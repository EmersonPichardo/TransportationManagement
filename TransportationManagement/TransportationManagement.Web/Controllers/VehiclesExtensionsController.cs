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
    public class VehiclesExtensionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesExtensionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VehicleExtensions
        public async Task<IActionResult> Index()
        {
              return View(await _context.VehiclesExtensions.ToListAsync());
        }

        // GET: VehicleExtensions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.VehiclesExtensions == null)
            {
                return NotFound();
            }

            var vehicleExtension = await _context.VehiclesExtensions
                .FirstOrDefaultAsync(m => m.Description == id);
            if (vehicleExtension == null)
            {
                return NotFound();
            }

            return View(vehicleExtension);
        }

        // GET: VehicleExtensions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleExtensions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Status")] VehicleExtension vehicleExtension)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleExtension);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleExtension);
        }

        // GET: VehicleExtensions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.VehiclesExtensions == null)
            {
                return NotFound();
            }

            var vehicleExtension = await _context.VehiclesExtensions.FindAsync(id);
            if (vehicleExtension == null)
            {
                return NotFound();
            }
            return View(vehicleExtension);
        }

        // POST: VehicleExtensions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Description,Status")] VehicleExtension vehicleExtension)
        {
            if (id != vehicleExtension.Description)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleExtension);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleExtensionExists(vehicleExtension.Description))
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
            return View(vehicleExtension);
        }

        // GET: VehicleExtensions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.VehiclesExtensions == null)
            {
                return NotFound();
            }

            var vehicleExtension = await _context.VehiclesExtensions
                .FirstOrDefaultAsync(m => m.Description == id);
            if (vehicleExtension == null)
            {
                return NotFound();
            }

            return View(vehicleExtension);
        }

        // POST: VehicleExtensions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.VehiclesExtensions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VehiclesExtensions'  is null.");
            }
            var vehicleExtension = await _context.VehiclesExtensions.FindAsync(id);
            if (vehicleExtension != null)
            {
                _context.VehiclesExtensions.Remove(vehicleExtension);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleExtensionExists(string id)
        {
          return _context.VehiclesExtensions.Any(e => e.Description == id);
        }
    }
}
