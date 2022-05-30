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
            if(position.Length>0)
            position = position.Substring(0,1);

            if (position == "A")
                return 58d;
            if (position == "B")
                return 168d;
            if (position == "C")
                return 272d;
            if (position == "D")
                return 380d;
            if (position == "E")
                return 485d;
            if (position == "F")
                return 590d;

            else
                return -100d;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
