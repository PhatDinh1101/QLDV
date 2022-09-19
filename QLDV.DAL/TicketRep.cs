using QLDV.Common.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLDV.DAL.Models;
using System.Linq;
using QLDV.Common.Rsp;

namespace QLDV.DAL
{
    public class TicketRep : GenericRep<QLDVXKContext, Ticket>
    {
        public TicketRep()
        {

        }

        public override Ticket Read(int id)
        {
            var res = All.FirstOrDefault(c => c.TicketId == id);
            return res;
        }

        public string Remove(int id)
        {
            string message;
            using (var context = new QLDVXKContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var m = All.First(i => i.TicketId == id);
                        var p = context.Tickets.Remove(m);
                        context.SaveChanges();
                        tran.Commit();
                        message = "Delete complete";
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        message = "Delete not complete";
                    }
                }
            }

            return message;
        }

        public SingleRsp CreateTicket(Ticket ticket)
        {
            var res = new SingleRsp();
            using (var context = new QLDVXKContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Tickets.Add(ticket);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }


        public SingleRsp UpdateTicket(Ticket ticket)
        {
            var res = new SingleRsp();
            using (var context = new QLDVXKContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Tickets.Update(ticket);
                        context.SaveChanges();
                        res.Data = ticket;
                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }
}
