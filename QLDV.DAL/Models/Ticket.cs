using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.DAL.Models
{
    public partial class Ticket
    {
        public Ticket()
        {
            Bookings = new HashSet<Booking>();
        }

        public int TicketId { get; set; }
        public int? ChuyenXeId { get; set; }
        public DateTime? TimeStart { get; set; }

        public virtual ChuyenXe ChuyenXe { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
