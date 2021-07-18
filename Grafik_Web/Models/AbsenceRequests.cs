using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Grafik_Logic;

namespace Grafik_Web.Models
{

    public class AbsenceRequest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public Employee Requester { get; set; }
        [Required]
        public DateTime SubmissionDate { get; set; }
        [Required]
        public DateTime AbsenceStartDate { get; set; }
        [Required]
        public DateTime AbsenceEndDate { get; set; }
        [Required]
        public string CurrentStatus { get; set; }

        public string RequestType { get; set; }
    }
}
