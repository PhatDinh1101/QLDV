using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDV.Common.Req
{
    public class StatsQuantityTicketReq
    {
        public int ChuyenXeId { get; set; }
        public string Start { get; set; }
        public string Finish { get; set; }

        public int Quantity { get; set; }

    }
}