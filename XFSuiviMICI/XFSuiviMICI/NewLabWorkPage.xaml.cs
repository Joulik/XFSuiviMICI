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
    public partial class NewLabWorkPage : ContentPage
    {
        public NewLabWorkPage()
        {
            InitializeComponent();
        }

        private void OnButtonLabWorkClicked(object sender, EventArgs e)
        {
            LabWork labWork = new LabWork
            {
                DateLabWork = dateLabWorkPicked.Date,
                TestName = testName.Text,
                //TestValue = (float)Convert.ToDouble(testValue.Text),
                TestValue = float.Parse(testValue.Text, CultureInfo.InvariantCulture.NumberFormat),
                TestUnit = testUnit.Text
            };

            SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation);

            conn.CreateTable<LabWork>();
            int rows = conn.Insert(labWork);
            conn.Close();

            if (rows > 0)
                DisplayAlert("", "Sauvegarde effectuée", "OK");
            else
                DisplayAlert("Problème", "Sauvegarde non enregistré", "OK");

            Navigation.PopAsync();
        }
    }
}