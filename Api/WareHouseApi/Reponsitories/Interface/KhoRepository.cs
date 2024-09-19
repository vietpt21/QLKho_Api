using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using WareHouseApi.Data;
using WareHouseApi.Models.Domain;
using WareHouseApi.Reponsitories.Implements;

namespace WareHouseApi.Reponsitories.Interface
{
    public class KhoRepository : IKhoRepository
    {
        private readonly ApplicationDbContext dbContext;
        public KhoRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Kho> CreateKhoAsync(Kho kho)
        {
            await dbContext.kho.AddAsync(kho);
            await dbContext.SaveChangesAsync();

            return kho;
        }
        public async Task<Kho> DeleteKhoAsync(Kho kho)
        {
            var sql = @"DELETE FROM kho WHERE id = @id";

            using (var connection = dbContext.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    command.Parameters.Add(new SqlParameter("@id", kho.id));

                    await command.ExecuteNonQueryAsync();
                }
            }

            return kho;
        }
        public async Task<IEnumerable<Kho>> GetAllKhoAsync()
        {
            try
            {
                return await dbContext.kho.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log the exception (sử dụng logger của bạn)
                // Nếu bạn có logger, bạn có thể sử dụng nó để ghi log
                Console.WriteLine($"Error fetching data: {ex.Message}");

                // Bạn có thể trả về null hoặc một danh sách rỗng tùy theo yêu cầu
                return Enumerable.Empty<Kho>();
            }
        }
        public async Task<Kho> GetByIdKhoAsync(int id)
        {
            Kho kho = null;
            var sql = @"SELECT * FROM kho WHERE id = @id";

            using (var connection = dbContext.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    command.Parameters.Add(new SqlParameter("@id", id));

                    using (var reader = await command.ExecuteReaderAsync())
                    {
                        if (await reader.ReadAsync())
                        {
                            kho = new Kho
                            {
                                id = reader.GetInt32(reader.GetOrdinal("id")),
                                ten_kho = reader.GetString(reader.GetOrdinal("ten_kho")),
                                hien_thi = reader.GetString(reader.GetOrdinal("hien_thi")),
                                ghi_chu = reader.GetString(reader.GetOrdinal("ghi_chu")),
                                nguoi_tao = reader.GetString(reader.GetOrdinal("nguoi_tao")),
                                ngay_tao = reader.GetDateTime(reader.GetOrdinal("ngay_tao")),
                                cap_nhat = reader.GetDateTime(reader.GetOrdinal("cap_nhat")),
                            };
                        }
                    }
                }
            }

            return kho;
        }

        public async Task<Kho> UpdateKhoAsync(Kho kho)
        {
            var sql = @"UPDATE kho
                    SET ten_kho = @ten_kho,
                        hien_thi = @hien_thi,
                        ghi_chu = @ghi_chu,
                        nguoi_tao = @nguoi_tao,
                        cap_nhat = @cap_nhat
                    WHERE id = @id";

            using (var connection = dbContext.Database.GetDbConnection())
            {
                await connection.OpenAsync();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = sql;
                    command.Parameters.Add(new SqlParameter("@id", kho.id));
                    command.Parameters.Add(new SqlParameter("@ten_kho", kho.ten_kho));
                    command.Parameters.Add(new SqlParameter("@hien_thi", kho.hien_thi));
                    command.Parameters.Add(new SqlParameter("@ghi_chu", kho.ghi_chu));
                    command.Parameters.Add(new SqlParameter("@nguoi_tao", kho.nguoi_tao));
                    command.Parameters.Add(new SqlParameter("@cap_nhat", DateTime.Now));

                    await command.ExecuteNonQueryAsync();
                }
            }

            return kho;
        }
    }
}
