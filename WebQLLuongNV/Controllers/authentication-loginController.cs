using Microsoft.AspNetCore.Mvc;

using WebQLLuongNV.Models;

namespace WebQLLuongNV.Controllers
{
    public class authentication_loginController : Controller
    {
        private readonly QlnvpartTimeContext _context;
        public authentication_loginController(QlnvpartTimeContext context)
        {
            _context = context; 
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult login(string TenTaiKhoan , string MatKhau)
        {
            var user = _context.TaiKhoans
                .FirstOrDefault(tk => tk.TenTaiKhoan == TenTaiKhoan && tk.MatKhau == MatKhau && tk.TrangThai == "Active");
            if (user != null) {
                var nhanVien = _context.NhanViens
          .FirstOrDefault(nv => nv.MaTaiKhoan == user.MaTaiKhoan);
                HttpContext.Session.SetString("TenTaiKhoan", user.TenTaiKhoan);
                HttpContext.Session.SetInt32("VaiTro", user.MaVaiTro ?? 0);


                if (nhanVien != null)
                {
                    HttpContext.Session.SetString("MaNhanVien", nhanVien.MaNhanVien);
                    HttpContext.Session.SetString("TenNhanVien", nhanVien.TenNhanVien);
                }

                return RedirectToAction("Index", "Home");

            }
            ViewBag.ErrorMessage = "Tên tài khoản hoặc mật khẩu không đúng hoặc tài khoản đã bị khóa.";
            return View("Index");
         
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "authentication_login");
        }
    }
}
