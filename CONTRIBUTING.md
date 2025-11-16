# 🤝 Hướng dẫn đóng góp

Cảm ơn bạn đã quan tâm đến việc đóng góp cho dự án Hệ thống Quản lý Thực tập!

## 📋 Mục lục

1. [Code of Conduct](#code-of-conduct)
2. [Bắt đầu](#bắt-đầu)
3. [Quy trình đóng góp](#quy-trình-đóng-góp)
4. [Coding Standards](#coding-standards)
5. [Commit Messages](#commit-messages)
6. [Pull Request Process](#pull-request-process)

## 📜 Code of Conduct

- Tôn trọng mọi người
- Sử dụng ngôn ngữ lịch sự
- Chấp nhận phản hồi mang tính xây dựng
- Tập trung vào điều tốt nhất cho cộng đồng

## 🚀 Bắt đầu

### 1. Fork repository

```bash
# Clone repository của bạn
git clone https://github.com/your-username/quan_ly_thuc_tap_ui.git
cd quan_ly_thuc_tap_ui
```

### 2. Cài đặt dependencies

```bash
dotnet restore
dotnet build
```

### 3. Tạo branch mới

```bash
git checkout -b feature/ten-tinh-nang
# hoặc
git checkout -b fix/ten-loi
```

## 🔄 Quy trình đóng góp

### 1. Chọn issue hoặc tạo issue mới

- Kiểm tra [Issues](../../issues) để tìm task
- Hoặc tạo issue mới để đề xuất tính năng/báo lỗi

### 2. Implement changes

- Viết code theo [Coding Standards](#coding-standards)
- Thêm comments rõ ràng
- Test kỹ lưỡng

### 3. Test

```bash
# Build project
dotnet build

# Chạy ứng dụng
dotnet run --project MyWinFormsApp

# Test với Mock Data
# Test với API (nếu có)
```

### 4. Commit changes

```bash
git add .
git commit -m "feat: thêm chức năng xyz"
```

### 5. Push to GitHub

```bash
git push origin feature/ten-tinh-nang
```

### 6. Tạo Pull Request

- Mở Pull Request từ branch của bạn
- Mô tả rõ ràng những gì đã thay đổi
- Link đến issue liên quan

## 💻 Coding Standards

### C# Coding Conventions

#### Naming Conventions

```csharp
// Classes, Methods, Properties: PascalCase
public class UserService { }
public void LoginAsync() { }
public string FullName { get; set; }

// Private fields: _camelCase
private readonly UserRepository _userRepository;

// Local variables, parameters: camelCase
string email = "test@example.com";
public void Login(string email, string password) { }

// Constants: UPPER_CASE
private const string API_BASE_URL = "http://localhost:5000";
```

#### Code Organization

```csharp
// 1. Using statements
using System;
using System.Threading.Tasks;

// 2. Namespace
namespace MyWinFormsApp.Business.Services
{
    // 3. XML Comments
    /// <summary>
    /// Service xử lý logic nghiệp vụ cho User
    /// </summary>
    public class UserService
    {
        // 4. Private fields
        private readonly UserRepository _repository;

        // 5. Constructor
        public UserService()
        {
            _repository = new UserRepository();
        }

        // 6. Public methods
        public async Task<User> GetUserAsync(string id)
        {
            // Implementation
        }

        // 7. Private methods
        private void ValidateInput(string input)
        {
            // Implementation
        }
    }
}
```

#### Comments

```csharp
// XML Comments cho public members
/// <summary>
/// Đăng nhập vào hệ thống
/// </summary>
/// <param name="email">Email đăng nhập</param>
/// <param name="password">Mật khẩu</param>
/// <returns>Tuple chứa kết quả login</returns>
public async Task<(bool, string, User?)> LoginAsync(string email, string password)
{
    // Inline comments cho logic phức tạp
    // Validate email format
    if (!email.Contains("@"))
    {
        return (false, "Email không hợp lệ", null);
    }

    // TODO: Thêm validation phức tạp hơn
    // FIXME: Xử lý case email null
}
```

### File Organization

```
MyWinFormsApp.Business/
├── Models/
│   └── User.cs              # Một class một file
├── Services/
│   └── UserService.cs       # Một service một file
└── MyWinFormsApp.Business.csproj
```

### Error Handling

```csharp
public async Task<ApiResponse<T>> CallApiAsync()
{
    try
    {
        // API call
        var response = await client.ExecuteAsync(request);
        
        if (response.IsSuccessful)
        {
            return ParseResponse(response);
        }
        else
        {
            return new ApiResponse<T>
            {
                Success = false,
                Message = $"Error: {response.StatusCode}",
                Error = response.ErrorMessage
            };
        }
    }
    catch (Exception ex)
    {
        // Log error
        Console.WriteLine($"Error: {ex.Message}");
        
        return new ApiResponse<T>
        {
            Success = false,
            Message = "An error occurred",
            Error = ex.Message
        };
    }
}
```

## 📝 Commit Messages

### Format

```
<type>(<scope>): <subject>

<body>

<footer>
```

### Types

- **feat**: Tính năng mới
- **fix**: Sửa lỗi
- **docs**: Thay đổi documentation
- **style**: Format code (không ảnh hưởng logic)
- **refactor**: Refactor code
- **test**: Thêm tests
- **chore**: Cập nhật build, dependencies

### Examples

```bash
# Tính năng mới
git commit -m "feat(auth): thêm chức năng đăng nhập"

# Sửa lỗi
git commit -m "fix(api): sửa lỗi timeout khi gọi API"

# Documentation
git commit -m "docs(readme): cập nhật hướng dẫn cài đặt"

# Refactor
git commit -m "refactor(service): tối ưu UserService"
```

## 🔍 Pull Request Process

### 1. Checklist trước khi tạo PR

- [ ] Code build thành công
- [ ] Đã test kỹ lưỡng
- [ ] Code tuân theo Coding Standards
- [ ] Đã thêm/cập nhật comments
- [ ] Đã cập nhật documentation (nếu cần)
- [ ] Commit messages rõ ràng

### 2. PR Template

```markdown
## Mô tả

Mô tả ngắn gọn về thay đổi

## Loại thay đổi

- [ ] Bug fix
- [ ] New feature
- [ ] Breaking change
- [ ] Documentation update

## Checklist

- [ ] Code build thành công
- [ ] Đã test
- [ ] Tuân theo coding standards
- [ ] Đã cập nhật docs

## Screenshots (nếu có)

Thêm screenshots nếu có thay đổi UI
```

### 3. Review Process

- Maintainer sẽ review code
- Có thể yêu cầu thay đổi
- Sau khi approve, PR sẽ được merge

## 🎯 Các loại đóng góp

### 1. Báo lỗi (Bug Reports)

Tạo issue với template:
```markdown
**Mô tả lỗi**
Mô tả rõ ràng lỗi là gì

**Các bước tái hiện**
1. Vào '...'
2. Click vào '...'
3. Thấy lỗi

**Kết quả mong đợi**
Mô tả kết quả mong đợi

**Screenshots**
Thêm screenshots nếu có
```

### 2. Đề xuất tính năng

Tạo issue với template:
```markdown
**Mô tả tính năng**
Mô tả tính năng muốn thêm

**Lý do**
Tại sao cần tính năng này

**Giải pháp đề xuất**
Cách implement tính năng
```

### 3. Cải thiện Documentation

- Sửa lỗi chính tả
- Thêm ví dụ
- Cải thiện giải thích
- Thêm hướng dẫn mới

## 📚 Tài liệu tham khảo

- [README.md](README.md)
- [PROJECT_STRUCTURE.md](PROJECT_STRUCTURE.md)
- [EXTENSION_GUIDE.md](EXTENSION_GUIDE.md)

---

**Cảm ơn bạn đã đóng góp! 🎉**

