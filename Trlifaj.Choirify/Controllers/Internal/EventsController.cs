using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using Trlifaj.Choirify.Database.Interfaces;
using Trlifaj.Choirify.Models;
using Trlifaj.Choirify.Models.Enums;
using Trlifaj.Choirify.Models.ManyToMany;
using Trlifaj.Choirify.Services;
using Trlifaj.Choirify.ViewModels.EventViewModels;

namespace Trlifaj.Choirify.Controllers.Internal
{
    [Authorize]
    public class EventsController : Controller
    {
        private readonly IEventMapper _eventMapper;
        private readonly IEventRegistrationMapper _eventRegistrationMapper;
        private readonly IUserMapper _userMapper;
        private readonly ISingerMapper _singerMapper;
        private readonly IHostingEnvironment _hostingEnvironment;

        public EventsController(IEventMapper eventMapper, IEventRegistrationMapper eventRegistrationMapper, IUserMapper userMapper, ISingerMapper singerMapper, IHostingEnvironment environment)
        {
            _eventMapper = eventMapper;
            _eventRegistrationMapper = eventRegistrationMapper;
            _userMapper = userMapper;
            _singerMapper = singerMapper;
            _hostingEnvironment = environment;
        }

        // GET: Events
        [Authorize(Roles = Roles.Singer)]
        public IActionResult Index(string filter = "upcoming")
        {
            IEnumerable<EventRegistration> singerRegistrations = new List<EventRegistration>();
            VoiceGroup? voice = VoiceGroup.S1;
            int? singerId = 0;

            var user = _userMapper.FindBy(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user != null && user.SingerId != null)
            {
                singerRegistrations = _eventRegistrationMapper.FindBy(er => er.SingerId == user.SingerId).ToList();
                voice = _singerMapper.Find(user.SingerId.Value).VoiceGroup;
                singerId = user.SingerId;
            }
            IQueryable<Event> events = new List<Event>().AsQueryable();
            if (filter == "upcoming")
            {
                events = _eventMapper.FindBy(e => e.To >= DateTime.Now).OrderBy(e => e.From);
            }
            else if (filter == "all")
            {
                events = _eventMapper.FindAll().OrderByDescending(e => e.From);
            }

            var eventIds = events.Select(e => e.Id).ToList();
            var activeSingers = _singerMapper.FindBy(s => s.IsActive == true).Count();
            var allEventRegistrations = _eventRegistrationMapper.FindBy(er => eventIds.Contains(er.EventId.Value)).ToList();

            var model = events.ToList().Select(e =>
            {
                var answeredYes = allEventRegistrations.Where(er => er.EventId.Value == e.Id && er.Answer == true).Count();
                var answeredNo = allEventRegistrations.Where(er => er.EventId.Value == e.Id && er.Answer == false).Count();
                var registrationInfo = singerRegistrations.FirstOrDefault(r => r.EventId == e.Id);
                if (registrationInfo == null)
                {
                    return new SingerEventListViewModel(e, new EventRegistrationViewModel(voice, e.Id, singerId, e.EndOfRegistration), activeSingers, answeredYes, answeredNo);
                }
                else
                {
                    return new SingerEventListViewModel(e, new EventRegistrationViewModel(registrationInfo, voice, e.EndOfRegistration), activeSingers, answeredYes, answeredNo);
                }

            }).OrderBy(ri => ri.From).AsEnumerable();

            return View(model);
        }

        // GET: Events/Admin
        [Authorize(Roles = Roles.Admins.EventAdmins)]
        public IActionResult Admin(string filter = "upcoming")
        {
            IQueryable<Event> events = new List<Event>().AsQueryable();
            if (filter == "upcoming")
            {
                events = _eventMapper.FindBy(e => e.To >= DateTime.Now).OrderBy(e => e.From);
            }
            else if (filter == "all")
            {
                events = _eventMapper.FindAll().OrderByDescending(e => e.From);
            }

            var eventIds = events.Select(e => e.Id).ToList();
            var activeSingers = _singerMapper.FindBy(s => s.IsActive == true).Count();
            var allEventRegistrations = _eventRegistrationMapper.FindBy(er => eventIds.Contains(er.EventId.Value)).ToList();

            var model = new List<AdminEventListViewModel>();
            foreach (var e in events)
            {
                var answeredYes = allEventRegistrations.Where(er => er.EventId.Value == e.Id && er.Answer == true).Count();
                var answeredNo = allEventRegistrations.Where(er => er.EventId.Value == e.Id && er.Answer == false).Count();
                var modelItem = new AdminEventListViewModel(e, activeSingers, answeredYes, answeredNo);
                model.Add(modelItem);

            }
            return View(model);
        }

        //GET: Events/Choirmaster
        [Authorize(Roles = Roles.Choirmaster + "," + Roles.Admin)]
        public IActionResult Choirmaster(string filter = "upcoming")
        {
            IQueryable<Event> events = new List<Event>().AsQueryable();
            if (filter == "upcoming")
            {
                events = _eventMapper.FindBy(e => e.To >= DateTime.Now).OrderBy(e => e.From);
            }
            else if (filter == "all")
            {
                events = _eventMapper.FindAll().OrderByDescending(e => e.From);
            }

            return View(events.Select(e => new SingerEventListViewModel(e)).AsEnumerable());
        }

