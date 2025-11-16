# 🔧 Hướng dẫn mở rộng dự án

Hướng dẫn chi tiết cách thêm chức năng mới vào dự án.

## 📝 Quy trình thêm chức năng mới

### Bước 1: Tạo Model (Business Layer)

Ví dụ: Thêm model `ProgressReport`

```csharp
// File: MyWinFormsApp.Business/Models/ProgressReport.cs
namespace MyWinFormsApp.Business.Models
{
    public class ProgressReport
    {
        public string? Id { get; set; }
        public string Student { get; set; } = string.Empty;
        public string Internship { get; set; } = string.Empty;
        public int Week { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string ReportType { get; set; } = "weekly";
        public string Status { get; set; } = "submitted";
        public DateTime? CreatedAt { get; set; }
    }
}
```

### Bước 2: Tạo DTO Models (Data Access Layer)

```csharp
// File: MyWinFormsApp.DataAccess/Models/ProgressReportDto.cs
using Newtonsoft.Json;

namespace MyWinFormsApp.DataAccess.Models
{
    public class ProgressReportDto
    {
        [JsonProperty("_id")]
        public string? Id { get; set; }
        
        [JsonProperty("student")]
        public string? Student { get; set; }
        
        [JsonProperty("title")]
        public string? Title { get; set; }
        
        // ... other fields
    }
}
```

### Bước 3: Tạo Repository (Data Access Layer)

```csharp
// File: MyWinFormsApp.DataAccess/Repositories/ProgressRepository.cs
using MyWinFormsApp.DataAccess.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Threading.Tasks;

namespace MyWinFormsApp.DataAccess.Repositories
{
    public class ProgressRepository
    {
        /// <summary>
        /// Lấy danh sách progress reports của sinh viên
        /// </summary>
        public async Task<ApiResponse<List<ProgressReportDto>>> GetMyProgressReportsAsync()
        {
            try
            {
                var client = ApiClient.CreateClient();
                var request = ApiClient.CreateRequest("/v1/api/progress/me", Method.Get);
                
                var response = await client.ExecuteAsync(request);
                
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<ApiResponse<List<ProgressReportDto>>>(response.Content);
                }
                else
                {
                    return new ApiResponse<List<ProgressReportDto>>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}",
                        Error = response.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<List<ProgressReportDto>>
                {
                    Success = false,
                    Message = "An error occurred",
                    Error = ex.Message
                };
            }
        }
        
        /// <summary>
        /// Tạo progress report mới
        /// </summary>
        public async Task<ApiResponse<ProgressReportDto>> CreateProgressReportAsync(ProgressReportDto report)
        {
            try
            {
                var client = ApiClient.CreateClient();
                var request = ApiClient.CreateRequest("/v1/api/progress", Method.Post);
                request.AddJsonBody(report);
                
                var response = await client.ExecuteAsync(request);
                
                if (response.IsSuccessful && !string.IsNullOrEmpty(response.Content))
                {
                    return JsonConvert.DeserializeObject<ApiResponse<ProgressReportDto>>(response.Content);
                }
                else
                {
                    return new ApiResponse<ProgressReportDto>
                    {
                        Success = false,
                        Message = $"Error: {response.StatusCode}",
                        Error = response.ErrorMessage
                    };
                }
            }
            catch (Exception ex)
            {
                return new ApiResponse<ProgressReportDto>
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

### Bước 4: Tạo Service (Business Layer)

```csharp
// File: MyWinFormsApp.Business/Services/ProgressService.cs
using MyWinFormsApp.Business.Models;
using MyWinFormsApp.DataAccess.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyWinFormsApp.Business.Services
{
    public class ProgressService
    {
        private readonly ProgressRepository _repository;

        public ProgressService()
        {
            _repository = new ProgressRepository();
        }

        public async Task<(bool Success, string Message, List<ProgressReport>? Reports)> GetMyProgressReportsAsync()
        {
            var response = await _repository.GetMyProgressReportsAsync();
            
            if (response.Success && response.Data != null)
            {
                // Map DTO to Business Model
                var reports = response.Data.Select(dto => new ProgressReport
                {
                    Id = dto.Id,
                    Student = dto.Student,
                    Title = dto.Title,
                    // ... map other fields
                }).ToList();
                
                return (true, "Success", reports);
            }
            else
            {
                return (false, response.Message ?? "Failed", null);
            }
        }
    }
}
```

### Bước 5: Tạo Form (UI Layer)

```csharp
// File: MyWinFormsApp/Forms/ProgressReportForm.cs
using MyWinFormsApp.Business.Services;
using System;
using System.Windows.Forms;

