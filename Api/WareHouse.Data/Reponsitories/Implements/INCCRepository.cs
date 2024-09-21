using WareHouseApi.Models.Domain;

namespace WareHouseApi.Reponsitories.Implements
{
    public interface INCCRepository
    {
        Task<IEnumerable<NhaCC>> GetAllAsync();
        Task<NhaCC> CreateAsync(NhaCC ncc);
        Task<NhaCC> UpdateAsync(NhaCC ncc);
        Task<NhaCC> DeleteAsync(int id);
        Task<NhaCC> GetByIdAsync(int id);

    }
}
