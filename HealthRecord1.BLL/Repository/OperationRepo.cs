using HealthRecord1.BLL.Interfaces;
using HealthRecord1.BLL.Models;
using HealthRecord1.DAL.Database;
using HealthRecord1.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace HealthRecord1.BLL.Repository
{
    public class OperationRepo : IOperation
    {
        private readonly MyContext db;

        public OperationRepo(MyContext db)
        { 
        this.db = db;
        }



        public async Task CreateAsync(Operation obj)
        {

            await db.Operations.AddAsync(obj);
            await db.SaveChangesAsync();
        }

        public async Task DeleteAsync(Operation obj)
        {
            db.Entry(obj).State = EntityState.Deleted;
            await db.SaveChangesAsync();
        }

        public async Task<IEnumerable<Operation>> GetAllAsync()
        {
            var data = await db.Operations.ToListAsync();

            return data;
        }

        public async Task<Operation> GetByIdAsync(int id)
        {
            var data = await db.Operations.Where(a=>a.id==id).FirstOrDefaultAsync();
            return data;
        }

        public async Task UpdateAsync(Operation obj)
        {
        db.Entry(obj).State = EntityState.Modified;
            await db.SaveChangesAsync();
        }
    }
}
