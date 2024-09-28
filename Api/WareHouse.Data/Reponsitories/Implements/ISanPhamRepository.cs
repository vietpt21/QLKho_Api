using WareHouseApi.Models.Domain;

namespace WareHouseApi.Reponsitories.Implements
{
    public interface ISanPhamRepository
    {
        Task<IEnumerable<SanPham>> GetAll();
        Task<SanPham> Create(SanPham sanPham); 
        Task<SanPham> Update(SanPham sanPham); 
        Task<SanPham> Delete(int id); 
        Task<SanPham> GetById(int id);
    }
}
