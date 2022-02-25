using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using XFSuiviMICI.Models;

namespace XFSuiviMICI.ViewModels
{
    
    public class DailyReportDetailVM
    {
        public Command DeleteCommand { get; set; }
        public Command UpdateCommand { get; set; }
        public DailyReport SelectedDailyReport { get; set; }

        public DailyReportDetailVM()
        {
            DeleteCommand = new Command(Delete);
            UpdateCommand = new Command(Update);
        }

        private void Update()
        {
            throw new NotImplementedException();
        }

        private void Delete()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<DailyReport>();
                int rows = conn.Delete(SelectedDailyReport);
                App.Current.MainPage.Navigation.PopAsync();
            }
        }
    }
}
