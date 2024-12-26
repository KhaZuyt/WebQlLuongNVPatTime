namespace WebQLLuongNV.Models.ViewModel
{
    public class CTongluongtheoLich
    {
        public string MaLichLam { get; set; }
        public string MaNhanVien { get; set; } = null!;

        public string? TenNhanVien { get; set; }
        public DateTime? ThuNgayThangNam { get; set; }
        public decimal TongLuongPV { get; set; }
        public decimal TongLuongCVK { get; set; }
        public decimal TongLuongChung { get; set; }
        public List<CBangluongNV> ChiTiet { get; set; }

    }
}
