﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MVVM.Pages;
using MVVM.Service;

namespace MVVM.ViewModels
{
    public class MainViewModel
    {
        #region Atributes

        private NavigationService navigationService;
        private ApiService apiService;
        #endregion
        #region Properties
        public ObservableCollection<MenuItemViewModel> Menu { get; set; }

        public ObservableCollection<OrderViewModel> Orders { get; set; }
        public OrderViewModel NewOrder { get; private set; }



        #endregion
        #region Constructors
        public MainViewModel()
        {

            Menu = new ObservableCollection<MenuItemViewModel>();
            Orders = new ObservableCollection<OrderViewModel>();
            navigationService = new NavigationService();
            apiService= new ApiService();
            LoadMenu();
           // loadFakeData();
        }

        #endregion
        #region Commands

        public ICommand GoToCommand
        {
            get { return new  RelayCommand<string>(GoTo); }
        
        }

        public ICommand StartCommand
        {
            get { return new RelayCommand(Start); }
        }

         private async void Start()
        {
            var orders = await apiService.GetAllOrders();
            Orders.Clear();
            foreach (var order in orders)
            {
                Orders.Add(new OrderViewModel
                {
                    Client = order.Client,
                    CreationDate = order.CreationDate,
                    DeliveryDate = order.DeliveryDate,
                    DeliveryInformation= order.DeliveryInformation,
                    Description = order.Description,
                    Id = order.Id,
                    IsDelivered = order.IsDelivered,
                    Phone = order.Phone,
                    Title = order.Title,

                    
                });
            }
        
            navigationService.SetMainPage();
        }

        private void GoTo(string pageName)
        {
            switch (pageName)
            {
                case "NewOrderPage":
                    NewOrder = new OrderViewModel();
                    break;
                 
            }


            navigationService.Navigate(pageName);
        }
        #endregion
        #region Methods
        private void loadFakeData()
        {

            for (int i = 0; i < 10; i++)
            {
                Orders.Add(new OrderViewModel
                {
                    Title = "Lorem Ipsum",
                    DeliveryDate = DateTime.Today,
                    Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                });
            }
        }


        private void LoadMenu()
        {

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_orders.png",
                PageName = "MainPage",
                Title = "Pedidos",
            });


            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_customer.png",
                PageName = "ClientsPage",
                Title = "Clientes",
            });

            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_alarm.png",
                PageName = "AlarmsPage",
                Title = "Alarmas",
            });


            Menu.Add(new MenuItemViewModel
            {
                Icon = "ic_action_action_settings.png",
                PageName = "SettingsPage",
                Title = "Ajuste",
            });
        }

    #endregion
    } 
}
