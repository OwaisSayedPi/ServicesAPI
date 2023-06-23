using DBLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ServicesAPI.Controllers
{
    public class AdminController : ApiController
    {
        public OutResponse<bool> Post(Admin admin)
        {
            bool check = Operations.AdminLogin(admin);

            OutResponse<bool> outResponse = new OutResponse<bool>();
            outResponse.ResCode = 101;
            outResponse.ResData = check;
            outResponse.ResMessage = "Task Completed";
            return outResponse;
        }
    }
}
