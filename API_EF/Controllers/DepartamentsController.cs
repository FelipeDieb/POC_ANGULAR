using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocAPI.Model;
using PocAPI.Repository;

namespace PocAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartamentsController : BaseController<Departament>
    {
        public DepartamentsController(IRepository<Departament> repository) : base(repository)
        {
        }
    }
}