﻿using HeinekenRobot.Models;
using HeinekenRobot.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.PortableExecutable;

namespace HeinekenRobot.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecycleMachineController : ControllerBase
    {
        private readonly IRecycleMachineService _servive;

        public RecycleMachineController(IRecycleMachineService service)
        {
            _servive= service;
        }

        [HttpGet("GetMachines")]
        public async Task<IActionResult> GetMachines()
        {
            var machines= await _servive.GetMachines();
            return Ok(machines);
        }

        [HttpPost("AppMachine")]
        public async Task<IActionResult> AddMachine([FromBody] RecycleMachine recycleMachine)
        {
            try
            {
                await _servive.Add_Machine(recycleMachine);
                return Ok("Recycle machine added successfully.");
            }
            
            catch (Exception)
            {
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpGet("GetMachineDetail")]
        public async Task<IActionResult> GetMachineDetail(int id)
        {
            var machine= await _servive.GetMachineDetail(id);
            if (machine == null)
            {
                return NotFound("Recycle machine not found.");
            }

            return Ok(machine);
        }

        [HttpPut("UpdateMachine/{id}")]
        public async Task<IActionResult> UpdateMachine(int id, [FromBody] RecycleMachine recycleMachine)
        {
            try
            {
                recycleMachine.MachineId = id;
                await _servive.Upadate_Machine(recycleMachine);
                return Ok("Recycle machine updated successfully.");
            }
            
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

    }
}