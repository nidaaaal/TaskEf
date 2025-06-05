using Microsoft.AspNetCore.Mvc;
using Task.Models.Dto;
using Task.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _services;   

        public EmployeeController(IEmployeeServices employeeServices)
        {
            _services = employeeServices;   
        }
        // GET: api/<EmployeeController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _services.GetAll();
            return Ok(data);
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var data = await _services.GetById(id);
            return data ==null ? NotFound():Ok(data);
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmployeeDto employeeDto)
        {
            var data = await _services.Create(employeeDto);
            return data == null ? NoContent() : Ok(data);   

        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] EmployeeDto employeeDto)
        {

            var data = await _services.Update(id,employeeDto);
            return data == null ? NotFound() : Ok(data);

        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {

            var data = await _services.DeleteById(id);
            return data ? NoContent() : NotFound();
        }
    }
}
