# Changelog

Tất cả các thay đổi quan trọng của dự án sẽ được ghi lại trong file này.

## [1.0.0] - 2025-11-16

### ✨ Added - Tính năng mới

#### Cấu trúc dự án
- ✅ Tạo kiến trúc 3-layer (UI, Business, DataAccess)
- ✅ Thêm MockData layer cho testing
- ✅ Cấu hình Solution với 4 projects

#### Dependencies
- ✅ RestSharp 112.1.0 - REST API client
- ✅ Newtonsoft.Json 13.0.4 - JSON serialization
- ✅ .NET 8.0 - Framework

#### Models (Business Layer)
- ✅ User.cs - Model cho User
- ✅ Student.cs - Model cho Sinh viên
- ✅ Company.cs - Model cho Công ty
- ✅ Lecturer.cs - Model cho Giảng viên
- ✅ Internship.cs - Model cho Vị trí thực tập

#### Data Access Layer
- ✅ ApiClient.cs - Quản lý API connection và JWT token
  - Static BaseUrl dễ dàng cấu hình
  - Tự động lưu và quản lý JWT token
  - Tự động thêm Authorization header
  - Timeout 30 giây
- ✅ UserRepository.cs - API calls cho User
  - LoginAsync() - Đăng nhập
  - Logout() - Đăng xuất
- ✅ ApiResponse.cs - Generic DTO cho API response
- ✅ LoginRequest.cs - DTO cho login request
- ✅ LoginResponse.cs - DTO cho login response

#### Business Logic Layer
- ✅ UserService.cs - Business logic cho User
  - LoginAsync() với validation
  - Logout()
  - Email validation
  - Password validation

#### Mock Data
- ✅ UserMockData.cs - Dữ liệu giả lập
  - 4 user mẫu (admin, student, lecturer, company)
  - MockLogin() - Simulate login
  - FindUser() - Tìm user

#### UI Layer
- ✅ LoginForm.cs - Form đăng nhập
  - Màu sắc Đại học Lạc Hồng (#0054A6, #F36F21)
  - TextBox Email và Password
  - Button Login
  - Validation input
  - MessageBox hiển thị kết quả
  - Hỗ trợ Enter key
  - Disable button khi processing
  - Chuyển đổi Mock Data / API
- ✅ Program.cs - Entry point khởi chạy LoginForm

#### Documentation
- ✅ README.md - Tổng quan dự án
- ✅ INDEX.md - Mục lục tài liệu
- ✅ QUICK_START.md - Hướng dẫn chạy nhanh
- ✅ MOCK_DATA_GUIDE.md - Hướng dẫn Mock Data
- ✅ API_INTEGRATION_GUIDE.md - Hướng dẫn tích hợp API
- ✅ PROJECT_STRUCTURE.md - Cấu trúc dự án chi tiết
- ✅ EXTENSION_GUIDE.md - Hướng dẫn mở rộng
- ✅ IMPLEMENTATION_SUMMARY.md - Tổng kết implementation
- ✅ CHANGELOG.md - Lịch sử thay đổi
- ✅ LICENSE - MIT License
- ✅ .gitignore - Git ignore file

### 🔧 Changed - Thay đổi

- ✅ Đổi MaxTimeout thành Timeout trong ApiClient (fix warning)
- ✅ Cập nhật Program.cs để khởi chạy LoginForm thay vì Form1

### 🗑️ Removed - Xóa bỏ

- ✅ Xóa Class1.cs mặc định trong các project
- ✅ Xóa Form1 references (giữ file để tham khảo)

### 🐛 Fixed - Sửa lỗi

- ✅ Sửa warning RestSharp MaxTimeout obsolete

### 🔒 Security - Bảo mật

- ✅ JWT Token được quản lý trong ApiClient
- ✅ Password không được log
- ✅ HTTPS ready (cần cấu hình BaseUrl)

### 📊 Build Status

- ✅ Debug Build: Success (0 errors, 0 warnings)
- ✅ Release Build: Success (0 errors, 0 warnings)

## [Unreleased] - Kế hoạch tương lai

### 🎯 Planned - Dự định

#### Forms
- ⏳ StudentMainForm - Form chính cho sinh viên
- ⏳ LecturerMainForm - Form chính cho giảng viên
- ⏳ CompanyMainForm - Form chính cho công ty
- ⏳ AdminMainForm - Form chính cho admin

#### Features
- ⏳ Student: Xem profile, upload CV, đăng ký thực tập
- ⏳ Lecturer: Quản lý sinh viên, review báo cáo
- ⏳ Company: Đăng vị trí thực tập, đánh giá sinh viên
- ⏳ Admin: Dashboard, quản lý users, cấu hình hệ thống

#### Repositories
- ⏳ StudentRepository
- ⏳ LecturerRepository
- ⏳ CompanyRepository
- ⏳ InternshipRepository
- ⏳ ProgressRepository

#### Services
- ⏳ StudentService
- ⏳ LecturerService
- ⏳ CompanyService
- ⏳ InternshipService
- ⏳ ProgressService

#### Testing
- ⏳ Unit Tests cho Services
- ⏳ Integration Tests cho Repositories
- ⏳ UI Tests

#### Improvements
- ⏳ Refresh Token implementation
- ⏳ Logging system
- ⏳ Configuration management
- ⏳ Error tracking
- ⏳ Performance optimization

---

## Format

Changelog này tuân theo [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
và dự án sử dụng [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

### Các loại thay đổi

- **Added** - Tính năng mới
- **Changed** - Thay đổi trong tính năng hiện có
- **Deprecated** - Tính năng sắp bị loại bỏ
- **Removed** - Tính năng đã bị xóa
- **Fixed** - Sửa lỗi
- **Security** - Cập nhật bảo mật

