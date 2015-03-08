using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace FreelanceHunt.Converters
{
    class ByteToString : IValueConverter
    {
        #region Члены IValueConverter

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is byte)
            {
                var data = System.Convert.ToByte(value);
                return data > 0 ? data.ToString() : string.Empty;
            }
            else
            {
                return string.Empty;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            try
            {
                return System.Convert.ToByte(value);
            }
            catch
            {
                return 0;
            }
        }

        #endregion
    }
}
