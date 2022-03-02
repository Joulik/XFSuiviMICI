using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSuiviMICI.Models;
using XFSuiviMICI.ViewModels;

namespace XFSuiviMICI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TreatmentDetailPage : ContentPage
    {
        public Treatment SelectedTreatment;
        public TreatmentDetailPage(Treatment selectedTreatment)
        {
            InitializeComponent();

            (Resources["vm"] as TreatmentDetailVM).SelectedTreatment = selectedTreatment;

            medication.Text = selectedTreatment.MedicationName;
            startDateTreatmentPicked.Date = selectedTreatment.StartDate;
            switchActiveTreatment.IsToggled = selectedTreatment.MedicationNotActive;
        }

        private void SwitchActiveTreatmentToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                labelActiveTreatment.TextColor = Color.Red;
                labelActiveTreatment.Text = "non";
            }
            else
            {
                labelActiveTreatment.TextColor = Color.Gray;
                labelActiveTreatment.Text = "oui";
            }
        }
    }
}