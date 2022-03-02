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
    public partial class TreatmentPage : ContentPage
    {
        public TreatmentVM vm;
        public TreatmentPage()
        {   
            InitializeComponent();

            vm = Resources["vm"] as TreatmentVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.GetTreatments();
        }
    }
}