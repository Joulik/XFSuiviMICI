using System;
using System.Collections.Generic;
using System.Globalization;
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
    public partial class DailyReportDetailPage : ContentPage
    {
        public DailyReport SelectedDailyReport;
        public DailyReportDetailPage(DailyReport selectedDailyReport)
        {
            InitializeComponent();

            (Resources["vm"] as DailyReportDetailVM).SelectedDailyReport = selectedDailyReport;

            dateDaiylReportPicked.Date = selectedDailyReport.DateDailyReport;
            weight.Text = selectedDailyReport.Weight.ToString(CultureInfo.InvariantCulture);
            countBowelMovement.Text = selectedDailyReport.BowelMovement.ToString();
            switchDiarrhea.IsToggled = selectedDailyReport.Diarrhea;
            switchBloodMucus.IsToggled = selectedDailyReport.BloodOrMucus;
            switchAdbominalPain.IsToggled = selectedDailyReport.AbdominalPain;
            switchTiredness.IsToggled = selectedDailyReport.Tiredness;
            heartRate.Text = selectedDailyReport.HeartRate.ToString();
            systolic.Text = selectedDailyReport.Systolic.ToString();
            diastolic.Text = selectedDailyReport.Diastolic.ToString();
        }
        private void OnStepperValueChanged(object sender, ValueChangedEventArgs e)
        {
            double value = e.NewValue;

            countBowelMovement.Text = string.Format("{0}", value);
        }
        private void SwitchDiarrheaToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                labelDiarrhea.TextColor = Color.Red;
                labelDiarrhea.Text = "oui";
            }
            else
            {
                labelDiarrhea.TextColor = Color.Gray;
                labelDiarrhea.Text = "non";
            }
        }
        private void SwitchBloodMucusToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                labelBloodMucus.TextColor = Color.Red;
                labelBloodMucus.Text = "oui";
            }
            else
            {
                labelBloodMucus.TextColor = Color.Gray;
                labelBloodMucus.Text = "non";
            }
        }
        private void SwitchAbdominalPainToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                labelAbdominalPain.TextColor = Color.Red;
                labelAbdominalPain.Text = "oui";
            }
            else
            {
                labelAbdominalPain.TextColor = Color.Gray;
                labelAbdominalPain.Text = "non";
            }
        }
        private void SwitchTirednessToggled(object sender, ToggledEventArgs e)
        {
            if (e.Value == true)
            {
                labelTiredness.TextColor = Color.Red;
                labelTiredness.Text = "oui";
            }
            else
            {
                labelTiredness.TextColor = Color.Gray;
                labelTiredness.Text = "non";
            }
        }
    }
}