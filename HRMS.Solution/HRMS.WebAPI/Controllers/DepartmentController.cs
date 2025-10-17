using HRMS.Business.Abstract;
using HRMS.Entities.DTOs.Department;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _departmentService.GetAll();
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpGet("all-with-details")]
        public IActionResult GetAllWithDetails()
        {
            var result = _departmentService.GetAllWithDetail();
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Data);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _departmentService.GetById(id);
            if (!result.Success)
                return NotFound(result.Message);

            return Ok(result.Data);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateDepartmentDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _departmentService.Add(dto);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateDepartmentDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _departmentService.Update(dto);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id, [FromBody] DeleteDepartmentDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            var result = _departmentService.Delete(dto);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}
