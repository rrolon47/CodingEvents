﻿using System;
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
        [Route("/Events")]
        public IActionResult Index()
        {
            ViewBag.events = EventData.GetAll();
            return View();
        }

        //Get: /events/add
        [HttpGet]
        [Route("/Events/Add")]
        public IActionResult Add()
        {
            return View();
        }

        //post: /events/add
        //handles the form submission
        [HttpPost]
        [Route("/Events/Add")]
        public IActionResult NewEvent(Event newEvent)
        {
            EventData.Add(newEvent);
            return Redirect("/Events");
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
        [Route("/Events/Edit/{eventId?}")]
        public IActionResult Edit(int eventId)
        {
            Event eventById = EventData.GetById(eventId);
            ViewBag.editEvent = eventById;
            ViewBag.title = $"Edit Event {eventById.Name}  (id={eventById.Id})";
            return View();
        }

        //post: events/edit
        [HttpPost]
        [Route("/Events/Edit")]
        public IActionResult SubmitEditEventForm(int eventId, string name, string description)
        {
            Event eventById = EventData.GetById(eventId);
            eventById.Name = name;
            eventById.Description = description;
            return Redirect("/Events");

        }
}
}
