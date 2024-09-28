using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata;
using WareHouse.Models.Domain;
using WareHouse.Models.DTO;
using WareHouseApi.Models.Domain;
using WareHouseApi.Reponsitories.Implements;

namespace WareHouseApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NhapKhoController : ControllerBase
    {
        private readonly IUnitWork _UnitWork;


        public NhapKhoController(IUnitWork UnitWork)
        {
            _UnitWork = UnitWork;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllNhapKho()
        {
            var nhapkhos = await _UnitWork.nhapKhoRepository.GetAll();
            var response = nhapkhos.Select(nk => new NhapKhoDto
            {
                id = nk.id,
                loai_nhap = nk.loai_nhap,
                ngay_nhap = nk.ngay_nhap,
                sl_nhap = nk.sl_nhap,
                nguoi_giao = nk.nguoi_giao,
                noi_dung_nhap = nk.noi_dung_nhap,
                ngay_tao = nk.ngay_tao,
                ngay_cap_nhat = nk.ngay_cap_nhat,
                nguoi_tao = nk.nguoi_tao,
                kho_id = nk.kho_id,
                ncc_id = nk.ncc_id,
            }).ToList();

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateNhapKho([FromBody] NhapKhoRequestDto request)
        {
            var kho = await _UnitWork.khoRepository.GetByIdAsync(request.kho_id);
            var ncc = await _UnitWork.nccRepository.GetByIdAsync(request.ncc_id);

            if (kho == null)
            {
                return NotFound("Kho không tồn tại");
            }

            if (ncc == null)
            {
                return NotFound("NCC không tồn tại");
            }
            string nhapkhoId = await _UnitWork.nhapKhoRepository.GenIdNhapKho();
            var nhapkho = new NhapKho
            {
                id =nhapkhoId,
                loai_nhap = request.loai_nhap,
                ngay_nhap = DateTime.Now,
                sl_nhap = request.sl_nhap,
                nguoi_giao = request.nguoi_giao,
                noi_dung_nhap = request.noi_dung_nhap,
                ngay_tao = DateTime.Now,
                ngay_cap_nhat = DateTime.Now,
                nguoi_tao = request.nguoi_tao,
                kho_id = request.kho_id,
                ncc_id = request.ncc_id,
            };
         
            if (request.NhapKhoCTs.Count == nhapkho.sl_nhap)
            {
                var createdNhapKho = await _UnitWork.nhapKhoRepository.Create(nhapkho);

                foreach (var requestCT in request.NhapKhoCTs)
                {
                    var sp = await _UnitWork.sanPhamRepository.GetById(requestCT.san_pham_id);
                    var nhapKhoCT = new NhapKhoCT
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
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNhapKho([FromRoute] string id)
        {
            var nhapkhocts = await _UnitWork.nhapKhoCTRepository.GetAllNhapKhoCTByNhapKhoId(id);
            foreach( var nhapkhoct in nhapkhocts)
            {
                var sanpham = await _UnitWork.sanPhamRepository.GetById(nhapkhoct.san_pham_id);
                sanpham.sl_nhap = sanpham.sl_nhap - nhapkhoct.sl_nhap;
                sanpham.sl_ton = sanpham.sl_nhap - sanpham.sl_xuat;
                await _UnitWork.sanPhamRepository.Update(sanpham);
            }
            var deletedNhapKho = await _UnitWork.nhapKhoRepository.Delete(id);
            if (deletedNhapKho == null)
            {
                return NotFound();
            }
            var response = new NhapKhoDto
            {
                id = deletedNhapKho.id,
                loai_nhap = deletedNhapKho.loai_nhap,
                ngay_nhap = deletedNhapKho.ngay_nhap,
                nguoi_giao = deletedNhapKho.nguoi_giao,
                sl_nhap = deletedNhapKho.sl_nhap,
                noi_dung_nhap = deletedNhapKho.noi_dung_nhap,
                ngay_tao = deletedNhapKho.ngay_tao,
                ngay_cap_nhat = deletedNhapKho.ngay_cap_nhat,
                nguoi_tao = deletedNhapKho.nguoi_tao,
                kho_id = deletedNhapKho.kho_id,
                ncc_id = deletedNhapKho.ncc_id,
            };

            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateNhapKho(string id, [FromBody] NhapKhoRequestDto request)
        {
            var kho = await _UnitWork.khoRepository.GetByIdAsync(request.kho_id);
            var ncc = await _UnitWork.nccRepository.GetByIdAsync(request.ncc_id);

            if (kho == null)
            {
                return NotFound("Kho không tồn tại");
            }

            if (ncc == null)
            {
                return NotFound("NCC không tồn tại");
            }

            var nhapkho = await _UnitWork.nhapKhoRepository.GetById(id); 
            if (nhapkho == null)
            {
                return NotFound("Nhập kho không tồn tại");
            }
            nhapkho.id = await _UnitWork.nhapKhoRepository.GenIdNhapKho();
            nhapkho.loai_nhap = request.loai_nhap;
            nhapkho.ngay_nhap = DateTime.Now;
            nhapkho.ngay_cap_nhat = DateTime.Now;
            nhapkho.ncc_id = request.ncc_id;
            nhapkho.kho_id = request.kho_id;
            nhapkho.sl_nhap = request.sl_nhap;
            nhapkho.nguoi_tao = request.nguoi_giao;
            nhapkho.noi_dung_nhap = request.noi_dung_nhap;
            nhapkho.ngay_tao = DateTime.Now;
            nhapkho.ngay_cap_nhat = DateTime.Now;
          

            if (request.NhapKhoCTs.Count == nhapkho.sl_nhap)
            {
                await _UnitWork.nhapKhoRepository.Update(nhapkho);
                foreach (var requestCT in request.NhapKhoCTs)
                {
                    var nhapKhoCTList = await _UnitWork.nhapKhoCTRepository.GetAllNhapKhoCTByNhapKhoId(id);

                    if (nhapKhoCTList.Any())
                    {
                        foreach (var nhapKhoCT in nhapKhoCTList)
                        {
                            var nhapKhoCTOld = nhapKhoCTList.FirstOrDefault(x => x.san_pham_id == requestCT.san_pham_id);

                            if (nhapKhoCTOld != null)
                            {
                              
                                nhapKhoCT.nhap_kho_id = nhapkho.id;
                                nhapKhoCT.ngay_nhap = DateTime.Now;
                                nhapKhoCT.san_pham_id = requestCT.san_pham_id;
                                nhapKhoCT.nhom_san_pham = requestCT.nhom_san_pham;
                                nhapKhoCT.hang_sx = requestCT.hang_sx;
                                nhapKhoCT.hinh_anh = requestCT.hinh_anh;
                                nhapKhoCT.thong_tin = requestCT.thong_tin;
                                nhapKhoCT.han_su_dung = requestCT.han_su_dung;
                                nhapKhoCT.quy_cach = requestCT.quy_cach;
                                nhapKhoCT.dvt = requestCT.dvt;
                                nhapKhoCT.so_lo = requestCT.so_lo;
                                nhapKhoCT.gia_nhap = requestCT.gia_nhap;
                                nhapKhoCT.sl_nhap = requestCT.sl_nhap;
                                nhapKhoCT.sl_xuat = requestCT.sl_xuat;
                                nhapKhoCT.sl_ton = requestCT.sl_ton;
                                nhapKhoCT.ngay_het_han = requestCT.ngay_het_han;
                                nhapKhoCT.ghi_chu = requestCT.ghi_chu;
                                nhapKhoCT.ngay_tao = DateTime.Now;
                                nhapKhoCT.ngay_cap_nhat = DateTime.Now;
                                nhapKhoCT.nguoi_tao = request.nguoi_tao;

                                await _UnitWork.nhapKhoCTRepository.Update(nhapKhoCT);
                                var sanpham = await _UnitWork.sanPhamRepository.GetById(nhapKhoCT.san_pham_id);
                                if (sanpham != null)
                                {
                                    sanpham.sl_nhap += sanpham.sl_nhap - nhapKhoCTOld.sl_nhap + nhapKhoCT.sl_nhap;
                                    sanpham.sl_ton = sanpham.sl_nhap - sanpham.sl_xuat;
                                    await _UnitWork.sanPhamRepository.Update(sanpham);
                                }
                            }
                        }
                    }
                    else
                    {
                        
                    }
                }
            }
            var nhapkhoDto = new NhapKhoDto
            {
                id = nhapkho.id,
                loai_nhap = nhapkho.loai_nhap,
                ngay_nhap = nhapkho.ngay_nhap,
                nguoi_giao = nhapkho.nguoi_giao,
                sl_nhap = nhapkho.sl_nhap,
                noi_dung_nhap = nhapkho.noi_dung_nhap,
                ngay_tao = nhapkho.ngay_tao,
                ngay_cap_nhat = nhapkho.ngay_cap_nhat,
                nguoi_tao = nhapkho.nguoi_tao,
                kho_id = nhapkho.kho_id,
                ncc_id = nhapkho.ncc_id,
            };

            return Ok(nhapkhoDto); // Return updated NhapKhoDto
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetNhapKhoById(string id)
        {
            var nhapkho = await _UnitWork.nhapKhoRepository.GetById(id);
            if (nhapkho == null)
            {
                return NotFound();
            }

            var nhapkhoDto = new NhapKhoDto
            {
                id = nhapkho.id,
                loai_nhap = nhapkho.loai_nhap,
                ngay_nhap = nhapkho.ngay_nhap,
                sl_nhap = nhapkho.sl_nhap,
                nguoi_giao = nhapkho.nguoi_giao,
                noi_dung_nhap = nhapkho.noi_dung_nhap,
                ngay_tao = nhapkho.ngay_tao,
                ngay_cap_nhat = nhapkho.ngay_cap_nhat,
                nguoi_tao = nhapkho.nguoi_tao,
                kho_id = nhapkho.kho_id,
                ncc_id = nhapkho.ncc_id,
            };

            return Ok(nhapkhoDto);
        }


    }
}
