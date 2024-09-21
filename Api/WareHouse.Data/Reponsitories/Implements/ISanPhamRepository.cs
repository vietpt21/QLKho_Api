using WareHouseApi.Models.Domain;

namespace WareHouseApi.Reponsitories.Implements
{
    public interface ISanPhamRepository
    {
        Task<IEnumerable<SanPham>> GetAllAsync();
        Task<SanPham> CreateAsync(SanPham sanPham);
        Task<SanPham> UpdateAsync(SanPham sanPham);
        Task<SanPham> DeleteAsync(int id);
        Task<SanPham> GetByIdAsync(int id);

    }
}
