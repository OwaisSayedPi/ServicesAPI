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
    public class BranchController : ApiController
    {
        public OutResponse<Branch> Post([FromBody] Branch branch)
        {
            branch = Operations.BranchCreation(branch);
            OutResponse<Branch> outResponse = new OutResponse<Branch>();
            outResponse.ResCode = 101;
            outResponse.ResMessage = "Success";
            outResponse.ResData = branch;
            return outResponse;
            //  return "Branch Successfully Added";
        }
    }
}
