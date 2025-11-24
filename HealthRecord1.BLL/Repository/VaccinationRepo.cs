using HealthRecord1.BLL.Interfaces;
using HealthRecord1.BLL.Models;
using HealthRecord1.DAL.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthRecord1.BLL.Repository
{
    public class VaccinationRepo : IVaccination
    {
        MyContext db = new MyContext();

        public Task<VaccinationVM> CreateAsync(VaccinationVM vaccinationVM)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VaccinationVM>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<VaccinationVM?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(VaccinationVM vaccinationVM)
        {
            throw new NotImplementedException();
        }
    }
}
