using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MahAppsMetro.Samples.Core
{
    public class MenuItem :ViewModelBase
    {
        public object Icon { get; set; }

        public string Text { get; set; }

        public ICommand Command { get; set; }

        public Uri NavigationDestination { get; set; }

        public bool IsNavigation => this.NavigationDestination != null;
    }
}
