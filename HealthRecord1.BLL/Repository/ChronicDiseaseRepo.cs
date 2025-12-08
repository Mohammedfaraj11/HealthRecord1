using HealthRecord1.BLL.Interfaces;
using HealthRecord1.BLL.Models;
using HealthRecord1.DAL.Database;
using HealthRecord1.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthRecord1.BLL.Repository
{
    public class ChronicDiseaseRepo : IChronicDisease
    {
        MyContext db = new MyContext();

        public async Task CreateAsync(ChronicDiseaseVM chronicDiseaseVM)
        {
            ChronicDisease cd = new ChronicDisease();
            cd.Name = chronicDiseaseVM.Name;
            cd.Description = chronicDiseaseVM.Description;
            cd.Notes = chronicDiseaseVM.Notes;
            cd.SeverityScale = chronicDiseaseVM.SeverityScale;
            cd.IsActive = chronicDiseaseVM.IsActive;
            cd.ICD10Code = chronicDiseaseVM.ICD10Code;
            await db.ChronicDiseases.AddAsync(cd);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var chronicDisease = await db.ChronicDiseases.FindAsync(id);
            if (chronicDisease != null)
            {
                db.ChronicDiseases.Remove(chronicDisease);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ChronicDiseaseVM>> GetAllAsync()
        {
            var data = await db.ChronicDiseases.Select(a => new ChronicDiseaseVM
            {
                Id = a.Id,
                Name = a.Name,
                Description = a.Description,
                Notes = a.Notes,
                SeverityScale = a.SeverityScale,
                IsActive = a.IsActive,
                ICD10Code = a.ICD10Code
            }).ToListAsync();

            return data;
        }

        public async Task<ChronicDiseaseVM?> GetByIdAsync(int id)
        {
            var chronicDisease = await db.ChronicDiseases.FindAsync(id);
            if (chronicDisease == null) return null;
            return new ChronicDiseaseVM
            {
                Id = chronicDisease.Id,
                Name = chronicDisease.Name,
                Description = chronicDisease.Description,
                Notes = chronicDisease.Notes,
                SeverityScale = chronicDisease.SeverityScale,
                IsActive = chronicDisease.IsActive,
                ICD10Code = chronicDisease.ICD10Code
            };
        }

        public async Task UpdateAsync(ChronicDiseaseVM chronicDiseaseVM)
        {
            var chronicDisease = await db.ChronicDiseases.FindAsync(chronicDiseaseVM.Id);
            if (chronicDisease != null)
            {
                chronicDisease.Name = chronicDiseaseVM.Name;
                chronicDisease.Description = chronicDiseaseVM.Description;
                chronicDisease.Notes = chronicDiseaseVM.Notes;
                chronicDisease.SeverityScale = chronicDiseaseVM.SeverityScale;
                chronicDisease.IsActive = chronicDiseaseVM.IsActive;
                chronicDisease.ICD10Code = chronicDiseaseVM.ICD10Code;
                await db.SaveChangesAsync();
            }
        }

        public async Task<bool> IsICD10CodeUniqueAsync(string code, int? excludeId = null)
        {
            return !await db.ChronicDiseases.AnyAsync(c => c.ICD10Code == code && (excludeId == null || c.Id != excludeId));
        }
    }
}
