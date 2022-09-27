using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Interface;
using DeviceManagement_WebApp.Models;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class DeviceRepository : GenericRepository<Device>, IDeviceRepository
    {
        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {
        }
        public bool DeviceExists(Guid id)
        {
            return _context.Device.Any(e => e.CategoryId == id);
        }
    }
}
