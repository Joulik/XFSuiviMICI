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

        private void Update(object obj)
        {
            throw new NotImplementedException();
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

        //private void Update()
        //{
        //    SelectedLabWork.DateLabWork = dateLabWorkPicked;
        //    TestName = SelectedLabWork.TestName;
        //    TestValue = SelectedLabWork.TestValue;
        //    TestUnit = SelectedLabWork.TestUnit;

        //    using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
        //    {
        //        conn.CreateTable<LabWork>();
        //        int rows = conn.Update(SelectedLabWork);
        //        App.Current.MainPage.Navigation.PopAsync();

        //        if (rows > 0)
        //            App.Current.MainPage.DisplayAlert("Success", "Experience successfully updated", "OK");
        //        else
        //            App.Current.MainPage.DisplayAlert("Failure", "Failed to update experience", "OK");
        //    }
        //}
    }
}
