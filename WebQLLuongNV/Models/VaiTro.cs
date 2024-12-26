using System;
using System.Collections.Generic;

namespace WebQLLuongNV.Models;

public partial class VaiTro
{
    public int MaVaiTro { get; set; }

    public string TenVaiTro { get; set; } = null!;

    public virtual ICollection<TaiKhoan> TaiKhoans { get; } = new List<TaiKhoan>();

    public virtual ICollection<PhanQuyen> MaQuyens { get; } = new List<PhanQuyen>();
}
