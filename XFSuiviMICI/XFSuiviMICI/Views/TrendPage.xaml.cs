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
    public partial class TrendPage : ContentPage
    {
        public TrendPageVM vm;
        public TrendPage()
        {
            //vm = new TrendPageVM();
            
            InitializeComponent();

            vm = Resources["vm"] as TrendPageVM;
            //this.BindingContext = vm;

        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            vm.LoadGraph();
        }
    }
}