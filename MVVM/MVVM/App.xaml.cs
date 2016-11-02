﻿
using MVVM.Pages;
using Xamarin.Forms;

namespace MVVM
{

    public partial class App : Application
        {
        public static NavigationPage Navigator { get; internal set; }

        public App()
            {
                InitializeComponent();

            // The root page of your application
            MainPage = new MasterPage();

            }

            protected override void OnStart()
            {
                // Handle when your app starts
            }

            protected override void OnSleep()
            {
                // Handle when your app sleeps
            }

            protected override void OnResume()
            {
                // Handle when your app resumes
            }
        }
    }

