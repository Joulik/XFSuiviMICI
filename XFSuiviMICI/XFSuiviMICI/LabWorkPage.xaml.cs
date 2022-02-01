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
    public partial class LabWorkPage : ContentPage
    {
        public LabWorkPage()
        {
            InitializeComponent();
        }

        private void LabTapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewLabWorkPage());
        }
    }
}