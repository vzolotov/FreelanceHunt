using System;
using System.Collections.Generic;
using System.Text;
using Coding4Fun.Toolkit.Controls;
using FreelanceHunt.Models;
using FreelanceHunt.ViewModels;
using Windows.UI.Xaml.Data;
using Microsoft.Practices.Unity;

namespace FreelanceHunt.Converters
{
    class ProfileToChatBubbleDirection : IValueConverter
    {
        #region Члены IValueConverter

        public object Convert(object value, Type targetType, object parameter, string language)
        {
            try
            {
                var profile = value as Profile;
                if (profile != null)
                {
                    var myProfile = parameter as Profile;
                    if (myProfile != null)
                    {
                        var result = profile.profile_id == myProfile.profile_id;
                        return result ? ChatBubbleDirection.LowerRight : ChatBubbleDirection.UpperLeft;
                    }
                    else
                    {
                        throw new NullReferenceException();
                    }
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch
            {
                return ChatBubbleDirection.LowerRight;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
