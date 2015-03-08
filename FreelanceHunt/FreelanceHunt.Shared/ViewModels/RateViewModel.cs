using System;
using System.Collections.Generic;
using System.Text;
using FreelanceHunt.Models;
using FreelanceHunt.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FreelanceHunt.ViewModels
{
    public class RateViewModel: ViewModelBase
    {
        INavigationService _navigationService;
        IWebService _webService;
        public RateViewModel(IWebService webService, IConfigService config, INavigationService navService)
            : base(webService, config, navService)
        {
        }
        public ulong ProjectId
        {
            get;
            set;
        }

        private Rate _currentRate = new Rate();
        public Rate CurrentRate
        {
            get
            {
                return _currentRate;
            }
            set
            {
                _currentRate = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand CreateRateCommand
        {
            get
            {
                return new RelayCommand( async()=>
                    {
                       var result = await _webService.SetRate(this.ProjectId, this.CurrentRate);
                    });
            }
        }

        public RelayCommand CancelCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _navigationService.GoBack();
                });
            }
        }
    }
}
