using System;
using System.Windows.Forms;
using KartingClubApp.Models;
using KartingClubApp.Services;

namespace KartingClubApp
{
    /// <summary>
    /// Модальна форма реєстрації нового гонщика в системі.
    /// Виконує валідацію введених даних перед збереженням.
    /// </summary>
    public partial class AddRacerForm : Form
    {
        private readonly KartingClubManager _manager;

        /// <summary>
        /// Конструктор. Отримує посилання на менеджер і заповнює список категорій.
        /// </summary>
        /// <param name="manager">Екземпляр менеджера картинг-клубу.</param>
        public AddRacerForm(KartingClubManager manager)
        {
            InitializeComponent();
            _manager = manager;
            FillCategoryComboBox();
        }

        /// <summary>
        /// Заповнює випадаючий список категорій українськими назвами.
        /// Індекс елемента відповідає значенню enum RaceCategory.
        /// </summary>
        private void FillCategoryComboBox()
        {
            cmbCategory.Items.Add("Аматор");
            cmbCategory.Items.Add("Досвідчений");
            cmbCategory.Items.Add("Професіонал");
            cmbCategory.SelectedIndex = 0;
        }

        // Обробники кнопок

        /// <summary>
        /// Виконує валідацію полів і, у разі успіху, зберігає нового гонщика.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            // Очищуємо попередні повідомлення про помилки
            lblError.Text = string.Empty;

            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string license = txtLicense.Text.Trim();

            // Валідація
            string errorMessage = ValidateInputs(firstName, lastName, license);
            if (!string.IsNullOrEmpty(errorMessage))
            {
                lblError.Text = errorMessage;
                return;
            }

            // Створення об'єкта
            Racer newRacer = new Racer
            {
                FirstName = firstName,
                LastName = lastName,
                LicenseNumber = license,
                Category = (RaceCategory)cmbCategory.SelectedIndex
            };

            // Спроба збереження через менеджер
            bool success = _manager.AddRacer(newRacer);

            if (!success)
            {
                lblError.Text = $"Гонщик з номером ліцензії \"{license}\" вже існує в системі.";
                txtLicense.Focus();
                return;
            }

            // Повідомляємо MainForm про успішне збереження
            DialogResult = DialogResult.OK;
        }

        // Валідація

        /// <summary>
        /// Перевіряє коректність введених даних.
        /// </summary>
        /// <returns>Рядок з описом помилки, або порожній рядок якщо дані коректні.</returns>
        private string ValidateInputs(string firstName, string lastName, string license)
        {
            if (string.IsNullOrEmpty(firstName))
                return "Поле \"Ім'я\" є обов'язковим для заповнення.";

            if (string.IsNullOrEmpty(lastName))
                return "Поле \"Прізвище\" є обов'язковим для заповнення.";

            if (string.IsNullOrEmpty(license))
                return "Поле \"Номер ліцензії\" є обов'язковим для заповнення.";

            return string.Empty;
        }
    }
}