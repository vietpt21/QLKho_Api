using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WareHouse.Models.Domain;
using WareHouseApi.Data;
using WareHouseApi.Models.Domain;
using WareHouseApi.Reponsitories.Implements;

namespace WareHouseApi.Reponsitories.Interface
{
    public class NhapKhoCTRepository : INhapKhoCTRepository
    {
        private readonly ApplicationDbContext dbContext;

        public NhapKhoCTRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<NhapKhoCT> Create(NhapKhoCT nhapKhoct)
        {
            try
            {
                dbContext.nhap_kho_ct.Add(nhapKhoct);
                await dbContext.SaveChangesAsync(); 
                return nhapKhoct;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating record: {ex.Message}");
                return null;
            }
        }


        public async Task<NhapKhoCT> Delete(int id)
        {
            var existing = await dbContext.nhap_kho_ct.FirstOrDefaultAsync(x => x.id == id);

            if (existing is null)
            {
                return null;
            }

            dbContext.nhap_kho_ct.Remove(existing);
            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<IEnumerable<NhapKhoCT>> GetAll()
        {
            try
            {
                return await dbContext.nhap_kho_ct.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return Enumerable.Empty<NhapKhoCT>();
            }
        }

        public async Task<NhapKhoCT> GetById(int id)
        {
            return await dbContext.nhap_kho_ct.FirstOrDefaultAsync(x => x.id == id);
        }
        public async Task<List<NhapKhoCT>> GetAllNhapKhoCTByNhapKhoId(string nhapKhoId)
        {
            return await dbContext.nhap_kho_ct
                .Where(nkct => nkct.nhap_kho_id == nhapKhoId)
                .ToListAsync();
        }
        public async Task<NhapKhoCT> Update(NhapKhoCT nhapKhoct)
        {
            var existing = await dbContext.nhap_kho_ct.FirstOrDefaultAsync(x => x.id == nhapKhoct.id);
            if (existing == null)
            {
                return null;
            }

            dbContext.Entry(existing).CurrentValues.SetValues(nhapKhoct);
            await dbContext.SaveChangesAsync();
            return existing; // Hoặc trả về nhapKhoct nếu bạn muốn
        }

    }

}
