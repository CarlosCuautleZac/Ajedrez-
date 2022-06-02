using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Ajedrez.Helpers
{
    internal class PiezaComidaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string colapsado = "Collapsed";
            string position = value.ToString();
            if (position.Length > 0)
                position = position.Substring(0, 2);

            if (position == "A5" || position == "A6")
                return colapsado;
            else
                colapsado = "Visible";
                return colapsado;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
