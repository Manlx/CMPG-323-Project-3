using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Interface
{
    public interface ICategoryRepository: IGenericRepository<Category>
    {
        //Add specialized Zone Methods
        public bool CategoryExists(Guid id);

    }
}
