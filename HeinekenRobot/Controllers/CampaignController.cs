using HeinekenRobot.Models;
using HeinekenRobot.Service.CampaignFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeinekenRobot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly ICampaignService _service;

        public CampaignController(ICampaignService service)
        {
            _service = service;
        }
        [HttpGet("GetOperationalCampaigns")]
        public async Task<IActionResult> GetOperationalCampaigns()
        {
            try
            {
                var campaigns = await _service.GetActiveCampaignSummaries();
                return Ok(campaigns);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = $"Internal server error: {ex.Message}" });
            }
        }

        [HttpPost("AddCampaign")]
        public async Task<IActionResult> AddCampaign([FromBody] Campaign campaign)
        {
            try
            {
                await _service.AddCampaign(campaign);
                return Ok("Campaign added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }

        [HttpGet("GetCampaignDetails/{id}")]
        public async Task<IActionResult> GetCampaignDetails(int id)
        {
            try
            {
                var result = await _service.GetCampaignDetails(id);
                return Ok(result);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { error = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { error = ex.Message });
            }
        }

        [HttpPut("UpdateCampaign/{id}")]
        public async Task<IActionResult> UpdateCampaign(int id, [FromBody] Campaign updatedCampaign)
        {
            if (id != updatedCampaign.CampaignId)
            {
                return BadRequest("Campaign ID mismatch.");
            }

            try
            {
                await _service.UpdateCampaign(id, updatedCampaign);
                return Ok("Campaign updated successfully.");
            }
            catch (ArgumentException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpDelete("DeleteCampaign/{id}")]
        public async Task<IActionResult> DeleteCampaign(int id)
        {
            try
            {
                await _service.DeleteCampaign(id);
                return Ok("Campaign deleted successfully.");
            }
            catch (ArgumentException ex)
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
