using System.ComponentModel.DataAnnotations;

namespace WebQLLuongNV.Models.ViewModel
{
    public class CNhanVien
    {
        [Display(Name = "Mã nhân viên")]
        [Required(ErrorMessage = "Bạn chưa nhập mã nhân viên!")]
        public string MaNhanVien { get; set; } = null!;

        [Display(Name = "Tên nhân viên")]
        [Required(ErrorMessage = "Bạn chưa nhập tên nhân viên!")]
        public string? TenNhanVien { get; set; } = null!;

        [Display(Name = "CMND")]
        [Required(ErrorMessage = "Bạn chưa nhập CMND!")]
        public string Cmnd { get; set; } = null!;

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Bạn chưa nhập số điện thoại!")]
        public string Sdt { get; set; } = null!;

        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Email không hợp lệ!")]
        public string? Email { get; set; }

        [Display(Name = "Mã-Tên tài khoản")]
        [Required(ErrorMessage = "Mã tài khoản không hợp lệ")]
        public string? MaTaiKhoan { get; set; }

        public virtual TaiKhoan? MaTaiKhoanNavigation { get; set; }

        // Phương thức chuyển đổi từ Entity NhanVien sang ViewModel CNhanVien
        public static NhanVien chuyendoi(CNhanVien x)
        {
            return new NhanVien
            {
                MaNhanVien = x.MaNhanVien,
                TenNhanVien = x.TenNhanVien,
                Cmnd = x.Cmnd,
                Sdt = x.Sdt,
                Email = x.Email,
                MaTaiKhoan = x.MaTaiKhoan
            };
        }

        public static CNhanVien chuyendoi(NhanVien x)
        {
            return new CNhanVien
            {
                MaNhanVien = x.MaNhanVien,
                TenNhanVien = x.TenNhanVien,
                Cmnd = x.Cmnd,
                Sdt = x.Sdt,
                Email = x.Email,
                MaTaiKhoan = x.MaTaiKhoan
            };
        }
    }
}
