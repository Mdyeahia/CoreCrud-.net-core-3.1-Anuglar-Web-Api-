using CoreCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CoreCrud.Repository
{
    public class CategoryRepository:ICategory
    {
        private readonly APIDbContext _appDB;
        public CategoryRepository(APIDbContext context)
        {
            _appDB= context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Category>> Gets() => await _appDB.Categories.ToListAsync();
        public async Task<Category> Get(int id) => await _appDB.Categories.FindAsync(id);

        public async Task<Category> AddCategory(Category category)
        {
            await _appDB.Categories.AddAsync(category); 
            await _appDB.SaveChangesAsync();
            return category;
        }
        public async Task<Category> UpdateCategory(Category category)
        {
             _appDB.Entry(category).State = EntityState.Modified;
            await _appDB.SaveChangesAsync();
            return category;
        }
        public bool Delete(int id)
        {
            var category=_appDB.Categories.Find(id);
            if(category != null)
            {
                _appDB.Entry(category).State = EntityState.Deleted;
                _appDB.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}
