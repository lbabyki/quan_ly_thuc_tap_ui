# Hướng dẫn tích hợp API

## 🔧 Cấu hình API Client

### 1. Thiết lập BaseUrl

Mở file `MyWinFormsApp.DataAccess/ApiClient.cs` và cấu hình:

```csharp
public static string BaseUrl { get; set; } = "http://localhost:5000";
```

Thay đổi URL theo môi trường:
- **Development**: `http://localhost:5000`
- **Staging**: `https://staging-api.lhu.edu.vn`
- **Production**: `https://api.lhu.edu.vn`

### 2. JWT Token Management

ApiClient tự động quản lý JWT Token:
- Token được lưu sau khi login thành công
- Tự động thêm `Authorization: Bearer {token}` vào mọi request
- Xóa token khi logout

```csharp
// Lưu token
ApiClient.JwtToken = "your_jwt_token_here";

// Kiểm tra đã login chưa
bool isLoggedIn = ApiClient.IsAuthenticated();

// Xóa token (logout)
ApiClient.ClearToken();
```

## 📡 API Endpoints

### Authentication API

#### Login
```
POST /v1/api/auth/login
Content-Type: application/json

Request Body:
{
  "email": "student@lhu.edu.vn",
  "password": "password123"
}

Response (Success):
{
  "success": true,
  "message": "Login successful",
  "data": {
    "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9...",
    "user": {
      "_id": "507f1f77bcf86cd799439011",
      "email": "student@lhu.edu.vn",
      "role": "student",
      "fullName": "Nguyễn Văn A",
      "userName": "nguyenvana",
      "phone": "0912345678"
    }
  }
}

Response (Error):
{
  "success": false,
  "message": "Invalid credentials",
  "error": "Email or password is incorrect"
}
```

## 🔨 Tạo Repository mới

### Ví dụ: StudentRepository

```csharp
using MyWinFormsApp.DataAccess.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace MyWinFormsApp.DataAccess.Repositories
{
    public class StudentRepository
    {
        /// <summary>
        /// Lấy thông tin sinh viên hiện tại
        /// </summary>
        public async Task<ApiResponse<StudentDto>> GetMyProfileAsync()
        {
            try
            {
                var client = ApiClient.CreateClient();
                var request = ApiClient.CreateRequest("/v1/api/students/me", Method.Get);
                
                var response = await client.ExecuteAsync(request);
                
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<ApiResponse<StudentDto>>(response.Content);
                }
                else
                {
                    return new ApiResponse<StudentDto>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}",
                        Error = response.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<StudentDto>
                {
                    Success = false,
                    Message = "An error occurred",
                    Error = ex.Message
                };
            }
        }
    }
}
```

## 🎯 Tạo Service mới

### Ví dụ: StudentService

```csharp
using MyWinFormsApp.Business.Models;
using MyWinFormsApp.DataAccess.Repositories;
using System.Threading.Tasks;

namespace MyWinFormsApp.Business.Services
{
    public class StudentService
    {
        private readonly StudentRepository _repository;

        public StudentService()
        {
            _repository = new StudentRepository();
        }

        public async Task<(bool Success, string Message, Student? Student)> GetMyProfileAsync()
        {
            var response = await _repository.GetMyProfileAsync();
            
            if (response.Success && response.Data != null)
            {
                // Map DTO to Business Model
                var student = new Student
                {
                    Id = response.Data.Id,
                    Email = response.Data.Email,
                    FullName = response.Data.FullName,
                    // ... map other fields
                };
                
                return (true, "Success", student);
            }
            else
            {
                return (false, response.Message ?? "Failed", null);
            }
        }
    }
}
```

## 🔍 Error Handling

### Xử lý lỗi HTTP

```csharp
if (response.IsSuccessful)
{
    // Success
}
else
{
    switch (response.StatusCode)
    {
        case System.Net.HttpStatusCode.Unauthorized:
            // Token hết hạn hoặc không hợp lệ
            MessageBox.Show("Phiên đăng nhập đã hết hạn. Vui lòng đăng nhập lại.");
            break;
        case System.Net.HttpStatusCode.NotFound:
            MessageBox.Show("Không tìm thấy dữ liệu.");
            break;
        case System.Net.HttpStatusCode.BadRequest:
            MessageBox.Show("Dữ liệu không hợp lệ.");
            break;
        default:
            MessageBox.Show($"Lỗi: {response.StatusCode}");
            break;
    }
}
```

## 📝 Best Practices

1. **Luôn sử dụng async/await** cho API calls
2. **Xử lý exceptions** trong try-catch
3. **Validate input** trước khi gọi API
4. **Hiển thị loading indicator** khi đang gọi API
5. **Disable buttons** để tránh multiple clicks
6. **Log errors** để debug
7. **Timeout**: Mặc định 30 giây, có thể điều chỉnh trong ApiClient

## 🧪 Testing API

### Test với Postman/Thunder Client

1. Import API endpoints
2. Test login để lấy token
3. Copy token vào Authorization header cho các request khác
4. Test các endpoints khác

### Test trong code

```csharp
// Enable API mode
private bool _useMockData = false;

// Cấu hình BaseUrl
ApiClient.BaseUrl = "http://localhost:5000";
```

## 🔐 Security

1. **HTTPS**: Luôn sử dụng HTTPS trong production
2. **Token Storage**: Hiện tại token lưu trong memory, có thể lưu vào SecureStorage
3. **Password**: Không bao giờ log password
4. **Sensitive Data**: Không log token hoặc dữ liệu nhạy cảm

