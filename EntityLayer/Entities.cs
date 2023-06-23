using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   
   
    public class Agent
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int BranchID { get; set; }
    }
    public class Counter
    {
        public int CounterID { get; set; }
        public string CounterName { get; set; }
        public int BranchID { get; set; }
    }
    //public class Services
    //{
    //    public int ServiceID { get; set; }
    //    public string ServiceName { get; set; }
    //    public int CounterID { get; set; }
    //    public List<Question> Question { get; set; }
    //}
    public class Question
    {
        public int QuestionID { get; set; }
        public string QuestionString { get; set; }
    }
    public class Answers
    {
        public int AnswerID { get; set; }
        public string Answer { get; set; }
        public int QuestionID { get; set; }
    }
    public class User
    {
        public int UserID { get; set; }
        public string Token { get; set; }
        public StatusTypes Status { get; set; }
        public int ServiceID { get; set; }
        public int CounterID { get; set; }
        public int AgentID { get; set; }
        public DateTime ResolvedTime { get; set; }
    }
    public enum StatusTypes
    {
        Waiting = 1,
        Active = 2,
        Resolved = 3,
    }
}
