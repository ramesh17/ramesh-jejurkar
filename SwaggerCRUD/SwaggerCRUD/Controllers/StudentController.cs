using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SwaggerCRUD.Context;
using SwaggerCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SwaggerCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly CRUDContext _Context;
        private ILogger _logger;

        public StudentController(CRUDContext Context,ILogger logger)
        {
            _Context = Context;
            _logger = logger;

        }
        // GET: api/<StudentController>
        [HttpGet]
        public IEnumerable<Student> Get()
        {
            _logger.LogInformation("Getting Student Data");
            return _Context.Students;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            if(id==0)
            {
                _logger.LogWarning("Details({id}) id is missing:{id}", id);
            }
            _logger.LogInformation("Getting Student {id}", id);
            return _Context.Students.SingleOrDefault(x => x.Id == id);
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] Student student)
        {
            _Context.Students.Add(student);
            _Context.SaveChanges();
            _logger.LogInformation("Data inserted Succefully");
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] Student student)
        {
            _Context.Students.Update(student);
            _Context.SaveChanges();
            _logger.LogInformation("Update Successfully");
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var item = _Context.Students.FirstOrDefault(x => x.Id == id);
            if(item!=null)
            {
                _Context.Students.Remove(item);
                _Context.SaveChanges();
            }
        }
    }
}
