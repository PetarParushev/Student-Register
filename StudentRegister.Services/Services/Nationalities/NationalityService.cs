using Microsoft.EntityFrameworkCore;
using StudentRegister.Data.Context;
using StudentRegister.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Services.Services.Nationalities
{
    public class NationalityService : INationalityService
    {
        private readonly StudentRegisterDBContext context;

        public NationalityService(StudentRegisterDBContext context)
        {
            this.context = context;
        }

        public async Task CreateNationality(Nationality nationality)
        {
            await context.Nationalities.AddAsync(nationality);
            await context.SaveChangesAsync();
        }

        public async Task DeleteNationality(int id)
        {
            context.Nationalities.Remove(context.Nationalities.Find(id));
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Nationality>> GetAllNationalities(string query)
        {
            var nationalities = await context.Nationalities.ToListAsync();
            if (!String.IsNullOrEmpty(query))
            {
                nationalities = nationalities.Where(n => n.Title.ToLower().Contains(query.ToLower())).ToList();
            }
            return nationalities;
        }

        public async Task<Nationality> GetNationality(int id)
        {
            var nationality = await context.Nationalities.FirstOrDefaultAsync(n => n.Id == id);
            return nationality;
        }

        public async Task<Nationality> UpdateNationality(Nationality nationality, int id)
        {
            var updatedNationality = await context.Nationalities.FirstOrDefaultAsync(n => n.Id == id);
            updatedNationality.Title = nationality.Title;
            updatedNationality.UpdatedOn = DateTime.Now;

            await context.SaveChangesAsync();
            return updatedNationality;
        }
    }
}
