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
    public partial class NewLabWorkPage : ContentPage
    {
        public NewLabWorkPage()
        {
            InitializeComponent();
        }

        private void OnButtonLabWorkClicked(object sender, EventArgs e)
        {
            //DisplayAlert("", "Sauvegarde effectuée", "OK");
            Navigation.PopAsync();
        }
    }
}