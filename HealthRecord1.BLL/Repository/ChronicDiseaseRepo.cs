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
    public class ChronicDiseaseRepo : IChronicDisease
    {
        MyContext db = new MyContext();

        public Task<ChronicDiseaseVM> CreateAsync(ChronicDiseaseVM chronicDiseaseVM)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ChronicDiseaseVM>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<ChronicDiseaseVM?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(ChronicDiseaseVM chronicDiseaseVM)
        {
            throw new NotImplementedException();
        }
    }
}
