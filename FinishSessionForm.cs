using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using KartingClubApp.Models;
using KartingClubApp.Services;

namespace KartingClubApp
{
    /// <summary>
    /// Модальна форма фіксації результатів заїзду.
    /// Відображає список учасників з полями для введення часу кола.
    /// Для завершених заїздів переходить у режим перегляду.
    /// </summary>
    public partial class FinishSessionForm : Form
    {
        private readonly KartingClubManager _manager;
        private readonly Guid _sessionId;
        private RaceSession _session;

        // Індекс стовпця з часом кола у таблиці — для зручного звернення
        private const int LapTimeColumnIndex = 2;

        /// <summary>
        /// Конструктор. Завантажує дані заїзду і налаштовує форму.
        /// </summary>
        /// <param name="manager">Екземпляр менеджера картинг-клубу.</param>
        /// <param name="sessionId">Ідентифікатор заїзду для відображення.</param>
        public FinishSessionForm(KartingClubManager manager, Guid sessionId)
        {
            InitializeComponent();
            _manager = manager;
            _sessionId = sessionId;
            _session = _manager.Sessions.First(s => s.Id == sessionId);

            ConfigureGrid();
            LoadSessionData();
        }

        // Налаштування та завантаження даних

        /// <summary>
        /// Налаштовує стовпці таблиці результатів.
        /// Стовпець з часом кола є редагованим лише для запланованих заїздів.
        /// </summary>
        private void ConfigureGrid()
        {
            dgvResults.AutoGenerateColumns = false;
            dgvResults.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvResults.MultiSelect = false;
            dgvResults.AllowUserToAddRows = false;
            dgvResults.RowHeadersVisible = false;
            dgvResults.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colName",
                HeaderText = "Гонщик",
                Width = 180,
                ReadOnly = true
            });

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLicense",
                HeaderText = "Ліцензія",
                Width = 110,
                ReadOnly = true
            });

            // Стовпець часу — єдиний редагований
            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colLapTime",
                HeaderText = "Час кола (сек)",
                Width = 130,
                ReadOnly = false
            });

            dgvResults.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colResult",
                HeaderText = "Результат",
                Width = 110,
                ReadOnly = true
            });
        }

        /// <summary>
        /// Завантажує інформацію про заїзд в інформаційну панель і таблицю.
        /// Налаштовує режим форми залежно від статусу заїзду.
        /// </summary>
        private void LoadSessionData()
        {
            // --- Інформаційна панель ---
            lblTrack.Text = $"Траса: {_session.TrackName}";
            lblDate.Text = $"Дата: {_session.SessionDate:dd.MM.yyyy HH:mm}";
            lblStatus.Text = _session.Status == SessionStatus.Scheduled
                ? "Статус: Заплановано"
                : "Статус: Завершено";

            // --- Заповнення таблиці ---
            dgvResults.Rows.Clear();

            foreach (var entry in _session.ParticipantsResults)
            {
                Racer racer = _manager.Racers.FirstOrDefault(r => r.Id == entry.Key);
                if (racer == null) continue;

                string lapTime = entry.Value.HasValue
                    ? entry.Value.Value.TotalSeconds.ToString("F2")
                    : string.Empty;

                string result = GetResultLabel(entry.Key);

                int rowIndex = dgvResults.Rows.Add(
                    $"{racer.LastName} {racer.FirstName}",
                    racer.LicenseNumber,
                    lapTime,
                    result
                );

                dgvResults.Rows[rowIndex].Tag = entry.Key;
            }

            // --- Режим залежно від статусу ---
            ConfigureFormMode();
        }

        /// <summary>
        /// Налаштовує режим форми: редагування для запланованих заїздів,
        /// перегляд — для завершених. Підсвічує переможця зеленим.
        /// </summary>
        private void ConfigureFormMode()
        {
            bool isCompleted = _session.Status == SessionStatus.Completed;

            // Блокуємо редагування стовпця часу для завершених заїздів
            dgvResults.Columns[LapTimeColumnIndex].ReadOnly = isCompleted;
            dgvResults.ReadOnly = isCompleted;

            // Показуємо потрібну кнопку
            btnFinish.Visible = !isCompleted;
            btnClose.Visible = isCompleted;

            // Підсвічуємо переможця для завершеного заїзду
            if (isCompleted)
                HighlightWinner();
        }

        /// <summary>
        /// Повертає текстову мітку результату для гонщика у завершеному заїзді.
        /// </summary>
        private string GetResultLabel(Guid racerId)
        {
            if (_session.Status != SessionStatus.Completed)
                return string.Empty;

            Guid? winnerId = _session.ParticipantsResults
                .Where(p => p.Value.HasValue)
                .OrderBy(p => p.Value)
                .FirstOrDefault().Key;

            return racerId == winnerId ? "🏆 Переможець" : string.Empty;
        }

        /// <summary>
        /// Підсвічує рядок переможця зеленим фоном у таблиці.
        /// </summary>
        private void HighlightWinner()
        {
            foreach (DataGridViewRow row in dgvResults.Rows)
            {
                string result = row.Cells["colResult"].Value?.ToString() ?? string.Empty;
                if (result.Contains("Переможець"))
                {
                    row.DefaultCellStyle.BackColor = Color.LightGreen;
                    row.DefaultCellStyle.ForeColor = Color.DarkGreen;
                    row.DefaultCellStyle.SelectionBackColor = Color.MediumSeaGreen;
                    row.DefaultCellStyle.SelectionForeColor = Color.White;
                }
            }
        }

        // Валідація введених даних

        /// <summary>
        /// Перевіряє коректність введеного часу кола для кожного учасника.
        /// Повертає словник Guid → TimeSpan у разі успіху, або null — при помилці.
        /// </summary>
        private Dictionary<Guid, TimeSpan>? CollectAndValidateResults()
        {
            var results = new Dictionary<Guid, TimeSpan>();

            foreach (DataGridViewRow row in dgvResults.Rows)
            {
                string cellValue = row.Cells[LapTimeColumnIndex].Value?.ToString()?.Trim()
                                   ?? string.Empty;

                if (string.IsNullOrEmpty(cellValue))
                {
                    Guid racerId = (Guid)row.Tag;
                    Racer racer = _manager.Racers.First(r => r.Id == racerId);
                    lblError.Text = $"Будь ласка, введіть час кола для гонщика: " +
                                    $"{racer.LastName} {racer.FirstName}.";
                    row.Cells[LapTimeColumnIndex].Selected = true;
                    return null;
                }

                if (!double.TryParse(cellValue,
                        System.Globalization.NumberStyles.Any,
                        System.Globalization.CultureInfo.InvariantCulture,
                        out double seconds) || seconds <= 0)
                {
                    lblError.Text = "Час кола має бути додатнім числом (наприклад: 58.34).";
                    row.Cells[LapTimeColumnIndex].Selected = true;
                    return null;
                }

                results[(Guid)row.Tag] = TimeSpan.FromSeconds(seconds);
            }

            return results;
        }

        // Обробники кнопок

        /// <summary>
        /// Завершує заїзд: валідує результати, передає їх менеджеру та оновлює форму.
        /// </summary>
        private void btnFinish_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            // Збираємо і перевіряємо результати
            var results = CollectAndValidateResults();
            if (results == null) return;

            // Записуємо час кола в об'єкт заїзду перед передачею менеджеру
            foreach (var entry in results)
                _session.ParticipantsResults[entry.Key] = entry.Value;

            bool success = _manager.FinishSession(_sessionId);

            if (!success)
            {
                lblError.Text = "Не вдалося завершити заїзд. Перевірте коректність даних.";
                return;
            }

            // Перезавантажуємо об'єкт заїзду з актуальними даними
            _session = _manager.Sessions.First(s => s.Id == _sessionId);
            LoadSessionData();

            MessageBox.Show(
                "Заїзд успішно завершено! Статистику гонщиків оновлено.",
                "Заїзд завершено",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Закриває форму перегляду завершеного заїзду.
        /// </summary>
        private void btnClose_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        // Обробники клавіатури

        /// <summary>
        /// Блокує стандартну поведінку Enter у DataGridView,
        /// щоб курсор не переходив на наступний рядок при підтвердженні.
        /// </summary>
        private void dgvResults_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }
    }
}