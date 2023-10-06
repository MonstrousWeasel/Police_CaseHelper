using Microsoft.AspNetCore.Mvc;

namespace Police_CaseHelper.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
