using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeviceManagement_WebApp.Interface
{
    public interface IZoneRepository: IGenericRepository<Zone>
    {
        //Add specialized Zone Methods
        public bool ZoneExists(Guid id);
    }
    
}
