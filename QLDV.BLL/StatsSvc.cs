using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDV.Common.BLL;
using QLDV.Common.Req;
using QLDV.Common.Rsp;
using QLDV.DAL;
using QLDV.DAL.Models;

namespace QLDV.BLL
{
    public class StatsSvc
    {
        private StatsRep statsRep;

        public StatsSvc()
        {
            statsRep = new StatsRep();
        }

        public SingleRsp StatsQuantityTicket(int month)
        {
            var res = new SingleRsp();
            res = statsRep.StatsQuantityTicket(month);
            return res;
        }
    }
}