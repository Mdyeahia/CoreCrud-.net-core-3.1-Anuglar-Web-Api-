using CoreCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreCrud.Repository
{
    public class MenuRepository: IMenu
    {

        private readonly APIDbContext _appDB;
        public MenuRepository(APIDbContext context)
        {
            _appDB = context ??
                throw new ArgumentNullException(nameof(context));
        }
        public async Task<List<Menu>> getmenu(){
            
            var menu =  _appDB.Menus.ToList();
            return  menu; 
        } 
    }
}
