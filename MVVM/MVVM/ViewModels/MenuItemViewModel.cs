using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MVVM.Pages;
using MVVM.Service;

namespace MVVM.ViewModels
{
    public class MenuItemViewModel
    {


        private NavigationService navigationService;
        public string Icon { get; set; }

        public string Title { get; set; }

        public string PageName { get; set; }

        public MenuItemViewModel()
        {
            navigationService = new NavigationService();
        }

        public ICommand NavigateCommand{get { return new RelayCommand(Navigate); }
        }

        private void Navigate()
        {
           navigationService.Navigate(PageName);
        }
    }
    
}
