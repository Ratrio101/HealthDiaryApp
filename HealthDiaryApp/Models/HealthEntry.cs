using System;
using SQLite;

namespace HealthDiaryApp.Models
{
    public class HealthEntry
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        // Активность
        public int Steps { get; set; }

        // Сон
        public double SleepHours { get; set; }

        // Питание
        public int Calories { get; set; }

        // Показатели здоровья
        public int Pulse { get; set; }
        public int Pressure { get; set; }
        public double Weight { get; set; }
    }
}
