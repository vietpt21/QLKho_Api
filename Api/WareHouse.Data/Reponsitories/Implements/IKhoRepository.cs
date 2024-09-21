using WareHouseApi.Models.Domain;

namespace WareHouseApi.Reponsitories.Implements
{
    public interface IKhoRepository
    {
        Task<IEnumerable<Kho>> GetAllAsync();
        Task<Kho> CreateAsync(Kho kho);
        Task<Kho> UpdateAsync(Kho kho);
        Task<Kho> DeleteAsync(int id);
        Task<Kho> GetByIdAsync(int id);

    }
}
