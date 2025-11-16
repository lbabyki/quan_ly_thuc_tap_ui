using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using MyWinFormsApp.Business.Models;
using MyWinFormsApp.Business.Services;
using MyWinFormsApp.UI.Services;
using MyWinFormsApp.MockData;

namespace MyWinFormsApp.UI.Forms
{
    public partial class StudentForm : Form
    {
        private readonly StudentService _studentService;
        private readonly bool _useMockData = true;

        // LHU Colors
        private readonly Color LHU_BLUE = Color.FromArgb(0, 84, 166);
        private readonly Color LHU_ORANGE = Color.FromArgb(243, 111, 33);

        // Data
        private StudentProfile? _currentProfile;
        private List<WeeklyReport> _weeklyReports = new List<WeeklyReport>();
        private List<WorkLog> _workLogs = new List<WorkLog>();
        private List<StudentGrade> _grades = new List<StudentGrade>();
        private InternshipProgress? _progress;
        private StudentStatistics? _statistics;
        private List<Milestone> _milestones = new List<Milestone>();
        private List<InternshipTopic> _availableTopics = new List<InternshipTopic>();
        private List<Company> _companies = new List<Company>();
        private List<InternshipRegistration> _myRegistrations = new List<InternshipRegistration>();

        public StudentForm()
        {
            try
            {
                InitializeComponent();

                // Initialize service with mock data provider if needed
                if (_useMockData)
                {
                    var mockDataProvider = new StudentMockDataProvider();
                    _studentService = new StudentService(null, true, mockDataProvider);
                }
                else
                {
                    _studentService = new StudentService();
                }

                this.Load += StudentForm_Load;
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khởi tạo StudentForm: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private async void StudentForm_Load(object sender, EventArgs e)
        {
            try
            {
                await LoadDataAsync();
                SetupGradeChart();
                SetupProgressChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi load dữ liệu: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        #region Data Loading

        private async Task LoadDataAsync()
        {
            await LoadProfileAsync();
            await LoadAvailableTopicsAsync();
            await LoadCompaniesAsync();
            await LoadMyRegistrationsAsync();
            await LoadWeeklyReportsAsync();
            await LoadWorkLogsAsync();
            await LoadGradesAsync();
            await LoadProgressAsync();
            await LoadStatisticsAsync();
            await LoadMilestonesAsync();
        }

        #endregion

        #region Data Loading - API

        private async Task LoadProfileAsync()
        {
            var (success, message, data) = await _studentService.GetProfileAsync();
            if (success && data != null)
            {
                _currentProfile = data;
                DisplayProfile();
            }
        }

        private async Task LoadWeeklyReportsAsync()
        {
            var (success, message, data) = await _studentService.GetWeeklyReportsAsync();
            if (success && data != null)
            {
                _weeklyReports = data;
                DisplayWeeklyReports();
            }
        }

        private async Task LoadWorkLogsAsync()
        {
            var (success, message, data) = await _studentService.GetWorkLogsAsync();
            if (success && data != null)
            {
                _workLogs = data;
                DisplayWorkLogs();
            }
        }

        private async Task LoadGradesAsync()
        {
            var (success, message, data) = await _studentService.GetGradesAsync();
            if (success && data != null)
            {
                _grades = data;
                DisplayGrades();
            }
        }

        private async Task LoadProgressAsync()
        {
            var (success, message, data) = await _studentService.GetProgressAsync();
            if (success && data != null)
            {
                _progress = data;
                DisplayProgress();
            }
        }

        private async Task LoadStatisticsAsync()
        {
            var (success, message, data) = await _studentService.GetStatisticsAsync();
            if (success && data != null)
            {
                _statistics = data;
                DisplayStatistics();
            }
        }

        private async Task LoadMilestonesAsync()
        {
            var (success, message, data) = await _studentService.GetMilestonesAsync();
            if (success && data != null)
            {
                _milestones = data;
                DisplayMilestones();
            }
        }

        #endregion

        #region Display Methods

        private async Task LoadAvailableTopicsAsync()
        {
            var (success, message, data) = await _studentService.GetAvailableTopicsAsync();
            if (success && data != null)
            {
                _availableTopics = data;
                DisplayAvailableTopics();
            }
        }

        private async Task LoadCompaniesAsync()
        {
            // Load companies from StudentMockData
            _companies = StudentMockData.GetApprovedCompanies();
            DisplayCompanies();
        }

        private async Task LoadMyRegistrationsAsync()
        {
            var (success, message, data) = await _studentService.GetMyRegistrationsAsync();
            if (success && data != null)
            {
                _myRegistrations = data;
                DisplayMyRegistrations();
            }
        }

        private void DisplayProfile()
        {
            if (_currentProfile == null) return;

            if (txtFullName != null) txtFullName.Text = _currentProfile.FullName;
            if (txtEmail != null) txtEmail.Text = _currentProfile.Email;
            if (txtPhone != null) txtPhone.Text = _currentProfile.Phone ?? "";
            if (txtStudentCode != null) txtStudentCode.Text = _currentProfile.StudentCode;
            if (txtDepartment != null) txtDepartment.Text = _currentProfile.Department ?? "";
            if (txtYear != null) txtYear.Text = _currentProfile.Year.ToString();
            if (rtbDescription != null) rtbDescription.Text = _currentProfile.Description ?? "";

            if (lblProfileStatus != null)
            {
                lblProfileStatus.Text = $"Trạng thái: {GetStatusText(_currentProfile.Status)}";
                lblProfileStatus.ForeColor = GetStatusColor(_currentProfile.Status);
            }
        }

        private void DisplayAvailableTopics()
        {
            if (dgvTopics == null) return;

            dgvTopics.DataSource = null;
            dgvTopics.DataSource = _availableTopics;

            // Configure columns
            if (dgvTopics.Columns.Count > 0)
            {
                if (dgvTopics.Columns.Contains("Id"))
                    dgvTopics.Columns["Id"]!.Visible = false;
                if (dgvTopics.Columns.Contains("CompanyId"))
                    dgvTopics.Columns["CompanyId"]!.Visible = false;
                if (dgvTopics.Columns.Contains("LecturerId"))
                    dgvTopics.Columns["LecturerId"]!.Visible = false;
                if (dgvTopics.Columns.Contains("LecturerName"))
                    dgvTopics.Columns["LecturerName"]!.Visible = false;
                if (dgvTopics.Columns.Contains("Skills"))
                    dgvTopics.Columns["Skills"]!.Visible = false;
                if (dgvTopics.Columns.Contains("StartDate"))
                    dgvTopics.Columns["StartDate"]!.Visible = false;
                if (dgvTopics.Columns.Contains("EndDate"))
                    dgvTopics.Columns["EndDate"]!.Visible = false;
                if (dgvTopics.Columns.Contains("Deadline"))
                    dgvTopics.Columns["Deadline"]!.Visible = false;
                if (dgvTopics.Columns.Contains("RejectionReason"))
                    dgvTopics.Columns["RejectionReason"]!.Visible = false;
                if (dgvTopics.Columns.Contains("CreatedAt"))
                    dgvTopics.Columns["CreatedAt"]!.Visible = false;
                if (dgvTopics.Columns.Contains("UpdatedAt"))
                    dgvTopics.Columns["UpdatedAt"]!.Visible = false;

                if (dgvTopics.Columns.Contains("Title"))
                    dgvTopics.Columns["Title"]!.HeaderText = "Đề tài";
                if (dgvTopics.Columns.Contains("CompanyName"))
                    dgvTopics.Columns["CompanyName"]!.HeaderText = "Doanh nghiệp";
                if (dgvTopics.Columns.Contains("Description"))
                    dgvTopics.Columns["Description"]!.HeaderText = "Mô tả";
                if (dgvTopics.Columns.Contains("Requirements"))
                    dgvTopics.Columns["Requirements"]!.HeaderText = "Yêu cầu";
                if (dgvTopics.Columns.Contains("MaxStudents"))
                    dgvTopics.Columns["MaxStudents"]!.HeaderText = "Số lượng";
                if (dgvTopics.Columns.Contains("CurrentStudents"))
                    dgvTopics.Columns["CurrentStudents"]!.HeaderText = "Đã đăng ký";
                if (dgvTopics.Columns.Contains("Duration"))
                    dgvTopics.Columns["Duration"]!.HeaderText = "Thời gian";
                if (dgvTopics.Columns.Contains("Location"))
                    dgvTopics.Columns["Location"]!.HeaderText = "Địa điểm";
                if (dgvTopics.Columns.Contains("Supervisor"))
                    dgvTopics.Columns["Supervisor"]!.HeaderText = "Người hướng dẫn";
                if (dgvTopics.Columns.Contains("Status"))
                    dgvTopics.Columns["Status"]!.HeaderText = "Trạng thái";
            }

            // Populate combo boxes
            if (cboTopics != null)
            {
                cboTopics.DataSource = null;
                cboTopics.DisplayMember = "Title";
                cboTopics.ValueMember = "Id";
                cboTopics.DataSource = _availableTopics;
            }
        }

        private void DisplayCompanies()
        {
            if (cboCompanies != null)
            {
                cboCompanies.DataSource = null;
                cboCompanies.DisplayMember = "CompanyName";
                cboCompanies.ValueMember = "Id";
                cboCompanies.DataSource = _companies;
            }
        }

        private void DisplayMyRegistrations()
        {
            if (dgvMyRegistrations == null) return;

            dgvMyRegistrations.DataSource = null;
            dgvMyRegistrations.DataSource = _myRegistrations;

            // Configure columns
            if (dgvMyRegistrations.Columns.Count > 0)
            {
                if (dgvMyRegistrations.Columns.Contains("Id"))
                    dgvMyRegistrations.Columns["Id"]!.Visible = false;
                if (dgvMyRegistrations.Columns.Contains("StudentId"))
                    dgvMyRegistrations.Columns["StudentId"]!.Visible = false;
                if (dgvMyRegistrations.Columns.Contains("TopicId"))
                    dgvMyRegistrations.Columns["TopicId"]!.Visible = false;
                if (dgvMyRegistrations.Columns.Contains("CompanyId"))
                    dgvMyRegistrations.Columns["CompanyId"]!.Visible = false;
                if (dgvMyRegistrations.Columns.Contains("CoverLetterUrl"))
                    dgvMyRegistrations.Columns["CoverLetterUrl"]!.Visible = false;
                if (dgvMyRegistrations.Columns.Contains("RejectionReason"))
                    dgvMyRegistrations.Columns["RejectionReason"]!.Visible = false;

                if (dgvMyRegistrations.Columns.Contains("StudentName"))
                    dgvMyRegistrations.Columns["StudentName"]!.Visible = false;
                if (dgvMyRegistrations.Columns.Contains("StudentCode"))
                    dgvMyRegistrations.Columns["StudentCode"]!.Visible = false;

                if (dgvMyRegistrations.Columns.Contains("TopicTitle"))
                    dgvMyRegistrations.Columns["TopicTitle"]!.HeaderText = "Đề tài";
                if (dgvMyRegistrations.Columns.Contains("CompanyName"))
                    dgvMyRegistrations.Columns["CompanyName"]!.HeaderText = "Doanh nghiệp";
                if (dgvMyRegistrations.Columns.Contains("Status"))
                    dgvMyRegistrations.Columns["Status"]!.HeaderText = "Trạng thái";
                if (dgvMyRegistrations.Columns.Contains("RegisteredAt"))
                {
                    dgvMyRegistrations.Columns["RegisteredAt"]!.HeaderText = "Ngày đăng ký";
                    dgvMyRegistrations.Columns["RegisteredAt"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
                }
                if (dgvMyRegistrations.Columns.Contains("ApprovedAt"))
                {
                    dgvMyRegistrations.Columns["ApprovedAt"]!.HeaderText = "Ngày duyệt";
                    dgvMyRegistrations.Columns["ApprovedAt"]!.DefaultCellStyle.Format = "dd/MM/yyyy";
                }
            }
        }

        private void DisplayWeeklyReports()
        {
            if (dgvWeeklyReports == null) return;
            dgvWeeklyReports.Rows.Clear();
            foreach (var report in _weeklyReports.OrderByDescending(r => r.WeekNumber))
            {
                dgvWeeklyReports.Rows.Add(
                    report.WeekNumber,
                    report.Title,
                    $"{report.Progress}%",
                    GetStatusText(report.Status),
                    report.SubmittedAt?.ToString("dd/MM/yyyy") ?? "",
                    report.LecturerComment ?? "",
                    report.CompanyComment ?? ""
                );
            }
        }

        private void DisplayWorkLogs()
        {
            if (lvWorkLogs == null) return;
            lvWorkLogs.Items.Clear();
            foreach (var log in _workLogs.OrderByDescending(w => w.Date))
            {
                var item = new ListViewItem(log.Date.ToString("dd/MM/yyyy"));
                item.SubItems.Add(log.Title);
                item.SubItems.Add($"{log.HoursWorked}h");
                item.SubItems.Add(log.Tags ?? "");
                item.Tag = log;
                lvWorkLogs.Items.Add(item);
            }
        }

        private void DisplayGrades()
        {
            if (dgvGrades == null) return;
            dgvGrades.Rows.Clear();
            foreach (var grade in _grades)
            {
                dgvGrades.Rows.Add(
                    grade.Category,
                    grade.Score,
                    grade.MaxScore,
                    grade.GraderName,
                    grade.Comment ?? "",
                    grade.GradedAt.ToString("dd/MM/yyyy")
                );
            }

            if (_grades.Any() && lblAverageScore != null)
            {
                var avgScore = _grades.Average(g => g.Score);
                lblAverageScore.Text = $"Điểm trung bình: {avgScore:F2}";
            }

            // Setup chart
            if (chartGrades != null && _grades.Any())
            {
                try
                {
                    SetupGradeChart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải biểu đồ điểm: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DisplayProgress()
        {
            if (_progress == null) return;

            if (progressBar != null)
            {
                progressBar.Maximum = 100;
                progressBar.Value = _progress.ProgressPercentage;
            }
            if (lblProgressPercent != null) lblProgressPercent.Text = $"{_progress.ProgressPercentage}%";
            if (lblCompletedWeeks != null) lblCompletedWeeks.Text = $"Đã hoàn thành: {_progress.CompletedWeeks}/{_progress.TotalWeeks} tuần";
            if (lblDaysRemaining != null) lblDaysRemaining.Text = $"Còn lại: {_progress.DaysRemaining} ngày";
            if (lblReportDeadline != null) lblReportDeadline.Text = $"Hạn nộp báo cáo: {_progress.ReportDeadline?.ToString("dd/MM/yyyy")}";
            if (lblDefenseDate != null) lblDefenseDate.Text = $"Ngày bảo vệ: {_progress.DefenseDate?.ToString("dd/MM/yyyy")}";

            if (calDeadline != null)
            {
                if (_progress.ReportDeadline.HasValue)
                {
                    calDeadline.AddBoldedDate(_progress.ReportDeadline.Value);
                }
                if (_progress.DefenseDate.HasValue)
                {
                    calDeadline.AddBoldedDate(_progress.DefenseDate.Value);
                }
            }
        }

        private void DisplayStatistics()
        {
            if (_statistics == null) return;

            if (lblTotalReports != null) lblTotalReports.Text = $"Tổng báo cáo: {_statistics.TotalReports}";
            if (lblSubmittedReports != null) lblSubmittedReports.Text = $"Đã nộp: {_statistics.SubmittedReports}";
            if (lblTotalWorkLogs != null) lblTotalWorkLogs.Text = $"Nhật ký: {_statistics.TotalWorkLogs}";
            if (lblTotalHours != null) lblTotalHours.Text = $"Tổng giờ: {_statistics.TotalHoursWorked}h";
            if (lblStatDaysRemaining != null) lblStatDaysRemaining.Text = $"Còn lại: {_statistics.DaysRemaining} ngày";

            if (pbMilestones != null)
            {
                pbMilestones.Maximum = _statistics.TotalMilestones;
                pbMilestones.Value = _statistics.CompletedMilestones;
            }

            // Setup chart
            if (chartProgress != null)
            {
                try
                {
                    SetupProgressChart();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi tải biểu đồ tiến độ: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DisplayMilestones()
        {
            if (lvMilestones == null) return;
            lvMilestones.Items.Clear();
            foreach (var milestone in _milestones.OrderBy(m => m.DueDate))
            {
                var item = new ListViewItem(milestone.Title);
                item.SubItems.Add(milestone.Description);
                item.SubItems.Add(milestone.DueDate.ToString("dd/MM/yyyy"));
                item.SubItems.Add(milestone.IsCompleted ? "✓ Hoàn thành" : "○ Chưa");
                item.SubItems.Add(milestone.CompletedAt?.ToString("dd/MM/yyyy") ?? "");
                item.ForeColor = milestone.IsCompleted ? Color.Green : Color.Black;
                lvMilestones.Items.Add(item);
            }
        }

        #endregion

        #region Event Handlers

        private async void btnSaveProfile_Click(object sender, EventArgs e)
        {
            try
            {
                var phone = txtPhone.Text.Trim();
                var description = rtbDescription.Text.Trim();

                var (success, message) = await _studentService.UpdateProfileAsync(
                    phone, description, _currentProfile?.AvatarUrl, _currentProfile?.CvUrl);

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadProfileAsync();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnUploadAvatar_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.Title = "Chọn ảnh đại diện";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        picAvatar.Image = Image.FromFile(openFileDialog.FileName);
                        MessageBox.Show("Upload ảnh thành công!", "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Lỗi khi tải ảnh: {ex.Message}", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnUploadCV_Click(object sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "PDF Files|*.pdf|Word Files|*.doc;*.docx";
                openFileDialog.Title = "Chọn file CV";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    MessageBox.Show($"Đã chọn file: {openFileDialog.FileName}\n\nChức năng upload đang được phát triển.",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        #endregion

        #region Helper Methods

        private string GetStatusText(string status)
        {
            return status switch
            {
                "pending" => "Chờ duyệt",
                "approved" => "Đã duyệt",
                "rejected" => "Từ chối",
                "draft" => "Nháp",
                "submitted" => "Đã nộp",
                "reviewed" => "Đã chấm",
                "in_progress" => "Đang thực hiện",
                "completed" => "Hoàn thành",
                _ => status
            };
        }

        private Color GetStatusColor(string status)
        {
            return status switch
            {
                "approved" => Color.Green,
                "pending" => LHU_ORANGE,
                "rejected" => Color.Red,
                "completed" => Color.Green,
                _ => Color.Black
            };
        }

        private void SetupGradeChart()
        {
            chartGrades.Series.Clear();
            chartGrades.ChartAreas.Clear();

            var chartArea = new ChartArea();
            chartGrades.ChartAreas.Add(chartArea);

            var series = new Series
            {
                Name = "Điểm",
                ChartType = SeriesChartType.Column,
                Color = LHU_BLUE
            };

            foreach (var grade in _grades)
            {
                series.Points.AddXY(grade.Category, grade.Score);
            }

            chartGrades.Series.Add(series);
            chartGrades.Titles.Clear();
            chartGrades.Titles.Add("Biểu đồ điểm đánh giá");
        }

        private void SetupProgressChart()
        {
            if (_statistics == null) return;

            chartProgress.Series.Clear();
            chartProgress.ChartAreas.Clear();

            var chartArea = new ChartArea();
            chartProgress.ChartAreas.Add(chartArea);

            var series = new Series
            {
                Name = "Tiến độ",
                ChartType = SeriesChartType.Doughnut
            };

            var completed = series.Points.Add(_statistics.CompletedMilestones);
            completed.Color = LHU_BLUE;
            completed.Label = $"Hoàn thành ({_statistics.CompletedMilestones})";

            var remaining = series.Points.Add(_statistics.TotalMilestones - _statistics.CompletedMilestones);
            remaining.Color = LHU_ORANGE;
            remaining.Label = $"Còn lại ({_statistics.TotalMilestones - _statistics.CompletedMilestones})";

            chartProgress.Series.Add(series);
            chartProgress.Titles.Clear();
            chartProgress.Titles.Add("Tiến độ hoàn thành Milestone");
        }

        #endregion
    }
}

