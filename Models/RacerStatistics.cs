using System;
using System.Collections.Generic;
using System.Text;

namespace KartingClubApp.Models
{
    /// <summary>
    /// Клас для зберігання спортивної статистики гонщика.
    /// Реалізований як частина композиції в класі Racer.
    /// </summary>
    public class RacerStatistics
    {
        /// <summary>
        /// Загальна кількість завершених заїздів.
        /// </summary>
        public int TotalRaces { get; set; }

        /// <summary>
        /// Кількість перемог (найшвидше коло у заїзді).
        /// </summary>
        public int TotalWins { get; set; }

        /// <summary>
        /// Найкращий час кола за всю історію (якщо є).
        /// </summary>
        public TimeSpan? BestLapTime { get; set; }

        /// <summary>
        /// Конструктор за замовчуванням. Ініціалізує початкову (нульову) статистику.
        /// </summary>
        public RacerStatistics()
        {
            TotalRaces = 0;
            TotalWins = 0;
            BestLapTime = null;
        }
    }
}
