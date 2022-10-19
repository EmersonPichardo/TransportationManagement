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
    public class TransportationsDetailsVehiclesExtensionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransportationsDetailsVehiclesExtensionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TransportationDetailVehicleExtensions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TransportationsDetailsVehiclesExtensions.Include(t => t.TransportationDetail).Include(t => t.VehicleExtensionDescriptionNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TransportationDetailVehicleExtensions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransportationsDetailsVehiclesExtensions == null)
            {
                return NotFound();
            }

            var transportationDetailVehicleExtension = await _context.TransportationsDetailsVehiclesExtensions
                .Include(t => t.TransportationDetail)
                .Include(t => t.VehicleExtensionDescriptionNavigation)
                .FirstOrDefaultAsync(m => m.TransportationDetailId == id);
            if (transportationDetailVehicleExtension == null)
            {
                return NotFound();
            }

            return View(transportationDetailVehicleExtension);
        }

        // GET: TransportationDetailVehicleExtensions/Create
        public IActionResult Create()
        {
            ViewData["TransportationDetailId"] = new SelectList(_context.TransportationsDetails, "Id", "Id");
            ViewData["VehicleExtensionDescription"] = new SelectList(_context.VehiclesExtensions, "Description", "Description");
            return View();
        }

        // POST: TransportationDetailVehicleExtensions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransportationDetailId,VehicleExtensionDescription,Status")] TransportationDetailVehicleExtension transportationDetailVehicleExtension)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transportationDetailVehicleExtension);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TransportationDetailId"] = new SelectList(_context.TransportationsDetails, "Id", "Id", transportationDetailVehicleExtension.TransportationDetailId);
            ViewData["VehicleExtensionDescription"] = new SelectList(_context.VehiclesExtensions, "Description", "Description", transportationDetailVehicleExtension.VehicleExtensionDescription);
            return View(transportationDetailVehicleExtension);
        }

        // GET: TransportationDetailVehicleExtensions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransportationsDetailsVehiclesExtensions == null)
            {
                return NotFound();
            }

            var transportationDetailVehicleExtension = await _context.TransportationsDetailsVehiclesExtensions.FindAsync(id);
            if (transportationDetailVehicleExtension == null)
            {
                return NotFound();
            }
            ViewData["TransportationDetailId"] = new SelectList(_context.TransportationsDetails, "Id", "Id", transportationDetailVehicleExtension.TransportationDetailId);
            ViewData["VehicleExtensionDescription"] = new SelectList(_context.VehiclesExtensions, "Description", "Description", transportationDetailVehicleExtension.VehicleExtensionDescription);
            return View(transportationDetailVehicleExtension);
        }

        // POST: TransportationDetailVehicleExtensions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransportationDetailId,VehicleExtensionDescription,Status")] TransportationDetailVehicleExtension transportationDetailVehicleExtension)
        {
            if (id != transportationDetailVehicleExtension.TransportationDetailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transportationDetailVehicleExtension);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportationDetailVehicleExtensionExists(transportationDetailVehicleExtension.TransportationDetailId))
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
            ViewData["TransportationDetailId"] = new SelectList(_context.TransportationsDetails, "Id", "Id", transportationDetailVehicleExtension.TransportationDetailId);
            ViewData["VehicleExtensionDescription"] = new SelectList(_context.VehiclesExtensions, "Description", "Description", transportationDetailVehicleExtension.VehicleExtensionDescription);
            return View(transportationDetailVehicleExtension);
        }

        // GET: TransportationDetailVehicleExtensions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransportationsDetailsVehiclesExtensions == null)
            {
                return NotFound();
            }

            var transportationDetailVehicleExtension = await _context.TransportationsDetailsVehiclesExtensions
                .Include(t => t.TransportationDetail)
                .Include(t => t.VehicleExtensionDescriptionNavigation)
                .FirstOrDefaultAsync(m => m.TransportationDetailId == id);
            if (transportationDetailVehicleExtension == null)
            {
                return NotFound();
            }

            return View(transportationDetailVehicleExtension);
        }

        // POST: TransportationDetailVehicleExtensions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransportationsDetailsVehiclesExtensions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TransportationsDetailsVehiclesExtensions'  is null.");
            }
            var transportationDetailVehicleExtension = await _context.TransportationsDetailsVehiclesExtensions.FindAsync(id);
            if (transportationDetailVehicleExtension != null)
            {
                _context.TransportationsDetailsVehiclesExtensions.Remove(transportationDetailVehicleExtension);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportationDetailVehicleExtensionExists(int id)
        {
          return _context.TransportationsDetailsVehiclesExtensions.Any(e => e.TransportationDetailId == id);
        }
    }
}
