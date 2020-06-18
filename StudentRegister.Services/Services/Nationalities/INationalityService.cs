using StudentRegister.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegister.Services.Services.Nationalities
{
    public interface INationalityService
    {
        Task<IEnumerable<Nationality>> GetAllNationalities(string query);
        Task<Nationality> GetNationality(int id);
        Task CreateNationality(Nationality nationality);
        Task<Nationality> UpdateNationality(Nationality nationality, int id);
        Task DeleteNationality(int id);
    }
}
