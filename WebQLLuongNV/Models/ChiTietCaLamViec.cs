using System;
using System.Collections.Generic;

namespace WebQLLuongNV.Models;

public partial class ChiTietCaLamViec
{
    public int IdChiTietLichLam { get; set; }

    public int IdcaLamViec { get; set; }

    public int SoLuong { get; set; }

    public int Id { get; set; }

    public virtual ChiTietLichLam IdChiTietLichLamNavigation { get; set; } = null!;

    public virtual CalamViec IdcaLamViecNavigation { get; set; } = null!;
}
