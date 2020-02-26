using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LoadsheddingSystem.Models
{
    public class Loadshedding
    {
        [Key]
        public int LoadsheddingId { get; set; }
        //[Required]
        [Display(Name ="Block Number")]
        public string BlockNumber { get; set; }
        [Required]
        [Display(Name ="Date of Loadshedding")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name ="Starting Time")]
        [TimeValidation(ErrorMessage = "Power can only be taken at o'clock or half past ")]
        public DateTime StartTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name ="Ending Time")]
        [TimeValidation(ErrorMessage ="Power can only return at o'clock or half past ")]
        public DateTime EndTime { get; set; }
       // [Required]

        public string Stage { get; set; }


        public class TimeValidation : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                DateTime dt = (DateTime)value;
                if (dt.Minute == 30 || dt.Minute == 00)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }
}