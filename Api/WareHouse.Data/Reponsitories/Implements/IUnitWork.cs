namespace WareHouseApi.Reponsitories.Implements
{
    public interface IUnitWork
    {
        IKhoRepository khoRepository { get; }
        INCCRepository nccRepository { get; }
        INhomSanPhamRepository nhomSanPhamRepository { get; }
        ISanPhamRepository sanPhamRepository { get; }
       
    }
}
