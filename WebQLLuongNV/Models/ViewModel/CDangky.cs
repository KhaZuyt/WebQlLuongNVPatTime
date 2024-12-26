namespace WebQLLuongNV.Models.ViewModel
{
    public class CDangky
    {
        // Thông tin lịch làm
        public string MaLichLam { get; set; }
        public DateTime? ThuNgayThangNam { get; set; }

        // Thông tin đăng ký
        public int IdChitietLichLam { get; set; }
        public string MaNhanVien { get; set; }
        public string TenNhanVien { get; set; }
        public DateTime? ThoiGianDK { get; set; }
        public string LoaiDangKy { get; set; }

        public string TrangThaiNhomCa { get; set; }
        public TimeSpan? GioBatDau { get; set; }
        public string? TenCa { get; set; }

        public bool? HoanThanh { get; set; }

        public int IdDangKy { get; set; }

        public TimeSpan? GioKetThuc { get; set; }
        public string NoiLam { get; set; }
        public string MaLoaiCongViec { get; set; } // Mã loại công việc
        public string TenLoaiCongViec { get; set; } // Tên loại công việc
    }

}
