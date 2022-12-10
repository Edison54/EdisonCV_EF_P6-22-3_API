using System;
using System.Collections.Generic;

namespace EdisonCV_EF_P6_22_3_API.Models
{
    public partial class AskStatus
    {
        public AskStatus()
        {
            Asks = new HashSet<Ask>();
        }

        public int AskStatusId { get; set; }
        public string AskStatus1 { get; set; } = null!;

        public virtual ICollection<Ask> Asks { get; set; }
    }
}
