namespace WareHouseApi.Models.DTO
{
    public class KhoDTO
    {
        public int id { get; set; }
        public string ten_kho { get; set; }
        public string hien_thi { get; set; }
        public string ghi_chu { get; set; }
        public string nguoi_tao { get; set; }
        public DateTime ngay_tao { get; set; }
        public DateTime cap_nhat { get; set; }
    }
}
