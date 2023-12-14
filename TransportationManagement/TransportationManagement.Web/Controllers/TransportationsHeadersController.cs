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

        public TransportationsHeadersController(ApplicationDbContext context) =>
            _context = context;

        // GET: TransportationHeaders
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.TransportationsHeaders.Include(t => t.Client);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: TransportationHeaders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TransportationsHeaders == null)
                return NotFound();

            var transportationHeader = await _context.TransportationsHeaders
                .Include(t => t.Client)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (transportationHeader == null)
                return NotFound();

            return View(
                GetModelViewData(transportationHeader, false)
            ); ;
        }

        // GET: TransportationHeaders/Create
        public IActionResult Create() =>
            View(GetModelViewData());

        // POST: TransportationHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ClientId, TotalAmount, TransportationsDetails")] TransportationHeader transportationHeader) 
        {
            transportationHeader.CreationDate = DateTime.Now;
            transportationHeader.TransportationsDetails?.RemoveAt(0);

            if (transportationHeader.TransportationsDetails?.Any() is null or false)
                transportationHeader.TransportationsDetails = null;

            ModelState.ClearValidationState(nameof(transportationHeader));
            if (!TryValidateModel(transportationHeader))
                return View(GetModelViewData(transportationHeader));

            _context.Add(transportationHeader);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: TransportationHeaders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TransportationsHeaders == null)
                return NotFound();

            var transportationHeader = await _context.TransportationsHeaders
                .Include(t => t.Client)
                .Include(t => t.TransportationsDetails)
                .SingleOrDefaultAsync(t => t.Id == id);

            if (transportationHeader == null)
                return NotFound();

            return View(
                "Create",
                GetModelViewData(transportationHeader)
            );
        }

        // POST: TransportationHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id, ClientId, TotalAmount, Status, TransportationsDetails")] TransportationHeader transportationHeader)
        {
            if (id != transportationHeader.Id)
                return NotFound();

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
            return View(transportationHeader);
        }

        // GET: TransportationHeaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TransportationsHeaders == null)
                return NotFound();

            var transportationHeader = await _context.TransportationsHeaders
                .Include(t => t.Client)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (transportationHeader == null)
                return NotFound();

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

        private TransportationHeader GetModelViewData(TransportationHeader? transportationHeader = null, bool setSelectData = true)
        {
            if (setSelectData)
            {
                ViewData["ClientId"] = new SelectList(_context.Clients, "Id", "Name");
                ViewData["DriverId"] = new SelectList(_context.Drivers, "Id", "Name");
                ViewData["VehicleLicensePlate"] = new SelectList(_context.Vehicles, "LicensePlate", "LicensePlate");
            }

            if (transportationHeader is null)
                transportationHeader = new();

            if (transportationHeader.Client is null)
                transportationHeader.Client = new();

            if (transportationHeader.TransportationsDetails?.Any() is null or false)
                transportationHeader.TransportationsDetails = new List<TransportationDetail>() {
                    new TransportationDetail()
                };

            return transportationHeader;
        }
    }
}
