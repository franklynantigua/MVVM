using GalaSoft.MvvmLight.Command;
using MVVM.Models;
using MVVM.Service;
using System;
using System.Windows.Input;

namespace MVVM.ViewModels
{
    public  class OrderViewModel
    {

        #region Properties
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public string DeliveryInformation { get; set; }

        public string Client { get; set; }
        public string Phone { get; set; }

        public bool IsDelivered { get; set; }
        #endregion

        #region Attributes

        private ApiService apiService;
        private DialogService dialogService;

        #endregion

        #region Constructors

        public OrderViewModel()
        {
            apiService = new ApiService();
            dialogService = new DialogService();
            DeliveryDate= DateTime.Now;

        }
        #endregion

        #region Commands

        public ICommand SaveCommand
        {
            get
            {
                return new RelayCommand(Save);
            }
        }

        private async void Save()
        {
            //validar que el titulo no este vacio y asi podemos validar los demas !
            if (string.IsNullOrEmpty(Title))
            {

                await dialogService.ShowMessage("Error", "Debes ingresar un titulo");
            }

            var order = new Order
            {
                Id = Id,
                Client = this.Client,
                CreationDate = DateTime.Now,
                DeliveryDate = this.DeliveryDate,
                DeliveryInformation = this.DeliveryInformation,
                Description = this.Description,
                IsDelivered = false,
                Title = this.Title,
            };

            await apiService.CreateOrder(order);
            await dialogService.ShowMessage("Informacion", "El servicio ha sido creado");
        }


        #endregion
    }
}
