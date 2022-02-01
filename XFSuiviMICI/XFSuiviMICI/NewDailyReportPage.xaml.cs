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
        private void OnButtonNewDailyClicked(object sender, EventArgs e)
        {
            //DisplayAlert("", "Sauvegarde effectuée", "OK");
            Navigation.PopAsync();
        }
    }
}