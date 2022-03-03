using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using XFSuiviMICI.Models;

namespace XFSuiviMICI.ViewModels
{
    public class NewDailyReportVM
    {
        public Command SaveCommand { get; set; }
        public bool BloodOrMucus { get; set; }
        public int BowelMovement { get; set; }
        public DateTime DateDailyReport { get; set; }
        public string Diastolic { get; set; }
        public bool AbdominalPain { get; set; }
        public bool Diarrhea { get; set; }
        public string HeartRate { get; set; }
        public string Systolic { get; set; }
        public bool Tiredness { get; set; }
        public string Weight { get; set; }

        public NewDailyReportVM()
        {
            SaveCommand = new Command(Save);
            BowelMovement = 0;
            DateDailyReport = DateTime.Now;
            AbdominalPain = false;
            BloodOrMucus = false;
            Diarrhea = false;
            Tiredness = false;
        }

        private void Save()
        {
            var ci = (CultureInfo)CultureInfo.CurrentCulture.Clone();
            ci.NumberFormat.NumberDecimalSeparator = ".";

            DailyReport dailyReport = new DailyReport
            {
                BloodOrMucus = BloodOrMucus,
                BowelMovement = BowelMovement, //int.Parse(BowelMovement),
                DateDailyReport = DateDailyReport,
                Diastolic = int.Parse(Diastolic),
                AbdominalPain = AbdominalPain,
                Diarrhea = Diarrhea,
                HeartRate = int.Parse(HeartRate),
                Systolic = int.Parse(Systolic),
                Tiredness = Tiredness,
                Weight = float.Parse(Weight, ci),
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<DailyReport>();
                int rows = conn.Insert(dailyReport);
                conn.Close();

                if (rows > 0)
                    App.Current.MainPage.DisplayAlert("", "Sauvegarde effectuée", "OK");
                else
                    App.Current.MainPage.DisplayAlert("Problème", "Sauvegarde non enregistrée", "OK");

                App.Current.MainPage.Navigation.PopAsync();
            }   
        }
    }
}
