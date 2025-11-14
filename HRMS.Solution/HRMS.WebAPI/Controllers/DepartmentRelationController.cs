using HRMS.Business.Abstract;
using HRMS.Entities.DTOs.DepartmentRelation;
using Microsoft.AspNetCore.Mvc;

namespace HRMS.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentRelationController : ControllerBase
    {
        private readonly IDepartmentRelationService _departmentRelationService;

        public DepartmentRelationController(IDepartmentRelationService departmentRelationService)
        {
            _departmentRelationService = departmentRelationService;
        }

        [HttpPost("assign-roles")]
        public IActionResult AssignRolesToDepartment([FromBody] AssignRolesRequestDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _departmentRelationService.AssignRolesToDepartment(dto.DepartmentId, dto.RoleIds);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }

        [HttpPost("assign-employee")]
        public IActionResult AssignEmployeeToRole([FromBody] AssignEmployeeRequestDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = _departmentRelationService.AssignEmployeeToRole(dto.EmployeeId, dto.DepartmentRoleId);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }
    }
}