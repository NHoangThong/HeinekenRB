﻿using HeinekenRobot.Models;
using HeinekenRobot.Service.RobotFolder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeinekenRobot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RobotController : ControllerBase
    {
        private readonly IRobotService _service;

        public RobotController(IRobotService service)
        {
            _service = service;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var robots = await _service.GetRobots();
            return Ok(robots);
        }

        [HttpPost("AddRobot")]
        public async Task<IActionResult> PostRobot([FromBody] Robot robot)
        {
            if (robot == null)
            {
                return BadRequest("Robot data is null");
            }
            await _service.AddRobot(robot);
            return Ok();
        }

        [HttpGet("GetRobot/{id}")]
        public async Task<IActionResult> GetRobot(int id)
        {
            var rb= await _service.GetRobotId(id);
            if(rb == null)
                return NotFound();
            return Ok(rb);
        }

        [HttpPut("UpdateRobot/{id}")]
        public async Task<IActionResult> UpdateRobot(int id, [FromBody] Robot robot)
        {
         

            try
            {
                robot.RobotId= id ;
                await _service.UpdateRobot(robot);
                return Ok("Robot updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
        [HttpDelete("DeleteRobot/{id}")]
        public async Task<IActionResult> DeleteRobot(int id)
        {
            try
            {
                await _service.DeleteRobot(id);
                return Ok("Robot deleted successfully.");
            }
           
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
