using WareHouse.Models.Domain;
using WareHouseApi.Models.Domain;

namespace WareHouseApi.Reponsitories.Implements
{
    public interface INhapKhoRepository
    {
        Task<IEnumerable<NhapKho>> GetAll(); 
        Task<NhapKho> Create(NhapKho nhapKho);
        Task<NhapKho> Update(NhapKho nhapKho);
        Task<NhapKho> Delete(string id);
        Task<NhapKho> GetById(string id);
        Task<string> GenIdNhapKho();
    }
}
