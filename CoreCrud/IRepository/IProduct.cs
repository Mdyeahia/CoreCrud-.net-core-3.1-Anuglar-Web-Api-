using CoreCrud.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreCrud.Repository
{
    public interface IProduct
    {

        Task<Product> AddProduct(int objId);
        Task<Product> UpdateProduct(int objId);
        Task<Product> Get(int objId);
        Task<List<Product>> Gets();
        Task<string> Delete(Product obj);
    }
}
