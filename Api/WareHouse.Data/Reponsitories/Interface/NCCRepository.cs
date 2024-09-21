using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WareHouseApi.Data;
using WareHouseApi.Models.Domain;
using WareHouseApi.Reponsitories.Implements;

namespace WareHouseApi.Reponsitories.Interface
{
    public class NCCRepository : INCCRepository
    {
        private readonly ApplicationDbContext dbContext;
        public NCCRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<NhaCC> CreateAsync(NhaCC ncc)
        {
            try
            {
                dbContext.ncc.Add(ncc);
                await dbContext.SaveChangesAsync();
                return ncc;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating record: {ex.Message}");
                return null;
            }
        }
        public async Task<NhaCC> DeleteAsync(int id)
        {
            var existing = await dbContext.ncc.FirstOrDefaultAsync(x => x.id == id);

            if (existing is null)
            {
                return null;
            }

            dbContext.ncc.Remove(existing);
            await dbContext.SaveChangesAsync();
            return existing;
        }
        public async Task<IEnumerable<NhaCC>> GetAllAsync()
        {
            try
            {
                return await dbContext.ncc.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return Enumerable.Empty<NhaCC>();
            }
        }
        public async Task<NhaCC> GetByIdAsync(int id)
        {
            return await dbContext.ncc.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<NhaCC> UpdateAsync(NhaCC ncc)
        {
            var existing = await dbContext.ncc.FirstOrDefaultAsync(x => x.id == ncc.id);

            if (existing != null)
            {
                dbContext.Entry(existing).CurrentValues.SetValues(ncc);
                await dbContext.SaveChangesAsync();
                return ncc;
            }

            return null;
        }
    }
}
