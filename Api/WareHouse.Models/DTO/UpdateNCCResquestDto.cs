namespace WareHouseApi.Models.DTO
{
    public class UpdateNCCResquestDto
    {
        public int id { get; set; }
        public string ten_ncc { get; set; }
        public string hien_thi { get; set; }
        public string ten_day_du { get; set; }
        public string loai_ncc { get; set; }
        public string logo { get; set; }
        public string nguoi_dai_dien { get; set; }
        public string sdt { get; set; }
        public string tinh_trang { get; set; }
        public string nv_phu_trach { get; set; }
        public string ghi_chu { get; set; }
        public DateTime ngay_tao { get; set; }
        public DateTime ngay_cap_nhat { get; set; }
    }
}
