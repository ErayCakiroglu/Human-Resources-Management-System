using HRMS.Business.Abstract;
using Microsoft.AspNetCore.Http;
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
        public IActionResult AssignRolesToDepartment(int departmentId, [FromBody] List<int> roleIds)
        {
            var result = _departmentRelationService.AssignRolesToDepartment(departmentId, roleIds);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }

        [HttpPost("assign-employee")]
        public IActionResult AssignEmployeeToRole(int employeeId, int departmentRoleId)
        {
            var result = _departmentRelationService.AssignEmployeeToRole(employeeId, departmentRoleId);
            if (!result.Success)
                return BadRequest(result.Message);
            return Ok(result.Message);
        }
    }
}
