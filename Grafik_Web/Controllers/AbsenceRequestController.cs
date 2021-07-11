using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Grafik_Web.Controllers
{
    public class AbsenceRequestController : Controller
    {
        public IActionResult SubmitNewAbsenceRequest()
        {
            return View();
        }
    }
}
