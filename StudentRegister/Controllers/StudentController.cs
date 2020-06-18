using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentRegister.Data.Entities;
using StudentRegister.Services.Services.Students;

namespace StudentRegister.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        // GET: api/Student
        [HttpGet]
        public async Task<IActionResult> GetAll(string query)
        {
            var students = await studentService.GetAllStudents(query);
            return Ok(students);
        }

        // GET: api/Student/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await studentService.GetStudent(id);
            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid View Model");
            }

            await studentService.CreateStudent(student);
            return StatusCode(201, "Student Created!");
        }

        // PUT: api/Student/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Student student)
        {
            if (ModelState.IsValid)
            {
                var updatedStudent = await studentService.UpdateStudent(student, id);
                if (updatedStudent != null)
                {
                    return Ok(updatedStudent);
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
                await studentService.DeleteStudent(id);
                return Ok("Student successfully deleted!");
            }
            catch (Exception)
            {
                return NotFound();
            }
        }
    }
}
