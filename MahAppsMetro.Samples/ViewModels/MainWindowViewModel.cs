using MahApps.Metro.IconPacks;
using MahAppsMetro.Samples.Core;
using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.ObjectModel;

using MahApps.Metro.Controls;
using System.Windows.Controls;
using Microsoft.Practices.Unity;
using MahAppsMetro.Samples.Views;

namespace MahAppsMetro.Samples.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private IRegionManager _regionManager;
        private Navigation _navigation;
        private IUnityContainer _container;

        private static readonly ObservableCollection<MenuViewModel> AppMenu = new ObservableCollection<MenuViewModel>();
        private static readonly ObservableCollection<MenuViewModel> AppOptionsMenu = new ObservableCollection<MenuViewModel>();

        private static readonly string appTitle = "客戶關係管理系統";

        public MainWindowViewModel()
        {
            BuildMenu();
        }

        public MainWindowViewModel(IRegionManager regionManager, Navigation navigation, IUnityContainer container)
        {
            _regionManager = regionManager;
            _navigation = navigation;
            _container = container;

            BuildMenu();
            NavigateCommand = new DelegateCommand<MenuViewModel>(Navigate);

        }

        public DelegateCommand<MenuViewModel> NavigateCommand { get; set; }
        private void Navigate(MenuViewModel menuItem)
        {
            //_navigation.Navigate(menuItem.NavigationDestination);
            //_regionManger.RequestNavigate("ContentRegion", uri);
            //_navigation.Navigate(menuItem.NavigationDestination);

            //var view = _container.Resolve<ViewA>();

            //IRegion region = _regionManager.Regions["ContentRegion"];
            //region.Add(view);

            var uri = menuItem.NavigationDestination;

            CurrentTitle = menuItem.Text;

            try
            {
                var view = System.Windows.Application.LoadComponent(uri);
                CurrentView = (UserControl)view;
            }
            catch { }
           

            //if ( uri != null)
            //{

            //}

        }

        public ObservableCollection<MenuViewModel> Menu => AppMenu;
        public ObservableCollection<MenuViewModel> OptionsMenu => AppOptionsMenu;

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

        public UserControl CurrentView { get; set; }

        public String CurrentTitle { get; set; }

        private void BuildMenu()
        {
            // Build the menus
            this.Menu.Add(new MenuViewModel() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.Bug }, Text = "Bugs", NavigationDestination = new Uri(@"Views/ViewA.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuViewModel() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.UserOutline }, Text = "User", NavigationDestination = new Uri(@"Views/ViewB.xaml", UriKind.RelativeOrAbsolute) });
            this.Menu.Add(new MenuViewModel() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.Coffee }, Text = "Break" });
            this.Menu.Add(new MenuViewModel() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.FontAwesome }, Text = "Awesome" });

            this.OptionsMenu.Add(new MenuViewModel() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.Cogs }, Text = "Settings", NavigationDestination = new Uri("Views/ViewA.xaml", UriKind.RelativeOrAbsolute) });
            this.OptionsMenu.Add(new MenuViewModel() { Icon = new PackIconFontAwesome() { Kind = PackIconFontAwesomeKind.InfoCircle }, Text = "About" });
        }
    }
}
