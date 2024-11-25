using HeinekenRobot.Models;
using HeinekenRobot.Service.RewardRuleFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeinekenRobot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RewardRuleController : ControllerBase
    {
        private readonly IRewardRuleService _service;

        public RewardRuleController(IRewardRuleService service) {
            _service = service;
        }

        [HttpGet("GetRewardRules")]
        public async Task<IActionResult> GetRewardRules()
        {
            try
            {
                var rewardRules = await _service.GetRewardRules();
                return Ok(rewardRules);
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("AddRewardRule")]
        public async Task<IActionResult> AddRewardRule([FromBody] RewardRule rewardRule)
        {
            try
            {
                await _service.AddRewardRule(rewardRule);
                return Ok("Reward rule added successfully.");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch
            {
                return StatusCode(500, "Internal server error.");
            }
        }

        [HttpGet("GetRewardRuleDetail/{id}")]
        public async Task<IActionResult> GetRewardRule(int id)
        {
            var rewardRule = await _service.GetRewardRuleDetails(id);
            if (rewardRule == null)
            {
                return NotFound("Reward rule not found.");
            }

            return Ok(rewardRule);
        }

        [HttpPut("UpdateRewardRule/{ruleId}")]
        public async Task<IActionResult> UpdateRewardRule(int ruleId, [FromBody] RewardRule updatedRule)
        {
            if (ruleId != updatedRule.RuleId)
            {
                return BadRequest("Rule ID mismatch.");
            }

            try
            {
                await _service.UpdateRewardRule(updatedRule);
                return Ok("Reward rule updated successfully.");
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
    }
}
