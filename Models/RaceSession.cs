using System;
using System.Collections.Generic;
using System.Text;

namespace KartingClubApp.Models
{
    /// <summary>
    /// Перелік можливих статусів заїзду.
    /// </summary>
    public enum SessionStatus
    {
        Scheduled,
        Completed
    }

    /// <summary>
    /// Сутність, що описує спортивну подію (Заїзд) на трасі.
    /// </summary>
    public class RaceSession
    {
        /// <summary>
        /// Унікальний ідентифікатор заїзду.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Запланована дата та час початку заїзду.
        /// </summary>
        public DateTime SessionDate { get; set; }

        /// <summary>
        /// Назва траси, на якій відбувається заїзд.
        /// </summary>
        public string? TrackName { get; set; }

        /// <summary>
        /// Тривалість заїзду у хвилинах.
        /// </summary>
        public int DurationMinutes { get; set; }

        /// <summary>
        /// Поточний статус заїзду
        /// </summary>
        public SessionStatus Status { get; set; }

        /// <summary>
        /// Словник учасників заїзду та їх результатів.
        /// Ключ (Guid) - ID гонщика (Агрегація).
        /// Значення (TimeSpan?) - Найкращий час кола (null, якщо час ще не внесено).
        /// </summary>
        public Dictionary<Guid, TimeSpan?> ParticipantsResults { get; set; }

        /// <summary>
        /// Конструктор за замовчуванням для створення нового заїзду.
        /// </summary>
        public RaceSession()
        {
            Id = Guid.NewGuid();
            Status = SessionStatus.Scheduled;
            ParticipantsResults = new Dictionary<Guid, TimeSpan?>();
        }
    }
}
