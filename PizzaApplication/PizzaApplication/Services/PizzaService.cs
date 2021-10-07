using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PizzaApplication.Services
{
    public class PizzaService
    {
        public string GetAll(string token)
        {
            string PizzaList = null;

            using (var client = new HttpClient())
            {

                client.BaseAddress = new Uri("http://localhost:33854/api/");
                client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                var getTask = client.GetAsync("Pizza");
                getTask.Wait();
                var result = getTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync();
                    data.Wait();
                    PizzaList = data.Result;
                }


            }
            return PizzaList;
        }
    }
}
