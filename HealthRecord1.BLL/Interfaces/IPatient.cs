using HealthRecord1.BLL.Models;

namespace HealthRecord1.BLL.Interfaces;

public interface IPatient
{
    Task<IEnumerable<PatientVM>> GetAllAsync();
    Task<PatientVM?> GetByIdAsync(int id);
    Task<PatientVM> CreateAsync(PatientVM patientVM);
    Task UpdateAsync(PatientVM patientVM);
    Task DeleteAsync(int id);
}
