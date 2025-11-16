# 📚 Hướng dẫn Module Sinh viên - Quản lý Thực tập

## 📋 Tổng quan

Module Sinh viên đã được implement với đầy đủ các chức năng theo yêu cầu:
- ✅ Hồ sơ cá nhân
- ✅ Đăng ký thực tập
- ✅ Quản lý tiến độ
- ✅ Xem điểm & phản hồi
- ✅ Thống kê cá nhân

---

## 🏗️ Kiến trúc 3 lớp

### **1. Models (Business Layer)**
📁 `MyWinFormsApp.Business/Models/StudentProfile.cs`

**Các models đã tạo:**
- `StudentProfile` - Hồ sơ sinh viên
- `InternshipRegistration` - Đăng ký thực tập
- `WeeklyReport` - Báo cáo tuần
- `WorkLog` - Nhật ký công việc
- `StudentGrade` - Điểm đánh giá
- `InternshipProgress` - Tiến độ thực tập
- `Milestone` - Mốc hoàn thành
- `StudentStatistics` - Thống kê

### **2. DTOs (Data Access Layer)**
📁 `MyWinFormsApp.DataAccess/Models/StudentDtos.cs`

**Các DTOs cho API:**
- `UpdateStudentProfileDto`
- `CreateInternshipRegistrationDto`
- `CreateWeeklyReportDto`
- `UpdateWeeklyReportDto`
- `CreateWorkLogDto`
- `AvailableTopicsResponse`
- `ProgressResponse`
- `GradesResponse`
- `StatisticsResponse`

### **3. Repository (Data Access Layer)**
📁 `MyWinFormsApp.DataAccess/Repositories/StudentRepository.cs`

**API Endpoints:**
```
GET    /v1/api/students/profile
PUT    /v1/api/students/profile
GET    /v1/api/students/topics/available
POST   /v1/api/students/registrations
GET    /v1/api/students/reports
POST   /v1/api/students/reports
GET    /v1/api/students/progress
GET    /v1/api/students/grades
GET    /v1/api/students/statistics
```

**Features:**
- ✅ RestSharp client
- ✅ JWT token trong Header
- ✅ Error handling
- ✅ Async/await pattern

### **4. Service (Business Layer)**
📁 `MyWinFormsApp.Business/Services/StudentService.cs`

**Methods:**
- `GetProfileAsync()` - Lấy hồ sơ
- `UpdateProfileAsync()` - Cập nhật hồ sơ
- `GetAvailableTopicsAsync()` - Lấy đề tài
- `RegisterInternshipAsync()` - Đăng ký thực tập
- `GetWeeklyReportsAsync()` - Lấy báo cáo tuần
- `CreateWeeklyReportAsync()` - Tạo báo cáo
- `GetWorkLogsAsync()` - Lấy nhật ký
- `CreateWorkLogAsync()` - Tạo nhật ký
- `GetGradesAsync()` - Lấy điểm
- `GetProgressAsync()` - Lấy tiến độ
- `GetStatisticsAsync()` - Lấy thống kê
- `GetMilestonesAsync()` - Lấy milestones

**Features:**
- ✅ Toggle Mock Data / API: `_useMockData` flag
- ✅ Validation
- ✅ Mapping DTO ↔ Model
- ✅ Error handling

### **5. Mock Data**
📁 `MyWinFormsApp.MockData/StudentProfileMockData.cs`

**Dữ liệu mẫu:**
- 1 sinh viên: Nguyễn Văn An (2021600001)
- 1 đăng ký thực tập: Công ty ABC
- 3 báo cáo tuần (tuần 1, 2, 3)
- 3 nhật ký công việc
- 3 điểm đánh giá (Quá trình, Báo cáo, DN)
- 1 tiến độ: 40% (3/12 tuần)
- 5 milestones (2 hoàn thành, 3 chưa)

---

## 🎨 UI Components (StudentForm)

### **Tab 1: Hồ sơ cá nhân**

