using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace XFSuiviMICI.Helpers
{
    public class TreatmentBoolToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string statusText;

            if (Equals(value,true))
                statusText = "suspendu ou arrêté";
            else
                statusText = "en cours depuis le";
                
            return statusText;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
