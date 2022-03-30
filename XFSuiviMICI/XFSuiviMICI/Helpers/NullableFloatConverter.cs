using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Xamarin.Forms;

namespace XFSuiviMICI.Helpers
{
    class NullableFloatConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var nullable = value as float?;
            var result = string.Empty;

            if (nullable.HasValue)
            {
                result = nullable.Value.ToString();
            }

            return result;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = value as string;
            float floatValue;
            float? result = null;

            if (float.TryParse(stringValue, out floatValue))
            {
                result = new Nullable<float>(floatValue);
            }

            return result;
        }
    }
}
