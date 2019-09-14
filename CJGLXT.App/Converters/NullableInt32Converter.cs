using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CJGLXT.App.Converters
{
    class NullableInt32Converter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Int32 n32)
            {
                if (targetType == typeof(String))
                {
                    return n32.ToString();
                }
                return n32;
            }
            if (targetType == typeof(String))
            {
                return null;
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string str)
            {
                if (!String.IsNullOrWhiteSpace(str))
                    if (Int32.TryParse(value.ToString(), out Int32 n32))
                    {
                        return n32;
                    }
            }
            return null;
        }
    }
}
