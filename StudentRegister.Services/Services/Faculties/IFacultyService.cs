using StudentRegister.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Services.Services.Faculties
{
    public interface IFacultyService
    {
        Task<IEnumerable<Faculty>> GetAllFaculties(string query);
        Task<Faculty> GetFaculty(int id);
        Task CreateFaculty (Faculty faculty);
        Task<Faculty> UpdateFaculty(Faculty faculty, int id);
        Task DeleteFaculty(int id);
    }
}
