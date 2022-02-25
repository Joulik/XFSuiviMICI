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
    public partial class DailyReportDetailPage : ContentPage
    {
        public DailyReport SelectedDailyReport;
        public DailyReportDetailPage(DailyReport selectedDailyReport)
        {
            InitializeComponent();

            (Resources["vm"] as DailyReportDetailVM).SelectedDailyReport = selectedDailyReport;

            //this.selectedLabWork = selectedLabWork;

            dateDaiylReportPicked.Date = selectedDailyReport.DateDailyReport;
            weight.Text = selectedDailyReport.Weight.ToString();
            countBowelMovement.Text = selectedDailyReport.BowelMovement.ToString();
            switchDiarrhea.IsToggled = selectedDailyReport.Diarrhea;
            switchBloodMucus.IsToggled = selectedDailyReport.BloodOrMucus;
            switchAdbominalPain.IsToggled = selectedDailyReport.AbdominalPain;
            switchTiredness.IsToggled = selectedDailyReport.Tiredness;
            heartRate.Text = selectedDailyReport.HeartRate.ToString();
            systolic.Text = selectedDailyReport.Systolic.ToString();
            diastolic.Text = selectedDailyReport.Diastolic.ToString();
        }
    }
}