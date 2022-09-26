using _34551875Project3WebAppDesignPatterns.Data;
using _34551875Project3WebAppDesignPatterns.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _34551875Project3WebAppDesignPatterns.Repository
{
    public class DeviceRepository
    {
        protected readonly ConnectedOfficeContext _context = new ConnectedOfficeContext();


        // GET ALL: Products
        public IEnumerable<Device> GetAll()//Get all
        {
            return _context.Device.ToList();
        }

        public Device GetByID(Guid ID) //Get by ID
        {
            return _context.Device.Find(ID);
        }

        public void Add(Device entity)//Post
        {
            _context.Set<Device>().Add(entity);
        }

        public void Update(Device entity)//Post
        {
            _context.Update(entity);
        }

        public void AddRange(IEnumerable<Device> entities)//Post Multi
        {
            _context.Set<Device>().AddRange(entities);
        }
        public IEnumerable<Device> Find(Expression<Func<Device, bool>> expression)//Search
        {
            return _context.Set<Device>().Where(expression);
        }
        public void Remove(Device entity)//Remove
        {
            _context.Set<Device>().Remove(entity);
        }
        public void RemoveRange(IEnumerable<Device> entities)//Remove in Range
        {
            _context.Set<Device>().RemoveRange(entities);
        }
        public bool DeviceExists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }
        public ConnectedOfficeContext GetContext()
        {
            return this._context;
        }
        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var device = await _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);
            if (device == null)
            {
                return null;
            }

            return (IActionResult)device;
        }

        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var device = this.GetByID(id);
            _context.Device.Remove(device);
            await this.SaveChangesAsync();
            return (IActionResult)device;
        }

    }
}
