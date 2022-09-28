using DeviceManagement_WebApp.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace DeviceManagement_WebApp.Interface
{
    public interface IZoneRepository: IGenericRepository<Zone>
    {
        //Looks if Entity of Type Zone Exists with Guid of 
        public bool ZoneExists(Guid id);
    }
    
}
