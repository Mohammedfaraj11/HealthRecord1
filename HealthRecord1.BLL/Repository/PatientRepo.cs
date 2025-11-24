using HealthRecord1.BLL.Interfaces;
using HealthRecord1.BLL.Models;
using HealthRecord1.DAL.Database;
using HealthRecord1.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthRecord1.BLL.Repository
{
    public class PatientRepo : IPatient
    {
        MyContext db = new MyContext();

        public async Task<PatientVM> CreateAsync(PatientVM patientVM)
        {
            Patient p = new Patient
            {
                FirstName = patientVM.FirstName,
                LastName = patientVM.LastName,
                DateOfBirth = patientVM.DateOfBirth,
                Gender = patientVM.Gender,
                PhoneNumber = patientVM.PhoneNumber,
                Email = patientVM.Email,
                Address = patientVM.Address,
                CreationDate = patientVM.CreationDate,
                BloodType = patientVM.BloodType,
                MedicalHistory = patientVM.MedicalHistory,
                Allergies = patientVM.Allergies,
                Notes = patientVM.Notes,
                PhoneNumber2 = patientVM.PhoneNumber2,
                IsActive = patientVM.IsActive
            };
            await db.Patients.AddAsync(p);
            await db.SaveChangesAsync();
            patientVM.Id = p.Id;
            return patientVM;
        }

        public async Task DeleteAsync(int id)
        {
            var patient = await db.Patients.FindAsync(id);
            if (patient != null)
            {
                db.Patients.Remove(patient);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<PatientVM>> GetAllAsync()
        {
            var data = await db.Patients.Select(a => new PatientVM
            {
                Id = a.Id,
                FirstName = a.FirstName,
                LastName = a.LastName,
                DateOfBirth = a.DateOfBirth,
                Gender = a.Gender,
                PhoneNumber = a.PhoneNumber,
                Email = a.Email,
                Address = a.Address,
                CreationDate = a.CreationDate,
                BloodType = a.BloodType,
                MedicalHistory = a.MedicalHistory,
                Allergies = a.Allergies,
                Notes = a.Notes,
                PhoneNumber2 = a.PhoneNumber2,
                IsActive = a.IsActive
            }).ToListAsync();

            return data;
        }

        public async Task<PatientVM?> GetByIdAsync(int id)
        {
            var patient = await db.Patients.FindAsync(id);
            if (patient == null) return null;
            return new PatientVM
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                DateOfBirth = patient.DateOfBirth,
                Gender = patient.Gender,
                PhoneNumber = patient.PhoneNumber,
                Email = patient.Email,
                Address = patient.Address,
                CreationDate = patient.CreationDate,
                BloodType = patient.BloodType,
                MedicalHistory = patient.MedicalHistory,
                Allergies = patient.Allergies,
                Notes = patient.Notes,
                PhoneNumber2 = patient.PhoneNumber2,
                IsActive = patient.IsActive
            };
        }

        public async Task UpdateAsync(PatientVM patientVM)
        {
            var patient = await db.Patients.FindAsync(patientVM.Id);
            if (patient != null)
            {
                patient.FirstName = patientVM.FirstName;
                patient.LastName = patientVM.LastName;
                patient.DateOfBirth = patientVM.DateOfBirth;
                patient.Gender = patientVM.Gender;
                patient.PhoneNumber = patientVM.PhoneNumber;
                patient.Email = patientVM.Email;
                patient.Address = patientVM.Address;
                patient.CreationDate = patientVM.CreationDate;
                patient.BloodType = patientVM.BloodType;
                patient.MedicalHistory = patientVM.MedicalHistory;
                patient.Allergies = patientVM.Allergies;
                patient.Notes = patientVM.Notes;
                patient.PhoneNumber2 = patientVM.PhoneNumber2;
                patient.IsActive = patientVM.IsActive;
                await db.SaveChangesAsync();
            }
        }
    }
}
