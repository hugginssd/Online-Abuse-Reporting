using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Abuse.Data;
using Abuse.Models;

namespace Abuse.Controllers
{
    public class DocketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DocketsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Dockets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Docket.ToListAsync());
        }

        // GET: Dockets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docket = await _context.Docket
                .SingleOrDefaultAsync(m => m.ID == id);
            if (docket == null)
            {
                return NotFound();
            }

            return View(docket);
        }

        // GET: Dockets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Dockets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,CreateDate,Accussed,AccussedDescription,Offense,DateOfOffense,Victim,AddressOfOffender,OfficerOnCase,InvestigativeOfficer")] Docket docket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(docket);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(docket);
        }

        // GET: Dockets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docket = await _context.Docket.SingleOrDefaultAsync(m => m.ID == id);
            if (docket == null)
            {
                return NotFound();
            }
            return View(docket);
        }

        // POST: Dockets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,CreateDate,Accussed,AccussedDescription,Offense,DateOfOffense,Victim,AddressOfOffender,OfficerOnCase,InvestigativeOfficer")] Docket docket)
        {
            if (id != docket.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(docket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DocketExists(docket.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(docket);
        }

        // GET: Dockets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var docket = await _context.Docket
                .SingleOrDefaultAsync(m => m.ID == id);
            if (docket == null)
            {
                return NotFound();
            }

            return View(docket);
        }

        // POST: Dockets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var docket = await _context.Docket.SingleOrDefaultAsync(m => m.ID == id);
            _context.Docket.Remove(docket);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool DocketExists(int id)
        {
            return _context.Docket.Any(e => e.ID == id);
        }
    }
}
