using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using ManDontGetAngryGame.Enums;

namespace ManDontGetAngryGame.Converter
{
    public class PieceColorToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            EPieceColor color = (EPieceColor) value;
            switch (color)
            {
                case EPieceColor.Blue:
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Figures/BlueFigure.PNG", UriKind.Absolute));
                case EPieceColor.Green:
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Figures/GreenFigure.PNG", UriKind.Absolute));
                case EPieceColor.None:
                    return new BitmapImage(new Uri(AppDomain.CurrentDomain.BaseDirectory + "Figures/empty.png", UriKind.Absolute));
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
