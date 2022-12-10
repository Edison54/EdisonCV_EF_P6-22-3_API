using System;
using System.Collections.Generic;

namespace EdisonCV_EF_P6_22_3_API.Models
{
    public partial class UserRole
    {
        public UserRole()
        {
            Users = new HashSet<User>();
        }

        public int UserRoleId { get; set; }
        public string UserRole1 { get; set; } = null!;
        public bool IsUserSelectable { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
