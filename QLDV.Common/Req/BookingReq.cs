using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLDV.Common.Req
{
    public class BookingReq
    {
        public BookingReq()
        {
            UserId = -1;
            TicketId = -1;
            Quantity = -1;
        }
        public BookingReq(int userId, int ticketId, int quantity)
        {
            UserId = userId;
            TicketId = ticketId;
            Quantity = quantity;
        }

        public DateTime? CreateDate { get; set; }
        public int? UserId { get; set; }
        public int? TicketId { get; set; }
        public int? Quantity { get; set; }
    }
}
