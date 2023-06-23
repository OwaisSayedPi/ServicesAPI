using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EntityLayer;
using DBLayer;

namespace ServicesAPI.Controllers
{
    public class ServiceController : ApiController
    {
        private ServiceOperation serviceOperation;
        ServiceController()
        {
             serviceOperation = new ServiceOperation();
        }
        public OutResponse<string> Post([FromBody] Services services)
        {
            string xml = "<root>";
            foreach (var item in services.Question)
            {
                xml += "<Question>" + item.QuestionString + "</Question>";
            }
            xml += "</root>";
            Operations.ServiceCreation(services, xml);
            //return "ServiceOperation Successfully Added";
            OutResponse<string> outResponse = new OutResponse<string>();
            outResponse.ResCode = 101;
            outResponse.ResMessage = "Success";
            outResponse.ResData = "ServiceOperation Successfully Added";
            return outResponse;
        }
        public OutResponse<List<ServicesDTO>> Get(int id)
        {
            return serviceOperation.GetServices(id);
            //OutResponse<string> outResponse = new OutResponse<string>();
            //return outResponse;
        }
    }
}
