using System;
using System.Linq;
using System.Windows.Forms;
using KartingClubApp.Models;
using KartingClubApp.Services;

namespace KartingClubApp
{
    /// <summary>
    /// Головна форма програми. Відображає списки гонщиків та заїздів
    /// і надає доступ до всіх основних функцій системи.
    /// </summary>
    public partial class MainForm : Form
    {
        private readonly KartingClubManager _manager;

        /// <summary>
        /// Конструктор. Ініціалізує менеджер, налаштовує таблиці та завантажує дані.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
            _manager = new KartingClubManager();
            ConfigureRacersGrid();
            ConfigureSessionsGrid();
            RefreshAll();
        }

        /// <summary>
        /// Налаштовує стовпці та параметри відображення таблиці гонщиків.
        /// </summary>
        private void ConfigureRacersGrid()
        {
            dgvRacers.AutoGenerateColumns = false;
            dgvRacers.ReadOnly = true;
            dgvRacers.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvRacers.MultiSelect = false;
            dgvRacers.AllowUserToAddRows = false;
            dgvRacers.AllowUserToDeleteRows = false;
            dgvRacers.RowHeadersVisible = false;

            dgvRacers.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colFirstName", HeaderText = "Ім'я", Width = 100 });
            dgvRacers.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colLastName", HeaderText = "Прізвище", Width = 120 });
            dgvRacers.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colLicense", HeaderText = "Номер ліцензії", Width = 120 });
            dgvRacers.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colCategory", HeaderText = "Категорія", Width = 110 });
            dgvRacers.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colRaces", HeaderText = "Заїздів", Width = 70 });
            dgvRacers.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colWins", HeaderText = "Перемог", Width = 70 });
            dgvRacers.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colBestLap", HeaderText = "Найкращий час (с)", Width = 140 });
        }

        /// <summary>
        /// Налаштовує стовпці та параметри відображення таблиці заїздів.
        /// </summary>
        private void ConfigureSessionsGrid()
        {
            dgvSessions.AutoGenerateColumns = false;
            dgvSessions.ReadOnly = true;
            dgvSessions.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSessions.MultiSelect = false;
            dgvSessions.AllowUserToAddRows = false;
            dgvSessions.RowHeadersVisible = false;

            dgvSessions.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colDate", HeaderText = "Дата та час", Width = 130 });
            dgvSessions.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colTrack", HeaderText = "Траса", Width = 160 });
            dgvSessions.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colDuration", HeaderText = "Тривалість", Width = 90 });
            dgvSessions.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colParticipants", HeaderText = "Учасників", Width = 90 });
            dgvSessions.Columns.Add(new DataGridViewTextBoxColumn
            { Name = "colStatus", HeaderText = "Статус", Width = 110 });
        }

        /// <summary>
        /// Оновлює обидві таблиці актуальними даними.
        /// </summary>
        private void RefreshAll()
        {
            RefreshRacersGrid();
            RefreshSessionsGrid();
        }

        /// <summary>
        /// Перезаповнює таблицю гонщиків. Зберігає Guid гонщика у властивості
        /// Tag кожного рядка для надійної ідентифікації при видаленні.
        /// </summary>
        private void RefreshRacersGrid()
        {
            dgvRacers.Rows.Clear();

            foreach (Racer racer in _manager.Racers)
            {
                string categoryDisplay = racer.Category switch
                {
                    RaceCategory.Amateur => "Аматор",
                    RaceCategory.Experienced => "Досвідчений",
                    RaceCategory.Professional => "Професіонал",
                    _ => racer.Category.ToString()
                };

                string bestLap = racer.Statistics.BestLapTime.HasValue
                    ? racer.Statistics.BestLapTime.Value.TotalSeconds.ToString("F2")
                    : "—";

                int rowIndex = dgvRacers.Rows.Add(
                    racer.FirstName,
                    racer.LastName,
                    racer.LicenseNumber,
                    categoryDisplay,
                    racer.Statistics.TotalRaces,
                    racer.Statistics.TotalWins,
                    bestLap
                );

                // Зберігаємо Id гонщика в Tag рядка для надійного пошуку
                dgvRacers.Rows[rowIndex].Tag = racer.Id;
            }
        }

        /// <summary>
        /// Перезаповнює таблицю заїздів. Зберігає Guid заїзду у властивості
        /// Tag кожного рядка для надійної ідентифікації при відкритті.
        /// </summary>
        private void RefreshSessionsGrid()
        {
            dgvSessions.Rows.Clear();

            foreach (RaceSession session in _manager.Sessions)
            {
                string statusDisplay = session.Status == SessionStatus.Scheduled
                    ? "Заплановано"
                    : "Завершено";

                int rowIndex = dgvSessions.Rows.Add(
                    session.SessionDate.ToString("dd.MM.yyyy HH:mm"),
                    session.TrackName,
                    session.DurationMinutes + " хв",
                    session.ParticipantsResults.Count,
                    statusDisplay
                );

                dgvSessions.Rows[rowIndex].Tag = session.Id;
            }
        }

        // Обробники кнопок — Гонщики

        /// <summary>
        /// Відкриває модальне вікно реєстрації нового гонщика.
        /// </summary>
        private void btnAddRacer_Click(object sender, EventArgs e)
        {
            using AddRacerForm form = new AddRacerForm(_manager);
            if (form.ShowDialog() == DialogResult.OK)
                RefreshAll();
        }

