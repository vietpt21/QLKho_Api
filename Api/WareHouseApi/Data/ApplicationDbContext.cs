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
        public DbSet<NhomSanPham> nhomsanpham { get; set; }
        public DbSet<SanPham> san_pham { get; set; }
        public DbSet<NhapKho> nhap_kho { get; set; }
        public DbSet<NhapKhoCT> nhap_kho_ct { get; set; }
        public DbSet<XuatKho> xuat_kho { get; set; }
        public DbSet<XuatKhoCt> xuat_kho_ct { get; set; }
      
    }
}
