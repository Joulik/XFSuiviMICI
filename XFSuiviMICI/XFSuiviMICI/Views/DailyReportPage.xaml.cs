using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XFSuiviMICI.ViewModels;

namespace XFSuiviMICI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyReportPage : ContentPage
    {
        private DailyReportVM vm;
        public DailyReportPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as DailyReportVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.GetDailyReports();
        }
    }
}