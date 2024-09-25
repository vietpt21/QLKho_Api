using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WareHouseApi.Data;
using WareHouseApi.Models.Domain;
using WareHouseApi.Reponsitories.Implements;

namespace WareHouseApi.Reponsitories.Interface
{
    public class KhoRepository : IKhoRepository
    {
        private readonly ApplicationDbContext dbContext;
        public KhoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Kho> CreateAsync(Kho kho)
        {
            try
            {
                dbContext.kho.Add(kho);
                await dbContext.SaveChangesAsync();
                return kho;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating record: {ex.Message}");
                return null;
            }
        }
        public async Task<Kho> DeleteAsync(int id)
        {
            var existing = await dbContext.kho.FirstOrDefaultAsync(x => x.id == id);

            if (existing is null)
            {
                return null;
            }

            dbContext.kho.Remove(existing);
            await dbContext.SaveChangesAsync();
            return existing;
        }
        public async Task<IEnumerable<Kho>> GetAllAsync()
        {
            try
            {
                return await dbContext.kho.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return Enumerable.Empty<Kho>();
            }
        }
        public async Task<Kho> GetByIdAsync(int id)
        {
            return await dbContext.kho.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Kho> UpdateAsync(Kho kho)
        {
            var existing = await dbContext.kho.FirstOrDefaultAsync(x => x.id == kho.id);

            if (existing != null)
            {
                dbContext.Entry(existing).CurrentValues.SetValues(kho);
                await dbContext.SaveChangesAsync();
                return kho;
            }

            return null;
        }
    }
}
