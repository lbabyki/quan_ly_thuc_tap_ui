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

namespace MyWinFormsApp.UI.Forms
{
    public partial class TeacherForm : Form
    {
        private readonly LecturerService _lecturerService;
        private readonly bool _useMockData = true;
        
        private List<SupervisedStudent> _allStudents = new List<SupervisedStudent>();
        private List<StudentReport> _allReports = new List<StudentReport>();
        private List<StudentGrading> _allGradings = new List<StudentGrading>();
        private List<DefenseSchedule> _allDefenseSchedules = new List<DefenseSchedule>();
        private LecturerStatistics? _statistics;

        public TeacherForm()
        {
            InitializeComponent();
            
            // Initialize service with mock data
            if (_useMockData)
            {
                var mockDataProvider = new TeacherMockDataProvider();
                _lecturerService = new LecturerService(null, true, mockDataProvider);
            }
            else
            {
                _lecturerService = new LecturerService(); // API mode
            }
            
            // Set default values
            cboStatusFilter.SelectedIndex = 0;
            cboReportStatusFilter.SelectedIndex = 0;
            cboStatsFilter.SelectedIndex = 0;
            
            // Wire up event handlers
            WireUpEventHandlers();
        }

        private void WireUpEventHandlers()
        {
            // Students Tab
            cboStatusFilter.SelectedIndexChanged += CboStatusFilter_SelectedIndexChanged;
            btnSearchStudent.Click += BtnSearchStudent_Click;
            btnRefreshStudents.Click += BtnRefreshStudents_Click;
            
            // Reports Tab
            cboReportStatusFilter.SelectedIndexChanged += CboReportStatusFilter_SelectedIndexChanged;
            dgvReports.SelectionChanged += DgvReports_SelectionChanged;
            btnSubmitReview.Click += BtnSubmitReview_Click;
            
            // Grading Tab
            dgvGrading.CellEndEdit += DgvGrading_CellEndEdit;
            btnSaveGrades.Click += BtnSaveGrades_Click;
            btnExportGrades.Click += BtnExportGrades_Click;
            
            // Defense Tab
            calendarDefense.DateSelected += CalendarDefense_DateSelected;
            btnCreateDefense.Click += BtnCreateDefense_Click;
            btnDeleteDefense.Click += BtnDeleteDefense_Click;
            btnExportDefensePDF.Click += BtnExportDefensePDF_Click;
            
            // Statistics Tab
            cboStatsFilter.SelectedIndexChanged += CboStatsFilter_SelectedIndexChanged;
            btnExportStats.Click += BtnExportStats_Click;
        }

        private async void TeacherForm_Load(object sender, EventArgs e)
        {
            await LoadAllDataAsync();
        }

