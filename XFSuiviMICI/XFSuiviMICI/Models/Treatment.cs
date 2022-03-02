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
        public string MedicationName { get; set; }
        public int MedicationDosage { get; set; }
        public DateTime StartDate { get; set; }
        public bool MedicationNotActive { get; set; }

    }
}
