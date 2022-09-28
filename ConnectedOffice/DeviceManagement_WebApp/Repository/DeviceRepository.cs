using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Interface;
using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        //Default Constructor leave empty
        public DeviceRepository(ConnectedOfficeContext context) : base(context){}
        //Looks if Entity of Type Zone Exists with Guid of 
        public bool DeviceExists(Guid id)
        {
            return _context.Device.Any(e => e.CategoryId == id);
        }
        //Had to Create new GetAll method because base Get all method does not include correct data;
        public async Task<List<Device>> GetAllAll()
        {
            var AllData = await _context.Device.Include(d => d.Category).Include(d => d.Zone).ToListAsync();
            return AllData;
        }
    }
}
