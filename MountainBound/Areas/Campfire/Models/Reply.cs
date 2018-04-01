using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MountainBound.Areas.Campfire.Models
{
    public class Reply
    {
        public int ReplyId { get; set; }
        public int MessageId { get; set; }
        public string Text { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
