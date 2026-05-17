using System;
using System.Windows.Forms;
using KartingClubApp.Models;
using KartingClubApp.Services;

namespace KartingClubApp
{
    /// <summary>
    /// Модальна форма редагування даних існуючого гонщика.
    /// Поля форми заповнюються поточними даними обраного гонщика.
    /// </summary>
    public partial class EditRacerForm : Form
    {
        private readonly KartingClubManager _manager;
        private readonly Racer _racer;

        /// <summary>
        /// Конструктор. Заповнює поля форми поточними даними гонщика.
        /// </summary>
        /// <param name="manager">Екземпляр менеджера картинг-клубу.</param>
        /// <param name="racer">Гонщик, дані якого редагуються.</param>
        public EditRacerForm(KartingClubManager manager, Racer racer)
        {
            InitializeComponent();
            _manager = manager;
            _racer = racer;

            FillCategoryComboBox();
            LoadRacerData();
        }

        /// <summary>
        /// Заповнює випадаючий список категорій.
        /// </summary>
        private void FillCategoryComboBox()
        {
            cmbCategory.Items.Add("Аматор");
            cmbCategory.Items.Add("Досвідчений");
            cmbCategory.Items.Add("Професіонал");
        }

        /// <summary>
        /// Завантажує поточні дані гонщика у поля форми.
        /// </summary>
        private void LoadRacerData()
        {
            txtFirstName.Text = _racer.FirstName;
            txtLastName.Text = _racer.LastName;
            txtLicense.Text = _racer.LicenseNumber;
            cmbCategory.SelectedIndex = (int)_racer.Category;
        }

        /// <summary>
        /// Виконує валідацію та зберігає оновлені дані гонщика.
        /// </summary>
        private void btnSave_Click(object sender, EventArgs e)
        {
            lblError.Text = string.Empty;

            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string license = txtLicense.Text.Trim();

            if (string.IsNullOrEmpty(firstName))
            { lblError.Text = "Поле \"Ім'я\" є обов'язковим."; return; }

            if (string.IsNullOrEmpty(lastName))
            { lblError.Text = "Поле \"Прізвище\" є обов'язковим."; return; }

            if (string.IsNullOrEmpty(license))
            { lblError.Text = "Поле \"Номер ліцензії\" є обов'язковим."; return; }

            Racer updated = new Racer
            {
                Id = _racer.Id,
                FirstName = firstName,
                LastName = lastName,
                LicenseNumber = license,
                Category = (RaceCategory)cmbCategory.SelectedIndex,
                Statistics = _racer.Statistics
            };

            bool success = _manager.EditRacer(updated);

            if (!success)
            {
                lblError.Text = $"Гонщик з ліцензією \"{license}\" вже існує в системі.";
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}