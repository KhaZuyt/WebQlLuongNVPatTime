using System;
using System.Collections.Generic;

namespace WebQLLuongNV.Models;

public partial class NhanVien
{
    public string MaNhanVien { get; set; } = null!;

    public string? TenNhanVien { get; set; }

    public string Cmnd { get; set; } = null!;

    public string Sdt { get; set; } = null!;

    public string? Email { get; set; }

    public string? MaTaiKhoan { get; set; }

    public virtual ICollection<BangLuongNv> BangLuongNvs { get; } = new List<BangLuongNv>();

    public virtual ICollection<DangKy> DangKies { get; } = new List<DangKy>();

    public virtual ICollection<LichLam> LichLams { get; } = new List<LichLam>();

    public virtual TaiKhoan? MaTaiKhoanNavigation { get; set; }

    public virtual ICollection<TongLuongAllnv> TongLuongAllnvs { get; } = new List<TongLuongAllnv>();
}
