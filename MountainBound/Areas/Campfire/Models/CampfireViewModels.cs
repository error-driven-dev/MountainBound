using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MountainBound.Areas.Campfire.Models
{
    public class MessageModel
    {
        [Required]
        public string Heading { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int TopicId { get; set; }

        [Required]
        public string TopicHeading { get; set; }

        [Required]
        public string Username { get; set; }
    }

    public class ReplyModel
    {
        [Required]
        public int MessageId { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public string Username { get; set; }
    }
}
