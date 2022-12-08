using CoreCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CoreCrud.Repository
{
    public class ProductRepository:IProduct
    {
        private readonly APIDbContext _appDB;
        public ProductRepository(APIDbContext context)
        {
            _appDB= context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task<List<Product>> Gets() => await _appDB.Products.Include(c=>c.Category).ToListAsync();
        public async Task<Product> Get(int id) => await _appDB.Products.FindAsync(id);

        public async Task<Product> AddProduct(Product product)
        {
            await _appDB.Products.AddAsync(product); 
            await _appDB.SaveChangesAsync();
            return product;
        }
        public async Task<Product> UpdateProduct(Product product)
        {
             _appDB.Entry(product).State = EntityState.Modified;
            await _appDB.SaveChangesAsync();
            return product;
        }
        public bool Delete(int id)
        {
            var product = _appDB.Products.Find(id);
            if(product != null)
            {
                _appDB.Entry(product).State = EntityState.Deleted;
                _appDB.SaveChangesAsync();
                return true;
            }
            return false;
        }


    }
}
