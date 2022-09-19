using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.DAL.Models
{
    public partial class Garage
    {
        public Garage()
        {
            ChuyenXes = new HashSet<ChuyenXe>();
        }

        public int GarageId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        public virtual ICollection<ChuyenXe> ChuyenXes { get; set; }
    }
}
