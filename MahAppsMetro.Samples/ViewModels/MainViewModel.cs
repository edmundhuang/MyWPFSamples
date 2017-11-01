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

        public MainWindowViewModel(IRegionManager regionManager)
        {
            _regionManger = regionManager;

            ViewACommand = new DelegateCommand(ButtonAExecute, () => true);
            ViewBCommand = new DelegateCommand(ButtonBExecute, () => true);

            NavigateCommand = new DelegateCommand<string>(Navigate);
            
        }

        private void Navigate(string uri)
        {
            _regionManger.RequestNavigate("ContentRegion", uri);
        }

        private void ButtonBExecute()
        {
            CurrentView = new Views.ViewA();
        }

        private void ButtonAExecute()
        {
            throw new NotImplementedException();
        }

        public string Title { get; set; }

        public String ContentRegion { get; set; }

        public object CurrentView { get; set; }

        public ICommand ViewACommand { get; set; }
        public ICommand ViewBCommand { get; set; }

        public DelegateCommand<string> NavigateCommand { get; set; }


    }
}
