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
        MyContext db = new MyContext();

        public async Task CreateAsync(VaccinationVM obj)
        {
            Vaccination d = new Vaccination();
            d.VaccineName = obj.VaccineName;
            d.Manufacturer = obj.Manufacturer;
            d.StandardDoseCount = obj.StandardDoseCount;
            d.Description = obj.Description;
            d.IsActive = obj.IsActive;
            await db.Vaccinations.AddAsync(d);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var vaccination = await db.Vaccinations.FindAsync(id);
            if (vaccination != null)
            {
                db.Vaccinations.Remove(vaccination);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<VaccinationVM>> GetAllAsync()
        {
            var data = await db.Vaccinations.Select(a => new VaccinationVM
            {
                Id = a.Id,
                VaccineName = a.VaccineName,
                Manufacturer = a.Manufacturer,
                StandardDoseCount = a.StandardDoseCount,
                Description = a.Description,
                IsActive = a.IsActive
            }).ToListAsync();

            return data;
        }

        public async Task<VaccinationVM?> GetByIdAsync(int id)
        {
            var vaccination = await db.Vaccinations.FindAsync(id);
            if (vaccination == null) return null;
            return new VaccinationVM
            {
                Id = vaccination.Id,
                VaccineName = vaccination.VaccineName,
                Manufacturer = vaccination.Manufacturer,
                StandardDoseCount = vaccination.StandardDoseCount,
                Description = vaccination.Description,
                IsActive = vaccination.IsActive
            };
        }

        public async Task UpdateAsync(VaccinationVM vaccinationVM)
        {
            var vaccination = await db.Vaccinations.FindAsync(vaccinationVM.Id);
            if (vaccination != null)
            {
                vaccination.VaccineName = vaccinationVM.VaccineName;
                vaccination.Manufacturer = vaccinationVM.Manufacturer;
                vaccination.StandardDoseCount = vaccinationVM.StandardDoseCount;
                vaccination.Description = vaccinationVM.Description;
                vaccination.IsActive = vaccinationVM.IsActive;
                await db.SaveChangesAsync();
            }
        }
    }
}

