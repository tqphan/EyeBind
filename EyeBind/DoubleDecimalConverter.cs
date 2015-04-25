using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeBind
{
    public class DoubleDecimalConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double)
            {
                double d = (double)value;
                return System.Convert.ToDecimal(d);
            }
            throw new ArgumentException("value is not double");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is decimal)
            {
                decimal d = (decimal)value;
                return decimal.ToDouble(d);
            }
            throw new ArgumentException("value is not decimal");
        }
    }
}