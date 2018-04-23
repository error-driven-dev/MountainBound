using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MountainBound.Areas.Campfire.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MountainBound.Areas.Campfire.Controllers
{
    [Area("Campfire")]
    public class MessageController : Controller
    {
        private MessageRepository _repository;

        public MessageController(MessageRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            return View(_repository.GetTopics);
        }

        public IActionResult GetMessages(int id)
        {
            return View(_repository.GetTopicMessages(id));
        }



        //admin only
        public IActionResult CreateTopic() => View();
        [HttpPost]
        public IActionResult CreateTopic(Topic topic)
        {
            var newtopic = new Topic()
            {
                Heading = topic.Heading,
                Description = topic.Description
            };
            _repository.SaveTopic(newtopic);
            return RedirectToAction("Index");
        }

       
        public IActionResult CreateMessage(int id, string heading)
        {
            var msg = new MessageModel()
            {
                TopicId = id,
                TopicHeading = heading,
                };
            return View(msg);
        }
        [HttpPost]
        public IActionResult CreateMessage(MessageModel msg)
        {
            var newMsg = new Message()
            {
                Heading = msg.Heading,
                TopicId = msg.TopicId,
                Text = msg.Text,
                Username = msg.Username
            };
            _repository.SaveMessage(newMsg);
            return RedirectToAction("Index");
        }

        public IActionResult GetReplies(int id)
        {
            return View(new ReplyModel {Message= _repository.GetMessageAndReplies(id)});
        }



        [HttpPost]
        public IActionResult CreateReply(ReplyModel reply)
        {
            if (ModelState.IsValid)
            {
                var newReply = new Reply()
                {
                    MessageId = reply.MessageId,
                    Text = reply.Text,
                    Username = reply.Username
                };
                _repository.SaveReply(newReply);
                return RedirectToAction("GetReplies", new {id = reply.MessageId});
            }

            return View("GetReplies", reply);
        }
    }
}
