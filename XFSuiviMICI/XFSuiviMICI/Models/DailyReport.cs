using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFSuiviMICI.Models
{
    public class DailyReport
    {
        [PrimaryKey, AutoIncrement]
        public int DailyReportId { get; set; }
        public bool BloodOrMucus { get; set; }
        public int BowelMovement { get; set; }
        public DateTime Date { get; set; }
        public int Diastolic { get; set; }
        public bool AbdominalPain { get; set; }
        public bool Diarrhea { get; set; }
        public int HeartRate { get; set; }
        public int Systolic { get; set; }
        public bool Tiredness { get; set; }
        public float Weight { get; set; }
    }
}
