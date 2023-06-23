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
    public class AgentController : ApiController
    {
        public OutResponse<string> Put([FromBody] Agent agent)
        {
            Operations.AgentCreation(agent);
            OutResponse<string> outResponse = new OutResponse<string>();
            outResponse.ResCode = 101;
            outResponse.ResMessage = "Success";
            outResponse.ResData = "Agent Successfully Added";
            return outResponse;
           // return "Agent Successfully Added";
        }
        public OutResponse<bool> Post(Agent agent)
        {
            bool check = Operations.AgentLogin(agent);

            OutResponse<bool> outResponse = new OutResponse<bool>();
            outResponse.ResCode = 101;
            outResponse.ResData = check;
            outResponse.ResMessage = "Task Completed";
            return outResponse;
        }
        public OutResponse<List<User>> Get(string token)
        {
            List<User> user = Operations.GetUserInfo(token);

            OutResponse<List<User>> outResponse = new OutResponse<List<User>>();
            outResponse.ResCode = 101;
            outResponse.ResData = user;
            outResponse.ResMessage = "Task Completed";
            return outResponse;
        }
    }
}
