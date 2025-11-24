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
    public class ChronicDiseaseCardRepo : IChronicDiseaseCard
    {
        MyContext db = new MyContext();

        public Task<ChronicDiseaseCardVM> CreateAsync(ChronicDiseaseCardVM chronicDiseaseCardVM)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ChronicDiseaseCardVM>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ChronicDiseaseCardVM?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ChronicDiseaseCardVM chronicDiseaseCardVM)
        {
            throw new NotImplementedException();
        }
    }
}
