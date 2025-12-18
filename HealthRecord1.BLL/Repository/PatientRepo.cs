using HealthRecord1.BLL.Interfaces;
using HealthRecord1.BLL.Models;
using HealthRecord1.DAL.Database;
using HealthRecord1.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HealthRecord1.BLL.Repository
{
    public class PatientRepo : IPatient
    {
        private readonly MyContext db;

        public PatientRepo(MyContext db)
        { 
            this.db = db;
        }

        public async Task CreateAsync(Patient obj)
        {
            await db.Patients.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Patient obj)
        {
            // Soft Delete: Mark as deleted instead of removing from database
            var patient = await db.Patients.IgnoreQueryFilters().FirstOrDefaultAsync(p => p.Id == obj.Id);
            if (patient != null)
            {
                patient.IsDeleted = true;
                db.Entry(patient).State = EntityState.Modified;
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Patient>> GetAllAsync(Expression<Func<Patient, bool>> filter = null)
        {
            if (filter == null)
                return await db.Patients.ToListAsync();
            else  
                return await db.Patients.Where(filter).ToListAsync();
           
        }

        public async Task<Patient> GetByIdAsync(int id, Expression<Func<Patient, bool>> filter = null)
        {
            IQueryable<Patient> query = db.Patients.Where(p => p.Id == id);

            if (filter != null)
            {
                query = query.Where(filter);
            }

            var patient = await query.FirstOrDefaultAsync();
            return patient;
        }

        public async Task UpdateAsync(Patient obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
