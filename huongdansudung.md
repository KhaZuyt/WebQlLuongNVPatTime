# WebQlLuongNVPatTime
Web quản lý lương nhân viên Part-Time 


## Hướng dẫn cài đặt 

- **B1**:Tải source về
- **B2**:Thay đổi chuỗi kết nối trong project ví dụ trong QlnvpartTimeContext.cs và appsetting.json :
        - Server=__Tên Server_-;Database=_Tên DataBase_-;Trusted_Connection=True;TrustServerCertificate=True;
                  *Lưu ý tên database phải giống QLNVPartTime hoặc đổi tên database trên chuỗi kết nối*
- **B3**:Import dữ liệu vào có tên file là data_WebQLLuongNV.spl

  *Nếu B2,B3 làm không được có thể dùng lệnh Package Manager Console :*
             -   *Scaffold-DbContext "Server=__tên máy chủ__;Database=__tên database__;Trusted_Connection=True;Encrypt=False;TrustServerCertificate=True;"                                          -       Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Force*
---

## Hướng dẫn sử dụng 

### Đối với người dùng thường

- **B1**: Truy cập vào trang web: [http://www.qlnhanvienpt.somee.com](http://www.qlnhanvienpt.somee.com)
- **B2**: Đăng nhập vào trang bằng tài khoản:
  - Tài khoản: `employee1`
  - Mật khẩu: `emp123`
- **B3**: Đăng ký bấm vào đăng ký ở trang đăng ký 
- **B4**: Đăng ký theo buổi làm tương ứng sau khi đăng ký bấm nút "xác nhận đăng ký "
- **B5**: Kiểm tra đăng ký ở Danh sách đăng ký, click ở cột hoàn thành để lưu và đẩy lương qua trang lương cá nhân 
- **B6**: Kiểm tra lương của mình trong trang lương cá nhân 

---

### Đối với Admin 

- **B1**: Đăng nhập vào trang bằng tài khoản:
  - Tài khoản: `phuckha`
  - Mật khẩu: `123`
- **B2**: Nhấn tạo lịch ở trang Lịch 
- **B3**: Sau khi tạo, nhân thêm buổi lịch làm 
- **B4**: Nhấn chi tiết để thêm ca phục vụ 
- **B5**: Xem danh sách đăng ký và lương ở trang lương 
- **B6**: Bấm nút "Hiển thị lương mỗi nhân viên" để hiển thị lương nhân viên đã làm trong lịch làm đó 

*p/s xem tài khoản, thông tin nhân viên nếu cần*
