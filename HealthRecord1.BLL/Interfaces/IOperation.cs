using HealthRecord1.BLL.Models;

namespace HealthRecord1.BLL.Interfaces;

public interface IOperation
{
    Task<IEnumerable<OperationVM>> GetAllAsync();
    Task<OperationVM?> GetByIdAsync(int id);
    Task CreateAsync(OperationVM operationVM);
    Task UpdateAsync(OperationVM operationVM);
    Task DeleteAsync(int id);
}
