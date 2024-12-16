using WareHouse.Models.Domain;
using WareHouseApi.Models.Domain;

namespace WareHouseApi.Reponsitories.Implements
{
    public interface IXuatKhoRepository
    {
        Task<IEnumerable<XuatKho>> GetAll(); 
        Task<XuatKho> Create(XuatKho xuatKho);
        Task<XuatKho> Update(XuatKho xuatKho);
        Task<XuatKho> Delete(string id);
        Task<XuatKho> GetById(string id);
        Task<string> GenIdXuatKho();
    }
}