        //GET: Events/Dress
        [Authorize(Roles = Roles.Admins.EventAdmins + "," + Roles.DresscodeLeader)]
        public IActionResult Dress(string filter = "upcoming")
        {
            IQueryable<Event> events = new List<Event>().AsQueryable();
            if (filter == "upcoming")
            {
                events = _eventMapper.FindBy(e => e.To >= DateTime.Now).OrderBy(e => e.From);
            }
            else if (filter == "all")
            {
                events = _eventMapper.FindAll().OrderByDescending(e => e.From);
            }

            return View(events.Select(e => new DressCodeEventListViewModel(e)).AsEnumerable());
        }

        [Authorize(Roles = Roles.Admins.EventAdmins + "," + Roles.DresscodeLeader)]
        public IActionResult DressDetails(int eventId)
        {
            return View();
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

        // GET: Events/AdminDetails/5
        [Authorize(Roles = Roles.Admins.EventAdmins)]
        public IActionResult AdminDetails(int? id)
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

            var registrations = _eventRegistrationMapper.FindBy(er => er.EventId == id.Value).ToList();
            var singers = _singerMapper.FindBy(s => s.IsActive == true).Select(s => new { s.Id, s.FirstName, s.Surname, s.VoiceGroup }).ToList();
            var singersWhoDidntAnswer = singers.Where(s => !registrations.Select(r => r.SingerId.Value).Contains(s.Id));
            var modelRegistrations = new List<AdminEventDetailSingerRegistrationViewModel>();
            foreach (var er in registrations)
            {
                var singer = singers.FirstOrDefault(s => s.Id == er.SingerId.Value);
                if (singer == null)
                    continue;
                var registrationModel = new AdminEventDetailSingerRegistrationViewModel(singer.Id, er.Id, @event.Id, singer.FirstName, singer.Surname, singer.VoiceGroup.Value, er.RegistrationDate, er.Answer, er.Comment);
                modelRegistrations.Add(registrationModel);
            }

            var modelSingersWithoutAnswer = new List<AdminEventDetailSingerRegistrationViewModel>();
            foreach (var singer in singersWhoDidntAnswer)
            {
                var notAnsweredModel = new AdminEventDetailSingerRegistrationViewModel(singer.Id, null, @event.Id, singer.FirstName, singer.Surname, singer.VoiceGroup.Value, null, null, null);
                modelSingersWithoutAnswer.Add(notAnsweredModel);
            }

            return View(new AdminEventDetailViewModel(@event, modelRegistrations, modelSingersWithoutAnswer));
        }

        // POST: Events/ExportRegistrationsToExcel
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Admins.EventAdmins)]
        public IActionResult ExportRegistrationsToExcel(int id, [Bind]ExcelExportParams exportParams)
        {
            var singers = _singerMapper.FindBy(s => s.IsActive).ToList();
            var eventRegistrations = _eventRegistrationMapper.FindBy(er => er.EventId == id).ToList();
            var @event = _eventMapper.Find(id);
            var excelWorkbook = ExcelExporter.ExportRegistrations(singers, eventRegistrations, @event, exportParams.Registered, exportParams.Unregistered, exportParams.WithoutRegistration);

            var memory = new MemoryStream();
            var fileName = $"Registrace-{DateTime.Now.ToString("d-M-yyyy-H-mm")}.xlsx";
            var filePath = Path.Combine(_hostingEnvironment.WebRootPath, fileName);
            using (var fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            {
                excelWorkbook.Write(fs);
            }

            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                stream.CopyTo(memory);
            }
            memory.Position = 0;

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            return File(memory, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", fileName);
        }

        [Authorize(Roles = Roles.Admins.EventAdmins)]
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
        [Authorize(Roles = Roles.Admins.EventAdmins)]
        public IActionResult Create([Bind] EventDetailEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                _eventMapper.Create(model.ToEvent());
                return RedirectToAction(nameof(Admin));
            }
            return View(model);
        }

        // GET: Events/Edit/5
        [Authorize(Roles = Roles.Admins.EventAdmins)]
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
        [Authorize(Roles = Roles.Admins.EventAdmins)]
        public IActionResult Edit(int id, [Bind] EventDetailEditViewModel model)
        {

            if (ModelState.IsValid)
            {
                _eventMapper.Update(model.ToEvent());
                return RedirectToAction(nameof(Admin));
            }
            return View(model);
        }

        // GET: Events/Delete/5
        [Authorize(Roles = Roles.Admins.EventAdmins)]
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
        [Authorize(Roles = Roles.Admins.EventAdmins)]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var e = _eventMapper.Find(id);
                _eventMapper.Delete(e);
                return RedirectToAction(nameof(Admin));
            }
            catch
            {
                return View();
            }
        }
    }
}
