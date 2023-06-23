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
    public class AnswerController : ApiController
    {
        public OutResponse<List<Token>> Post(int serviceID, int branchID, [FromBody] List<Answers> answers)
        {
            string xml = "";
            foreach (var item in answers)
            {
                xml += "<root><AnswerID>" + item.AnswerID + "</AnswerID><Answer>" + item.Answer + "</Answer><QuestionID>" + item.QuestionID + "</QuestionID></root>";
            }
            List<Token> token = Operations.AnswerCreation(xml, serviceID, branchID);

            OutResponse<List<Token>> outResponse = new OutResponse<List<Token>>();
            outResponse.ResCode = 101;
            outResponse.ResMessage = "Success";
            outResponse.ResData = token;


            return outResponse;
        }
        // GET api/values
        public OutResponse<List<Answers>> Get(string token)
        {
            var list = Operations.GetAnswersFromDB(token);
            OutResponse<List<Answers>> outResponse = new OutResponse<List<Answers>>();
            outResponse.ResCode = 101;
            outResponse.ResMessage = "Success";
            outResponse.ResData = list;
            return outResponse;
        }
    }
}
