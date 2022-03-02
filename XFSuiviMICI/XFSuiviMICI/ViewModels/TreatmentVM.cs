using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using XFSuiviMICI.Models;

namespace XFSuiviMICI.ViewModels
{
    public class TreatmentVM
    {
        public ObservableCollection<Treatment> Treatments { get; set; }

        private Treatment selectedTreatment;
        public Treatment SelectedTreatment
        { 
            get { return selectedTreatment; } 
            set 
            { 
                selectedTreatment = value;
                if (selectedTreatment != null)
                    App.Current.MainPage.Navigation.PushAsync(new TreatmentDetailPage(selectedTreatment));
            } 
        }

        public Command ClickNewTreatmentCommand { get; set; }

        public TreatmentVM()
        {
            ClickNewTreatmentCommand = new Command(ClickNewTreatment);
            Treatments = new ObservableCollection<Treatment>();
        }

        public void GetTreatments()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                Treatments.Clear();
                conn.CreateTable<Treatment>();
                var treatments = conn.Table<Treatment>().Select(d => d).OrderByDescending(d => d.MedicationName).ToList();
                foreach (var labwork in treatments)
                {
                    Treatments.Add(labwork);
                }
            }
        }

        public void ClickNewTreatment()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewTreatmentPage());
        }
    }
}
