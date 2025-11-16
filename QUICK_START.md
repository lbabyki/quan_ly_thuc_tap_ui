# 🚀 Quick Start Guide

Hướng dẫn nhanh để chạy demo ứng dụng Quản lý Thực tập.

## ✅ Yêu cầu hệ thống

- **.NET 8.0 SDK** hoặc cao hơn
- **Visual Studio 2022** hoặc **VS Code** (khuyến nghị)
- **Windows OS** (WinForms chỉ chạy trên Windows)

## 📦 Cài đặt

### Bước 1: Clone hoặc mở project

```bash
cd d:\Class_Collection\Nam_3\K5\Winform\quan_ly_thuc_tap_ui
```

### Bước 2: Restore dependencies

```bash
dotnet restore
```

### Bước 3: Build project

```bash
dotnet build
```

## ▶️ Chạy ứng dụng

### Cách 1: Sử dụng dotnet CLI

```bash
dotnet run --project MyWinFormsApp
```

### Cách 2: Sử dụng Visual Studio

1. Mở file `quan_ly_thuc_tap_ui.sln`
2. Set `MyWinFormsApp` làm Startup Project
3. Nhấn `F5` hoặc click nút "Start"

### Cách 3: Chạy file exe

```bash
.\MyWinFormsApp\bin\Debug\net8.0-windows\MyWinFormsApp.exe
```

## 🔐 Demo Login

Ứng dụng hiện đang sử dụng **Mock Data** để demo.

### Tài khoản test:

#### 👨‍💼 Admin
```
Email: admin@lhu.edu.vn
Password: admin123
```

#### 👨‍🎓 Student (Sinh viên)
```
Email: student@lhu.edu.vn
Password: student123
```

#### 👨‍🏫 Lecturer (Giảng viên)
```
Email: lecturer@lhu.edu.vn
Password: lecturer123
```

#### 🏢 Company (Công ty)
```
Email: company@example.com
Password: company123
```

## 🎨 Giao diện

### LoginForm
- **Màu nền**: Xanh dương Đại học Lạc Hồng (#0054A6)
- **Button**: Cam Đại học Lạc Hồng (#F36F21)
- **Panel**: Trắng với shadow
- **Font**: Segoe UI

### Tính năng
- ✅ Validation email và password
- ✅ Hiển thị thông báo lỗi
- ✅ Hỗ trợ Enter key để login
- ✅ Disable button khi đang xử lý
- ✅ Mock Data để test nhanh

## 🔄 Chuyển đổi Mock Data / API

### Sử dụng Mock Data (mặc định - đã bật)

File: `MyWinFormsApp/Forms/LoginForm.cs`
```csharp
private bool _useMockData = true;
```

### Sử dụng API thật

File: `MyWinFormsApp/Forms/LoginForm.cs`
```csharp
private bool _useMockData = false;
```

File: `MyWinFormsApp.DataAccess/ApiClient.cs`
```csharp
public static string BaseUrl { get; set; } = "http://localhost:5000";
```

## 🧪 Test các tính năng

### Test 1: Login thành công
1. Chạy ứng dụng
2. Nhập: `student@lhu.edu.vn` / `student123`
3. Click "Đăng nhập"
4. ✅ Hiển thị MessageBox thành công

### Test 2: Login thất bại
1. Nhập: `wrong@email.com` / `wrongpass`
2. Click "Đăng nhập"
3. ❌ Hiển thị lỗi "Email hoặc mật khẩu không đúng"

### Test 3: Validation
1. Để trống email
2. Click "Đăng nhập"
3. ❌ Hiển thị lỗi "Email không được để trống"

### Test 4: Enter key
1. Nhập email và password
2. Nhấn Enter trong textbox password
3. ✅ Tự động submit form

## 📁 Cấu trúc Project

```
quan_ly_thuc_tap_ui/
├── MyWinFormsApp/              # UI Layer
│   ├── Forms/
│   │   ├── LoginForm.cs
│   │   └── LoginForm.Designer.cs
│   └── Program.cs
│
├── MyWinFormsApp.Business/     # Business Layer
│   ├── Models/
│   │   ├── User.cs
│   │   ├── Student.cs
│   │   ├── Company.cs
│   │   ├── Lecturer.cs
│   │   └── Internship.cs
│   └── Services/
│       └── UserService.cs
│
├── MyWinFormsApp.DataAccess/   # Data Access Layer
│   ├── ApiClient.cs
│   ├── Models/
│   │   ├── ApiResponse.cs
│   │   ├── LoginRequest.cs
│   │   └── LoginResponse.cs
│   └── Repositories/
│       └── UserRepository.cs
│
└── MyWinFormsApp.MockData/     # Mock Data
    └── UserMockData.cs
```

## 🐛 Troubleshooting

### Lỗi: "The type or namespace name could not be found"
```bash
dotnet restore
dotnet build
```

### Lỗi: "Unable to find package RestSharp"
```bash
dotnet add MyWinFormsApp.DataAccess package RestSharp
dotnet add MyWinFormsApp.DataAccess package Newtonsoft.Json
```

### Lỗi: "Form không hiển thị"
- Kiểm tra `Program.cs` đã set `Application.Run(new LoginForm())`
- Kiểm tra project type là WinForms (.NET 8.0-windows)

## 📚 Tài liệu thêm

- [README.md](README.md) - Tổng quan dự án
- [MOCK_DATA_GUIDE.md](MOCK_DATA_GUIDE.md) - Hướng dẫn Mock Data
- [API_INTEGRATION_GUIDE.md](API_INTEGRATION_GUIDE.md) - Hướng dẫn tích hợp API

## 💡 Tips

1. **Debug**: Sử dụng breakpoint trong Visual Studio để debug
2. **Log**: Thêm `Console.WriteLine()` để log thông tin
3. **Mock Data**: Test với Mock Data trước khi kết nối API
4. **Build**: Luôn build lại sau khi thay đổi code

## 🎯 Next Steps

Sau khi chạy demo thành công:
1. Tạo các Form cho từng role (Student, Lecturer, Company, Admin)
2. Implement các chức năng quản lý thực tập
3. Kết nối với API backend thật
4. Thêm validation và error handling
5. Viết unit tests

---

**Chúc bạn code vui vẻ! 🎉**

