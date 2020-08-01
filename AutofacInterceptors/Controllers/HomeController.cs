using AutofacInterceptors.Interceptors;
using AutofacInterceptors.Interfaces;
using AutofacInterceptors.Models;
using AutofacInterceptors.Services;
using Castle.DynamicProxy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AutofacInterceptors.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDateTimeService _dateTimeService;

        public HomeController(ILogger<HomeController> logger, IDateTimeService dateTimeService)
        {
            _logger = logger;
            _dateTimeService = dateTimeService;
        }

        public IActionResult Index()
        {
            // How to call GetCurrentDate 
            // and meanwhile log with LoggingInterceptor

            // using only Castle.DynamicProxy
            var generator = new ProxyGenerator();
            var dateTimeService = generator.CreateClassProxy<DateTimeService>(new LoggingInterceptor());
            _ = dateTimeService.GetCurrentDate();

            // using Autofac Interceptors in AOP manner
            _ = _dateTimeService.GetCurrentDate();
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
