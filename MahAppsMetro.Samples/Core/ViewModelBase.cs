#pragma warning disable 
using System.ComponentModel;

namespace MahAppsMetro.Samples.Core
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
