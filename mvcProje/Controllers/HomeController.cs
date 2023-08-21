using Microsoft.AspNetCore.Mvc;
using mvcApideneme.Models;
using System.Diagnostics;
using System.Text;
using static System.Net.WebRequestMethods;

namespace mvcApideneme.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> PostDataToApi(DataModell model)
        {
            using (var client = new HttpClient())
            {
                // Web API endpoint adresi
                //string apiUrl = "https://localhost/api/values/postdata";
                string apiUrl = "http://localhost:5256/api/values/postdata";

                // Modeli JSON formatına dönüştür
                string jsonModel = Newtonsoft.Json.JsonConvert.SerializeObject(model);

                // JSON verisini içeren HTTP içeriği
                var content = new StringContent(jsonModel, Encoding.UTF8, "application/json");

                // POST isteği gönderme
                var response = await client.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                  
                    Console.WriteLine("api gönderimi başarılı");
                }
                else
                {
 
                    Console.WriteLine("başarısız");
                }
            }

            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}