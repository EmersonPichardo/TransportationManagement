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
    public class VehiclesTypesVehiclesExtensionsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesTypesVehiclesExtensionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VehicleTypeVehicleExtensions
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VehiclesTypesVehiclesExtensions.Include(v => v.VehiclesExtensionsDescriptionNavigation).Include(v => v.VehiclesTypesDescriptionNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VehicleTypeVehicleExtensions/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.VehiclesTypesVehiclesExtensions == null)
            {
                return NotFound();
            }

            var vehicleTypeVehicleExtension = await _context.VehiclesTypesVehiclesExtensions
                .Include(v => v.VehiclesExtensionsDescriptionNavigation)
                .Include(v => v.VehiclesTypesDescriptionNavigation)
                .FirstOrDefaultAsync(m => m.VehiclesTypesDescription == id);
            if (vehicleTypeVehicleExtension == null)
            {
                return NotFound();
            }

            return View(vehicleTypeVehicleExtension);
        }

        // GET: VehicleTypeVehicleExtensions/Create
        public IActionResult Create()
        {
            ViewData["VehiclesExtensionsDescription"] = new SelectList(_context.VehiclesExtensions, "Description", "Description");
            ViewData["VehiclesTypesDescription"] = new SelectList(_context.VehiclesTypes, "Description", "Description");
            return View();
        }

        // POST: VehicleTypeVehicleExtensions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VehiclesTypesDescription,VehiclesExtensionsDescription,Status")] VehicleTypeVehicleExtension vehicleTypeVehicleExtension)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleTypeVehicleExtension);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["VehiclesExtensionsDescription"] = new SelectList(_context.VehiclesExtensions, "Description", "Description", vehicleTypeVehicleExtension.VehiclesExtensionsDescription);
            ViewData["VehiclesTypesDescription"] = new SelectList(_context.VehiclesTypes, "Description", "Description", vehicleTypeVehicleExtension.VehiclesTypesDescription);
            return View(vehicleTypeVehicleExtension);
        }

        // GET: VehicleTypeVehicleExtensions/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.VehiclesTypesVehiclesExtensions == null)
            {
                return NotFound();
            }

            var vehicleTypeVehicleExtension = await _context.VehiclesTypesVehiclesExtensions.FindAsync(id);
            if (vehicleTypeVehicleExtension == null)
            {
                return NotFound();
            }
            ViewData["VehiclesExtensionsDescription"] = new SelectList(_context.VehiclesExtensions, "Description", "Description", vehicleTypeVehicleExtension.VehiclesExtensionsDescription);
            ViewData["VehiclesTypesDescription"] = new SelectList(_context.VehiclesTypes, "Description", "Description", vehicleTypeVehicleExtension.VehiclesTypesDescription);
            return View(vehicleTypeVehicleExtension);
        }

        // POST: VehicleTypeVehicleExtensions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("VehiclesTypesDescription,VehiclesExtensionsDescription,Status")] VehicleTypeVehicleExtension vehicleTypeVehicleExtension)
        {
            if (id != vehicleTypeVehicleExtension.VehiclesTypesDescription)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleTypeVehicleExtension);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleTypeVehicleExtensionExists(vehicleTypeVehicleExtension.VehiclesTypesDescription))
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
            ViewData["VehiclesExtensionsDescription"] = new SelectList(_context.VehiclesExtensions, "Description", "Description", vehicleTypeVehicleExtension.VehiclesExtensionsDescription);
            ViewData["VehiclesTypesDescription"] = new SelectList(_context.VehiclesTypes, "Description", "Description", vehicleTypeVehicleExtension.VehiclesTypesDescription);
            return View(vehicleTypeVehicleExtension);
        }

        // GET: VehicleTypeVehicleExtensions/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.VehiclesTypesVehiclesExtensions == null)
            {
                return NotFound();
            }

            var vehicleTypeVehicleExtension = await _context.VehiclesTypesVehiclesExtensions
                .Include(v => v.VehiclesExtensionsDescriptionNavigation)
                .Include(v => v.VehiclesTypesDescriptionNavigation)
                .FirstOrDefaultAsync(m => m.VehiclesTypesDescription == id);
            if (vehicleTypeVehicleExtension == null)
            {
                return NotFound();
            }

            return View(vehicleTypeVehicleExtension);
        }

        // POST: VehicleTypeVehicleExtensions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.VehiclesTypesVehiclesExtensions == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VehiclesTypesVehiclesExtensions'  is null.");
            }
            var vehicleTypeVehicleExtension = await _context.VehiclesTypesVehiclesExtensions.FindAsync(id);
            if (vehicleTypeVehicleExtension != null)
            {
                _context.VehiclesTypesVehiclesExtensions.Remove(vehicleTypeVehicleExtension);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleTypeVehicleExtensionExists(string id)
        {
          return _context.VehiclesTypesVehiclesExtensions.Any(e => e.VehiclesTypesDescription == id);
        }
    }
}
