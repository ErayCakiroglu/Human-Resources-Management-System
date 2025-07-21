using HRMS.Business.Abstract;
using HRMS.Entities.DTOs.Role;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _roleService.GetAll();
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Data);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var result = _roleService.GetById(id);
            if (!result.Success)
                return NotFound(result.Message);
            return Ok(result.Data);
        }

        [HttpPost]
        public IActionResult Add([FromBody] CreateRoleDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _roleService.Add(dto);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, [FromBody] UpdateRoleDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _roleService.Update(dto);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id, [FromBody] DeleteRoleDTO dto)
        {
            if (id != dto.Id)
                return BadRequest("ID mismatch.");

            var result = _roleService.Delete(dto);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }
    }
}
