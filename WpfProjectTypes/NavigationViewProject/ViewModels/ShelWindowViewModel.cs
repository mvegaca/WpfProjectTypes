using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using MahApps.Metro.Controls;
using NavigationViewProject.Helpers;
using NavigationViewProject.Services;
using NavigationViewProject.Views;

namespace NavigationViewProject.ViewModels
{
    public class ShelWindowViewModel : Observable, IDisposable
    {
        private NavigationService _navigationService;
        private RelayCommand _goBackCommand;
        private ICommand _menuItemInvokedCommand;
        private ICommand _optionsItemInvokedCommand;
        private HamburgerMenuItem _selectedMenuItem;
        private HamburgerMenuItem _selectedOptionsItem;

        public HamburgerMenuItem SelectedMenuItem
        {
            get { return _selectedMenuItem; }
            set { Set(ref _selectedMenuItem, value); }
        }

        public HamburgerMenuItem SelectedOptionsItem
        {
            get { return _selectedOptionsItem; }
            set { Set(ref _selectedOptionsItem, value); }
        }

        public ObservableCollection<HamburgerMenuItem> MenuItems { get; } = new ObservableCollection<HamburgerMenuItem>()
        {
            new HamburgerMenuGlyphItem() { Label = "Main", Glyph = "\uE8A5", TargetPageType = typeof(MainPage) },
            new HamburgerMenuGlyphItem() { Label = "Secondary", Glyph = "\uE8A5", TargetPageType = typeof(SecondaryPage) }
        };

        public ObservableCollection<HamburgerMenuItem> OptionsItems { get; } = new ObservableCollection<HamburgerMenuItem>()
        {
            new HamburgerMenuGlyphItem() { Label = "Settings", Glyph = "\uE713", TargetPageType = typeof(SettingsPage) }
        };

        public RelayCommand GoBackCommand => _goBackCommand ?? (_goBackCommand = new RelayCommand(OnGoBack, CanGoBack));

        public ICommand MenuItemInvokedCommand => _menuItemInvokedCommand ?? (_menuItemInvokedCommand = new RelayCommand(MenuItemInvoked));

        public ICommand OptionsItemInvokedCommand => _optionsItemInvokedCommand ?? (_optionsItemInvokedCommand = new RelayCommand(OptionsItemInvoked));

        public ShelWindowViewModel(NavigationService navigationService)
        {
            _navigationService = navigationService;
            _navigationService.Navigated += OnNavigated;
        }

        public void Dispose()
        {
            _navigationService.Navigated -= OnNavigated;
        }

        private bool CanGoBack()
            => _navigationService.CanGoBack;

        private void OnGoBack()
            => _navigationService.GoBack();

        private void OnNavigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {
            var pageType = e.Content.GetType();
            var selected = MenuItems.OfType<HamburgerMenuItem>().FirstOrDefault(i => i.TargetPageType == pageType);
            if (selected != null)
            {
                SelectedMenuItem = selected;
                SelectedOptionsItem = null;
            }
            else
            {
                selected = OptionsItems.OfType<HamburgerMenuItem>().FirstOrDefault(i => i.TargetPageType == pageType);
                SelectedOptionsItem = selected;
                SelectedMenuItem = null;
            }
            GoBackCommand.OnCanExecuteChanged();
        }

        private void MenuItemInvoked()
            => _navigationService.Navigate(SelectedMenuItem.TargetPageType);

        private void OptionsItemInvoked()
            => _navigationService.Navigate(SelectedOptionsItem.TargetPageType);
    }
}
