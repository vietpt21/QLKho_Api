using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WareHouseApi.Models.Domain;
using WareHouseApi.Models.DTO;
using WareHouseApi.Reponsitories.Implements;

namespace WareHouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NCCController : ControllerBase
    {
        private readonly IUnitWork _UnitWork;
       
        public NCCController(IUnitWork UnitWork)
        {
            _UnitWork = UnitWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNhaCC()
        {
            var nccList = await _UnitWork.nccRepository.GetAllAsync();
            var response = new List<NhaCCDto>();

            foreach (var ncc in nccList)
            {
                response.Add(new NhaCCDto
                {
                    id = ncc.id,
                    ten_ncc = ncc.ten_ncc,
                    hien_thi = ncc.hien_thi,
                    ten_day_du = ncc.ten_day_du,
                    loai_ncc = ncc.loai_ncc,
                    logo = ncc.logo,
                    nguoi_dai_dien = ncc.nguoi_dai_dien,
                    sdt = ncc.sdt,
                    tinh_trang = ncc.tinh_trang,
                    nv_phu_trach = ncc.nv_phu_trach,
                    ghi_chu = ncc.ghi_chu,
                    ngay_tao = ncc.ngay_tao,
                    ngay_cap_nhat = ncc.ngay_cap_nhat,
                });
            }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNhaCC([FromBody] CreateNhaCCRequestDto request)
        {
            var nhaCC = new NhaCC
            {
                ten_ncc = request.ten_ncc,
                hien_thi = request.hien_thi,
                ten_day_du = request.ten_day_du,
                loai_ncc = request.loai_ncc,
                logo = request.logo,
                nguoi_dai_dien = request.nguoi_dai_dien,
                sdt = request.sdt,
                tinh_trang = request.tinh_trang,
                nv_phu_trach = request.nv_phu_trach,
                ghi_chu = request.ghi_chu,
                ngay_tao = request.ngay_tao,
                ngay_cap_nhat = request.ngay_cap_nhat,
            };

            await _UnitWork.nccRepository.CreateAsync(nhaCC);

            var response = new NhaCCDto
            {
                id = nhaCC.id,
                ten_ncc = nhaCC.ten_ncc,
                hien_thi = nhaCC.hien_thi,
                ten_day_du = nhaCC.ten_day_du,
                loai_ncc = nhaCC.loai_ncc,
                logo = nhaCC.logo,
                nguoi_dai_dien = nhaCC.nguoi_dai_dien,
                sdt = nhaCC.sdt,
                tinh_trang = nhaCC.tinh_trang,
                nv_phu_trach = nhaCC.nv_phu_trach,
                ghi_chu = nhaCC.ghi_chu,
                ngay_tao = nhaCC.ngay_tao,
                ngay_cap_nhat = nhaCC.ngay_cap_nhat,
            };

            return CreatedAtAction(nameof(GetById), new { id = nhaCC.id }, response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var nhaCC = await _UnitWork.nccRepository.GetByIdAsync(id);
            if (nhaCC == null)
            {
                return NotFound();
            }

            var response = new NhaCCDto
            {
                id = nhaCC.id,
                ten_ncc = nhaCC.ten_ncc,
                hien_thi = nhaCC.hien_thi,
                ten_day_du = nhaCC.ten_day_du,
                loai_ncc = nhaCC.loai_ncc,
                logo = nhaCC.logo,
                nguoi_dai_dien = nhaCC.nguoi_dai_dien,
                sdt = nhaCC.sdt,
                tinh_trang = nhaCC.tinh_trang,
                nv_phu_trach = nhaCC.nv_phu_trach,
                ghi_chu = nhaCC.ghi_chu,
                ngay_tao = nhaCC.ngay_tao,
                ngay_cap_nhat = nhaCC.ngay_cap_nhat,
            };

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CreateNhaCCRequestDto request)
        {
            var nhaCC = new NhaCC
            {
                id = id,
                ten_ncc = request.ten_ncc,
                hien_thi = request.hien_thi,
                ten_day_du = request.ten_day_du,
                loai_ncc = request.loai_ncc,
                logo = request.logo,
                nguoi_dai_dien = request.nguoi_dai_dien,
                sdt = request.sdt,
                tinh_trang = request.tinh_trang,
                nv_phu_trach = request.nv_phu_trach,
                ghi_chu = request.ghi_chu,
                ngay_tao = request.ngay_tao,
                ngay_cap_nhat = request.ngay_cap_nhat,
            };

            var updatedNhaCC = await _UnitWork.nccRepository.UpdateAsync(nhaCC);
            if (updatedNhaCC == null)
            {
                return NotFound();
            }

            var response = new NhaCCDto
            {
                id = updatedNhaCC.id,
                ten_ncc = updatedNhaCC.ten_ncc,
                hien_thi = updatedNhaCC.hien_thi,
                ten_day_du = updatedNhaCC.ten_day_du,
                loai_ncc = updatedNhaCC.loai_ncc,
                logo = updatedNhaCC.logo,
                nguoi_dai_dien = updatedNhaCC.nguoi_dai_dien,
                sdt = updatedNhaCC.sdt,
                tinh_trang = updatedNhaCC.tinh_trang,
                nv_phu_trach = updatedNhaCC.nv_phu_trach,
                ghi_chu = updatedNhaCC.ghi_chu,
                ngay_tao = updatedNhaCC.ngay_tao,
                ngay_cap_nhat = updatedNhaCC.ngay_cap_nhat,
            };

            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var ncc = await _UnitWork.nccRepository.DeleteAsync(id);

            if (ncc is null)
            {
                return NotFound();
            }
            var response = new NhaCCDto
            {
                id = ncc.id,
                ten_ncc = ncc.ten_ncc,
                hien_thi = ncc.hien_thi,
                ten_day_du = ncc.ten_day_du,
                loai_ncc = ncc.loai_ncc,
                logo = ncc.logo,
                nguoi_dai_dien = ncc.nguoi_dai_dien,
                sdt = ncc.sdt,
                tinh_trang = ncc.tinh_trang,
                nv_phu_trach = ncc.nv_phu_trach,
                ghi_chu = ncc.ghi_chu,
                ngay_tao = ncc.ngay_tao,
                ngay_cap_nhat = ncc.ngay_cap_nhat,
            };

            return Ok(response);

        }
    }
}
