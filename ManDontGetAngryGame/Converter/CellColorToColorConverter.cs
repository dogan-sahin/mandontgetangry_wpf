using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using ManDontGetAngryGame.Enums;

namespace ManDontGetAngryGame.Converter
{
    public class CellColorToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ECellColor color = (ECellColor) value;
            switch (color)
            {
                case ECellColor.Blue:
                    return new SolidColorBrush(Colors.DodgerBlue);
                case ECellColor.Green:
                    return new SolidColorBrush(Colors.ForestGreen);
                case ECellColor.White:
                    return new SolidColorBrush(Colors.White);
                default:
                    throw new ArgumentException("Not supported field type.");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
