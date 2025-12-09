using HealthRecord1.BLL.Interfaces;
using HealthRecord1.BLL.Models;
using HealthRecord1.DAL.Database;
using HealthRecord1.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecord1.BLL.Repository
{
    public class VaccinationRepo : IVaccination
    {
        private readonly MyContext db;

        public VaccinationRepo(MyContext db)
        {
            this.db = db;
        }
        public async Task CreateAsync(Vaccination obj)
        {

            await db.Vaccinations.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Vaccination obj)
        {
            db.Entry(obj).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Vaccination>> GetAllAsync()
        {
            var data = await db.Vaccinations.ToListAsync();

            return data;
        }

        public async Task<Vaccination> GetByIdAsync(int id)
        {
            var data = await db.Vaccinations.Where(a => a.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task UpdateAsync(Vaccination obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}

