﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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

        // GET: Cases
        public async Task<IActionResult> Index()
        {
              return _context.Cases != null ? 
                          View(await _context.Cases.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Cases'  is null.");
        }

        // GET: Cases/Details/5
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

        // GET: Cases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CaseID,VictimName,OffenderName,Charges,OffenderPlea,OffenderInCustody,OffenderReleaseDate,CourtDates,CourtLocation,Details,Bail,BailConditions,BailBreached,RequiredToBeArrested,WantedToArrest,OfficerInChargeName,OfficerInChargeEmail,OfficerInChargePhone,VictimUserName")] Cases cases)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cases);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cases);
        }

        // GET: Cases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Cases == null)
            {
                return NotFound();
            }

            var cases = await _context.Cases.FindAsync(id);
            if (cases == null)
            {
                return NotFound();
            }
            return View(cases);
        }

        // POST: Cases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CaseID,VictimName,OffenderName,Charges,OffenderPlea,OffenderInCustody,OffenderReleaseDate,CourtDates,CourtLocation,Details,Bail,BailConditions,BailBreached,RequiredToBeArrested,WantedToArrest,OfficerInChargeName,OfficerInChargeEmail,OfficerInChargePhone,VictimUserName")] Cases cases)
        {
            if (id != cases.CaseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cases);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasesExists(cases.CaseID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(cases);
        }

        private bool CasesExists(int id)
        {
          return (_context.Cases?.Any(e => e.CaseID == id)).GetValueOrDefault();
        }
    }
}