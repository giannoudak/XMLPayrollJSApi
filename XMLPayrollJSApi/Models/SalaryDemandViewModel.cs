using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XMLPayrollJSApi.Models
{
    [Serializable]
    public class SalaryDemandViewModel
    {

        [StringLength(9,MinimumLength=9,ErrorMessage="Το ΑΦΜ πρέπει να είναι 9 χαρακτήρες")]
        [Required(ErrorMessage="Το ΑΦΜ είναι υποχρεωτικό")]
        public string Afm { get; set; }
        //[Range(1,12)]
        public short Month { get; set; }
       // [MaxLength(4),MinLength(4)]
        public int year { get; set; }
    }


}