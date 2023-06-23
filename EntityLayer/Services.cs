using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
    public class Services
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }
        public int CounterID { get; set; }
        public List<Question> Question { get; set; }
    }
    public class ServicesDTO
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; }

        public string BranchName { get; set; }
    }
}
