using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoadsheddingSystem.Models
{
    public class Notify
    {
        [Key]
        public int NotifyId { get; set; }
        [Required]
        [Display(Name ="Reason for sending notification")]
        public string NotificationReason { get; set; }
        [Required]
        [Display(Name ="Cellphone number")]
        public string CellNo { get; set; }
        public string Comments { get; set; }

    }
}