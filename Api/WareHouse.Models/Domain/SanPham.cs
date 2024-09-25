using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseApi.Models.Domain
{
    public class SanPham
    {
     
        public int id { get; set; }
        public string ten_san_pham { get; set; }
        public string hien_thi { get; set; }
        public string hang_sx { get; set; }
        public string hinh_anh { get; set; }
        public string dia_chi { get; set; }
        public string thong_tin { get; set; }
        public DateTime han_su_dung { get; set; }
        public string quy_cach { get; set; }
        public string dvt { get; set; }
        public float gia_nhap { get; set; }
        public int sl_toi_thieu { get; set; }
        public int sl_toi_da { get; set; }
        public int sl_nhap { get; set; }
        public int sl_xuat { get; set; }
        public int sl_ton { get; set; }
        public string trang_thai { get; set; }
        public string ghi_chu { get; set; }
        public DateTime ngay_tao { get; set; }
        public DateTime ngay_cap_nhat { get; set; }
        public string nguoi_tao { get; set; }
        public int nhom_san_pham_id { get; set; }
        [ForeignKey("nhom_san_pham_id")]
        public NhomSanPham NhomSanPham { get; set; }
       
    }
}
