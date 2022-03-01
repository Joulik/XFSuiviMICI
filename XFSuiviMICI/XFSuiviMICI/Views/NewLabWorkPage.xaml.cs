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
using XFSuiviMICI.ViewModels;

namespace XFSuiviMICI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewLabWorkPage : ContentPage
    {
        private NewLabWorkVM vm;
        public NewLabWorkPage()
        {
            InitializeComponent();

            vm = Resources["vm"] as NewLabWorkVM;

            var testUnits = vm.GetTestUnit();
            testUnit.ItemsSource = testUnits;
        }
    }
}