        /// <summary>
        /// Видаляє обраного гонщика після перевірки зв'язків та підтвердження.
        /// </summary>
        private void btnDeleteRacer_Click(object sender, EventArgs e)
        {
            DeleteSelectedRacer();
        }

        // Обробники кнопок — Заїзди

        /// <summary>
        /// Відкриває модальне вікно створення нового заїзду.
        /// </summary>
        private void btnCreateSession_Click(object sender, EventArgs e)
        {
            if (_manager.Racers.Count == 0)
            {
                MessageBox.Show(
                    "Неможливо створити заїзд: у системі немає зареєстрованих гонщиків.\n" +
                    "Будь ласка, спочатку додайте хоча б одного гонщика.",
                    "Недостатньо даних",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using CreateSessionForm form = new CreateSessionForm(_manager);
            if (form.ShowDialog() == DialogResult.OK)
                RefreshAll();
        }

        /// <summary>
        /// Відкриває вікно фіксації результатів для обраного заїзду.
        /// </summary>
        private void btnOpenSession_Click(object sender, EventArgs e)
        {
            OpenSelectedSession();
        }

        // Обробники клавіатури

        /// <summary>
        /// Обробляє натискання клавіші Delete у таблиці гонщиків.
        /// </summary>
        private void dgvRacers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                DeleteSelectedRacer();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Обробляє натискання Enter у таблиці заїздів для відкриття обраного заїзду.
        /// </summary>
        private void dgvSessions_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OpenSelectedSession();
                // Блокуємо стандартну поведінку Enter у DataGridView
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        /// <summary>
        /// Відкриває вікно заїзду при подвійному кліку на рядку таблиці заїздів.
        /// </summary>
        private void dgvSessions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
                OpenSelectedSession();
        }

        // Допоміжні методи

        /// <summary>
        /// Виконує логіку видалення обраного гонщика з таблиці:
        /// перевіряє зв'язки із заїздами та запитує підтвердження.
        /// </summary>
        private void DeleteSelectedRacer()
        {
            if (dgvRacers.CurrentRow == null) return;

            Guid racerId = (Guid)dgvRacers.CurrentRow.Tag;
            Racer racer = _manager.Racers.First(r => r.Id == racerId);

            // Перевіряємо наявність запланованих заїздів до підтвердження
            bool hasScheduledSessions = _manager.Sessions
                .Where(s => s.Status == SessionStatus.Scheduled)
                .Any(s => s.ParticipantsResults.ContainsKey(racerId));

            if (hasScheduledSessions)
            {
                MessageBox.Show(
                    $"Неможливо видалити гонщика {racer.FirstName} {racer.LastName}.\n" +
                    "Він є учасником запланованого заїзду.",
                    "Видалення неможливе",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            DialogResult confirm = MessageBox.Show(
                $"Ви дійсно бажаєте видалити гонщика {racer.FirstName} {racer.LastName}?\n" +
                "Цю дію неможливо скасувати.",
                "Підтвердження видалення",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.OK) return;

            _manager.DeleteRacer(racerId);
            RefreshAll();
        }

        /// <summary>
        /// Відкриває форму редагування для обраного гонщика.
        /// </summary>
        private void btnEditRacer_Click(object sender, EventArgs e)
        {
            if (dgvRacers.CurrentRow == null)
            {
                MessageBox.Show(
                    "Будь ласка, оберіть гонщика у таблиці для редагування.",
                    "Гонщика не обрано",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            Guid racerId = (Guid)dgvRacers.CurrentRow.Tag;
            Racer racer = _manager.Racers.First(r => r.Id == racerId);

            using EditRacerForm form = new EditRacerForm(_manager, racer);
            if (form.ShowDialog() == DialogResult.OK)
                RefreshAll();
        }

        /// <summary>
        /// Відкриває вікно фіксації результатів для обраного в таблиці заїзду.
        /// </summary>
        private void OpenSelectedSession()
        {
            if (dgvSessions.CurrentRow == null) return;

            Guid sessionId = (Guid)dgvSessions.CurrentRow.Tag;

            using FinishSessionForm form = new FinishSessionForm(_manager, sessionId);
            if (form.ShowDialog() == DialogResult.OK)
                RefreshAll();
        }

        /// <summary>
        /// Фільтрує таблицю гонщиків за прізвищем або номером ліцензії
        /// в режимі реального часу при введенні тексту.
        /// </summary>
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string query = txtSearch.Text.Trim().ToLower();

            dgvRacers.Rows.Clear();

            var filtered = string.IsNullOrEmpty(query)
                ? _manager.Racers
                : _manager.Racers.Where(r =>
                    (r.LastName?.ToLower().Contains(query) ?? false) ||
                    (r.LicenseNumber?.ToLower().Contains(query) ?? false));

            foreach (Racer racer in filtered)
            {
                string categoryDisplay = racer.Category switch
                {
                    RaceCategory.Amateur => "Аматор",
                    RaceCategory.Experienced => "Досвідчений",
                    RaceCategory.Professional => "Професіонал",
                    _ => racer.Category.ToString()
                };

                string bestLap = racer.Statistics.BestLapTime.HasValue
                    ? racer.Statistics.BestLapTime.Value.TotalSeconds.ToString("F2")
                    : "—";

                int rowIndex = dgvRacers.Rows.Add(
                    racer.FirstName,
                    racer.LastName,
                    racer.LicenseNumber,
                    categoryDisplay,
                    racer.Statistics.TotalRaces,
                    racer.Statistics.TotalWins,
                    bestLap
                );

                dgvRacers.Rows[rowIndex].Tag = racer.Id;
            }
        }
    }
}