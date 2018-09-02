using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Trlifaj.Choirify.Database.Interfaces;
using Trlifaj.Choirify.Models;
using Trlifaj.Choirify.Services;
using Trlifaj.Choirify.ViewModels.UserViewModels;

namespace Trlifaj.Choirify.Controllers.Internal
{
    [Authorize(Roles = Roles.Admin + "," + Roles.Chairman + "," + Roles.ViceChairman)]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserMapper _userMapper;
        private readonly ISingerMapper _singerMapper;

        public UserController(
            UserManager<ApplicationUser> userManager,
            IUserMapper userMapper,
            ISingerMapper singerMapper)
        {
            _userManager = userManager;
            _userMapper = userMapper;
            _singerMapper = singerMapper;
        }



        // GET: User
        public ActionResult Index()
        {
            var users = _userMapper.FindAll(); // loads Singer property too
            var model = users.Select(u => ConvertToUserListViewModel(u)).AsEnumerable();
            return View(model);
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(string id)
        {
            var user = _userMapper.Find(id); // loads Singer property too
            var model = ConvertToUserDetailEditViewModel(user);
            var roles = await _userManager.GetRolesAsync(user);
            model.SelectedRoles = roles.ToList();
            return View(model);
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(string id)
        {
            var user = _userMapper.Find(id); // loads Singer property too
            var model = ConvertToUserDetailEditViewModel(user);
            var roles = await _userManager.GetRolesAsync(user);
            model.SelectedRoles = roles.ToList();
            return View(model);
        }

        // POST: User/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(string id, [Bind] UserDetailEditViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _userMapper.Find(id); // loads Singer property too
                var updatedUser = MergeUserWithEditModel(user, model);

                var updateUserResult = await _userManager.UpdateAsync(updatedUser);
                if (!updateUserResult.Succeeded)
                {
                    AddErrors(updateUserResult);
                    return View(model);
                }
                var currentRoles = await _userManager.GetRolesAsync(updatedUser);
                var newRoles = model.SelectedRoles;

                IEnumerable<string> rolesToBeRemoved = currentRoles.Except(newRoles);
                IEnumerable<string> rolesToBeAdded = newRoles.Except(currentRoles);

                var removeRolesResult = await _userManager.RemoveFromRolesAsync(updatedUser, rolesToBeRemoved);
                var addRolesResult = await _userManager.AddToRolesAsync(updatedUser, rolesToBeAdded);
                if (!(removeRolesResult.Succeeded && addRolesResult.Succeeded))
                {
                    AddErrors(removeRolesResult);
                    AddErrors(addRolesResult);
                    return View(model);
                }
                return RedirectToAction(nameof(Index));
            };

            return View(model);
        }

        // GET: User/Delete/5
        public ActionResult Delete(string id)
        {
            var user = _userMapper.Find(id); // loads Singer property too
            var model = ConvertToUserDetailEditViewModel(user);
            return View(model);
        }

        // POST: User/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var user = _userMapper.Find(id); // loads Singer property too
                _userMapper.Delete(user);
                _singerMapper.Delete(user.Singer);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private UserListViewModel ConvertToUserListViewModel(ApplicationUser user)
        {
            var result = new UserListViewModel
            {
                UserId = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                CanLogin = user.CanLogin,
                LastLogin = user.LastLogin,

                SingerId = user.Singer.Id,
                FirstName = user.Singer.FirstName,
                Surname = user.Singer.Surname,
                VoiceGroup = user.Singer.VoiceGroup
            };
            return result;
        }

        private UserDetailEditViewModel ConvertToUserDetailEditViewModel(ApplicationUser user)
        {
            var result = new UserDetailEditViewModel
            {
                UserId = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                CanLogin = user.CanLogin,
                LastLogin = user.LastLogin,
                CreatedOn = user.CreatedOn,

                SingerId = user.Singer.Id,
                Address = user.Singer.Address,
                FirstName = user.Singer.FirstName,
                Surname = user.Singer.Surname,
                VoiceGroup = user.Singer.VoiceGroup,
                DateOfBirth = user.Singer.DateOfBirth,
                ImageUrl = user.Singer.ImageUrl,
                IsActive = user.Singer.IsActive,
                NumberOfIDCard = user.Singer.NumberOfIDCard,
                PassportNumber = user.Singer.PassportNumber
            };
            return result;
        }

        private ApplicationUser MergeUserWithEditModel(ApplicationUser user, UserDetailEditViewModel model)
        {
            user.CanLogin = model.CanLogin;

            if (user.Singer != null)
            {
                user.Singer.Address = model.Address;
                user.Singer.FirstName = model.FirstName;
                user.Singer.Surname = model.Surname;
                user.Singer.VoiceGroup = model.VoiceGroup;
                user.Singer.DateOfBirth = model.DateOfBirth;
                user.Singer.ImageUrl = model.ImageUrl;
                user.Singer.IsActive = model.IsActive;
                user.Singer.NumberOfIDCard = model.NumberOfIDCard;
                user.Singer.PassportNumber = model.PassportNumber;
                user.Singer.Email = model.Email;
                user.Singer.PhoneNumber = model.PhoneNumber;
            }

            return user;
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}