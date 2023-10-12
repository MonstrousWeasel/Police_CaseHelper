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
        

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var user = "leroy.gibbs";
            SqlParameter username = new("@username", user);
            DatabaseManager.GetUserCases = _context.UserCases.FromSqlRaw("EXEC [dbo].[spUserCases] @username", username).ToList();
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