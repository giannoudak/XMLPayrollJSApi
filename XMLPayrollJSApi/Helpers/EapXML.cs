using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security;
using System.Web;
using System.Xml.Linq;

namespace XMLPayrollJSApi.Helpers
{

    public static class EapXML
    {

        /// <summary>
        /// Loads and returns the appropriate XML instance
        /// </summary>
        /// <param name="month"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public static XDocument LoadXML(short month, int year)
        {
            XDocument xmlDoc;
            if (month != null && year != null)
            {

                string xmlData = HttpContext.Current.Server.MapPath("~/App_Data/xmls/"+year+"/"+month+"/data.xml");//Path of the xml script

                try
                {
                    xmlDoc = XDocument.Load(xmlData);
                    return xmlDoc;
                }
                catch (SecurityException e)
                {
                  // The XmlReader does not have sufficient permissions 
                  // to access the location of the XML data.
                    //return null;
                    throw;
                }
                catch (FileNotFoundException e)
                {
                    // The underlying file of the path cannot be found
                    throw new EAPXMLException(string.Format("Το αρχείο XML για την περίοδο {0}/{1} δεν βρέθηκε", month, year), e);
                    //return null;
                }
                catch (System.Xml.XmlException e)
                {
                    throw;
                }
                catch (Exception e)
                {
                    throw new EAPXMLException(string.Format("Το αρχείο XML για την περίοδο {0}/{1} δεν βρέθηκε", month, year), e);
                    //throw;
                }
                
            }
            else
            {
                // The underlying file of the path cannot be found
                throw new EAPXMLException("Δεν δώσατε Περίοδο Πληρωμής (Μήνα/Έτος) προς αναζήτηση ",null);
                //return null;
            }
        }


    }
}