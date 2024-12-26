using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQLLuongNV.Models;
using WebQLLuongNV.Models.ViewModel;

namespace WebQLLuongNV.Controllers
{
    [RoleAuthorize(1, 2,3)]
    public class luongcanhanController : Controller
    {
        QlnvpartTimeContext db = new QlnvpartTimeContext();
     
        public IActionResult Index()
        {
      
            // Lấy mã nhân viên từ session
            var maNhanVien = HttpContext.Session.GetString("MaNhanVien");

            if (string.IsNullOrEmpty(maNhanVien))
            {
                return RedirectToAction("Index", "Authentication_Login");
            }

            var danhSachLuong = db.ChiTietLichLams
                .Join(db.DangKies,
                      ctl => ctl.IdChitietLichLam,
                      dk => dk.IdchitietLichLam,
                      (ctl, dk) => new { ctl, dk })
                .Where(x => x.dk.MaNhanVien == maNhanVien && x.dk.HoanThanh == true)
                .Select(x => new CBangluongNV
                {
                    MaNhanVien = maNhanVien,
                    TenNhanVien = x.dk.MaNhanVienNavigation.TenNhanVien,
                    MaLichLam = x.ctl.MaLichLam,
                    GioBatDau = x.ctl.GioBd,
                    GioKetThuc = x.ctl.GioKt,
                    ThuNgayThangNam = x.ctl.MaLichLamNavigation.ThuNgayThangNam,
                    TenCa = x.dk.LoaiDangKy == "PV"
                        ? (x.ctl.ChiTietCaLamViecs.Any()
                            ? x.ctl.ChiTietCaLamViecs.FirstOrDefault().IdcaLamViecNavigation.TenCa
                            : null)
                        : null,
                    NoiLam = x.dk.LoaiDangKy == "CVK" ? x.ctl.NoiLam : null,
                    TenLoaiCongViec = x.dk.LoaiDangKy == "CVK"
                        ? x.ctl.MaLoaiCongViecNavigation.TenLoaiCongViec
                        : null,
                    ThoiGianDky = x.dk.ThoiGianDky,
                    ThoiGian = x.dk.LoaiDangKy == "PV"
               ? (x.ctl.ChiTietCaLamViecs.Any()
                   ? x.ctl.ChiTietCaLamViecs.FirstOrDefault().IdcaLamViecNavigation.ThoiGian
                   : null)
               : null,
                    LoaiDangKy = x.dk.LoaiDangKy,
                    MucLuong = x.dk.LoaiDangKy == "PV"
                        ? (x.ctl.ChiTietCaLamViecs.Any()
                            ? x.ctl.ChiTietCaLamViecs.FirstOrDefault().IdcaLamViecNavigation.Mucluong
                            : 0)
                        : x.ctl.LuongLoaiCv
                })
                .ToList();

            var tongLuongTheoLich = danhSachLuong
                .GroupBy(x => new { x.MaLichLam, x.ThuNgayThangNam })
                .Select(group => new CTongluongtheoLich
                {
                    MaLichLam = group.Key.MaLichLam,
                    ThuNgayThangNam = group.Key.ThuNgayThangNam,
                    TongLuongPV = group.Where(x => x.LoaiDangKy == "PV").Sum(x => x.MucLuong ?? 0),
                    TongLuongCVK = group.Where(x => x.LoaiDangKy == "CVK").Sum(x => x.MucLuong ?? 0),
                    TongLuongChung = group.Sum(x => x.MucLuong ?? 0),
                    ChiTiet = group.ToList()
                })
                .ToList();

            return View(tongLuongTheoLich);
        }

        [HttpPost]
        public IActionResult GuiVeAdmin(string maNhanVien, decimal tongLuongChung, string maLichLam)
        {
            var thangNam = DateTime.Now;
            var ngay = thangNam.Date;

            var maQuanLy = db.NhanViens
                .Join(db.TaiKhoans, nv => nv.MaTaiKhoan, tk => tk.MaTaiKhoan, (nv, tk) => new { nv, tk })
                .Join(db.VaiTros, nvtk => nvtk.tk.MaVaiTro, vt => vt.MaVaiTro, (nvtk, vt) => new { nvtk.nv, vt })
                .Where(result => result.vt.TenVaiTro == "Admin")
                .Select(result => result.nv.MaNhanVien)
                .FirstOrDefault() ?? "NV001";

            // Kiểm tra ràng buộc
            var exists = db.BangLuongNvs
                .Any(bl => bl.MaNhanVien == maNhanVien
                           && bl.ThangNam.Value.Date == ngay
                           && bl.ThangNam.Value.Month == thangNam.Month
                           && bl.ThangNam.Value.Year == thangNam.Year
                           && bl.MaLichLam == maLichLam);

            if (exists)
            {
                TempData["ErrorMessage"] = "Bảng lương đã được gửi cho mã lịch làm này!";
                return RedirectToAction("Index");
            }

            // Tạo đối tượng BangLuongNv
            var bangLuong = new BangLuongNv
            {
                MaNhanVien = maNhanVien,
                TongLuong = tongLuongChung,
                ThangNam = thangNam,
                MaQuanLy = maQuanLy,
                MaLichLam = maLichLam // Gán giá trị MaLichLam
            };

            db.BangLuongNvs.Add(bangLuong);
            try
            {
                db.SaveChanges();
                TempData["SuccessMessage"] = "Đã gửi bảng lương thành công!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Đã xảy ra lỗi: " + ex.Message;
                return RedirectToAction("Index");
            }
        }




    }
}
