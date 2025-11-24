using HealthRecord1.BLL.Models;

namespace HealthRecord1.BLL.Interfaces;

public interface IChronicDiseaseCard
{
    Task<IEnumerable<ChronicDiseaseCardVM>> GetAllAsync();
    Task<ChronicDiseaseCardVM?> GetByIdAsync(int id);
    Task<ChronicDiseaseCardVM> CreateAsync(ChronicDiseaseCardVM chronicDiseaseCardVM);
    Task UpdateAsync(ChronicDiseaseCardVM chronicDiseaseCardVM);
    Task DeleteAsync(int id);
}
