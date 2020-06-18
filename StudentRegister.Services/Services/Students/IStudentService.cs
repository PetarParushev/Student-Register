using StudentRegister.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Services.Services.Students
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudents(string query);
        Task<Student> GetStudent(int id);
        Task CreateStudent(Student student);
        Task<Student> UpdateStudent(Student student, int id);
        Task DeleteStudent(int id);
    }
}
