using Microsoft.EntityFrameworkCore;
using StudentRegister.Data.Context;
using StudentRegister.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Services.Services.Students
{
    public class StudentService : IStudentService
    {
        private readonly StudentRegisterDBContext context;

        public StudentService(StudentRegisterDBContext context)
        {
            this.context = context;
        }
        public async Task CreateStudent(Student student)
        {
            await context.Students.AddAsync(student);
            await context.SaveChangesAsync();
        }

        public async Task DeleteStudent(int id)
        {
            context.Students.Remove(context.Students.Find(id));
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Student>> GetAllStudents(string query)
        {
            var students = await context.Students.Include(s => s.Nationality)
                                                 .Include(s => s.Faculty).ToListAsync();
            if (!String.IsNullOrEmpty(query))
            {
                students = students.Where(s => s.FacultyNumber.ToString().Contains(query)).ToList();
            }
            return students;
        }

        public async Task<Student> GetStudent(int id)
        {
            var student = await context.Students.Include(s => s.Nationality)
                                                .Include(s => s.Faculty)
                                                .FirstOrDefaultAsync(s => s.Id == id);
            return student;
        }

        public async Task<Student> UpdateStudent(Student student, int id)
        {
            var updatedStudent = await context.Students.FirstOrDefaultAsync(s => s.Id == id);
            updatedStudent.FirstName = student.FirstName;
            updatedStudent.LastName = student.LastName;
            updatedStudent.FacultyNumber = student.FacultyNumber;
            updatedStudent.Faculty = student.Faculty;
            updatedStudent.FacultyId = student.FacultyId;
            updatedStudent.Nationality = student.Nationality;
            updatedStudent.NationalityId = student.NationalityId;
            updatedStudent.UpdatedOn = DateTime.Now;

            await context.SaveChangesAsync();
            return updatedStudent;
        }
    }
}
