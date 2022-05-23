using System;
using SQLite;

namespace RPECal.Models
{
    public class RPE
    {
        [PrimaryKey, AutoIncrement]
        public int id { get; set; }
        public double Rpe { get; set; }
        public int Reps { get; set; }
        public double Value { get; set; }
    }
}
