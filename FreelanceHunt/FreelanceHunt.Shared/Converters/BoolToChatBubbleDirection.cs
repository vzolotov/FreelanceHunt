using System;
using System.Collections.Generic;
using System.Text;
using Coding4Fun.Toolkit.Controls;
using Windows.UI.Xaml.Data;

namespace FreelanceHunt.Converters
{
    class BoolToChatBubbleDirection : IValueConverter
    {
        
        #region Члены IValueConverter

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            if (value is bool)
            {
                var data = System.Convert.ToBoolean(value);
                return data ? ChatBubbleDirection.LowerRight : ChatBubbleDirection.UpperLeft;
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
