using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XMLPayrollJSApi.Models
{
    [Serializable]
    public class SalaryDetailsViewModel
    {
        public SalaryEmployeeInfo SalaryEmployee { get; set; }

        public List<SalaryEmployeeDetails> SalaryDetalis { get; set; }

        public SalaryTotals SalaryTotalAmounts { get; set; }
       
        public List<EapXMLError> Errors { get; set; }
    }

    [Serializable]
    public class SalaryTotals
    {
        public decimal AtotalAmount { get; set; }
        public decimal BtotalAmount { get; set; }
    }

    [Serializable]
    public class SalaryEmployeeInfo
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Afm { get; set; }
        public string Amka { get; set; }

        public string Am { get; set; }
        public string Patronymo { get; set; }

        public string ArTaut { get; set; }

        public bool IsNewInsured { get; set; }
        
    }

    [Serializable]
    public class SalaryEmployeeDetails
    {

        public int skata { get; set; }

        public int Type { get; set; }
        public string TypeDescriptionText { get; set; }

        public string TypeDisplayText { get; set; }

        public int? PeriodCount { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }


        public string AmoibesPredicate
        {
            get
            {
                return this.TypeDescriptionText + "_Amoibes";
            }
        }

        public string KrathseisPredicate
        {
            get
            {
                return this.TypeDescriptionText + "_Krathseis";
            }
        }

        public List<SalaryAmounts> Amoibes { get; set; }
        public List<SalaryAmounts> ErgEisfores { get; set; }
        public List<SalaryAmounts> Krathseis { get; set; }

       

        public decimal TotalSynakap 
        { 
            get 
            {
                decimal total = 0M;
                total = this.Amoibes.Sum(s => s.Amount);
                return total;
            } 
        }

        public decimal TotalErgodotikes
        {
            get
            {
                decimal total = 0M;
                total = this.ErgEisfores.Sum(s => s.Amount);
                return total;
            }
        }

        public decimal TotalKrathseis
        {
            get
            {
                decimal total = 0M;
                total = this.Krathseis.Sum(s => s.Amount);
                return total;
            }
        }

        public decimal TotalSynoloKrathsewn
        {
            get
            {
                return (this.TotalKrathseis + this.TotalErgodotikes);
            }
        }

        public decimal TotalPlhroteo
        {
            get
            {
                return this.TotalSynakap + this.TotalErgodotikes - this.TotalSynoloKrathsewn;
            }
        }

    }

    [Serializable]
    public class SalaryAmounts
    {
        private string kae;
        private string kaeDesc;
        private decimal amount;

        public string Kae { get; set; }
        public string KaeDesc { get; set; }
        public decimal Amount { get; set; }

        public SalaryAmounts(string kae, string kaeDesc, decimal amount)
        {
            
            this.Kae = kae;
            this.KaeDesc = kaeDesc;
            this.Amount = amount;
        }

        public SalaryAmounts()
        {
            // TODO: Complete member initialization
        }

    }
}