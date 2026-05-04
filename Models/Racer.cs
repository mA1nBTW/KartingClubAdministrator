using System;
using System.Collections.Generic;
using System.Text;

namespace KartingClubApp.Models
{
    /// <summary>
    /// Перелік доступних категорій гонщиків.
    /// Використовується для уникнення помилок при ручному введенні категорій.
    /// </summary>
    public enum RaceCategory
    {
        Amateur,
        Experienced,
        Professional
    }

    /// <summary>
    /// Головна сутність - Гонщик (клієнт картинг-клубу).
    /// </summary>
    public class Racer
    {
        /// <summary>
        /// Унікальний системний ідентифікатор гонщика.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Ім'я гонщика.
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Прізвище гонщика.
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Дата народження. Використовується для перевірки віку (> 10 років).
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Унікальний номер ліцензії в реальному світі.
        /// </summary>
        public string? LicenseNumber { get; set; }

        /// <summary>
        /// Контактний телефон
        /// </summary>
        public string? PhoneNumber { get; set; }

        /// <summary>
        /// Рівень підготовки гонщика.
        /// </summary>
        public RaceCategory Category { get; set; }

        /// <summary>
        /// Дата реєстрації гонщика в системі.
        /// </summary>
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Статистика досягнень гонщика. Демонстрація принципу Композиції.
        /// </summary>
        public RacerStatistics Statistics { get; set; }

        /// <summary>
        /// Конструктор для ініціалізації нового гонщика.
        /// </summary>
        public Racer()
        {
            Id = Guid.NewGuid();
            RegistrationDate = DateTime.Now;

            Statistics = new RacerStatistics();
        }
    }
}
