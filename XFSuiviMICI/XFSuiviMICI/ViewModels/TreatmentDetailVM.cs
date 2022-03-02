using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XFSuiviMICI.Models;

namespace XFSuiviMICI.ViewModels
{
    public class TreatmentDetailVM
    {
        public Command DeleteCommand { get; set; }
        public Command UpdateCommand { get; set; }
        public Treatment SelectedTreatment { get; set; }

        public TreatmentDetailVM()
        {
            DeleteCommand = new Command(Delete);
            UpdateCommand = new Command(Update);
        }

        private void Update(object obj)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Treatment>();
                int rows = conn.Update(SelectedTreatment);
                if (rows > 0)
                    App.Current.MainPage.DisplayAlert("", "Données mises à jour", "OK");
                else
                    App.Current.MainPage.DisplayAlert("Echec", "Données non mises à jour", "OK");
                App.Current.MainPage.Navigation.PopAsync();
            }
        }

        private void Delete(object obj)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Treatment>();
                int rows = conn.Delete(SelectedTreatment);
                App.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
