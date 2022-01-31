﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XFSuiviMICI
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DailyReportPage : ContentPage
    {
        public DailyReportPage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NewDailyReportPage());
            //DisplayAlert("", "Mise à jour effectuée", "OK");
        }
    }
}