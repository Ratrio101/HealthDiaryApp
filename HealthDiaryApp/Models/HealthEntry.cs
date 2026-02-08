using System;
using SQLite; // работа с SQLite

namespace HealthDiaryApp.Models
{
    public class HealthEntry // ведение дневника
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } // номер записи

        public DateTime Date { get; set; } // дата

        // Активность (в шагах)
        public int Steps { get; set; }

        // Сон (в часах)
        public double SleepHours { get; set; }

        // Питание (калории) 
        public int Calories { get; set; }

        // Показатели здоровья
        public int Pulse { get; set; } // пульс
        public int Pressure { get; set; } // давление
        public double Weight { get; set; } // вес
    }
}
