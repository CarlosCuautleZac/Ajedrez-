using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using Ajedrez.Views;

namespace Ajedrez.Helpers
{
    internal class PositionLeftConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string position = value.ToString();
            if (position.Length > 0)
                position = position.Substring(1, 1);

            if (position == "1")
                return 545d;
            if (position == "2")
                return 445d;
            if (position == "3")
                return 345d;
            if (position == "4")
                return 245d;
            if (position == "5")
                return 145d;
            if (position == "6")
                return 45d;

            else
                return 545d;

        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
