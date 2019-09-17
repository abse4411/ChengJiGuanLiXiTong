using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CJGLXT.App.Converters
{
    public sealed class CustomMultiValueConvertor : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((values?.Length??-1) == 2)
                if (targetType ==typeof(bool))
                {
                    var isEditMode=(bool)values[0];
                    var isNotNew = (bool)values[1];
                    return (!isEditMode) || (isEditMode && !isNotNew);
                }
            return values?[0];
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
