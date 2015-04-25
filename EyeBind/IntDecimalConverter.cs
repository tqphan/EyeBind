using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeBind
{
    public class IntDecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
            {
                int i = (int)value;
                return (decimal)i;
            }
            throw new ArgumentException("value is not int");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is decimal)
            {
                decimal d = (decimal)value;
                return decimal.ToInt32(d);
            }
            throw new ArgumentException("value is not decimal");
        }
    }
}
