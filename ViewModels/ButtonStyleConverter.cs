using System.Windows;
using System.Globalization;
using System.Windows.Data;

namespace ParcInfo.ViewModels
{
    class ButtonStyleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool isActive = (bool)value;

            if (isActive)
                return Application.Current.FindResource("menuButtonActive");
            else
                return Application.Current.FindResource("menuButton");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
