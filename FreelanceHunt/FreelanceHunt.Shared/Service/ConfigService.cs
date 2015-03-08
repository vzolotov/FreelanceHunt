using System;
using System.Collections.Generic;
using System.Text;
using Windows.Storage;

namespace FreelanceHunt.Service
{
    public class ConfigService : FreelanceHunt.Service.IConfigService
    {
        private ApplicationDataContainer _settings = ApplicationData.Current.LocalSettings;
        public string Token
        {
            get
            {
                var str = _settings.Values["Token"] as string;
                return str;
            }
            set
            {
                _settings.Values["Token"] = value;
            }
        }

        public string Secret
        {
            get
            {
                var str = _settings.Values["Secret"] as string;
                return str;
            }
            set
            {
                _settings.Values["Secret"] = value;
            }
        }
    }
}
