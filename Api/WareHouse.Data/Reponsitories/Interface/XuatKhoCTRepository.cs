using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WareHouse.Models.Domain;
using WareHouseApi.Data;
using WareHouseApi.Models.Domain;
using WareHouseApi.Reponsitories.Implements;

namespace WareHouseApi.Reponsitories.Interface
{
    public class XuatKhoCTRepository : IXuatKhoCTRepository
    {
        private readonly ApplicationDbContext dbContext;

        public XuatKhoCTRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<XuatKhoCT> Create(XuatKhoCT xuatKhoct)
        {
            try
            {
                dbContext.xuat_kho_ct.Add(xuatKhoct);
                await dbContext.SaveChangesAsync(); 
                return xuatKhoct;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating record: {ex.Message}");
                return null;
            }
        }


        public async Task<XuatKhoCT> Delete(int id)
        {
            var existing = await dbContext.xuat_kho_ct.FirstOrDefaultAsync(x => x.id == id);

            if (existing is null)
            {
                return null;
            }

            dbContext.xuat_kho_ct.Remove(existing);
            await dbContext.SaveChangesAsync();
            return existing;
        }

        public async Task<IEnumerable<XuatKhoCT>> GetAll()
        {
            try
            {
                return await dbContext.xuat_kho_ct.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return Enumerable.Empty<XuatKhoCT>();
            }
        }

        public async Task<XuatKhoCT> GetById(int id)
        {
            return await dbContext.xuat_kho_ct.FirstOrDefaultAsync(x => x.id == id);
        }
        public async Task<List<XuatKhoCT>> GetAllXuatKhoCTByXuatKhoId(string xuatKhoId)
        {
            return await dbContext.xuat_kho_ct
                .Where(nkct => nkct.xuat_kho_id == xuatKhoId)
                .ToListAsync();
        }
        public async Task<XuatKhoCT> Update(XuatKhoCT xuatKhoct)
        {
            var existing = await dbContext.xuat_kho_ct.FirstOrDefaultAsync(x => x.id == xuatKhoct.id);
            if (existing == null)
            {
                return null;
            }

            dbContext.Entry(existing).CurrentValues.SetValues(xuatKhoct);
            await dbContext.SaveChangesAsync();
            return existing; 
        }
    }

}
