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
        public async Task<SanPham> CreateAsync(SanPham sanPham)
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
        public async Task<SanPham> DeleteAsync(int id)
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
        public async Task<IEnumerable<SanPham>> GetAllAsync()
        {
            try
            {
                return await dbContext.san_pham.Include(x=>x.NhomSanPhams).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return Enumerable.Empty<SanPham>();
            }
        }
        public async Task<SanPham> GetByIdAsync(int id)
        {
            return await dbContext.san_pham.Include(x => x.NhomSanPhams).FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<SanPham> UpdateAsync(SanPham sanPham)
        {
            var existing = await dbContext.san_pham.Include(x => x.NhomSanPhams).FirstOrDefaultAsync(x => x.id == sanPham.id);
            if (existing == null)
            {
                return null;
            }
            dbContext.Entry(existing).CurrentValues.SetValues(sanPham);
            existing.NhomSanPhams = sanPham.NhomSanPhams;

            await dbContext.SaveChangesAsync();

            return sanPham;


        }
    }
}
