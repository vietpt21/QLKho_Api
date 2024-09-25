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

        public SanPham Create(SanPham sanPham)
        {
            try
            {
                dbContext.san_pham.Add(sanPham);
                dbContext.SaveChanges();
                return sanPham;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating record: {ex.Message}");
                return null;
            }
        }

        public SanPham Delete(int id)
        {
            var existing = dbContext.san_pham.FirstOrDefault(x => x.id == id);

            if (existing is null)
            {
                return null;
            }

            dbContext.san_pham.Remove(existing);
            dbContext.SaveChanges(); // Gọi SaveChanges đồng bộ
            return existing;
        }

        public IEnumerable<SanPham> GetAll()
        {
            try
            {
                return dbContext.san_pham.Include(x => x.NhomSanPham).ToList(); // Gọi ToList đồng bộ
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return Enumerable.Empty<SanPham>();
            }
        }

        public SanPham GetById(int id)
        {
            return dbContext.san_pham.Include(x => x.NhomSanPham).FirstOrDefault(x => x.id == id); // Gọi FirstOrDefault đồng bộ
        }

        public SanPham Update(SanPham sanPham)
        {
            var existing = dbContext.san_pham.Include(x => x.NhomSanPham).FirstOrDefault(x => x.id == sanPham.id);
            if (existing == null)
            {
                return null;
            }
            dbContext.Entry(existing).CurrentValues.SetValues(sanPham);
            existing.NhomSanPham = sanPham.NhomSanPham;

            dbContext.SaveChanges(); // Gọi SaveChanges đồng bộ

            return sanPham;
        }
    }

}
