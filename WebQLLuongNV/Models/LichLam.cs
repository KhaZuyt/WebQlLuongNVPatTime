using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebQLLuongNV.Models;

public partial class LichLam
{
    [Required(ErrorMessage = "Mã lịch làm là bắt buộc.")]
    [RegularExpression(@"^LL.{8}$", ErrorMessage = "Mã lịch làm phải bắt đầu bằng 'LL' và có đủ 10 ký tự.")]
    public string MaLichLam { get; set; } = null!;
    [Required(ErrorMessage = "Mã lịch làm là bắt buộc.")]
    public string? MaQuanLy { get; set; }
    [Required(ErrorMessage = "Thứ ngày tháng không hợp lệ!")]
    [DataType(DataType.Date, ErrorMessage = "Định dạng ngày tháng không hợp lệ.")]
    public DateTime? ThuNgayThangNam { get; set; }
    [Required(ErrorMessage = "Số ca quy định không được để trống!")]
    [Range(1, int.MaxValue, ErrorMessage = "Số ca quy định phải lớn hơn 0.")]
    public int? SoCaQuyDinh { get; set; }

    public virtual ICollection<BangLuongNv> BangLuongNvs { get; } = new List<BangLuongNv>();

    public virtual ICollection<ChiTietLichLam> ChiTietLichLams { get; } = new List<ChiTietLichLam>();

    public virtual ICollection<DangKy> DangKies { get; } = new List<DangKy>();

    public virtual NhanVien? MaQuanLyNavigation { get; set; }
}
