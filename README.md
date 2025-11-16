# Hệ thống Quản lý Thực tập - Đại học Lạc Hồng

Dự án WinForms C# theo mô hình 3-layer (Presentation, Business Logic, Data Access) để quản lý thực tập sinh viên.

## 🏗️ Cấu trúc dự án

```
MyWinFormsApp/
│
├── MyWinFormsApp/                        # UI Layer (Presentation)
│   ├── Forms/
│   │   ├── LoginForm.cs                  # Form đăng nhập
│   │   └── LoginForm.Designer.cs
│   └── Program.cs                        # Entry point
│
├── MyWinFormsApp.Business/               # Business Logic Layer
│   ├── Services/
│   │   └── UserService.cs                # Business logic cho User
│   └── Models/
│       ├── User.cs
│       ├── Student.cs
│       ├── Company.cs
│       ├── Lecturer.cs
│       └── Internship.cs
│
├── MyWinFormsApp.DataAccess/             # Data Access Layer
│   ├── ApiClient.cs                      # Quản lý API connection, JWT token
│   ├── Repositories/
│   │   └── UserRepository.cs             # Gọi API cho User
│   └── Models/
│       ├── ApiResponse.cs                # DTO cho API response
│       ├── LoginRequest.cs
│       └── LoginResponse.cs
│
└── MyWinFormsApp.MockData/               # Mock Data cho testing
    └── UserMockData.cs                   # Dữ liệu giả lập User
```

## 🎨 Màu sắc Đại học Lạc Hồng

- **Xanh dương**: #0054A6
- **Cam**: #F36F21

## 🚀 Cách chạy dự án

### 1. Build dự án

```bash
dotnet build
```

### 2. Chạy ứng dụng

```bash
dotnet run --project MyWinFormsApp
```

## 🔐 Thông tin đăng nhập (Mock Data)

Hiện tại ứng dụng đang sử dụng Mock Data để test. Bạn có thể đăng nhập bằng các tài khoản sau:

### Admin

- **Email**: admin@lhu.edu.vn
- **Password**: admin123

### Student (Sinh viên)

- **Email**: student@lhu.edu.vn
- **Password**: student123

### Lecturer (Giảng viên)

- **Email**: lecturer@lhu.edu.vn
- **Password**: lecturer123

### Company (Công ty)

- **Email**: company@example.com
- **Password**: company123

## ⚙️ Cấu hình API

Để chuyển từ Mock Data sang gọi API thật:

1. Mở file `MyWinFormsApp/Forms/LoginForm.cs`
2. Tìm dòng: `private bool _useMockData = true;`
3. Đổi thành: `private bool _useMockData = false;`
4. Cấu hình BaseUrl trong `MyWinFormsApp.DataAccess/ApiClient.cs`:
   ```csharp
   public static string BaseUrl { get; set; } = "http://localhost:5000";
   ```

## 📡 API Endpoints

### Authentication

- **POST** `/v1/api/auth/login` - Đăng nhập

### Student

- **GET** `/v1/api/students/me` - Lấy thông tin sinh viên
- **PATCH** `/v1/api/students/me` - Cập nhật thông tin

### Lecturer

- **GET** `/v1/api/lecturer/students` - Lấy danh sách sinh viên được phân công

### Company

- **GET** `/v1/api/company/students` - Lấy danh sách sinh viên thực tập

### Admin

- **GET** `/v1/api/admin/dashboard` - Dashboard thống kê

## 🔧 Dependencies

- **.NET 8.0**
- **RestSharp** (112.1.0) - Gọi REST API
- **Newtonsoft.Json** (13.0.4) - Parse JSON

## 📝 Ghi chú

- JWT Token được tự động lưu trong `ApiClient` sau khi đăng nhập thành công
- Mọi request sau đó sẽ tự động thêm `Authorization: Bearer {token}` header
- Mock Data được sử dụng để test mà không cần backend API

## 🎯 Các bước tiếp theo

1. ✅ Tạo cấu trúc 3-layer
2. ✅ Implement LoginForm với Mock Data
3. ✅ Tích hợp RestSharp để gọi API
4. ⏳ Tạo các Form chính cho từng role (Student, Lecturer, Company, Admin)
5. ⏳ Implement các chức năng quản lý thực tập
6. ⏳ Viết unit tests

## 📚 Tài liệu đầy đủ

1. **[README.md](README.md)** - Tổng quan dự án (file này)
2. **[QUICK_START.md](QUICK_START.md)** - Hướng dẫn chạy nhanh
3. **[MOCK_DATA_GUIDE.md](MOCK_DATA_GUIDE.md)** - Hướng dẫn sử dụng Mock Data
4. **[API_INTEGRATION_GUIDE.md](API_INTEGRATION_GUIDE.md)** - Hướng dẫn tích hợp API
5. **[PROJECT_STRUCTURE.md](PROJECT_STRUCTURE.md)** - Cấu trúc dự án chi tiết
6. **[EXTENSION_GUIDE.md](EXTENSION_GUIDE.md)** - Hướng dẫn mở rộng dự án
7. **[IMPLEMENTATION_SUMMARY.md](IMPLEMENTATION_SUMMARY.md)** - Tổng kết implementation

## 🎓 Kiến thức áp dụng

- ✅ **3-Layer Architecture** - Tách biệt UI, Business Logic, Data Access
- ✅ **Repository Pattern** - Quản lý data access
- ✅ **Service Pattern** - Tập trung business logic
- ✅ **DTO Pattern** - Transfer data giữa layers
- ✅ **REST API Integration** - Gọi API với RestSharp
- ✅ **JWT Authentication** - Quản lý token
- ✅ **Async/Await** - Xử lý bất đồng bộ
- ✅ **Error Handling** - Xử lý lỗi toàn diện
- ✅ **Mock Data** - Testing không cần backend

## 👨‍💻 Tác giả

Dự án được phát triển cho Đại học Lạc Hồng

---

**Chúc bạn code vui vẻ! 🎉**
