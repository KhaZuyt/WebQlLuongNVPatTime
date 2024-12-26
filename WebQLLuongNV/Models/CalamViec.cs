using System;
using System.Collections.Generic;

namespace WebQLLuongNV.Models;

public partial class CalamViec
{
    public int IdcalamViec { get; set; }

    public string? TenCa { get; set; }

    public TimeSpan? ThoiGian { get; set; }

    public decimal? Mucluong { get; set; }

    public virtual ICollection<ChiTietCaLamViec> ChiTietCaLamViecs { get; } = new List<ChiTietCaLamViec>();
}
