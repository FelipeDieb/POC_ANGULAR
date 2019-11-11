using Microsoft.EntityFrameworkCore;
using PocAPI.Data;
using PocAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocAPI.Repository
{
    public class EmployeesRepository : RepositoryBase<Employee>
    {
        public EmployeesRepository(DatabaseContext dbContext) : base(dbContext) { }
    }
}
