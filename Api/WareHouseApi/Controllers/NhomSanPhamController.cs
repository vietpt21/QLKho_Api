using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Models.DTO;
using WareHouseApi.Models.Domain;
using WareHouseApi.Reponsitories.Implements;

namespace WareHouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhomSanPhamController : ControllerBase
    {
        private readonly IUnitWork _UnitWork;

        public NhomSanPhamController(IUnitWork UnitWork)
        {
            _UnitWork = UnitWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNhomSanPham()
        {
            var nhomSanPhams = await _UnitWork.nhomSanPhamRepository.GetAllAsync();
            var response = nhomSanPhams.Select(nsp => new NhomSanPhamDto
            {
                id = nsp.id,
                loai_san_pham = nsp.loai_san_pham
            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNhomSanPham([FromBody] NhomSanPhamRequestDto request)
        {
            var nhomSanPham = new NhomSanPham
            {
                loai_san_pham = request.loai_san_pham
            };

            await _UnitWork.nhomSanPhamRepository.CreateAsync(nhomSanPham);

            var response = new NhomSanPhamDto
            {
                id = nhomSanPham.id,
                loai_san_pham = nhomSanPham.loai_san_pham
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var nhomSanPham = await _UnitWork.nhomSanPhamRepository.GetByIdAsync(id);
            if (nhomSanPham == null)
            {
                return NotFound();
            }

            var response = new NhomSanPhamDto
            {
                id = nhomSanPham.id,
                loai_san_pham = nhomSanPham.loai_san_pham
            };

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] NhomSanPhamRequestDto request)
        {
            var nhomSanPham = new NhomSanPham
            {
                id = id,
                loai_san_pham = request.loai_san_pham
            };

            var updatedNhomSanPham = await _UnitWork.nhomSanPhamRepository.UpdateAsync(nhomSanPham);
            if (updatedNhomSanPham == null)
            {
                return NotFound();
            }

            var response = new NhomSanPhamDto
            {
                id = updatedNhomSanPham.id,
                loai_san_pham = updatedNhomSanPham.loai_san_pham
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var nhomSanPham = await _UnitWork.nhomSanPhamRepository.DeleteAsync(id);
            if (nhomSanPham == null)
            {
                return NotFound();
            }

            var response = new NhomSanPhamDto
            {
                id = nhomSanPham.id,
                loai_san_pham = nhomSanPham.loai_san_pham
            };

            return Ok(response);
        }
    }
}
