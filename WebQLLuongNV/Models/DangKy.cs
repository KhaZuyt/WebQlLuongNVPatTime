using System;
using System.Collections.Generic;

namespace WebQLLuongNV.Models;

public partial class DangKy
{
    public string MaLichLam { get; set; } = null!;

    public string MaNhanVien { get; set; } = null!;

    public DateTime? ThoiGianDky { get; set; }

    public bool? HoanThanh { get; set; }

    public int IdDangKy { get; set; }

    public int? IdchitietLichLam { get; set; }

    public string? LoaiDangKy { get; set; }

    public string? TrangThaiNhomCa { get; set; }

    public virtual ChiTietLichLam? IdchitietLichLamNavigation { get; set; }

    public virtual LichLam MaLichLamNavigation { get; set; } = null!;

    public virtual NhanVien MaNhanVienNavigation { get; set; } = null!;
}
