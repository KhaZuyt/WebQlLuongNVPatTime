using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using WebQLLuongNV.Models;
using WebQLLuongNV.Models.ViewModel;
namespace WebQLLuongNV.Controllers

{
    
    [RoleAuthorize(1, 2, 3)] 
    public class HomeController : Controller
    {
        QlnvpartTimeContext db = new QlnvpartTimeContext();
        public IActionResult Index()
        {
            List<LichLam> ds = db.LichLams.ToList();
            /*      List<CLichLam> ds = lichLams.Select(x => CLichLam.chuyendoi(x)).ToList();*/
         
            ViewBag.VaiTro = HttpContext.Session.GetInt32("VaiTro");
            return View(ds);
        }

      
        public IActionResult Dashboard()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View("AccessDenied"); // Trang hiển thị thông báo "Không có quyền truy cập"
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public IActionResult formhienbuoidangky(string id)
        {
            var lichLam = db.LichLams.Find(id);
            if (lichLam == null)
            {
                return NotFound();
            }

            var ds = db.ChiTietLichLams
                .Where(x => x.MaLichLam == lichLam.MaLichLam)
                .Select(x => CChitietlichlam.chuyendoi(x))
                .ToList();

            foreach (var item in ds)
            {
                item.ChiTietCaLamViecs = db.ChiTietCaLamViecs
                    .Where(c => c.IdChiTietLichLam == item.IdChitietLichLam)
                    .ToList();
            }
            ViewBag.ThuNgayThangNam = lichLam.ThuNgayThangNam?.ToString("dddd, dd/MM/yyyy", new System.Globalization.CultureInfo("vi-VN"));
            var loaiCongViecs = db.LoaiCongViecs.ToList();
            ViewBag.DSlich = new SelectList(db.LichLams.ToList(), "MaLichLam", "ThuNgayThangNam");
            ViewBag.DSLoaicongviec = new SelectList(db.LoaiCongViecs.ToList(), "MaLoaiCongViec", "TenLoaiCongViec");
            ViewBag.DScalamviec = new SelectList(db.CalamViecs.ToList(), "IdcalamViec", "TenCa");
            return View("formhienbuoidangky",ds);
        }


        public IActionResult formthemcongvieckhac(string id)
        {
            var result = db.ChiTietLichLams
                              .Include(ctl => ctl.ChiTietCaLamViecs)
                              .ThenInclude(ccv => ccv.IdcaLamViecNavigation)
                              .ToList();




            ViewBag.DSLoaicongviec = new SelectList(db.LoaiCongViecs.ToList(), "MaLoaiCongViec", "TenLoaiCongViec");
            LichLam l = db.LichLams.Find(id);
            return View("formthemcongvieckhac",CLichLam.chuyendoi(l));
        }
        [HttpPost]
        public JsonResult DangKy(int idChitietLichLam, int idCaLamViec)
        {
            var chitiet = db.ChiTietLichLams.FirstOrDefault(c => c.IdChitietLichLam == idChitietLichLam);
            if (chitiet != null && (chitiet.Songuoilam ?? 0) < (chitiet.TongSoCaQuyDinh ?? 0))
            {
                chitiet.Songuoilam += 1; // Tăng số người làm
                db.SaveChanges();

                return Json(new { success = true, action = "dangky" }); // Trả về trạng thái
            }
            return Json(new { success = false, message = "Không thể đăng ký!" });
        }

