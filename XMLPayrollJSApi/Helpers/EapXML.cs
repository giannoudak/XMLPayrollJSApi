using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
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
                Uri server = new Uri(Constants.SERVER_NAME);
                Uri xmlFold = new Uri(Constants.SERVER_NAME + Constants.THE_FOLD);
                Uri xmlFoldYear = new Uri(xmlFold, year+"/"+month+"/"+Constants.THE_NAME);
                
                

                try
                {
                    string xmlDataResult ="";


                    // Add a user agent header in case the  
                    // requested URI contains a query.
                    using (WebClient clnt = new WebClient())
                    {
                        clnt.Encoding = System.Text.Encoding.UTF8;
                        clnt.Headers.Add("user-agent", "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; .NET CLR 1.0.3705;)");
                        xmlDataResult = clnt.DownloadString(xmlFoldYear);
                        xmlDoc = XDocument.Parse(xmlDataResult);
                    }


                    //return null;
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