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
    public class EmployeesController : BaseController<Employee>
    {
        public EmployeesController(IRepository<Employee> repository) : base(repository)
        {
        }

        [HttpGet("per-departament")]
        public ActionResult<IEnumerable<Employee>> PerDepartament()
        {
            try
            {
                return Ok(_repository.All()
                    .GroupBy(x => x.DepartamentId)
                    .Select(x => new { Departament = x.FirstOrDefault().Departament, Count = x.Count() }));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Data);
            }
        }

        [HttpGet("started-between-january-and-june")]
        public ActionResult<IEnumerable<Employee>> StartedBetweenJanuaryAndJune()
        {
            try
            {
                return Ok(_repository.All()
                    .Where(x => x.StartMonth >= Month.January && x.StartMonth <= Month.June)
                    .GroupBy(x => x.StartMonth)
                    .Select(g => new { Month = new { Name = Enum.GetName(typeof(Month), g.Key), Number = g.Key }, Count = g.Count() }));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Data);
            }
        }
    }
}
