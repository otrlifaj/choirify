using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Trlifaj.Choirify.Database.Interfaces;
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

        public SingerActionsController(ISingerMapper singerMapper, IEventMapper eventMapper, IEventRegistrationMapper eventRegistrationMapper, IUserMapper userMapper)
        {
            _singerMapper = singerMapper;
            _eventRegistrationMapper = eventRegistrationMapper;
            _eventMapper = eventMapper;
            _userMapper = userMapper;
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
                    _eventRegistrationMapper.Update(oldRegistration);
                }
                return RedirectToAction("Index", "Events");
            }
        }
        [Authorize]
        public IActionResult RegistrationDeadline()
        {
            return View();
        }
    }
}