using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Police_CaseHelper.Areas.Identity.Data;
using Police_CaseHelper.Core;
using Police_CaseHelper.Core.Repositories;
using Police_CaseHelper.Core.ViewModels;

namespace Police_CaseHelper.Controllers
{
    public class UserController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserController(IUnitOfWork unitOfWork, SignInManager<ApplicationUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _signInManager = signInManager;
        }


        #region Index Page
        [Authorize(Policy = Constants.Policies.RequireAdmin)]
        public IActionResult Index()
        {
            //Get the Users from the DB
            var users = _unitOfWork.User.GetUsers();

            //Return the View
            return View(users);
        }
        #endregion

        #region Edit Page
        [Authorize(Policy = Constants.Policies.RequireAdmin)]
        public async Task<IActionResult> Edit(string id)
        {
            //Get the Users from the DB
            var user = _unitOfWork.User.GetUser(id);

            //Get the Roles from the DB
            var roles = _unitOfWork.Role.GetRoles();

            //Get the User Roles
            var userRoles = await _signInManager.UserManager.GetRolesAsync(user);

            var roleItems = roles.Select(role =>
                new SelectListItem(
                    role.Name,
                    role.Id,
                    userRoles.Any(ur => ur.Contains(role.Name)))).ToList();

            //Create the EditUserViewModel - Edit User and Edit User Roles all in one page
            var vm = new EditUserViewModel
            {
                User = user,
                Roles = roleItems
            };

            //Return the View
            return View(vm);
        }
        #endregion

        #region On Post Async - Edit User View Model
        [HttpPost]
        public async Task<IActionResult> OnPostAsync(EditUserViewModel data)
        {
            //Get the User from the User ID
            var user = _unitOfWork.User.GetUser(data.User.Id);

            //If a user is not found do this
            if (user == null)
            {
                return NotFound();
            }

            //Get the current User Roles in the DB - This is what we will be comparing with to see if we need to add or remove any roles from the user
            var userRolesInDb = await _signInManager.UserManager.GetRolesAsync(user);

            //Create two new lists - rolesToAdd & rolesToDelete - this is what we will add the roles that either need to be added or removed from the Users Roles
            var rolesToAdd = new List<string>();
            var rolesToDelete = new List<string>();

            //Loop through the roles in ViewModel
            
            foreach (var role in data.Roles)
            {
                //Check if the Role is Assigned In DB
                var assignedInDb = userRolesInDb.FirstOrDefault(ur => ur == role.Text);

                //If Assigned -> Do Nothing
                //If Not Assigned -> Add Role
                if (role.Selected)
                {
                    if (assignedInDb == null)
                    {
                        rolesToAdd.Add(role.Text);
                    }
                }
                else
                {
                    if (assignedInDb != null)
                    {
                        rolesToDelete.Add(role.Text);
                    }
                }
            }

            //If there are any roles to add - add them
            if (rolesToAdd.Any())
            {
                await _signInManager.UserManager.AddToRolesAsync(user, rolesToAdd);
            }

            //If there are any roles to remove - remove them
            if (rolesToDelete.Any())
            {
                await _signInManager.UserManager.RemoveFromRolesAsync(user, rolesToDelete);
            }

            //Add the input data from the textboxes for the user and add them to "user"
            user.FirstName = data.User.FirstName;
            user.Surname = data.User.Surname;
            user.Email = data.User.Email;
            user.PhoneNumber = data.User.PhoneNumber;

            //Update User
            _unitOfWork.User.UpdateUser(user);

            //Return to the current page
            return RedirectToAction("Edit", new { id = user.Id });
        } 
        #endregion
    }
}
