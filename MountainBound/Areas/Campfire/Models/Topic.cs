using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MountainBound.Areas.Campfire.Models
{
    public class Topic
    {
        public int TopicId { get; set; }
        public string Heading { get; set; }
        public List<Message> Messages { get; set; } = new List<Message>();
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
