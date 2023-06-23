using EntityLayer;
using Project1.DatabaseSpecific;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer
{
    public class Branch
    {
        
            public int BranchID { get; set; }
            public string BranchName { get; set; }
            public int CompanyID { get; set; }
            public int CustomersAttended { get; set; }
        
        //OS_Queue_Get_Company_branch
        public OutResponse<List<ServicesDTO>> GetServices(int BranchId)
        {
            DataTable resultSet = RetrievalProcedures.OsGetCategoryReport(BranchId);

            List<ServicesDTO> sList = new List<ServicesDTO>();
            OutResponse<List<ServicesDTO>> outResponse = new OutResponse<List<ServicesDTO>>();
            if (resultSet != null)
            {
                for (int i = 0; i < resultSet.Rows.Count; i++)
                {
                    ServicesDTO s = new ServicesDTO();
                    s.ServiceID = Convert.ToInt32(resultSet.Rows[i]["Id"]);
                    s.ServiceName = resultSet.Rows[i]["ServiceName"].ToString();
                    sList.Add(s);
                }


                outResponse.ResCode = 101;
                outResponse.ResMessage = "Success";
                outResponse.ResData = sList;
            }
            else
            {
                outResponse.ResCode = 100;
                outResponse.ResMessage = "Failed";
                outResponse.ResData = sList;
            }

            return outResponse;

            // Console.ReadLine();
        }
    }
}
