using Microsoft.EntityFrameworkCore;
using WareHouseApi.Models.Domain;

namespace WareHouseApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Kho> kho { get; set; }
        public DbSet<NhaCC> ncc { get; set; }
        public DbSet<NhomSanPham> nhom_san_pham { get; set; }
        public DbSet<SanPham> san_pham { get; set; }
    }
}
