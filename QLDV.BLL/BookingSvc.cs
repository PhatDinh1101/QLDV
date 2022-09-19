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
    public class BookingSvc : GenericSvc<BookingRep, Booking>
    {
        private BookingRep req;
        public BookingSvc()
        {
            req = new BookingRep();
        }

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            res.Data = _rep.Read(id);
            return res;
        }
        public override SingleRsp Update(Booking b)
        {
            var res = new SingleRsp();

            var m1 = b.BookingId > 0 ? _rep.Read(b.BookingId) : _rep.Read(b.BookingId);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(b);
                res.Data = b;
            }

            return res;
        }
        public override SingleRsp Delete(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Remove(id);
            res.SetMessage(m);

            return res;
        }
        public SingleRsp CreateBooking(BookingReq bookingReq)
        {
            var res = new SingleRsp();
            Booking booking = new Booking();
            booking.UserId = bookingReq.UserId;
            booking.TicketId = bookingReq.TicketId;
            booking.Quantity = bookingReq.Quantity;
            booking.CreateDate = bookingReq.CreateDate;
            res = req.CreateBooking(booking);
            return res;
        }

        public SingleRsp UpdateBooking(BookingReq bookingReq, int id)
        {
            var res = new SingleRsp();
            Booking booking = new Booking();
            booking = id > 0 ? _rep.Read(id) : _rep.Read(id);
            if (bookingReq.UserId > 0)
                booking.UserId = bookingReq.UserId;
            if (bookingReq.TicketId > 0)
                booking.TicketId = bookingReq.TicketId;
            if (bookingReq.Quantity > 0)
                booking.Quantity = bookingReq.Quantity;

            res = req.UpdateBooking(booking);

            return res;
        }
    }
}
