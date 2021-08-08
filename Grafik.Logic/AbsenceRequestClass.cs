using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


/*

    "requestdate": "2021-06-18",
    "absence": [
      {
        "EmployeeEmail": "bonnie.craig@example.com",
        "AbsenceStartDate": "2021-07-18",
        "AbsenceEndDate": "2021-07-20",
        "AbsenceType": "AnnualLeave",
        "Comment": "OwO",
        "Status": "Pending"
      }
    ]
 */
namespace Grafik_Logic
{
    public class AbsenceRequestClass
    {

        public string RequestDate { get; set; }
        public abs Absence { get; set; }

        public class abs
        {
            public string EmployeeEmail { get; set; }
            public string AbsenceStartDate { get; set; }
            public string AbsenceEndDate { get; set; }
            public string AbsenceType { get; set; }
            public string Comment { get; set; }
            public string Status { get; set; }
        }
    }
}