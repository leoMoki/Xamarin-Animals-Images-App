using ImagesApp.Services.Config;
using ImagesApp.Services.Models;
using Newtonsoft.Json;
using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace ImagesApp.Services.Services
{
    public class CatsService
    {
        public async Task<List<Cats>> Get(string param)
        {
            ApiConfigCats api = new ApiConfigCats();

            List<Cats> returnObject = null;

            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(api.BaseAdress);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(api.ContentType));
                client.DefaultRequestHeaders.Add("x-api-key", api.ApiKey);

                if (CrossConnectivity.Current.IsConnected)
                {
                    HttpResponseMessage response = await client.GetAsync(api.Url + param);

                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string Json = await response.Content.ReadAsStringAsync();
                        returnObject = JsonConvert.DeserializeObject<List<Cats>>(Json);
                    }
                }

            }
            catch (Exception ex)
            {
                //add Log
            }

            return returnObject;

        }


    }
}
