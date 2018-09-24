using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trlifaj.Choirify.Database.Interfaces;
using Trlifaj.Choirify.Models.Enums;
using Trlifaj.Choirify.Models.ManyToMany;
using Trlifaj.Choirify.Services;
using Trlifaj.Choirify.ViewModels.EventViewModels;

namespace Trlifaj.Choirify.Controllers.Internal
{
    [Authorize(Roles = Roles.Singer)]
    public class SingerActionsController : Controller
    {
        private ISingerMapper _singerMapper;
        private IEventRegistrationMapper _eventRegistrationMapper;
        private IEventMapper _eventMapper;
        private IUserMapper _userMapper;
        private ISongMapper _songMapper;
        private ISheetsInfoMapper _sheetsInfoMapper;

        public SingerActionsController(ISingerMapper singerMapper, IEventMapper eventMapper, IEventRegistrationMapper eventRegistrationMapper, IUserMapper userMapper, ISongMapper songMapper, ISheetsInfoMapper sheetsInfoMapper)
        {
            _singerMapper = singerMapper;
            _eventRegistrationMapper = eventRegistrationMapper;
            _eventMapper = eventMapper;
            _userMapper = userMapper;
            _songMapper = songMapper;
            _sheetsInfoMapper = sheetsInfoMapper;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EventRegistration(int singerId, int eventId, [Bind] EventRegistrationViewModel model)
        {
            if (model.RegistrationDeadline < DateTime.Now)
            {
                return RedirectToAction(nameof(RegistrationDeadline));
            }

            var user = _userMapper.FindBy(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null || user.SingerId != singerId)
            {
                return RedirectToAction("AccessDenied", "Account");
            }
            else
            {
                var newRegistration = model.ToEventRegistration();
                newRegistration.RegistrationDate = DateTime.Now;
                newRegistration.Answer = true;
                var oldRegistration = _eventRegistrationMapper.FindBy(er => er.SingerId == singerId && er.EventId == eventId).FirstOrDefault();
                if (oldRegistration == null)
                {
                    newRegistration.Id = null;
                    _eventRegistrationMapper.Create(newRegistration);
                }
                else
                {
                    oldRegistration.Answer = newRegistration.Answer;
                    oldRegistration.Comment = newRegistration.Comment;
                    oldRegistration.DressOrder = newRegistration.DressOrder;
                    oldRegistration.RegistrationDate = newRegistration.RegistrationDate;
                    _eventRegistrationMapper.Update(oldRegistration);
                }
                return RedirectToAction("Index", "Events");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EventUnregistration(int singerId, int eventId, [Bind] EventRegistrationViewModel model)
        {
            if (model.RegistrationDeadline < DateTime.Now)
            {
                return RedirectToAction(nameof(RegistrationDeadline));
            }

            var user = _userMapper.FindBy(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null || user.SingerId != singerId)
            {
                return RedirectToAction("AccessDenied", "Account");
            }
            else
            {
                var newRegistration = model.ToEventRegistration();
                newRegistration.RegistrationDate = DateTime.Now;
                newRegistration.Answer = false;
                var oldRegistration = _eventRegistrationMapper.FindBy(er => er.SingerId == singerId && er.EventId == eventId).FirstOrDefault();
                if (oldRegistration == null)
                {
                    _eventRegistrationMapper.Create(newRegistration);
                }
                else
                {
                    oldRegistration.Answer = newRegistration.Answer;
                    oldRegistration.Comment = newRegistration.Comment;
                    oldRegistration.DressOrder = null;
                    oldRegistration.RegistrationDate = newRegistration.RegistrationDate;
                    _eventRegistrationMapper.Update(oldRegistration);
                }
                return RedirectToAction("Index", "Events");
            }
        }

        [HttpGet]
        public IActionResult OrderSheets(int singerId, int songId, string filter = "current")
        {
            var user = _userMapper.FindBy(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null || user.SingerId != singerId)
            {
                return RedirectToAction("AccessDenied", "Account");
            }
            var song = _songMapper.Find(songId);
            if (song.Current == false)
            {
                return RedirectToAction(nameof(NotCurrentSong));
            }

            var oldInfo = _sheetsInfoMapper.FindBy(si => si.SingerId == singerId && si.SongId == songId).FirstOrDefault();
            if (oldInfo == null)
            {
                var order = new SingerSong
                {
                    SingerId = singerId,
                    SongId = songId,
                    Status = SheetInfoType.Ordered
                };
                _sheetsInfoMapper.Create(order);
            }
            else if (oldInfo.Status == SheetInfoType.NoCopy)
            {
                oldInfo.Status = SheetInfoType.Ordered;
                _sheetsInfoMapper.Update(oldInfo);
            }
            return RedirectToAction("Index", "Songs", new { filter = filter });
        }

        [HttpGet]
        public IActionResult SingerHasSheets(int singerId, int songId, string filter = "current")
        {
            var user = _userMapper.FindBy(u => u.UserName == User.Identity.Name).FirstOrDefault();
            if (user == null || user.SingerId != singerId)
            {
                return RedirectToAction("AccessDenied", "Account");
            }

            var oldInfo = _sheetsInfoMapper.FindBy(si => si.SingerId == singerId && si.SongId == songId).FirstOrDefault();
            if (oldInfo == null)
            {
                var info = new SingerSong
                {
                    SingerId = singerId,
                    SongId = songId,
                    Status = SheetInfoType.HasCopy
                };
                _sheetsInfoMapper.Create(info);
            }
            else if (oldInfo.Status == SheetInfoType.Ordered || oldInfo.Status == SheetInfoType.NoCopy)
            {
                oldInfo.Status = SheetInfoType.HasCopy;
                _sheetsInfoMapper.Update(oldInfo);
            }
            return RedirectToAction("Index", "Songs", new { filter = filter });
        }

        [Authorize]
        public IActionResult RegistrationDeadline()
        {
            return View();
        }

        [Authorize]
        public IActionResult NotCurrentSong()
        {
            return View();
        }
    }
}