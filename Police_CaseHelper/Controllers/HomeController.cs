using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Police_CaseHelper.Areas.Identity.Data;
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

        public IActionResult Index()
        {
            //find the user
            var user = DatabaseManager.GetUserName;

            if (user != null) {
                // var user = _signInManager.UserManager.FindByIdAsync
                //var user = "leroy.gibbs";
                SqlParameter username = new("@username", user);
                DatabaseManager.GetUserCases = _context.UserCases.FromSqlRaw("EXEC [dbo].[spUserCases] @username", username).ToList();
            }
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}