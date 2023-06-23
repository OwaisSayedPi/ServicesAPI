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
    public class CompanyController : ApiController
    {
        public OutResponse<Company> Post([FromBody] Company company)
        {
            company = Operations.CompanyCreation(company);
            OutResponse<Company> outResponse = new OutResponse<Company>();
            outResponse.ResCode = 101;
            outResponse.ResMessage = "Success";
            outResponse.ResData = company;
            return outResponse;
        }
    }
}
