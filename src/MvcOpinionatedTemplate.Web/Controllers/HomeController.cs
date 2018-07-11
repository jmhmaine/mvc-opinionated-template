using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MvcOpinionatedTemplate.Core.Interfaces.Services;
using MvcOpinionatedTemplate.Web.Models;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MvcOpinionatedTemplate.Domain.Models;

namespace MvcOpinionatedTemplate.Web.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        private readonly IAddressService _addressService;
        private const string SessionKeySetTime = "_SetTime";

        public HomeController(IConfiguration configuration, ILogger<HomeController> logger, IAddressService addressService) : base(configuration,logger)
        {
            _addressService = addressService;
        }

        public async Task<IActionResult> Index()
        {
            Logger.Log(LogLevel.Information, "Logging Example.");

            //if (string.IsNullOrEmpty(HttpContext.Session.GetString(SessionKeySetTime)))
            //{
            //    HttpContext.Session.SetString(SessionKeySetTime, DateTimeOffset.Now.ToString());
            //}

            //ViewBag.SessionKeyNameValue = HttpContext.Session.GetString(SessionKeySetTime);

            ViewBag.SessionKeyNameValue = "n/a";

            ViewBag.StateList = await _addressService.GetAllStatesAsync<State>();
            ViewBag.ProcessName = Configuration["ProcessName"];

            return View();
        }

        public IActionResult ShowAnException()
        {
            ViewData["Message"] = "ASP.NET Core MVC Opinionated Template";

            throw new Exception("A Test from ShowAnException!");
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
