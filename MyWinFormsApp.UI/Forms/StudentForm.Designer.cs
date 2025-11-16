namespace MyWinFormsApp.UI.Forms
{
    partial class StudentForm
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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.tabRegistration = new System.Windows.Forms.TabPage();
            this.tabProgress = new System.Windows.Forms.TabPage();
            this.tabGrades = new System.Windows.Forms.TabPage();
            this.tabStatistics = new System.Windows.Forms.TabPage();
            
            // Profile Tab Controls
            this.panelProfile = new System.Windows.Forms.Panel();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtStudentCode = new System.Windows.Forms.TextBox();
            this.txtDepartment = new System.Windows.Forms.TextBox();
            this.txtYear = new System.Windows.Forms.TextBox();
            this.rtbDescription = new System.Windows.Forms.RichTextBox();
            this.lblProfileStatus = new System.Windows.Forms.Label();
            this.btnUploadAvatar = new System.Windows.Forms.Button();
            this.btnUploadCV = new System.Windows.Forms.Button();
            this.btnSaveProfile = new System.Windows.Forms.Button();

            // Labels for Profile
            var lblFullName = new System.Windows.Forms.Label();
            var lblEmail = new System.Windows.Forms.Label();
            var lblPhone = new System.Windows.Forms.Label();
            var lblStudentCode = new System.Windows.Forms.Label();
            var lblDepartment = new System.Windows.Forms.Label();
            var lblYear = new System.Windows.Forms.Label();
            var lblDescription = new System.Windows.Forms.Label();
            
            // Registration Tab Controls
            this.dgvTopics = new System.Windows.Forms.DataGridView();
            this.cboTopics = new System.Windows.Forms.ComboBox();
            this.cboCompanies = new System.Windows.Forms.ComboBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnUploadCoverLetter = new System.Windows.Forms.Button();
            this.dgvMyRegistrations = new System.Windows.Forms.DataGridView();
            
            // Progress Tab Controls
            this.tabControlProgress = new System.Windows.Forms.TabControl();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.tabWorkLogs = new System.Windows.Forms.TabPage();
            this.tabDeadline = new System.Windows.Forms.TabPage();
            this.dgvWeeklyReports = new System.Windows.Forms.DataGridView();
            this.btnCreateReport = new System.Windows.Forms.Button();
            this.btnSubmitReport = new System.Windows.Forms.Button();
            this.lvWorkLogs = new System.Windows.Forms.ListView();
            this.rtbWorkLog = new System.Windows.Forms.RichTextBox();
            this.dtpWorkDate = new System.Windows.Forms.DateTimePicker();
            this.txtWorkTitle = new System.Windows.Forms.TextBox();
            this.nudHoursWorked = new System.Windows.Forms.NumericUpDown();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.btnSaveWorkLog = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lblProgressPercent = new System.Windows.Forms.Label();
            this.lblCompletedWeeks = new System.Windows.Forms.Label();
            this.lblDaysRemaining = new System.Windows.Forms.Label();
            this.lblReportDeadline = new System.Windows.Forms.Label();
            this.lblDefenseDate = new System.Windows.Forms.Label();
            this.calDeadline = new System.Windows.Forms.MonthCalendar();
            
            // Grades Tab Controls
            this.dgvGrades = new System.Windows.Forms.DataGridView();
            this.gbLecturerComment = new System.Windows.Forms.GroupBox();
            this.rtbLecturerComment = new System.Windows.Forms.RichTextBox();
            this.gbCompanyComment = new System.Windows.Forms.GroupBox();
            this.rtbCompanyComment = new System.Windows.Forms.RichTextBox();
            this.chartGrades = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblAverageScore = new System.Windows.Forms.Label();
            
            // Statistics Tab Controls
            this.chartProgress = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.lblTotalReports = new System.Windows.Forms.Label();
            this.lblSubmittedReports = new System.Windows.Forms.Label();
            this.lblTotalWorkLogs = new System.Windows.Forms.Label();
            this.lblTotalHours = new System.Windows.Forms.Label();
            this.lblStatDaysRemaining = new System.Windows.Forms.Label();
            this.lvMilestones = new System.Windows.Forms.ListView();
            this.pbMilestones = new System.Windows.Forms.ProgressBar();
            
            this.tabControl.SuspendLayout();
            this.tabProfile.SuspendLayout();
            this.tabRegistration.SuspendLayout();
            this.tabProgress.SuspendLayout();
            this.tabGrades.SuspendLayout();
            this.tabStatistics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyRegistrations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeeklyReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoursWorked)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGrades)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProgress)).BeginInit();
            this.SuspendLayout();
            
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabProfile);
            this.tabControl.Controls.Add(this.tabRegistration);
            this.tabControl.Controls.Add(this.tabProgress);
            this.tabControl.Controls.Add(this.tabGrades);
            this.tabControl.Controls.Add(this.tabStatistics);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1200, 700);
            this.tabControl.TabIndex = 0;
            
            // 
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.panelProfile);
            this.tabProfile.Location = new System.Drawing.Point(4, 28);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Padding = new System.Windows.Forms.Padding(3);
            this.tabProfile.Size = new System.Drawing.Size(1192, 668);
            this.tabProfile.TabIndex = 0;
            this.tabProfile.Text = "📋 Hồ sơ cá nhân";
            this.tabProfile.UseVisualStyleBackColor = true;
            
            //
            // panelProfile
            //
            this.panelProfile.AutoScroll = true;
            this.panelProfile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelProfile.Location = new System.Drawing.Point(3, 3);
            this.panelProfile.Name = "panelProfile";
            this.panelProfile.Size = new System.Drawing.Size(1186, 662);
            this.panelProfile.TabIndex = 0;
            this.panelProfile.Controls.Add(this.picAvatar);
            this.panelProfile.Controls.Add(this.btnUploadAvatar);
            this.panelProfile.Controls.Add(this.txtFullName);
            this.panelProfile.Controls.Add(this.txtEmail);
            this.panelProfile.Controls.Add(this.txtPhone);
            this.panelProfile.Controls.Add(this.txtStudentCode);
            this.panelProfile.Controls.Add(this.txtDepartment);
            this.panelProfile.Controls.Add(this.txtYear);
            this.panelProfile.Controls.Add(this.rtbDescription);
            this.panelProfile.Controls.Add(this.lblProfileStatus);
            this.panelProfile.Controls.Add(this.btnUploadCV);
            this.panelProfile.Controls.Add(this.btnSaveProfile);

            //
            // picAvatar
            //
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(20, 20);
            this.picAvatar.Name = "picAvatar";
            this.picAvatar.Size = new System.Drawing.Size(150, 150);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAvatar.TabIndex = 0;
            this.picAvatar.TabStop = false;

            //
            // btnUploadAvatar
            //
            this.btnUploadAvatar.BackColor = System.Drawing.Color.FromArgb(0, 84, 166);
            this.btnUploadAvatar.ForeColor = System.Drawing.Color.White;
            this.btnUploadAvatar.Location = new System.Drawing.Point(20, 180);
            this.btnUploadAvatar.Name = "btnUploadAvatar";
            this.btnUploadAvatar.Size = new System.Drawing.Size(150, 35);
            this.btnUploadAvatar.TabIndex = 1;
            this.btnUploadAvatar.Text = "📷 Upload ảnh";
            this.btnUploadAvatar.UseVisualStyleBackColor = false;
            this.btnUploadAvatar.Click += new System.EventHandler(this.btnUploadAvatar_Click);

            //
            // btnSaveProfile
            //
            this.btnSaveProfile.BackColor = System.Drawing.Color.FromArgb(243, 111, 33);
            this.btnSaveProfile.ForeColor = System.Drawing.Color.White;
            this.btnSaveProfile.Location = new System.Drawing.Point(200, 500);
            this.btnSaveProfile.Name = "btnSaveProfile";
            this.btnSaveProfile.Size = new System.Drawing.Size(150, 40);
            this.btnSaveProfile.TabIndex = 10;
            this.btnSaveProfile.Text = "💾 Lưu hồ sơ";
            this.btnSaveProfile.UseVisualStyleBackColor = false;
            this.btnSaveProfile.Click += new System.EventHandler(this.btnSaveProfile_Click);

            //
            // Profile Labels and TextBoxes Layout
            //
            lblFullName.Text = "Họ và tên:";
            lblFullName.Location = new System.Drawing.Point(200, 30);
            lblFullName.Size = new System.Drawing.Size(100, 23);
            this.panelProfile.Controls.Add(lblFullName);

            this.txtFullName.Location = new System.Drawing.Point(310, 30);
            this.txtFullName.Size = new System.Drawing.Size(300, 27);
            this.txtFullName.ReadOnly = false;

            lblEmail.Text = "Email:";
            lblEmail.Location = new System.Drawing.Point(200, 70);
            lblEmail.Size = new System.Drawing.Size(100, 23);
            this.panelProfile.Controls.Add(lblEmail);

            this.txtEmail.Location = new System.Drawing.Point(310, 70);
            this.txtEmail.Size = new System.Drawing.Size(300, 27);
            this.txtEmail.ReadOnly = true;

            lblPhone.Text = "Số điện thoại:";
            lblPhone.Location = new System.Drawing.Point(200, 110);
            lblPhone.Size = new System.Drawing.Size(100, 23);
            this.panelProfile.Controls.Add(lblPhone);

            this.txtPhone.Location = new System.Drawing.Point(310, 110);
            this.txtPhone.Size = new System.Drawing.Size(300, 27);

            lblStudentCode.Text = "Mã sinh viên:";
            lblStudentCode.Location = new System.Drawing.Point(200, 150);
            lblStudentCode.Size = new System.Drawing.Size(100, 23);
            this.panelProfile.Controls.Add(lblStudentCode);

            this.txtStudentCode.Location = new System.Drawing.Point(310, 150);
            this.txtStudentCode.Size = new System.Drawing.Size(300, 27);
            this.txtStudentCode.ReadOnly = true;

            lblDepartment.Text = "Khoa:";
            lblDepartment.Location = new System.Drawing.Point(200, 190);
            lblDepartment.Size = new System.Drawing.Size(100, 23);
            this.panelProfile.Controls.Add(lblDepartment);

            this.txtDepartment.Location = new System.Drawing.Point(310, 190);
            this.txtDepartment.Size = new System.Drawing.Size(300, 27);

            lblYear.Text = "Năm học:";
            lblYear.Location = new System.Drawing.Point(200, 230);
            lblYear.Size = new System.Drawing.Size(100, 23);
            this.panelProfile.Controls.Add(lblYear);

            this.txtYear.Location = new System.Drawing.Point(310, 230);
            this.txtYear.Size = new System.Drawing.Size(300, 27);

            lblDescription.Text = "Giới thiệu:";
            lblDescription.Location = new System.Drawing.Point(200, 270);
            lblDescription.Size = new System.Drawing.Size(100, 23);
            this.panelProfile.Controls.Add(lblDescription);

            this.rtbDescription.Location = new System.Drawing.Point(310, 270);
            this.rtbDescription.Size = new System.Drawing.Size(300, 150);

            this.lblProfileStatus.Location = new System.Drawing.Point(200, 440);
            this.lblProfileStatus.Size = new System.Drawing.Size(400, 30);
            this.lblProfileStatus.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);

            //
            // tabRegistration
            //
            this.tabRegistration.Controls.Add(this.dgvTopics);
            this.tabRegistration.Controls.Add(this.cboTopics);
            this.tabRegistration.Controls.Add(this.cboCompanies);
            this.tabRegistration.Controls.Add(this.btnRegister);
            this.tabRegistration.Controls.Add(this.btnUploadCoverLetter);
            this.tabRegistration.Controls.Add(this.dgvMyRegistrations);
            this.tabRegistration.Location = new System.Drawing.Point(4, 28);
            this.tabRegistration.Name = "tabRegistration";
            this.tabRegistration.Padding = new System.Windows.Forms.Padding(3);
            this.tabRegistration.Size = new System.Drawing.Size(1192, 668);
            this.tabRegistration.TabIndex = 1;
            this.tabRegistration.Text = "📝 Đăng ký thực tập";
            this.tabRegistration.UseVisualStyleBackColor = true;

            //
            // dgvTopics
            //
            this.dgvTopics.AllowUserToAddRows = false;
            this.dgvTopics.AllowUserToDeleteRows = false;
            this.dgvTopics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopics.Location = new System.Drawing.Point(10, 50);
            this.dgvTopics.Name = "dgvTopics";
            this.dgvTopics.ReadOnly = true;
            this.dgvTopics.RowHeadersWidth = 51;
            this.dgvTopics.Size = new System.Drawing.Size(1170, 250);
            this.dgvTopics.TabIndex = 0;

            //
            // cboTopics
            //
            this.cboTopics.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboTopics.FormattingEnabled = true;
            this.cboTopics.Location = new System.Drawing.Point(10, 10);
            this.cboTopics.Name = "cboTopics";
            this.cboTopics.Size = new System.Drawing.Size(400, 28);
            this.cboTopics.TabIndex = 1;

            //
            // cboCompanies
            //
            this.cboCompanies.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCompanies.FormattingEnabled = true;
            this.cboCompanies.Location = new System.Drawing.Point(420, 10);
            this.cboCompanies.Name = "cboCompanies";
            this.cboCompanies.Size = new System.Drawing.Size(400, 28);
            this.cboCompanies.TabIndex = 2;

            //
            // btnRegister
            //
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(830, 10);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(150, 30);
            this.btnRegister.TabIndex = 3;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = false;

            //
            // btnUploadCoverLetter
            //
            this.btnUploadCoverLetter.Location = new System.Drawing.Point(990, 10);
            this.btnUploadCoverLetter.Name = "btnUploadCoverLetter";
            this.btnUploadCoverLetter.Size = new System.Drawing.Size(190, 30);
            this.btnUploadCoverLetter.TabIndex = 4;
            this.btnUploadCoverLetter.Text = "Upload thư giới thiệu";
            this.btnUploadCoverLetter.UseVisualStyleBackColor = true;

            //
            // dgvMyRegistrations
            //
            this.dgvMyRegistrations.AllowUserToAddRows = false;
            this.dgvMyRegistrations.AllowUserToDeleteRows = false;
            this.dgvMyRegistrations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMyRegistrations.Location = new System.Drawing.Point(10, 310);
            this.dgvMyRegistrations.Name = "dgvMyRegistrations";
            this.dgvMyRegistrations.ReadOnly = true;
            this.dgvMyRegistrations.RowHeadersWidth = 51;
            this.dgvMyRegistrations.Size = new System.Drawing.Size(1170, 350);
            this.dgvMyRegistrations.TabIndex = 5;

            //
            // tabProgress
            //
            this.tabProgress.Controls.Add(this.dgvWeeklyReports);
            this.tabProgress.Controls.Add(this.lvWorkLogs);
            this.tabProgress.Controls.Add(this.progressBar);
            this.tabProgress.Controls.Add(this.lblProgressPercent);
            this.tabProgress.Controls.Add(this.lblCompletedWeeks);
            this.tabProgress.Controls.Add(this.lblDaysRemaining);
            this.tabProgress.Controls.Add(this.lblReportDeadline);
            this.tabProgress.Controls.Add(this.lblDefenseDate);
            this.tabProgress.Controls.Add(this.calDeadline);
            this.tabProgress.Location = new System.Drawing.Point(4, 28);
            this.tabProgress.Name = "tabProgress";
            this.tabProgress.Padding = new System.Windows.Forms.Padding(3);
            this.tabProgress.Size = new System.Drawing.Size(1192, 668);
            this.tabProgress.TabIndex = 2;
            this.tabProgress.Text = "📊 Quản lý tiến độ";
            this.tabProgress.UseVisualStyleBackColor = true;

            //
            // tabGrades
            //
            this.tabGrades.Controls.Add(this.dgvGrades);
            this.tabGrades.Controls.Add(this.gbLecturerComment);
            this.tabGrades.Controls.Add(this.gbCompanyComment);
            this.tabGrades.Controls.Add(this.chartGrades);
            this.tabGrades.Controls.Add(this.lblAverageScore);
            this.tabGrades.Location = new System.Drawing.Point(4, 28);
            this.tabGrades.Name = "tabGrades";
            this.tabGrades.Padding = new System.Windows.Forms.Padding(3);
            this.tabGrades.Size = new System.Drawing.Size(1192, 668);
            this.tabGrades.TabIndex = 3;
            this.tabGrades.Text = "⭐ Đánh giá & Điểm";
            this.tabGrades.UseVisualStyleBackColor = true;

            //
            // tabStatistics
            //
            this.tabStatistics.Controls.Add(this.chartProgress);
            this.tabStatistics.Controls.Add(this.lblTotalReports);
            this.tabStatistics.Controls.Add(this.lblSubmittedReports);
            this.tabStatistics.Controls.Add(this.lblTotalWorkLogs);
            this.tabStatistics.Controls.Add(this.lblTotalHours);
            this.tabStatistics.Controls.Add(this.lblStatDaysRemaining);
            this.tabStatistics.Controls.Add(this.lvMilestones);
            this.tabStatistics.Controls.Add(this.pbMilestones);
            this.tabStatistics.Location = new System.Drawing.Point(4, 28);
            this.tabStatistics.Name = "tabStatistics";
            this.tabStatistics.Padding = new System.Windows.Forms.Padding(3);
            this.tabStatistics.Size = new System.Drawing.Size(1192, 668);
            this.tabStatistics.TabIndex = 4;
            this.tabStatistics.Text = "📈 Thống kê";
            this.tabStatistics.UseVisualStyleBackColor = true;

            //
            // dgvWeeklyReports
            //
            this.dgvWeeklyReports.AllowUserToAddRows = false;
            this.dgvWeeklyReports.AllowUserToDeleteRows = false;
            this.dgvWeeklyReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvWeeklyReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvWeeklyReports.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colWeek", HeaderText = "Tuần", Width = 60 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colTitle", HeaderText = "Tiêu đề" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colProgress", HeaderText = "Tiến độ", Width = 80 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colStatus", HeaderText = "Trạng thái", Width = 100 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colSubmitted", HeaderText = "Ngày nộp", Width = 100 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colLecComment", HeaderText = "Nhận xét GV" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colCompComment", HeaderText = "Nhận xét DN" }
            });
            this.dgvWeeklyReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvWeeklyReports.Location = new System.Drawing.Point(3, 3);
            this.dgvWeeklyReports.Name = "dgvWeeklyReports";
            this.dgvWeeklyReports.ReadOnly = true;
            this.dgvWeeklyReports.RowHeadersWidth = 51;
            this.dgvWeeklyReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvWeeklyReports.Size = new System.Drawing.Size(1178, 400);
            this.dgvWeeklyReports.TabIndex = 0;

            //
            // dgvGrades
            //
            this.dgvGrades.AllowUserToAddRows = false;
            this.dgvGrades.AllowUserToDeleteRows = false;
            this.dgvGrades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colCategory", HeaderText = "Hạng mục" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colScore", HeaderText = "Điểm", Width = 80 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colMaxScore", HeaderText = "Điểm tối đa", Width = 100 },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colGrader", HeaderText = "Người chấm" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colComment", HeaderText = "Nhận xét" },
                new System.Windows.Forms.DataGridViewTextBoxColumn { Name = "colGradedAt", HeaderText = "Ngày chấm", Width = 100 }
            });
            this.dgvGrades.Location = new System.Drawing.Point(20, 20);
            this.dgvGrades.Name = "dgvGrades";
            this.dgvGrades.ReadOnly = true;
            this.dgvGrades.RowHeadersWidth = 51;
            this.dgvGrades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrades.Size = new System.Drawing.Size(1140, 250);
            this.dgvGrades.TabIndex = 0;

            //
            // lvMilestones
            //
            this.lvMilestones.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                new System.Windows.Forms.ColumnHeader { Text = "Tiêu đề", Width = 200 },
                new System.Windows.Forms.ColumnHeader { Text = "Mô tả", Width = 300 },
                new System.Windows.Forms.ColumnHeader { Text = "Deadline", Width = 100 },
                new System.Windows.Forms.ColumnHeader { Text = "Trạng thái", Width = 120 },
                new System.Windows.Forms.ColumnHeader { Text = "Hoàn thành", Width = 100 }
            });
            this.lvMilestones.FullRowSelect = true;
            this.lvMilestones.GridLines = true;
            this.lvMilestones.Location = new System.Drawing.Point(20, 350);
            this.lvMilestones.Name = "lvMilestones";
            this.lvMilestones.Size = new System.Drawing.Size(1140, 250);
            this.lvMilestones.TabIndex = 5;
            this.lvMilestones.UseCompatibleStateImageBehavior = false;
            this.lvMilestones.View = System.Windows.Forms.View.Details;

            //
            // StudentForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabControl);
            this.Name = "StudentForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Thực tập - Sinh viên";
            this.tabControl.ResumeLayout(false);
            this.tabProfile.ResumeLayout(false);
            this.tabRegistration.ResumeLayout(false);
            this.tabProgress.ResumeLayout(false);
            this.tabGrades.ResumeLayout(false);
            this.tabStatistics.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMyRegistrations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvWeeklyReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudHoursWorked)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartGrades)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartProgress)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TabPage tabRegistration;
        private System.Windows.Forms.TabPage tabProgress;
        private System.Windows.Forms.TabPage tabGrades;
        private System.Windows.Forms.TabPage tabStatistics;
        private System.Windows.Forms.Panel panelProfile;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtStudentCode;
        private System.Windows.Forms.TextBox txtDepartment;
        private System.Windows.Forms.TextBox txtYear;
        private System.Windows.Forms.RichTextBox rtbDescription;
        private System.Windows.Forms.Label lblProfileStatus;
        private System.Windows.Forms.Button btnUploadAvatar;
        private System.Windows.Forms.Button btnUploadCV;
        private System.Windows.Forms.Button btnSaveProfile;
        private System.Windows.Forms.DataGridView dgvTopics;
        private System.Windows.Forms.ComboBox cboTopics;
        private System.Windows.Forms.ComboBox cboCompanies;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnUploadCoverLetter;
        private System.Windows.Forms.DataGridView dgvMyRegistrations;
        private System.Windows.Forms.TabControl tabControlProgress;
        private System.Windows.Forms.TabPage tabReports;
        private System.Windows.Forms.TabPage tabWorkLogs;
        private System.Windows.Forms.TabPage tabDeadline;
        private System.Windows.Forms.DataGridView dgvWeeklyReports;
        private System.Windows.Forms.Button btnCreateReport;
        private System.Windows.Forms.Button btnSubmitReport;
        private System.Windows.Forms.ListView lvWorkLogs;
        private System.Windows.Forms.RichTextBox rtbWorkLog;
        private System.Windows.Forms.DateTimePicker dtpWorkDate;
        private System.Windows.Forms.TextBox txtWorkTitle;
        private System.Windows.Forms.NumericUpDown nudHoursWorked;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.Button btnSaveWorkLog;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label lblProgressPercent;
        private System.Windows.Forms.Label lblCompletedWeeks;
        private System.Windows.Forms.Label lblDaysRemaining;
        private System.Windows.Forms.Label lblReportDeadline;
        private System.Windows.Forms.Label lblDefenseDate;
        private System.Windows.Forms.MonthCalendar calDeadline;
        private System.Windows.Forms.DataGridView dgvGrades;
        private System.Windows.Forms.GroupBox gbLecturerComment;
        private System.Windows.Forms.RichTextBox rtbLecturerComment;
        private System.Windows.Forms.GroupBox gbCompanyComment;
        private System.Windows.Forms.RichTextBox rtbCompanyComment;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartGrades;
        private System.Windows.Forms.Label lblAverageScore;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartProgress;
        private System.Windows.Forms.Label lblTotalReports;
        private System.Windows.Forms.Label lblSubmittedReports;
        private System.Windows.Forms.Label lblTotalWorkLogs;
        private System.Windows.Forms.Label lblTotalHours;
        private System.Windows.Forms.Label lblStatDaysRemaining;
        private System.Windows.Forms.ListView lvMilestones;
        private System.Windows.Forms.ProgressBar pbMilestones;
    }
}


