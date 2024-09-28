using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouseApi.Models.Domain;

namespace WareHouse.Models.Domain
{
    public class XuatKhoCT
    {
        public int id { get; set; }
        public string LoaiXuat { get; set; }
        public string xuat_kho_id { get; set; }
        [ForeignKey("xuat_kho_id")]
        public virtual XuatKho XuatKho { get; set; }
        public DateTime ngay_xuat { get; set; }
        public int san_pham_id { get; set; }
        [ForeignKey("san_pham_id")]
        public virtual SanPham SanPham { get; set; }
        public string ten_san_pham { get; set; }
        public string nhom_san_pham { get; set; }
        public string hang_sx { get; set; }
        public string hinh_anh { get; set; }
        public string thong_tin { get; set; }
        public string quy_cach { get; set; }
        public string dvt { get; set; }
        public string so_lo { get; set; }
        public DateTime ngay_het_han { get; set; }
        public int sl_xuat { get; set; }
        public int sl_xuat_tong { get; set; }
        public DateTime ngay_tao { get; set; }
        public DateTime ngay_cap_nhat { get; set; }
        public string nguoi_tao { get; set; }
    }
}
