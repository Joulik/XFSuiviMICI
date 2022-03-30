using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace XFSuiviMICI.Models
{
    public class LabWork
    {
        [PrimaryKey, AutoIncrement]
        public int LabWorkId { get; set; }
        public DateTime DateLabWork { get; set; }
        public string TestName { get; set; }
        public float TestValue { get; set; }
        public string TestUnit { get; set; }
    }
}
