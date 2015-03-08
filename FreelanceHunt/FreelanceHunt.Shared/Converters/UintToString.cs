using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml.Data;

namespace FreelanceHunt.Converters
{
    class UintToString : IValueConverter
    {
        #region Члены IValueConverter

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is uint)
            {
                var data = System.Convert.ToUInt32(value);
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
                return System.Convert.ToUInt32(value);
            }
            catch
            {
                return 0;
            }
        }

        #endregion
    }
}
