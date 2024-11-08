using CapstoneGenerator.Server.Services.Contracts;
using CapstoneGenerator.Server.Models;
using Microsoft.AspNetCore.Mvc;
using CapstoneGenerator.Server.Services;
using CapstoneGenerator.Server.Migrations;

namespace CapstoneGenerator.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CapstoneController : ControllerBase
    {
        private readonly ICapstoneServices capstoneServices;
        private readonly IHttpContextAccessor httpContextAccessor;

        public CapstoneController
            (
            ICapstoneServices capstoneServices,
            IHttpContextAccessor httpContextAccessor
            )
        {
            this.capstoneServices = capstoneServices;
            this.httpContextAccessor = httpContextAccessor;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<CapstoneGenerator.Server.Models.Capstones>>> GetAll()
        {
            try
            {
                var capstones = await capstoneServices.GetAllCapstones();
                if (capstones == null || !capstones.Any())
                {
                    return NotFound("No Capstones Found in the Database");
                }
                return Ok(capstones);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<CapstoneGenerator.Server.Models.Capstones>> GetById(int id)
        {
            var capstone = await capstoneServices.GetCapstonesById(id);
            if (capstone == null)
            {
                return NotFound("Capstone Not Found");
            }
            return Ok(capstone);
        }


        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CapstoneGenerator.Server.Models.Capstones capstones)
        {
            await capstoneServices.AddCapstones(capstones);
            return CreatedAtAction(nameof(GetById), new { id = capstones.CapstoneId.ToString() }, capstones);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, CapstoneGenerator.Server.Models.Capstones capstones)
        {
            try
            {
                var existingCapstone = await capstoneServices.GetCapstonesById(id);
                if (existingCapstone == null)
                {
                    return NotFound("Capstone Not Found");
                }

                existingCapstone.Title = capstones.Title;
                existingCapstone.Description = capstones.Description;
                existingCapstone.Categories = capstones.Categories;
                existingCapstone.CreatedBy = capstones.CreatedBy;

                await capstoneServices.UpdateCapstones(id, existingCapstone);
                return Ok(existingCapstone);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            try
            {
                var capstone = await capstoneServices.GetCapstonesById(id);
                if (capstone == null)
                {
                    return NotFound("Capstone Not Found");
                }

                await capstoneServices.RemoveCapstones(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
