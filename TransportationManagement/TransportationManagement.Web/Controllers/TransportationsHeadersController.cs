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
    public class TransportationsHeadersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransportationsHeadersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TransportationHeaders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TransportationsHeaders.Include(t => t.Client).Include(t => t.TransportationRequest);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TransportationHeaders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransportationsHeaders == null)
            {
                return NotFound();
            }

            var transportationHeader = await _context.TransportationsHeaders
                .Include(t => t.Client)
                .Include(t => t.TransportationRequest)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportationHeader == null)
            {
                return NotFound();
            }

            return View(transportationHeader);
        }

        // GET: TransportationHeaders/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
            ViewData["TransportationRequestId"] = new SelectList(_context.TransportationsRequests, "Id", "Id");
            return View();
        }

        // POST: TransportationHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,CreationDate,TotalAmount,TransportationRequestId,Status")] TransportationHeader transportationHeader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transportationHeader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", transportationHeader.ClientId);
            ViewData["TransportationRequestId"] = new SelectList(_context.TransportationsRequests, "Id", "Id", transportationHeader.TransportationRequestId);
            return View(transportationHeader);
        }

        // GET: TransportationHeaders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransportationsHeaders == null)
            {
                return NotFound();
            }

            var transportationHeader = await _context.TransportationsHeaders.FindAsync(id);
            if (transportationHeader == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", transportationHeader.ClientId);
            ViewData["TransportationRequestId"] = new SelectList(_context.TransportationsRequests, "Id", "Id", transportationHeader.TransportationRequestId);
            return View(transportationHeader);
        }

        // POST: TransportationHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,CreationDate,TotalAmount,TransportationRequestId,Status")] TransportationHeader transportationHeader)
        {
            if (id != transportationHeader.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transportationHeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportationHeaderExists(transportationHeader.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", transportationHeader.ClientId);
            ViewData["TransportationRequestId"] = new SelectList(_context.TransportationsRequests, "Id", "Id", transportationHeader.TransportationRequestId);
            return View(transportationHeader);
        }

        // GET: TransportationHeaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransportationsHeaders == null)
            {
                return NotFound();
            }

            var transportationHeader = await _context.TransportationsHeaders
                .Include(t => t.Client)
                .Include(t => t.TransportationRequest)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportationHeader == null)
            {
                return NotFound();
            }

            return View(transportationHeader);
        }

        // POST: TransportationHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransportationsHeaders == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TransportationsHeaders'  is null.");
            }
            var transportationHeader = await _context.TransportationsHeaders.FindAsync(id);
            if (transportationHeader != null)
            {
                _context.TransportationsHeaders.Remove(transportationHeader);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportationHeaderExists(int id)
        {
          return _context.TransportationsHeaders.Any(e => e.Id == id);
        }
    }
}
