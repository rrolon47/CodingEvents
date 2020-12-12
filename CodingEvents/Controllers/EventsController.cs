using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {

        //Get: /events
        [HttpGet]
        [Route("/events")]
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();
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
        public IActionResult NewEvent(string name, string description )
        {
            EventData.Add(new Event(name, description));
            return Redirect("/Events");
        }

        //get: /delete
        [HttpGet]
        public IActionResult Delete()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] eventIds)
        {
            foreach(int eventId in eventIds)
            {
                EventData.Remove(eventId);
            }

            return Redirect("/Events");
        }
    }
}
