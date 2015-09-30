using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Configuration;

namespace AmexTestAppMVC_DI_MOQ.Controllers
{
    public class HomeController : Controller
    {
        private readonly IConfiguration _config;

        public HomeController(IConfiguration config)
        {
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page. And a Dependency Injected String: " + _config.Get("Data:DIMessage");

            return View();
        }

        public IActionResult WebServiceAbout()
        {
            //string messageFromWebservice = System.Net.WebRequest.Create("http://webapiresponse.azurewebsites.net/api/values").GetResponse().ToString();

            //System.Net.WebClient client = new System.Net.WebClient();
            //string messageFromWebservice = client.OpenRead("http://webapiresponse.azurewebsites.net/api/values").ToString();

            ViewData["Message"] = "Message from http://webapiresponse.azurewebsites.net/api/values : "; //+ messageFromWebservice;//"Your application description page. And a Dependency Injected String: " + _config.Get("Data:DIMessage");

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View("~/Views/Shared/Error.cshtml");
        }
    }
}
