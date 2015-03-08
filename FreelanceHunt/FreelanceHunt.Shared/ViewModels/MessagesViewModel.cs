using System;
using System.Collections.Generic;
using System.Text;
using FreelanceHunt.Incremental;
using FreelanceHunt.Models;
using FreelanceHunt.Service;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace FreelanceHunt.ViewModels
{
    public class MessagesViewModel : ViewModelBase
    {
        ProjectsIncrimental<Dialog> _incrementalData;
        public MessagesViewModel(IWebService webService, IConfigService config, INavigationService navService)
            : base(webService, config, navService)
        {
            IncrementalProjects = new ProjectsIncrimental<Dialog>(_webService.GetDialogsByPage);
        }

        public IProfile MyProfile
        {
            get;
            set;
        }

        public ProjectsIncrimental<Dialog> IncrementalProjects
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

        public RelayCommand<Dialog> ViewDialogCommand
        {
            get
            {
                return new RelayCommand<Dialog>((arg) =>
                {
                    var id = Convert.ToUInt64(arg.thread_id);
                    _navigationService.NavigateToViewModel(typeof(ChatViewModel), id);
                });
            }
        }
    }
}
