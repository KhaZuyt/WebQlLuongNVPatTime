using System.ComponentModel.DataAnnotations;

namespace WebQLLuongNV.Models.ViewModel
{
    public class CChitietcalamviec
    {
        public int IdcalamViec { get; set; }

        public int Id { get; set; }

        public int IdChiTietLichLam { get; set; }
        [Required(ErrorMessage = "Số lượng không được để trống không được để trống.")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải là số dương.")]
        public int SoLuong { get; set; }

        public static CChitietcalamviec chuyendoi(ChiTietCaLamViec x)
        {
            return new CChitietcalamviec
            {
                Id = x.Id,
                IdChiTietLichLam = x.IdChiTietLichLam,
                IdcalamViec = x.IdcaLamViec,
                SoLuong = x.SoLuong
            };
        }

        public static ChiTietCaLamViec chuyendoi(CChitietcalamviec x)
        {
            return new ChiTietCaLamViec
            {
                Id = x.Id,
                IdChiTietLichLam = x.IdChiTietLichLam,
                IdcaLamViec = x.IdcalamViec,
                SoLuong = x.SoLuong
            };
        }
    }
}
