using System;
using System.Collections.Generic;

namespace WebQLLuongNV.Models;

public partial class LoaiCongViec
{
    public string MaLoaiCongViec { get; set; } = null!;

    public string? TenLoaiCongViec { get; set; }

    public virtual ICollection<ChiTietLichLam> ChiTietLichLams { get; } = new List<ChiTietLichLam>();
}
