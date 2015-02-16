using XMLPayrollJSApi.Filters;
using XMLPayrollJSApi.Helpers;
using XMLPayrollJSApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Xml.Linq;
using System.Web.Http.Cors;

namespace XMLPayrollJSApi
{

    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/salary")]
    public class SalaryController : ApiController
    {

        


        [ValidateModelAttribute]
        [HttpPost]
        public IHttpActionResult Post(SalaryDemandViewModel model)
        {

            if (ModelState.IsValid)
            {
                XDocument xml;


                try
                {
                    
                    xml = EapXML.LoadXML(model.Month, model.year,model.IsAnaplhrwths);
                }
                catch (EAPXMLException e)
                {
                    return this.NotFound(e.Message);

                }

                SalaryDetailsViewModel employee = EapXMLTool.GetSalaryDetailsViewModel(xml, model.Afm);
                if (employee == null)
                {
                    return this.NotFound(string.Format("Ο υπαλληλος με ΑΦΜ:{0} δεν βρέθηκε στο XML της περιόδου {1}/{2}", model.Afm, model.Month, model.year));
                }
                return Ok<SalaryDetailsViewModel>(employee);
            }else
            {
                return BadRequest(ModelState);
            }

            //return Ok();
        }
    }


    public class NotFoundTextPlainActionResult : IHttpActionResult
    {
        public NotFoundTextPlainActionResult(string message, HttpRequestMessage request)
        {
            if (message == null)
            {
                throw new ArgumentNullException("message");
            }

            if (request == null)
            {
                throw new ArgumentNullException("request");
            }

            Message = message;
            Request = request;
        }

        public string Message { get; private set; }

        public HttpRequestMessage Request { get; private set; }

        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            return Task.FromResult(Execute());
        }

        public HttpResponseMessage Execute()
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.NotFound);
            response.Content = new StringContent(Message); // Put the message in the response body (text/plain content).
            response.RequestMessage = Request;
            return response;
        }
    }

    public static class ApiControllerExtensions
    {
        public static NotFoundTextPlainActionResult NotFound(this ApiController controller, string message)
        {
            return new NotFoundTextPlainActionResult(message, controller.Request);
        }
    }
}
