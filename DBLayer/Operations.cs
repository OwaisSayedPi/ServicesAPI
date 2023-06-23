using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using EntityLayer;

namespace DBLayer
{
    public static class Operations
    {
        static string connectionString = @"Data Source=PC-227\SQL2016EXPRESS;Initial Catalog=Northwind;User ID=sagar;Password=aa";

        

        public static void SQLCommandRun(string Query)
        {
            SqlConnection sql = new SqlConnection(connectionString);
            sql.Open();

            SqlCommand cmd = new SqlCommand(Query, sql);
            SqlDataReader reader = cmd.ExecuteReader();
            reader.Close();
            sql.Close();
        }
        public static Company CompanyCreation(Company company)
        {
            string Query = "EXEC OS_COMPANY_CREATION '" + company.CompanyName + "'";
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                company = sql.Query<Company>(Query).ToList()[0];
            }
            return company;
        }
        public static  Branch BranchCreation(Branch branch)
        {
            string Query = "EXEC OS_BRANCH_CREATION '" + branch.BranchName + "', " + branch.CompanyID;
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                branch = sql.Query<Branch>(Query).ToList()[0];
            }
            return branch;
        }
        public static Counter CounterCreation(Counter counter)
        {
            string Query = "EXEC OS_COUNTER_CREATION '" + counter.CounterName + "', " + counter.BranchID;
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                counter = sql.Query<Counter>(Query).ToList()[0];
            }
            return counter;
        }
        public static void ServiceCreation(Services services, string question)
        {
            string Query = "EXEC OS_SERVICE_CREATION '" + services.ServiceName+ "', " + services.CounterID +", '"+question+"'";
            SQLCommandRun(Query);
        }
        public static void AgentCreation(Agent agent)
        {
            string Query = $"EXEC OS_AGENT_CREATION '{agent.UserName}', '{agent.Password}', {agent.BranchID}";
            SQLCommandRun(Query);
        }
        public static void QuestionCreation(string question,int serviceID)
        {
            string Query = "EXEC OS_QUESTION_CREATION " +serviceID+", '" + question + "'";
            SQLCommandRun(Query);
        }
        public static List<Token> AnswerCreation(string answers, int serviceID, int branchID)
        {
            string Query = "EXEC OS_ANSWERS_SP '" + answers + "', " + serviceID +", " + branchID;
            List<Token> token;
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                token = sql.Query<Token>(Query).ToList();
            }
            return token;
        }
        public static List<Question> GetQuestionsFromDB(int ServiceID)
        {
            string Query = "EXEC OS_GET_QUESTION " + ServiceID;
            List<Question> questions;
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                questions = sql.Query<Question>(Query).ToList();
            }
            return questions;
        }
        public static List<Answers> GetAnswersFromDB(string Token)
        {
            string Query = "EXEC OS_GET_QNA '" + Token+"'";
            List<Answers> answers;
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                answers = sql.Query<Answers>(Query).ToList();
            }
            return answers;
        }
        public static  void UpdateStatusInDB(string Token, StatusTypes status)
        {            
            string Query = "EXEC OS_STATUS_UPDATE '"+ Token+"', "+((int)status);
            SQLCommandRun(Query);
        }
        public static bool AdminLogin(Admin admin)
        {
            string Query = $"EXEC OS_Admin_Login '{admin.UserName}', '{admin.Password}'";
            bool exists;
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                exists = sql.Query<bool>(Query).ToList()[0];
            }
            return exists;
        }
        public static bool AgentLogin(Agent agent)
        {
            string Query = $"EXEC OS_Agent_Login '{agent.UserName}', '{agent.Password}'";
            bool exists;
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                exists = sql.Query<bool>(Query).ToList()[0];
            }
            return exists;
        }
        public static List<User> GetUserInfo(string token)
        {
            string Query = $"EXEC [OS_GET_USER] '{token}'";
            List<User> user;
            using (SqlConnection sql = new SqlConnection(connectionString))
            {
                user = sql.Query<User>(Query).ToList();
            }
            return user;
        }
    }
}
