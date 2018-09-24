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
using Trlifaj.Choirify.Models.Enums;
using Trlifaj.Choirify.Services;
using Trlifaj.Choirify.ViewModels.SongViewModels;

namespace Trlifaj.Choirify.Controllers.Internal
{
    [Authorize]
    public class SongsController : Controller
    {
        private readonly ISongMapper _songMapper;
        private readonly ISingerMapper _singerMapper;
        private readonly IUserMapper _userMapper;
        private readonly ISheetsInfoMapper _sheetsInfoMapper;

        public SongsController(ISongMapper songMapper, ISingerMapper singerMapper, IUserMapper userMapper, ISheetsInfoMapper sheetsInfoMapper)
        {
            _songMapper = songMapper;
            _singerMapper = singerMapper;
            _userMapper = userMapper;
            _sheetsInfoMapper = sheetsInfoMapper;
        }

        // GET: Songs
        [Authorize(Roles = Roles.Singer)]
        public IActionResult Index(string filter = "current")
        {
            var user = _userMapper.FindBy(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null || user.SingerId == null)
                return RedirectToAction("AccessDenied", "Account");

            IQueryable<Song> songs = new List<Song>().AsQueryable();
            if (filter == "current")
            {
                songs = _songMapper.FindBy(s => s.Current == true).OrderBy(s => s.Name);
            }
            else if (filter == "all")
            {
                songs = _songMapper.FindAll().OrderByDescending(s => s.Current).ThenBy(s => s.Name);
            }

            var modelBase = new List<SingerSongListViewModel>();
            var sheetInfos = _sheetsInfoMapper.FindBy(si => si.SingerId == user.SingerId).ToList();
            foreach (var song in songs)
            {
                var info = sheetInfos.FirstOrDefault(si => si.SingerId == user.SingerId && si.SongId == song.Id);
                SheetInfoType? status = null;
                if (info != null)
                {
                    status = info.Status;
                }
                modelBase.Add(new SingerSongListViewModel(song, status, user.SingerId.Value));
            }

            ViewData["filter"] = filter;
            return View(modelBase);
        }

        // GET: Songs/Admin
        [Authorize(Roles = Roles.Admins.SongAdmins)]
        public IActionResult Admin(string filter = "current")
        {
            IQueryable<Song> songs = new List<Song>().AsQueryable();
            if (filter == "current")
            {
                songs = _songMapper.FindBy(s => s.Current == true).OrderBy(s => s.Name);
            }
            else if (filter == "all")
            {
                songs = _songMapper.FindAll().OrderByDescending(s => s.Current).ThenBy(s => s.Name);
            }

            var modelBase = new List<AdminSongListViewModel>();
            var orders = _sheetsInfoMapper.FindBy(si => si.Status == SheetInfoType.Ordered).ToList();
            foreach (var song in songs)
            {
                int ordersForSong = orders.Where(o => o.SongId == song.Id).Count();
                modelBase.Add(new AdminSongListViewModel(song, ordersForSong));
            }

            return View(modelBase);
        }

        // GET: Songs/Choirmaster
        [Authorize(Roles = Roles.Choirmaster + "," + Roles.Admin)]
        public IActionResult Choirmaster(string filter = "current")
        {
            IQueryable<Song> songs = new List<Song>().AsQueryable();
            if (filter == "current")
            {
                songs = _songMapper.FindBy(s => s.Current == true).OrderBy(s => s.Name);
            }
            else if (filter == "all")
            {
                songs = _songMapper.FindAll().OrderByDescending(s => s.Current).ThenBy(s => s.Name);
            }
            return View("Index", songs.Select(s => new SongListViewModel(s)));
        }

        // GET: Songs/Sheets/5
        [Authorize(Roles = Roles.Admins.SongAdmins)]
        public IActionResult Sheets(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var song = _songMapper.Find(id.Value);

            var activeSingers = _singerMapper.FindBy(s => s.IsActive);

            var songSheetsInfo = _sheetsInfoMapper.FindBy(si => si.SongId == song.Id);
            var hasCopyInfos = songSheetsInfo.Where(info => info.Status == SheetInfoType.HasCopy).Select(s => s.SingerId.Value).ToList();
            var orderedInfos = songSheetsInfo.Where(info => info.Status == SheetInfoType.Ordered).Select(s => s.SingerId.Value).ToList();

            var singersIdsWithoutSheetsInfo = activeSingers.Select(s => s.Id).ToList().Except(hasCopyInfos).Except(orderedInfos);

            var singersWhoHave = activeSingers.Where(s => hasCopyInfos.Contains(s.Id)).Select(s => new SingerInfoViewModel(s.Id, s.FirstName, s.Surname, s.VoiceGroup, SheetInfoType.HasCopy)).OrderBy(s => s.Voice).ThenBy(s => s.Surname).ToList();
            var singersWhoOrdered = activeSingers.Where(s => orderedInfos.Contains(s.Id)).Select(s => new SingerInfoViewModel(s.Id, s.FirstName, s.Surname, s.VoiceGroup, SheetInfoType.Ordered)).OrderBy(s => s.Voice).ThenBy(s => s.Surname).ToList();
            var singersWhoDontHave = activeSingers.Where(s => singersIdsWithoutSheetsInfo.Contains(s.Id)).Select(s => new SingerInfoViewModel(s.Id, s.FirstName, s.Surname, s.VoiceGroup, SheetInfoType.NoCopy)).OrderBy(s => s.Voice).ThenBy(s => s.Surname).ToList();

            return View(new SheetsStatusViewModel(song, singersWhoOrdered, singersWhoHave, singersWhoDontHave));
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admins.SongAdmins)]
        public IActionResult DistributeToSingers([Bind][FromForm] IEnumerable<SingerInfoViewModel> model, int songId, string returnUrl = null)
        {
            int distributed = 0;
            foreach (var singerInfo in model.Where(m => m.SelectedForAction))
            {
                var sheetsInfo = _sheetsInfoMapper.FindAll().FirstOrDefault(si => si.SongId == songId && si.SingerId == singerInfo.Id);
                if (sheetsInfo != null)
                {
                    sheetsInfo.Status = SheetInfoType.HasCopy;
                    _sheetsInfoMapper.Update(sheetsInfo);
                    distributed++;
                }
            }

            var song = _songMapper.Find(songId);
            song.SheetsAvailable -= distributed;
            _songMapper.Update(song);

            return Redirect(returnUrl);
        }

        [HttpPost]
        [Authorize(Roles = Roles.Admins.SongAdmins)]
        public IActionResult OrderForSingers([Bind][FromForm] IEnumerable<SingerInfoViewModel> model, int songId, string returnUrl = null)
        {
            foreach (var singerInfo in model.Where(m => m.SelectedForAction))
            {
                var sheetsInfo = _sheetsInfoMapper.FindAll().FirstOrDefault(si => si.SongId == songId && si.SingerId == singerInfo.Id);
                if (sheetsInfo != null)
                {
                    sheetsInfo.Status = SheetInfoType.Ordered;
                    _sheetsInfoMapper.Update(sheetsInfo);
                }
                else
                {
                    sheetsInfo = new Models.ManyToMany.SingerSong
                    {
                        SingerId = singerInfo.Id,
                        SongId = songId,
                        Status = SheetInfoType.Ordered
                    };
                    _sheetsInfoMapper.Create(sheetsInfo);
                }
            }
            return Redirect(returnUrl);
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
