using HealthRecord1.BLL.Interfaces;
using HealthRecord1.BLL.Models;
using HealthRecord1.DAL.Database;
using HealthRecord1.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthRecord1.BLL.Repository
{
    public class ChronicDiseaseRepo : IChronicDisease
    {
        private readonly MyContext db;

        public ChronicDiseaseRepo(MyContext db)
        {
            this.db = db;
        }

        public async Task CreateAsync(ChronicDisease obj)
        {

            await db.ChronicDiseases.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(ChronicDisease obj)
        {
            db.Entry(obj).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<ChronicDisease>> GetAllAsync()
        {
            var data = await db.ChronicDiseases.ToListAsync();

            return data;
        }

        public async Task<ChronicDisease> GetByIdAsync(int id)
        {
            var data = await db.ChronicDiseases.Where(a => a.Id == id).FirstOrDefaultAsync();
            return data;
        }

        public async Task UpdateAsync(ChronicDisease obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
