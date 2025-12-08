using HealthRecord1.BLL.Models;
using HealthRecord1.DAL.Entities;

namespace HealthRecord1.BLL.Interfaces;

public interface IOperation
{
    Task<IEnumerable<Operation>> GetAllAsync();
    Task<Operation> GetByIdAsync(int id);
    Task CreateAsync(Operation obj);
    Task UpdateAsync(Operation obj);
    Task DeleteAsync(Operation obj);
}
