using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using _34551875Project3WebAppDesignPatterns.Data;
using _34551875Project3WebAppDesignPatterns.Models;
using _34551875Project3WebAppDesignPatterns.Repository;

namespace _34551875Project3WebAppDesignPatterns.Controllers
{
    public class DevicesController : Controller
    {
        //private readonly ConnectedOfficeContext _context;

        public DevicesController()
        {
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            DeviceRepository DeviceRepository = new DeviceRepository();

            var results = DeviceRepository.GetAll();

            return View(results);
        }


        // GET: Devices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            DeviceRepository DeviceRepository = new DeviceRepository();
            var device = DeviceRepository.GetByID((Guid)id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            DeviceRepository DeviceRepository = new DeviceRepository();
            ViewData["CategoryId"] = new SelectList(DeviceRepository.GetContext().Category, "CategoryId", "CategoryName");
            ViewData["ZoneId"] = new SelectList(DeviceRepository.GetContext().Zone, "ZoneId", "ZoneName");
            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            DeviceRepository DeviceRepository = new DeviceRepository();
            device.DeviceId = Guid.NewGuid();
            DeviceRepository.Add(device);
            return RedirectToAction(nameof(Index));
        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            DeviceRepository DeviceRepository = new DeviceRepository();
            if (id == null)
            {
                return NotFound();
            }

            var device = DeviceRepository.GetByID((Guid)id);
            if (device == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(DeviceRepository.GetContext().Category, "CategoryId", "CategoryName", device.CategoryId);
            ViewData["ZoneId"] = new SelectList(DeviceRepository.GetContext().Zone, "ZoneId", "ZoneName", device.ZoneId);
            return View(device);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            if (id != device.DeviceId)
            {
                return NotFound();
            }
            try
            {
                DeviceRepository DeviceRepository = new DeviceRepository();
                DeviceRepository.Update(device);
                await DeviceRepository.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(device.DeviceId))
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

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            DeviceRepository DeviceRepository = new DeviceRepository();
            var device = DeviceRepository.Delete(id);

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            DeviceRepository DeviceRepository = new DeviceRepository();
            DeviceRepository.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(Guid id)
        {
            DeviceRepository DeviceRepository = new DeviceRepository();
            return DeviceRepository.DeviceExists(id);
        }
    }
}
