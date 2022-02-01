using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFSuiviMICI.Models
{
    public class Treatment
    {
        [PrimaryKey, AutoIncrement]
        public int TreatmentId { get; set; }
        public string Medication { get; set; }
        public int MedicationDosage { get; set; }
        public DateTime StartDate { get; set; }
        public bool Active { get; set; }

    }
}
