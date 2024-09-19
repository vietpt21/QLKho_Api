namespace WareHouseApi.Models.Domain
{
    public class NhapKhoCT
    {
        public int id { get; set; }
        public string nhap_kho_id { get; set; }
        public DateTime ngay_nhap { get; set; }
        public int san_pham_id { get; set; }
        public string nhom_san_pham { get; set; }
        public string hang_sx { get; set; }
        public string hinh_anh { get; set; }
        public string thong_tin { get; set; }
        public DateTime han_su_dung { get; set; }
        public string quy_cach { get; set; }
        public string dvt { get; set; }
        public string so_lo { get; set; }
        public float gia_nhap { get; set; }
        public int sl_nhap { get; set; }
        public int sl_xuat { get; set; }
        public int sl_ton { get; set; }
        public DateTime ngay_het_han { get; set; }
        public string ghi_chu { get; set; }
        public DateTime ngay_tao { get; set; }
        public DateTime ngay_cap_nhat { get; set; }
        public string nguoi_tao { get; set; }
    }

}
