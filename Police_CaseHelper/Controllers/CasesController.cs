using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Police_CaseHelper.Core;
using Police_CaseHelper.Data;
using Police_CaseHelper.Models;

namespace Police_CaseHelper.Controllers
{
    public class CasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CasesController(ApplicationDbContext context)
        {
            _context = context;
        }


        #region Index
        //Users with Administration Rights have access, if not logged in get sent to log in page. If someone without access tries to access, they will get access denied
        [Authorize(Policy = Constants.Policies.RequireAdmin)]
        public async Task<IActionResult> Index()
        {
            // Return the cases
            return _context.Cases != null ?
                        View(await _context.Cases.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Cases'  is null.");
        }
        #endregion

        #region Details
        // GET: Cases/Details/5
        //Users with Administration and User Rights have access, if not logged in get sent to log in page. If someone without access tries to access, they will get access denied
        [Authorize(Roles = $"{Constants.Roles.Administrator},{Constants.Roles.User}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Cases == null)
            {
                return NotFound();
            }

            var cases = await _context.Cases
                .FirstOrDefaultAsync(m => m.CaseID == id);
            if (cases == null)
            {
                return NotFound();
            }

            return View(cases);
        } 
        #endregion

        #region CasesExists
        //Checks if the case exists
        private bool CasesExists(int id)
        {
            return (_context.Cases?.Any(e => e.CaseID == id)).GetValueOrDefault();
        } 
        #endregion
    }
}
