using System;
using System.Collections.Generic;
using System.Text;
using FreelanceHunt.Models;
using FreelanceHunt.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Threading;
using Windows.UI.Popups;

namespace FreelanceHunt.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        public LoginViewModel(IWebService webService, IConfigService config, INavigationService navService)
            : base(webService, config, navService)
        {
        }

        private string _login = string.Empty;
        public string Login
        {
            get
            {
                return _login;
            }
            set
            {
                _login = value;
                RaisePropertyChanged();
            }
        }

        private string _password = string.Empty;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                RaisePropertyChanged();
            }
        }

        public IProfile MyProfile
        {
            get;
            set;
        }

        public RelayCommand LoginCommand
        {
            get
            {
                return new RelayCommand(async () =>
                {
                    this._config.Secret = this.Login;
                    this._config.Token = this.Password;
                    MyProfile = await this._webService.GetAccountInfo();
                    if (MyProfile == null)
                    {
                        DispatcherHelper.CheckBeginInvokeOnUI(async() =>
                            {
                                try
                                {
                                    MessageDialog diag = new MessageDialog("Введены неправильные данные", "Ошибка авторизации");
                                    await diag.ShowAsync();
                                }
                                catch
                                { }
                            });
                    }
                    else
                    {
                        this._navigationService.NavigateToViewModel(typeof(MainViewModel));
                    }
                });
            }
        }
    }
}
