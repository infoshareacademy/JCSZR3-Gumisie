using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grafik_Logic;
using Grafik_Web.Models;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace Grafik_Web.Controllers
{
    public class AbsenceRequestController : Controller
    {
        //private readonly /*AbsenceRequestService*/ _absenceRequestService;

        public AbsenceRequestController()
        {
            JsonHelper.LoadAbsenceRequestsJson();
        }
        public IActionResult SubmitNewAbsenceRequest()
        { 
            return View();
        }

        //[HttpPost]
        //public IActionResult SubmitNewAbsenceRequest(AbsenceRequest model)
        //{
        //    await this._AbsenceRequestService.AddNewRequest(model);
        //    return View();
        //}
        [HttpGet]
        public IActionResult ViewMyAbsenceRequests(string requestType)
        {

            return View();
        }

        public IActionResult ViewMyAbsences()
        {
            return View();
        }


    }
}
