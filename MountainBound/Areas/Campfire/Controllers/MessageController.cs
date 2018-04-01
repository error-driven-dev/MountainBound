using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
                Heading = topic.Heading
            };
            _repository.SaveTopic(newtopic);
            return RedirectToAction("Index");
        }

        public IActionResult CreateMessage() => View();
        [HttpPost]
        public IActionResult CreateMessage(Message msg)
        {
            _repository.SaveMessage(msg);
            return RedirectToAction("Index");
        }

        public IActionResult CreateReply() => View();

        [HttpPost]
        public IActionResult CreateReply(Reply reply)
        {
            _repository.SaveReply(reply);
            return RedirectToAction("Index");
        }
    }
}
