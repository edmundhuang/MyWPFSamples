using MahApps.Metro.IconPacks;
using MahAppsMetro.Samples.Core;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;

using MahApps.Metro.Controls;

namespace MahAppsMetro.Samples.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IRegionManager _regionManger;
        private Navigation _navigation;

        private static readonly ObservableCollection<MenuItem> AppMenu = new ObservableCollection<MenuItem>();
        private static readonly ObservableCollection<MenuItem> AppOptionsMenu = new ObservableCollection<MenuItem>();

        private static readonly string appTitle = "客戶關係管理系統";

        public MainWindowViewModel()
        {
            BuildMenu();
        }

        public MainWindowViewModel(IRegionManager regionManager, Navigation navigation)
        {
            _regionManger = regionManager;
            _navigation = navigation;
            BuildMenu();
            NavigateCommand = new DelegateCommand<object>(Navigate);
        }

        public DelegateCommand<object> NavigateCommand { get; set; }
        private void Navigate(object item)
        {
            MenuItem menuItem = (MenuItem)item;

            _navigation.Navigate(menuItem.NavigationDestination);
            //_regionManger.RequestNavigate("ContentRegion", uri);
        }

        public ObservableCollection<MenuItem> Menu => AppMenu;
        public ObservableCollection<MenuItem> OptionsMenu => AppOptionsMenu;

        private HamburgerMenuItem _selectedMenuItem;
        public HamburgerMenuItem SelectedMenuItem
        {
            get
            {
                return _selectedMenuItem;
            }

            set
            {
                if (value != _selectedMenuItem)
                {
                    _selectedMenuItem = value;
                }
            }
        }

        public string Title { get; set; } = appTitle;

        public String ContentRegion { get; set; }

        public object CurrentView { get; set; }


        private void BuildMenu()
        {
            // Build the menus
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.Bug }, Text = "Bugs", NavigationDestination = new Uri("Views/ViewA.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.UserOutline }, Text = "User", NavigationDestination = new Uri("Views/ViewB.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.Coffee }, Text = "Break" });
            this.Menu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.FontAwesome }, Text = "Awesome" });

            this.OptionsMenu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.Cogs }, Text = "Settings" ,NavigationDestination = new Uri("Views/ViewA.xaml", UriKind.RelativeOrAbsolute) });
            this.OptionsMenu.Add(new MenuItem() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.InfoCircle }, Text = "About" });
        }
    }
}
