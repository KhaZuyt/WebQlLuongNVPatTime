using System;
using System.Collections.Generic;

namespace WebQLLuongNV.Models;

public partial class TongLuongAllnv
{
    public DateTime ThangID { get; set; }

    public decimal? TongLuongAllNv1 { get; set; }

    public string? MaQuanLy { get; set; }

    public int MaLuong { get; set; }

    public virtual BangLuongNv MaLuongNavigation { get; set; } = null!;

    public virtual NhanVien? MaQuanLyNavigation { get; set; }
}
