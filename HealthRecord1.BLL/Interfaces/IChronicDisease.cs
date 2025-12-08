using HealthRecord1.BLL.Models;

namespace HealthRecord1.BLL.Interfaces;

public interface IChronicDisease
{
    Task<IEnumerable<ChronicDiseaseVM>> GetAllAsync();
    Task<ChronicDiseaseVM?> GetByIdAsync(int id);
    Task CreateAsync(ChronicDiseaseVM chronicDiseaseVM);
    Task UpdateAsync(ChronicDiseaseVM chronicDiseaseVM);
    Task DeleteAsync(int id);
    Task<bool> IsICD10CodeUniqueAsync(string code, int? excludeId = null);
}
