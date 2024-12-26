using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebQLLuongNV.Models;
using WebQLLuongNV.Models.ViewModel;

namespace WebQLLuongNV.Controllers
{
    [RoleAuthorize(1)] // Chỉ Admin được phép truy cập
    public class taikhoannhanvienController : Controller
    {
        private readonly QlnvpartTimeContext _context;
        private QlnvpartTimeContext db = new QlnvpartTimeContext();
        public taikhoannhanvienController(QlnvpartTimeContext context)
        {
            _context = context;
        }
  
        public IActionResult Index(string timMa, string timTen)
        {
            var tk = db.TaiKhoans.AsQueryable();

            if (!string.IsNullOrEmpty(timMa))
            {
                tk = tk.Where(x => x.MaTaiKhoan.Contains(timMa));
            }

            if (!string.IsNullOrEmpty(timTen))
            {
                tk = tk.Where(x => x.TenTaiKhoan.Contains(timTen));
            }
            List<CTaiKhoan> ds = tk.Select(x => CTaiKhoan.chuyendoi(x)).ToList();
            foreach(var t in ds)
            {
                t.MaVaiTroNavigation= db.VaiTros.Find(t.MaVaiTro);
            }
            return View(ds);
        }
        [HttpPost]
        public IActionResult login(string username, string password)
        {
            // Check for the user in TaiKhoans table
            var user = _context.TaiKhoans.FirstOrDefault(t => t.TenTaiKhoan == username && t.MatKhau == password && t.TrangThai == "Active");

            if (user != null)
            {
                // Find the associated NhanVien
                var nhanVien = _context.NhanViens.FirstOrDefault(nv => nv.MaTaiKhoan == user.MaTaiKhoan);

                // Store required information in session
                HttpContext.Session.SetString("TenTaiKhoan", user.TenTaiKhoan);
                HttpContext.Session.SetInt32("VaiTro", user.MaVaiTro ?? 0);

                if (nhanVien != null)
                {
                    HttpContext.Session.SetString("MaNhanVien", nhanVien.MaNhanVien);
                    HttpContext.Session.SetString("TenNhanVien", nhanVien.TenNhanVien); // Store TenNhanVien in session
                }

                // Redirect to Home/Index
                return RedirectToAction("Index", "Home");
            }

            // If login fails, show error message
            ViewBag.ErrorMessage = "Tên đăng nhập hoặc mật khẩu không đúng!";
            return View("Index");
        }


        public IActionResult formThemTaiKhoan()
        {
            ViewBag.DSmavaitro = new SelectList(db.VaiTros.ToList(), "MaVaiTro", "TenVaiTro");
            return View();
        }
        [HttpPost]
        public IActionResult themTaiKhoan(CTaiKhoan model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DSmavaitro = new SelectList(db.VaiTros.ToList(), "MaVaiTro", "TenVaiTro");
                TempData["ErrorMessage"] = "Dữ liệu không hợp lệ. Vui lòng kiểm tra lại!";
                return View(model);
            }

            try
            {
                // Chuyển đổi từ ViewModel sang Entity
                var taiKhoan = CTaiKhoan.chuyendoi(model);

                // Kiểm tra tài khoản đã tồn tại chưa
                if (db.TaiKhoans.Any(tk => tk.MaTaiKhoan == model.MaTaiKhoan))
                {
                    TempData["ErrorMessage"] = "Tài khoản đã tồn tại! Mã tài khoản đã bi trùng ";
                    ViewBag.DSmavaitro = new SelectList(db.VaiTros.ToList(), "MaVaiTro", "TenVaiTro");
                    return View("formThemTaiKhoan");
                }

                // Thêm tài khoản vào cơ sở dữ liệu
                db.TaiKhoans.Add(taiKhoan);
                db.SaveChanges();

                TempData["SuccessMessage"] = "Tài khoản đã được thêm thành công!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi thêm nhân viên: " + ex.Message);
             
                ViewBag.DSmavaitro = new SelectList(db.VaiTros.ToList(), "MaVaiTro", "TenVaiTro");
                return View("formThemTaiKhoan");
            }
        }

        public IActionResult formSuaTaiKhoan(string id)
        {
            // Lấy danh sách vai trò
            ViewBag.DSmavaitro = new SelectList(db.VaiTros.ToList(), "MaVaiTro", "TenVaiTro");

            // Tìm tài khoản theo ID
            TaiKhoan tk = db.TaiKhoans.Find(id);
            if (tk == null)
            {
                TempData["ErrorMessage"] = $"Tài khoản không tồn tại! ID: {id}";
                return RedirectToAction("Index");
            }

            // Chuyển đổi sang ViewModel và trả về view
            return View(CTaiKhoan.chuyendoi(tk));
        }

        public IActionResult suataikhoan(CTaiKhoan tk)
{
    // Kiểm tra nếu model không hợp lệ
    if (!ModelState.IsValid)
    {
        // Load lại danh sách vai trò để hiển thị trên view
        ViewBag.DSmavaitro = new SelectList(db.VaiTros.ToList(), "MaVaiTro", "TenVaiTro");
        return View("formSuaTaiKhoan", tk); // Trả lại form sửa với dữ liệu người dùng đã nhập
    }

    try
    {
        // Chuyển đổi từ ViewModel sang Entity
        TaiKhoan x = CTaiKhoan.chuyendoi(tk);

        // Kiểm tra tài khoản tồn tại
        var tt = db.TaiKhoans.Find(x.MaTaiKhoan);
        if (tt == null)
        {
            TempData["ErrorMessage"] = $"Tài khoản không tồn tại! ID: {x.MaTaiKhoan}";
            return RedirectToAction("Index");
        }

        // Cập nhật thông tin
        tt.TenTaiKhoan = x.TenTaiKhoan;
        tt.MatKhau = x.MatKhau;
        tt.MaVaiTro = x.MaVaiTro;
        tt.TrangThai = x.TrangThai;

        db.TaiKhoans.Update(tt);
        db.SaveChanges();

        TempData["SuccessMessage"] = "Tài khoản đã được cập nhật thành công!";
    }
    catch (Exception ex)
    {
        TempData["ErrorMessage"] = $"Có lỗi xảy ra: {ex.Message}";
        ViewBag.DSmavaitro = new SelectList(db.VaiTros.ToList(), "MaVaiTro", "TenVaiTro");
        return View("formSuaTaiKhoan", tk);
    }

    return RedirectToAction("Index");
}

    }
}
