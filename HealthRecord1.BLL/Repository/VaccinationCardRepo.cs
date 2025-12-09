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
    public class VaccinationCardRepo : IVaccinationCard
    {
        private readonly MyContext db;

        public VaccinationCardRepo(MyContext db)
        {
            this.db = db;
        }


        public Task<VaccinationCardVM> CreateAsync(VaccinationCardVM vaccinationCardVM)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<VaccinationCardVM>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<VaccinationCardVM?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(VaccinationCardVM vaccinationCardVM)
        {
            throw new NotImplementedException();
        }
    }
}
