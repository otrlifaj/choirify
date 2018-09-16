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
using Trlifaj.Choirify.ViewModels.SongViewModels;

namespace Trlifaj.Choirify.Controllers.Internal
{
    [Authorize]
    public class SongsController : Controller
    {
        private readonly ISongMapper _songMapper;

        public SongsController(ISongMapper songMapper)
        {
            _songMapper = songMapper;
        }

        // GET: Songs
        public IActionResult Index()
        {
            return View(_songMapper.FindAll().Select(s => new SongListViewModel(s)));
        }

        // GET: Songs/Admin
        [Authorize(Roles = Roles.Admins.SongAdmins)]
        public IActionResult Admin()
        {
            return View(_songMapper.FindAll().Select(s => new SongListViewModel(s)));
        }

        // GET: Songs/Choirmaster
        [Authorize(Roles = Roles.Choirmaster + "," + Roles.Admin)]
        public IActionResult Choirmaster()
        {
            return View("Index", _songMapper.FindAll().Select(s => new SongListViewModel(s)));
        }

        // GET: Songs/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = _songMapper.Find(id.Value);
            if (song == null)
            {
                return NotFound();
            }
            var model = new SongDetailEditViewModel(song);
            return View(model);
        }

        // GET: Songs/AdminDetails/5
        [Authorize(Roles = Roles.Admins.SongAdmins)]
        public IActionResult AdminDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = _songMapper.Find(id.Value);
            if (song == null)
            {
                return NotFound();
            }
            var model = new SongDetailEditViewModel(song);
            return View(model);
        }



        // GET: Songs/Create
        [Authorize(Roles = Roles.Admins.SongAdmins)]
        public IActionResult Create()
        {
            return View(new SongDetailEditViewModel());
        }

        // POST: Songs/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Admins.SongAdmins)]
        public IActionResult Create([Bind] SongDetailEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var song = model.ToSong();
                _songMapper.Create(song);
                return RedirectToAction(nameof(Admin));
            }
            return View(model);
        }

        // GET: Songs/Edit/5
        [Authorize(Roles = Roles.Admins.SongAdmins)]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = _songMapper.Find(id.Value);
            if (song == null)
            {
                return NotFound();
            }
            var model = new SongDetailEditViewModel(song);
            return View(model);
        }

        // POST: Songs/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Admins.SongAdmins)]
        public IActionResult Edit(int id, [Bind] SongDetailEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var song = model.ToSong();
                _songMapper.Update(song);
                return RedirectToAction(nameof(Admin));
            }
            return View(model);
        }

        // GET: Songs/Delete/5
        [Authorize(Roles = Roles.Admins.SongAdmins)]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var song = _songMapper.Find(id.Value);
            if (song == null)
            {
                return NotFound();
            }
            var model = new SongDetailEditViewModel(song);
            return View(model);
        }

        // POST: Songs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Admins.SongAdmins)]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var song = _songMapper.Find(id);
                _songMapper.Delete(song);
                return RedirectToAction(nameof(Admin));
            }
            catch
            {
                return View();
            }
        }

    }
}
