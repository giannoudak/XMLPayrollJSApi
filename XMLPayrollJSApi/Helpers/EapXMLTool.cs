using XMLPayrollJSApi.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace XMLPayrollJSApi.Helpers
{
    public static class EapXMLTool
    {
        // To namespace του XML που παράγεται για αποστολή στην ΕΑΠ
        private readonly static XNamespace nsDefault = XNamespace.Get("http://www.gsis.gr/psp/2.3");

        /// <summary>
        /// Επιστρέφει το Identification Element ενός υπαλλήλου από ένα XML
        /// </summary>
        /// <param name="xmlDoc">το XML</param>
        /// <param name="tin">το ΑΦΜ του υπαλλήλου</param>
        /// <returns>το XElement του Identification του υπαλλήλου</returns>
        public static XElement GetEmployeeIdentification(XDocument xmlDoc, string tin)
        {

            // find the identification element according to request tin (AFM)
            XElement employeeIdentity = (from e in xmlDoc.Descendants(nsDefault + "identification")
                                         where (string)e.Element(nsDefault + "tin").Value.ToString() == tin
                                         select e).SingleOrDefault();

            return employeeIdentity;
        }

        /// <summary>
        /// Επιστρέφει τα προσωπικά στοιχεία του υπαλλήλου από το Identity XElement
        /// </summary>
        /// <param name="employeeIdentity"></param>
        /// <returns>ενα SalaryEmployeeInfo αντικείμενο</returns>
        public static SalaryEmployeeInfo GetEmployeeInfoFromElement(XElement employeeIdentity)
        {
            SalaryEmployeeInfo info = new SalaryEmployeeInfo();
            if (employeeIdentity != null)
            {

                info.Afm = (string)employeeIdentity.Element(nsDefault + "tin").Value.ToString();
                info.Amka = (string)employeeIdentity.Element(nsDefault + "amka").Value.ToString();
                info.FirstName = (string)employeeIdentity.Element(nsDefault + "firstName").Value.ToString();
                info.LastName = (string)employeeIdentity.Element(nsDefault + "lastName").Value.ToString();
                info.Am = (string)employeeIdentity.Element(nsDefault + "amm").Value.ToString();
                info.ArTaut = (string)employeeIdentity.Element(nsDefault + "policeId").Value.ToString();
                info.IsNewInsured = (employeeIdentity.Element(nsDefault + "newInsured") == null ? false : true);
            }

            return info;

        }

        /// <summary>
        /// Επιστρεφει το Payment parent element του Υπαλληλου
        /// </summary>
        /// <param name="employeeIdentification"></param>
        /// <returns></returns>
        public static XElement GetEmployeePaymentParent(XElement employeeIdentification)
        {
            if (employeeIdentification != null)
                return employeeIdentification.Parent;
            else 
                return null;
        }

        /// <summary>
        /// Get all payment Incomes
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> GetPaymentIncomes(XElement payment)
        {
            if (payment != null)
            {
                IEnumerable<XElement> allIncomes = from income in payment.Descendants(nsDefault + "income")
                                                   select income;
                return allIncomes;
            }
            else
                return null;
            
        }


        


        /// <summary>
        /// Get all incomes of a specific type
        /// </summary>
        /// <param name="allIncomes"></param>
        /// <param name="incomeType">o typos tou income</param>
        /// <returns></returns>
        public static IEnumerable<XElement> GetPaymentIncomesOfType(IEnumerable<XElement> allIncomes, int incomeType)
        {
            IEnumerable<XElement> anadIncomes = from takt in allIncomes
                                                where (string)takt.Attribute("type").Value.ToString() == incomeType.ToString()
                                               select takt;

            return anadIncomes;
        }

        /// <summary>
        /// Get Payment Element Total Amounts for A and B payment
        /// </summary>
        /// <param name="payment"></param>
        /// <returns></returns>
        public static SalaryTotals GetPaymentABAmounts(XElement payment)
        {

            decimal Aplhroteo;
            decimal Bplhroteo;
            string alpha = "", bhta = "";
            SalaryTotals totals = new SalaryTotals();


            XElement amount1 = (from s in payment.Descendants(nsDefault + "netAmount1")
                                select s).SingleOrDefault();
            if (amount1 != null)
            {
                alpha = (string)amount1.Attribute("value").Value.ToString();
            }

            XElement amount2 = (from s in payment.Descendants(nsDefault + "netAmount2")
                                select s).SingleOrDefault();
            if (amount2 != null)
            {
                bhta = (string)amount2.Attribute("value").Value.ToString();
            }


            bool aOK = Decimal.TryParse(alpha, out Aplhroteo);
            bool bOK = Decimal.TryParse(bhta, out Bplhroteo);


            if (aOK && bOK)
            {
                totals.AtotalAmount = Aplhroteo;
                totals.BtotalAmount = Bplhroteo;

            }

            return totals;




        }


        /// <summary>
        /// Επιστρέφει τα σύνολο για ΑΜΟΙΒΕΣ, ΚΡΑΤΗΣΕΙΣ, ΕΡΓΟΔΟΤΙΚΕΣ για 
        /// τα income Τακτικής Μισθοδοσίας
        /// </summary>
        /// <param name="incomestaktikhs">Όλα τα income τακτικής</param>
        /// <returns>Ενα SalaryEmployeeDetails για τακτικη</returns>
        public static SalaryEmployeeDetails GetPaymentTaktikisAmounts(IList<XElement> incomestaktikhs, int incomeType )
        {

            SalaryEmployeeDetails employeeItm = null;

            if (incomestaktikhs.Count() > 0)
            {

                employeeItm = new SalaryEmployeeDetails();
                employeeItm.Amoibes = new List<SalaryAmounts>();
                employeeItm.ErgEisfores = new List<SalaryAmounts>();
                employeeItm.Krathseis = new List<SalaryAmounts>();

                // εφόσον ειναι Τακτική, καθαρίζουμε τις τιμές 
                // στα properties για την περίπτωση αναδρομικού
                // TODO ΟΛΕΣ ΤΙΣ ΠΕΡΙΠΤΩΣΕΙΣ....
                employeeItm.Type = 444;
                switch (incomeType)
                {
                    case 0:
                        employeeItm.Type = 0;
                        break;
                    case 1:
                        employeeItm.Type = 1;
                        
                        employeeItm.EndDate = Convert.ToDateTime( incomestaktikhs.First().Attribute("endDate").Value).ToString("dd/M/yyyy");
                        employeeItm.StartDate = Convert.ToDateTime(incomestaktikhs.First().Attribute("startDate").Value).ToString("dd/M/yyyy");
                        employeeItm.PeriodCount = null;

                        break;
                    case 2:
                        employeeItm.Type = 2;
                        break;
                    case 3:
                        employeeItm.Type = 3;
                        break;
                    case 4:
                        employeeItm.Type = 4;
                        break;
                    case 5:
                        employeeItm.Type = 5;
                        break;
                    case 6:
                        employeeItm.Type = 6;
                        break;
                    
                    
                }

                employeeItm.TypeDescriptionText = DisplayNameHelper.GetEnumStringValue((TyposEisodhmatos)employeeItm.Type);
                employeeItm.TypeDisplayText = DisplayNameHelper.GetEnumVocativeDescription((TyposEisodhmatos)employeeItm.Type);
                

               


                employeeItm.Amoibes = EapXMLTool.GetSalaryAmounts(incomestaktikhs, "gr", "kae");
                employeeItm.ErgEisfores = EapXMLTool.GetSalaryAmounts(incomestaktikhs, "et", "code");
                employeeItm.Krathseis = EapXMLTool.GetSalaryAmounts(incomestaktikhs, "de", "code");





            }


            return employeeItm;

        }


        /// <summary>
        /// Επιστρέφει μία λίστα με αντικείμενα SalaryAmounts. Το καθε SalaryAmount
        /// έχει ένα κωδικό, ένα description και το ποσό.
        /// </summary>
        /// <param name="incomes">Η λίστα των incomes</param>
        /// <param name="type">αν προκειται για amoibes "gr", erg.eisfores "et", krathseis "de"</param>
        /// <param name="code">το attribute του element που κραταει το ποσο, "kae" για αμοιβές, "code" για κρατήσεις ή εργ.εισφ.</param>
        /// <returns>Επιστρέφει μία λίστα με αντικείμενα SalaryAmounts. Το καθε SalaryAmount
        /// έχει ένα κωδικό, ένα description και το ποσό.
        /// </returns>
        public static IList<SalaryAmounts> GetSalaryAmounts(IEnumerable<XElement> incomes, string type, string code)
        {
            IList<SalaryAmounts> amounts = new List<SalaryAmounts>();
            IList<string> gfh = new List<string>();


            // διπλο grouping των Incomes ως προς το code 
            var amoibesIncomes = (from tInc in incomes.Descendants(nsDefault + type)
                                  group tInc by tInc.Attribute(code) into amoibes
                                  group amoibes by (amoibes.Key as XAttribute).Value into totals
                                  select new
                                  {
                                      key = totals.Key,                                      
                                      value = totals.ToList()
                                  }).ToList();


            
            foreach (var inc in amoibesIncomes)
            {
                var kae = inc.key;
                string descr="";

                switch (type) 
                {
                    case "gr":
                        descr = DisplayNameHelper.GetEnumDescription((TyposAmoibhsKAE)Convert.ToInt32(kae.Right(3)));
                        break;
                    case "de":
                        descr = DisplayNameHelper.GetEnumDescription((ForeisKrathshs)Convert.ToInt32(kae));
                        break;
                    case "et":
                        descr = DisplayNameHelper.GetEnumDescription((ForeisKrathshs)Convert.ToInt32(kae)) + " Εργοδ.";
                        kae = ((inc.value).First().SingleOrDefault() as XElement).Attribute("kae").Value;

                        break;
                    default:
                        descr = "NotSet";
                        break;
                }

                
                var amount = inc.value.Sum(s => Convert.ToDecimal ( (s.First() as XElement).Attribute("amount").Value));
                SalaryAmounts amoibh = new SalaryAmounts(kae, descr, amount);
                amounts.Add(amoibh);
            }

            return amounts;
        }


        public static SalaryDetailsViewModel GetSalaryDetailsViewModel(XDocument xml, string tin)
        {

            SalaryDetailsViewModel model;

            
            // Διαβάζουμε για τον υπαλληλο το Indentification XElement και το αντίστοιχο SalaryEmployeeInfo instance
            XElement identification = EapXMLTool.GetEmployeeIdentification(xml, tin);
            if (identification !=null ){

                SalaryEmployeeInfo employee = EapXMLTool.GetEmployeeInfoFromElement(identification);

                // Διαβάζουμε το payment parent XElement του Identification
                XElement payment = EapXMLTool.GetEmployeePaymentParent(identification);
                // και παίρνουμε όλα τα incomes του υπαλληλου 
                IEnumerable<XElement> incomes = EapXMLTool.GetPaymentIncomes(payment);

                // κρατάμε τα incomes τακτικής μισθοδοσίας και αναδρομικών
                IEnumerable<XElement> incomesTaktikhs = EapXMLTool.GetPaymentIncomesOfType(incomes,0);
                IEnumerable<XElement> incomesAnadromikwn = EapXMLTool.GetPaymentIncomesOfType(incomes,1);

                IEnumerable<XElement> incomesTrimhnes = EapXMLTool.GetPaymentIncomesOfType(incomes, 2);
                IEnumerable<XElement> incomesEkpApodoxwn = EapXMLTool.GetPaymentIncomesOfType(incomes, 3);

                IEnumerable<XElement> incomesApozhmiwsh = EapXMLTool.GetPaymentIncomesOfType(incomes, 4);
                IEnumerable<XElement> incomesApozhmiwshAdeias = EapXMLTool.GetPaymentIncomesOfType(incomes, 5);

                IEnumerable<XElement> incomesEteroxronismenh = EapXMLTool.GetPaymentIncomesOfType(incomes, 6);


               

                SalaryEmployeeDetails detailsTaktikwn = EapXMLTool.GetPaymentTaktikisAmounts(incomesTaktikhs.ToList(), 0);
                SalaryEmployeeDetails detailsAnadromikwn = EapXMLTool.GetPaymentTaktikisAmounts(incomesAnadromikwn.ToList(), 1);

                SalaryEmployeeDetails detailsTrimhnesApodoxes = EapXMLTool.GetPaymentTaktikisAmounts(incomesTrimhnes.ToList(), 2);
                SalaryEmployeeDetails detailsEkpaidApodoxes = EapXMLTool.GetPaymentTaktikisAmounts(incomesEkpApodoxwn.ToList(), 3);

                SalaryEmployeeDetails detailsApozhmiwsh = EapXMLTool.GetPaymentTaktikisAmounts(incomesApozhmiwsh.ToList(), 4);
                SalaryEmployeeDetails detailsApozhmiwshAdeias = EapXMLTool.GetPaymentTaktikisAmounts(incomesApozhmiwshAdeias.ToList(), 5);

                SalaryEmployeeDetails detailsEteroxronismenh = EapXMLTool.GetPaymentTaktikisAmounts(incomesEteroxronismenh.ToList(), 6);


                SalaryTotals ABamounts = EapXMLTool.GetPaymentABAmounts(payment);


                model = new SalaryDetailsViewModel();

                model.SalaryEmployee = employee;
                model.SalaryTotalAmounts = ABamounts;
                model.SalaryDetalis = new List<SalaryEmployeeDetails>();

                if (detailsTaktikwn != null) model.SalaryDetalis.Add(detailsTaktikwn);
                if (detailsAnadromikwn != null) model.SalaryDetalis.Add(detailsAnadromikwn);

                if (detailsTrimhnesApodoxes != null) model.SalaryDetalis.Add(detailsTrimhnesApodoxes);
                if (detailsEkpaidApodoxes != null) model.SalaryDetalis.Add(detailsEkpaidApodoxes);

                if (detailsApozhmiwsh != null) model.SalaryDetalis.Add(detailsApozhmiwsh);
                if (detailsApozhmiwshAdeias != null) model.SalaryDetalis.Add(detailsApozhmiwshAdeias);

                if (detailsEteroxronismenh != null) model.SalaryDetalis.Add(detailsEteroxronismenh);
                

                return model;
            }
            else
            {
                return null;
            }
          
            

            
        }
    }
}