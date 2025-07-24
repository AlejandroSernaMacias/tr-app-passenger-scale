using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace TR.Torrey.Weight.Capture.Converters
{
    public class StringToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            try
            {
                var colorStr = value as string;
                if (string.IsNullOrEmpty(colorStr))
                    return Brushes.Transparent;

                var brush = (SolidColorBrush)new BrushConverter().ConvertFromString(colorStr);
                return brush.Color;
            }
            catch
            {
                return Colors.Transparent;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
