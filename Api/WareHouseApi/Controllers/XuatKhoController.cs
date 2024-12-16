using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WareHouse.Models.Domain;
using WareHouse.Models.DTO;
using WareHouseApi.Reponsitories.Implements;

namespace WareHouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class XuatKhoController : ControllerBase
    {
        private readonly IUnitWork _UnitWork;
        public XuatKhoController(IUnitWork UnitWork)
        {
            _UnitWork = UnitWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllXuatKho()
        {
            var xuatkhos = await _UnitWork.xuatKhoRepository.GetAll();
            var response = xuatkhos.Select(xk => new XuatKhoDto
            {
                id = xk.id,
                loat_xuat = xk.loat_xuat,
                ngay_xuat = xk.ngay_xuat,
                nhan_vien_id = xk.nhan_vien_id,
                ma_hoa_don = xk.ma_hoa_don,
                sl_san_pham = xk.sl_san_pham,
                sl_xuat = xk.sl_xuat,
                noi_dung_xuat = xk.noi_dung_xuat,
                ghi_chu = xk.ghi_chu,
                ngay_tao = xk.ngay_tao,
                ngay_cap_nhat = xk.ngay_cap_nhat,
                nguoi_tao = xk.nguoi_tao,
            }).ToList();

            return Ok(response);
        }
      /*  [HttpPost]
        public async Task<IActionResult> CreateXuatKho([FromBody] XuatKhoRequestDto request)
        {
           
            string xuatkhoId = await _UnitWork.xuatKhoRepository.GenIdXuatKho();
            var xuatkho = new XuatKho
            {
                id = xuatkhoId,
                loat_xuat = request.loat_xuat,
                ngay_xuat = DateTime.Now,
                nhan_vien_id = request.nhan_vien_id,
                ma_hoa_don = request.ma_hoa_don,
                sl_san_pham = request.sl_san_pham,
                sl_xuat = request.sl_xuat,
                noi_dung_xuat = request.noi_dung_xuat,
                ghi_chu = request.ghi_chu,
                ngay_tao = request.ngay_tao,
                ngay_cap_nhat = request.ngay_cap_nhat,
                nguoi_tao = request.nguoi_tao,
            };

            if (request.XuatKhoCTs.Count == xuatkho.sl_xuat)
            {
                var createdXuatKho = await _UnitWork.xuatKhoRepository.Create(xuatkho);

                foreach (var requestCT in request.XuatKhoCTs)
                {
                    var sp = await _UnitWork.sanPhamRepository.GetById(requestCT.san_pham_id);
                    var nhapKhoCT = new XuatKhoCT
                    {
                        nhap_kho_id = createdNhapKho.id,
                        ngay_nhap = DateTime.Now,
                        san_pham_id = requestCT.san_pham_id,
                        nhom_san_pham = sp.NhomSanPham.loai_san_pham,
                        hang_sx = sp.hang_sx,
                        hinh_anh = requestCT.hinh_anh,
                        thong_tin = requestCT.thong_tin,
                        han_su_dung = requestCT.han_su_dung,
                        quy_cach = requestCT.quy_cach,
                        dvt = requestCT.dvt,
                        so_lo = requestCT.so_lo,
                        gia_nhap = requestCT.gia_nhap,
                        sl_nhap = requestCT.sl_nhap,
                        sl_xuat = requestCT.sl_xuat,
                        sl_ton = requestCT.sl_ton,
                        ngay_het_han = requestCT.ngay_het_han,
                        ghi_chu = requestCT.ghi_chu,
                        ngay_tao = DateTime.Now,
                        ngay_cap_nhat = DateTime.Now,
                        nguoi_tao = request.nguoi_tao
                    };

                    await _UnitWork.nhapKhoCTRepository.Create(nhapKhoCT);
                    var sanpham = await _UnitWork.sanPhamRepository.GetById(nhapKhoCT.san_pham_id);
                    if (sanpham != null)
                    {
                        sanpham.sl_nhap += nhapKhoCT.sl_nhap;
                        sanpham.sl_ton = sanpham.sl_nhap - sanpham.sl_xuat;
                        await _UnitWork.sanPhamRepository.Update(sanpham);
                    }
                }
                var nhapkhoDto = new NhapKhoDto
                {
                    id = createdNhapKho.id,
                    loai_nhap = createdNhapKho.loai_nhap,
                    ngay_nhap = createdNhapKho.ngay_nhap,
                    nguoi_giao = createdNhapKho.nguoi_giao,
                    sl_nhap = createdNhapKho.sl_nhap,
                    noi_dung_nhap = createdNhapKho.noi_dung_nhap,
                    ngay_tao = createdNhapKho.ngay_tao,
                    ngay_cap_nhat = createdNhapKho.ngay_cap_nhat,
                    nguoi_tao = createdNhapKho.nguoi_tao,
                    kho_id = createdNhapKho.kho_id,
                    ncc_id = createdNhapKho.ncc_id,
                };
                return CreatedAtAction(nameof(GetNhapKhoById), new { id = createdNhapKho.id }, nhapkhoDto);
            }
            return BadRequest();
        }*/
    }
}
