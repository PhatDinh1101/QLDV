using QLDV.Common.DAL;
using QLDV.Common.Rsp;
using QLDV.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDV.DAL
{
    public class BookingRep : GenericRep<QLDVXKContext, Booking>
    {
        public BookingRep()
        {

        }

        public override Booking Read(int id)
        {
            var res = All.FirstOrDefault(c => c.BookingId == id);
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
                        var m = All.First(i => i.BookingId == id);
                        var p = context.Bookings.Remove(m);
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
        public SingleRsp CreateBooking(Booking booking)
        {
            var res = new SingleRsp();
            using (var context = new QLDVXKContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Bookings.Add(booking);
                        context.SaveChanges();
                        tran.Commit();
                        res.Data = booking;
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

        public SingleRsp UpdateBooking(Booking booking)
        {
            var res = new SingleRsp();
            using (var context = new QLDVXKContext())
            {
                using (var t = context.Database.BeginTransaction())
                {
                    try
                    {
                        var b = context.Bookings.Update(booking);
                        context.SaveChanges();
                        res.Data = booking;
                        t.Commit();
                    }
                    catch (Exception ex)
                    {
                        t.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }
            }
            return res;
        }
    }
}
