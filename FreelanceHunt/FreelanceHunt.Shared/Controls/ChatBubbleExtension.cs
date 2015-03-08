using System;
using System.Collections.Generic;
using System.Text;
using Coding4Fun.Toolkit.Controls;
using FreelanceHunt.Models;
using Windows.UI.Xaml;

namespace FreelanceHunt.Controls
{
    public static class ChatBubbleExtension
    {
        public static DependencyProperty DirectionExtendedProperty = DependencyProperty.RegisterAttached("DirectionExtended", typeof(From), typeof(ChatBubbleExtension), new PropertyMetadata(default(From), ChatBubbleDirectionChanged));

        private static void ChatBubbleDirectionChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var control = d as ChatBubble;
            var myProfile = control.Tag as IProfile;
            var from = GetDirectionExtended(control);
            if (myProfile.profile_id == from.profile_id)
            {
                control.ChatBubbleDirection = ChatBubbleDirection.LowerRight;
                control.HorizontalAlignment = HorizontalAlignment.Right;
            }
            else
            {
                control.ChatBubbleDirection = ChatBubbleDirection.UpperLeft;
                control.HorizontalAlignment = HorizontalAlignment.Left;
            }
        }

        public static void SetDirectionExtended(ChatBubble element, From value)
        {
            element.SetValue(DirectionExtendedProperty, value);
        }

        public static From GetDirectionExtended(ChatBubble element)
        {
            return (From)element.GetValue(DirectionExtendedProperty);
        }
    }
}