        private async Task LoadAllDataAsync()
        {
            try
            {
                this.Cursor = Cursors.WaitCursor;
                
                // Load all data in parallel
                var studentsTask = LoadStudentsAsync();
                var reportsTask = LoadReportsAsync();
                var gradingsTask = LoadGradingsAsync();
                var defensesTask = LoadDefenseSchedulesAsync();
                var statsTask = LoadStatisticsAsync();
                
                await Task.WhenAll(studentsTask, reportsTask, gradingsTask, defensesTask, statsTask);
                
                this.Cursor = Cursors.Default;
            }
            catch (Exception ex)
            {
                this.Cursor = Cursors.Default;
                MessageBox.Show($"Lỗi khi tải dữ liệu: {ex.Message}", "Lỗi", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Students Tab

        private async Task LoadStudentsAsync(string? status = null)
        {
            var (success, message, students) = await _lecturerService.GetSupervisedStudentsAsync(status);
            
            if (success)
            {
                _allStudents = students;
                dgvStudents.DataSource = null;
                dgvStudents.DataSource = students;
                
                // Configure columns
                if (dgvStudents.Columns.Count > 0)
                {
                    dgvStudents.Columns["Id"]!.Visible = false;
                    dgvStudents.Columns["StudentCode"]!.HeaderText = "Mã SV";
                    dgvStudents.Columns["StudentName"]!.HeaderText = "Họ tên";
                    dgvStudents.Columns["TopicTitle"]!.HeaderText = "Đề tài";
                    dgvStudents.Columns["CompanyName"]!.HeaderText = "Doanh nghiệp";
                    dgvStudents.Columns["Status"]!.HeaderText = "Trạng thái";
                    dgvStudents.Columns["StartDate"]!.HeaderText = "Ngày bắt đầu";
                    dgvStudents.Columns["EndDate"]!.HeaderText = "Ngày kết thúc";
                    dgvStudents.Columns["Progress"]!.HeaderText = "Tiến độ (%)";
                }
                
                lblStudentCount.Text = $"Tổng số: {students.Count} sinh viên";
            }
            else
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CboStatusFilter_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string? status = cboStatusFilter.SelectedIndex switch
            {
                0 => null, // Tất cả
                1 => "in_progress", // Đang thực tập
                2 => "completed", // Hoàn thành
                3 => "failed", // Thất bại
                _ => null
            };
            
            await LoadStudentsAsync(status);
        }

        private async void BtnSearchStudent_Click(object? sender, EventArgs e)
        {
            string searchText = txtSearchStudent.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchText))
            {
                dgvStudents.DataSource = _allStudents;
                return;
            }

            var filtered = _allStudents.Where(s =>
                s.StudentCode.ToLower().Contains(searchText) ||
                s.StudentName.ToLower().Contains(searchText) ||
                s.TopicTitle.ToLower().Contains(searchText) ||
                s.CompanyName.ToLower().Contains(searchText)
            ).ToList();

            dgvStudents.DataSource = null;
            dgvStudents.DataSource = filtered;
            lblStudentCount.Text = $"Tìm thấy: {filtered.Count} sinh viên";
        }

        private async void BtnRefreshStudents_Click(object? sender, EventArgs e)
        {
            await LoadStudentsAsync();
        }

        #endregion

        #region Reports Tab

        private async Task LoadReportsAsync(string? status = null)
        {
            var (success, message, reports) = await _lecturerService.GetStudentReportsAsync(status);

            if (success)
            {
                _allReports = reports;
                dgvReports.DataSource = null;
                dgvReports.DataSource = reports;

                // Configure columns
                if (dgvReports.Columns.Count > 0)
                {
                    dgvReports.Columns["Id"]!.Visible = false;
                    dgvReports.Columns["StudentId"]!.Visible = false;
                    dgvReports.Columns["StudentCode"]!.HeaderText = "Mã SV";
                    dgvReports.Columns["StudentName"]!.HeaderText = "Họ tên";
                    dgvReports.Columns["Title"]!.HeaderText = "Tiêu đề";
                    dgvReports.Columns["WeekNumber"]!.HeaderText = "Tuần";
                    dgvReports.Columns["SubmittedAt"]!.HeaderText = "Ngày nộp";
                    dgvReports.Columns["Status"]!.HeaderText = "Trạng thái";
                    dgvReports.Columns["Content"]!.Visible = false;
                    dgvReports.Columns["LecturerComment"]!.Visible = false;
                    dgvReports.Columns["ReviewedAt"]!.HeaderText = "Ngày phản hồi";
                    dgvReports.Columns["AttachmentUrl"]!.Visible = false;
                    dgvReports.Columns["Progress"]!.HeaderText = "Tiến độ (%)";
                }
            }
            else
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CboReportStatusFilter_SelectedIndexChanged(object? sender, EventArgs e)
        {
            string? status = cboReportStatusFilter.SelectedIndex switch
            {
                0 => null, // Tất cả
                1 => "submitted", // Chờ phản hồi
                2 => "reviewed", // Đã phản hồi
                _ => null
            };

            await LoadReportsAsync(status);
        }

        private void DgvReports_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count > 0)
            {
                var report = dgvReports.SelectedRows[0].DataBoundItem as StudentReport;
                if (report != null)
                {
                    lblReportTitle.Text = $"📝 {report.Title} - {report.StudentName} ({report.StudentCode})";
                    txtReportContent.Text = report.Content;
                    txtLecturerComment.Text = report.LecturerComment ?? "";

                    btnSubmitReview.Enabled = true;
                }
            }
            else
            {
                lblReportTitle.Text = "Chọn báo cáo để xem chi tiết";
                txtReportContent.Text = "";
                txtLecturerComment.Text = "";
                btnSubmitReview.Enabled = false;
            }
        }

