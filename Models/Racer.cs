using System;
using System.Collections.Generic;
using System.Text;

namespace KartingClubApp.Models
{
    //Перелік доступних категорій гонщиків.
    //Використовується для уникнення помилок при ручному введенні категорій.
    public enum RaceCategory
    {
        Amateur,
        Experienced,
        Professional
    }

    //Головна сутність - Гонщик (клієнт картинг-клубу).
    public class Racer
    {
        //Унікальний системний ідентифікатор гонщика.
        public Guid Id { get; set; }

        //Ім'я гонщика.
        public string FirstName { get; set; }

        //Прізвище гонщика.
        public string LastName { get; set; }

        //Дата народження. Використовується для перевірки віку (> 10 років).
        public DateTime DateOfBirth { get; set; }

        //Унікальний номер ліцензії в реальному світі.
        public string LicenseNumber { get; set; }

        //Контактний телефон
        public string PhoneNumber { get; set; }

        //Рівень підготовки гонщика.
        public RaceCategory Category { get; set; }

        //Дата реєстрації гонщика в системі.
        public DateTime RegistrationDate { get; set; }

        // Статистика досягнень гонщика. Демонстрація принципу Композиції.
        public RacerStatistics Statistics { get; set; }

        //Конструктор для ініціалізації нового гонщика.
        public Racer()
        {
            Id = Guid.NewGuid();
            RegistrationDate = DateTime.Now;

            Statistics = new RacerStatistics();
        }
    }
}
