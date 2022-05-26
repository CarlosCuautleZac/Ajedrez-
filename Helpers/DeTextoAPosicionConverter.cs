using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace Ajedrez.Helpers
{
    internal class DeTextoAPosicionConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string position = value.ToString();

            if (string.IsNullOrWhiteSpace(position))
                return 5;

            if (position == "B2")
                return 15;
            else                
                return 20;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
