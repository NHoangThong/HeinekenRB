using HeinekenRobot.Models;
using HeinekenRobot.Service.RoleFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeinekenRobot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _service;

        public RoleController(IRoleService service)
        {
            _service = service;
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var roles = await _service.GetAllRoles();
                var result = roles.Select(r => new
                {
                    r.RoleId,
                    r.RoleName,
                    r.Description,
                    UserCount = r.Users.Count // Số lượng tài khoản thuộc vai trò
                });

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("AddRole")]
        public async Task<IActionResult> AddRole([FromBody] Role role)
        {
            try
            {
                await _service.AddRoleAsync(role);
                return Ok(new { message = "Role added successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetRole/{id}")]
        public async Task<IActionResult> GetRoleById(int id)
        {
            var role = await _service.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound(new { message = "Role not found." });
            }
            return Ok(role);
        }
        [HttpPut("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(int id, [FromBody] Role role)
        {
            if (id != role.RoleId)
            {
                return BadRequest(new { message = "Role ID mismatch." });
            }

            try
            {
                await _service.UpdateRoleAsync(role);
                return Ok(new { message = "Role updated successfully." });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Role not found." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            try
            {
                await _service.DeleteRoleAsync(id);
                return Ok(new { message = "Role deleted successfully." });
            }
            catch (KeyNotFoundException)
            {
                return NotFound(new { message = "Role not found." });
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
