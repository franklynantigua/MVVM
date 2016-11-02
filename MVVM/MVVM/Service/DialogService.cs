﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Service
{
     public class DialogService
    {
        public async Task ShowMessage(string title, string message)
        {
            await App.Navigator.DisplayAlert(title, message, "OK");
        }

    }
}
