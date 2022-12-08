using CoreCrud.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreCrud.Repository
{
    public interface ICategory
    {
        
        Task<Category> AddCategory(Category category);
        Task<Category> UpdateCategory(Category category);
        Task<Category> Get(int objId);
        Task<List<Category>> Gets();
        bool Delete(int objId);
    }
}
