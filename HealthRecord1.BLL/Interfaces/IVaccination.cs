using HealthRecord1.BLL.Models;
using HealthRecord1.DAL.Entities;

namespace HealthRecord1.BLL.Interfaces;

public interface IVaccination
{
    Task<IEnumerable<Vaccination>> GetAllAsync();
    Task<Vaccination> GetByIdAsync(int id);
    Task CreateAsync(Vaccination obj);
    Task UpdateAsync(Vaccination obj);
    Task DeleteAsync(Vaccination obj);
}
