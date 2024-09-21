using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Models.DTO;
using WareHouseApi.Models.Domain;
using WareHouseApi.Reponsitories.Implements;

namespace WareHouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SanPhamController : ControllerBase
    {
        private readonly IUnitWork _UnitWork;

        public SanPhamController(IUnitWork UnitWork)
        {
            _UnitWork = UnitWork;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSanPham()
        {
            var sanPhams = await _UnitWork.sanPhamRepository.GetAllAsync();
            var response = sanPhams.Select(sp => new SanPhamDto
            {
                id = sp.id,
                ten_san_pham = sp.ten_san_pham,
                hien_thi = sp.hien_thi,
                hang_sx = sp.hang_sx,
                hinh_anh = sp.hinh_anh,
                dia_chi = sp.dia_chi,
                thong_tin = sp.thong_tin,
                han_su_dung = sp.han_su_dung,
                quy_cach = sp.quy_cach,
                dvt = sp.dvt,
                gia_nhap = sp.gia_nhap,
                sl_toi_thieu = sp.sl_toi_thieu,
                sl_toi_da = sp.sl_toi_da,
                sl_nhap = sp.sl_nhap,
                sl_xuat = sp.sl_xuat,
                sl_ton = sp.sl_ton,
                trang_thai = sp.trang_thai,
                ghi_chu = sp.ghi_chu,
                ngay_tao = sp.ngay_tao,
                ngay_cap_nhat = sp.ngay_cap_nhat,
                nguoi_tao = sp.nguoi_tao,
                nhom_san_pham_id = sp.nhom_san_pham_id
            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSanPham([FromBody] SanPhamRequestDto request)
        {
            var sanPham = new SanPham
            {
                ten_san_pham = request.ten_san_pham,
                hien_thi = request.hien_thi,
                hang_sx = request.hang_sx,
                hinh_anh = request.hinh_anh,
                dia_chi = request.dia_chi,
                thong_tin = request.thong_tin,
                han_su_dung = request.han_su_dung,
                quy_cach = request.quy_cach,
                dvt = request.dvt,
                gia_nhap = request.gia_nhap,
                sl_toi_thieu = request.sl_toi_thieu,
                sl_toi_da = request.sl_toi_da,
                sl_nhap = request.sl_nhap,
                sl_xuat = request.sl_xuat,
                sl_ton = request.sl_ton,
                trang_thai = request.trang_thai,
                ghi_chu = request.ghi_chu,
                ngay_tao = DateTime.Now,
                ngay_cap_nhat = DateTime.Now,
                nguoi_tao = request.nguoi_tao,
                nhom_san_pham_id = request.nhom_san_pham_id
            };

            await _UnitWork.sanPhamRepository.CreateAsync(sanPham);

            var response = new SanPhamDto
            {
                id = sanPham.id,
                ten_san_pham = sanPham.ten_san_pham,
                hien_thi = sanPham.hien_thi,
                hang_sx = sanPham.hang_sx,
                hinh_anh = sanPham.hinh_anh,
                dia_chi = sanPham.dia_chi,
                thong_tin = sanPham.thong_tin,
                han_su_dung = sanPham.han_su_dung,
                quy_cach = sanPham.quy_cach,
                dvt = sanPham.dvt,
                gia_nhap = sanPham.gia_nhap,
                sl_toi_thieu = sanPham.sl_toi_thieu,
                sl_toi_da = sanPham.sl_toi_da,
                sl_nhap = sanPham.sl_nhap,
                sl_xuat = sanPham.sl_xuat,
                sl_ton = sanPham.sl_ton,
                trang_thai = sanPham.trang_thai,
                ghi_chu = sanPham.ghi_chu,
                ngay_tao = sanPham.ngay_tao,
                ngay_cap_nhat = sanPham.ngay_cap_nhat,
                nguoi_tao = sanPham.nguoi_tao,
                nhom_san_pham_id = sanPham.nhom_san_pham_id
            };

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var sanPham = await _UnitWork.sanPhamRepository.GetByIdAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            var response = new SanPhamDto
            {
                id = sanPham.id,
                ten_san_pham = sanPham.ten_san_pham,
                hien_thi = sanPham.hien_thi,
                hang_sx = sanPham.hang_sx,
                hinh_anh = sanPham.hinh_anh,
                dia_chi = sanPham.dia_chi,
                thong_tin = sanPham.thong_tin,
                han_su_dung = sanPham.han_su_dung,
                quy_cach = sanPham.quy_cach,
                dvt = sanPham.dvt,
                gia_nhap = sanPham.gia_nhap,
                sl_toi_thieu = sanPham.sl_toi_thieu,
                sl_toi_da = sanPham.sl_toi_da,
                sl_nhap = sanPham.sl_nhap,
                sl_xuat = sanPham.sl_xuat,
                sl_ton = sanPham.sl_ton,
                trang_thai = sanPham.trang_thai,
                ghi_chu = sanPham.ghi_chu,
                ngay_tao = sanPham.ngay_tao,
                ngay_cap_nhat = sanPham.ngay_cap_nhat,
                nguoi_tao = sanPham.nguoi_tao,
                nhom_san_pham_id = sanPham.nhom_san_pham_id
            };

            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] SanPhamRequestDto request)
        {
            var sanPham = new SanPham
            {
                id = id,
                ten_san_pham = request.ten_san_pham,
                hien_thi = request.hien_thi,
                hang_sx = request.hang_sx,
                hinh_anh = request.hinh_anh,
                dia_chi = request.dia_chi,
                thong_tin = request.thong_tin,
                han_su_dung = request.han_su_dung,
                quy_cach = request.quy_cach,
                dvt = request.dvt,
                gia_nhap = request.gia_nhap,
                sl_toi_thieu = request.sl_toi_thieu,
                sl_toi_da = request.sl_toi_da,
                sl_nhap = request.sl_nhap,
                sl_xuat = request.sl_xuat,
                sl_ton = request.sl_ton,
                trang_thai = request.trang_thai,
                ghi_chu = request.ghi_chu,
                ngay_cap_nhat = DateTime.Now,
                nguoi_tao = request.nguoi_tao,
                nhom_san_pham_id = request.nhom_san_pham_id
            };

            var updatedSanPham = await _UnitWork.sanPhamRepository.UpdateAsync(sanPham);
            if (updatedSanPham == null)
            {
                return NotFound();
            }

            var response = new SanPhamDto
            {
                id = updatedSanPham.id,
                ten_san_pham = updatedSanPham.ten_san_pham,
                hien_thi = updatedSanPham.hien_thi,
                hang_sx = updatedSanPham.hang_sx,
                hinh_anh = updatedSanPham.hinh_anh,
                dia_chi = updatedSanPham.dia_chi,
                thong_tin = updatedSanPham.thong_tin,
                han_su_dung = updatedSanPham.han_su_dung,
                quy_cach = updatedSanPham.quy_cach,
                dvt = updatedSanPham.dvt,
                gia_nhap = updatedSanPham.gia_nhap,
                sl_toi_thieu = updatedSanPham.sl_toi_thieu,
                sl_toi_da = updatedSanPham.sl_toi_da,
                sl_nhap = updatedSanPham.sl_nhap,
                sl_xuat = updatedSanPham.sl_xuat,
                sl_ton = updatedSanPham.sl_ton,
                trang_thai = updatedSanPham.trang_thai,
                ghi_chu = updatedSanPham.ghi_chu,
                ngay_tao = updatedSanPham.ngay_tao,
                ngay_cap_nhat = updatedSanPham.ngay_cap_nhat,
                nguoi_tao = updatedSanPham.nguoi_tao,
                nhom_san_pham_id = updatedSanPham.nhom_san_pham_id
            };

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var sanPham = await _UnitWork.sanPhamRepository.DeleteAsync(id);
            if (sanPham == null)
            {
                return NotFound();
            }

            var response = new SanPhamDto
            {
                id = sanPham.id,
                ten_san_pham = sanPham.ten_san_pham,
                hien_thi = sanPham.hien_thi,
                hang_sx = sanPham.hang_sx,
                hinh_anh = sanPham.hinh_anh,
                dia_chi = sanPham.dia_chi,
                thong_tin = sanPham.thong_tin,
                han_su_dung = sanPham.han_su_dung,
                quy_cach = sanPham.quy_cach,
                dvt = sanPham.dvt,
                gia_nhap = sanPham.gia_nhap,
                sl_toi_thieu = sanPham.sl_toi_thieu,
                sl_toi_da = sanPham.sl_toi_da,
                sl_nhap = sanPham.sl_nhap,
                sl_xuat = sanPham.sl_xuat,
                sl_ton = sanPham.sl_ton,
                trang_thai = sanPham.trang_thai,
                ghi_chu = sanPham.ghi_chu,
                ngay_tao = sanPham.ngay_tao,
                ngay_cap_nhat = sanPham.ngay_cap_nhat,
                nguoi_tao = sanPham.nguoi_tao,
                nhom_san_pham_id = sanPham.nhom_san_pham_id
            };

            return Ok(response);
        }
    }
}
