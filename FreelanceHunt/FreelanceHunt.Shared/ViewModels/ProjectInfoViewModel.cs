using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using FreelanceHunt.Models;
using FreelanceHunt.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Coding4Fun.Toolkit.Controls;

namespace FreelanceHunt.ViewModels
{
    public class ProjectInfoViewModel: ViewModelBase
    {
        public ProjectInfoViewModel(IWebService webService, IConfigService config, INavigationService navService)
            : base(webService, config, navService)
        {
        }

        private bool _isNewRate;
        public bool IsNewRate
        {
            get
            {
                return _isNewRate;
            }
            set
            {
                _isNewRate = value;
                RaisePropertyChanged();
            }
        }

        ProjectDetail _currentProject;
        public ProjectDetail CurrentProject
        {
            get
            {
                return _currentProject;
            }
            set
            {
                _currentProject = value;
                RaisePropertyChanged();
            }
        }

        public async Task GetProjectData(ulong projectId)
        {
            CurrentProject = await _webService.GetProjectInfo(projectId);
        }

        public RelayCommand SetRateCommand
        {
            get
            {
                return new RelayCommand(() =>
                {
                    this._navigationService.NavigateToViewModel(typeof(RateViewModel), CurrentProject.project_id);
                });
            }
        }
    }
}
