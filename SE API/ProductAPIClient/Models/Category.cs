using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace ProductAPIClient.Models
{
    public class Category
    {
        
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }

        string baseurl = "https://localhost:7175/";

        public async Task<List<Category>> GetCategories()
        {
            List<Category> categories = new List<Category>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Categories");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ProductResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    categories = JsonConvert.DeserializeObject<List<Category>>(ProductResponse);

                }
                //returning the employee list to view  
                return categories;
            }
        }
    }
}