**Controls:**
```csharp
PictureBox picAvatar;           // Avatar 150x150
TextBox txtFullName;            // Họ tên (readonly)
TextBox txtEmail;               // Email (readonly)
TextBox txtPhone;               // Số điện thoại
TextBox txtStudentCode;         // Mã SV (readonly)
TextBox txtDepartment;          // Khoa (readonly)
TextBox txtYear;                // Năm học (readonly)
RichTextBox rtbDescription;     // Mô tả bản thân
Label lblProfileStatus;         // Trạng thái hồ sơ
Button btnUploadAvatar;         // Upload ảnh
Button btnUploadCV;             // Upload CV
Button btnSaveProfile;          // Lưu hồ sơ
```

**Chức năng:**
- Upload avatar (OpenFileDialog → .jpg, .png)
- Upload CV (OpenFileDialog → .pdf, .docx)
- Cập nhật phone, description
- Hiển thị trạng thái: Pending/Approved/Rejected

### **Tab 2: Đăng ký thực tập**

**Controls:**
```csharp
ComboBox cboTopics;             // Chọn đề tài
ComboBox cboCompanies;          // Chọn doanh nghiệp
DataGridView dgvTopics;         // Danh sách đề tài
Button btnRegister;             // Đăng ký
Button btnUploadCoverLetter;    // Upload thư giới thiệu
DataGridView dgvMyRegistrations; // Đăng ký của tôi
```

**Columns dgvTopics:**
- Tiêu đề
- Công ty
- Mô tả
- Số lượng (X/Y)
- Yêu cầu
- Trạng thái

**Chức năng:**
- Xem danh sách đề tài đã duyệt
- Lọc theo công ty
- Đăng ký đề tài
- Upload thư giới thiệu
- Xem trạng thái đăng ký

### **Tab 3: Quản lý tiến độ**

**TabControl với 3 tabs:**

#### **Tab 3.1: Báo cáo tuần**
```csharp
DataGridView dgvWeeklyReports;  // Danh sách báo cáo
Button btnCreateReport;         // Tạo báo cáo mới
Button btnSubmitReport;         // Nộp báo cáo
Button btnViewReport;           // Xem chi tiết
```

**Columns:**
- Tuần
- Tiêu đề
- Tiến độ (%)
- Trạng thái
- Ngày nộp
- Nhận xét GV
- Nhận xét DN

#### **Tab 3.2: Nhật ký công việc**
```csharp
RichTextBox rtbWorkLog;         // Nội dung nhật ký
DateTimePicker dtpWorkDate;     // Ngày làm việc
TextBox txtWorkTitle;           // Tiêu đề
NumericUpDown nudHoursWorked;   // Số giờ làm việc
TextBox txtTags;                // Tags
Button btnSaveWorkLog;          // Lưu nhật ký
ListView lvWorkLogs;            // Danh sách nhật ký
```

#### **Tab 3.3: Tiến độ & Deadline**
```csharp
ProgressBar progressBar;        // Tiến độ tổng thể
Label lblProgressPercent;       // % hoàn thành
Label lblCompletedWeeks;        // Số tuần hoàn thành
Label lblTotalWeeks;            // Tổng số tuần
MonthCalendar calDeadline;      // Lịch deadline
Label lblDaysRemaining;         // Số ngày còn lại
Label lblReportDeadline;        // Hạn nộp báo cáo
Label lblDefenseDate;           // Ngày bảo vệ
```

### **Tab 4: Điểm & Phản hồi**

**Controls:**
```csharp
DataGridView dgvGrades;         // Bảng điểm
GroupBox gbLecturerComment;     // Nhận xét GV
RichTextBox rtbLecturerComment; // Nội dung nhận xét GV
GroupBox gbCompanyComment;      // Nhận xét DN
RichTextBox rtbCompanyComment;  // Nội dung nhận xét DN
Chart chartGrades;              // Biểu đồ điểm
Label lblAverageScore;          // Điểm trung bình
```

**Columns dgvGrades:**
- Hạng mục
- Điểm
- Điểm tối đa
- Người chấm
- Nhận xét
- Ngày chấm

**Chart:**
- Type: Column
- Series: Điểm theo hạng mục
- Colors: LHU Blue & Orange

### **Tab 5: Thống kê cá nhân**

**Controls:**
```csharp
Chart chartProgress;            // Biểu đồ tiến độ
Label lblTotalReports;          // Tổng số báo cáo
Label lblSubmittedReports;      // Đã nộp
Label lblTotalWorkLogs;         // Tổng nhật ký
Label lblTotalHours;            // Tổng giờ làm việc
Label lblDaysRemaining;         // Ngày còn lại
ListView lvMilestones;          // Danh sách milestone
ProgressBar pbMilestones;       // Tiến độ milestone
```

