using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WareHouseApi.Models.Domain;
using WareHouseApi.Models.DTO;
using WareHouseApi.Reponsitories.Implements;
using WareHouseApi.Reponsitories.Interface;


namespace WareHouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KhoController : ControllerBase
    {
        private readonly IUnitWork _UnitWork;

        public KhoController(IUnitWork UnitWork )
        {
            
            _UnitWork = UnitWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllKho()
        {
            var khos = await _UnitWork.khoRepository.GetAllAsync();
            var response = new List<KhoDto>();
            foreach (var kho in khos)
            {
                response.Add(new KhoDto
                {
                    id = kho.id,
                    ten_kho = kho.ten_kho,
                    hien_thi = kho.hien_thi,
                    ghi_chu = kho.ghi_chu,
                    nguoi_tao = kho.nguoi_tao,
                    ngay_tao = kho.ngay_tao,
                    cap_nhat = kho.cap_nhat,
                });
            }
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateKhoRequestDto request)
        {
            var kho = new Kho
            {
                ten_kho = request.ten_kho,
                hien_thi = request.hien_thi,
                ghi_chu = request.ghi_chu,
                nguoi_tao = request.nguoi_tao,
                ngay_tao = request.ngay_tao,
                cap_nhat = request.cap_nhat,

            };
            await _UnitWork.khoRepository.CreateAsync(kho);
            var response = new KhoDto
            {
                id = kho.id,
                ten_kho = kho.ten_kho,
                hien_thi = kho.hien_thi,
                ghi_chu = kho.ghi_chu,
                nguoi_tao = kho.nguoi_tao,
                ngay_tao = kho.ngay_tao,
                cap_nhat = kho.cap_nhat,
            };

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var kho = await _UnitWork.khoRepository.GetByIdAsync(id);
            if (kho == null)
            {
                return NotFound();
            }

            var response = new KhoDto
            {
                id = kho.id,
                ten_kho = kho.ten_kho,
                hien_thi = kho.hien_thi,
                ghi_chu = kho.ghi_chu,
                nguoi_tao = kho.nguoi_tao,
                ngay_tao = kho.ngay_tao,
                cap_nhat = kho.cap_nhat,
            };

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateKhoRequestDto request)
        {
            var kho = new Kho
            {
                id = id,
                ten_kho = request.ten_kho,
                hien_thi = request.hien_thi,
                ghi_chu = request.ghi_chu,
                nguoi_tao = request.nguoi_tao,
                ngay_tao = request.ngay_tao,
                cap_nhat = request.cap_nhat,
            };

            var updatedKho = await _UnitWork.khoRepository.UpdateAsync(kho);
            if (updatedKho == null)
            {
                return NotFound();
            }

            var response = new KhoDto
            {
                id = updatedKho.id,
                ten_kho = updatedKho.ten_kho,
                hien_thi = updatedKho.hien_thi,
                ghi_chu = updatedKho.ghi_chu,
                nguoi_tao = updatedKho.nguoi_tao,
                ngay_tao = updatedKho.ngay_tao,
                cap_nhat = updatedKho.cap_nhat,
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var kho = await _UnitWork.khoRepository.DeleteAsync(id);

            if (kho is null)
            {
                return NotFound();
            }
            var response = new KhoDto
            {
                id = kho.id,
                ten_kho = kho.ten_kho,
                hien_thi = kho.hien_thi,
                ghi_chu = kho.ghi_chu,
                nguoi_tao = kho.nguoi_tao,
                ngay_tao = kho.ngay_tao,
                cap_nhat = kho.cap_nhat,
            };

            return Ok(response);

        }

    }
}
