using System;
using System.Globalization;
using Xamarin.Forms;

namespace Daily3Goals
{
    public class DoneToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool done = (bool)value;

            if (done) {
                return Color.Green;
            } else {
                return Color.LightGray;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Color color = (Color)value;

            if (color == Color.Green) {
                return true;
            } else {
                return false;
            }
        }
    }
}