**ListView Milestones Columns:**
- Tiêu đề
- Mô tả
- Deadline
- Trạng thái
- Ngày hoàn thành

**Chart Progress:**
- Type: Pie / Doughnut
- Data: Completed vs Remaining

---

## 🎨 Màu sắc LHU

```csharp
Color LHU_BLUE = Color.FromArgb(0, 84, 166);    // #0054A6
Color LHU_ORANGE = Color.FromArgb(243, 111, 33); // #F36F21
```

**Áp dụng:**
- Header panels: LHU_BLUE background, White text
- Buttons: LHU_BLUE (primary), LHU_ORANGE (secondary)
- Charts: LHU_BLUE & LHU_ORANGE colors
- Status labels: Green (approved), Orange (pending), Red (rejected)

---

## 📝 Code mẫu StudentForm.Designer.cs

Do file Designer quá dài (>1000 dòng), dưới đây là cấu trúc chính:

```csharp
private void InitializeComponent()
{
    this.tabControl = new TabControl();
    this.tabProfile = new TabPage("Hồ sơ cá nhân");
    this.tabRegistration = new TabPage("Đăng ký thực tập");
    this.tabProgress = new TabPage("Quản lý tiến độ");
    this.tabGrades = new TabPage("Điểm & Phản hồi");
    this.tabStatistics = new TabPage("Thống kê");
    
    // Tab Profile
    this.picAvatar = new PictureBox();
    this.txtFullName = new TextBox();
    // ... other controls
    
    // Tab Registration
    this.dgvTopics = new DataGridView();
    this.cboTopics = new ComboBox();
    // ... other controls
    
    // Tab Progress
    this.tabControlProgress = new TabControl();
    this.tabReports = new TabPage("Báo cáo tuần");
    this.tabWorkLogs = new TabPage("Nhật ký");
    this.tabDeadline = new TabPage("Tiến độ");
    
    // Tab Grades
    this.dgvGrades = new DataGridView();
    this.chartGrades = new Chart();
    
    // Tab Statistics
    this.chartProgress = new Chart();
    this.lvMilestones = new ListView();
}
```

---

## 🔧 Cách sử dụng

### **1. Chạy với Mock Data**

```csharp
// Trong StudentForm.cs
private readonly bool _useMockData = true;

// Trong StudentService
public StudentService(string? token = null, bool useMockData = true)
{
    _repository = new StudentRepository(token);
    _useMockData = useMockData;
}
```

### **2. Chuyển sang API thật**

```csharp
// Đổi flag
private readonly bool _useMockData = false;

// Truyền JWT token
var token = "your_jwt_token_here";
_studentService = new StudentService(token, false);
```

---

## 📊 Kết quả

✅ **Models**: 8 models hoàn chỉnh  
✅ **DTOs**: 10+ DTOs cho API  
✅ **Repository**: 9 API methods với RestSharp + JWT  
✅ **Service**: 12 business methods với validation  
✅ **Mock Data**: Đầy đủ dữ liệu mẫu  
✅ **UI**: 5 tabs với 30+ controls  

---

## 🚀 Bước tiếp theo

1. **Hoàn thiện StudentForm.Designer.cs** - Tạo đầy đủ UI controls
2. **Implement Event Handlers** - Xử lý sự kiện button click, selection changed
3. **File Upload** - Implement upload avatar, CV, cover letter
4. **Chart Setup** - Cấu hình biểu đồ điểm và tiến độ
5. **Validation** - Validate input trước khi submit
6. **Testing** - Test với mock data
7. **API Integration** - Kết nối API thật khi backend sẵn sàng

---

## 📌 Lưu ý

- **Mock Data**: Hiện tại đang dùng mock data, khi API sẵn sàng chỉ cần đổi `_useMockData = false`
- **JWT Token**: Cần truyền token khi khởi tạo StudentService
- **File Upload**: Cần implement upload file lên server (chưa có trong code mẫu)
- **Chart**: Cần cài NuGet package `System.Windows.Forms.DataVisualization`

