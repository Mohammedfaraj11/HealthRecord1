using HealthRecord1.BLL.Models;
using HealthRecord1.DAL.Entities;

namespace HealthRecord1.BLL.Interfaces;

public interface IChronicDisease
{
    Task<IEnumerable<ChronicDisease>> GetAllAsync();
    Task<ChronicDisease> GetByIdAsync(int id);
    Task CreateAsync(ChronicDisease obj);
    Task UpdateAsync(ChronicDisease obj);
    Task DeleteAsync(ChronicDisease obj);
}
