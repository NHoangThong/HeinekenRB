using HeinekenRobot.Models;
using HeinekenRobot.Service.LocationFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeinekenRobot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _service;

        public LocationController(ILocationService service) {
            _service= service;
        }
        [HttpGet("GetLocation")]
        public async Task<IActionResult> GetLocation()
        {
            var location=await _service.GetAllLocations();
            return Ok(location);
        }
        [HttpPost("AddLocation")]
        public async Task<IActionResult> AddLocation([FromBody] Location location)
        {
            try
            {
                await _service.AddLocation(location);
                return Ok(new { message = "Location added successfully." });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("GetLocationID")]
        public async Task<IActionResult> GetLocationDetails(int locationId)
        {
            var locationDetails = await _service.GetLocationDetailsAsync(locationId);

            if (locationDetails == null)
            {
                return NotFound(new { message = "Location not found." });
            }

            return Ok(locationDetails);
        }

        [HttpPut("UpdateLocation/{id}")]

        public async Task<IActionResult> UpdateLocation(int id, [FromBody] Location location)
        {
            if (id != location.LocationId)
            {
                return BadRequest("Location ID mismatch.");
            }
            try
            {
                await _service.updateLocation(location);
                return Ok("Success");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteLocation/{id}")]

        public async Task<IActionResult> DeleteLocation(int id)
        {
            try
            {
                await _service.DeleteLocation(id);
                return Ok("Location deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