        private async void BtnSubmitReview_Click(object? sender, EventArgs e)
        {
            if (dgvReports.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn báo cáo cần phản hồi", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var report = dgvReports.SelectedRows[0].DataBoundItem as StudentReport;
            if (report == null) return;

            string comment = txtLecturerComment.Text.Trim();
            if (string.IsNullOrEmpty(comment))
            {
                MessageBox.Show("Vui lòng nhập nội dung phản hồi", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (success, message) = await _lecturerService.ReviewReportAsync(report.Id!, comment);

            if (success)
            {
                MessageBox.Show("Gửi phản hồi thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadReportsAsync();
            }
            else
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Grading Tab

        private async Task LoadGradingsAsync()
        {
            var (success, message, gradings) = await _lecturerService.GetStudentGradingsAsync();

            if (success)
            {
                _allGradings = gradings;
                dgvGrading.DataSource = null;
                dgvGrading.DataSource = gradings;

                // Configure columns
                if (dgvGrading.Columns.Count > 0)
                {
                    dgvGrading.Columns["Id"]!.Visible = false;
                    dgvGrading.Columns["StudentId"]!.Visible = false;
                    dgvGrading.Columns["StudentCode"]!.HeaderText = "Mã SV";
                    dgvGrading.Columns["StudentName"]!.HeaderText = "Họ tên";
                    dgvGrading.Columns["TopicTitle"]!.HeaderText = "Đề tài";
                    dgvGrading.Columns["ProcessScore"]!.HeaderText = "Quá trình";
                    dgvGrading.Columns["ReportScore"]!.HeaderText = "Báo cáo";
                    dgvGrading.Columns["DefenseScore"]!.HeaderText = "Bảo vệ";
                    dgvGrading.Columns["FinalScore"]!.HeaderText = "Tổng kết";
                    dgvGrading.Columns["Comment"]!.HeaderText = "Nhận xét";
                    dgvGrading.Columns["GradedAt"]!.HeaderText = "Ngày chấm";

                    // Make score columns editable
                    dgvGrading.Columns["ProcessScore"]!.ReadOnly = false;
                    dgvGrading.Columns["ReportScore"]!.ReadOnly = false;
                    dgvGrading.Columns["DefenseScore"]!.ReadOnly = false;
                    dgvGrading.Columns["Comment"]!.ReadOnly = false;
                    dgvGrading.Columns["FinalScore"]!.ReadOnly = true;
                }
            }
            else
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvGrading_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            // Auto-calculate final score when any score is edited
            if (e.RowIndex >= 0)
            {
                var row = dgvGrading.Rows[e.RowIndex];
                var grading = row.DataBoundItem as StudentGrading;

                if (grading != null && grading.ProcessScore.HasValue &&
                    grading.ReportScore.HasValue && grading.DefenseScore.HasValue)
                {
                    grading.FinalScore = grading.ProcessScore.Value * 0.3m +
                                        grading.ReportScore.Value * 0.3m +
                                        grading.DefenseScore.Value * 0.4m;
                    dgvGrading.Refresh();
                }
            }
        }

        private async void BtnSaveGrades_Click(object? sender, EventArgs e)
        {
            if (dgvGrading.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần lưu điểm", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var grading = dgvGrading.SelectedRows[0].DataBoundItem as StudentGrading;
            if (grading == null) return;

            if (!grading.ProcessScore.HasValue || !grading.ReportScore.HasValue || !grading.DefenseScore.HasValue)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ điểm Quá trình, Báo cáo, Bảo vệ", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var (success, message) = await _lecturerService.SubmitGradeAsync(
                grading.StudentId,
                grading.ProcessScore.Value,
                grading.ReportScore.Value,
                grading.DefenseScore.Value,
                grading.Comment
            );

            if (success)
            {
                MessageBox.Show("Lưu điểm thành công!", "Thành công",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                await LoadGradingsAsync();
            }
            else
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnExportGrades_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất Excel đang được phát triển", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Defense Tab

        private async Task LoadDefenseSchedulesAsync()
        {
            var (success, message, schedules) = await _lecturerService.GetDefenseSchedulesAsync();

            if (success)
            {
                _allDefenseSchedules = schedules;
                dgvDefenseSchedule.DataSource = null;
                dgvDefenseSchedule.DataSource = schedules;

                // Configure columns
                if (dgvDefenseSchedule.Columns.Count > 0)
                {
                    dgvDefenseSchedule.Columns["Id"]!.Visible = false;
                    dgvDefenseSchedule.Columns["StudentId"]!.Visible = false;
                    dgvDefenseSchedule.Columns["StudentCode"]!.HeaderText = "Mã SV";
                    dgvDefenseSchedule.Columns["StudentName"]!.HeaderText = "Họ tên";
                    dgvDefenseSchedule.Columns["TopicTitle"]!.HeaderText = "Đề tài";
                    dgvDefenseSchedule.Columns["DefenseDate"]!.HeaderText = "Ngày bảo vệ";
                    dgvDefenseSchedule.Columns["Location"]!.HeaderText = "Địa điểm";
                    dgvDefenseSchedule.Columns["Status"]!.HeaderText = "Trạng thái";
                    dgvDefenseSchedule.Columns["Notes"]!.HeaderText = "Ghi chú";
                }

                // Highlight dates on calendar
                HighlightDefenseDates();
            }
            else
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void HighlightDefenseDates()
        {
            calendarDefense.RemoveAllBoldedDates();

            foreach (var schedule in _allDefenseSchedules)
            {
                calendarDefense.AddBoldedDate(schedule.DefenseDate);
            }

            calendarDefense.UpdateBoldedDates();
        }

        private void CalendarDefense_DateSelected(object? sender, DateRangeEventArgs e)
        {
            var selectedDate = e.Start.Date;
            var schedulesOnDate = _allDefenseSchedules
                .Where(s => s.DefenseDate.Date == selectedDate)
                .ToList();

            dgvDefenseSchedule.DataSource = null;
            dgvDefenseSchedule.DataSource = schedulesOnDate;
        }

        private async void BtnCreateDefense_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Chức năng tạo lịch bảo vệ đang được phát triển", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnDeleteDefense_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xóa lịch bảo vệ đang được phát triển", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void BtnExportDefensePDF_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất PDF đang được phát triển", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Statistics Tab

        private async Task LoadStatisticsAsync()
        {
            var (success, message, stats) = await _lecturerService.GetStatisticsAsync();

            if (success && stats != null)
            {
                _statistics = stats;
                UpdateStatisticsDisplay();
            }
            else
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatisticsDisplay()
        {
            if (_statistics == null) return;

            // Update labels
            lblTotalStudents.Text = $"👥 Tổng SV: {_statistics.TotalStudents}";
            lblCompletedStudents.Text = $"✅ Hoàn thành: {_statistics.CompletedStudents}";
            lblPendingReports.Text = $"⏳ BC chờ duyệt: {_statistics.PendingReports}";
            lblAverageScore.Text = $"📊 Điểm TB: {_statistics.AverageScore:F2}";

            // Update chart based on filter
            UpdateChart();
        }

        private void UpdateChart()
        {
            if (_statistics == null || chartStatistics == null) return;

            try
            {
                chartStatistics.Series.Clear();
                chartStatistics.Titles.Clear();
                chartStatistics.ChartAreas.Clear();

                // Add ChartArea
                var chartArea = new ChartArea();
                chartStatistics.ChartAreas.Add(chartArea);

                int filterIndex = cboStatsFilter.SelectedIndex;

                if (filterIndex == 0) // Tổng quan
                {
                    chartStatistics.Titles.Add("Thống kê tổng quan");

                    var series = new Series("Tổng quan")
                    {
                        ChartType = SeriesChartType.Column,
                        Color = Color.FromArgb(0, 84, 166)
                    };

                    series.Points.AddXY("Tổng SV", _statistics.TotalStudents);
                    series.Points.AddXY("Hoàn thành", _statistics.CompletedStudents);
                    series.Points.AddXY("Đang TT", _statistics.InProgressStudents);
                    series.Points.AddXY("BC chờ", _statistics.PendingReports);

                    chartStatistics.Series.Add(series);
                }
                else if (filterIndex == 1) // Theo doanh nghiệp
                {
                    chartStatistics.Titles.Add("Thống kê theo doanh nghiệp");

                    var series = new Series("Doanh nghiệp")
                    {
                        ChartType = SeriesChartType.Pie
                    };

                    foreach (var company in _statistics.StudentsByCompany)
                    {
                        series.Points.AddXY(company.Key, company.Value);
                    }

                    chartStatistics.Series.Add(series);
                }
                else if (filterIndex == 2) // Theo đề tài
                {
                    chartStatistics.Titles.Add("Thống kê theo đề tài");

                    var series = new Series("Đề tài")
                    {
                        ChartType = SeriesChartType.Bar,
                        Color = Color.FromArgb(243, 111, 33)
                    };

                    foreach (var topic in _statistics.StudentsByTopic)
                    {
                        series.Points.AddXY(topic.Key, topic.Value);
                    }

                    chartStatistics.Series.Add(series);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải biểu đồ thống kê: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CboStatsFilter_SelectedIndexChanged(object? sender, EventArgs e)
        {
            UpdateChart();
        }

        private void BtnExportStats_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Chức năng xuất Excel đang được phát triển", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion
    }
}

