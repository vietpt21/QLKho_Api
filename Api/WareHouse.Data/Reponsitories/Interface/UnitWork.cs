using WareHouseApi.Data;
using WareHouseApi.Reponsitories.Implements;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace WareHouseApi.Reponsitories.Interface
{
    public class UnitWork : IUnitWork
    {
        private readonly ApplicationDbContext _db;
        public IKhoRepository khoRepository { get; private set; }
        public INCCRepository nccRepository { get; private set; }
        public INhomSanPhamRepository nhomSanPhamRepository { get; private set; }
        public ISanPhamRepository sanPhamRepository { get; private set; }
        public UnitWork(ApplicationDbContext db)
        {
            _db = db;
            khoRepository = new KhoRepository(_db);
            nccRepository = new NCCRepository(_db);
            nhomSanPhamRepository = new NhomSanPhamRepository(_db);
            sanPhamRepository = new SanPhamRepository(_db);
          
        }
    }
}
