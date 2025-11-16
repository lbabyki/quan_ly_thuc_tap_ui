using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using MyWinFormsApp.Business.Models;
using MyWinFormsApp.Business.Services;
using MyWinFormsApp.UI.Services;

namespace MyWinFormsApp.UI.Forms
{
    public partial class CompanyForm : Form
    {
        private readonly CompanyService _companyService;
        private readonly bool _useMockData = true; // Toggle để test

        private List<StudentConfirmation> _confirmations = new List<StudentConfirmation>();
        private List<StudentEvaluation> _evaluations = new List<StudentEvaluation>();
        private List<CompanyReport> _reports = new List<CompanyReport>();
        private List<InternshipTopic> _topics = new List<InternshipTopic>();

        private StudentEvaluation? _selectedEvaluation = null;
        private List<string> _attachments = new List<string>();

        public CompanyForm()
        {
            try
            {
                InitializeComponent();

                // Force TabControl to be visible
                if (tabControl != null)
                {
                    tabControl.Visible = true;
                    tabControl.BringToFront();
                }

                // Initialize service with mock data
                if (_useMockData)
                {
                    var mockDataProvider = new CompanyMockDataProvider();
                    _companyService = new CompanyService(null, true, mockDataProvider);
                }
                else
                {
                    _companyService = new CompanyService(); // API mode
                }

                // Set default values
                if (cboConfirmStatusFilter != null && cboConfirmStatusFilter.Items.Count > 0)
                {
                    cboConfirmStatusFilter.SelectedIndex = 0;
                }

                // Wire up event handlers
                WireUpEventHandlers();

                // Load data when form is shown
                this.Shown += CompanyForm_Shown;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi khởi tạo CompanyForm:\n\nMessage: {ex.Message}\n\nStackTrace:\n{ex.StackTrace}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void CompanyForm_Shown(object? sender, EventArgs e)
        {
            await LoadAllDataAsync();
        }

        private void WireUpEventHandlers()
        {
            try
            {
                // Tab Confirmations
                if (cboConfirmStatusFilter != null)
                    cboConfirmStatusFilter.SelectedIndexChanged += async (s, e) => await LoadConfirmationsAsync();
                if (btnRefreshConfirmations != null)
                    btnRefreshConfirmations.Click += async (s, e) => await LoadConfirmationsAsync();
                if (dgvConfirmations != null)
                    dgvConfirmations.CellContentClick += DgvConfirmations_CellContentClick;

                // Tab Evaluations
                if (dgvEvaluations != null)
                    dgvEvaluations.SelectionChanged += DgvEvaluations_SelectionChanged;
                if (numAttendance != null)
                    numAttendance.ValueChanged += CalculateTotalScore;
                if (numAttitude != null)
                    numAttitude.ValueChanged += CalculateTotalScore;
                if (numSkill != null)
                    numSkill.ValueChanged += CalculateTotalScore;
                if (numResult != null)
                    numResult.ValueChanged += CalculateTotalScore;
                if (btnSubmitEvaluation != null)
                    btnSubmitEvaluation.Click += async (s, e) => await SubmitEvaluationAsync();
                if (btnCancelEvaluation != null)
                    btnCancelEvaluation.Click += (s, e) => ClearEvaluationForm();

                // Tab Reports
                if (btnAddAttachment != null)
                    btnAddAttachment.Click += BtnAddAttachment_Click;
                if (btnRemoveAttachment != null)
                    btnRemoveAttachment.Click += BtnRemoveAttachment_Click;
                if (btnSubmitReport != null)
                    btnSubmitReport.Click += async (s, e) => await SubmitReportAsync();

                // Tab Topics
                if (btnAddTopic != null)
                    btnAddTopic.Click += async (s, e) => await ShowTopicDialogAsync(null);
                if (btnEditTopic != null)
                    btnEditTopic.Click += async (s, e) => await ShowTopicDialogAsync(GetSelectedTopic());
                if (btnDeleteTopic != null)
                    btnDeleteTopic.Click += async (s, e) => await DeleteTopicAsync();
                if (btnRefreshTopics != null)
                    btnRefreshTopics.Click += async (s, e) => await LoadTopicsAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi wire up event handlers:\n\nMessage: {ex.Message}\n\nStackTrace:\n{ex.StackTrace}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task LoadAllDataAsync()
        {
            try
            {
                await Task.WhenAll(
                    LoadConfirmationsAsync(),
                    LoadEvaluationsAsync(),
                    LoadReportsAsync(),
                    LoadTopicsAsync()
                );
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải dữ liệu:\n\nMessage: {ex.Message}\n\nStackTrace:\n{ex.StackTrace}",
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region Tab Confirmations

        private async Task LoadConfirmationsAsync()
        {
            try
            {
                if (cboConfirmStatusFilter == null || dgvConfirmations == null)
                {
                    return;
                }

                string? status = cboConfirmStatusFilter.SelectedIndex switch
                {
                    0 => null, // Tất cả
                    1 => "pending",
                    2 => "confirmed",
                    3 => "rejected",
                    _ => null
                };

                var (success, message, data) = await _companyService.GetStudentConfirmationsAsync(status);

                if (success)
                {
                    _confirmations = data;

                    // Force visible and bring to front
                    dgvConfirmations.Visible = true;
                    dgvConfirmations.BringToFront();

                    // Bind data
                    dgvConfirmations.AutoGenerateColumns = true;
                    dgvConfirmations.DataSource = null;
                    dgvConfirmations.DataSource = _confirmations;
                    dgvConfirmations.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

                    // Configure columns
                    if (dgvConfirmations.Columns.Count > 0)
                    {
                        if (dgvConfirmations.Columns.Contains("Id"))
                            dgvConfirmations.Columns["Id"]!.Visible = false;
                        if (dgvConfirmations.Columns.Contains("StudentId"))
                            dgvConfirmations.Columns["StudentId"]!.Visible = false;
                        if (dgvConfirmations.Columns.Contains("StudentCode"))
                            dgvConfirmations.Columns["StudentCode"]!.HeaderText = "Mã SV";
                        if (dgvConfirmations.Columns.Contains("StudentName"))
                            dgvConfirmations.Columns["StudentName"]!.HeaderText = "Họ tên";
                        if (dgvConfirmations.Columns.Contains("Email"))
                            dgvConfirmations.Columns["Email"]!.HeaderText = "Email";
                        if (dgvConfirmations.Columns.Contains("Phone"))
                            dgvConfirmations.Columns["Phone"]!.HeaderText = "SĐT";
                        if (dgvConfirmations.Columns.Contains("TopicTitle"))
                            dgvConfirmations.Columns["TopicTitle"]!.HeaderText = "Đề tài";
                        if (dgvConfirmations.Columns.Contains("Supervisor"))
                            dgvConfirmations.Columns["Supervisor"]!.HeaderText = "Người hướng dẫn";
                        if (dgvConfirmations.Columns.Contains("Status"))
                            dgvConfirmations.Columns["Status"]!.HeaderText = "Trạng thái";
                        if (dgvConfirmations.Columns.Contains("RequestedAt"))
                            dgvConfirmations.Columns["RequestedAt"]!.HeaderText = "Ngày yêu cầu";
                        if (dgvConfirmations.Columns.Contains("ConfirmedAt"))
                            dgvConfirmations.Columns["ConfirmedAt"]!.HeaderText = "Ngày xác nhận";
                        if (dgvConfirmations.Columns.Contains("Notes"))
                            dgvConfirmations.Columns["Notes"]!.HeaderText = "Ghi chú";

                        // Add button column if not exists
                        if (!dgvConfirmations.Columns.Contains("btnConfirm"))
                        {
                            var btnColumn = new DataGridViewButtonColumn
                            {
                                Name = "btnConfirm",
                                HeaderText = "Hành động",
                                Text = "Xác nhận",
                                UseColumnTextForButtonValue = true,
                                Width = 100
                            };
                            dgvConfirmations.Columns.Add(btnColumn);
                        }
                    }

                    // Force refresh and update
                    dgvConfirmations.Refresh();
                    dgvConfirmations.Update();
                    this.Refresh();
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvConfirmations_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            if (dgvConfirmations.Columns[e.ColumnIndex].Name == "btnConfirm")
            {
                var confirmation = _confirmations[e.RowIndex];

                if (confirmation.Status != "pending")
                {
                    MessageBox.Show("Sinh viên đã được xác nhận trước đó", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Show dialog to confirm
                var dialog = new ConfirmStudentDialog(confirmation);
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _ = LoadConfirmationsAsync();
                }
            }
        }

        #endregion

        #region Tab Evaluations

        private async Task LoadEvaluationsAsync()
        {
            try
            {
                if (dgvEvaluations == null)
                {
                    return;
                }

                var (success, message, data) = await _companyService.GetStudentEvaluationsAsync();

                if (success)
                {
                    _evaluations = data;
                    dgvEvaluations.DataSource = null;
                    dgvEvaluations.DataSource = _evaluations;

                    // Configure columns
                    if (dgvEvaluations.Columns.Count > 0)
                    {
                        if (dgvEvaluations.Columns.Contains("Id"))
                            dgvEvaluations.Columns["Id"]!.Visible = false;
                        if (dgvEvaluations.Columns.Contains("StudentId"))
                            dgvEvaluations.Columns["StudentId"]!.Visible = false;
                        if (dgvEvaluations.Columns.Contains("StudentCode"))
                            dgvEvaluations.Columns["StudentCode"]!.HeaderText = "Mã SV";
                        if (dgvEvaluations.Columns.Contains("StudentName"))
                            dgvEvaluations.Columns["StudentName"]!.HeaderText = "Họ tên";
                        if (dgvEvaluations.Columns.Contains("TopicTitle"))
                            dgvEvaluations.Columns["TopicTitle"]!.HeaderText = "Đề tài";
                        if (dgvEvaluations.Columns.Contains("AttendanceScore"))
                            dgvEvaluations.Columns["AttendanceScore"]!.HeaderText = "Chuyên cần";
                        if (dgvEvaluations.Columns.Contains("AttitudeScore"))
                            dgvEvaluations.Columns["AttitudeScore"]!.HeaderText = "Thái độ";
                        if (dgvEvaluations.Columns.Contains("SkillScore"))
                            dgvEvaluations.Columns["SkillScore"]!.HeaderText = "Kỹ năng";
                        if (dgvEvaluations.Columns.Contains("ResultScore"))
                            dgvEvaluations.Columns["ResultScore"]!.HeaderText = "Kết quả";
                        if (dgvEvaluations.Columns.Contains("TotalScore"))
                            dgvEvaluations.Columns["TotalScore"]!.HeaderText = "Tổng điểm";
                        if (dgvEvaluations.Columns.Contains("Comment"))
                            dgvEvaluations.Columns["Comment"]!.HeaderText = "Nhận xét";
                        if (dgvEvaluations.Columns.Contains("Status"))
                            dgvEvaluations.Columns["Status"]!.HeaderText = "Trạng thái";
                        if (dgvEvaluations.Columns.Contains("EvaluatedAt"))
                            dgvEvaluations.Columns["EvaluatedAt"]!.HeaderText = "Ngày đánh giá";
                    }
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DgvEvaluations_SelectionChanged(object? sender, EventArgs e)
        {
            if (dgvEvaluations.SelectedRows.Count > 0)
            {
                _selectedEvaluation = dgvEvaluations.SelectedRows[0].DataBoundItem as StudentEvaluation;
                if (_selectedEvaluation != null)
                {
                    LoadEvaluationToForm(_selectedEvaluation);
                }
            }
        }

        private void LoadEvaluationToForm(StudentEvaluation evaluation)
        {
            txtStudentName.Text = $"{evaluation.StudentCode} - {evaluation.StudentName}";
            numAttendance.Value = evaluation.AttendanceScore ?? 0;
            numAttitude.Value = evaluation.AttitudeScore ?? 0;
            numSkill.Value = evaluation.SkillScore ?? 0;
            numResult.Value = evaluation.ResultScore ?? 0;
            rtbComment.Text = evaluation.Comment ?? "";
            CalculateTotalScore(null, EventArgs.Empty);
        }

        private void CalculateTotalScore(object? sender, EventArgs e)
        {
            decimal total = (numAttendance.Value + numAttitude.Value + numSkill.Value + numResult.Value) / 4;
            txtTotal.Text = total.ToString("F2");
        }

        private async Task SubmitEvaluationAsync()
        {
            if (_selectedEvaluation == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên để đánh giá", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn gửi đánh giá này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                var (success, message) = await _companyService.SubmitEvaluationAsync(
                    _selectedEvaluation.StudentId,
                    numAttendance.Value,
                    numAttitude.Value,
                    numSkill.Value,
                    numResult.Value,
                    rtbComment.Text
                );

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadEvaluationsAsync();
                    ClearEvaluationForm();
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

        private void ClearEvaluationForm()
        {
            _selectedEvaluation = null;
            txtStudentName.Clear();
            numAttendance.Value = 0;
            numAttitude.Value = 0;
            numSkill.Value = 0;
            numResult.Value = 0;
            txtTotal.Clear();
            rtbComment.Clear();
        }

        #endregion

        #region Tab Reports

        private async Task LoadReportsAsync()
        {
            try
            {
                if (dgvReports == null)
                {
                    return;
                }

                var (success, message, data) = await _companyService.GetReportsAsync();

                if (success)
                {
                    _reports = data;
                    dgvReports.DataSource = null;
                    dgvReports.DataSource = _reports;

                    // Configure columns
                    if (dgvReports.Columns.Count > 0)
                    {
                        if (dgvReports.Columns.Contains("Id"))
                            dgvReports.Columns["Id"]!.Visible = false;
                        if (dgvReports.Columns.Contains("CompanyId"))
                            dgvReports.Columns["CompanyId"]!.Visible = false;
                        if (dgvReports.Columns.Contains("Title"))
                            dgvReports.Columns["Title"]!.HeaderText = "Tiêu đề";
                        if (dgvReports.Columns.Contains("Content"))
                            dgvReports.Columns["Content"]!.Visible = false;
                        if (dgvReports.Columns.Contains("Period"))
                            dgvReports.Columns["Period"]!.HeaderText = "Kỳ";
                        if (dgvReports.Columns.Contains("TotalStudents"))
                            dgvReports.Columns["TotalStudents"]!.HeaderText = "Tổng SV";
                        if (dgvReports.Columns.Contains("CompletedStudents"))
                            dgvReports.Columns["CompletedStudents"]!.HeaderText = "SV hoàn thành";
                        if (dgvReports.Columns.Contains("Attachments"))
                            dgvReports.Columns["Attachments"]!.Visible = false;
                        if (dgvReports.Columns.Contains("Status"))
                            dgvReports.Columns["Status"]!.HeaderText = "Trạng thái";
                        if (dgvReports.Columns.Contains("CreatedAt"))
                            dgvReports.Columns["CreatedAt"]!.HeaderText = "Ngày tạo";
                        if (dgvReports.Columns.Contains("SubmittedAt"))
                            dgvReports.Columns["SubmittedAt"]!.HeaderText = "Ngày gửi";
                    }
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnAddAttachment_Click(object? sender, EventArgs e)
        {
            using (var openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "All files (*.*)|*.*";
                openFileDialog.Multiselect = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (var fileName in openFileDialog.FileNames)
                    {
                        _attachments.Add(fileName);
                        var item = new ListViewItem(System.IO.Path.GetFileName(fileName));
                        item.Tag = fileName;
                        lvAttachments.Items.Add(item);
                    }
                }
            }
        }

        private void BtnRemoveAttachment_Click(object? sender, EventArgs e)
        {
            if (lvAttachments.SelectedItems.Count > 0)
            {
                var item = lvAttachments.SelectedItems[0];
                _attachments.Remove(item.Tag?.ToString() ?? "");
                lvAttachments.Items.Remove(item);
            }
        }

        private async Task SubmitReportAsync()
        {
            if (string.IsNullOrWhiteSpace(txtReportTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(rtbReportContent.Text))
            {
                MessageBox.Show("Vui lòng nhập nội dung báo cáo", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show("Bạn có chắc chắn muốn gửi báo cáo này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                var (success, message) = await _companyService.SubmitReportAsync(
                    txtReportTitle.Text,
                    rtbReportContent.Text,
                    txtPeriod.Text,
                    (int)numTotalStudents.Value,
                    (int)numCompletedStudents.Value,
                    _attachments
                );

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadReportsAsync();
                    ClearReportForm();
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

        private void ClearReportForm()
        {
            txtReportTitle.Clear();
            rtbReportContent.Clear();
            txtPeriod.Clear();
            numTotalStudents.Value = 0;
            numCompletedStudents.Value = 0;
            _attachments.Clear();
            lvAttachments.Items.Clear();
        }

        #endregion

        #region Tab Topics

        private async Task LoadTopicsAsync()
        {
            try
            {
                if (dgvTopics == null)
                {
                    return;
                }

                var (success, message, data) = await _companyService.GetTopicsAsync();

                if (success)
                {
                    _topics = data;
                    dgvTopics.DataSource = null;
                    dgvTopics.DataSource = _topics;

                    // Configure columns
                    if (dgvTopics.Columns.Count > 0)
                    {
                        if (dgvTopics.Columns.Contains("Id"))
                            dgvTopics.Columns["Id"]!.Visible = false;
                        if (dgvTopics.Columns.Contains("CompanyId"))
                            dgvTopics.Columns["CompanyId"]!.Visible = false;
                        if (dgvTopics.Columns.Contains("Title"))
                            dgvTopics.Columns["Title"]!.HeaderText = "Tiêu đề";
                        if (dgvTopics.Columns.Contains("Description"))
                            dgvTopics.Columns["Description"]!.HeaderText = "Mô tả";
                        if (dgvTopics.Columns.Contains("Requirements"))
                            dgvTopics.Columns["Requirements"]!.HeaderText = "Yêu cầu";
                        if (dgvTopics.Columns.Contains("MaxStudents"))
                            dgvTopics.Columns["MaxStudents"]!.HeaderText = "SL tối đa";
                        if (dgvTopics.Columns.Contains("CurrentStudents"))
                            dgvTopics.Columns["CurrentStudents"]!.HeaderText = "SL hiện tại";
                        if (dgvTopics.Columns.Contains("Duration"))
                            dgvTopics.Columns["Duration"]!.HeaderText = "Thời gian";
                        if (dgvTopics.Columns.Contains("Location"))
                            dgvTopics.Columns["Location"]!.HeaderText = "Địa điểm";
                        if (dgvTopics.Columns.Contains("Supervisor"))
                            dgvTopics.Columns["Supervisor"]!.HeaderText = "Người hướng dẫn";
                        if (dgvTopics.Columns.Contains("Status"))
                            dgvTopics.Columns["Status"]!.HeaderText = "Trạng thái";
                        if (dgvTopics.Columns.Contains("CreatedAt"))
                            dgvTopics.Columns["CreatedAt"]!.HeaderText = "Ngày tạo";
                        if (dgvTopics.Columns.Contains("UpdatedAt"))
                            dgvTopics.Columns["UpdatedAt"]!.HeaderText = "Ngày cập nhật";
                    }
                }
                else
                {
                    MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private InternshipTopic? GetSelectedTopic()
        {
            if (dgvTopics.SelectedRows.Count > 0)
            {
                return dgvTopics.SelectedRows[0].DataBoundItem as InternshipTopic;
            }
            return null;
        }

        private async Task ShowTopicDialogAsync(InternshipTopic? topic)
        {
            var dialog = new TopicDialog(topic);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                await LoadTopicsAsync();
            }
        }

        private async Task DeleteTopicAsync()
        {
            var topic = GetSelectedTopic();
            if (topic == null)
            {
                MessageBox.Show("Vui lòng chọn đề tài để xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var result = MessageBox.Show($"Bạn có chắc chắn muốn xóa đề tài '{topic.Title}'?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result != DialogResult.Yes) return;

            try
            {
                var (success, message) = await _companyService.DeleteTopicAsync(topic.Id!);

                if (success)
                {
                    MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    await LoadTopicsAsync();
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

        #endregion
    }

    #region Helper Dialogs

    // Simple dialog for confirming student
    public class ConfirmStudentDialog : Form
    {
        private readonly StudentConfirmation _confirmation;
        private TextBox txtSupervisor;
        private TextBox txtNotes;
        private Button btnConfirm;
        private Button btnReject;
        private Button btnCancel;

        public ConfirmStudentDialog(StudentConfirmation confirmation)
        {
            _confirmation = confirmation;
            InitializeDialog();
        }

        private void InitializeDialog()
        {
            this.Text = "Xác nhận sinh viên";
            this.Size = new Size(500, 300);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var lblInfo = new Label
            {
                Text = $"Sinh viên: {_confirmation.StudentCode} - {_confirmation.StudentName}\nĐề tài: {_confirmation.TopicTitle}",
                Location = new Point(20, 20),
                Size = new Size(450, 60),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };

            var lblSupervisor = new Label
            {
                Text = "Người hướng dẫn:",
                Location = new Point(20, 90),
                Size = new Size(150, 25)
            };

            txtSupervisor = new TextBox
            {
                Location = new Point(180, 88),
                Size = new Size(290, 25)
            };

            var lblNotes = new Label
            {
                Text = "Ghi chú:",
                Location = new Point(20, 125),
                Size = new Size(150, 25)
            };

            txtNotes = new TextBox
            {
                Location = new Point(180, 123),
                Size = new Size(290, 60),
                Multiline = true
            };

            btnConfirm = new Button
            {
                Text = "Xác nhận",
                Location = new Point(120, 210),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(0, 84, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnConfirm.Click += async (s, e) => await ConfirmAsync("confirmed");

            btnReject = new Button
            {
                Text = "Từ chối",
                Location = new Point(230, 210),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnReject.Click += async (s, e) => await ConfirmAsync("rejected");

            btnCancel = new Button
            {
                Text = "Hủy",
                Location = new Point(340, 210),
                Size = new Size(100, 35),
                DialogResult = DialogResult.Cancel
            };

            this.Controls.AddRange(new Control[] { lblInfo, lblSupervisor, txtSupervisor, lblNotes, txtNotes, btnConfirm, btnReject, btnCancel });
        }

        private async Task ConfirmAsync(string status)
        {
            var mockProvider = new CompanyMockDataProvider();
            var service = new CompanyService(null, true, mockProvider);

            var (success, message) = await Task.FromResult(service.ConfirmStudentAsync(_confirmation.StudentId, status, txtSupervisor.Text, txtNotes.Text).Result);

            if (success)
            {
                MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // Simple dialog for topic
    public class TopicDialog : Form
    {
        private readonly InternshipTopic? _topic;
        private TextBox txtTitle;
        private TextBox txtDescription;
        private TextBox txtRequirements;
        private NumericUpDown numMaxStudents;
        private TextBox txtDuration;
        private TextBox txtLocation;
        private TextBox txtSupervisor;
        private Button btnSave;
        private Button btnCancel;

        public TopicDialog(InternshipTopic? topic)
        {
            _topic = topic;
            InitializeDialog();
        }

        private void InitializeDialog()
        {
            this.Text = _topic == null ? "Thêm đề tài" : "Sửa đề tài";
            this.Size = new Size(600, 500);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            int y = 20;

            AddField("Tiêu đề:", ref txtTitle, ref y);
            AddField("Mô tả:", ref txtDescription, ref y, true);
            AddField("Yêu cầu:", ref txtRequirements, ref y, true);

            var lblMaxStudents = new Label { Text = "Số lượng tối đa:", Location = new Point(20, y), Size = new Size(150, 25) };
            numMaxStudents = new NumericUpDown { Location = new Point(180, y), Size = new Size(390, 25), Minimum = 1, Maximum = 10, Value = 1 };
            this.Controls.AddRange(new Control[] { lblMaxStudents, numMaxStudents });
            y += 35;

            AddField("Thời gian:", ref txtDuration, ref y);
            AddField("Địa điểm:", ref txtLocation, ref y);
            AddField("Người hướng dẫn:", ref txtSupervisor, ref y);

            btnSave = new Button
            {
                Text = "Lưu",
                Location = new Point(350, y + 20),
                Size = new Size(100, 35),
                BackColor = Color.FromArgb(0, 84, 166),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.Click += async (s, e) => await SaveAsync();

            btnCancel = new Button
            {
                Text = "Hủy",
                Location = new Point(460, y + 20),
                Size = new Size(100, 35),
                DialogResult = DialogResult.Cancel
            };

            this.Controls.AddRange(new Control[] { btnSave, btnCancel });

            if (_topic != null)
            {
                txtTitle.Text = _topic.Title;
                txtDescription.Text = _topic.Description;
                txtRequirements.Text = _topic.Requirements;
                numMaxStudents.Value = _topic.MaxStudents;
                txtDuration.Text = _topic.Duration;
                txtLocation.Text = _topic.Location;
                txtSupervisor.Text = _topic.Supervisor;
            }
        }

        private void AddField(string label, ref TextBox textBox, ref int y, bool multiline = false)
        {
            var lbl = new Label { Text = label, Location = new Point(20, y), Size = new Size(150, 25) };
            textBox = new TextBox
            {
                Location = new Point(180, y),
                Size = new Size(390, multiline ? 60 : 25),
                Multiline = multiline
            };
            this.Controls.AddRange(new Control[] { lbl, textBox });
            y += multiline ? 70 : 35;
        }

        private async Task SaveAsync()
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Vui lòng nhập tiêu đề", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var mockProvider = new CompanyMockDataProvider();
            var service = new CompanyService(null, true, mockProvider);

            bool success;
            string message;

            if (_topic == null)
            {
                (success, message) = await service.CreateTopicAsync(
                    txtTitle.Text,
                    txtDescription.Text,
                    txtRequirements.Text,
                    (int)numMaxStudents.Value,
                    txtDuration.Text,
                    txtLocation.Text,
                    txtSupervisor.Text
                );
            }
            else
            {
                (success, message) = await service.UpdateTopicAsync(
                    _topic.Id!,
                    txtTitle.Text,
                    txtDescription.Text,
                    txtRequirements.Text,
                    (int)numMaxStudents.Value,
                    txtDuration.Text,
                    txtLocation.Text,
                    txtSupervisor.Text
                );
            }

            if (success)
            {
                MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    #endregion
}

