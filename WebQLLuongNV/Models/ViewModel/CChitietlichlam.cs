using System.ComponentModel.DataAnnotations;

using WebQLLuongNV.Models;
namespace WebQLLuongNV.Models.ViewModel
{
    public class CChitietlichlam
    {

        public int IdChitietLichLam { get; set; }

        public string? MaLichLam { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Số ca CVK phải là số dương.")]
        public int? SoCaCvk { get; set; }

        public TimeSpan? GioBd { get; set; }

        public TimeSpan? GioKt { get; set; }
        [Range(0, double.MaxValue, ErrorMessage = "Lương loại công việc phải lớn hơn hoặc bằng 0.")]
        public decimal? LuongLoaiCv { get; set; }
        [Required(ErrorMessage = "Nơi làm không được để trống ")]
        [StringLength(200, ErrorMessage = "Nơi làm không được vượt quá 200 ký tự.")]
        public string? NoiLam { get; set; }
        [Required(ErrorMessage = "Tổng số ca quy đijnh không được để trống ")]
        [Range(0, int.MaxValue, ErrorMessage = "Tổng số ca quy định phải là số dương.")]
        public int? TongSoCaQuyDinh { get; set; }

        public string? MaLoaiCongViec { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Số người làm phải là số dương.")]
        public int? Songuoilam { get; set; }
        [Range(0, int.MaxValue, ErrorMessage = "Số người làm CVK phải là số dương.")]
        public int? SonguoilamCvk { get; set; }

        /*        public virtual ICollection<ChiTietCaLamViec> ChiTietCaLamViecs { get; } = new List<ChiTietCaLamViec>();
        */
        public List<ChiTietCaLamViec> ChiTietCaLamViecs { get; set; } = new List<ChiTietCaLamViec>();
        public virtual LichLam? MaLichLamNavigation { get; set; }
        public virtual LoaiCongViec ? MaLoaiCongViecNavigation { get; set; }

     


        public static ChiTietLichLam chuyendoi(CChitietlichlam x)
        {
            return new ChiTietLichLam { 
                IdChitietLichLam=x.IdChitietLichLam,
                MaLichLam = x.MaLichLam,
                SoCaCvk = x.SoCaCvk,
                GioBd=x.GioBd,
                GioKt=x.GioKt,
                LuongLoaiCv=x.LuongLoaiCv,
                NoiLam=x.NoiLam,
                TongSoCaQuyDinh=x.TongSoCaQuyDinh,
                MaLoaiCongViec=x.MaLoaiCongViec,
                Songuoilam = x.Songuoilam,
                SonguoilamCvk=x.SonguoilamCvk,  


            };
        }

        public static CChitietlichlam chuyendoi(ChiTietLichLam x)
        {
            return new CChitietlichlam
            {
                IdChitietLichLam = x.IdChitietLichLam,
                MaLichLam = x.MaLichLam,
                SoCaCvk = x.SoCaCvk,
                GioBd = x.GioBd,
                GioKt = x.GioKt,
                LuongLoaiCv = x.LuongLoaiCv,
                NoiLam = x.NoiLam,
                TongSoCaQuyDinh = x.TongSoCaQuyDinh,
                MaLoaiCongViec = x.MaLoaiCongViec,
                Songuoilam = x.Songuoilam,
                SonguoilamCvk = x.SonguoilamCvk,

            };
        }


    }
}
