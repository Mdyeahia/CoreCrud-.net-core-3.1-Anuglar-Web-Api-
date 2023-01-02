using CoreCrud.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreCrud.Repository
{
    public interface IMachine_Allocation
    {
        
        string DataSaveOrUpdate(MachineAllocation  obj);
         List<MachineAllocation> Gets();
    }
}
