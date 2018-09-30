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
using Trlifaj.Choirify.ViewModels.RehearsalViewModels;

namespace Trlifaj.Choirify.Controllers.Internal
{
    [Authorize]
    public class RehearsalsController : Controller
    {
        private readonly IRehearsalMapper _rehearsalMapper;

        public RehearsalsController(IRehearsalMapper rehearsalMapper)
        {
            _rehearsalMapper = rehearsalMapper;
        }

        // GET: Rehearsals
        public IActionResult Index()
        {
            return View(_rehearsalMapper.FindAll().OrderByDescending(r => r.Date).Select(r => new RehearsalListViewModel(r)));
        }

        // GET: Rehearsals/Admin
        [Authorize(Roles = Roles.Admins.RehearsalAdmins)]
        public IActionResult Admin()
        {
            return View(_rehearsalMapper.FindAll().OrderByDescending(r => r.Date).Select(r => new RehearsalListViewModel(r)));
        }

        // GET: Rehearsals/Choirmaster
        [Authorize(Roles = Roles.Choirmaster + "," + Roles.Admin)]
        public IActionResult Choirmaster()
        {
            return View("Index", _rehearsalMapper.FindAll().OrderByDescending(r => r.Date).Select(r => new RehearsalListViewModel(r)));
        }

        // GET: Rehearsals/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rehearsal = _rehearsalMapper.Find(id.Value);
            if (rehearsal == null)
            {
                return NotFound();
            }
            var model = new RehearsalDetailEditViewModel(rehearsal);
            return View(model);
        }

        // GET: Rehearsals/AdminDetails/5
        [Authorize(Roles = Roles.Admins.RehearsalAdmins)]
        public IActionResult AdminDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rehearsal = _rehearsalMapper.Find(id.Value);
            if (rehearsal == null)
            {
                return NotFound();
            }
            var model = new RehearsalDetailEditViewModel(rehearsal);
            return View(model);
        }

        // GET: Rehearsals/Create
        [Authorize(Roles = Roles.Admins.RehearsalAdmins)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rehearsals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Admins.RehearsalAdmins)]
        public IActionResult Create([Bind] RehearsalDetailEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var rehearsal = model.ToRehearsal();
                _rehearsalMapper.Create(rehearsal);
                return RedirectToAction(nameof(Admin));
            }
            return View(model);
        }

        // GET: Rehearsals/Edit/5
        [Authorize(Roles = Roles.Admins.RehearsalAdmins)]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rehearsal = _rehearsalMapper.Find(id.Value);
            if (rehearsal == null)
            {
                return NotFound();
            }
            var model = new RehearsalDetailEditViewModel(rehearsal);
            return View(model);
        }

        // POST: Rehearsals/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Admins.RehearsalAdmins)]
        public IActionResult Edit(int id, [Bind] RehearsalDetailEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var rehearsal = model.ToRehearsal();
                _rehearsalMapper.Update(rehearsal);
                return RedirectToAction(nameof(Admin));
            }
            return View(model);
        }

        // GET: Rehearsals/Delete/5
        [Authorize(Roles = Roles.Admins.RehearsalAdmins)]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rehearsal = _rehearsalMapper.Find(id.Value);
            if (rehearsal == null)
            {
                return NotFound();
            }
            var model = new RehearsalDetailEditViewModel(rehearsal);
            return View(model);
        }

        // POST: Rehearsals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Admins.RehearsalAdmins)]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var rehearsal = _rehearsalMapper.Find(id);
                _rehearsalMapper.Delete(rehearsal);
                return RedirectToAction(nameof(Admin));
            }
            catch
            {
                return View();
            }
        }

    }
}
