namespace MyWinFormsApp.Forms
{
    partial class AdminForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();

            // Sidebar
            this.panelSidebar = new System.Windows.Forms.Panel();
            this.btnMenuUsers = new System.Windows.Forms.Button();
            this.btnMenuTopics = new System.Windows.Forms.Button();
            this.btnMenuLogs = new System.Windows.Forms.Button();
            this.btnMenuStats = new System.Windows.Forms.Button();
            this.lblAppTitle = new System.Windows.Forms.Label();

            // Content panels
            this.panelUsersContent = new System.Windows.Forms.Panel();
            this.panelTopicsContent = new System.Windows.Forms.Panel();
            this.panelLogsContent = new System.Windows.Forms.Panel();
            this.panelStatsContent = new System.Windows.Forms.Panel();

            // Tab Users sub-tabs
            this.tabControlUsers = new System.Windows.Forms.TabControl();
            this.tabStudents = new System.Windows.Forms.TabPage();
            this.tabLecturers = new System.Windows.Forms.TabPage();
            this.tabCompanies = new System.Windows.Forms.TabPage();
            
            // DataGridViews
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.dgvLecturers = new System.Windows.Forms.DataGridView();
            this.dgvCompanies = new System.Windows.Forms.DataGridView();
            this.dgvTopics = new System.Windows.Forms.DataGridView();
            
            // Buttons
            this.btnCreateUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnApproveTopic = new System.Windows.Forms.Button();
            this.btnRejectTopic = new System.Windows.Forms.Button();
            
            // ComboBox
            this.cboTopicStatus = new System.Windows.Forms.ComboBox();
            
            // ListView
            this.lvLogs = new System.Windows.Forms.ListView();
            
            // Charts
            this.chartStudentsByCompany = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.chartScoresByMajor = new System.Windows.Forms.DataVisualization.Charting.Chart();
            
            // Labels for statistics
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.lblTotalLecturers = new System.Windows.Forms.Label();
            this.lblTotalCompanies = new System.Windows.Forms.Label();
            this.lblTotalInternships = new System.Windows.Forms.Label();
            this.lblActiveInternships = new System.Windows.Forms.Label();
            this.lblPendingTopics = new System.Windows.Forms.Label();
            this.lblAverageScore = new System.Windows.Forms.Label();
            
            // Context Menu
            this.contextMenuUser = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.resetPasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            
            // Panels
            this.panelUserButtons = new System.Windows.Forms.Panel();
            this.panelTopicControls = new System.Windows.Forms.Panel();
            this.panelStatsInfo = new System.Windows.Forms.Panel();

