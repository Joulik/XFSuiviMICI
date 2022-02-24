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
    public partial class LabWorkDetailPage : ContentPage
    {
        public LabWork selectedLabWork;
        public LabWorkDetailPage(LabWork selectedLabWork)
        {
            InitializeComponent();

            (Resources["vm"] as LabWorkDetailVM).SelectedLabWork = selectedLabWork;

            //this.selectedLabWork = selectedLabWork;

            dateLabWorkPicked.Date = selectedLabWork.DateLabWork;
            testName.Text = selectedLabWork.TestName;
            testValue.Text =  selectedLabWork.TestValue.ToString();
            testUnit.Text = selectedLabWork.TestUnit;
        }
    }
}