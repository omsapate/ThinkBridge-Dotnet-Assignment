using EmployeeTaskManager.Models;
using EmployeeTaskManager.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        IEmployeesService _employeeService;
        public EmployeesController(IEmployeesService service)
        {
            _employeeService = service;
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult GetAllEmployees()
        {
            try
            {
                var employees = _employeeService.GetEmployeesList();

                if (employees == null) 
                    return NotFound();

                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("[action]/id")]
        public IActionResult GetEmployeesById(long id)
        {
            try
            {
                var employees = _employeeService.GetEmployeesById(id);

                if (employees == null) 
                    return NotFound();
                
                return Ok(employees);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult SaveEmployees(Employees employeeModel)
        {
            try
            {
                var result = _employeeService.SaveEmployee(employeeModel);

                if(result)
                    return Ok("Details saved");
                return BadRequest("failed");
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
