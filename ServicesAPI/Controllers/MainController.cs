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
    //public class CompanyController : ApiController
    //{
    //   // Operations operations = new Operations();
    //    // POST api/values
    //    public string Post([FromBody] Company company)
    //    {
    //        Operations.CompanyCreation(company);
    //        return "Company Successfully Added";
    //    }
    //}
    //public class BranchController : ApiController
    //{
    //   // Operations operations = new Operations();
    //    // POST api/values
    //    public string Post([FromBody] Branch branch)
    //    {
    //        Operations.BranchCreation(branch);
    //        return "Branch Successfully Added";
    //    }
    //}
    //public class CounterController : ApiController
    //{
    //    //Operations operations = new Operations();
    //    // POST api/values
    //    public string Post([FromBody] Counter counter)
    //    {
    //        Operations.CounterCreation(counter);
    //        return "Counter Successfully Added";
    //    }
    //}
    //public class ServiceController : ApiController
    //{
    //    //Operations operations = new Operations();
    //    // POST api/values
    //    public string Post([FromBody] Services services)
    //    {
    //        string xml = "<root>";
    //        foreach (var item in services.Question)
    //        {
    //            xml += "<Question>" + item.QuestionString + "</Question>";
    //        }
    //        xml += "</root>";
    //        Operations.ServiceCreation(services, xml);
    //        return "ServiceOperation Successfully Added";
    //    }
    //}
    //public class AgentController : ApiController
    //{
    // //   Operations operations = new Operations();
    //    // POST api/values
    //    public string Post([FromBody] Agent agent)
    //    {
    //        Operations.AgentCreation(agent);
    //        return "Agent Successfully Added";
    //    }
    //}
    
    //public class AnswerController : ApiController
    //{
        //Operations operations = new Operations();
        // POST api/values
        //public string Post(int serviceID, int branchID, [FromBody] List<Answers> answers)
        //{
        //    string xml = "<root>";
        //    foreach (var item in answers)
        //    {
        //        xml += "<AnswerID>"+ item.AnswerID + "</AnswerID><Answer>" + item.Answer + "</Answer><QuestionID>" + item.QuestionString + "</QuestionID>";
        //    }
        //    xml += "</root>";

            
        //    string token = Operations.AnswerCreation(xml, serviceID, branchID);
        //    return token;
        //}
        //// GET api/values
        //public List<Answers> Get(string token)
        //{
        //    var list = Operations.GetAnswersFromDB(token);
        //    return list;
        //}
    //}
  
}