            this.panelSidebar.SuspendLayout();
            this.panelUsersContent.SuspendLayout();
            this.panelTopicsContent.SuspendLayout();
            this.panelLogsContent.SuspendLayout();
            this.panelStatsContent.SuspendLayout();
            this.tabControlUsers.SuspendLayout();
            this.tabStudents.SuspendLayout();
            this.tabLecturers.SuspendLayout();
            this.tabCompanies.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStudentsByCompany)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartScoresByMajor)).BeginInit();
            this.contextMenuUser.SuspendLayout();
            this.panelUserButtons.SuspendLayout();
            this.panelTopicControls.SuspendLayout();
            this.panelStatsInfo.SuspendLayout();
            this.SuspendLayout();
            
            //
            // panelSidebar
            //
            this.panelSidebar.BackColor = System.Drawing.Color.FromArgb(30, 58, 95);
            this.panelSidebar.Controls.Add(this.btnMenuStats);
            this.panelSidebar.Controls.Add(this.btnMenuLogs);
            this.panelSidebar.Controls.Add(this.btnMenuTopics);
            this.panelSidebar.Controls.Add(this.btnMenuUsers);
            this.panelSidebar.Controls.Add(this.lblAppTitle);
            this.panelSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelSidebar.Location = new System.Drawing.Point(0, 0);
            this.panelSidebar.Name = "panelSidebar";
            this.panelSidebar.Size = new System.Drawing.Size(250, 700);
            this.panelSidebar.TabIndex = 0;

            //
            // lblAppTitle
            //
            this.lblAppTitle.BackColor = System.Drawing.Color.FromArgb(243, 111, 33);
            this.lblAppTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblAppTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblAppTitle.ForeColor = System.Drawing.Color.White;
            this.lblAppTitle.Location = new System.Drawing.Point(0, 0);
            this.lblAppTitle.Name = "lblAppTitle";
            this.lblAppTitle.Size = new System.Drawing.Size(250, 80);
            this.lblAppTitle.TabIndex = 0;
            this.lblAppTitle.Text = "🎓 LHU Admin\r\nQuản trị hệ thống";
            this.lblAppTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

            //
            // btnMenuUsers
            //
            this.btnMenuUsers.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuUsers.FlatAppearance.BorderSize = 0;
            this.btnMenuUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuUsers.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMenuUsers.ForeColor = System.Drawing.Color.White;
            this.btnMenuUsers.Location = new System.Drawing.Point(0, 80);
            this.btnMenuUsers.Name = "btnMenuUsers";
            this.btnMenuUsers.Size = new System.Drawing.Size(250, 60);
            this.btnMenuUsers.TabIndex = 1;
            this.btnMenuUsers.Text = "👥 Quản lý người dùng";
            this.btnMenuUsers.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuUsers.UseVisualStyleBackColor = true;

            //
            // btnMenuTopics
            //
            this.btnMenuTopics.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuTopics.FlatAppearance.BorderSize = 0;
            this.btnMenuTopics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuTopics.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMenuTopics.ForeColor = System.Drawing.Color.White;
            this.btnMenuTopics.Location = new System.Drawing.Point(0, 140);
            this.btnMenuTopics.Name = "btnMenuTopics";
            this.btnMenuTopics.Size = new System.Drawing.Size(250, 60);
            this.btnMenuTopics.TabIndex = 2;
            this.btnMenuTopics.Text = "📋 Đề tài thực tập";
            this.btnMenuTopics.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuTopics.UseVisualStyleBackColor = true;

            //
            // btnMenuLogs
            //
            this.btnMenuLogs.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuLogs.FlatAppearance.BorderSize = 0;
            this.btnMenuLogs.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuLogs.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMenuLogs.ForeColor = System.Drawing.Color.White;
            this.btnMenuLogs.Location = new System.Drawing.Point(0, 200);
            this.btnMenuLogs.Name = "btnMenuLogs";
            this.btnMenuLogs.Size = new System.Drawing.Size(250, 60);
            this.btnMenuLogs.TabIndex = 3;
            this.btnMenuLogs.Text = "📊 Nhật ký hệ thống";
            this.btnMenuLogs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuLogs.UseVisualStyleBackColor = true;

            //
            // btnMenuStats
            //
            this.btnMenuStats.Dock = System.Windows.Forms.DockStyle.Top;
            this.btnMenuStats.FlatAppearance.BorderSize = 0;
            this.btnMenuStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMenuStats.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.btnMenuStats.ForeColor = System.Drawing.Color.White;
            this.btnMenuStats.Location = new System.Drawing.Point(0, 260);
            this.btnMenuStats.Name = "btnMenuStats";
            this.btnMenuStats.Size = new System.Drawing.Size(250, 60);
            this.btnMenuStats.TabIndex = 4;
            this.btnMenuStats.Text = "📈 Thống kê";
            this.btnMenuStats.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMenuStats.UseVisualStyleBackColor = true;
            
            //
            // panelUsersContent
            //
            this.panelUsersContent.BackColor = System.Drawing.Color.White;
            this.panelUsersContent.Controls.Add(this.tabControlUsers);
            this.panelUsersContent.Controls.Add(this.panelUserButtons);
            this.panelUsersContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelUsersContent.Location = new System.Drawing.Point(250, 0);
            this.panelUsersContent.Name = "panelUsersContent";
            this.panelUsersContent.Padding = new System.Windows.Forms.Padding(10);
            this.panelUsersContent.Size = new System.Drawing.Size(950, 700);
            this.panelUsersContent.TabIndex = 1;
            this.panelUsersContent.Visible = false;
            
            //
            // panelUserButtons
            //
            this.panelUserButtons.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelUserButtons.Controls.Add(this.btnCreateUser);
            this.panelUserButtons.Controls.Add(this.btnEditUser);
            this.panelUserButtons.Controls.Add(this.btnDeleteUser);
            this.panelUserButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelUserButtons.Location = new System.Drawing.Point(10, 10);
            this.panelUserButtons.Name = "panelUserButtons";
            this.panelUserButtons.Padding = new System.Windows.Forms.Padding(5);
            this.panelUserButtons.Size = new System.Drawing.Size(930, 60);
            this.panelUserButtons.TabIndex = 0;
            
            //
            // btnCreateUser
            //
            this.btnCreateUser.Location = new System.Drawing.Point(10, 10);
            this.btnCreateUser.Name = "btnCreateUser";
            this.btnCreateUser.Size = new System.Drawing.Size(120, 35);
            this.btnCreateUser.TabIndex = 0;
            this.btnCreateUser.Text = "Tạo mới";
            this.btnCreateUser.UseVisualStyleBackColor = true;
            this.btnCreateUser.Click += new System.EventHandler(this.btnCreateUser_Click);

            //
            // btnEditUser
            //
            this.btnEditUser.Location = new System.Drawing.Point(140, 10);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(120, 35);
            this.btnEditUser.TabIndex = 1;
            this.btnEditUser.Text = "Sửa";
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);

            //
            // btnDeleteUser
            //
            this.btnDeleteUser.Location = new System.Drawing.Point(270, 10);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteUser.TabIndex = 2;
            this.btnDeleteUser.Text = "Xóa";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);

            //
            // tabControlUsers
            //
            this.tabControlUsers.Controls.Add(this.tabStudents);
            this.tabControlUsers.Controls.Add(this.tabLecturers);
            this.tabControlUsers.Controls.Add(this.tabCompanies);
            this.tabControlUsers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlUsers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControlUsers.Location = new System.Drawing.Point(10, 70);
            this.tabControlUsers.Name = "tabControlUsers";
            this.tabControlUsers.SelectedIndex = 0;
            this.tabControlUsers.Size = new System.Drawing.Size(930, 620);
            this.tabControlUsers.TabIndex = 1;

            //
            // tabStudents
            //
            this.tabStudents.Controls.Add(this.dgvStudents);
            this.tabStudents.Location = new System.Drawing.Point(4, 26);
            this.tabStudents.Name = "tabStudents";
            this.tabStudents.Padding = new System.Windows.Forms.Padding(3);
            this.tabStudents.Size = new System.Drawing.Size(1178, 584);
            this.tabStudents.TabIndex = 0;
            this.tabStudents.Text = "Sinh viên";
            this.tabStudents.UseVisualStyleBackColor = true;

            //
            // dgvStudents
            //
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.ContextMenuStrip = this.contextMenuUser;
            this.dgvStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudents.Location = new System.Drawing.Point(3, 3);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.Size = new System.Drawing.Size(1172, 578);
            this.dgvStudents.TabIndex = 0;

            //
            // tabLecturers
            //
            this.tabLecturers.Controls.Add(this.dgvLecturers);
            this.tabLecturers.Location = new System.Drawing.Point(4, 26);
            this.tabLecturers.Name = "tabLecturers";
            this.tabLecturers.Padding = new System.Windows.Forms.Padding(3);
            this.tabLecturers.Size = new System.Drawing.Size(1178, 584);
            this.tabLecturers.TabIndex = 1;
            this.tabLecturers.Text = "Giảng viên";
            this.tabLecturers.UseVisualStyleBackColor = true;

            //
            // dgvLecturers
            //
            this.dgvLecturers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLecturers.ContextMenuStrip = this.contextMenuUser;
            this.dgvLecturers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLecturers.Location = new System.Drawing.Point(3, 3);
            this.dgvLecturers.Name = "dgvLecturers";
            this.dgvLecturers.Size = new System.Drawing.Size(1172, 578);
            this.dgvLecturers.TabIndex = 0;

            //
            // tabCompanies
            //
            this.tabCompanies.Controls.Add(this.dgvCompanies);
            this.tabCompanies.Location = new System.Drawing.Point(4, 26);
            this.tabCompanies.Name = "tabCompanies";
            this.tabCompanies.Padding = new System.Windows.Forms.Padding(3);
            this.tabCompanies.Size = new System.Drawing.Size(1178, 584);
            this.tabCompanies.TabIndex = 2;
            this.tabCompanies.Text = "Doanh nghiệp";
            this.tabCompanies.UseVisualStyleBackColor = true;

            //
            // dgvCompanies
            //
            this.dgvCompanies.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCompanies.ContextMenuStrip = this.contextMenuUser;
            this.dgvCompanies.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCompanies.Location = new System.Drawing.Point(3, 3);
            this.dgvCompanies.Name = "dgvCompanies";
            this.dgvCompanies.Size = new System.Drawing.Size(1172, 578);
            this.dgvCompanies.TabIndex = 0;

            //
            // contextMenuUser
            //
            this.contextMenuUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetPasswordToolStripMenuItem});
            this.contextMenuUser.Name = "contextMenuUser";
            this.contextMenuUser.Size = new System.Drawing.Size(181, 26);

            //
            // resetPasswordToolStripMenuItem
            //
            this.resetPasswordToolStripMenuItem.Name = "resetPasswordToolStripMenuItem";
            this.resetPasswordToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.resetPasswordToolStripMenuItem.Text = "Reset mật khẩu";
            this.resetPasswordToolStripMenuItem.Click += new System.EventHandler(this.resetPasswordToolStripMenuItem_Click);

            //
            // panelTopicsContent
            //
            this.panelTopicsContent.BackColor = System.Drawing.Color.White;
            this.panelTopicsContent.Controls.Add(this.dgvTopics);
            this.panelTopicsContent.Controls.Add(this.panelTopicControls);
            this.panelTopicsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTopicsContent.Location = new System.Drawing.Point(250, 0);
            this.panelTopicsContent.Name = "panelTopicsContent";
            this.panelTopicsContent.Padding = new System.Windows.Forms.Padding(10);
            this.panelTopicsContent.Size = new System.Drawing.Size(950, 700);
            this.panelTopicsContent.TabIndex = 2;
            this.panelTopicsContent.Visible = false;

            //
            // panelTopicControls
            //
            this.panelTopicControls.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelTopicControls.Controls.Add(this.cboTopicStatus);
            this.panelTopicControls.Controls.Add(this.btnApproveTopic);
            this.panelTopicControls.Controls.Add(this.btnRejectTopic);
            this.panelTopicControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelTopicControls.Location = new System.Drawing.Point(10, 10);
            this.panelTopicControls.Name = "panelTopicControls";
            this.panelTopicControls.Padding = new System.Windows.Forms.Padding(5);
            this.panelTopicControls.Size = new System.Drawing.Size(930, 60);
            this.panelTopicControls.TabIndex = 0;

            //
            // cboTopicStatus
            //
            this.cboTopicStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTopicStatus.FormattingEnabled = true;
            this.cboTopicStatus.Items.AddRange(new object[] {
            "Tất cả",
            "pending",
            "approved",
            "rejected",
            "in_progress",
            "completed"});
            this.cboTopicStatus.Location = new System.Drawing.Point(10, 12);
            this.cboTopicStatus.Name = "cboTopicStatus";
            this.cboTopicStatus.SelectedIndex = 0;
            this.cboTopicStatus.Size = new System.Drawing.Size(150, 25);
            this.cboTopicStatus.TabIndex = 0;
            this.cboTopicStatus.SelectedIndexChanged += new System.EventHandler(this.cboTopicStatus_SelectedIndexChanged);

            //
            // btnApproveTopic
            //
            this.btnApproveTopic.Location = new System.Drawing.Point(180, 10);
            this.btnApproveTopic.Name = "btnApproveTopic";
            this.btnApproveTopic.Size = new System.Drawing.Size(120, 35);
            this.btnApproveTopic.TabIndex = 1;
            this.btnApproveTopic.Text = "Duyệt";
            this.btnApproveTopic.UseVisualStyleBackColor = true;
            this.btnApproveTopic.Click += new System.EventHandler(this.btnApproveTopic_Click);

            //
            // btnRejectTopic
            //
            this.btnRejectTopic.Location = new System.Drawing.Point(310, 10);
            this.btnRejectTopic.Name = "btnRejectTopic";
            this.btnRejectTopic.Size = new System.Drawing.Size(120, 35);
            this.btnRejectTopic.TabIndex = 2;
            this.btnRejectTopic.Text = "Từ chối";
            this.btnRejectTopic.UseVisualStyleBackColor = true;
            this.btnRejectTopic.Click += new System.EventHandler(this.btnRejectTopic_Click);

            //
            // dgvTopics
            //
            this.dgvTopics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTopics.Location = new System.Drawing.Point(10, 70);
            this.dgvTopics.Name = "dgvTopics";
            this.dgvTopics.Size = new System.Drawing.Size(930, 620);
            this.dgvTopics.TabIndex = 1;

            //
            // panelLogsContent
            //
            this.panelLogsContent.BackColor = System.Drawing.Color.White;
            this.panelLogsContent.Controls.Add(this.lvLogs);
            this.panelLogsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLogsContent.Location = new System.Drawing.Point(250, 0);
            this.panelLogsContent.Name = "panelLogsContent";
            this.panelLogsContent.Padding = new System.Windows.Forms.Padding(10);
            this.panelLogsContent.Size = new System.Drawing.Size(950, 700);
            this.panelLogsContent.TabIndex = 3;
            this.panelLogsContent.Visible = false;

            //
            // lvLogs
            //
            this.lvLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvLogs.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lvLogs.HideSelection = false;
            this.lvLogs.Location = new System.Drawing.Point(10, 10);
            this.lvLogs.Name = "lvLogs";
            this.lvLogs.Size = new System.Drawing.Size(930, 680);
            this.lvLogs.TabIndex = 0;
            this.lvLogs.UseCompatibleStateImageBehavior = false;

            //
            // panelStatsContent
            //
            this.panelStatsContent.BackColor = System.Drawing.Color.White;
            this.panelStatsContent.Controls.Add(this.chartScoresByMajor);
            this.panelStatsContent.Controls.Add(this.chartStudentsByCompany);
            this.panelStatsContent.Controls.Add(this.panelStatsInfo);
            this.panelStatsContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelStatsContent.Location = new System.Drawing.Point(250, 0);
            this.panelStatsContent.Name = "panelStatsContent";
            this.panelStatsContent.Padding = new System.Windows.Forms.Padding(10);
            this.panelStatsContent.Size = new System.Drawing.Size(950, 700);
            this.panelStatsContent.TabIndex = 4;
            this.panelStatsContent.Visible = false;

            //
            // panelStatsInfo
            //
            this.panelStatsInfo.BackColor = System.Drawing.Color.FromArgb(0, 84, 166);
            this.panelStatsInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStatsInfo.Location = new System.Drawing.Point(10, 10);
            this.panelStatsInfo.Name = "panelStatsInfo";
            this.panelStatsInfo.Padding = new System.Windows.Forms.Padding(10);
            this.panelStatsInfo.Size = new System.Drawing.Size(930, 120);
            this.panelStatsInfo.TabIndex = 0;

            // Create labels for statistics in panelStatsInfo
            var lblTotalStudentsTitle = new System.Windows.Forms.Label();
            lblTotalStudentsTitle.Text = "Tổng SV:";
            lblTotalStudentsTitle.Location = new System.Drawing.Point(20, 20);
            lblTotalStudentsTitle.Size = new System.Drawing.Size(100, 25);
            lblTotalStudentsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.panelStatsInfo.Controls.Add(lblTotalStudentsTitle);

            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.lblTotalStudents.Text = "0";
            this.lblTotalStudents.Location = new System.Drawing.Point(120, 20);
            this.lblTotalStudents.Size = new System.Drawing.Size(80, 25);
            this.lblTotalStudents.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalStudents.ForeColor = ColorTranslator.FromHtml("#0054A6");
            this.panelStatsInfo.Controls.Add(this.lblTotalStudents);

            var lblTotalLecturersTitle = new System.Windows.Forms.Label();
            lblTotalLecturersTitle.Text = "Tổng GV:";
            lblTotalLecturersTitle.Location = new System.Drawing.Point(220, 20);
            lblTotalLecturersTitle.Size = new System.Drawing.Size(100, 25);
            lblTotalLecturersTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.panelStatsInfo.Controls.Add(lblTotalLecturersTitle);

            this.lblTotalLecturers = new System.Windows.Forms.Label();
            this.lblTotalLecturers.Text = "0";
            this.lblTotalLecturers.Location = new System.Drawing.Point(320, 20);
            this.lblTotalLecturers.Size = new System.Drawing.Size(80, 25);
            this.lblTotalLecturers.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalLecturers.ForeColor = ColorTranslator.FromHtml("#0054A6");
            this.panelStatsInfo.Controls.Add(this.lblTotalLecturers);

            var lblTotalCompaniesTitle = new System.Windows.Forms.Label();
            lblTotalCompaniesTitle.Text = "Tổng DN:";
            lblTotalCompaniesTitle.Location = new System.Drawing.Point(420, 20);
            lblTotalCompaniesTitle.Size = new System.Drawing.Size(100, 25);
            lblTotalCompaniesTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.panelStatsInfo.Controls.Add(lblTotalCompaniesTitle);

            this.lblTotalCompanies = new System.Windows.Forms.Label();
            this.lblTotalCompanies.Text = "0";
            this.lblTotalCompanies.Location = new System.Drawing.Point(520, 20);
            this.lblTotalCompanies.Size = new System.Drawing.Size(80, 25);
            this.lblTotalCompanies.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalCompanies.ForeColor = ColorTranslator.FromHtml("#0054A6");
            this.panelStatsInfo.Controls.Add(this.lblTotalCompanies);

            var lblTotalInternshipsTitle = new System.Windows.Forms.Label();
            lblTotalInternshipsTitle.Text = "Tổng đề tài:";
            lblTotalInternshipsTitle.Location = new System.Drawing.Point(620, 20);
            lblTotalInternshipsTitle.Size = new System.Drawing.Size(100, 25);
            lblTotalInternshipsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.panelStatsInfo.Controls.Add(lblTotalInternshipsTitle);

            this.lblTotalInternships = new System.Windows.Forms.Label();
            this.lblTotalInternships.Text = "0";
            this.lblTotalInternships.Location = new System.Drawing.Point(720, 20);
            this.lblTotalInternships.Size = new System.Drawing.Size(80, 25);
            this.lblTotalInternships.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTotalInternships.ForeColor = ColorTranslator.FromHtml("#0054A6");
            this.panelStatsInfo.Controls.Add(this.lblTotalInternships);

            var lblActiveInternshipsTitle = new System.Windows.Forms.Label();
            lblActiveInternshipsTitle.Text = "Đang thực tập:";
            lblActiveInternshipsTitle.Location = new System.Drawing.Point(20, 55);
            lblActiveInternshipsTitle.Size = new System.Drawing.Size(120, 25);
            lblActiveInternshipsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.panelStatsInfo.Controls.Add(lblActiveInternshipsTitle);

            this.lblActiveInternships = new System.Windows.Forms.Label();
            this.lblActiveInternships.Text = "0";
            this.lblActiveInternships.Location = new System.Drawing.Point(140, 55);
            this.lblActiveInternships.Size = new System.Drawing.Size(80, 25);
            this.lblActiveInternships.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblActiveInternships.ForeColor = ColorTranslator.FromHtml("#F36F21");
            this.panelStatsInfo.Controls.Add(this.lblActiveInternships);

            var lblPendingTopicsTitle = new System.Windows.Forms.Label();
            lblPendingTopicsTitle.Text = "Chờ duyệt:";
            lblPendingTopicsTitle.Location = new System.Drawing.Point(240, 55);
            lblPendingTopicsTitle.Size = new System.Drawing.Size(100, 25);
            lblPendingTopicsTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.panelStatsInfo.Controls.Add(lblPendingTopicsTitle);

            this.lblPendingTopics = new System.Windows.Forms.Label();
            this.lblPendingTopics.Text = "0";
            this.lblPendingTopics.Location = new System.Drawing.Point(340, 55);
            this.lblPendingTopics.Size = new System.Drawing.Size(80, 25);
            this.lblPendingTopics.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblPendingTopics.ForeColor = ColorTranslator.FromHtml("#F36F21");
            this.panelStatsInfo.Controls.Add(this.lblPendingTopics);

            var lblAverageScoreTitle = new System.Windows.Forms.Label();
            lblAverageScoreTitle.Text = "Điểm TB:";
            lblAverageScoreTitle.Location = new System.Drawing.Point(440, 55);
            lblAverageScoreTitle.Size = new System.Drawing.Size(100, 25);
            lblAverageScoreTitle.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.panelStatsInfo.Controls.Add(lblAverageScoreTitle);

            this.lblAverageScore = new System.Windows.Forms.Label();
            this.lblAverageScore.Text = "0.00";
            this.lblAverageScore.Location = new System.Drawing.Point(540, 55);
            this.lblAverageScore.Size = new System.Drawing.Size(80, 25);
            this.lblAverageScore.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAverageScore.ForeColor = ColorTranslator.FromHtml("#F36F21");
            this.panelStatsInfo.Controls.Add(this.lblAverageScore);

            //
            // chartStudentsByCompany
            //
            chartArea1.Name = "ChartArea1";
            this.chartStudentsByCompany.ChartAreas.Add(chartArea1);
            this.chartStudentsByCompany.Location = new System.Drawing.Point(20, 120);
            this.chartStudentsByCompany.Name = "chartStudentsByCompany";
            this.chartStudentsByCompany.Size = new System.Drawing.Size(560, 400);
            this.chartStudentsByCompany.TabIndex = 1;
            this.chartStudentsByCompany.Text = "chart1";

            //
            // chartScoresByMajor
            //
            chartArea2.Name = "ChartArea1";
            this.chartScoresByMajor.ChartAreas.Add(chartArea2);
            this.chartScoresByMajor.Location = new System.Drawing.Point(600, 120);
            this.chartScoresByMajor.Name = "chartScoresByMajor";
            this.chartScoresByMajor.Size = new System.Drawing.Size(560, 400);
            this.chartScoresByMajor.TabIndex = 2;
            this.chartScoresByMajor.Text = "chart2";

            //
            // AdminForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.panelStatsContent);
            this.Controls.Add(this.panelLogsContent);
            this.Controls.Add(this.panelTopicsContent);
            this.Controls.Add(this.panelUsersContent);
            this.Controls.Add(this.panelSidebar);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản trị hệ thống - Lac Hong University";
            this.tabControlUsers.ResumeLayout(false);
            this.tabStudents.ResumeLayout(false);
            this.tabLecturers.ResumeLayout(false);
            this.tabCompanies.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLecturers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCompanies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartStudentsByCompany)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartScoresByMajor)).EndInit();
            this.contextMenuUser.ResumeLayout(false);
            this.panelUserButtons.ResumeLayout(false);
            this.panelTopicControls.ResumeLayout(false);
            this.panelStatsInfo.ResumeLayout(false);
            this.panelSidebar.ResumeLayout(false);
            this.panelUsersContent.ResumeLayout(false);
            this.panelTopicsContent.ResumeLayout(false);
            this.panelLogsContent.ResumeLayout(false);
            this.panelStatsContent.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        // Sidebar
        private System.Windows.Forms.Panel panelSidebar;
        private System.Windows.Forms.Button btnMenuUsers;
        private System.Windows.Forms.Button btnMenuTopics;
        private System.Windows.Forms.Button btnMenuLogs;
        private System.Windows.Forms.Button btnMenuStats;
        private System.Windows.Forms.Label lblAppTitle;

        // Content Panels
        private System.Windows.Forms.Panel panelUsersContent;
        private System.Windows.Forms.Panel panelTopicsContent;
        private System.Windows.Forms.Panel panelLogsContent;
        private System.Windows.Forms.Panel panelStatsContent;

        // Old tab controls (kept for compatibility)
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabUsers;
        private System.Windows.Forms.TabPage tabTopics;
        private System.Windows.Forms.TabPage tabLogs;
        private System.Windows.Forms.TabPage tabStatistics;

        // User Management
        private System.Windows.Forms.TabControl tabControlUsers;
        private System.Windows.Forms.TabPage tabStudents;
        private System.Windows.Forms.TabPage tabLecturers;
        private System.Windows.Forms.TabPage tabCompanies;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.DataGridView dgvLecturers;
        private System.Windows.Forms.DataGridView dgvCompanies;
        private System.Windows.Forms.Button btnCreateUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Panel panelUserButtons;
        private System.Windows.Forms.ContextMenuStrip contextMenuUser;
        private System.Windows.Forms.ToolStripMenuItem resetPasswordToolStripMenuItem;

        // Topics
        private System.Windows.Forms.DataGridView dgvTopics;
        private System.Windows.Forms.Button btnApproveTopic;
        private System.Windows.Forms.Button btnRejectTopic;
        private System.Windows.Forms.ComboBox cboTopicStatus;
        private System.Windows.Forms.Panel panelTopicControls;

        // Logs
        private System.Windows.Forms.ListView lvLogs;

        // Statistics
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStudentsByCompany;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartScoresByMajor;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Label lblTotalLecturers;
        private System.Windows.Forms.Label lblTotalCompanies;
        private System.Windows.Forms.Label lblTotalInternships;
        private System.Windows.Forms.Label lblActiveInternships;
        private System.Windows.Forms.Label lblPendingTopics;
        private System.Windows.Forms.Label lblAverageScore;
        private System.Windows.Forms.Panel panelStatsInfo;
    }
}

