using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.DAL.Models
{
    public partial class ChuyenXe
    {
        public ChuyenXe()
        {
            Tickets = new HashSet<Ticket>();
        }

        public int ChuyenXeId { get; set; }
        public int? GarageId { get; set; }
        public string Start { get; set; }
        public string Finish { get; set; }

        public virtual Garage Garage { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
