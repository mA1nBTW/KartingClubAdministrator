using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using KartingClubApp.Models;

namespace KartingClubApp.Services
{
    /// <summary>
    /// Головний керуючий клас системи, реалізований за патерном "Фасад".
    /// Координує роботу з колекціями гонщиків та заїздів, виконує валідацію,
    /// розрахунок статистики та збереження даних у форматі JSON.
    /// </summary>
    public class KartingClubManager
    {
        private readonly string _racerFilePath = "racers.json";
        private readonly string _sessionFilePath = "sessions.json";

        private readonly JsonSerializerOptions _jsonOptions = new JsonSerializerOptions
        {
            WriteIndented = true
        };

        /// <summary>
        /// Колекція всіх зареєстрованих у системі гонщиків.
        /// </summary>
        public List<Racer> Racers { get; private set; }

        /// <summary>
        /// Колекція всіх заїздів у системі.
        /// </summary>
        public List<RaceSession> Sessions { get; private set; }

        /// <summary>
        /// Конструктор. Ініціалізує порожні колекції та завантажує
        /// збережені дані з файлів, якщо вони існують.
        /// </summary>
        public KartingClubManager()
        {
            Racers = new List<Racer>();
            Sessions = new List<RaceSession>();
            //LoadData();
        }

        /// <summary>
        /// Додає нового гонщика до колекції після перевірки валідності даних.
        /// </summary>
        /// <param name="racer">Об'єкт гонщика для додавання.</param>
        /// <returns>
        /// <c>true</c> — якщо гонщика успішно додано;
        /// <c>false</c> — якщо номер ліцензії вже існує в системі.
        /// </returns>
        public bool AddRacer(Racer racer)
        {
            bool licenseExists = Racers.Any(r => r.LicenseNumber == racer.LicenseNumber);
            if (licenseExists) return false;

            Racers.Add(racer);
            //SaveData();
            return true;
        }
    }
}
