using CoreCrud.Models;
using System.Threading.Tasks;

namespace CoreCrud.IRepository
{
    public interface IStock
    {
        string InsertStock(StockMaster  stock);
    }
}
