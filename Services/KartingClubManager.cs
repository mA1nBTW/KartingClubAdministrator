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
        private readonly string _racersFilePath = "racers.json";
        private readonly string _sessionsFilePath = "sessions.json";

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
            LoadData();
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
            SaveData();
            return true;
        }

        /// <summary>
        /// Видаляє профіль гонщика з колекції, якщо він не є учасником
        /// жодного запланованого заїзду.
        /// </summary>
        /// <param name="racerId">Ідентифікатор гонщика для видалення.</param>
        /// <returns>
        /// <c>true</c> — якщо гонщика успішно видалено;
        /// <c>false</c> — якщо гонщик зареєстрований у запланованому заїзді.
        /// </returns>
        public bool DeleteRacer(Guid racerId)
        {
            bool hasScheduledSessions = Sessions
                .Where(s => s.Status == SessionStatus.Scheduled)
                .Any(s => s.ParticipantsResults.ContainsKey(racerId));

            if (hasScheduledSessions)
                return false;

            Racer racerToRemove = Racers.FirstOrDefault(r => r.Id == racerId);
            if (racerToRemove == null)
                return false;

            Racers.Remove(racerToRemove);
            SaveData();
            return true;
        }

        /// <summary>
        /// Створює новий заїзд та додає його до колекції.
        /// </summary>
        /// <param name="session">Об'єкт заїзду для додавання.</param>
        /// <returns>
        /// <c>true</c> — якщо заїзд успішно створено;
        /// <c>false</c> — якщо список учасників порожній.
        /// </returns>
        public bool CreateSession(RaceSession session)
        {
            if (session.ParticipantsResults.Count == 0)
                return false;

            Sessions.Add(session);
            SaveData();
            return true;
        }

        /// <summary>
        /// Завершує заїзд, оновлює статистику всіх учасників та визначає переможця.
        /// Переможцем вважається гонщик із найменшим часом кола.
        /// </summary>
        /// <param name="sessionId">Ідентифікатор заїзду для завершення.</param>
        /// <returns>
        /// <c>true</c> — якщо заїзд успішно завершено;
        /// <c>false</c> — якщо час кола введено не для всіх учасників,
        /// або заїзд із вказаним ідентифікатором не знайдено.
        /// </returns>
        public bool FinishSession(Guid sessionId)
        {
            RaceSession session = Sessions.FirstOrDefault(s => s.Id == sessionId);
            if (session == null)
                return false;

            bool allResultsEntered = session.ParticipantsResults.Values.All(t => t.HasValue);
            if (!allResultsEntered)
                return false;

            Guid winnerId = session.ParticipantsResults
                .OrderBy(p => p.Value)
                .First()
                .Key;

            foreach (KeyValuePair<Guid, TimeSpan?> entry in session.ParticipantsResults)
            {
                Racer racer = Racers.FirstOrDefault(r => r.Id == entry.Key);
                if (racer == null)
                    continue;

                racer.Statistics.TotalRaces++;

                if (entry.Key == winnerId)
                    racer.Statistics.TotalWins++;

                TimeSpan lapTime = entry.Value.Value;
                if (racer.Statistics.BestLapTime == null || lapTime < racer.Statistics.BestLapTime)
                    racer.Statistics.BestLapTime = lapTime;
            }

            session.Status = SessionStatus.Completed;
            SaveData();
            return true;
        }

        /// <summary>
        /// Серіалізує поточні колекції гонщиків та заїздів у локальні JSON-файли.
        /// </summary>
        public void SaveData()
        {
            File.WriteAllText(_racersFilePath, JsonSerializer.Serialize(Racers, _jsonOptions));
            File.WriteAllText(_sessionsFilePath, JsonSerializer.Serialize(Sessions, _jsonOptions));
        }

        /// <summary>
        /// Десеріалізує колекції гонщиків та заїздів із локальних JSON-файлів.
        /// Якщо файли відсутні, колекції залишаються порожніми.
        /// </summary>
        public void LoadData()
        {
            if (File.Exists(_racersFilePath))
            {
                string racersJson = File.ReadAllText(_racersFilePath);
                Racers = JsonSerializer.Deserialize<List<Racer>>(racersJson) ?? new List<Racer>();
            }

            if (File.Exists(_sessionsFilePath))
            {
                string sessionsJson = File.ReadAllText(_sessionsFilePath);
                Sessions = JsonSerializer.Deserialize<List<RaceSession>>(sessionsJson) ?? new List<RaceSession>();
            }
        }
    }
}
