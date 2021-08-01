using Grafik_Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Grafik_Web.Controllers
{
    public class TimesheetsController : Controller
    {
        private readonly ILogger<TimesheetsController> _logger;

        public TimesheetsController(ILogger<TimesheetsController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            TimeSheetViewModel timesheets = new TimeSheetViewModel();
            timesheets.Employees = Grafik_Logic.JsonHelper.LoadEmployeesJson<Grafik_Logic.Employee>();

            return View(timesheets);
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
