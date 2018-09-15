using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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
            return View(_eventMapper.FindAll().OrderBy(e => e.From).Select(e => new EventListViewModel(e)).AsEnumerable());
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
            var now = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, 0);
            return View(new EventDetailEditViewModel
            {
                From = now,
                To = now,
                StartOfRegistration = now,
                EndOfRegistration = now
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
        public IActionResult Delete(int? id)
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
    }
}
