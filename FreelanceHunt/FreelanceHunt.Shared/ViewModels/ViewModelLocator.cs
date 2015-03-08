using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ObjectBuilder2;
using FreelanceHunt.Models;
using FreelanceHunt.Service;

namespace FreelanceHunt.ViewModels
{
    public class ViewModelLocator
    {
        private static UnityContainer _container = new UnityContainer();
        public static UnityContainer Container
        {
            get { return _container; }
            set { _container = value; }
        }

        private IProfile Profile{get;set;}
        public ViewModelLocator()
        {
            Container.RegisterType<IConfigService, ConfigService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IWebService, WebService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<INavigationService, NavigationService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IProfile, Profile>(new ContainerControlledLifetimeManager());
            Container.RegisterType<LoginViewModel>(new ContainerControlledLifetimeManager(), new InjectionProperty("MyProfile", new ResolvedParameter(typeof(IProfile))));
            Container.RegisterType<MainViewModel>(new ContainerControlledLifetimeManager(), new InjectionProperty("MyProfile", new ResolvedParameter(typeof(IProfile))));
            Container.RegisterType<MessagesViewModel>(new ContainerControlledLifetimeManager(), new InjectionProperty("MyProfile", new ResolvedParameter(typeof(IProfile))));
            Container.RegisterType<ProjectInfoViewModel>();
            Container.RegisterType<RateViewModel>();
            Container.RegisterType<ChatViewModel>(new ContainerControlledLifetimeManager(),new InjectionProperty("MyProfile", new ResolvedParameter(typeof(IProfile))));            
        }

        public MainViewModel MainViewModel
        {
            get
            {
                return Container.Resolve<MainViewModel>();
            }
        }

        public LoginViewModel LoginViewModel
        {
            get
            {
                return Container.Resolve<LoginViewModel>();
            }
        }

        public MessagesViewModel MessagesViewModel
        {
            get
            {
                return Container.Resolve<MessagesViewModel>();
            }
        }

        public ProjectInfoViewModel ProjectInfoViewModel
        {
            get
            {
                return Container.Resolve<ProjectInfoViewModel>();
            }
        }

        public ChatViewModel ChatViewModel
        {
            get
            {
                return Container.Resolve<ChatViewModel>();
            }
        }
        public RateViewModel RateViewModel
        {
            get
            {
                return Container.Resolve<RateViewModel>();
            }
        }

        public static IConfigService Configuration
        {
            get
            {
                return Container.Resolve<IConfigService>();
            }
        }
    }
}
