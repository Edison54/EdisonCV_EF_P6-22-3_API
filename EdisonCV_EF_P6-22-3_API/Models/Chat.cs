using System;
using System.Collections.Generic;

namespace EdisonCV_EF_P6_22_3_API.Models
{
    public partial class Chat
    {
        public long ChatId { get; set; }
        public DateTime Date { get; set; }
        public string Message { get; set; } = null!;
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }

        public virtual User Receiver { get; set; } = null!;
        public virtual User Sender { get; set; } = null!;
    }
}
