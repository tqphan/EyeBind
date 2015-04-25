using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EyeBind
{
    public class DoubleIntConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double)
            {
                double d = (double)value;
                return (int)(d * 100);
            }
            throw new ArgumentException("value is not double");
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is int)
            {
                int i = (int)value;
                return (double)((double)i / 100.00);
            }
            throw new ArgumentException("value is not int");
        }
    }
}

