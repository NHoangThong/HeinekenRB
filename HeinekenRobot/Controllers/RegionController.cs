using HeinekenRobot.Models;
using HeinekenRobot.Service.RegionFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeinekenRobot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionController : ControllerBase
    {
        private readonly IRegionService _service;

        public RegionController(IRegionService service)
        {
            _service = service;
        }

        [HttpGet("GetAllRegions")]
        public async Task<IActionResult> GetAllRegions()
        {
            try
            {
                var result = await _service.GetAllRegionsWithLocationCount();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost("AddRegion")]
        public async Task<IActionResult> AddRegion([FromBody] Region region)
        {
            try
            {
                await _service.AddRegion(region);
                return Ok("Region added successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("GetRegion/{regionId}")]
        public async Task<IActionResult> GetRegion(int regionId)
        {
            var region = await _service.GetRegionById(regionId);

            if (region == null)
            {
                return NotFound("Region not found.");
            }

            return Ok(region);
        }

        [HttpPut("UpdateRegion/{regionId}")]
        public async Task<IActionResult> UpdateRegion(int regionId, [FromBody] Region updatedRegion)
        {
            if (regionId != updatedRegion.RegionId)
            {
                return BadRequest("Region ID mismatch.");
            }

            try
            {
                await _service.UpdateRegion(updatedRegion);
                return Ok("Region updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("DeleteRegion/{regionId}")]
        public async Task<IActionResult> DeleteRegion(int regionId)
        {
            try
            {
                var success = await _service.DeleteRegion(regionId);

                if (success)
                {
                    return Ok("Region deleted successfully.");
                }

                return BadRequest("Unable to delete region.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
