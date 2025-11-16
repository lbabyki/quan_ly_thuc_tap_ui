using MyWinFormsApp.Business.Models;
using MyWinFormsApp.Business.Services;
using MyWinFormsApp.MockData;
using MyWinFormsApp.UI.Services;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
        private List<InternshipPeriod> _currentPeriods = new List<InternshipPeriod>();
        private List<Notification> _currentNotifications = new List<Notification>();
        private List<SystemLog> _currentLogs = new List<SystemLog>();
        private Statistics? _currentStats;

        // Current active menu button
        private Button? _activeMenuButton;

        public AdminForm()
        {
            try
            {
                InitializeComponent();
                _adminService = new AdminService();

                SetupSidebar();
                SetupColors();
                SetupDataGridViews();
                SetupListView();
                SetupChart();

                // Show Users panel by default
                if (panelUsersContent != null)
                {
                    ShowPanel(panelUsersContent);
                }

                _activeMenuButton = btnMenuUsers;
                if (btnMenuUsers != null)
                {
                    SetActiveMenuButton(btnMenuUsers);
                }

                LoadAllData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Lỗi khởi tạo AdminForm: {ex.Message}\n\nStack Trace:\n{ex.StackTrace}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
        }

        private void SetupSidebar()
        {
            try
            {
                // Setup sidebar panel
                if (panelSidebar != null)
                {
                    panelSidebar.BackColor = SIDEBAR_BG;
                }

                // Setup menu buttons
                if (btnMenuUsers != null) SetupMenuButton(btnMenuUsers, "👥 Quản lý người dùng");
                if (btnMenuTopics != null) SetupMenuButton(btnMenuTopics, "📋 Đề tài thực tập");
                if (btnMenuPeriods != null) SetupMenuButton(btnMenuPeriods, "📅 Quản lý kỳ thực tập");
                if (btnMenuNotifications != null) SetupMenuButton(btnMenuNotifications, "🔔 Thông báo");
                if (btnMenuLogs != null) SetupMenuButton(btnMenuLogs, "📊 Nhật ký hệ thống");
                if (btnMenuStats != null) SetupMenuButton(btnMenuStats, "📈 Thống kê");

                // Add click events
                if (btnMenuUsers != null) btnMenuUsers.Click += (s, e) => { ShowPanel(panelUsersContent); SetActiveMenuButton(btnMenuUsers); };
                if (btnMenuTopics != null) btnMenuTopics.Click += (s, e) => { ShowPanel(panelTopicsContent); SetActiveMenuButton(btnMenuTopics); };
                if (btnMenuPeriods != null) btnMenuPeriods.Click += (s, e) => { ShowPanel(panelPeriodsContent); SetActiveMenuButton(btnMenuPeriods); };
                if (btnMenuNotifications != null) btnMenuNotifications.Click += (s, e) => { ShowPanel(panelNotificationsContent); SetActiveMenuButton(btnMenuNotifications); };
                if (btnMenuLogs != null) btnMenuLogs.Click += (s, e) => { ShowPanel(panelLogsContent); SetActiveMenuButton(btnMenuLogs); };
                if (btnMenuStats != null) btnMenuStats.Click += (s, e) => { ShowPanel(panelStatsContent); SetActiveMenuButton(btnMenuStats); };
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi SetupSidebar: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupMenuButton(Button? btn, string text)
        {
            if (btn == null) return;

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
            panelPeriodsContent.Visible = false;
            panelNotificationsContent.Visible = false;
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
            await LoadPeriods();
            await LoadNotifications();
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
                    // Load from specific mock data sources
                    dgvStudents.DataSource = StudentMockData.GetAllStudents();
                    dgvLecturers.DataSource = LecturerMockData.GetAllLecturers();
                    dgvCompanies.DataSource = CompanyMockData.GetAllCompanies();
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

        private async void btnCreateUser_Click(object sender, EventArgs e)
        {
            // Determine current role based on selected tab
            string role = "student";
            if (tabControlUsers.SelectedTab == tabLecturers) role = "lecturer";
            else if (tabControlUsers.SelectedTab == tabCompanies) role = "company";

            var dialog = new UserDialog(role);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (_useMockData)
                    {
                        // Use mock data
                        bool success = false;
                        string message = "";

                        if (role == "student" && dialog.UserData is Student student)
                        {
                            var (s, m, _) = StudentMockData.CreateStudent(student);
                            success = s;
                            message = m;
                        }
                        else if (role == "lecturer" && dialog.UserData is Lecturer lecturer)
                        {
                            var (s, m, _) = LecturerMockData.CreateLecturer(lecturer);
                            success = s;
                            message = m;
                        }
                        else if (role == "company" && dialog.UserData is Company company)
                        {
                            var (s, m, _) = CompanyMockData.CreateCompany(company);
                            success = s;
                            message = m;
                        }

                        if (success)
                        {
                            MessageBox.Show(message, "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // TODO: Call real API
                        MessageBox.Show("Chức năng tạo người dùng qua API đang được phát triển!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEditUser_Click(object sender, EventArgs e)
        {
            // Get selected user
            var currentTab = tabControlUsers.SelectedTab;
            DataGridView? currentDgv = null;
            string role = "student";

            if (currentTab == tabStudents)
            {
                currentDgv = dgvStudents;
                role = "student";
            }
            else if (currentTab == tabLecturers)
            {
                currentDgv = dgvLecturers;
                role = "lecturer";
            }
            else if (currentTab == tabCompanies)
            {
                currentDgv = dgvCompanies;
                role = "company";
            }

            if (currentDgv == null || currentDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedUser = currentDgv.SelectedRows[0].DataBoundItem;

            var dialog = new UserDialog(role, selectedUser);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (_useMockData)
                    {
                        // Use mock data
                        bool success = false;
                        string message = "";
                        string? userId = null;

                        if (role == "student" && dialog.UserData is Student student)
                        {
                            userId = student.Id;
                            if (!string.IsNullOrEmpty(userId))
                            {
                                var (s, m, _) = StudentMockData.UpdateStudent(userId, student);
                                success = s;
                                message = m;
                            }
                        }
                        else if (role == "lecturer" && dialog.UserData is Lecturer lecturer)
                        {
                            userId = lecturer.Id;
                            if (!string.IsNullOrEmpty(userId))
                            {
                                var (s, m, _) = LecturerMockData.UpdateLecturer(userId, lecturer);
                                success = s;
                                message = m;
                            }
                        }
                        else if (role == "company" && dialog.UserData is Company company)
                        {
                            userId = company.Id;
                            if (!string.IsNullOrEmpty(userId))
                            {
                                var (s, m, _) = CompanyMockData.UpdateCompany(userId, company);
                                success = s;
                                message = m;
                            }
                        }

                        if (success)
                        {
                            MessageBox.Show(message, "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show(message ?? "Không tìm thấy ID người dùng", "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // TODO: Call real API
                        MessageBox.Show("Chức năng sửa người dùng qua API đang được phát triển!", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnDeleteUser_Click(object sender, EventArgs e)
        {
            var currentTab = tabControlUsers.SelectedTab;
            DataGridView? currentDgv = null;
            string? userId = null;
            string? userName = null;
            string role = "student";

            if (currentTab == tabStudents)
            {
                currentDgv = dgvStudents;
                role = "student";
                if (currentDgv.SelectedRows.Count > 0)
                {
                    var student = currentDgv.SelectedRows[0].DataBoundItem as Student;
                    userId = student?.Id;
                    userName = student?.FullName;
                }
            }
            else if (currentTab == tabLecturers)
            {
                currentDgv = dgvLecturers;
                role = "lecturer";
                if (currentDgv.SelectedRows.Count > 0)
                {
                    var lecturer = currentDgv.SelectedRows[0].DataBoundItem as Lecturer;
                    userId = lecturer?.Id;
                    userName = lecturer?.FullName;
                }
            }
            else if (currentTab == tabCompanies)
            {
                currentDgv = dgvCompanies;
                role = "company";
                if (currentDgv.SelectedRows.Count > 0)
                {
                    var company = currentDgv.SelectedRows[0].DataBoundItem as Company;
                    userId = company?.Id;
                    userName = company?.CompanyName;
                }
            }

            if (currentDgv == null || currentDgv.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn người dùng cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("Không tìm thấy ID người dùng!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var result = MessageBox.Show($"Bạn có chắc muốn xóa '{userName}'?\n\nHành động này không thể hoàn tác!",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (_useMockData)
                    {
                        // Use mock data
                        bool success = false;
                        string message = "";

                        if (role == "student")
                        {
                            var (s, m) = StudentMockData.DeleteStudent(userId);
                            success = s;
                            message = m;
                        }
                        else if (role == "lecturer")
                        {
                            var (s, m) = LecturerMockData.DeleteLecturer(userId);
                            success = s;
                            message = m;
                        }
                        else if (role == "company")
                        {
                            var (s, m) = CompanyMockData.DeleteCompany(userId);
                            success = s;
                            message = m;
                        }

                        if (success)
                        {
                            MessageBox.Show(message, "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadUsers();
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        var (success, message) = await _adminService.DeleteUserAsync(userId);

                        if (success)
                        {
                            MessageBox.Show(message, "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadUsers(); // Reload data
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        private async void btnCreateTopic_Click(object sender, EventArgs e)
        {
            var dialog = new TopicDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (_useMockData)
                    {
                        // Use mock data
                        var (success, message, topic) = AdminMockData.CreateTopic(dialog.TopicData!);

                        if (success)
                        {
                            MessageBox.Show(message, "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadTopics();
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Call API to create topic
                        var (success, message, topic) = await _adminService.CreateTopicAsync(dialog.TopicData!);

                        if (success)
                        {
                            MessageBox.Show(message, "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadTopics(); // Reload data
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEditTopic_Click(object sender, EventArgs e)
        {
            if (dgvTopics.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn đề tài cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedTopic = dgvTopics.SelectedRows[0].DataBoundItem as InternshipTopic;
            if (selectedTopic == null) return;

            var dialog = new TopicDialog(selectedTopic);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (string.IsNullOrEmpty(selectedTopic.Id))
                    {
                        MessageBox.Show("Không tìm thấy ID đề tài!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (_useMockData)
                    {
                        // Use mock data
                        var (success, message, topic) = AdminMockData.UpdateTopic(selectedTopic.Id, dialog.TopicData!);

                        if (success)
                        {
                            MessageBox.Show(message, "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadTopics();
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // Call API to update topic
                        var (success, message, topic) = await _adminService.UpdateTopicAsync(selectedTopic.Id, dialog.TopicData!);

                        if (success)
                        {
                            MessageBox.Show(message, "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadTopics(); // Reload data
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                    _currentLogs = SystemLogMockData.GetAllLogs();
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

        #region Internship Period Management

        private async System.Threading.Tasks.Task LoadPeriods()
        {
            try
            {
                if (_useMockData)
                {
                    _currentPeriods = InternshipPeriodMockData.GetAllPeriods();
                    dgvPeriods.DataSource = _currentPeriods;
                }
                else
                {
                    // TODO: Call API when available
                    MessageBox.Show("API chưa có sẵn", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách kỳ thực tập: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCreatePeriod_Click(object sender, EventArgs e)
        {
            var dialog = new MyWinFormsApp.UI.Forms.InternshipPeriodDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (_useMockData)
                    {
                        var (success, message, period) = InternshipPeriodMockData.CreatePeriod(dialog.PeriodData!);

                        if (success)
                        {
                            MessageBox.Show(message, "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadPeriods();
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // TODO: Call API
                        MessageBox.Show("API chưa có sẵn", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnEditPeriod_Click(object sender, EventArgs e)
        {
            if (dgvPeriods.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn kỳ thực tập cần sửa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedPeriod = dgvPeriods.SelectedRows[0].DataBoundItem as InternshipPeriod;
            if (selectedPeriod == null) return;

            var dialog = new MyWinFormsApp.UI.Forms.InternshipPeriodDialog(selectedPeriod);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if (string.IsNullOrEmpty(selectedPeriod.Id))
                    {
                        MessageBox.Show("Không tìm thấy ID kỳ thực tập!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (_useMockData)
                    {
                        var (success, message, period) = InternshipPeriodMockData.UpdatePeriod(selectedPeriod.Id, dialog.PeriodData!);

                        if (success)
                        {
                            MessageBox.Show(message, "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadPeriods();
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // TODO: Call API
                        MessageBox.Show("API chưa có sẵn", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnDeletePeriod_Click(object sender, EventArgs e)
        {
            if (dgvPeriods.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn kỳ thực tập cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedPeriod = dgvPeriods.SelectedRows[0].DataBoundItem as InternshipPeriod;
            if (selectedPeriod == null) return;

            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa kỳ thực tập '{selectedPeriod.Name}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    if (string.IsNullOrEmpty(selectedPeriod.Id))
                    {
                        MessageBox.Show("Không tìm thấy ID kỳ thực tập!", "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    if (_useMockData)
                    {
                        var (success, message) = InternshipPeriodMockData.DeletePeriod(selectedPeriod.Id);

                        if (success)
                        {
                            MessageBox.Show(message, "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadPeriods();
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // TODO: Call API
                        MessageBox.Show("API chưa có sẵn", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnOpenPeriod_Click(object sender, EventArgs e)
        {
            if (dgvPeriods.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn kỳ thực tập cần mở!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedPeriod = dgvPeriods.SelectedRows[0].DataBoundItem as InternshipPeriod;
            if (selectedPeriod == null || string.IsNullOrEmpty(selectedPeriod.Id)) return;

            try
            {
                if (_useMockData)
                {
                    var (success, message, period) = InternshipPeriodMockData.OpenPeriod(selectedPeriod.Id);

                    if (success)
                    {
                        MessageBox.Show(message, "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadPeriods();
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // TODO: Call API
                    MessageBox.Show("API chưa có sẵn", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnClosePeriod_Click(object sender, EventArgs e)
        {
            if (dgvPeriods.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn kỳ thực tập cần đóng!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedPeriod = dgvPeriods.SelectedRows[0].DataBoundItem as InternshipPeriod;
            if (selectedPeriod == null || string.IsNullOrEmpty(selectedPeriod.Id)) return;

            try
            {
                if (_useMockData)
                {
                    var (success, message, period) = InternshipPeriodMockData.ClosePeriod(selectedPeriod.Id);

                    if (success)
                    {
                        MessageBox.Show(message, "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadPeriods();
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // TODO: Call API
                    MessageBox.Show("API chưa có sẵn", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Notification Management

        private async System.Threading.Tasks.Task LoadNotifications()
        {
            try
            {
                if (_useMockData)
                {
                    _currentNotifications = NotificationMockData.GetAllNotifications();
                    dgvNotifications.DataSource = _currentNotifications;
                }
                else
                {
                    // TODO: Call API when available
                    MessageBox.Show("API chưa có sẵn", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi tải danh sách thông báo: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnCreateNotification_Click(object sender, EventArgs e)
        {
            // Simple dialog for creating notification
            var title = Microsoft.VisualBasic.Interaction.InputBox("Nhập tiêu đề thông báo:", "Tạo thông báo", "");
            if (string.IsNullOrWhiteSpace(title)) return;

            var content = Microsoft.VisualBasic.Interaction.InputBox("Nhập nội dung thông báo:", "Tạo thông báo", "");
            if (string.IsNullOrWhiteSpace(content)) return;

            try
            {
                var notification = new Notification
                {
                    Title = title,
                    Content = content,
                    Type = "info",
                    TargetType = "all",
                    SenderId = "admin1",
                    SenderName = "Admin",
                    TotalRecipients = 100 // Mock value
                };

                if (_useMockData)
                {
                    var (success, message, notif) = NotificationMockData.CreateNotification(notification);

                    if (success)
                    {
                        MessageBox.Show(message, "Thành công",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        await LoadNotifications();
                    }
                    else
                    {
                        MessageBox.Show(message, "Lỗi",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    // TODO: Call API
                    MessageBox.Show("API chưa có sẵn", "Thông báo");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnSendNotification_Click(object sender, EventArgs e)
        {
            if (dgvNotifications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thông báo cần gửi!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedNotif = dgvNotifications.SelectedRows[0].DataBoundItem as Notification;
            if (selectedNotif == null || string.IsNullOrEmpty(selectedNotif.Id)) return;

            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn gửi thông báo '{selectedNotif.Title}'?",
                "Xác nhận gửi",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    if (_useMockData)
                    {
                        var (success, message, notif) = NotificationMockData.SendNotification(selectedNotif.Id);

                        if (success)
                        {
                            MessageBox.Show(message, "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadNotifications();
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // TODO: Call API
                        MessageBox.Show("API chưa có sẵn", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private async void btnDeleteNotification_Click(object sender, EventArgs e)
        {
            if (dgvNotifications.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn thông báo cần xóa!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedNotif = dgvNotifications.SelectedRows[0].DataBoundItem as Notification;
            if (selectedNotif == null || string.IsNullOrEmpty(selectedNotif.Id)) return;

            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa thông báo '{selectedNotif.Title}'?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    if (_useMockData)
                    {
                        var (success, message) = NotificationMockData.DeleteNotification(selectedNotif.Id);

                        if (success)
                        {
                            MessageBox.Show(message, "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                            await LoadNotifications();
                        }
                        else
                        {
                            MessageBox.Show(message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // TODO: Call API
                        MessageBox.Show("API chưa có sẵn", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Reset Password

        private void resetPasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get current tab to determine user type
            string userType = "";
            string userId = "";
            string userName = "";

            if (tabControlUsers.SelectedTab == tabStudents && dgvStudents.SelectedRows.Count > 0)
            {
                var student = dgvStudents.SelectedRows[0].DataBoundItem as Student;
                if (student != null)
                {
                    userType = "student";
                    userId = student.Id ?? "";
                    userName = student.FullName ?? "";
                }
            }
            else if (tabControlUsers.SelectedTab == tabLecturers && dgvLecturers.SelectedRows.Count > 0)
            {
                var lecturer = dgvLecturers.SelectedRows[0].DataBoundItem as Lecturer;
                if (lecturer != null)
                {
                    userType = "lecturer";
                    userId = lecturer.Id ?? "";
                    userName = lecturer.FullName ?? "";
                }
            }
            else if (tabControlUsers.SelectedTab == tabCompanies && dgvCompanies.SelectedRows.Count > 0)
            {
                var company = dgvCompanies.SelectedRows[0].DataBoundItem as Company;
                if (company != null)
                {
                    userType = "company";
                    userId = company.Id ?? "";
                    userName = company.CompanyName ?? "";
                }
            }

            if (string.IsNullOrEmpty(userId))
            {
                MessageBox.Show("Vui lòng chọn người dùng cần reset mật khẩu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirmResult = MessageBox.Show(
                $"Bạn có chắc chắn muốn reset mật khẩu cho '{userName}'?\nMật khẩu mới sẽ là: 123456",
                "Xác nhận reset mật khẩu",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    if (_useMockData)
                    {
                        (bool success, string message) result = (false, "");

                        switch (userType)
                        {
                            case "student":
                                result = StudentMockData.ResetPassword(userId);
                                break;
                            case "lecturer":
                                result = LecturerMockData.ResetPassword(userId);
                                break;
                            case "company":
                                result = CompanyMockData.ResetPassword(userId);
                                break;
                        }

                        if (result.success)
                        {
                            MessageBox.Show(result.message, "Thành công",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show(result.message, "Lỗi",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        // TODO: Call API
                        MessageBox.Show("API chưa có sẵn", "Thông báo");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        #region Excel Export

        private void btnExportUsers_Click(object sender, EventArgs e)
        {
            try
            {
                // Determine which tab is active
                string userType = "";
                List<Student> students = new List<Student>();
                List<Lecturer> lecturers = new List<Lecturer>();
                List<Company> companies = new List<Company>();

                if (tabControlUsers.SelectedTab == tabStudents)
                {
                    userType = "Students";
                    students = StudentMockData.GetAllStudents();
                }
                else if (tabControlUsers.SelectedTab == tabLecturers)
                {
                    userType = "Lecturers";
                    lecturers = LecturerMockData.GetAllLecturers();
                }
                else if (tabControlUsers.SelectedTab == tabCompanies)
                {
                    userType = "Companies";
                    companies = CompanyMockData.GetAllCompanies();
                }

                if (string.IsNullOrEmpty(userType))
                {
                    MessageBox.Show("Vui lòng chọn tab để xuất dữ liệu", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Show save file dialog
                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Xuất danh sách ra Excel";
                    saveFileDialog.FileName = $"DanhSach_{userType}_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        // Export based on user type
                        if (userType == "Students")
                        {
                            ExcelExportService.ExportStudents(students, saveFileDialog.FileName);
                        }
                        else if (userType == "Lecturers")
                        {
                            ExcelExportService.ExportLecturers(lecturers, saveFileDialog.FileName);
                        }
                        else if (userType == "Companies")
                        {
                            ExcelExportService.ExportCompanies(companies, saveFileDialog.FileName);
                        }

                        MessageBox.Show($"Xuất file thành công!\n{saveFileDialog.FileName}",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Ask if user wants to open the file
                        if (MessageBox.Show("Bạn có muốn mở file Excel không?", "Xác nhận",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveFileDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportTopics_Click(object sender, EventArgs e)
        {
            try
            {
                var topics = _currentTopics;
                if (topics == null || topics.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Xuất danh sách đề tài ra Excel";
                    saveFileDialog.FileName = $"DanhSachDeTai_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExcelExportService.ExportTopics(topics, saveFileDialog.FileName);

                        MessageBox.Show($"Xuất file thành công!\n{saveFileDialog.FileName}",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (MessageBox.Show("Bạn có muốn mở file Excel không?", "Xác nhận",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveFileDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportPeriods_Click(object sender, EventArgs e)
        {
            try
            {
                var periods = _currentPeriods;
                if (periods == null || periods.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Xuất danh sách kỳ thực tập ra Excel";
                    saveFileDialog.FileName = $"DanhSachKyThucTap_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExcelExportService.ExportPeriods(periods, saveFileDialog.FileName);

                        MessageBox.Show($"Xuất file thành công!\n{saveFileDialog.FileName}",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (MessageBox.Show("Bạn có muốn mở file Excel không?", "Xác nhận",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveFileDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExportLogs_Click(object sender, EventArgs e)
        {
            try
            {
                var logs = _currentLogs;
                if (logs == null || logs.Count == 0)
                {
                    MessageBox.Show("Không có dữ liệu để xuất", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var saveFileDialog = new SaveFileDialog())
                {
                    saveFileDialog.Filter = "Excel Files|*.xlsx";
                    saveFileDialog.Title = "Xuất nhật ký hệ thống ra Excel";
                    saveFileDialog.FileName = $"NhatKyHeThong_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx";

                    if (saveFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExcelExportService.ExportSystemLogs(logs, saveFileDialog.FileName);

                        MessageBox.Show($"Xuất file thành công!\n{saveFileDialog.FileName}",
                            "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        if (MessageBox.Show("Bạn có muốn mở file Excel không?", "Xác nhận",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                            {
                                FileName = saveFileDialog.FileName,
                                UseShellExecute = true
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi xuất file: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}
