using DeviceManagement_WebApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Interface
{
    public interface IDeviceRepository : IGenericRepository<Device>
    {
        //Looks if Entity of Type Device Exists with Guid of 
        bool DeviceExists(Guid id);
        //Had to Create new GetAll method because base Get all method does not include correct data;
        public Task<List<Device>> GetAllAll();
    }
}
