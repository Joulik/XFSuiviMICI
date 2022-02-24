using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XFSuiviMICI.Models;

namespace XFSuiviMICI.ViewModels
{
    public class LabWorkDetailVM
    {
        public Command DeleteCommand { get; set; }
        public Command UpdateCommand { get; set; }
        public LabWork SelectedLabWork { get; set; }
        public LabWorkDetailVM()
        {
            DeleteCommand = new Command(Delete);
            UpdateCommand = new Command(Update);
        }

        private void Update()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<LabWork>();
                int rows = conn.Update(SelectedLabWork);
                if (rows > 0)
                    App.Current.MainPage.DisplayAlert("", "Données mises à jour", "OK");
                else
                    App.Current.MainPage.DisplayAlert("Echec", "Données non mises à jour", "OK");
                App.Current.MainPage.Navigation.PopAsync();
            }
        }

        private void Delete()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<LabWork>();
                int rows = conn.Delete(SelectedLabWork);
                App.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
