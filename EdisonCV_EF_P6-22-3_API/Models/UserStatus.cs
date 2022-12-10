using System;
using System.Collections.Generic;

namespace EdisonCV_EF_P6_22_3_API.Models
{
    public partial class UserStatus
    {
        public UserStatus()
        {
            Users = new HashSet<User>();
        }

        public int UserStatusId { get; set; }
        public string Status { get; set; } = null!;

        public virtual ICollection<User> Users { get; set; }
    }
}
