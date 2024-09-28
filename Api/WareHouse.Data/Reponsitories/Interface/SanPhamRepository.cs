using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WareHouseApi.Data;
using WareHouseApi.Models.Domain;
using WareHouseApi.Reponsitories.Implements;

namespace WareHouseApi.Reponsitories.Interface
{
    public class SanPhamRepository : ISanPhamRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SanPhamRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<SanPham> Create(SanPham sanPham)
        {
            try
            {
                dbContext.san_pham.Add(sanPham);
                await dbContext.SaveChangesAsync();
                return sanPham;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating record: {ex.Message}");
                return null;
            }
        }

        public async Task<SanPham> Delete(int id)
        {
            var existing = await dbContext.san_pham.FirstOrDefaultAsync(x => x.id == id);

            if (existing is null)
            {
                return null;
            }

            dbContext.san_pham.Remove(existing);
            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<IEnumerable<SanPham>> GetAll()
        {
            try
            {
                return await dbContext.san_pham.Include(x => x.NhomSanPham).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return Enumerable.Empty<SanPham>();
            }
        }

        public async Task<SanPham> GetById(int id)
        {
            return await dbContext.san_pham.FirstOrDefaultAsync(x => x.id == id);
        }
        public async Task<SanPham> Update(SanPham sanPham)
        {
            var existing = await dbContext.san_pham.FirstOrDefaultAsync(x => x.id == sanPham.id);
            if (existing == null)
            {
                return null;
            }
            dbContext.Entry(existing).CurrentValues.SetValues(sanPham);

            await dbContext.SaveChangesAsync();
            return existing;
        }

    }

}
