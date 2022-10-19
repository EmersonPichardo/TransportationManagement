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
    public class TransportationsDetailsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TransportationsDetailsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TransportationDetails
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TransportationsDetails.Include(t => t.Client).Include(t => t.Driver).Include(t => t.VehicleLicensePlateNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TransportationDetails/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransportationsDetails == null)
            {
                return NotFound();
            }

            var transportationDetail = await _context.TransportationsDetails
                .Include(t => t.Client)
                .Include(t => t.Driver)
                .Include(t => t.VehicleLicensePlateNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportationDetail == null)
            {
                return NotFound();
            }

            return View(transportationDetail);
        }

        // GET: TransportationDetails/Create
        public IActionResult Create()
        {
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id");
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Id");
            ViewData["VehicleLicensePlate"] = new SelectList(_context.Vehicles, "LicensePlate", "LicensePlate");
            return View();
        }

        // POST: TransportationDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClientId,Description,PickUpLocation,DeliveryLocation,PickUpDate,DeliverypDate,Amount,DriverId,VehicleLicensePlate,Status")] TransportationDetail transportationDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transportationDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", transportationDetail.ClientId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Id", transportationDetail.DriverId);
            ViewData["VehicleLicensePlate"] = new SelectList(_context.Vehicles, "LicensePlate", "LicensePlate", transportationDetail.VehicleLicensePlate);
            return View(transportationDetail);
        }

        // GET: TransportationDetails/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransportationsDetails == null)
            {
                return NotFound();
            }

            var transportationDetail = await _context.TransportationsDetails.FindAsync(id);
            if (transportationDetail == null)
            {
                return NotFound();
            }
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", transportationDetail.ClientId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Id", transportationDetail.DriverId);
            ViewData["VehicleLicensePlate"] = new SelectList(_context.Vehicles, "LicensePlate", "LicensePlate", transportationDetail.VehicleLicensePlate);
            return View(transportationDetail);
        }

        // POST: TransportationDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClientId,Description,PickUpLocation,DeliveryLocation,PickUpDate,DeliverypDate,Amount,DriverId,VehicleLicensePlate,Status")] TransportationDetail transportationDetail)
        {
            if (id != transportationDetail.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transportationDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransportationDetailExists(transportationDetail.Id))
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
            ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Id", transportationDetail.ClientId);
            ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Id", transportationDetail.DriverId);
            ViewData["VehicleLicensePlate"] = new SelectList(_context.Vehicles, "LicensePlate", "LicensePlate", transportationDetail.VehicleLicensePlate);
            return View(transportationDetail);
        }

        // GET: TransportationDetails/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransportationsDetails == null)
            {
                return NotFound();
            }

            var transportationDetail = await _context.TransportationsDetails
                .Include(t => t.Client)
                .Include(t => t.Driver)
                .Include(t => t.VehicleLicensePlateNavigation)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (transportationDetail == null)
            {
                return NotFound();
            }

            return View(transportationDetail);
        }

        // POST: TransportationDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TransportationsDetails == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TransportationsDetails'  is null.");
            }
            var transportationDetail = await _context.TransportationsDetails.FindAsync(id);
            if (transportationDetail != null)
            {
                _context.TransportationsDetails.Remove(transportationDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransportationDetailExists(int id)
        {
          return _context.TransportationsDetails.Any(e => e.Id == id);
        }
    }
}
