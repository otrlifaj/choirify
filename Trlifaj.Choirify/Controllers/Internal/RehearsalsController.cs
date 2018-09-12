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
    [Authorize(Roles = Roles.Admin + "," + Roles.Chairman + "," + Roles.ViceChairman)]
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
            return View(_rehearsalMapper.FindAll().Select(r => new RehearsalListViewModel(r)));
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

        // GET: Rehearsals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rehearsals/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind] RehearsalDetailEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var rehearsal = model.ToRehearsal();
                _rehearsalMapper.Create(rehearsal);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Rehearsals/Edit/5
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
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: Rehearsals/Delete/5
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
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var rehearsal = _rehearsalMapper.Find(id);
                _rehearsalMapper.Delete(rehearsal);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

    }
}
