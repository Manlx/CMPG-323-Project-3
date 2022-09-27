using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repository;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        //private readonly ConnectedOfficeContext _context;
        private DeviceRepository DeviceRepository;

        public DevicesController(ConnectedOfficeContext context)
        {
            //_context = context;
            DeviceRepository = new DeviceRepository(context);
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            var connectedOfficeContext = DeviceRepository.GetAll();
            return View(connectedOfficeContext);
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = DeviceRepository.GetById((Guid)id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
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
            device.DeviceId = Guid.NewGuid();
            DeviceRepository.Add(device);
            DeviceRepository.SaveAsync();
            return RedirectToAction(nameof(Index));


        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var device = DeviceRepository.GetById((Guid)id);
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
                DeviceRepository.Update(device);
                DeviceRepository.SaveAsync();
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
            if (id == null)
            {
                return NotFound();
            }

            var device = DeviceRepository.GetById((Guid)id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var device = DeviceRepository.GetById((Guid)id);
            DeviceRepository.Remove(device);
            DeviceRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        public bool DeviceExists(Guid id)
        {
            return DeviceRepository.DeviceExists(id);
        }
    }
}
