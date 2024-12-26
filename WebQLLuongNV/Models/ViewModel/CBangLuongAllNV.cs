namespace WebQLLuongNV.Models.ViewModel
{
    public class CBangLuongAllNV
    {
        public DateTime ThangID { get; set; }
        public decimal? TongLuongAllNv1 { get; set; }
        public string? MaQuanLy { get; set; }
        public string? TenQuanLy { get; set; }
        public int MaLuong { get; set; }
        public virtual NhanVien? MaQuanLyNavigation { get; set; }
    }
}
