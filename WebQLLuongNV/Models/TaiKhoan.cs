using System;
using System.Collections.Generic;

namespace WebQLLuongNV.Models;

public partial class TaiKhoan
{
    public string MaTaiKhoan { get; set; } = null!;

    public string TenTaiKhoan { get; set; } = null!;

    public string MatKhau { get; set; } = null!;

    public int? MaVaiTro { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual VaiTro? MaVaiTroNavigation { get; set; }

    public virtual ICollection<NhanVien> NhanViens { get; } = new List<NhanVien>();
}
