using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSuiviMICI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewTreatmentPage : ContentPage
    {
        public NewTreatmentPage()
        {
            InitializeComponent();
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