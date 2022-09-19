using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDV.Common.Req
{
    public class TicketReq
    {
        public TicketReq()
        {
            ChuyenXeId = -1;
            TimeStart = DateTime.Now;
        }
        public TicketReq(int ChuyenXeId, DateTime TimeStart)
        {
            ChuyenXeId = ChuyenXeId;
            TimeStart = TimeStart;
        }

        public int? ChuyenXeId { get; set; }
        public DateTime? TimeStart { get; set; }
    }
}
