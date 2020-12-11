using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        static private List<Event> Events = new List<Event>();

        //Get: /events
        [HttpGet]
        [Route("/events")]
        public IActionResult Index()
        {
            ViewBag.events = Events;
            return View();
        }

        //Get: /events/add
        [HttpGet]
        [Route("/events/add")]
        public IActionResult Add()
        {
            return View();
        }

        //post: /events/add
        //handles the form submission
        [HttpPost]
        [Route("/events/add")]
        public IActionResult NewEvent(string name)
        {
            Events.Add(new Event(name));
            return Redirect("/Events");
        }
    }
}
