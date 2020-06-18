using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegister.Data.Entities;
using StudentRegister.Services.Services.Faculties;

namespace StudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class FacultyController : ControllerBase
    {
        private readonly IFacultyService facultyService;

        public FacultyController(IFacultyService facultyService)
        {
            this.facultyService = facultyService;
        }

        // GET: api/Faculty
        [HttpGet]
        public async Task<IActionResult> GetAll(string query)
        {
            var faculties = await facultyService.GetAllFaculties(query);
            return Ok(faculties);
        }

        // GET: api/Faculty/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var faculty = await facultyService.GetFaculty(id);
            return Ok(faculty);
        }

        // POST: api/Faculty
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Faculty faculty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid View Model");
            }

            await facultyService.CreateFaculty(faculty);
            return StatusCode(201, "Faculty Created!");
        }

        // PUT: api/Faculty/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Faculty faculty)
        {
            if (ModelState.IsValid)
            {
                var updatedFaculty = await facultyService.UpdateFaculty(faculty, id);
                if (updatedFaculty != null)
                {
                    return Ok(updatedFaculty);
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
                await facultyService.DeleteFaculty(id);
                return Ok("Faculty successfully deleted!");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
