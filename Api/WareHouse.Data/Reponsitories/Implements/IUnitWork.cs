namespace WareHouseApi.Reponsitories.Implements
{
    public interface IUnitWork
    {
        IKhoRepository khoRepository { get; }
        INCCRepository nccRepository { get; }
        INhomSanPhamRepository nhomSanPhamRepository { get; }
        ISanPhamRepository sanPhamRepository { get; }
        /*INhapKhoRepository nhapkhoRepository { get; }
        INhapKhoCTRepository nhapKhoctRepository { get; }
        IXuatKhoRepository xuatKhoRepository { get; }
        IXuatKhoCTRepository xuatkhoctRepository { get; }*/
    }
}
