using System;
using System.Collections.Generic;

namespace WebQLLuongNV.Models;

public partial class ChiTietLichLam
{
    public int IdChitietLichLam { get; set; }

    public string? MaLichLam { get; set; }

    public int? SoCaCvk { get; set; }

    public TimeSpan? GioBd { get; set; }

    public TimeSpan? GioKt { get; set; }

    public decimal? LuongLoaiCv { get; set; }

    public string? NoiLam { get; set; }

    public int? TongSoCaQuyDinh { get; set; }

    public string? MaLoaiCongViec { get; set; }

    public int? Songuoilam { get; set; }

    public int? SonguoilamCvk { get; set; }

    public virtual ICollection<ChiTietCaLamViec> ChiTietCaLamViecs { get; } = new List<ChiTietCaLamViec>();

    public virtual ICollection<DangKy> DangKies { get; } = new List<DangKy>();

    public virtual LichLam? MaLichLamNavigation { get; set; }

    public virtual LoaiCongViec? MaLoaiCongViecNavigation { get; set; }
}
