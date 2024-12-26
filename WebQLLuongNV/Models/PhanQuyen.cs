using System;
using System.Collections.Generic;

namespace WebQLLuongNV.Models;

public partial class PhanQuyen
{
    public int MaQuyen { get; set; }

    public string TenQuyen { get; set; } = null!;

    public virtual ICollection<VaiTro> MaVaiTros { get; } = new List<VaiTro>();
}
