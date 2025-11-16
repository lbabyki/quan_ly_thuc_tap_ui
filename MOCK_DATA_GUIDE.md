# Hướng dẫn sử dụng Mock Data

## 📋 Tổng quan

Mock Data được sử dụng để test ứng dụng mà không cần kết nối đến API backend thật. Điều này giúp:
- Phát triển và test UI nhanh chóng
- Không phụ thuộc vào backend API
- Dễ dàng test các trường hợp khác nhau

## 🔐 Tài khoản Mock Data

### 1. Admin (Quản trị viên)
```
Email: admin@lhu.edu.vn
Password: admin123
Role: admin
Full Name: Quản Trị Viên
```

### 2. Student (Sinh viên)
```
Email: student@lhu.edu.vn
Password: student123
Role: student
Full Name: Nguyễn Văn A
```

### 3. Lecturer (Giảng viên)
```
Email: lecturer@lhu.edu.vn
Password: lecturer123
Role: lecturer
Full Name: TS. Trần Thị B
```

### 4. Company (Công ty)
```
Email: company@example.com
Password: company123
Role: company
Full Name: Công ty ABC
```

## 🔄 Chuyển đổi giữa Mock Data và API thật

### Sử dụng Mock Data (mặc định)

Trong file `MyWinFormsApp/Forms/LoginForm.cs`:
```csharp
private bool _useMockData = true; // Sử dụng Mock Data
```

### Sử dụng API thật

Trong file `MyWinFormsApp/Forms/LoginForm.cs`:
```csharp
private bool _useMockData = false; // Gọi API thật
```

Và cấu hình BaseUrl trong `MyWinFormsApp.DataAccess/ApiClient.cs`:
```csharp
public static string BaseUrl { get; set; } = "http://localhost:5000"; // Thay đổi theo API server
```

## 📝 Thêm Mock Data mới

### Thêm User mới

Mở file `MyWinFormsApp.MockData/UserMockData.cs` và thêm vào list:

```csharp
new User
{
    UserId = "newuser001",
    Email = "newuser@lhu.edu.vn",
    Password = "password123",
    Role = "student",
    FullName = "Tên người dùng mới",
    UserName = "newuser",
    Phone = "0987654321",
    Token = "mock_token_newuser_001"
}
```

### Tạo Mock Data cho các Model khác

Tương tự như `UserMockData.cs`, bạn có thể tạo:
- `StudentMockData.cs` - Dữ liệu sinh viên
- `CompanyMockData.cs` - Dữ liệu công ty
- `LecturerMockData.cs` - Dữ liệu giảng viên
- `InternshipMockData.cs` - Dữ liệu vị trí thực tập

## 🧪 Test với Mock Data

### Test Login thành công
1. Chạy ứng dụng
2. Nhập email: `student@lhu.edu.vn`
3. Nhập password: `student123`
4. Click "Đăng nhập"
5. Kết quả: Hiển thị thông báo đăng nhập thành công

### Test Login thất bại
1. Chạy ứng dụng
2. Nhập email: `wrong@email.com`
3. Nhập password: `wrongpassword`
4. Click "Đăng nhập"
5. Kết quả: Hiển thị lỗi "Email hoặc mật khẩu không đúng"

### Test Validation
1. Để trống email hoặc password
2. Click "Đăng nhập"
3. Kết quả: Hiển thị lỗi validation

## 💡 Tips

1. **Mock Data vs API**: Luôn test với Mock Data trước, sau đó mới chuyển sang API thật
2. **Thêm dữ liệu**: Thêm nhiều user với các role khác nhau để test đầy đủ
3. **Password**: Trong Mock Data, password được lưu plain text để dễ test. Trong production, KHÔNG BAO GIỜ làm như vậy!
4. **Token**: Mock token chỉ là string giả lập, không có giá trị thật

## 🔍 Debug

Nếu gặp lỗi khi sử dụng Mock Data:

1. Kiểm tra `_useMockData = true` trong LoginForm.cs
2. Kiểm tra email/password có khớp với dữ liệu trong UserMockData.cs
3. Kiểm tra Console output để xem lỗi chi tiết

## 📚 Tài liệu tham khảo

- [UserMockData.cs](MyWinFormsApp.MockData/UserMockData.cs) - Implementation của Mock Data
- [LoginForm.cs](MyWinFormsApp/Forms/LoginForm.cs) - Cách sử dụng Mock Data trong UI
- [README.md](README.md) - Tổng quan dự án

