using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Interface;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repository
{
    public class CategoryRepository: GenericRepository<Category>, ICategoryRepository
    {
        //Default Constructor leave empty
        public CategoryRepository(ConnectedOfficeContext context) : base(context){}
        //Looks if Entity of Type Zone Exists with Guid of 
        public bool CategoryExists(Guid id)
        {
            return _context.Category.Any(e => e.CategoryId == id);
        }
    }
}
