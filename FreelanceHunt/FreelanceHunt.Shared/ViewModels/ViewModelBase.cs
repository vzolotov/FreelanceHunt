using System;
using System.Collections.Generic;
using System.Text;
using FreelanceHunt.Models;
using FreelanceHunt.Service;
using Newtonsoft.Json;

namespace FreelanceHunt.ViewModels
{
    public class ViewModelBase : GalaSoft.MvvmLight.ViewModelBase
    {
        protected IWebService _webService;
        protected INavigationService _navigationService;
        protected IConfigService _config;
        public ViewModelBase(IWebService webService, IConfigService configService, INavigationService navService)
        {
            _webService = webService;
            _navigationService = navService;
            _config = configService;
        }

        /// <summary>
        /// Сериализация в строку JSON
        /// </summary>
        /// <typeparam name="T">тип сериализуемого объекта</typeparam>
        /// <param name="objectToSerialization">объект для сериализации</param>
        /// <returns>строка описывающая объект</returns>
        public string Serialize<T>(T objectToSerialization)
        {
            try
            {
                if (objectToSerialization != null)
                {
                    return JsonConvert.SerializeObject(objectToSerialization);
                }
                else
                {
                    throw new NullReferenceException();
                }
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Десериализация строки в объект
        /// </summary>
        /// <typeparam name="T">тип результирующего объекта</typeparam>
        /// <param name="json">строка для десериализации</param>
        /// <returns>объект описываемой входным строковым параметром</returns>
        public T Deserialize<T>(string json)
        {
            if (!string.IsNullOrEmpty(json))
            {
                return JsonConvert.DeserializeObject<T>(json);
            }
            else
            {
                return default(T);
            }
        }

        #region base event handlers
        public virtual void LoadState(Object navigationParameter, Dictionary<String, Object> pageState)
        {
        }

        public virtual void SaveState(Dictionary<String, Object> pageState)
        {
        }
        #endregion


        private bool _progress = false;
        public bool Progress
        {
            get
            {
                return _progress;
            }
            set
            {
                _progress = value;
                RaisePropertyChanged();
            }
        }

    }
}
