namespace WareHouseApi.Models.Domain
{
    public class NhapKho
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
        public List<NhapKhoCT> nhapKhoCTs { get; set; } = new List<NhapKhoCT>();

        public void InsertNhapKhoDetail(NhapKhoCT nhapKhoCT)
        {
            nhapKhoCTs.Add(nhapKhoCT);
        }
        public List<NhapKhoCT> GetAllNhapKhoDetail()
        {
            return nhapKhoCTs;
        }

    }

}
