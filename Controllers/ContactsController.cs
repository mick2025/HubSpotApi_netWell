using HubSpotApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Data;
using System.Text;

namespace HubSpotApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly string _token;
        private readonly string _baseUrl;
        private readonly string _endPoint;
        

        public ContactsController(IConfiguration configuration)
        {
            _baseUrl = configuration["HubSpotBaseUrl"];
            _endPoint = configuration["HubSpotContactEndpoint"];
            _token = configuration["HubSpotToken"];
        }

        [HttpPost]
        public async void AddContact([FromBody] Contact request)
        {            
            try
            {
                var contacObj = new Properties();
                contacObj.properties = request;
                var data = JObject.FromObject(contacObj);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_baseUrl);

                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    var response = client.PostAsync(_endPoint, new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json")).Result;

                    response.EnsureSuccessStatusCode();
                    
                }
            }   
            catch (Exception ex)
            {
                // nothing yet                
            }
            
        }

    }
}
