using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoadsheddingSystem.Models
{
    public class Complaints
    {
        [Key]
        public int ComplaintsId { get; set; }
        [ScaffoldColumn(false)]
        public string Username { get; set; }
        [Display(Name = "Reason for writing complaint")]
        public string Reason { get; set; }
        [Display(Name = "Brief complaint letter")]
        public string Comments { get; set; }
        [ScaffoldColumn(false)]

        [Display(Name = "Date complaint letter was issued")]
        [DataType(DataType.DateTime)]
        public System.DateTime ComplaintDate { get; set; }


        public DateTime DisplayComplaintTime()
        {
            return DateTime.Now;
        }
    }
}