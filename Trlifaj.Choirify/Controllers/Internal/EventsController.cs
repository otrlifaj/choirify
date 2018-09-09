using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Trlifaj.Choirify.Data;
using Trlifaj.Choirify.Database.Interfaces;
using Trlifaj.Choirify.Models;
using Trlifaj.Choirify.Services;
using Trlifaj.Choirify.ViewModels.EventViewModels;

namespace Trlifaj.Choirify.Controllers.Internal
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Chairman + "," + Roles.ViceChairman)]
    public class EventsController : Controller
    {
        private readonly IEventMapper _eventMapper;

        public EventsController(IEventMapper eventMapper)
        {
            _eventMapper = eventMapper;
        }

        // GET: Events
        public IActionResult Index()
        {
            return View(_eventMapper.FindAll().Select(e => ConvertToEventListViewModel(e)).AsEnumerable());
        }

        // GET: Events/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var @event = _eventMapper.Find(id.Value);
            if (@event == null)
            {
                return NotFound();
            }

            return View(new EventDetailEditViewModel(@event));
        }

        // GET: Events/Create
        public IActionResult Create()
        {
            return View(new EventDetailEditViewModel
            {
                From = DateTime.Now,
                To = DateTime.Now,
                StartOfRegistration = DateTime.Now,
                EndOfRegistration = DateTime.Now
            });
        }

        // POST: Events/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] EventDetailEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                _eventMapper.Create(model.ToEvent());
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Events/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            else
            {
                var @event = _eventMapper.Find(id.Value);
                if (@event == null)
                {
                    return NotFound();
                }
                return View(new EventDetailEditViewModel(@event));
            }
        }

        // POST: Events/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind] EventDetailEditViewModel model)
        {

            if (ModelState.IsValid)
            {
                _eventMapper.Update(model.ToEvent());
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Events/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var e = _eventMapper.Find(id.Value);
            var model = new EventDetailEditViewModel(e);
            return View(model);
        }

        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var e = _eventMapper.Find(id);
                _eventMapper.Delete(e);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private EventDetailEditViewModel ConvertToEventDetailEditViewModel(Event @event)
        {

            if (@event == null)
            {
                return new EventDetailEditViewModel();
            }
            EventDetailEditViewModel result = null;
            {
                result = new EventDetailEditViewModel
                {
                    Id = @event.Id,
                    Name = @event.Name,
                    Place = @event.Place,
                    Description = @event.Description,
                    From = @event.From,
                    To = @event.To,
                    StartOfRegistration = @event.StartOfRegistration,
                    EndOfRegistration = @event.EndOfRegistration,
                    EventType = @event.EventType,
                    Organizer = @event.Organizer
                };
                return result;
            }
        }

        private EventListViewModel ConvertToEventListViewModel(Event @event)
        {

            if (@event == null)
            {
                return new EventListViewModel();
            }
            EventListViewModel result = null;
            {
                result = new EventListViewModel
                {
                    Id = @event.Id,
                    Name = @event.Name,
                    Place = @event.Place,
                    From = @event.From,
                    To = @event.To,
                    StartOfRegistration = @event.StartOfRegistration,
                    EndOfRegistration = @event.EndOfRegistration,
                    EventType = @event.EventType,
                };
                return result;
            }
        }

    }
}