namespace MyWinFormsApp.Forms
{
    public partial class ProgressReportForm : Form
    {
        private readonly ProgressService _progressService;

        public ProgressReportForm()
        {
            InitializeComponent();
            _progressService = new ProgressService();
            LoadProgressReports();
        }

        private async void LoadProgressReports()
        {
            try
            {
                var (success, message, reports) = await _progressService.GetMyProgressReportsAsync();
                
                if (success && reports != null)
                {
                    // Hiển thị danh sách reports
                    dataGridView1.DataSource = reports;
                }
                else
                {
                    MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
```

### Bước 6: Tạo Mock Data (Optional)

```csharp
// File: MyWinFormsApp.MockData/ProgressReportMockData.cs
using MyWinFormsApp.Business.Models;
using System.Collections.Generic;

namespace MyWinFormsApp.MockData
{
    public static class ProgressReportMockData
    {
        public static List<ProgressReport> GetMockProgressReports()
        {
            return new List<ProgressReport>
            {
                new ProgressReport
                {
                    Id = "report001",
                    Student = "student001",
                    Title = "Báo cáo tuần 1",
                    Content = "Nội dung báo cáo...",
                    Week = 1,
                    Status = "submitted"
                },
                // ... more mock data
            };
        }
    }
}
```

## 🎨 Thêm Form mới

### 1. Tạo Form trong Visual Studio
1. Right-click vào `Forms` folder
2. Add → New Item → Form (Windows Forms)
3. Đặt tên: `StudentMainForm.cs`

### 2. Design Form
- Sử dụng màu sắc LHU (#0054A6, #F36F21)
- Layout consistent với LoginForm
- Thêm controls: DataGridView, Buttons, Labels, etc.

### 3. Implement Logic
```csharp
public partial class StudentMainForm : Form
{
    private readonly StudentService _studentService;
    
    public StudentMainForm()
    {
        InitializeComponent();
        _studentService = new StudentService();
        SetupColors();
        LoadData();
    }
    
    private void SetupColors()
    {
        this.BackColor = ColorTranslator.FromHtml("#0054A6");
        // ... setup other colors
    }
    
    private async void LoadData()
    {
        // Load student data
    }
}
```

## 🔄 Mở rộng LoginForm

### Chuyển đến Form tương ứng sau login

```csharp
// File: MyWinFormsApp/Forms/LoginForm.cs
private async void btnLogin_Click(object sender, EventArgs e)
{
    // ... existing login code
    
    if (success && user != null)
    {
        MessageBox.Show($"Đăng nhập thành công!\n\nChào mừng: {user.FullName}");
        
        // Mở form tương ứng với role
        Form mainForm = user.Role switch
        {
            "student" => new StudentMainForm(),
            "lecturer" => new LecturerMainForm(),
            "company" => new CompanyMainForm(),
            "admin" => new AdminMainForm(),
            _ => null
        };
        
        if (mainForm != null)
        {
            mainForm.Show();
            this.Hide();
        }
    }
}
```

## 📊 Best Practices

### 1. Naming Conventions
- Forms: `{Feature}Form.cs`
- Services: `{Entity}Service.cs`
- Repositories: `{Entity}Repository.cs`
- Models: `{Entity}.cs`

### 2. Error Handling
```csharp
try
{
    // API call
}
catch (Exception ex)
{
    MessageBox.Show($"Error: {ex.Message}", "Error", 
        MessageBoxButtons.OK, MessageBoxIcon.Error);
}
```

### 3. Async/Await
- Luôn dùng async/await cho API calls
- Disable buttons khi processing
- Show loading indicator

### 4. Validation
- Validate input trước khi gọi API
- Hiển thị lỗi rõ ràng cho user

## 🧪 Testing

### 1. Tạo Mock Data trước
### 2. Test UI với Mock Data
### 3. Test API integration
### 4. Test error cases

## 📚 Tài liệu tham khảo

- [PROJECT_STRUCTURE.md](PROJECT_STRUCTURE.md) - Cấu trúc dự án
- [API_INTEGRATION_GUIDE.md](API_INTEGRATION_GUIDE.md) - Tích hợp API
- [MOCK_DATA_GUIDE.md](MOCK_DATA_GUIDE.md) - Mock Data

---

**Happy Coding! 🚀**

