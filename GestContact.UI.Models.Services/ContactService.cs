using GestContact.Interfaces;
using GestContact.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using Tools.Api;

namespace GestContact.UI.Models.Services
{
    public class ContactService : IContactServices<Contact>
    {
        private readonly IApiInfo _apiInfo;

        public ContactService(IApiInfo apiInfo)
        {
            _apiInfo = apiInfo;
        }
        

        public IEnumerable<Contact> Get()
        {
            using (HttpClient httpClient = HttpClientBuilder.Build(_apiInfo))
            {
                HttpResponseMessage responseMessage = httpClient.GetAsync("Contact").Result;
                responseMessage.EnsureSuccessStatusCode();
                string json = responseMessage.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Contact[]>(json);
            }
        }

        public Contact Get(int id)
        {
            using (HttpClient httpClient = HttpClientBuilder.Build(_apiInfo))
            {
                HttpResponseMessage responseMessage = httpClient.GetAsync("Contact/" + id).Result;
                responseMessage.EnsureSuccessStatusCode();
                string json = responseMessage.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Contact>(json);
            }
        }

        public Contact Insert(Contact entity)
        {
            using (HttpClient httpClient = HttpClientBuilder.Build(_apiInfo))
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(entity));
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage responseMessage = httpClient.PostAsync("Contact", httpContent).Result;
                responseMessage.EnsureSuccessStatusCode();
                string json = responseMessage.Content.ReadAsStringAsync().Result;
                return JsonConvert.DeserializeObject<Contact>(json);
            }
        }

        public bool Update(int id, Contact entity)
        {
            using (HttpClient httpClient = HttpClientBuilder.Build(_apiInfo))
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(entity));
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
                HttpResponseMessage responseMessage = httpClient.PutAsync("Contact/" + id, httpContent).Result;
                responseMessage.EnsureSuccessStatusCode();
                return true;
            }
        }

        public bool Delete(int id)
        {
            using (HttpClient httpClient = HttpClientBuilder.Build(_apiInfo))
            {
                HttpResponseMessage responseMessage = httpClient.DeleteAsync("Contact/" + id).Result;
                responseMessage.EnsureSuccessStatusCode();
                return true;
            }
        }
    }
}
