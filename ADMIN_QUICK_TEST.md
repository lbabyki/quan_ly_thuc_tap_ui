# 🧪 Admin Module - Hướng dẫn Test nhanh

## 🚀 Cách 1: Test trực tiếp AdminForm

### Bước 1: Sửa Program.cs để mở AdminForm
Mở file `MyWinFormsApp.UI/Program.cs` và sửa như sau:

```csharp
using MyWinFormsApp.Forms;
using System;
using System.Windows.Forms;

namespace MyWinFormsApp
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            
            // Test AdminForm trực tiếp
            Application.Run(new AdminForm());
            
            // Hoặc chạy LoginForm như bình thường
            // Application.Run(new LoginForm());
        }
    }
}
```

### Bước 2: Build và Run
```bash
dotnet build
dotnet run --project MyWinFormsApp.UI
```

## 🎯 Cách 2: Thêm button vào LoginForm

### Bước 1: Thêm button "Admin" vào LoginForm.Designer.cs

```csharp
// Thêm vào phần khai báo controls
private System.Windows.Forms.Button btnAdmin;

// Thêm vào InitializeComponent()
this.btnAdmin = new System.Windows.Forms.Button();

// Setup button
this.btnAdmin.Location = new System.Drawing.Point(300, 400);
this.btnAdmin.Name = "btnAdmin";
this.btnAdmin.Size = new System.Drawing.Size(100, 35);
this.btnAdmin.TabIndex = 4;
this.btnAdmin.Text = "Admin Test";
this.btnAdmin.UseVisualStyleBackColor = true;
this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);

// Thêm vào form
this.Controls.Add(this.btnAdmin);
```

### Bước 2: Thêm event handler vào LoginForm.cs

```csharp
private void btnAdmin_Click(object sender, EventArgs e)
{
    var adminForm = new AdminForm();
    adminForm.Show();
    this.Hide();
}
```

## 📊 Test các chức năng

### 1. Test Quản lý người dùng

#### Tab Sinh viên
- ✅ Xem danh sách sinh viên (3 users)
- ✅ Click "Xóa" để xóa user
- ✅ Right-click → "Reset mật khẩu"
- ✅ Click "Tạo mới" / "Sửa" (hiện thông báo TODO)

#### Tab Giảng viên
- ✅ Xem danh sách giảng viên (2 users)
- ✅ Các chức năng tương tự

#### Tab Doanh nghiệp
- ✅ Xem danh sách doanh nghiệp (3 users)
- ✅ Các chức năng tương tự

### 2. Test Đề tài thực tập

- ✅ Chọn "Tất cả" trong ComboBox → Hiển thị 4 topics
- ✅ Chọn "pending" → Hiển thị 2 topics
- ✅ Chọn "approved" → Hiển thị 1 topic
- ✅ Chọn "rejected" → Hiển thị 1 topic
- ✅ Chọn 1 topic pending → Click "Duyệt"
- ✅ Chọn 1 topic pending → Click "Từ chối" → Nhập lý do

### 3. Test Nhật ký hệ thống

- ✅ Xem danh sách 5 logs
- ✅ Kiểm tra format: Thời gian | Người dùng | Hành động | IP

### 4. Test Thống kê

#### Panel thống kê
- ✅ Tổng SV: 3
- ✅ Tổng GV: 2
- ✅ Tổng DN: 3
- ✅ Tổng đề tài: 4
- ✅ Đang thực tập: 2
- ✅ Chờ duyệt: 2
- ✅ Điểm TB: 8.50

#### Charts
- ✅ Chart 1: Sinh viên theo công ty (Column chart màu cam)
- ✅ Chart 2: Điểm TB theo ngành (Bar chart màu xanh)

## 🎨 Kiểm tra giao diện

### Màu sắc
- ✅ Form background: Blue #0054A6
- ✅ Buttons: Orange #F36F21
- ✅ DataGridView headers: Blue #0054A6
- ✅ Charts: Blue & Orange

### Layout
- ✅ TabControl với 4 tabs
- ✅ Buttons alignment
- ✅ DataGridView fill space
- ✅ Charts size và position

## 🔄 Test Mock Data vs API

### Mock Data Mode (Default)
```csharp
// Trong AdminForm.cs
private readonly bool _useMockData = true;
```

**Kết quả:**
- Data từ `AdminMockData`
- Không cần backend
- Thay đổi lưu trong memory

### API Mode
```csharp
// Trong AdminForm.cs
private readonly bool _useMockData = false;
```

**Yêu cầu:**
- Backend API đang chạy
- JWT token hợp lệ trong `ApiClient.Token`
- Endpoints `/v1/api/admin/*` available

## 🐛 Troubleshooting

### Lỗi: Chart không hiển thị
**Giải pháp:** Đảm bảo đã cài package:
```bash
dotnet add MyWinFormsApp.UI/MyWinFormsApp.csproj package System.Windows.Forms.DataVisualization --prerelease
```

### Lỗi: InputBox không tìm thấy
**Giải pháp:** Đảm bảo đã cài package:
```bash
dotnet add MyWinFormsApp.UI/MyWinFormsApp.csproj package Microsoft.VisualBasic
```

### Lỗi: Build failed
**Giải pháp:** Clean và rebuild:
```bash
dotnet clean
dotnet build
```

## 📸 Screenshots checklist

Khi test, kiểm tra:
- [ ] Tab "Quản lý người dùng" với 3 sub-tabs
- [ ] DataGridView hiển thị đúng data
- [ ] Buttons có màu cam
- [ ] Tab "Đề tài thực tập" với ComboBox filter
- [ ] Tab "Nhật ký hệ thống" với ListView
- [ ] Tab "Thống kê" với Panel + 2 Charts
- [ ] Context menu "Reset mật khẩu" khi right-click
- [ ] Dialog "Từ chối đề tài" với InputBox

## ✅ Checklist hoàn thành

- [x] Build thành công (0 errors, 0 warnings)
- [x] AdminForm mở được
- [x] 4 tabs hiển thị đúng
- [x] Mock data load được
- [x] Buttons hoạt động
- [x] DataGridView hiển thị data
- [x] Charts render được
- [x] Màu sắc LHU đúng
- [x] Context menu hoạt động
- [x] ComboBox filter hoạt động

---

**Happy Testing! 🎉**

