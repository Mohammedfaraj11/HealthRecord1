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
    public class OperationRepo : IOperation
    {
        MyContext db = new MyContext();

        public async Task CreateAsync(OperationVM obj)
        {
            Operation d = new Operation();
            d.Name = obj.Name;
            d.Date = obj.Date;
            d.CreationDate = obj.CreationDate;
            d.Notes = obj.Notes;
            d.Duration = obj.Duration;
            d.Surgeon = obj.Surgeon;
            d.MedicalTeam = obj.MedicalTeam;
            d.PatientId = obj.PatientId;
            await db.Operations.AddAsync(d);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var operation = await db.Operations.FindAsync(id);
            if (operation != null)
            {
                db.Operations.Remove(operation);
                await db.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<OperationVM>> GetAllAsync()
        {
            var data = await db.Operations.Select(a => new OperationVM
            {
                Id = a.Id,
                Name = a.Name,
                Date = a.Date,
                CreationDate = a.CreationDate,
                Notes = a.Notes,
                Duration = a.Duration,
                Surgeon = a.Surgeon,
                MedicalTeam = a.MedicalTeam,
                PatientId = a.PatientId
            }).ToListAsync();

            return data;
        }

        public async Task<OperationVM?> GetByIdAsync(int id)
        {
            var operation = await db.Operations.FindAsync(id);
            if (operation == null) return null;
            return new OperationVM
            {
                Id = operation.Id,
                Name = operation.Name,
                Date = operation.Date,
                CreationDate = operation.CreationDate,
                Notes = operation.Notes,
                Duration = operation.Duration,
                Surgeon = operation.Surgeon,
                MedicalTeam = operation.MedicalTeam,
                PatientId = operation.PatientId
            };
        }

        public async Task UpdateAsync(OperationVM operationVM)
        {
            var operation = await db.Operations.FindAsync(operationVM.Id);
            if (operation != null)
            {
                operation.Name = operationVM.Name;
                operation.Date = operationVM.Date;
                operation.Notes = operationVM.Notes;
                operation.Duration = operationVM.Duration;
                operation.Surgeon = operationVM.Surgeon;
                operation.MedicalTeam = operationVM.MedicalTeam;
                operation.PatientId = operationVM.PatientId;
                await db.SaveChangesAsync();
            }
        }
    }
}
