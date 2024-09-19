using WareHouseApi.Models.Domain;

namespace WareHouseApi.Reponsitories.Implements
{
    public interface IKhoRepository
    {
        Task<IEnumerable<Kho>> GetAllKhoAsync();
        Task<Kho> CreateKhoAsync(Kho kho);
        Task<Kho> UpdateKhoAsync(Kho kho);
        Task<Kho> DeleteKhoAsync(Kho kho);
        Task<Kho> GetByIdKhoAsync(int id);

    }
}
