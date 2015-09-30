using Microsoft.AspNet.Mvc;
using Microsoft.Framework.Configuration;
using System.Net;

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
            string url = "http://webapiresponse.azurewebsites.net/api/values";
            WebClient clnt = new WebClient();
            string strResponse = clnt.DownloadString(url);

            ViewData["Message"] = "Message from http://webapiresponse.azurewebsites.net/api/values : "+ strResponse;//"Your application description page. And a Dependency Injected String: " + _config.Get("Data:DIMessage");
            

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
