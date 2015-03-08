using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using FreelanceHunt.Models;
using FreelanceHunt.Service;

namespace FreelanceHunt.ViewModels
{
    public class ChatViewModel: ViewModelBase
    {
        public ChatViewModel(IWebService webService, IConfigService config, INavigationService navService): base(webService, config, navService)
        {
        }

        public IProfile MyProfile
        {
            get;
            set;
        }

        public override async void LoadState(object navigationParameter, Dictionary<string, object> pageState)
        {
            var id = Convert.ToUInt64(navigationParameter);
            this.MyProfile = await _webService.GetAccountInfo();
            var messages = await _webService.GetDialogMessages(id);
            Messages = new ObservableCollection<ChatMessage>(messages);
        }

        private ObservableCollection<ChatMessage> _messages = new ObservableCollection<ChatMessage>();

        public ObservableCollection<ChatMessage> Messages
        {
            get { return _messages; }
            set 
            { 
                _messages = value;
                RaisePropertyChanged();
            }
        }
    }
}
