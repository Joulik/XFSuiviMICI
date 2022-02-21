using SQLite;
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
    public partial class LabWorkPage : ContentPage
    {
        private LabWorkVM vm;
        public LabWorkPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as LabWorkVM;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.GetLabWorks();
        }
    }
}