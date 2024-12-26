using System.ComponentModel.DataAnnotations;
using WebQLLuongNV.Models;

namespace WebQLLuongNV.Models.ViewModel
{
    public class CTaiKhoan
    {
        [Display(Name = "Mã tài khoản")]
        [Required(ErrorMessage = "Bạn chưa nhập mã tài khoản!")]
        [StringLength(10, ErrorMessage = "Mã tài khoản không được vượt quá 10 ký tự!")]
        [RegularExpression(@"^TK.{8}$", ErrorMessage = "Mã tài khoản phải bắt đầu bằng 'TK' và có tổng cộng 10 ký tự!")]
        public string MaTaiKhoan { get; set; } = null!;

        [Display(Name = "Tên tài khoản")]
        [Required(ErrorMessage = "Bạn chưa nhập tên tài khoản!")]
        [StringLength(30, ErrorMessage = "Tên tài khoản không được vượt quá 30 ký tự!")]
        public string TenTaiKhoan { get; set; } = null!;

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Bạn chưa nhập mật khẩu!")]
        [StringLength(16, ErrorMessage = "Mật khẩu không được vượt quá 16 ký tự!")]
        public string MatKhau { get; set; } = null!;

        [Display(Name = "Chọn vai trò")]
        [Required(ErrorMessage = "Bạn chưa chọn vai trò!")]
        public int? MaVaiTro { get; set; }

        [Display(Name = "Chọn trạng thái")]
        [Required(ErrorMessage = "Bạn chưa chọn trạng thái!")]
        public string TrangThai { get; set; } = null!;
        public virtual VaiTro? MaVaiTroNavigation { get; set; }


        // Phương thức chuyển đổi từ Entity NhanVien sang ViewModel CNhanVien
        public static TaiKhoan chuyendoi(CTaiKhoan x)
        {
            return new TaiKhoan
            {
                MaTaiKhoan = x.MaTaiKhoan,
                TenTaiKhoan= x.TenTaiKhoan,
                MatKhau = x.MatKhau,
                MaVaiTro = x.MaVaiTro,
                TrangThai = x.TrangThai,
            };
        }

        // Phương thức chuyển đổi từ ViewModel CNhanVien sang Entity NhanVien
        public static CTaiKhoan chuyendoi(TaiKhoan x)
        {
            return new CTaiKhoan
            {
                MaTaiKhoan = x.MaTaiKhoan,
                TenTaiKhoan = x.TenTaiKhoan,
                MatKhau = x.MatKhau,
                MaVaiTro = x.MaVaiTro,
                TrangThai = x.TrangThai,
            };
        }
    }
}
