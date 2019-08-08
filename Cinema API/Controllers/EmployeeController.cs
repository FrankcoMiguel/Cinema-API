using Microsoft.AspNetCore.Mvc;
using Model;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CinemaAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {

            _employeeService = employeeService;

        }

        // GET Employee by Id
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok(_employeeService.Select(id));
        }

        // GET List All
        [HttpGet]
        public IActionResult Getll()
        {

            return Ok(_employeeService.SelectAll());

        }

        // POST new Employee
        [HttpPost]
        public IActionResult Post([FromBody] Employee employee)
        {

            return Ok(_employeeService.Add(employee));

        }


        // PUT edit Employee
        [HttpPut]
        public IActionResult Put(int id, [FromBody] Employee employee)
        {

            return Ok(_employeeService.Update(id, employee));

        }

        // DELETE remove Employee
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {

            return Ok(_employeeService.Delete(id));

        }

    }
}