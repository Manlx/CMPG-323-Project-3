using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Interface;
using DeviceManagement_WebApp.Models;
using System;
using System.Linq;

namespace DeviceManagement_WebApp.Repository
{
    public class ZoneRepository : GenericRepository<Zone>, IZoneRepository
    {
        //Default Constructor leave empty
        public ZoneRepository(ConnectedOfficeContext context) : base(context){}
        //Looks if Entity of Type Zone Exists with Guid of 
        public bool ZoneExists(Guid id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }
}
}
