using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MountainBound.Areas.Campfire.Models
{
    public class Message
    {
        public int MessageId { get; set; }

        public string Heading { get; set; }
        public string Text { get; set; }
        public int TopicId { get; set; }
        public string Username { get; set; }
        public List<Reply> Replies { get; set; } = new List<Reply>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
