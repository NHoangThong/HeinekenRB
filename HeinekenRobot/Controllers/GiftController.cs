using HeinekenRobot.Models;
using HeinekenRobot.Service.GiftFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeinekenRobot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiftController : ControllerBase
    {
        private readonly IGiftService _service;

        public GiftController(IGiftService service) {
            _service = service;
        }

        [HttpGet("GetGifts")]
        public async Task<IActionResult> GetGifts()
        {
            var gifts = await _service.GetAllGifts();
            return Ok(gifts);
        }

        [HttpPost("AddGift")]
        public async Task<IActionResult> AddGift([FromBody] Gift gift)
        {
            try
            {
                await _service.AddGift(gift);
                return Ok("Gift added successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("GetGiftDetails/{id}")]
        public async Task<IActionResult> GetGiftDetails(int id)
        {
            try
            {
                var giftDetails = await _service.GetGiftById(id);
                return Ok(giftDetails);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("UpdateGift/{id}")]
        public async Task<IActionResult> UpdateGift(int id, [FromBody] Gift updatedGift)
        {
            try
            {
                await _service.UpdateGift(id, updatedGift);
                return Ok("Gift updated successfully.");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("DeleteGift/{id}")]
        public async Task<IActionResult> DeleteGift(int id)
        {
            try
            {
                var result = await _service.DeleteGift(id);
                if (!result)
                {
                    return NotFound("Gift not found.");
                }
                return Ok("Gift deleted successfully.");
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }
    }
}
