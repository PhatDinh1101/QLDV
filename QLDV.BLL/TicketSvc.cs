using QLBH.Common.Req;
using QLDV.Common.BLL;
using QLDV.Common.Req;
using QLDV.Common.Rsp;
using QLDV.DAL;
using QLDV.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDV.BLL
{
    public class TicketSvc:GenericSvc<TicketRep, Ticket>
    {
        private TicketRep TicketRep;
        public TicketSvc()
        {
            TicketRep = new TicketRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }

        public override SingleRsp Delete(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Remove(id);
            res.SetMessage(m);

            return res;
        }

        public SingleRsp CreateTicket(TicketReq ticketReq)
        {
            var res = new SingleRsp();
            Ticket ticket = new Ticket();
            ticket.ChuyenXeId = ticketReq.ChuyenXeId;
            ticket.TimeStart = ticketReq.TimeStart;

            res = TicketRep.CreateTicket(ticket);
            return res;
        }

       
        public SingleRsp UpdateTicket(TicketReq ticketReq, int id)
        {
            var res = new SingleRsp();
            Ticket ticket = new Ticket();
            ticket = id > 0 ? _rep.Read(id) : _rep.Read(id);
            if (ticketReq.ChuyenXeId > 0)
                ticket.ChuyenXeId = ticketReq.ChuyenXeId;
            ticket.TimeStart = ticketReq.TimeStart;

            res = TicketRep.UpdateTicket(ticket);

            return res;
        }
    }
}
