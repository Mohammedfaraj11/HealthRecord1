using HealthRecord1.BLL.Models;

namespace HealthRecord1.BLL.Interfaces;

public interface IVaccinationCard
{
    Task<IEnumerable<VaccinationCardVM>> GetAllAsync();
    Task<VaccinationCardVM?> GetByIdAsync(int id);
    Task<VaccinationCardVM> CreateAsync(VaccinationCardVM vaccinationCardVM);
    Task UpdateAsync(VaccinationCardVM vaccinationCardVM);
    Task DeleteAsync(int id);
}
