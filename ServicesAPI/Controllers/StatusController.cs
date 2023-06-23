using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DBLayer;
using EntityLayer;

namespace ServicesAPI.Controllers
{
    public class StatusController : ApiController
    {

        //  Operations operations = new Operations();
        // PUT api/values/5
        public OutResponse<string> Put(string token, StatusTypes status)
            {
                Operations.UpdateStatusInDB(token, status);
                OutResponse<string> outResponse = new OutResponse<string>();
                outResponse.ResCode = 101;
                outResponse.ResMessage = "Success";
                outResponse.ResData = "Task Completed";
                return outResponse;
            //return ;
            }
        
    }
}
