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
    public partial class NewDailyReportPage : ContentPage
    {
        public NewDailyReportPage()
        {
            InitializeComponent();
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
    }
}