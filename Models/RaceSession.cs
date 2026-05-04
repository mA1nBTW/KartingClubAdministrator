using System;
using System.Collections.Generic;
using System.Text;

namespace KartingClubApp.Models
{
    //Перелік можливих статусів заїзду.
    public enum SessionStatus
    {
        Scheduled,
        Completed
    }

    //Сутність, що описує спортивну подію (Заїзд) на трасі.
    public class RaceSession
    {
        //Унікальний ідентифікатор заїзду.
        public Guid Id { get; set; }

        //Запланована дата та час початку заїзду.
        public DateTime SessionDate { get; set; }

        //Назва траси, на якій відбувається заїзд.
        public string TrackName { get; set; }

        //Тривалість заїзду у хвилинах.
        public int DurationMinutes { get; set; }

        //Поточний статус заїзду
        public SessionStatus Status { get; set; }

        //Словник учасників заїзду та їх результатів.
        //Ключ (Guid) - ID гонщика (Агрегація).
        //Значення (TimeSpan?) - Найкращий час кола (null, якщо час ще не внесено).
        public Dictionary<Guid, TimeSpan?> ParticipantsResults { get; set; }

        //Конструктор за замовчуванням для створення нового заїзду.
        public RaceSession()
        {
            Id = Guid.NewGuid();
            Status = SessionStatus.Scheduled;
            ParticipantsResults = new Dictionary<Guid, TimeSpan?>();
        }
    }
}
