using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Police_CaseHelper.Areas.Identity.Data;
using Police_CaseHelper.Core;
using Police_CaseHelper.Data;
using Police_CaseHelper.Models;
using System.Diagnostics;

namespace Police_CaseHelper.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public HomeController(ApplicationDbContext context, SignInManager<ApplicationUser> signInManager)
        {
            _context = context;
            _signInManager = signInManager;
        }

        //Users with Administration and User Rights have access, if not logged in get sent to log in page. If someone without access tries to access, they will get access denied
        [Authorize(Roles = $"{Constants.Roles.Administrator},{Constants.Roles.User}")]
        public IActionResult Index()
        {
            //find the user that is currently logged in
            var user = DatabaseManager.GetUserName;

            //Only do this, if the user is logged in
            if (user != null) {
                // var user = _signInManager.UserManager.FindByIdAsync
                SqlParameter username = new("@username", user);
                DatabaseManager.GetUserCases = _context.UserCases.FromSqlRaw("EXEC [dbo].[spUserCases] @username", username).ToList();
            }
            
            //Return View
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}