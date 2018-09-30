using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Trlifaj.Choirify.Database.Interfaces;
using Trlifaj.Choirify.Models;
using Trlifaj.Choirify.Services;
using Trlifaj.Choirify.ViewModels.SingerViewModels;

namespace Trlifaj.Choirify.Controllers.Internal
{
    [Authorize]
    public class SingersController : Controller
    {
        private readonly ISingerMapper _singerMapper;

        public SingersController(ISingerMapper singerMapper)
        {
            _singerMapper = singerMapper;
        }

        // GET: Singers
        public IActionResult Index()
        {
            return View(_singerMapper.FindAll().OrderBy(s => s.VoiceGroup).ThenBy(s => s.Surname).Select(s => new SingerListViewModel(s)));
        }

        // GET: Singers/Admin
        [Authorize(Roles = Roles.Admins.SingerAdmins)]
        public IActionResult Admin()
        {
            return View(_singerMapper.FindAll().OrderBy(s => s.VoiceGroup).ThenBy(s => s.Surname).Select(s => new SingerListViewModel(s)));
        }

        // GET: Singers/Chorimaster
        [Authorize(Roles = Roles.Choirmaster + "," + Roles.Admin)]
        public IActionResult Choirmaster()
        {
            return View("Index", _singerMapper.FindAll().OrderBy(s => s.VoiceGroup).ThenBy(s => s.Surname).Select(s => new SingerListViewModel(s)));
        }

        // GET: Singers/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singer = _singerMapper.Find(id.Value);
            if (singer == null)
            {
                return NotFound();
            }
            var model = new SingerDetailEditViewModel(singer);
            return View(model);
        }

        // GET: Singers/AdminDetails/5
        [Authorize(Roles = Roles.Admins.SingerAdmins)]
        public IActionResult AdminDetails(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singer = _singerMapper.Find(id.Value);
            if (singer == null)
            {
                return NotFound();
            }
            var model = new SingerDetailEditViewModel(singer);
            return View(model);
        }

        // GET: Singers/Create
        [Authorize(Roles = Roles.Admins.SingerAdmins)]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Singers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Admins.SingerAdmins)]
        public IActionResult Create([Bind] SingerDetailEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var singer = model.ToSinger();
                _singerMapper.Create(singer);
                return RedirectToAction(nameof(Admin));
            }
            return View(model);
        }

        // GET: Singers/Edit/5
        [Authorize(Roles = Roles.Admins.SingerAdmins)]
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singer = _singerMapper.Find(id.Value);

            if (singer == null)
            {
                return NotFound();
            }
            var model = new SingerDetailEditViewModel(singer);
            return View(model);
        }

        // POST: Singers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Admins.SingerAdmins)]
        public IActionResult Edit(int id, [Bind] SingerDetailEditViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var singer = model.ToSinger();
                _singerMapper.Update(singer);
                return RedirectToAction(nameof(Admin));
            }

            return View(model);
        }

        // GET: Singers/Delete/5
        [Authorize(Roles = Roles.Admins.SingerAdmins)]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var singer = _singerMapper.Find(id.Value);

            if (singer == null)
            {
                return NotFound();
            }
            var model = new SingerDetailEditViewModel(singer);
            return View(model);
        }

        // POST: Singers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = Roles.Admins.SingerAdmins)]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var singer = _singerMapper.Find(id);
                _singerMapper.Delete(singer);
                return RedirectToAction(nameof(Admin));
            }
            catch
            {
                return View();
            }
        }
    }
}
