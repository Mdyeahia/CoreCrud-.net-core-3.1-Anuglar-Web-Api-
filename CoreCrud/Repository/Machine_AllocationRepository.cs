using CoreCrud.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CoreCrud.Repository
{
    public class Machine_AllocationRepository:IMachine_Allocation
    {
        private readonly APIDbContext _appDB;
        public Machine_AllocationRepository(APIDbContext context)
        {
            _appDB= context ??
                throw new ArgumentNullException(nameof(context));
        }

        public List<MachineAllocation> Gets()
        {
            return _appDB.MachineAllocations.FromSqlRaw("").ToList();
        }

        public string DataSaveOrUpdate(MachineAllocation model)
        {
            return "";
        }


    }
}
