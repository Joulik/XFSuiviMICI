using SQLite;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSuiviMICI.Models;

namespace XFSuiviMICI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LabWorkDetailPage : ContentPage
    {
        LabWork selectedLabWork;
        public LabWorkDetailPage(LabWork selectedLabWork)
        {
            InitializeComponent();

            this.selectedLabWork = selectedLabWork;

            dateLabWorkPicked.Date = selectedLabWork.DateLabWork;
            testName.Text = selectedLabWork.TestName;
            testValue.Text =  selectedLabWork.TestValue.ToString();
            testUnit.Text = selectedLabWork.TestUnit;
        }

        private void UpdateLabWorkButton_Clicked(object sender, EventArgs e)
        {
            selectedLabWork.DateLabWork = dateLabWorkPicked.Date;
            selectedLabWork.TestName = testName.Text;
            selectedLabWork.TestValue = float.Parse(testValue.Text, CultureInfo.InvariantCulture.NumberFormat);
            selectedLabWork.TestUnit = testUnit.Text;

            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<LabWork>();
                int rows = conn.Update(selectedLabWork);
                Navigation.PopAsync();

                //if (rows > 0)
                //    DisplayAlert("Success", "Experience successfully updated", "OK");
                //else
                //    DisplayAlert("Failure", "Failed to update experience", "OK");
            }
        }

        private void DeleteLabWorkButton_Clicked(object sender, EventArgs e)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<LabWork>();
                int rows = conn.Delete(selectedLabWork);
                Navigation.PopAsync();

                //if (rows > 0)
                //    DisplayAlert("Success", "Experience successfully deleted", "OK");
                //else
                //    DisplayAlert("Failure", "Failed to delete experience", "OK");
            }

        }
    }
}