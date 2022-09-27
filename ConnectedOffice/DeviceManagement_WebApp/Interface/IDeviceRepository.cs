using DeviceManagement_WebApp.Models;
using System;

namespace DeviceManagement_WebApp.Interface
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        //Add specialized Zone Methods
        bool DeviceExists(Guid id);
    }
}
