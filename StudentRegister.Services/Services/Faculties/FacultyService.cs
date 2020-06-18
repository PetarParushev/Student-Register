using Microsoft.EntityFrameworkCore;
using StudentRegister.Data.Context;
using StudentRegister.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Services.Services.Faculties
{
    public class FacultyService : IFacultyService
    {
        private readonly StudentRegisterDBContext context;

        public FacultyService(StudentRegisterDBContext context)
        {
            this.context = context;
        }

        public async Task CreateFaculty(Faculty faculty)
        {
            await context.Faculties.AddAsync(faculty);
            await context.SaveChangesAsync();
        }

        public async Task DeleteFaculty(int id)
        {
            context.Faculties.Remove(context.Faculties.Find(id));
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Faculty>> GetAllFaculties(string query)
        {
            var faculties = await context.Faculties.ToListAsync();
            if (!String.IsNullOrEmpty(query))
            {
                faculties = faculties.Where(f => f.Name.ToLower().Contains(query.ToLower())).ToList();
            }
            return faculties;       
        }

        public async Task<Faculty> GetFaculty(int id)
        {
            var faculty = await context.Faculties.FirstOrDefaultAsync(f => f.Id == id);
            return faculty;
        }

        public async Task<Faculty> UpdateFaculty(Faculty faculty, int id)
        {
            var updatedFaculty = await context.Faculties.FirstOrDefaultAsync(f => f.Id == id);
            updatedFaculty.Name = faculty.Name;
            updatedFaculty.City = faculty.City;
            updatedFaculty.Address = faculty.Address;
            updatedFaculty.UpdatedOn = DateTime.Now;

            await context.SaveChangesAsync();
            return updatedFaculty;
        }
    }
}
