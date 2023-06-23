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
    public class QuestionController : ApiController
    {
        
          //  Operations operations = new Operations();
            // POST api/values
            public OutResponse<string> Post(int serviceID, [FromBody] List<Question> questions)
            {
                string xml = "";
                foreach (var item in questions)
                {
                    xml += "<root><Question>" + item.QuestionString + "</Question></root>";
                }
                Operations.QuestionCreation(xml, serviceID);
            OutResponse<string> outResponse = new OutResponse<string>();
            outResponse.ResCode = 101;
            outResponse.ResMessage = "Success";
            outResponse.ResData = "Question(s) Successfully Added";
            return outResponse;
          //  return "Question(s) Successfully Added";
            }
            // GET api/values
            public OutResponse<List<Question>> Get(int serviceID)
            {
                var list = Operations.GetQuestionsFromDB(serviceID);

            OutResponse<List<Question>> outResponse = new OutResponse<List<Question>>();
            outResponse.ResCode = 101;
            outResponse.ResMessage = "Success";
            outResponse.ResData = list;
            return outResponse;
            //return list;
            }
        
    }
}
