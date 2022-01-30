using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFSuiviMICI.Models
{
    public class DailyReport
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int BowelMouvement { get; set; }
        public DateTime Date { get; set; }
        public int Diastolic { get; set; }
        public bool FeelingPain { get; set; }
        public bool HavingDiarrhea { get; set; }
        public int HeartRate { get; set; }
        public int Systolic { get; set; }
        public int Tiredness { get; set; }
    }
}
