using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using TSB100_lab.Models;

namespace TSB100_lab.Controllers
{
    public class RESTPostController : Controller
    {
        string Baseurl = "http://localhost:53217/";
        public async Task<ActionResult> Index()
        {
            List<RESTServicePosts> Postinfo = new List<RESTServicePosts>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/PostContent");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var PostResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    Postinfo = JsonConvert.DeserializeObject<List<RESTServicePosts>>(PostResponse);

                }
                //returning the employee list to view  
                return View(Postinfo);
            }
        }
    }
}