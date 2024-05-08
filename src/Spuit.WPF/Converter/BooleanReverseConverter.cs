using System.Globalization;
using System.Windows.Data;

namespace Spuit.WPF
{
    internal class BooleanReverseConverter : IValueConverter
    {
        /// <summary>
        /// Convert bool value to reverse bool value
        /// </summary>
        /// <param name="value"></param>
        /// <param name="targetType"></param>
        /// <param name="parameter"></param>
        /// <param name="culture"></param>
        /// <returns></returns>
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool b) return !b;
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}