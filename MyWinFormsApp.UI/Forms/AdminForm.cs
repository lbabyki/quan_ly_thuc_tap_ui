using MyWinFormsApp.Business.Models;
using MyWinFormsApp.Business.Services;
using MyWinFormsApp.MockData;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace MyWinFormsApp.Forms
{
    /// <summary>
    /// Form quản trị hệ thống cho Admin
    /// </summary>
    public partial class AdminForm : Form
    {
        private readonly AdminService _adminService;
        private readonly bool _useMockData = true; // Toggle Mock Data / API

        // Colors
        private readonly Color LHU_BLUE = ColorTranslator.FromHtml("#0054A6");
        private readonly Color LHU_ORANGE = ColorTranslator.FromHtml("#F36F21");
        private readonly Color SIDEBAR_BG = ColorTranslator.FromHtml("#1E3A5F");
        private readonly Color SIDEBAR_HOVER = ColorTranslator.FromHtml("#2C5282");
        private readonly Color SIDEBAR_ACTIVE = ColorTranslator.FromHtml("#F36F21");

        // Current data
        private List<User> _currentUsers = new List<User>();
        private List<InternshipTopic> _currentTopics = new List<InternshipTopic>();
        private List<SystemLog> _currentLogs = new List<SystemLog>();
        private Statistics? _currentStats;

        // Current active menu button
        private Button? _activeMenuButton;

        public AdminForm()
        {
            InitializeComponent();
            _adminService = new AdminService();

            SetupSidebar();
            SetupColors();
            SetupDataGridViews();
            SetupListView();
            SetupChart();

            // Show Users panel by default
            ShowPanel(panelUsersContent);
            _activeMenuButton = btnMenuUsers;
            SetActiveMenuButton(btnMenuUsers);

            LoadAllData();
        }

        private void SetupSidebar()
        {
            // Setup sidebar panel
            panelSidebar.BackColor = SIDEBAR_BG;

            // Setup menu buttons
            SetupMenuButton(btnMenuUsers, "👥 Quản lý người dùng");
            SetupMenuButton(btnMenuTopics, "📋 Đề tài thực tập");
            SetupMenuButton(btnMenuLogs, "📊 Nhật ký hệ thống");
            SetupMenuButton(btnMenuStats, "📈 Thống kê");

            // Add click events
            btnMenuUsers.Click += (s, e) => { ShowPanel(panelUsersContent); SetActiveMenuButton(btnMenuUsers); };
            btnMenuTopics.Click += (s, e) => { ShowPanel(panelTopicsContent); SetActiveMenuButton(btnMenuTopics); };
            btnMenuLogs.Click += (s, e) => { ShowPanel(panelLogsContent); SetActiveMenuButton(btnMenuLogs); };
            btnMenuStats.Click += (s, e) => { ShowPanel(panelStatsContent); SetActiveMenuButton(btnMenuStats); };
        }

        private void SetupMenuButton(Button btn, string text)
        {
            btn.Text = text;
            btn.BackColor = SIDEBAR_BG;
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(20, 0, 0, 0);
            btn.Cursor = Cursors.Hand;

            // Hover effect
            btn.MouseEnter += (s, e) => {
                if (btn != _activeMenuButton)
                    btn.BackColor = SIDEBAR_HOVER;
            };
            btn.MouseLeave += (s, e) => {
                if (btn != _activeMenuButton)
                    btn.BackColor = SIDEBAR_BG;
            };
        }

        private void SetActiveMenuButton(Button btn)
        {
            // Reset previous active button
            if (_activeMenuButton != null)
            {
                _activeMenuButton.BackColor = SIDEBAR_BG;
                _activeMenuButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            }

            // Set new active button
            _activeMenuButton = btn;
            btn.BackColor = SIDEBAR_ACTIVE;
            btn.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
        }

        private void ShowPanel(Panel panel)
        {
            // Hide all content panels
            panelUsersContent.Visible = false;
            panelTopicsContent.Visible = false;
            panelLogsContent.Visible = false;
            panelStatsContent.Visible = false;

            // Show selected panel
            panel.Visible = true;
            panel.BringToFront();
        }

        private void SetupColors()
        {
            this.BackColor = Color.WhiteSmoke;

            // Buttons in content panels
            foreach (Control control in this.Controls)
            {
                SetButtonColors(control);
            }
        }

        private void SetButtonColors(Control parent)
        {
            foreach (Control control in parent.Controls)
            {
                if (control is Button btn && !btn.Name.StartsWith("btnMenu"))
                {
                    btn.BackColor = LHU_ORANGE;
                    btn.ForeColor = Color.White;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                    btn.Cursor = Cursors.Hand;
                }
                else if (control.HasChildren)
                {
                    SetButtonColors(control);
                }
            }
        }

        private void SetupDataGridViews()
        {
            // Setup DataGridView cho Users
            SetupUserDataGridView(dgvStudents);
            SetupUserDataGridView(dgvLecturers);
            SetupUserDataGridView(dgvCompanies);
            
            // Setup DataGridView cho Topics
            SetupTopicDataGridView(dgvTopics);
        }

        private void SetupUserDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            dgv.Columns.Clear();
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "UserId", HeaderText = "ID", Width = 80 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Email", HeaderText = "Email", Width = 200 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "FullName", HeaderText = "Họ tên", Width = 180 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Phone", HeaderText = "Điện thoại", Width = 120 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Role", HeaderText = "Vai trò", Width = 100 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CreatedAt", HeaderText = "Ngày tạo", Width = 120 });
            
            // Style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = LHU_BLUE;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        private void SetupTopicDataGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.MultiSelect = false;
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.RowHeadersVisible = false;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            
            dgv.Columns.Clear();
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Id", HeaderText = "ID", Width = 80 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Title", HeaderText = "Tiêu đề", Width = 250 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "CompanyName", HeaderText = "Công ty", Width = 180 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Trạng thái", Width = 100 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "MaxStudents", HeaderText = "SL tối đa", Width = 80 });
            dgv.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Deadline", HeaderText = "Hạn đăng ký", Width = 120 });
            
            // Style
            dgv.ColumnHeadersDefaultCellStyle.BackColor = LHU_BLUE;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        private void SetupListView()
        {
            lvLogs.View = View.Details;
            lvLogs.FullRowSelect = true;
            lvLogs.GridLines = true;
            lvLogs.BackColor = Color.White;

            lvLogs.Columns.Clear();
            lvLogs.Columns.Add("Thời gian", 150);
            lvLogs.Columns.Add("Người dùng", 150);
            lvLogs.Columns.Add("Hành động", 300);
            lvLogs.Columns.Add("IP Address", 120);
        }

        private void SetupChart()
        {
            // Chart sẽ được setup trong LoadStatistics
        }

        private async void LoadAllData()
        {
            await LoadUsers();
            await LoadTopics();
            await LoadLogs();
            await LoadStatistics();
        }

        #region User Management

        private async System.Threading.Tasks.Task LoadUsers()
        {
            try
            {
                if (_useMockData)
                {
                    _currentUsers = AdminMockData.GetAllUsers();
                    UpdateUserDataGridViews();
                }
                else
                {
                    var (success, message, users) = await _adminService.GetAllUsersAsync();
                    if (success && users != null)
                    {
                        _currentUsers = users;
                        UpdateUserDataGridViews();
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateUserDataGridViews()
        {
            dgvStudents.DataSource = _currentUsers.Where(u => u.Role == "student").ToList();
            dgvLecturers.DataSource = _currentUsers.Where(u => u.Role == "lecturer").ToList();
            dgvCompanies.DataSource = _currentUsers.Where(u => u.Role == "company").ToList();
        }

        private void btnCreateUser_Click(object sender, EventArgs e)
        {
            // TODO: Open dialog to create user
            MessageBox.Show("Chức năng tạo người dùng sẽ được implement", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            // TODO: Open dialog to edit user
            MessageBox.Show("Chức năng sửa người dùng sẽ được implement", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            var currentTab = tabControl1.SelectedTab;
            DataGridView? currentDgv = null;

            if (currentTab == tabStudents) currentDgv = dgvStudents;
            else if (currentTab == tabLecturers) currentDgv = dgvLecturers;
            else if (currentTab == tabCompanies) currentDgv = dgvCompanies;

            if (currentDgv == null || currentDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng cần xóa", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = currentDgv.SelectedRows[0].DataBoundItem as User;
            if (user == null) return;

            var result = MessageBox.Show($"Bạn có chắc muốn xóa người dùng '{user.FullName}'?",
                "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_useMockData)
                    {
                        var (success, message) = AdminMockData.DeleteUser(user.UserId ?? "");
                        if (success)
                        {
                            MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        var (success, message) = await _adminService.DeleteUserAsync(user.UserId ?? "");
                        if (success)
                        {
                            MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void resetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentTab = tabControl1.SelectedTab;
            DataGridView? currentDgv = null;

            if (currentTab == tabStudents) currentDgv = dgvStudents;
            else if (currentTab == tabLecturers) currentDgv = dgvLecturers;
            else if (currentTab == tabCompanies) currentDgv = dgvCompanies;

            if (currentDgv == null || currentDgv.SelectedRows.Count == 0) return;

            var user = currentDgv.SelectedRows[0].DataBoundItem as User;
            if (user == null) return;

            try
            {
                if (_useMockData)
                {
                    var (success, message) = AdminMockData.ResetPassword(user.UserId ?? "");
                    MessageBox.Show(message, success ? "Thành công" : "Lỗi",
                        MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                }
                else
                {
                    var (success, message) = await _adminService.ResetPasswordAsync(user.UserId ?? "");
                    MessageBox.Show(message, success ? "Thành công" : "Lỗi",
                        MessageBoxButtons.OK, success ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Topic Management

        private async System.Threading.Tasks.Task LoadTopics()
        {
            try
            {
                string? status = cboTopicStatus.SelectedItem?.ToString();
                if (status == "Tất cả") status = null;

                if (_useMockData)
                {
                    _currentTopics = AdminMockData.GetTopics(status);
                    dgvTopics.DataSource = _currentTopics;
                }
                else
                {
                    var (success, message, topics) = await _adminService.GetTopicsAsync(status);
                    if (success && topics != null)
                    {
                        _currentTopics = topics;
                        dgvTopics.DataSource = _currentTopics;
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnApproveTopic_Click(object sender, EventArgs e)
        {
            if (dgvTopics.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đề tài cần duyệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var topic = dgvTopics.SelectedRows[0].DataBoundItem as InternshipTopic;
            if (topic == null) return;

            if (topic.Status == "approved")
            {
                MessageBox.Show("Đề tài đã được duyệt", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                if (_useMockData)
                {
                    var (success, message, _) = AdminMockData.ApproveTopic(topic.Id ?? "");
                    if (success)
                    {
                        MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadTopics();
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    var (success, message, _) = await _adminService.ApproveTopicAsync(topic.Id ?? "");
                    if (success)
                    {
                        MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadTopics();
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnRejectTopic_Click(object sender, EventArgs e)
        {
            if (dgvTopics.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đề tài cần từ chối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var topic = dgvTopics.SelectedRows[0].DataBoundItem as InternshipTopic;
            if (topic == null) return;

            // TODO: Open dialog to input rejection reason
            string reason = Microsoft.VisualBasic.Interaction.InputBox("Nhập lý do từ chối:", "Từ chối đề tài", "");

            if (string.IsNullOrWhiteSpace(reason))
            {
                MessageBox.Show("Vui lòng nhập lý do từ chối", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (_useMockData)
                {
                    var (success, message, _) = AdminMockData.RejectTopic(topic.Id ?? "", reason);
                    if (success)
                    {
                        MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadTopics();
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    var (success, message, _) = await _adminService.RejectTopicAsync(topic.Id ?? "", reason);
                    if (success)
                    {
                        MessageBox.Show(message, "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadTopics();
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void cboTopicStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            await LoadTopics();
        }

        #endregion

        #region System Logs

        private async System.Threading.Tasks.Task LoadLogs()
        {
            try
            {
                if (_useMockData)
                {
                    _currentLogs = AdminMockData.GetSystemLogs(100);
                    UpdateLogsListView();
                }
                else
                {
                    var (success, message, logs) = await _adminService.GetSystemLogsAsync(100);
                    if (success && logs != null)
                    {
                        _currentLogs = logs;
                        UpdateLogsListView();
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateLogsListView()
        {
            lvLogs.Items.Clear();
            foreach (var log in _currentLogs)
            {
                var item = new ListViewItem(log.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss"));
                item.SubItems.Add(log.UserName);
                item.SubItems.Add(log.Action);
                item.SubItems.Add(log.IpAddress);
                lvLogs.Items.Add(item);
            }
        }

        #endregion

        #region Statistics

        private async System.Threading.Tasks.Task LoadStatistics()
        {
            try
            {
                if (_useMockData)
                {
                    _currentStats = AdminMockData.GetStatistics();
                    UpdateStatistics();
                }
                else
                {
                    var (success, message, stats) = await _adminService.GetStatisticsAsync();
                    if (success && stats != null)
                    {
                        _currentStats = stats;
                        UpdateStatistics();
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatistics()
        {
            if (_currentStats == null) return;

            // Update summary panels
            lblTotalStudents.Text = _currentStats.TotalStudents.ToString();
            lblTotalLecturers.Text = _currentStats.TotalLecturers.ToString();
            lblTotalCompanies.Text = _currentStats.TotalCompanies.ToString();
            lblTotalInternships.Text = _currentStats.TotalInternships.ToString();
            lblActiveInternships.Text = _currentStats.ActiveInternships.ToString();
            lblPendingTopics.Text = _currentStats.PendingTopics.ToString();
            lblAverageScore.Text = _currentStats.AverageScore.ToString("F2");

            // Update charts
            UpdateStudentsByCompanyChart();
            UpdateScoresByMajorChart();
        }

        private void UpdateStudentsByCompanyChart()
        {
            if (_currentStats == null || chartStudentsByCompany == null) return;

            chartStudentsByCompany.Series.Clear();
            chartStudentsByCompany.Titles.Clear();

            var series = new Series("Sinh viên theo công ty")
            {
                ChartType = SeriesChartType.Column,
                Color = LHU_ORANGE
            };

            foreach (var item in _currentStats.StudentsByCompany)
            {
                series.Points.AddXY(item.CompanyName, item.StudentCount);
            }

            chartStudentsByCompany.Series.Add(series);
            chartStudentsByCompany.Titles.Add("Số lượng sinh viên theo công ty");

            // Style
            chartStudentsByCompany.ChartAreas[0].AxisX.LabelStyle.Angle = -45;
            chartStudentsByCompany.ChartAreas[0].AxisX.Interval = 1;
            chartStudentsByCompany.ChartAreas[0].BackColor = Color.White;
        }

        private void UpdateScoresByMajorChart()
        {
            if (_currentStats == null || chartScoresByMajor == null) return;

            chartScoresByMajor.Series.Clear();
            chartScoresByMajor.Titles.Clear();

            var series = new Series("Điểm TB theo ngành")
            {
                ChartType = SeriesChartType.Bar,
                Color = LHU_BLUE
            };

            foreach (var item in _currentStats.ScoresByMajor)
            {
                series.Points.AddXY(item.Major, item.AverageScore);
            }

            chartScoresByMajor.Series.Add(series);
            chartScoresByMajor.Titles.Add("Điểm trung bình theo ngành");

            // Style
            chartScoresByMajor.ChartAreas[0].AxisX.Interval = 1;
            chartScoresByMajor.ChartAreas[0].BackColor = Color.White;
        }

        #endregion
    }
}

