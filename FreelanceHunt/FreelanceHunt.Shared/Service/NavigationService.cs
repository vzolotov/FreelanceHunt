using System;
using System.Collections.Generic;
using System.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace FreelanceHunt.Service
{
    public class NavigationService : INavigationService
    {
        Frame currentFrame = Window.Current.Content as Frame;
        #region Члены INavigationService

        public void NavigateToViewModel(Type sourceViewModelType)
        {
            try
            {
                var viewType = GetPageTypeByViewModel(sourceViewModelType);
                if (Window.Current.Content != null)
                {
                    var frame = (Frame)Window.Current.Content;                    
                    frame.Navigate(viewType);
                }
            }
            catch
            { }
        }

        public void NavigateToViewModel(Type sourceViewModelType, object parameter)
        {
            try
            {
                var viewType = GetPageTypeByViewModel(sourceViewModelType);
                if (Window.Current.Content != null)
                {
                    var frame = (Frame)Window.Current.Content;
                    if (parameter != null)
                    {
                        frame.Navigate(viewType, parameter);
                    }
                    else
                    {
                        frame.Navigate(viewType);
                    }
                }
            }
            catch
            { }
        }

        public void GoBack()
        {
            var frame = (Frame)Window.Current.Content;
            if (frame.CanGoBack)
            {
                frame.GoBack();
            }
        }

        public bool CanGoBack
        {
            get 
            {
                var frame = (Frame)Window.Current.Content;
                return frame.CanGoBack;
            }
        }

        #endregion

        private Type GetPageTypeByViewModel(Type viewModelType)
        {
            var viewType = typeof(MainPage);
            var viewClass = viewType.AssemblyQualifiedName.Replace(
                viewType.Name,
                viewType.Name.Replace("ViewModel", string.Empty));
            var viewName = viewModelType.Name.Replace(
                viewModelType.Name,
                viewModelType.Name.Replace("ViewModel", string.Empty));
            var result = viewType.AssemblyQualifiedName.Replace(viewType.Name, viewType.Name.Replace("Main", viewName));
            var type = Type.GetType(result);
            return type;
        }
    }
}
