using Microsoft.AspNetCore.Mvc;
using WebQLLuongNV.Models;
using WebQLLuongNV.Models.ViewModel;

namespace WebQLLuongNV.Controllers
{
    public class DangkyController : Controller
    {
        QlnvpartTimeContext  db = new QlnvpartTimeContext();
        [HttpGet]
        public IActionResult Index()
        {
            // Lấy mã nhân viên từ session
            var maNhanVien = HttpContext.Session.GetString("MaNhanVien");

            if (string.IsNullOrEmpty(maNhanVien))
            {
                return RedirectToAction("Index", "Authentication_Login");
            }

            // Lấy danh sách lịch làm và chi tiết đăng ký liên quan đến nhân viên
            var danhSachDangKy = db.DangKies
                .Where(dk => dk.MaNhanVien == maNhanVien)
                .Select(dk => new CDangky
                {
                    // Thông tin lịch làm
                    MaLichLam = dk.MaLichLam,
                    ThuNgayThangNam = dk.MaLichLamNavigation.ThuNgayThangNam,
                    TenCa = dk.IdchitietLichLamNavigation.ChiTietCaLamViecs
                .FirstOrDefault(ccv => ccv.IdChiTietLichLam == dk.IdchitietLichLam)
                .IdcaLamViecNavigation.TenCa,
                    // Thông tin chi tiết đăng ký
                    IdDangKy =dk.IdDangKy,
                    HoanThanh=dk.HoanThanh,
                    MaNhanVien = dk.MaNhanVien,
                    TenNhanVien = dk.MaNhanVienNavigation.TenNhanVien,
                    ThoiGianDK = dk.ThoiGianDky,
                    LoaiDangKy = dk.LoaiDangKy,
                    TrangThaiNhomCa = dk.HoanThanh == true ? "Hoàn thành" : "Chưa hoàn thành",
                    GioBatDau = dk.IdchitietLichLamNavigation.GioBd,
                    GioKetThuc = dk.IdchitietLichLamNavigation.GioKt,
                    NoiLam = dk.IdchitietLichLamNavigation.NoiLam,
                    MaLoaiCongViec = dk.IdchitietLichLamNavigation.MaLoaiCongViec,
                    TenLoaiCongViec = dk.IdchitietLichLamNavigation.MaLoaiCongViecNavigation.TenLoaiCongViec
                }).ToList();

            return View(danhSachDangKy);
        }
        [HttpPost]
        public JsonResult UpdateHoanThanh([FromBody] UpdateHoanThanhRequest request)
        {
            try
            {
                // Tìm bản ghi trong bảng DangKies theo IdDangKy
                var dangKy = db.DangKies.FirstOrDefault(d => d.IdDangKy == request.IdDangKy);

                // Nếu không tìm thấy bản ghi, trả về lỗi
                if (dangKy == null)
                {
                    return Json(new { success = false, message = $"Không tìm thấy bản ghi với IdDangKy: {request.IdDangKy}" });
                }

                // Cập nhật trạng thái HoanThanh
                dangKy.HoanThanh = request.HoanThanh;
                db.SaveChanges(); // Lưu thay đổi

                return Json(new { success = true, message = "Cập nhật trạng thái thành công!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Lỗi xảy ra: " + ex.Message });
            }
        }



        // Class nhận dữ liệu từ client
        public class UpdateHoanThanhRequest
        {
            public int IdDangKy { get; set; }
            public bool HoanThanh { get; set; } // Bool chuyển đổi sang bit trong SQL Server
        }




    }
}
