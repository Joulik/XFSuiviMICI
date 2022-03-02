using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XFSuiviMICI.Models;

namespace XFSuiviMICI.ViewModels
{
    public class NewTreatmentVM
    {
        public Command SaveCommand { get; set; }
        public string MedicationName { get; set; }
        public DateTime StartDate { get; set; }
        public bool MedicationNotActive { get; set; }

        public NewTreatmentVM()
        {
            SaveCommand = new Command(Save);
            StartDate = DateTime.Now;
            MedicationNotActive = false;
        }

        private void Save(object obj)
        {
            Treatment treatment = new Treatment()
            {
                MedicationName = MedicationName,
                StartDate = StartDate,
                MedicationNotActive = MedicationNotActive,
            };

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Treatment>();
                int rows = conn.Insert(treatment);
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
