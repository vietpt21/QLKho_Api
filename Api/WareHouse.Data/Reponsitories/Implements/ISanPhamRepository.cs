using WareHouseApi.Models.Domain;

namespace WareHouseApi.Reponsitories.Implements
{
    public interface ISanPhamRepository
    {
        IEnumerable<SanPham> GetAll(); // Không còn async
        SanPham Create(SanPham sanPham); // Không còn async
        SanPham Update(SanPham sanPham); // Không còn async
        SanPham Delete(int id); // Không còn async
        SanPham GetById(int id);
    }
}
