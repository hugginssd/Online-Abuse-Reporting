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
    public class ComplainsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ComplainsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Complains
        public async Task<IActionResult> Index()
        {
            return View(await _context.Complain.ToListAsync());
        }

        // GET: Complains/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complain = await _context.Complain
                .SingleOrDefaultAsync(m => m.ID == id);
            if (complain == null)
            {
                return NotFound();
            }

            return View(complain);
        }

        // GET: Complains/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Complains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ReportDate,DateOfIncident,VictimName,Accused,PlaceOfIncident,AddressOfVictim,AddressOfAccussed")] Complain complain)
        {
            if (ModelState.IsValid)
            {
                _context.Add(complain);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(complain);
        }

        // GET: Complains/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complain = await _context.Complain.SingleOrDefaultAsync(m => m.ID == id);
            if (complain == null)
            {
                return NotFound();
            }
            return View(complain);
        }

        // POST: Complains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,ReportDate,DateOfIncident,VictimName,Accused,PlaceOfIncident,AddressOfVictim,AddressOfAccussed")] Complain complain)
        {
            if (id != complain.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(complain);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ComplainExists(complain.ID))
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
            return View(complain);
        }

        // GET: Complains/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var complain = await _context.Complain
                .SingleOrDefaultAsync(m => m.ID == id);
            if (complain == null)
            {
                return NotFound();
            }

            return View(complain);
        }

        // POST: Complains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var complain = await _context.Complain.SingleOrDefaultAsync(m => m.ID == id);
            _context.Complain.Remove(complain);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ComplainExists(int id)
        {
            return _context.Complain.Any(e => e.ID == id);
        }
    }
}
