using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegister.Data.Entities;
using StudentRegister.Services.Services.Nationalities;

namespace StudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class NationalityController : ControllerBase
    {
        private readonly INationalityService nationalityService;

        public NationalityController(INationalityService nationalityService)
        {
            this.nationalityService = nationalityService;
        }

        // GET: api/Nationality
        [HttpGet]
        public async Task<IActionResult> GetAll (string query)
        {
            var nationalities = await nationalityService.GetAllNationalities(query);
            return Ok(nationalities);
        }

        // GET: api/Nationality/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var nationality = await nationalityService.GetNationality(id);
            return Ok(nationality);
        }

        // POST: api/Nationality
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Nationality nationality)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid View Model");
            }

            await nationalityService.CreateNationality(nationality);
            return StatusCode(201, "Nationality Created!");
        }

        // PUT: api/Nationality/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Nationality nationality)
        {
            if (ModelState.IsValid)
            {
                var updatedNationality = await nationalityService.UpdateNationality(nationality, id);
                if (updatedNationality != null)
                {
                    return Ok(updatedNationality);
                }
                else
                {
                    return BadRequest("Invalid ID!");
                }
            }
            return BadRequest();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await nationalityService.DeleteNationality(id);
                return Ok("Nationality successfully deleted!");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
