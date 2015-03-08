using System;
using System.Collections.Generic;
using System.Text;

namespace FreelanceHunt.Service
{
    public interface INavigationService
    {
        void NavigateToViewModel(Type sourceViewModelType);
        void NavigateToViewModel(Type sourceViewModelType, object parameter);
        void GoBack();
        bool CanGoBack { get; }
    }
}
