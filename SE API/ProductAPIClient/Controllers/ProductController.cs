using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using ProductAPIClient.Models;
using System.Dynamic;
using System.Net.Http.Headers;
using System.Text;

namespace ProductAPIClient.Controllers
{
    public class ProductController : Controller
    {
        string baseurl = "https://localhost:7157/";
        public async Task<ActionResult> Index()
        {
            List<Product> products = new List<Product>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Products");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ProductResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    products = JsonConvert.DeserializeObject<List<Product>>(ProductResponse);

                }
                Category c = new Category();
                List<Category> categories = await c.GetCategories();
                ViewBag.CategoryId = new SelectList(categories, "CategoryId", "CategoryName");
                dynamic mymodel = new ExpandoObject();
                mymodel.Products = products;
                mymodel.Categories = ViewBag.CategoryId;
                //returning the employee list to view  
                return View(mymodel);
            }
        }
        
        [HttpGet]

        public async Task<ActionResult> AddProduct()
        {
            Category c = new Category();  
            List<Category> categories = await c.GetCategories();            
            ViewBag.CategoryId = new SelectList(categories,"CategoryId", "CategoryName");
            return View();            
                      
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct(Product p)
        {
            Product obj = new Product();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseurl);
                StringContent content = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("api/Products", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    obj = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> UpdateProduct(int id)
        {
            Product p = new Product();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync("https://localhost:7157/api/Products/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    p = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return View(p);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateProduct(Product p)
        {
            Product receivedprod = new Product();

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(baseurl);
                #region
                //var content = new MultipartFormDataContent();
                //content.Add(new StringContent(reservation.Empid.ToString()), "Empid");
                //content.Add(new StringContent(reservation.Name), "Name");
                //content.Add(new StringContent(reservation.Gender), "Gender");
                //content.Add(new StringContent(reservation.Newcity), "Newcity");
                //content.Add(new StringContent(reservation.Deptid.ToString()), "Deptid");
                #endregion
                int id = p.ProdId;
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(p), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("api/Products/" + id, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    receivedprod = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            TempData["prodid"] = id;
            Product p = new Product();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:7157/api/Products/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    p = JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return View(p);
        }


        [HttpPost]
        // [ActionName("DeleteEmployee")]
        public async Task<ActionResult> DeleteProduct(Product p)
        {
            int prodid = Convert.ToInt32(TempData["prodid"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:7157/api/Products/" + prodid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> GetProduct(int id)
        {
            Product p = new Product();


            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Products/" + id);

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ProductResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    p = JsonConvert.DeserializeObject<Product>(ProductResponse);

                }
                //returning the employee list to view  
                return View(p);
            }
        }



    }
}
