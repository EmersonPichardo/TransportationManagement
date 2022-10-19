using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportationManagement.Web.Data;
using TransportationManagement.Web.Models;

namespace TransportationManagement.Web.Controllers
{
    public class InviocesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public InviocesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Invioces
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Invioces.Include(i => i.TransportationHeader);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Invioces/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Invioces == null)
            {
                return NotFound();
            }

            var invioce = await _context.Invioces
                .Include(i => i.TransportationHeader)
                .FirstOrDefaultAsync(m => m.Number == id);
            if (invioce == null)
            {
                return NotFound();
            }

            return View(invioce);
        }

        // GET: Invioces/Create
        public IActionResult Create()
        {
            ViewData["TransportationHeaderId"] = new SelectList(_context.TransportationsHeaders, "Id", "Id");
            return View();
        }

        // POST: Invioces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number,TransportationHeaderId,Ncf,GrossAmount,Taxes,Discount,NetAmount,Status")] Invioce invioce)
        {
            if (ModelState.IsValid)
            {
                _context.Add(invioce);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TransportationHeaderId"] = new SelectList(_context.TransportationsHeaders, "Id", "Id", invioce.TransportationHeaderId);
            return View(invioce);
        }

        // GET: Invioces/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Invioces == null)
            {
                return NotFound();
            }

            var invioce = await _context.Invioces.FindAsync(id);
            if (invioce == null)
            {
                return NotFound();
            }
            ViewData["TransportationHeaderId"] = new SelectList(_context.TransportationsHeaders, "Id", "Id", invioce.TransportationHeaderId);
            return View(invioce);
        }

        // POST: Invioces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Number,TransportationHeaderId,Ncf,GrossAmount,Taxes,Discount,NetAmount,Status")] Invioce invioce)
        {
            if (id != invioce.Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(invioce);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InvioceExists(invioce.Number))
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
            ViewData["TransportationHeaderId"] = new SelectList(_context.TransportationsHeaders, "Id", "Id", invioce.TransportationHeaderId);
            return View(invioce);
        }

        // GET: Invioces/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Invioces == null)
            {
                return NotFound();
            }

            var invioce = await _context.Invioces
                .Include(i => i.TransportationHeader)
                .FirstOrDefaultAsync(m => m.Number == id);
            if (invioce == null)
            {
                return NotFound();
            }

            return View(invioce);
        }

        // POST: Invioces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Invioces == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Invioces'  is null.");
            }
            var invioce = await _context.Invioces.FindAsync(id);
            if (invioce != null)
            {
                _context.Invioces.Remove(invioce);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InvioceExists(string id)
        {
          return _context.Invioces.Any(e => e.Number == id);
        }
    }
}
