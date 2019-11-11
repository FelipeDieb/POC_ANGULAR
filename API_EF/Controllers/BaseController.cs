using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PocAPI.Repository;

namespace PocAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase
    {
        protected IRepository<T> _repository;

        public BaseController(IRepository<T> repository)
        {
            _repository = repository;
        }

        // GET: api/Base
        [HttpGet]
        public ActionResult<IEnumerable<T>> Get()
        {
            try
            {
                return Ok(_repository.All());
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Data);
            }
        }

        // GET: api/Base/5
        [HttpGet("{id}")]
        public ActionResult<T> Get(long id)
        {
            try
            {
                return Ok(_repository.Get(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Data);
            }
        }

        // POST: api/Base
        [HttpPost]
        public ActionResult Post([FromBody] T entity)
        {
            try
            {
                _repository.Add(entity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Data);
            }
        }

        // PUT: api/Base/5
        [HttpPut("{id}")]
        public ActionResult Put(long id, [FromBody] T entity)
        {
            try
            {
                _repository.Update(id, entity);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Data);
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            try
            {
                _repository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Data);
            }
        }
    }
}
