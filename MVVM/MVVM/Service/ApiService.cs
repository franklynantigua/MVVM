using MVVM.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Service
{
     public   class ApiService
    {
        public async Task<List<Order>>GetAllOrders()
        {
            try
            {
                
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://zulu-software.com");
                var url = "/service/api/Orders";
                var response = await client.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                    
                }

                var result = await response.Content.ReadAsStringAsync();
                var orders = JsonConvert.DeserializeObject<List<Order>>(result);
                return orders;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Order> CreateOrder(Order order)
        {
            try
            {
                var content = JsonConvert.SerializeObject(order);
                var body = new StringContent(content, Encoding.UTF8, "application/json");
                var client = new HttpClient();
                client.BaseAddress = new Uri("http://zulu-software.com");
                var url = "/service/api/Orders";
                var response = await client.PostAsync(url, body);
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                var result = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Order>(result);
            }
            catch
            {
                return null;
            }
        }

    }
}
