using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MountainBound.Models;

namespace MountainBound.Areas.Campfire.Models
{
    public class MessageRepository
    {
        private AppDbContext _context;
        private List<Topic> _topics = new List<Topic>();

        public MessageRepository(AppDbContext context)
        {
            _context = context;
            
        }

        public List<Topic> GetTopics => _context.Topics.ToList();

        public Topic GetTopicMessages(int topicId)
        {
            var topicMessages = _context.Topics.Include(m => m.Messages)
                .FirstOrDefault(t => t.TopicId == topicId);
            return topicMessages;
        }

        public Message GetMessageAndReplies(int msgId)
        {
            var msgAndReplies = _context.Messages.Include(r => r.Replies).FirstOrDefault(m => m.MessageId == msgId);
            return msgAndReplies;
        }
        public void SaveMessage( Message msg)
        {
            _context.Messages.Add(msg);
            _context.SaveChanges();
        }

        public void SaveTopic(Topic topic)
        {
             _context.Topics.Add(topic);
            _context.SaveChanges();
        }

        public void SaveReply(Reply reply)
        {
             _context.Replies.Add(reply);
            _context.SaveChanges();
        }

        

        



    }
}
