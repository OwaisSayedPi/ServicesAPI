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
    public class CounterController : ApiController
    {
        public OutResponse<Counter> Post([FromBody] Counter counter)
        {
            counter = Operations.CounterCreation(counter);
            OutResponse<Counter> outResponse = new OutResponse<Counter>();
            outResponse.ResCode = 101;
            outResponse.ResMessage = "Success";
            outResponse.ResData = counter;
            return outResponse;
           // return ;
        }
    }
}
