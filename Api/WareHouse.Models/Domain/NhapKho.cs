using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WareHouse.Models.DTO;
using WareHouseApi.Models.Domain;

namespace WareHouse.Models.Domain
{
    public class NhapKho
    {
        
        public string id { get; set; }
        public string loai_nhap { get; set; }
        public DateTime ngay_nhap { get; set; }
        public int ncc_id { get; set; }
        [ForeignKey("ncc_id")]
        public NhaCC Ncc { get; set; }
       
        public int kho_id { get; set; }
        [ForeignKey("kho_id")]
        public Kho Kho { get; set; }

        public int sl_nhap { get; set; }
        public string nguoi_giao { get; set; }
        public string noi_dung_nhap { get; set; }
        public DateTime ngay_tao { get; set; }
        public DateTime ngay_cap_nhat { get; set; }
        public string nguoi_tao { get; set; }
        
        public List<NhapKhoCT> NhapKhoCTs { get; } = new List<NhapKhoCT>();



    }
}
