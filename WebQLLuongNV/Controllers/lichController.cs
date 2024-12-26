using Microsoft.AspNetCore.Mvc;
using WebQLLuongNV.Models;
using System.Linq;
using System;
using Microsoft.EntityFrameworkCore;
using WebQLLuongNV.Models.ViewModel;

using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebQLLuongNV.Controllers
{

    [RoleAuthorize(1, 2)]
    public class LichController : Controller
    {
        private readonly QlnvpartTimeContext _context;
        private QlnvpartTimeContext db = new QlnvpartTimeContext();
        public LichController(QlnvpartTimeContext context)
        {
            _context = context;
        }


        public IActionResult Index(string timMa, DateTime? timNgay)
        {
            var lichLams = db.LichLams.AsQueryable(); // Lấy dữ liệu ban đầu

            // Kiểm tra điều kiện tìm kiếm theo Mã Lịch Làm
            if (!string.IsNullOrEmpty(timMa))
            {
                lichLams = lichLams.Where(x => x.MaLichLam.Contains(timMa));
            }

            // Kiểm tra điều kiện tìm kiếm theo Ngày
            if (timNgay.HasValue)
            {
                lichLams = lichLams.Where(x => x.ThuNgayThangNam.HasValue && x.ThuNgayThangNam.Value.Date == timNgay.Value.Date);
            }

            // Chuyển đổi kết quả từ IQueryable thành List
            List<LichLam> ds = lichLams.ToList(); // Sử dụng lichLams đã được lọc

            return View(ds); // Trả về View với dữ liệu đã lọc
        }

        public IActionResult formTaoLichLam()
        {
            return PartialView("formTaoLichLam");
        }
        public IActionResult taolichlam(LichLam model)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    // Lấy mã quản lý
                    var maQuanLy = db.NhanViens
                        .Join(db.TaiKhoans, nv => nv.MaTaiKhoan, tk => tk.MaTaiKhoan, (nv, tk) => new { nv, tk })
                        .Join(db.VaiTros, nvtk => nvtk.tk.MaVaiTro, vt => vt.MaVaiTro, (nvtk, vt) => new { nvtk.nv, vt })
                        .Where(result => result.vt.TenVaiTro == "Admin")
                        .Select(result => result.nv.MaNhanVien)
                        .FirstOrDefault() ?? "NV001";


                    var lichLam = new LichLam
                    {
                        MaLichLam = model.MaLichLam ?? $"LL{DateTime.Now.Ticks}",
                        ThuNgayThangNam = model.ThuNgayThangNam,
                        MaQuanLy = maQuanLy,
                        SoCaQuyDinh = model.SoCaQuyDinh // Tạm thời
                    };

                    db.LichLams.Add(lichLam);
                    db.SaveChanges();
                    return RedirectToAction("Index", model);


                }
                catch (Exception)
                {
                    ModelState.AddModelError("", "Lỗi khi thêm lịch ");

                }
            }
            return PartialView("formTaoLichLam");
        }
        public IActionResult formthembuoi_chitietlichlam(string id)
        {
            var result = db.ChiTietLichLams
                             .Include(ctl => ctl.ChiTietCaLamViecs)
                             .ThenInclude(ccv => ccv.IdcaLamViecNavigation)
                             .ToList();




            ViewBag.DSLoaicongviec = new SelectList(db.LoaiCongViecs.ToList(), "MaLoaiCongViec", "TenLoaiCongViec");
            LichLam l = db.LichLams.Find(id);
            return View(CLichLam.chuyendoi(l));
        }
        public IActionResult thembuoi_chitietlichlam(CChitietlichlam x)
        {
            if (ModelState.IsValid)
            {
                var chitietLichLam = CChitietlichlam.chuyendoi(x);
                db.ChiTietLichLams.Add(chitietLichLam); // Thêm ChiTietLichLam vào db


                try
                {
                    db.SaveChanges();  // Lưu tất cả thay đổi vào cơ sở dữ liệu
                    return RedirectToAction("Index"); // Điều hướng đến trang Index sau khi lưu thành công
                }
                catch (Exception ex)
                {
                    // Nếu có lỗi, bạn có thể ghi log hoặc thông báo cho người dùng
                    ModelState.AddModelError("", "Lưu không thành công. Lỗi: " + ex.Message);
                    return View("formthembuoi_chitietlichlam"); // Trả về view với thông báo lỗi
                }
            }
            ViewBag.DSLoaicongviec = new SelectList(db.LoaiCongViecs.ToList(), "MaLoaiCongViec", "TenLoaiCongViec");
            ViewBag.DScalamviec = new SelectList(db.CalamViecs.ToList(), "IdcalamViec", "TenCa");
            return View("formthembuoi_chitietlichlam"); // Trả về view nếu Model không hợp lệ
        }

        public IActionResult hienchitietBuoiLichlam(string id)
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
            var loaiCongViecs = db.LoaiCongViecs.ToList();
            ViewBag.DSLoaicongviec = new SelectList(db.LoaiCongViecs.ToList(), "MaLoaiCongViec", "TenLoaiCongViec");
            ViewBag.DScalamviec = new SelectList(db.CalamViecs.ToList(), "IdcalamViec", "TenCa");
            return View(ds);
        }

        public IActionResult formchitietcalamviec(int id)
        {
            var ctll = db.ChiTietLichLams.Find(id);
            if (ctll == null)
            {
                return NotFound();
            }

            // Tạo view model với IdChiTietLichLam được thiết lập
            var viewModel = new CChitietcalamviec
            {
                IdChiTietLichLam = ctll.IdChitietLichLam
            };

            ViewBag.DScalamviec = new SelectList(db.CalamViecs.ToList(), "IdcalamViec", "TenCa");
            return View(viewModel);
        }



        public IActionResult chitietcalamviec(CChitietcalamviec model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    db.ChiTietCaLamViecs.Add(CChitietcalamviec.chuyendoi(model));
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", "Lưu không thành công. Lỗi: " + ex.Message);
                    return View("formchitietcalamviec", model);
                }
            }
            ViewBag.DScalamviec = new SelectList(db.CalamViecs.ToList(), "IdcalamViec", "TenCa");
            return View("formchitietcalamviec", model);
        }

        public IActionResult xoacalamviec(int id, int idChiTietLichLam)
        {
            var caLamViec = db.ChiTietCaLamViecs.Find(id);
            if (caLamViec == null)
            {
                return NotFound();
            }
            db.ChiTietCaLamViecs.Remove(caLamViec);
            db.SaveChanges();
            return RedirectToAction("index");

        }

     




      
        [HttpGet]
        public IActionResult xoabuoichitietlam(int id)
        {
            try
            {
                // Tìm bản ghi ChiTietLichLam dựa trên Id
                var chitietlichlam = db.ChiTietLichLams.FirstOrDefault(ct => ct.IdChitietLichLam == id);
                if (chitietlichlam == null)
                {
                    TempData["ErrorMessage"] = "Không tìm thấy buổi làm nào.";
                    return RedirectToAction("Index");
                }

                // Tìm tất cả các ChiTietCaLamViec liên quan đến ChiTietLichLam
                var chitietcalamviec = db.ChiTietCaLamViecs.Where(ctcLv => ctcLv.IdChiTietLichLam == id).ToList();

                // Xóa tất cả các dữ liêụ ChiTietCaLamViec 
                db.ChiTietCaLamViecs.RemoveRange(chitietcalamviec);

                // Xóa bản ghi ChiTietLichLam
                db.ChiTietLichLams.Remove(chitietlichlam);

                // Lưu thay đổi vào cơ sở dữ liệu
                db.SaveChanges();

                TempData["SuccessMessage"] = "Đã xóa lịch làm thành công.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Có lỗi xảy ra khi xóa: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }


        [HttpGet]
        public IActionResult Delete(string id)
        {
            try
            {
                // Tìm lịch làm theo id
                var lichLam = _context.LichLams.FirstOrDefault(l => l.MaLichLam == id);
                if (lichLam == null)
                {
                    TempData["ErrorMessage"] = "Không tìm thấy lịch làm.";
                    return RedirectToAction(nameof(Index));
                }

                // Xóa các chi tiết liên quan
                var chiTietLichLams = _context.ChiTietLichLams.Where(c => c.MaLichLam == id).ToList();
                foreach (var chiTiet in chiTietLichLams)
                {
                    var chiTietCaLamViecs = _context.ChiTietCaLamViecs.Where(ca => ca.IdChiTietLichLam == chiTiet.IdChitietLichLam).ToList();
                    _context.ChiTietCaLamViecs.RemoveRange(chiTietCaLamViecs);
                }
                _context.ChiTietLichLams.RemoveRange(chiTietLichLams);

                // Xóa lịch làm
                _context.LichLams.Remove(lichLam);
                _context.SaveChanges();

                TempData["SuccessMessage"] = "Đã xóa lịch làm thành công.";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Có lỗi xảy ra khi xóa: {ex.Message}";
            }

            return RedirectToAction(nameof(Index));
        }


        public IActionResult formsuabuoilichlam(int id)
        {


            ViewBag.DSLoaicongviec = new SelectList(db.LoaiCongViecs.ToList(), "MaLoaiCongViec", "TenLoaiCongViec");
            ChiTietLichLam ctll = db.ChiTietLichLams.Find(id);
            return View(CChitietlichlam.chuyendoi(ctll));
        }
        public IActionResult suabuoilichlam(CChitietlichlam x)
        {
            if (ModelState.IsValid)
            {
                var chitietLichLam = CChitietlichlam.chuyendoi(x);
                db.ChiTietLichLams.Update(chitietLichLam); 


                try
                {
                    db.SaveChanges(); 
                    return RedirectToAction("Index"); 
                }
                catch (Exception ex)
                {
                  
                    ModelState.AddModelError("", "Lưu không thành công. Lỗi: " + ex.Message);
                    return View("formthembuoi_chitietlichlam");
                }
            }
          
            return View("formthembuoi_chitietlichlam");

        }




        // Phương thức trả về PartialView của form sửa
        public IActionResult formSuaLichLam(string id)

        {
           
            LichLam l = db.LichLams.Find(id);
            return PartialView("formSuaLichLam",l);
        }
        [HttpPost]
        public IActionResult sualichlam (LichLam x)
        {

            if (ModelState.IsValid) { 
           
                db.LichLams.Update(x);
                db.SaveChanges();
                return RedirectToAction("Index",x);
            }
         return View("index");
        }


    }




}

