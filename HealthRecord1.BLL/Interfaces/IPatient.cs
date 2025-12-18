using HealthRecord1.BLL.Models;
using HealthRecord1.DAL.Entities;
using System.Linq.Expressions;

namespace HealthRecord1.BLL.Interfaces;

public interface IPatient
{
    Task<IEnumerable<Patient>> GetAllAsync(Expression<Func<Patient, bool>> filter = null);
    Task<Patient> GetByIdAsync(int id, Expression<Func<Patient, bool>> filter = null);
    Task CreateAsync(Patient obj);
    Task UpdateAsync(Patient obj);
    Task DeleteAsync(Patient obj);
}
