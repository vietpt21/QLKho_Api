using WareHouse.Models.Domain;
using WareHouseApi.Models.Domain;

namespace WareHouseApi.Reponsitories.Implements
{
    public interface IXuatKhoCTRepository
    {
        Task<IEnumerable<XuatKhoCT>> GetAll();
        Task<XuatKhoCT> Create(XuatKhoCT xuatKhoct);
        Task<XuatKhoCT> Update(XuatKhoCT xuatKhoct);
        Task<XuatKhoCT> Delete(int id);
        Task<XuatKhoCT> GetById(int id);
        Task<List<XuatKhoCT>> GetAllXuatKhoCTByXuatKhoId(string xuatKhoId);
    }
}
