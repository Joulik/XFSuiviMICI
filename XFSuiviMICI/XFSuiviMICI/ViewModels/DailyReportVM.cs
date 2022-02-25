﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using XFSuiviMICI.Models;

namespace XFSuiviMICI.ViewModels
{
    public class DailyReportVM
    {
        public ObservableCollection<DailyReport> DailyReports { get; set; }

        //private DailyReport selectedDailyReport;
        //public DailyReport SelectedDailyReport
        //{
        //    get { return selectedDailyReport; }
        //    set { 
        //        selectedDailyReport = value;
        //        if (selectedDailyReport !=null )
        //            App.Current.MainPage.Navigation.PushAsync(new DailyReportDetailPage(selectedDailyReport));
        //    }
        //}

        public DailyReportVM()
        {
            DailyReports = new ObservableCollection<DailyReport>();
        }
        public void GetDailyReports()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                DailyReports.Clear();
                conn.CreateTable<DailyReport>();
                var dailyreports = conn.Table<DailyReport>().ToList();
                foreach (var dailyreport in dailyreports)
                {
                    DailyReports.Add(dailyreport);
                }
            }
        }
    }
}
