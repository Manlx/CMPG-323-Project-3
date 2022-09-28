using DeviceManagement_WebApp.Models;
using System;

namespace DeviceManagement_WebApp.Interface
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        //Looks if Entity of Type Device Exists with Guid of 
        bool DeviceExists(Guid id);
    }
}
