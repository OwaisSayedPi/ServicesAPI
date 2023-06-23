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
    public class BranchCompanyOperation
    {

        public OutResponse<List<BranchCompanyDTO>> GetServices(int BranchId)
        {
            DataTable resultSet = RetrievalProcedures.OsGetCategoryReport(BranchId);

            List<BranchCompanyDTO> sList = new List<BranchCompanyDTO>();
            OutResponse<List<BranchCompanyDTO>> outResponse = new OutResponse<List<BranchCompanyDTO>>();
            if (resultSet != null)
            {
                for (int i = 0; i < resultSet.Rows.Count; i++)
                {
                    //BranchCompanyDTO s = new BranchCompanyDTO();
                    //s. = Convert.ToInt32(resultSet.Rows[i]["Id"]);
                    //s.ServiceName = resultSet.Rows[i]["ServiceName"].ToString();
                    //sList.Add(s);
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
