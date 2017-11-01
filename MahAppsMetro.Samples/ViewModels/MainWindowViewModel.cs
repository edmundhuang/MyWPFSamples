using MahAppsMetro.Samples.Core;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MahAppsMetro.Samples.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IRegionManager _regionManger;
        private Navigation _navigation;

        public MainWindowViewModel(IRegionManager regionManager, Navigation navigation)
        {
            _regionManger = regionManager;
            _navigation = navigation;

            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string uri)
        {
            _regionManger.RequestNavigate("ContentRegion", uri);
        }

        public string Title { get; set; }

        public String ContentRegion { get; set; }

        public object CurrentView { get; set; }

        public DelegateCommand<string> NavigateCommand { get; set; }


    }
}
