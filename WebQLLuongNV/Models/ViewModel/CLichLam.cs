using System.ComponentModel.DataAnnotations;
using WebQLLuongNV.Models;

namespace WebQLLuongNV.Models.ViewModel
{
    public class CLichLam
    {
        [Required(ErrorMessage = "Bạn chưa nhập mã lịch làm!")]
        [StringLength(50, ErrorMessage = "Mã lịch làm không được vượt quá 50 ký tự.")]
        public string MaLichLam { get; set; } = null!;

       
        public string? MaQuanLy { get; set; }

        [Required(ErrorMessage = "Thứ ngày tháng không hợp lệ!")]
        [DataType(DataType.Date, ErrorMessage = "Định dạng ngày tháng không hợp lệ.")]
        public DateTime? ThuNgayThangNam { get; set; }

        [Required(ErrorMessage = "Số ca quy định không được để trống!")]
        [Range(1, int.MaxValue, ErrorMessage = "Số ca quy định phải lớn hơn 0.")]
        public int? SoCaQuyDinh { get; set; }

        public virtual ICollection<ChiTietLichLam> ChiTietLichLams { get; } = new List<ChiTietLichLam>();

        public virtual ICollection<DangKy> DangKies { get; } = new List<DangKy>();

        public virtual NhanVien? MaQuanLyNavigation { get; set; }

        // Phương thức chuyển đổi
        public static LichLam chuyendoi(CLichLam x)
        {
            return new LichLam
            {
                MaLichLam = x.MaLichLam,
                MaQuanLy = x.MaQuanLy,
                ThuNgayThangNam = x.ThuNgayThangNam,
                SoCaQuyDinh = x.SoCaQuyDinh,
            };
        }

        public static CLichLam chuyendoi(LichLam x)
        {
            return new CLichLam
            {
                MaLichLam = x.MaLichLam,
                MaQuanLy = x.MaQuanLy,
                ThuNgayThangNam = x.ThuNgayThangNam,
                SoCaQuyDinh = x.SoCaQuyDinh,
            };
        }

        // Các thuộc tính chi tiết
        public int IdChitietLichLam { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Số ca công việc khác phải lớn hơn hoặc bằng 0.")]
        public int? SoCaCvk { get; set; }

        [DataType(DataType.Time, ErrorMessage = "Thời gian bắt đầu không hợp lệ.")]
        public TimeSpan? GioBd { get; set; }

        [DataType(DataType.Time, ErrorMessage = "Thời gian kết thúc không hợp lệ.")]
        public TimeSpan? GioKt { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Lương loại công việc phải lớn hơn hoặc bằng 0.")]
        [DataType(DataType.Currency, ErrorMessage = "Định dạng tiền tệ không hợp lệ.")]
        public decimal? LuongLoaiCv { get; set; }

        [StringLength(100, ErrorMessage = "Nơi làm không được vượt quá 100 ký tự.")]
        public string? NoiLam { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Tổng số ca quy định phải lớn hơn hoặc bằng 0.")]
        public int? TongSoCaQuyDinh { get; set; }

        [StringLength(50, ErrorMessage = "Mã loại công việc không được vượt quá 50 ký tự.")]
        public string? MaLoaiCongViec { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Số người làm phải lớn hơn hoặc bằng 0.")]
        public int? Songuoilam { get; set; }

        public virtual ICollection<ChiTietCaLamViec> ChiTietCaLamViecs { get; } = new List<ChiTietCaLamViec>();

        public virtual LichLam? MaLichLamNavigation { get; set; }

        public virtual LoaiCongViec? MaLoaiCongViecNavigation { get; set; }

        // Thuộc tính cho Ca làm việc
        public int IdcaLamViec { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Số lượng phải lớn hơn 0.")]
        public int SoLuong { get; set; }

        public virtual ChiTietLichLam IdChiTietLichLamNavigation { get; set; } = null!;

        public virtual CalamViec IdcaLamViecNavigation { get; set; } = null!;

        public int IdcalamViec { get; set; }

        [StringLength(100, ErrorMessage = "Tên ca không được vượt quá 100 ký tự.")]
        public string? TenCa { get; set; }

        [DataType(DataType.Time, ErrorMessage = "Thời gian không hợp lệ.")]
        public TimeSpan? ThoiGian { get; set; }
    }
}