        [HttpPost]
        public JsonResult HuyDangKy(int idChitietLichLam, int idCaLamViec)
        {
            var chitiet = db.ChiTietLichLams.FirstOrDefault(c => c.IdChitietLichLam == idChitietLichLam);
            if (chitiet != null && chitiet.Songuoilam > 0)
            {
                chitiet.Songuoilam -= 1; // Giảm số người làm
                db.SaveChanges();

                return Json(new { success = true, action = "huydangky" }); // Trả về trạng thái
            }
            return Json(new { success = false, message = "Không thể hủy đăng ký!" });
        }
        [HttpPost]
        public JsonResult DangKyCVK(int idChitietLichLam)
        {
            try
            {
                var maNhanVien = HttpContext.Session.GetString("MaNhanVien");
                if (string.IsNullOrEmpty(maNhanVien))
                {
                    return Json(new { success = false, message = "Bạn chưa đăng nhập!" });
                }

                var chitiet = db.ChiTietLichLams.FirstOrDefault(c => c.IdChitietLichLam == idChitietLichLam);

                if (chitiet != null && (chitiet.SonguoilamCvk ?? 0) < (chitiet.SoCaCvk ?? 0))
                {
                    chitiet.SonguoilamCvk = (chitiet.SonguoilamCvk ?? 0) + 1; // Tăng số người làm CVK
                    LuuDangKy(maNhanVien, idChitietLichLam, "CVK", "Đký");
                    db.SaveChanges();

                    return Json(new { success = true, message = "Đăng ký CVK thành công!" });
                }
                else
                {
                    return Json(new { success = false, message = "Số lượng đã đạt tối đa, không thể đăng ký!" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Lỗi khi đăng ký CVK: " + ex.Message });
            }
        }

        [HttpPost]
        public JsonResult HuyDangKyCVK(int idChitietLichLam)
        {
            try
            {
                var chitiet = db.ChiTietLichLams.FirstOrDefault(c => c.IdChitietLichLam == idChitietLichLam);

                if (chitiet != null && (chitiet.SonguoilamCvk ?? 0) > 0)
                {
                    chitiet.SonguoilamCvk -= 1; // Giảm số người làm CVK
                    db.SaveChanges();

                    return Json(new { success = true, message = "Hủy đăng ký CVK thành công!" });
                }
                else
                {
                    return Json(new { success = false, message = "Không thể hủy, số lượng hiện tại không hợp lệ!" });
                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Lỗi khi hủy đăng ký CVK: " + ex.Message });
            }
        }

        [HttpPost]
        public IActionResult XacNhanDangKy([FromBody] Dictionary<string, List<int>> danhSachDangKy)
        {
            var maNhanVien = HttpContext.Session.GetString("MaNhanVien");
            if (string.IsNullOrEmpty(maNhanVien))
            {
                return Json(new { success = false, message = "Bạn chưa đăng nhập!" });
            }

            if (danhSachDangKy == null || danhSachDangKy.Count == 0)
            {
                return Json(new { success = false, message = "Danh sách đăng ký trống hoặc không hợp lệ!" });
            }

            try
            {
                // Lưu danh sách đăng ký
                if (danhSachDangKy.ContainsKey("dangKyCLK"))
                {
                    foreach (var idChiTietLichLam in danhSachDangKy["dangKyCLK"])
                    {
                        LuuDangKy(maNhanVien, idChiTietLichLam, "PV", "Đký");
                    }
                }

                if (danhSachDangKy.ContainsKey("dangKyCVK"))
                {
                    foreach (var idChiTietLichLam in danhSachDangKy["dangKyCVK"])
                    {
                        LuuDangKy(maNhanVien, idChiTietLichLam, "CVK", "Đký");
                    }
                }

                db.SaveChanges();
                return Json(new { success = true, message = "Xác nhận đăng ký thành công!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Lỗi xảy ra: " + ex.Message });
            }
        }

        private void LuuDangKy(string maNhanVien, int idChiTietLichLam, string loaiDangKy, string trangThaiNhomCa)
        {
            var chiTiet = db.ChiTietLichLams.FirstOrDefault(c => c.IdChitietLichLam == idChiTietLichLam);
            if (chiTiet != null)
            {
                // Tạo bản ghi mới cho CVK
                if (loaiDangKy == "CVK")
                {
                    var dangKyMoi = new DangKy
                    {
                        IdchitietLichLam = idChiTietLichLam,
                        MaLichLam = chiTiet.MaLichLam,
                        MaNhanVien = maNhanVien,
                        LoaiDangKy = loaiDangKy,
                        TrangThaiNhomCa = trangThaiNhomCa,
                        ThoiGianDky = DateTime.Now,
                        HoanThanh = false
                    };

                    db.DangKies.Add(dangKyMoi); // Thêm mới bản ghi
                }
                else
                {
                    // Logic ghi đè cho các loại khác (nếu cần)
                    var dangKy = db.DangKies.FirstOrDefault(d => d.IdchitietLichLam == idChiTietLichLam && d.MaNhanVien == maNhanVien);
                    if (dangKy == null)
                    {
                        dangKy = new DangKy
                        {
                            IdchitietLichLam = idChiTietLichLam,
                            MaLichLam = chiTiet.MaLichLam,
                            MaNhanVien = maNhanVien,
                            LoaiDangKy = loaiDangKy,
                            TrangThaiNhomCa = trangThaiNhomCa,
                            ThoiGianDky = DateTime.Now,
                            HoanThanh = false
                        };

                        db.DangKies.Add(dangKy);
                    }
                    else
                    {
                        dangKy.LoaiDangKy = loaiDangKy;
                        dangKy.TrangThaiNhomCa = trangThaiNhomCa;
                        dangKy.ThoiGianDky = DateTime.Now;
                    }
                }
            }
        }


        [HttpGet]
        public JsonResult GetDanhSachDangKyCVK()
        {
            var maNhanVien = HttpContext.Session.GetString("MaNhanVien");

            if (string.IsNullOrEmpty(maNhanVien))
            {
                return Json(new { success = false, message = "Bạn chưa đăng nhập!" });
            }

            // Lấy danh sách các đăng ký CVK của nhân viên
            var danhSachDangKy = db.DangKies
                .Where(dk => dk.MaNhanVien == maNhanVien && dk.LoaiDangKy == "CVK")
                .Select(dk => dk.IdchitietLichLam)
                .ToList();

            return Json(new { success = true, data = danhSachDangKy });
        }




        [HttpGet]
        public JsonResult GetDanhSachDaDangKy()
        {
            var maNhanVien = HttpContext.Session.GetString("MaNhanVien");

            if (string.IsNullOrEmpty(maNhanVien))
            {
                return Json(new { success = false, message = "Bạn chưa đăng nhập!" });
            }

            // Lấy danh sách đã đăng ký
            var danhSachDangKy = db.DangKies
                .Where(dk => dk.MaNhanVien == maNhanVien)
                .Select(dk => new
                {
                    dk.IdchitietLichLam,
                    dk.LoaiDangKy,
                    dk.TrangThaiNhomCa,
                    dk.ThoiGianDky
                })
                .ToList();

            return Json(new { success = true, data = danhSachDangKy });
        }


        public IActionResult XemChiTiet(int idChiTietLichLam)
        {
            var chiTietLichLam = db.ChiTietLichLams.FirstOrDefault(cl => cl.IdChitietLichLam == idChiTietLichLam);
            if (chiTietLichLam != null)
            {
                ViewBag.SoNguoiLam = chiTietLichLam.Songuoilam;
            }
            else
            {
                ViewBag.SoNguoiLam = 0;
            }
            var danhSachDangKy = (from dk in db.DangKies
                                  join nv in db.NhanViens on dk.MaNhanVien equals nv.MaNhanVien
                                  join cll in db.ChiTietLichLams on dk.IdchitietLichLam equals cll.IdChitietLichLam
                                  join lcv in db.LoaiCongViecs on cll.MaLoaiCongViec equals lcv.MaLoaiCongViec
                                  where dk.IdchitietLichLam == idChiTietLichLam
                                  select new CDangky
                                  {
                                      IdChitietLichLam=cll.IdChitietLichLam,
                                      IdDangKy=dk.IdDangKy,
                                      MaNhanVien = nv.MaNhanVien,
                                      TenNhanVien = nv.TenNhanVien,
                                      ThoiGianDK = dk.ThoiGianDky,
                                      LoaiDangKy = dk.LoaiDangKy,
                                      TrangThaiNhomCa = dk.HoanThanh == true ? "Hoàn thành" : "Chưa hoàn thành",
                                      GioBatDau = cll.GioBd,
                                      GioKetThuc = cll.GioKt,
                                      NoiLam = cll.NoiLam,
                                      MaLoaiCongViec = lcv.MaLoaiCongViec,
                                      TenLoaiCongViec = lcv.TenLoaiCongViec
                                  }).ToList();
            var tenCa = (from ctclv in db.ChiTietCaLamViecs
                         join clv in db.CalamViecs on ctclv.IdcaLamViec equals clv.IdcalamViec
                         where ctclv.IdChiTietLichLam == idChiTietLichLam
                         select clv.TenCa).FirstOrDefault();

            // Truyền tên ca 
            ViewBag.TenCa = tenCa ?? "Chưa xác định";
            ViewBag.IdChiTietLichLam = idChiTietLichLam;
            return View("DanhSachDangKy",danhSachDangKy);
        }


     
        [HttpPost]
        [ValidateAntiForgeryToken]
        [RoleAuthorize(1, 2)]
        public IActionResult HuyDangKyinDS(int idDangKy)
        {
            try
            {
                // Tìm đăng ký cần hủy
                var dangKy = db.DangKies.Find(idDangKy);
                if (dangKy != null)
                {
                    // Tìm chi tiết lịch làm liên quan
                    var chiTietLichLam = db.ChiTietLichLams.FirstOrDefault(cl => cl.IdChitietLichLam == dangKy.IdchitietLichLam);
                    if (chiTietLichLam != null)
                    {
                        // Giảm số người làm
                        chiTietLichLam.Songuoilam = chiTietLichLam.Songuoilam - 1;
                        db.ChiTietLichLams.Update(chiTietLichLam);
                    }
                    db.DangKies.Remove(dangKy);
                    db.SaveChanges();
                    TempData["SuccessMessage"] = "Hủy đăng ký thành công.";
                }
                else
                {
                    TempData["ErrorMessage"] = "Không tìm thấy đăng ký cần hủy.";
                }
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Có lỗi xảy ra khi hủy đăng ký: " + ex.Message;
            }

            // Quay lại danh sách đăng ký
            return RedirectToAction("XemChiTiet", new { idChiTietLichLam = ViewBag.IdChiTietLichLam });
        }


    

    }
}
