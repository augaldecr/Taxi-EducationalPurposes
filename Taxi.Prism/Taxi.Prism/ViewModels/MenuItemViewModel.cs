﻿using Prism.Commands;
using Prism.Navigation;
using Taxi.Common.Helpers;
using Taxi.Common.Models;

namespace Taxi.Prism.ViewModels
{
    public class MenuItemViewModel : Menu
    {
        private readonly INavigationService _navigationService;
        private DelegateCommand _selectMenuCommand;

        public MenuItemViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public DelegateCommand SelectMenuCommand => _selectMenuCommand ??
            (_selectMenuCommand = new DelegateCommand(SelectMenuAsync));

        private async void SelectMenuAsync()
        {
            if (PageName == "LoginPage" && Settings.IsLogin)
            {
                Settings.IsLogin = false;
                Settings.User = null;
                Settings.Token = null;
            }

            if (IsLoginRequired && !Settings.IsLogin)
            {
                await _navigationService.NavigateAsync($"/TaxiMasterDetailPage/NavigationPage/LoginPage");
            }
            else
            {
                await _navigationService.NavigateAsync($"/TaxiMasterDetailPage/NavigationPage/{PageName}");
            }
        }
    }
}
