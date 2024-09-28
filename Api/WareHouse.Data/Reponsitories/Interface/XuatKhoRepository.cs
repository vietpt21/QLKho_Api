using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WareHouse.Models.Domain;
using WareHouseApi.Data;
using WareHouseApi.Models.Domain;
using WareHouseApi.Reponsitories.Implements;

namespace WareHouseApi.Reponsitories.Interface
{
    public class XuatKhoRepository : IXuatKhoRepository
    {
        private readonly ApplicationDbContext dbContext;

        public XuatKhoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<XuatKho> Create(XuatKho xuatkho)
        {
            try
            {
                dbContext.xuat_kho.Add(xuatkho);
                await dbContext.SaveChangesAsync();
                return xuatkho;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating record: {ex.Message}");
                return null;
            }
        }
        public async Task<XuatKho> Delete(string id)
        {
            var existing = await dbContext.xuat_kho.FirstOrDefaultAsync(x => x.id == id);

            if (existing is null)
            {
                return null;
            }

            dbContext.xuat_kho.Remove(existing);
            await dbContext.SaveChangesAsync();
            return existing;
        }
      
        public async Task<string> GetXuatKhoDescAsync()
        {
            var lastId = await dbContext.nhap_kho
                              .AsNoTracking()
                              .OrderByDescending(x => x.id)
                              .Select(x => x.id)
                              .FirstOrDefaultAsync();

            return lastId;
        }

        public async Task<string> GenIdNhapKho()
        {
            string idOld = await GetXuatKhoDescAsync();
            string prefix = "NKH";
            string idNow = string.Empty;
            string datePart = DateTime.Now.ToString("yyMMdd");

            if (string.IsNullOrEmpty(idOld))
            {
                idNow = $"{prefix}{datePart}01";
            }
            else
            {
                string oldDatePart = idOld.Substring(3, 6);
                if (datePart != oldDatePart)
                {
                    idNow = $"{prefix}{datePart}01";
                }
                else
                {
                    idNow = GetNextId(idOld);
                }
            }

            return idNow;
        }

        private static string GetNextId(string currentId)
        {
            string prefix = "NKH";
            string datePart = currentId.Substring(3, 6);
            string sequentialPart = currentId.Substring(9);
            int sequentialNumber = int.Parse(sequentialPart);
            sequentialNumber++;
            string newSequentialPart = sequentialNumber.ToString("D2");

            return $"{prefix}{datePart}{newSequentialPart}";
        }


        public async Task<IEnumerable<XuatKho>> GetAll()
        {
            try
            {
                return await dbContext.xuat_kho.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return Enumerable.Empty<XuatKho>();
            }
        }

        public async Task<XuatKho> GetById(string id)
        {
            return await dbContext.xuat_kho.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<XuatKho> Update(XuatKho xuatkho)
        {
            var existing = await dbContext.xuat_kho.FirstOrDefaultAsync(x => x.id == xuatkho.id);
            if (existing == null)
            {
                return null;
            }

            dbContext.Entry(existing).CurrentValues.SetValues(xuatkho);
          
            await dbContext.SaveChangesAsync();
            return existing; 
        }
    }

}
