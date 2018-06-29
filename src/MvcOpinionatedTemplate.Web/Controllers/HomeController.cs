using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MvcOpinionatedTemplate.Core.Interfaces.Services;
using MvcOpinionatedTemplate.Web.Models;
using System;
using System.Diagnostics;

namespace MvcOpinionatedTemplate.Web.Controllers
{
    public class HomeController : BaseController<HomeController>
    {
        private readonly IAddressService _addressService;

        public HomeController(IConfiguration configuration, ILogger<HomeController> logger, IAddressService addressService) : base(configuration,logger)
        {
            _addressService = addressService;
        }

        public IActionResult Index()
        {
            Logger.Log(LogLevel.Information, "Logging Example.");

            ViewBag.StateList = _addressService.GetAllStates();
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
