using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDV.Common.Req
{
    public class UserReq
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? UserRole { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Avatar { get; set; }
        public string Status { get; set; }
    }
}
