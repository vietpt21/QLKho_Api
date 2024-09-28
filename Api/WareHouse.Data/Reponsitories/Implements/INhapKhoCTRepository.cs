using WareHouse.Models.Domain;
using WareHouseApi.Models.Domain;

namespace WareHouseApi.Reponsitories.Implements
{
    public interface INhapKhoCTRepository
    {
        Task<IEnumerable<NhapKhoCT>> GetAll();
        Task<NhapKhoCT> Create(NhapKhoCT nhapKhoct);
        Task<NhapKhoCT> Update(NhapKhoCT nhapKhoct);
        Task<NhapKhoCT> Delete(int id);
        Task<NhapKhoCT> GetById(int id);
        Task<List<NhapKhoCT>> GetAllNhapKhoCTByNhapKhoId(string nhapKhoId);
    }
}
