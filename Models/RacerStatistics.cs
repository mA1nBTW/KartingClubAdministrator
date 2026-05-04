using System;
using System.Collections.Generic;
using System.Text;

//Клас для зберігання спортивної статистики гонщика.
//Реалізований як частина композиції в класі Racer.
namespace KartingClubApp.Models
{
    public class RacerStatistics
    {
        //Загальна кількість завершених заїздів.
        public int TotalRaces { get; set; }

        //Кількість перемог (найшвидше коло у заїзді).
        public int TotalWins { get; set; }

        //Найкращий час кола за всю історію (якщо є).
        public TimeSpan? BestLapTime { get; set; }

        //Конструктор за замовчуванням. Ініціалізує початкову (нульову) статистику.
        public RacerStatistics()
        {
            TotalRaces = 0;
            TotalWins = 0;
            BestLapTime = null;
        }
    }
}
