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
    public class VehiclesTypesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VehiclesTypesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VehicleTypes
        public async Task<IActionResult> Index()
        {
              return View(await _context.VehiclesTypes.ToListAsync());
        }

        // GET: VehicleTypes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.VehiclesTypes == null)
            {
                return NotFound();
            }

            var vehicleType = await _context.VehiclesTypes
                .FirstOrDefaultAsync(m => m.Description == id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            return View(vehicleType);
        }

        // GET: VehicleTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VehicleTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Description,Status")] VehicleType vehicleType)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vehicleType);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(vehicleType);
        }

        // GET: VehicleTypes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.VehiclesTypes == null)
            {
                return NotFound();
            }

            var vehicleType = await _context.VehiclesTypes.FindAsync(id);
            if (vehicleType == null)
            {
                return NotFound();
            }
            return View(vehicleType);
        }

        // POST: VehicleTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Description,Status")] VehicleType vehicleType)
        {
            if (id != vehicleType.Description)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vehicleType);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VehicleTypeExists(vehicleType.Description))
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
            return View(vehicleType);
        }

        // GET: VehicleTypes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.VehiclesTypes == null)
            {
                return NotFound();
            }

            var vehicleType = await _context.VehiclesTypes
                .FirstOrDefaultAsync(m => m.Description == id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            return View(vehicleType);
        }

        // POST: VehicleTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.VehiclesTypes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VehiclesTypes'  is null.");
            }
            var vehicleType = await _context.VehiclesTypes.FindAsync(id);
            if (vehicleType != null)
            {
                _context.VehiclesTypes.Remove(vehicleType);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VehicleTypeExists(string id)
        {
          return _context.VehiclesTypes.Any(e => e.Description == id);
        }
    }
}
