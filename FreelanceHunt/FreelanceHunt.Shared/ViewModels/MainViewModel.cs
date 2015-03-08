using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FreelanceHunt.Incremental;
using FreelanceHunt.Models;
using FreelanceHunt.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FreelanceHunt.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        ProjectsIncrimental<Project> _incrementalData;

        public MainViewModel(IWebService webService, IConfigService config, INavigationService navService)
            : base(webService, config, navService)
        {
        }

        public IProfile MyProfile
        {
            get;
            set;
        }

        public ProjectsIncrimental<Project> IncrementalProjects
        {
            get
            {
                return _incrementalData;
            }
            set
            {
                _incrementalData = value;
                RaisePropertyChanged();
            }
        }

        public RelayCommand<Project> ProjectInfoCommand
        {
            get
            {
                return new RelayCommand<Project>((arg) =>
                {
                    _navigationService.NavigateToViewModel(typeof(ProjectInfoViewModel), arg.project_id);
                });
            }
        }

        public RelayCommand NavigateToMessageCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    _navigationService.NavigateToViewModel(typeof(MessagesViewModel));
                });
            }
        }

        public override async void LoadState(object navigationParameter, Dictionary<string, object> pageState)
        {
            base.LoadState(navigationParameter, pageState);
            IncrementalProjects = new ProjectsIncrimental<Project>(_webService.GetProjectsByPage);
            var a  = await this._webService.GetAccountInfo();
            this.MyProfile = a;
        }
    }
}
