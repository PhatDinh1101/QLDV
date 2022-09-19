using System;
using System.Collections.Generic;

#nullable disable

namespace QLDV.DAL.Models
{
    public partial class User
    {
        public User()
        {
            Bookings = new HashSet<Booking>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? UserRole { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Avatar { get; set; }
        public string Status { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}
