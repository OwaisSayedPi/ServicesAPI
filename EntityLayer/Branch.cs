
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    internal class Branch
    {
        
            public int BranchID { get; set; }
            public string BranchName { get; set; }
            public int CompanyID { get; set; }
            public int CustomersAttended { get; set; }
        
        //OS_Queue_Get_Company_branch
      
    }
}
