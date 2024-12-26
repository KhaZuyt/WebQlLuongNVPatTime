using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebQLLuongNV.Models;
using WebQLLuongNV.Models.ViewModel;
using System.Linq;

namespace WebQLLuongNV.Controllers
{
    [RoleAuthorize(1, 2)]
    public class luongController : Controller
    {
        QlnvpartTimeContext db = new QlnvpartTimeContext();

        public IActionResult Index()
        {
            // Lấy danh sách toàn bộ lịch làm và nhân viên
            var danhSachLuong = db.ChiTietLichLams
                .Join(db.DangKies,
                      ctl => ctl.IdChitietLichLam,
                      dk => dk.IdchitietLichLam,
                      (ctl, dk) => new { ctl, dk })
                .Select(x => new CBangluongNV
                {
                    MaNhanVien = x.dk.MaNhanVien,
                    TenNhanVien = x.dk.MaNhanVienNavigation.TenNhanVien,
                    MaLichLam = x.ctl.MaLichLam,
                    GioBatDau = x.ctl.GioBd,
                    GioKetThuc = x.ctl.GioKt,
                    ThuNgayThangNam = x.ctl.MaLichLamNavigation.ThuNgayThangNam,
                    TenCa = x.dk.LoaiDangKy == "PV" && x.dk.HoanThanh == true
                        ? (x.ctl.ChiTietCaLamViecs.Any()
                            ? x.ctl.ChiTietCaLamViecs.FirstOrDefault().IdcaLamViecNavigation.TenCa
                            : null)
                        : null,
                    NoiLam = x.dk.LoaiDangKy == "CVK" && x.dk.HoanThanh == true ? x.ctl.NoiLam : null,
                    TenLoaiCongViec = x.dk.LoaiDangKy == "CVK" && x.dk.HoanThanh == true
                        ? x.ctl.MaLoaiCongViecNavigation.TenLoaiCongViec
                        : null,
                    ThoiGianDky = x.dk.ThoiGianDky,
                    ThoiGian = x.dk.LoaiDangKy == "PV" && x.dk.HoanThanh == true
                        ? (x.ctl.ChiTietCaLamViecs.Any()
                            ? x.ctl.ChiTietCaLamViecs.FirstOrDefault().IdcaLamViecNavigation.ThoiGian
                            : null)
                        : null,
                    LoaiDangKy = x.dk.LoaiDangKy,
                    MucLuong = x.dk.HoanThanh == true
                        ? (x.dk.LoaiDangKy == "PV"
                            ? (x.ctl.ChiTietCaLamViecs.Any()
                                ? x.ctl.ChiTietCaLamViecs.FirstOrDefault().IdcaLamViecNavigation.Mucluong
                                : 0)
                            : (x.dk.LoaiDangKy == "CVK" ? x.ctl.LuongLoaiCv : 0))
                        : 0 // Nếu chưa hoàn thành, mức lương là 0
                })
                .ToList();

            // Nhóm và tính tổng lương theo lịch làm
            var tongLuongTheoLich = danhSachLuong
                .GroupBy(x => new { x.MaLichLam, x.ThuNgayThangNam })
                .Select(group => new CTongluongtheoLich
                {
                    MaLichLam = group.Key.MaLichLam,
                    ThuNgayThangNam = group.Key.ThuNgayThangNam,
                    TongLuongPV = group.Where(x => x.LoaiDangKy == "PV").Sum(x => x.MucLuong ?? 0),
                    TongLuongCVK = group.Where(x => x.LoaiDangKy == "CVK").Sum(x => x.MucLuong ?? 0),
                    TongLuongChung = group.Sum(x => x.MucLuong ?? 0),
                    ChiTiet = group.ToList() // Lấy toàn bộ nhân viên tham gia lịch làm
                })
                .ToList();

            return View(tongLuongTheoLich);
        }


        public IActionResult NhanVien()
        {
            var danhSachBangLuongTheoLich = db.BangLuongNvs
                .GroupBy(bl => bl.MaLichLam) // Nhóm theo MaLichLam
                .Select(group => new DSluong
                {
                    MaLich = group.Key, // Mã lịch làm
                    BangLuong = group.Select(bl => new CBangluongNV
                    {
                        MaLuong = bl.MaLuong,
                        TongLuong = bl.TongLuong,
                        TenNhanVien=bl.MaNhanVienNavigation.TenNhanVien,
                        MaNhanVien = bl.MaNhanVien,
                        MaQuanLy = bl.MaQuanLy,
                        ThangNam = bl.ThangNam,
                        MaLichLam = bl.MaLichLam
                    }).ToList()
                })
                .ToList();

            return View("luongmoinhanvien", danhSachBangLuongTheoLich);
        }











    }
}
