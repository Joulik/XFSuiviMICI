using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;
using XFSuiviMICI.Models;

namespace XFSuiviMICI.ViewModels
{
    public class NewLabWorkVM
    {
        public Command SaveCommand { get; set; }

        public DateTime DateLabWork { get; set; }
        public string TestName { get; set; }
        public string TestValue { get; set; }
        public string TestUnit { get; set; }

        public NewLabWorkVM()
        {
            DateLabWork = DateTime.Now;
            SaveCommand = new Command(Save);
        }

        private void Save()
        {
            LabWork labWork = new LabWork
            {
                DateLabWork = DateLabWork,
                TestName = TestName,
                TestValue = float.Parse(TestValue, CultureInfo.InvariantCulture.NumberFormat),
                TestUnit = TestUnit,
            };

            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);

            conn.CreateTable<LabWork>();
            int rows = conn.Insert(labWork);
            conn.Close();

            if (rows > 0)
                App.Current.MainPage.DisplayAlert("", "Sauvegarde effectuée", "OK");
            else
                App.Current.MainPage.DisplayAlert("Problème", "Sauvegarde non enregistré", "OK");

            App.Current.MainPage.Navigation.PopAsync();
        }
    }
}
