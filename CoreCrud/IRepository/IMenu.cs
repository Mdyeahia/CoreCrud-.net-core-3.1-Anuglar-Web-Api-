using CoreCrud.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreCrud.Repository
{
    public interface IMenu
    {

        Task<List<Menu>> getmenu();
        
    }
}
