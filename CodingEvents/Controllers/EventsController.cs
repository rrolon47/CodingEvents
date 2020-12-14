using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodingEvents.Data;
using CodingEvents.Models;
using CodingEvents.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CodingEvents.Controllers
{
    public class EventsController : Controller
    {

        //Get: /events
        [HttpGet]
        [Route("/Events")]
        public IActionResult Index()
        {
            List<Event> events = new List<Event>(EventData.GetAll());
            return View(events);
        }

        //Get: /events/add
        [HttpGet]
        [Route("/Events/Add")]
        public IActionResult Add()
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();

            return View(addEventViewModel);
        }

        //post: /events/add
        //handles the form submission
        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult Add(AddEventViewModel addEventViewModel)
        {
            if (ModelState.IsValid) 
            {  
                Event newEvent = new Event
                {
                    Name= addEventViewModel.Name,
                    Description= addEventViewModel.Description,
                    ContactEmail= addEventViewModel.ContactEmail
                };
                EventData.Add(newEvent);

                return Redirect("/Events");
            }

            return View(addEventViewModel);
           
        }

        //get: events/delete
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

        //get: events/edit/eventId
        [HttpGet]
        [Route("/Events/Edit/{eventId}")]
        public IActionResult Edit(int eventId)
        {
            AddEventViewModel addEventViewModel = new AddEventViewModel();
            Event eventById = EventData.GetById(eventId);
            ViewBag.editEvent = eventById;
            ViewBag.title = $"Edit Event {eventById.Name}  (id={eventById.Id})";
            return View(addEventViewModel);
        }

        //post: events/edit
        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, AddEventViewModel addEventViewModel)
        {
            Event eventById = EventData.GetById(eventId);
            eventById.Name = addEventViewModel.Name;
            eventById.Description = addEventViewModel.Description;
            eventById.ContactEmail = addEventViewModel.ContactEmail;
            return Redirect("/Events");

        }
}
}
