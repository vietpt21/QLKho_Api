using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WareHouseApi.Models.DTO;
using WareHouseApi.Reponsitories.Implements;

namespace WareHouseApi.Data
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoController : ControllerBase
    {
        private readonly IKhoRepository khoRepository;

        public KhoController(IKhoRepository khoRepository)
        {
            this.khoRepository = khoRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKho()
        {
            var kho = await khoRepository.GetAllKhoAsync();
            var response = new List<KhoDTO>();
            foreach (var k in kho)
            {
                response.Add(new KhoDTO
                {
                    id = k.id,
                    ten_kho = k.ten_kho,
                    hien_thi = k.hien_thi,
                    ghi_chu = k.ghi_chu,
                    nguoi_tao = k.nguoi_tao,
                    ngay_tao = k.ngay_tao,
                    cap_nhat = k.cap_nhat,
                });
            }
            return Ok(response);
        }
    }
}
