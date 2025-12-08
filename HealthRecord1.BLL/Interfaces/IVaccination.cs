using HealthRecord1.BLL.Models;

namespace HealthRecord1.BLL.Interfaces;

public interface IVaccination
{
    Task<IEnumerable<VaccinationVM>> GetAllAsync();
    Task<VaccinationVM?> GetByIdAsync(int id);
    Task CreateAsync(VaccinationVM vaccinationVM);
    Task UpdateAsync(VaccinationVM vaccinationVM);
    Task DeleteAsync(int id);
}
