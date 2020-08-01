using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PostSharpAOPSample.Aspects;
using PostSharpAOPSample.Models;
using System.Diagnostics;

namespace PostSharpAOPSample.Controllers
{
    [ProviderAspect]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _ = CalcVAT(5, 8);
            _ = Calc(1, 1);
            return View();
        }

        // This method is passed to description in ProviderAspects
        // because it is ends with "VAT"
        private double CalcVAT(int x, int y)
        {
            return (x + y) * 0.12;
        }

        // This method doesn't suit ProviderAspect description
        // but if you can add aspect with attribute
        [CustomLoggerAspect]
        private double Calc(int x, int y)
        {
            return (x + y) * 0.1;
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
