using CoreCrud.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreCrud.Repository
{
    public interface IProduct
    {

        Task<Product> AddProduct(Product objId);
        Task<Product> UpdateProduct(Product objId);
        Task<Product> Get(int objId);
        Task<List<Product>> Gets();
        bool Delete(int objId);
    }
}
