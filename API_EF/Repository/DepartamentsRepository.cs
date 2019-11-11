using Microsoft.EntityFrameworkCore;
using PocAPI.Data;
using PocAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PocAPI.Repository
{
    public class DepartamentsRepository : RepositoryBase<Departament>
    {
        public DepartamentsRepository(DatabaseContext dbContext) : base(dbContext) { }
    }
}
