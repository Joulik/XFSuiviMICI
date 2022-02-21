﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using XFSuiviMICI.Models;

namespace XFSuiviMICI.ViewModels
{
    public class LabWorkVM
    {
        public ObservableCollection<LabWork> LabWorks { get; set; }

        private LabWork selectedLabWork;
        public LabWork SelectedLabWork
        {
            get { return selectedLabWork; }
            set
            {
                selectedLabWork = value;
                if (selectedLabWork != null)
                    App.Current.MainPage.Navigation.PushAsync(new LabWorkDetailPage(selectedLabWork));
            }
        }
        public Command ClickNewLabWorkCommand { get; set; }
        public LabWorkVM()
        {
            LabWorks = new ObservableCollection<LabWork>();
            ClickNewLabWorkCommand = new Command(ClickNewLabWork);
        }

        public void GetLabWorks()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                LabWorks.Clear();
                conn.CreateTable<LabWork>();
                var labworks = conn.Table<LabWork>().ToList();
                foreach (var labwork in labworks)
                {
                    LabWorks.Add(labwork);
                }
            }

            //using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            //{
            //    conn.CreateTable<LabWork>();
            //    var labWorks = conn.Table<LabWork>().ToList();
            //    labWorkListView.ItemsSource = labWorks;
            //}
        }

        public void ClickNewLabWork()
        {
           App.Current.MainPage.Navigation.PushAsync(new NewLabWorkPage());
        }
    }
}
