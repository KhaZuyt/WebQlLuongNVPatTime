namespace WebQLLuongNV.Models.ViewModel
{
    public class CBangluongNV
    {
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public int MaLuong { get; set; }
        public DateTime? ThangNam { get; set; }
        public DateTime? ThuNgayThangNam { get; set; }
        public string TenCa { get; set; }
        public string MaLichLam { get; set; }
        public string NoiLam { get; set; }
        public virtual LichLam? MaLichLamNavigation { get; set; }

        public virtual NhanVien? MaNhanVienNavigation { get; set; }
        public string? MaQuanLy { get; set; }
        public TimeSpan? GioBatDau { get; set; }
        public TimeSpan? GioKetThuc { get; set; }
        public string TenLoaiCongViec { get; set; }
        public DateTime? ThoiGianDky { get; set; }
        public TimeSpan? ThoiGian { get; set; }
        public string LoaiDangKy { get; set; }

    
        public decimal? MucLuong { get; set; }
        public decimal? TongLuong { get; set; }
        public bool HoanThanh { get; set; }
    }
}
