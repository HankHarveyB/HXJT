﻿// This Source Code Form is subject to the terms of the MIT License.
// If a copy of the MIT was not distributed with this file, You can obtain one at https://opensource.org/licenses/MIT.
// Copyright (C) Leszek Pomianowski and WPF UI Contributors.
// All Rights Reserved.

using System.Collections.ObjectModel;
using Wpf.Ui.Common;
using Wpf.Ui.Controls;

namespace HXJT.ViewModels.Windows;
public partial class MainWindowViewModel : ObservableObject
{
    [ObservableProperty]
    private string _applicationTitle = "学术活动";

    [ObservableProperty]
    private ObservableCollection<object> _menuItems = new()
    {
        //new NavigationViewItem()
        //{
        //    Content = "Home",
        //    Icon = new SymbolIcon { Symbol = SymbolRegular.Home24 },
        //    TargetPageType = typeof(Views.Pages.DashboardPage)
        //},
        //new NavigationViewItem()
        //{
        //    Content = "Data",
        //    Icon = new SymbolIcon { Symbol = SymbolRegular.DataHistogram24 },
        //    TargetPageType = typeof(Views.Pages.DataPage)
        //},
        //new NavigationViewItem()
        //{
        //    Content="Signin",
        //    Icon = new SymbolIcon {Symbol = SymbolRegular.GlobeAdd20},
        //    TargetPageType=typeof(Views.Pages.SigninPage)
        //},
        new NavigationViewItem()
        {
            Content="虹学讲堂",
            Icon = new SymbolIcon {Symbol= SymbolRegular.Beach48},
            TargetPageType=typeof(Views.Pages.HXJTPage)
        }
    };

    [ObservableProperty]
    private ObservableCollection<object> _footerMenuItems = new()
    {
        new NavigationViewItem()
        {
            Content = "Settings",
            Icon = new SymbolIcon { Symbol = SymbolRegular.Settings24 },
            TargetPageType = typeof(Views.Pages.SettingsPage)
        }
    };

    //[ObservableProperty]
    //private ObservableCollection<MenuItem> _trayMenuItems = new()
    //{
    //    new MenuItem { Header = "Home", Tag = "tray_home" }
    //};
}
