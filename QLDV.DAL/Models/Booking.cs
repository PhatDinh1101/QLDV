using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.DAL.Models
{
    public partial class Booking
    {
        public int BookingId { get; set; }
        public int? UserId { get; set; }
        public int? TicketId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Quantity { get; set; }

        public virtual Ticket Ticket { get; set; }
        public virtual User User { get; set; }
    }
}
