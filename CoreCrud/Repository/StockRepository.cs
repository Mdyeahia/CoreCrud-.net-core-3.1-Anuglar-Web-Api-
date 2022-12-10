using CoreCrud.IRepository;
using CoreCrud.Models;
using System.Threading.Tasks;

namespace CoreCrud.Repository
{
    public class StockRepository:IStock
    {
        public string InsertStock(StockMaster model)
        {
            var newId=string.Empty;
            if (model.Id > 0)
            {

            }
            else
            {
                
            }
            return "";
        }
    }
}
