using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace FreelanceHunt.Converters
{
    class ByteToBoolConverter : IValueConverter
    {
        #region Члены IValueConverter

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is byte)
            {
                var val = System.Convert.ToBoolean(value);
                return val;
                
            }
            else
            {
                return 0;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var data = System.Convert.ToByte(value);
            return data;
        }

        #endregion
    }
}
