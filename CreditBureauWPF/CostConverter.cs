using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace CreditBureauWPF
{
    [ValueConversion(typeof(int), typeof(string))]
    public class CostConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
        {
            // Возвращаем строку в формате 123.456.789 руб. 
            return ((int)value).ToString("#,###", culture) + " руб.";
        }

        public object ConvertBack(object value, Type targetType, object parameter,
        System.Globalization.CultureInfo culture)
        {
            int result;
            if (int.TryParse(value.ToString(), System.Globalization.NumberStyles.Any,
            culture, out result))
            {
                return result;
            }
            else if (int.TryParse(value.ToString().Replace(" руб.", ""), System.Globalization.NumberStyles.Any,
            culture, out result))
            {
                return result;
            }
            return value;
        }
    }
}
