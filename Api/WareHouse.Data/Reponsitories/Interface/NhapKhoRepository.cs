using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WareHouse.Models.Domain;
using WareHouseApi.Data;
using WareHouseApi.Models.Domain;
using WareHouseApi.Reponsitories.Implements;

namespace WareHouseApi.Reponsitories.Interface
{
    public class NhapKhoRepository : INhapKhoRepository
    {
        private readonly ApplicationDbContext dbContext;

        public NhapKhoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<NhapKho> Create(NhapKho nhapKho)
        {
            try
            {
                dbContext.nhap_kho.Add(nhapKho);
                await dbContext.SaveChangesAsync();
                return nhapKho;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating record: {ex.Message}");
                return null;
            }
        }
        public async Task<NhapKho> Delete(string id)
        {
            var existing = await dbContext.nhap_kho.FirstOrDefaultAsync(x => x.id == id);

            if (existing is null)
            {
                return null;
            }

            dbContext.nhap_kho.Remove(existing);
            await dbContext.SaveChangesAsync();
            return existing;
        }
      
        public async Task<string> GetNhapKhoDescAsync()
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
            string idOld = await GetNhapKhoDescAsync();
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


        public async Task<IEnumerable<NhapKho>> GetAll()
        {
            try
            {
                return await dbContext.nhap_kho.Include(x => x.Kho).Include(x => x.Ncc).ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
                return Enumerable.Empty<NhapKho>();
            }
        }

        public async Task<NhapKho> GetById(string id)
        {
            return await dbContext.nhap_kho.Include(x => x.Kho).Include(x => x.Ncc).FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<NhapKho> Update(NhapKho nhapKho)
        {
            var existing = await dbContext.nhap_kho.Include(x => x.Kho).Include(x => x.Ncc).FirstOrDefaultAsync(x => x.id == nhapKho.id);
            if (existing == null)
            {
                return null;
            }

            dbContext.Entry(existing).CurrentValues.SetValues(nhapKho);
            existing.Ncc = nhapKho.Ncc;
            existing.Kho = nhapKho.Kho;
            await dbContext.SaveChangesAsync();
            return existing; // Hoặc trả về nhapKho nếu bạn muốn
        }
    }

}
