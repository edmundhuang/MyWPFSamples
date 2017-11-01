using MahAppsMetro.Samples.Core;
using Prism.Commands;
using System;

namespace MahAppsMetro.Samples.ViewModels
{
    public  class ViewAViewModel: ViewModelBase
    {
        public ViewAViewModel()
        {
            UpdateCommand = new DelegateCommand(Execute, canExecute).ObservesProperty(() =>FirstName).ObservesProperty(()=> LastName);
        }

        private bool canExecute()
        {
            return !string.IsNullOrWhiteSpace(FirstName) && !string.IsNullOrWhiteSpace(LastName);
        }

        private void Execute()
        {
            LastUpdated = DateTime.Now;
        }
        
        public string FirstName { get; set; } = "test";
        public string LastName { get; set; }

        public DateTime? LastUpdated { get; set; }

        public DelegateCommand UpdateCommand { get; set; }


    }
}
