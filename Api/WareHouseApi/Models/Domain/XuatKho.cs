namespace WareHouseApi.Models.Domain
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

        public List<XuatKhoCt> xuatKhoCTs { get; set; } = new List<XuatKhoCt>();

        public void InsertXuatKhoDetail(XuatKhoCt xuatKhoCt)
        {
            xuatKhoCTs.Add(xuatKhoCt);
        }
        public List<XuatKhoCt> GetAllXuatKhoDetail()
        {
            return xuatKhoCTs;
        }

    }

}
