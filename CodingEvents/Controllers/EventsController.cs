using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {
        static private Dictionary<string, string> Events = new Dictionary<string, string>();

        //Get: /events
        [HttpGet]
        [Route("/events")]
        public IActionResult Index()
        {
            //Events.Add("Women in Tech Kansas City Event");
            //Events.Add("GodSpeed! You Black Emperor Concert"); 
            //Events.Add("League of Legends Virtual");
            

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
        public IActionResult NewEvent(string name, string description)
        {
            Events.Add(name, description);

            return Redirect("/Events");
        }
    }
}
