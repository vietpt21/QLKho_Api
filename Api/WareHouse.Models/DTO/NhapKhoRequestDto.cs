using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Models.Domain;
using WareHouseApi.Models.Domain;

namespace WareHouse.Models.DTO
{
    public class NhapKhoRequestDto
    {
        public string id { get; set; }
        public string loai_nhap { get; set; }
        public DateTime ngay_nhap { get; set; }
        public int ncc_id { get; set; }
        public int kho_id { get; set; }
        public int sl_nhap { get; set; }
        public string nguoi_giao { get; set; }
        public string noi_dung_nhap { get; set; }
        public DateTime ngay_tao { get; set; }
        public DateTime ngay_cap_nhat { get; set; }
        public string nguoi_tao { get; set; }
        public List<NhapKhoCTRequestDto> NhapKhoCTs { get; set; }

    }
}
