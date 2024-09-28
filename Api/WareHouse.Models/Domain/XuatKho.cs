using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouse.Models.Domain
{
    public class XuatKho
    {
        public string id { get; set; }
        public string loat_xuat { get; set; }
        public DateTime ngay_xuat { get; set; }
        public int nhan_vien_id { get; set; }
        public string ma_hoa_don { get; set; }
        public int sl_san_pham { get; set; }
        public int sl_xuat { get; set; }
        public string noi_dung_xuat { get; set; }
        public string ghi_chu { get; set; }
        public DateTime ngay_tao { get; set; }
        public DateTime ngay_cap_nhat { get; set; }
        public string nguoi_tao { get; set; }

        public List<XuatKhoCT> xuatKhoCTs { get; set; } = new List<XuatKhoCT>();
    }
}
