using HRMS.Business.Abstract;
using HRMS.Entities.DTOs.Employee;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _employeeService.GetAll();
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Data);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _employeeService.GetById(id);
            if (!result.Success)
                return NotFound(result.Message);
            return Ok(result.Data);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateEmployeeDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _employeeService.Add(dto);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateEmployeeDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _employeeService.Update(dto);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id, [FromBody] DeleteEmployeeDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            var result = _employeeService.Delete(dto);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }

        [HttpGet("all-with-details")]
        public IActionResult GetAllWithDetails()
        {
            var result = _employeeService.GetAllWithDetails();
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Data);
        }
    }
}
