using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grafik_Web.Models;

namespace Grafik_Web.Controllers
{
    public class AbsenceRequestController : Controller
    {
        public IActionResult SubmitNewAbsenceRequest()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SubmitNewAbsenceRequest(AbsenceRequest request)
        {
            if (ModelState.IsValid)
            {
                return View(request);
            }

            return View();
        }
    }
}
