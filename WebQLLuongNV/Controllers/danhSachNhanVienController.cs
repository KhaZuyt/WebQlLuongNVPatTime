using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebQLLuongNV.Models;
using WebQLLuongNV.Models.ViewModel;

namespace WebQLLuongNV.Controllers
{
    public class danhSachNhanVienController : Controller
    {
        private QlnvpartTimeContext db = new QlnvpartTimeContext();

        [RoleAuthorize(1, 2)]
        public IActionResult Index(string searchMa, string searchTen)
        {
        
            var query = db.NhanViens.AsQueryable();

     
            if (!string.IsNullOrEmpty(searchMa))
            {
                query = query.Where(x => x.MaNhanVien.Contains(searchMa));
            }


            if (!string.IsNullOrEmpty(searchTen))
            {
                query = query.Where(x => x.TenNhanVien != null && x.TenNhanVien.Contains(searchTen));
            }



            List<CNhanVien> ds = query.Select(x => CNhanVien.chuyendoi(x)).ToList();

          
            foreach (var item in ds)
            {
                item.MaTaiKhoanNavigation = db.TaiKhoans.Find(item.MaTaiKhoan);
            }

    
            return View(ds);
        }


        // GET: NhanVien/formThemNhanVien
        public IActionResult formThemNhanVien()
        {
            // Lấy danh sách tài khoản và truyền vào ViewBag
            ViewBag.DSTaikhoan = new SelectList(db.TaiKhoans.ToList(), "MaTaiKhoan", "TenTaiKhoan");

            return View();
        }

        public IActionResult themNhanVien(CNhanVien x)
        {
        

            // Kiểm tra tính hợp lệ của dữ liệu
            if (ModelState.IsValid)
            {
                try
                {
                    // Chuyển từ ViewModel sang Entity và thêm vào CSDL
                    db.NhanViens.Add(CNhanVien.chuyendoi(x));
                    db.SaveChanges();

                    // Hiển thị thông báo thành công
                    TempData["SuccessMessage"] = "Nhân viên đã được thêm thành công!";
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // Hiển thị thông báo lỗi
                    ModelState.AddModelError("", "Lỗi khi thêm nhân viên: " + ex.Message);
                }
            }

            // Nếu có lỗi, trả về form và cung cấp danh sách tài khoản để chọn
            ViewBag.DSTaikhoan = new SelectList(db.TaiKhoans.ToList(), "MaTaiKhoan", "TenTaiKhoan");
            TempData["ErrorMessage"] = "Thông tin không hợp lệ hoặc mã nhân viên bị trùng !";
            return View("formThemNhanVien");
        }

        public IActionResult formSuaNhanVien(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                TempData["ErrorMessage"] = "ID nhân viên không hợp lệ!";
                return RedirectToAction("Index");
            }

            var nv = db.NhanViens.Find(id);
            if (nv == null)
            {
                TempData["ErrorMessage"] = $"Nhân viên không tồn tại! ID: {id}";
                return RedirectToAction("Index");
            }

            ViewBag.DSTaikhoan = new SelectList(db.TaiKhoans.ToList(), "MaTaiKhoan", "TenTaiKhoan");
            return View(CNhanVien.chuyendoi(nv));
        }

        [HttpPost]
        public IActionResult suanhanvien(CNhanVien model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.DSTaikhoan = new SelectList(db.TaiKhoans.ToList(), "MaTaiKhoan", "TenTaiKhoan");
                TempData["ErrorMessage"] = "Thông tin không hợp lệ!";
                return View("formSuaNhanVien", model);
            }

            try
            {
                var nv = CNhanVien.chuyendoi(model);
                db.NhanViens.Update(nv);
                db.SaveChanges();

                TempData["SuccessMessage"] = "Nhân viên đã được cập nhật thành công!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Lỗi khi sửa nhân viên: " + ex.Message);
                ViewBag.DSTaikhoan = new SelectList(db.TaiKhoans.ToList(), "MaTaiKhoan", "TenTaiKhoan");
                return View("formSuaNhanVien", model);
            }
        }




        [HttpPost]
      
        public IActionResult XoaNhanVien(string id)
        {
            var nhanVien = db.NhanViens.FirstOrDefault(nv => nv.MaNhanVien == id);
            if (nhanVien == null)
            {
                return NotFound(); // Nếu không tìm thấy nhân viên
            }

            try
            {
                // Xóa nhân viên
                db.NhanViens.Remove(nhanVien);
                db.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

                TempData["SuccessMessage"] = "Nhân viên đã được xóa thành công!";
                return RedirectToAction("Index"); // Quay lại trang danh sách nhân viên
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Đã xảy ra lỗi khi xóa: " + ex.Message;
                return RedirectToAction("Index");
            }
        }
        public IActionResult chitietnhanvien(string id)
        {
            // Truy vấn thông tin nhân viên, tài khoản và vai trò
            var nhanVien = db.NhanViens
                             .Where(nv => nv.MaNhanVien == id)
                             .Include(nv => nv.MaTaiKhoanNavigation) // Lấy thông tin tài khoản
                             .ThenInclude(tk => tk.MaVaiTroNavigation) // Lấy thông tin vai trò
                             .FirstOrDefault();

            if (nhanVien == null)
            {
                return NotFound();
            }

            // Trả về view với model NhanVien
            return PartialView("chitietnhanvien", nhanVien);
        }



    }
}
