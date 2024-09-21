using WareHouseApi.Models.Domain;

namespace WareHouseApi.Reponsitories.Implements
{
    public interface INhomSanPhamRepository
    {
        Task<IEnumerable<NhomSanPham>> GetAllAsync();
        Task<NhomSanPham> CreateAsync(NhomSanPham nhomSanPham);
        Task<NhomSanPham> UpdateAsync(NhomSanPham nhomSanPham);
        Task<NhomSanPham> DeleteAsync(int id);
        Task<NhomSanPham> GetByIdAsync(int id);

    }
}
