using System;
using System.Collections.Generic;

namespace WebQLLuongNV.Models;

public partial class BangLuongNv
{
    public int MaLuong { get; set; }

    public decimal? TongLuong { get; set; }

    public string? MaNhanVien { get; set; }

    public string? MaQuanLy { get; set; }

    public DateTime? ThangNam { get; set; }

    public string? MaLichLam { get; set; }

    public virtual LichLam? MaLichLamNavigation { get; set; }

    public virtual NhanVien? MaNhanVienNavigation { get; set; }

    public virtual ICollection<TongLuongAllnv> TongLuongAllnvs { get; } = new List<TongLuongAllnv>();
}
