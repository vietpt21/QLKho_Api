using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        private readonly ISanPhamRepository sanPhamRepository;
        public SanPhamController(IUnitWork UnitWork)
        {
            _UnitWork = UnitWork;
          
        }
        [HttpGet]
        public async Task<IActionResult> GetAllSanPham()
        {
            var sanPhams = await _UnitWork.sanPhamRepository.GetAll();

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
                nhom_san_pham_id = sp.nhom_san_pham_id,
            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSanPham([FromBody] SanPhamRequestDto request)
        {
            var nhomSanPham = await _UnitWork.nhomSanPhamRepository.GetByIdAsync(request.nhom_san_pham_id);
            if (nhomSanPham == null)
            {
                return NotFound("Nhóm sản phẩm không tồn tại");
            }
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
                ngay_tao =request.ngay_tao,
                ngay_cap_nhat = request.ngay_cap_nhat,
                nguoi_tao = request.nguoi_tao,
                nhom_san_pham_id = request.nhom_san_pham_id,
            };

            var createdSanPham = await _UnitWork.sanPhamRepository.Create(sanPham);
            if (createdSanPham == null)
            {
                return BadRequest("Không thể tạo sản phẩm mới.");
            }

            var sanPhamDto = new SanPhamDto
            {
                id = createdSanPham.id,
                ten_san_pham = createdSanPham.ten_san_pham,
                hien_thi = createdSanPham.hien_thi,
                hang_sx = createdSanPham.hang_sx,
                hinh_anh = createdSanPham.hinh_anh,
                dia_chi = createdSanPham.dia_chi,
                thong_tin = createdSanPham.thong_tin,
                han_su_dung = createdSanPham.han_su_dung,
                quy_cach = createdSanPham.quy_cach,
                dvt = createdSanPham.dvt,
                gia_nhap = createdSanPham.gia_nhap,
                sl_toi_thieu = createdSanPham.sl_toi_thieu,
                sl_toi_da = createdSanPham.sl_toi_da,
                sl_nhap = createdSanPham.sl_nhap,
                sl_xuat = createdSanPham.sl_xuat,
                sl_ton = createdSanPham.sl_ton,
                trang_thai = createdSanPham.trang_thai,
                ghi_chu = createdSanPham.ghi_chu,
                ngay_tao = createdSanPham.ngay_tao,
                ngay_cap_nhat = createdSanPham.ngay_cap_nhat,
                nguoi_tao = createdSanPham.nguoi_tao,
                nhom_san_pham_id = createdSanPham.nhom_san_pham_id,
            };

            return CreatedAtAction(nameof(GetSanPhamById), new { id = createdSanPham.id }, sanPhamDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSanPhamById(int id)
        {
            var sanpham = await _UnitWork.sanPhamRepository.GetById(id);
            if (sanpham == null)
            {
                return NotFound();
            }

            var sanPhamDto = new SanPhamDto
            {
                id = sanpham.id,
                ten_san_pham = sanpham.ten_san_pham,
                hien_thi = sanpham.hien_thi,
                hang_sx = sanpham.hang_sx,
                hinh_anh = sanpham.hinh_anh,
                dia_chi = sanpham.dia_chi,
                thong_tin = sanpham.thong_tin,
                han_su_dung = sanpham.han_su_dung,
                quy_cach = sanpham.quy_cach,
                dvt = sanpham.dvt,
                gia_nhap = sanpham.gia_nhap,
                sl_toi_thieu = sanpham.sl_toi_thieu,
                sl_toi_da = sanpham.sl_toi_da,
                sl_nhap = sanpham.sl_nhap,
                sl_xuat = sanpham.sl_xuat,
                sl_ton = sanpham.sl_ton,
                trang_thai = sanpham.trang_thai,
                ghi_chu = sanpham.ghi_chu,
                ngay_tao = sanpham.ngay_tao,
                ngay_cap_nhat = sanpham.ngay_cap_nhat,
                nguoi_tao = sanpham.nguoi_tao,
                nhom_san_pham_id = sanpham.nhom_san_pham_id,
            };

            return Ok(sanPhamDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSanPham(int id, [FromBody] SanPhamRequestDto request)
        {
            var existingSanPham = await _UnitWork.sanPhamRepository.GetById(id);
            if (existingSanPham == null)
            {
                return NotFound("Sản phẩm không tồn tại");
            }

            existingSanPham.ten_san_pham = request.ten_san_pham;
            existingSanPham.hien_thi = request.hien_thi;
            existingSanPham.hang_sx = request.hang_sx;
            existingSanPham.hinh_anh = request.hinh_anh;
            existingSanPham.dia_chi = request.dia_chi;
            existingSanPham.thong_tin = request.thong_tin;
            existingSanPham.han_su_dung = request.han_su_dung;
            existingSanPham.quy_cach = request.quy_cach;
            existingSanPham.dvt = request.dvt;
            existingSanPham.gia_nhap = request.gia_nhap;
            existingSanPham.sl_toi_thieu = request.sl_toi_thieu;
            existingSanPham.sl_toi_da = request.sl_toi_da;
            existingSanPham.sl_nhap = request.sl_nhap;
            existingSanPham.sl_xuat = request.sl_xuat;
            existingSanPham.sl_ton = request.sl_ton;
            existingSanPham.trang_thai = request.trang_thai;
            existingSanPham.ghi_chu = request.ghi_chu;
            existingSanPham.ngay_cap_nhat = DateTime.Now;
            existingSanPham.nhom_san_pham_id = request.nhom_san_pham_id;
            existingSanPham.nguoi_tao = request.nguoi_tao;
            existingSanPham.ngay_tao = request.ngay_tao;

            await _UnitWork.sanPhamRepository.Update(existingSanPham);

            var sanPhamDto = new SanPhamDto
            {
                id = existingSanPham.id,
                ten_san_pham = existingSanPham.ten_san_pham,
                hien_thi = existingSanPham.hien_thi,
                hang_sx = existingSanPham.hang_sx,
                hinh_anh = existingSanPham.hinh_anh,
                dia_chi = existingSanPham.dia_chi,
                thong_tin = existingSanPham.thong_tin,
                han_su_dung = existingSanPham.han_su_dung,
                quy_cach = existingSanPham.quy_cach,
                dvt = existingSanPham.dvt,
                gia_nhap = existingSanPham.gia_nhap,
                sl_toi_thieu = existingSanPham.sl_toi_thieu,
                sl_toi_da = existingSanPham.sl_toi_da,
                sl_nhap = existingSanPham.sl_nhap,
                sl_xuat = existingSanPham.sl_xuat,
                sl_ton = existingSanPham.sl_ton,
                trang_thai = existingSanPham.trang_thai,
                ghi_chu = existingSanPham.ghi_chu,
                ngay_tao = existingSanPham.ngay_tao,
                ngay_cap_nhat = existingSanPham.ngay_cap_nhat,
                nguoi_tao = existingSanPham.nguoi_tao,
                nhom_san_pham_id = existingSanPham.nhom_san_pham_id,
            };

            return Ok(sanPhamDto);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSanPham(int id)
        {
            var existingSanPham = await _UnitWork.sanPhamRepository.GetById(id);
            if (existingSanPham == null)
            {
                return NotFound("Sản phẩm không tồn tại");
            }

            await _UnitWork.sanPhamRepository.Delete(id);
            var sanPhamDto = new SanPhamDto
            {
                id = existingSanPham.id,
                ten_san_pham = existingSanPham.ten_san_pham,
                hien_thi = existingSanPham.hien_thi,
                hang_sx = existingSanPham.hang_sx,
                hinh_anh = existingSanPham.hinh_anh,
                dia_chi = existingSanPham.dia_chi,
                thong_tin = existingSanPham.thong_tin,
                han_su_dung = existingSanPham.han_su_dung,
                quy_cach = existingSanPham.quy_cach,
                dvt = existingSanPham.dvt,
                gia_nhap = existingSanPham.gia_nhap,
                sl_toi_thieu = existingSanPham.sl_toi_thieu,
                sl_toi_da = existingSanPham.sl_toi_da,
                sl_nhap = existingSanPham.sl_nhap,
                sl_xuat = existingSanPham.sl_xuat,
                sl_ton = existingSanPham.sl_ton,
                trang_thai = existingSanPham.trang_thai,
                ghi_chu = existingSanPham.ghi_chu,
                ngay_tao = existingSanPham.ngay_tao,
                ngay_cap_nhat = existingSanPham.ngay_cap_nhat,
                nguoi_tao = existingSanPham.nguoi_tao,
                nhom_san_pham_id = existingSanPham.nhom_san_pham_id,
            };

            return Ok(sanPhamDto);
        }

    }
}
