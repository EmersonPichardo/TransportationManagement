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
    public class TransportationsRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransportationsRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TransportationRequests
        public async Task<IActionResult> Index()
        {
              return View(await _context.TransportationsRequests.ToListAsync());
        }

        // GET: TransportationRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransportationsRequests == null)
            {
                return NotFound();
            }

            var transportationRequest = await _context.TransportationsRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportationRequest == null)
            {
                return NotFound();
            }

            return View(transportationRequest);
        }

        // GET: TransportationRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TransportationRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Description,PickUpLocation,DeliveryLocation,PickUpDate,DeliverypDate,ContainerNumber,Status")] TransportationRequest transportationRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transportationRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(transportationRequest);
        }

        // GET: TransportationRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransportationsRequests == null)
            {
                return NotFound();
            }

            var transportationRequest = await _context.TransportationsRequests.FindAsync(id);
            if (transportationRequest == null)
            {
                return NotFound();
            }
            return View(transportationRequest);
        }

        // POST: TransportationRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Description,PickUpLocation,DeliveryLocation,PickUpDate,DeliverypDate,ContainerNumber,Status")] TransportationRequest transportationRequest)
        {
            if (id != transportationRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transportationRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportationRequestExists(transportationRequest.Id))
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
            return View(transportationRequest);
        }

        // GET: TransportationRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransportationsRequests == null)
            {
                return NotFound();
            }

            var transportationRequest = await _context.TransportationsRequests
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportationRequest == null)
            {
                return NotFound();
            }

            return View(transportationRequest);
        }

        // POST: TransportationRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransportationsRequests == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TransportationsRequests'  is null.");
            }
            var transportationRequest = await _context.TransportationsRequests.FindAsync(id);
            if (transportationRequest != null)
            {
                _context.TransportationsRequests.Remove(transportationRequest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportationRequestExists(int id)
        {
          return _context.TransportationsRequests.Any(e => e.Id == id);
        }
    }
}
