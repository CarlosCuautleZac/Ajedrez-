using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using Ajedrez.ViewModels;

namespace Ajedrez.Helpers
{
    internal class DePeonAReinaConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string reina = "../Assets/reina.png";
            string peon = "../Assets/peon.png";
            string position = value.ToString();
            if (position.Length > 0)
                position = position.Substring(0, 2);

            if (position == "B6" || position == "A6")
                return reina;
            else
                return peon;


        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
