﻿using System.Diagnostics;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Weather.Services;
using Weather.ViewModels;
using Application = Microsoft.Maui.Controls.Application;
using WindowsConfiguration = Microsoft.Maui.Controls.PlatformConfiguration.Windows;

namespace Weather.Pages;

public partial class HomePage : ContentPage
{
    static bool isSetup = false;

    public HomePage(HomeViewModel vm)
    {
        InitializeComponent();

        BindingContext = vm;

        if (!isSetup)
        {
            isSetup = true;

            SetupAppActions();
            SetupTrayIcon();
        }
    }

    private void SetupAppActions()
    {
        try
        {
            AppActions.SetAsync(
                new AppAction("current_info", "Check Current Weather", icon: "current_info"),
                new AppAction("add_location", "Add a Location", icon: "add_location")
            );
        }
        catch (System.Exception ex)
        {
            Debug.WriteLine("App Actions not supported", ex);
        }
    }

    private void SetupTrayIcon()
    {
        var trayService = ServiceProvider.GetService<ITrayService>();

        if (trayService != null)
        {
            trayService.Initialize();
            trayService.ClickHandler = () =>
                ServiceProvider.GetService<INotificationService>()
                    ?.ShowNotification("Hello Build! 😻 From .NET MAUI", "How's your weather?  It's sunny where we are 🌞");
        }
    }
}

public class MainPageViewModel
{
    public string CurrentDate => DateTime.Now.ToString("yyyy-MM-dd");
}