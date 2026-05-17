using System;
using System.Windows.Forms;
using KartingClubApp.Models;
using KartingClubApp.Services;

namespace KartingClubApp
{
    /// <summary>
    /// Модальна форма створення нового заїзду.
    /// Дозволяє задати параметри події та обрати учасників зі списку гонщиків.
    /// </summary>
    public partial class CreateSessionForm : Form
    {
        private readonly KartingClubManager _manager;

        /// <summary>
        /// Конструктор. Отримує посилання на менеджер і заповнює список гонщиків.
        /// </summary>
        /// <param name="manager">Екземпляр менеджера картинг-клубу.</param>
        public CreateSessionForm(KartingClubManager manager)
        {
            InitializeComponent();
            _manager = manager;
            FillRacersList();
        }

        // Ініціалізація

        /// <summary>
        /// Заповнює CheckedListBox списком усіх зареєстрованих гонщиків.
        /// У властивості Tag кожного елемента зберігається Guid гонщика.
        /// </summary>
        private void FillRacersList()
        {
            clbRacers.Items.Clear();

            foreach (Racer racer in _manager.Racers)
            {
                // Відображаємо ПІБ і ліцензію для зручності вибору
                string displayText = $"{racer.LastName} {racer.FirstName} (№{racer.LicenseNumber})";

                // Зберігаємо Id гонщика через окремий клас-обгортку
                clbRacers.Items.Add(new RacerListItem(racer.Id, displayText));
            }
        }

        // Обробники кнопок

        /// <summary>
        /// Виконує валідацію полів і, у разі успіху, створює новий заїзд.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            string trackName = txtTrackName.Text.Trim();

            // --- Валідація ---
            string errorMessage = ValidateInputs(trackName);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                lblError.Text = errorMessage;
                return;
            }

            // --- Створення об'єкта заїзду ---
            RaceSession newSession = new RaceSession
            {
                SessionDate = dtpSessionDate.Value,
                TrackName = trackName,
                DurationMinutes = (int)nudDuration.Value
            };

            // --- Додавання обраних учасників ---
            foreach (RacerListItem item in clbRacers.CheckedItems)
            {
                newSession.ParticipantsResults[item.RacerId] = null;
            }

            // --- Спроба збереження через менеджер ---
            bool success = _manager.CreateSession(newSession);

            if (!success)
            {
                lblError.Text = "Будь ласка, оберіть хоча б одного учасника заїзду.";
                return;
            }

            DialogResult = DialogResult.OK;
        }

        // Валідація

        /// <summary>
        /// Перевіряє коректність введених даних форми.
        /// </summary>
        /// <returns>Рядок з описом помилки, або порожній рядок якщо дані коректні.</returns>
        private string ValidateInputs(string trackName)
        {
            if (string.IsNullOrEmpty(trackName))
                return "Поле \"Назва траси\" є обов'язковим для заповнення.";

            if (clbRacers.CheckedItems.Count == 0)
                return "Будь ласка, оберіть хоча б одного учасника заїзду.";

            return string.Empty;
        }
    }

    // Допоміжний клас

    /// <summary>
    /// Клас-обгортка для елементів CheckedListBox.
    /// Зберігає Guid гонщика разом з рядком для відображення.
    /// </summary>
    internal class RacerListItem
    {
        /// <summary>
        /// Ідентифікатор гонщика.
        /// </summary>
        public Guid RacerId { get; }

        private readonly string _displayText;

        /// <summary>
        /// Конструктор елемента списку.
        /// </summary>
        /// <param name="racerId">Ідентифікатор гонщика.</param>
        /// <param name="displayText">Рядок для відображення у списку.</param>
        public RacerListItem(Guid racerId, string displayText)
        {
            RacerId = racerId;
            _displayText = displayText;
        }

        /// <summary>
        /// Повертає рядок відображення — саме його показує CheckedListBox.
        /// </summary>
        public override string ToString() => _displayText;
    }
}