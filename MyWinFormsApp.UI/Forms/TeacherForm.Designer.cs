namespace MyWinFormsApp.UI.Forms
{
    partial class TeacherForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabStudents = new System.Windows.Forms.TabPage();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.tabGrading = new System.Windows.Forms.TabPage();
            this.tabDefense = new System.Windows.Forms.TabPage();
            this.tabStatistics = new System.Windows.Forms.TabPage();
            
            // Students Tab Controls
            this.panelStudentsTop = new System.Windows.Forms.Panel();
            this.cboStatusFilter = new System.Windows.Forms.ComboBox();
            this.txtSearchStudent = new System.Windows.Forms.TextBox();
            this.btnSearchStudent = new System.Windows.Forms.Button();
            this.btnRefreshStudents = new System.Windows.Forms.Button();
            this.dgvStudents = new System.Windows.Forms.DataGridView();
            this.lblStudentCount = new System.Windows.Forms.Label();
            
            // Reports Tab Controls
            this.splitContainerReports = new System.Windows.Forms.SplitContainer();
            this.dgvReports = new System.Windows.Forms.DataGridView();
            this.panelReportDetail = new System.Windows.Forms.Panel();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.txtReportContent = new System.Windows.Forms.RichTextBox();
            this.txtLecturerComment = new System.Windows.Forms.RichTextBox();
            this.btnSubmitReview = new System.Windows.Forms.Button();
            this.cboReportStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblReportStatus = new System.Windows.Forms.Label();
            
            // Grading Tab Controls
            this.dgvGrading = new System.Windows.Forms.DataGridView();
            this.panelGradingBottom = new System.Windows.Forms.Panel();
            this.btnSaveGrades = new System.Windows.Forms.Button();
            this.btnExportGrades = new System.Windows.Forms.Button();
            this.lblGradingInfo = new System.Windows.Forms.Label();
            
            // Defense Tab Controls
            this.splitContainerDefense = new System.Windows.Forms.SplitContainer();
            this.calendarDefense = new System.Windows.Forms.MonthCalendar();
            this.dgvDefenseSchedule = new System.Windows.Forms.DataGridView();
            this.panelDefenseControls = new System.Windows.Forms.Panel();
            this.btnCreateDefense = new System.Windows.Forms.Button();
            this.btnDeleteDefense = new System.Windows.Forms.Button();
            this.btnExportDefensePDF = new System.Windows.Forms.Button();
            
            // Statistics Tab Controls
            this.chartStatistics = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.panelStatsTop = new System.Windows.Forms.Panel();
            this.cboStatsFilter = new System.Windows.Forms.ComboBox();
            this.btnExportStats = new System.Windows.Forms.Button();
            this.panelStatsInfo = new System.Windows.Forms.Panel();
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.lblCompletedStudents = new System.Windows.Forms.Label();
            this.lblPendingReports = new System.Windows.Forms.Label();
            this.lblAverageScore = new System.Windows.Forms.Label();
            
            this.tabControl.SuspendLayout();
            this.tabStudents.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.tabGrading.SuspendLayout();
            this.tabDefense.SuspendLayout();
            this.tabStatistics.SuspendLayout();
            this.panelStudentsTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerReports)).BeginInit();
            this.splitContainerReports.Panel1.SuspendLayout();
            this.splitContainerReports.Panel2.SuspendLayout();
            this.splitContainerReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            this.panelReportDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrading)).BeginInit();
            this.panelGradingBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDefense)).BeginInit();
            this.splitContainerDefense.Panel1.SuspendLayout();
            this.splitContainerDefense.Panel2.SuspendLayout();
            this.splitContainerDefense.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefenseSchedule)).BeginInit();
            this.panelDefenseControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistics)).BeginInit();
            this.panelStatsTop.SuspendLayout();
            this.panelStatsInfo.SuspendLayout();
            this.SuspendLayout();
            
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabStudents);
            this.tabControl.Controls.Add(this.tabReports);
            this.tabControl.Controls.Add(this.tabGrading);
            this.tabControl.Controls.Add(this.tabDefense);
            this.tabControl.Controls.Add(this.tabStatistics);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1200, 700);
            this.tabControl.TabIndex = 0;
            
            //
            // tabStudents
            //
            this.tabStudents.BackColor = System.Drawing.Color.White;
            this.tabStudents.Controls.Add(this.dgvStudents);
            this.tabStudents.Controls.Add(this.panelStudentsTop);
            this.tabStudents.Controls.Add(this.lblStudentCount);
            this.tabStudents.Location = new System.Drawing.Point(4, 28);
            this.tabStudents.Name = "tabStudents";
            this.tabStudents.Padding = new System.Windows.Forms.Padding(10);
            this.tabStudents.Size = new System.Drawing.Size(1192, 668);
            this.tabStudents.TabIndex = 0;
            this.tabStudents.Text = "📚 Sinh viên hướng dẫn";

            //
            // panelStudentsTop
            //
            this.panelStudentsTop.Controls.Add(this.cboStatusFilter);
            this.panelStudentsTop.Controls.Add(this.txtSearchStudent);
            this.panelStudentsTop.Controls.Add(this.btnSearchStudent);
            this.panelStudentsTop.Controls.Add(this.btnRefreshStudents);
            this.panelStudentsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStudentsTop.Location = new System.Drawing.Point(10, 10);
            this.panelStudentsTop.Name = "panelStudentsTop";
            this.panelStudentsTop.Size = new System.Drawing.Size(1172, 50);
            this.panelStudentsTop.TabIndex = 0;

            //
            // cboStatusFilter
            //
            this.cboStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatusFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboStatusFilter.FormattingEnabled = true;
            this.cboStatusFilter.Items.AddRange(new object[] {
            "Tất cả",
            "Đang thực tập",
            "Hoàn thành",
            "Thất bại"});
            this.cboStatusFilter.Location = new System.Drawing.Point(10, 10);
            this.cboStatusFilter.Name = "cboStatusFilter";
            this.cboStatusFilter.Size = new System.Drawing.Size(180, 29);
            this.cboStatusFilter.TabIndex = 0;

            //
            // txtSearchStudent
            //
            this.txtSearchStudent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtSearchStudent.Location = new System.Drawing.Point(210, 10);
            this.txtSearchStudent.Name = "txtSearchStudent";
            this.txtSearchStudent.PlaceholderText = "Tìm kiếm theo tên, mã SV...";
            this.txtSearchStudent.Size = new System.Drawing.Size(300, 29);
            this.txtSearchStudent.TabIndex = 1;

            //
            // btnSearchStudent
            //
            this.btnSearchStudent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.btnSearchStudent.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchStudent.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSearchStudent.ForeColor = System.Drawing.Color.White;
            this.btnSearchStudent.Location = new System.Drawing.Point(530, 8);
            this.btnSearchStudent.Name = "btnSearchStudent";
            this.btnSearchStudent.Size = new System.Drawing.Size(100, 35);
            this.btnSearchStudent.TabIndex = 2;
            this.btnSearchStudent.Text = "🔍 Tìm";
            this.btnSearchStudent.UseVisualStyleBackColor = false;

            //
            // btnRefreshStudents
            //
            this.btnRefreshStudents.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(111)))), ((int)(((byte)(33)))));
            this.btnRefreshStudents.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshStudents.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnRefreshStudents.ForeColor = System.Drawing.Color.White;
            this.btnRefreshStudents.Location = new System.Drawing.Point(650, 8);
            this.btnRefreshStudents.Name = "btnRefreshStudents";
            this.btnRefreshStudents.Size = new System.Drawing.Size(120, 35);
            this.btnRefreshStudents.TabIndex = 3;
            this.btnRefreshStudents.Text = "🔄 Làm mới";
            this.btnRefreshStudents.UseVisualStyleBackColor = false;

            //
            // dgvStudents
            //
            this.dgvStudents.AllowUserToAddRows = false;
            this.dgvStudents.AllowUserToDeleteRows = false;
            this.dgvStudents.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudents.BackgroundColor = System.Drawing.Color.White;
            this.dgvStudents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudents.Location = new System.Drawing.Point(10, 60);
            this.dgvStudents.Name = "dgvStudents";
            this.dgvStudents.ReadOnly = true;
            this.dgvStudents.RowHeadersWidth = 51;
            this.dgvStudents.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvStudents.Size = new System.Drawing.Size(1172, 568);
            this.dgvStudents.TabIndex = 1;

            //
            // lblStudentCount
            //
            this.lblStudentCount.AutoSize = true;
            this.lblStudentCount.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblStudentCount.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblStudentCount.Location = new System.Drawing.Point(10, 628);
            this.lblStudentCount.Name = "lblStudentCount";
            this.lblStudentCount.Padding = new System.Windows.Forms.Padding(5);
            this.lblStudentCount.Size = new System.Drawing.Size(150, 30);
            this.lblStudentCount.TabIndex = 2;
            this.lblStudentCount.Text = "Tổng số: 0 sinh viên";

            //
            // tabReports
            //
            this.tabReports.BackColor = System.Drawing.Color.White;
            this.tabReports.Controls.Add(this.splitContainerReports);
            this.tabReports.Location = new System.Drawing.Point(4, 28);
            this.tabReports.Name = "tabReports";
            this.tabReports.Padding = new System.Windows.Forms.Padding(10);
            this.tabReports.Size = new System.Drawing.Size(1192, 668);
            this.tabReports.TabIndex = 1;
            this.tabReports.Text = "📝 Phản hồi báo cáo";

            //
            // splitContainerReports
            //
            this.splitContainerReports.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerReports.Location = new System.Drawing.Point(10, 10);
            this.splitContainerReports.Name = "splitContainerReports";
            this.splitContainerReports.Orientation = System.Windows.Forms.Orientation.Horizontal;
            //
            // splitContainerReports.Panel1
            //
            this.splitContainerReports.Panel1.Controls.Add(this.dgvReports);
            this.splitContainerReports.Panel1.Controls.Add(this.cboReportStatusFilter);
            this.splitContainerReports.Panel1.Controls.Add(this.lblReportStatus);
            //
            // splitContainerReports.Panel2
            //
            this.splitContainerReports.Panel2.Controls.Add(this.panelReportDetail);
            this.splitContainerReports.Size = new System.Drawing.Size(1172, 648);
            this.splitContainerReports.SplitterDistance = 320;
            this.splitContainerReports.TabIndex = 0;

            //
            // lblReportStatus
            //
            this.lblReportStatus.AutoSize = true;
            this.lblReportStatus.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblReportStatus.Location = new System.Drawing.Point(10, 10);
            this.lblReportStatus.Name = "lblReportStatus";
            this.lblReportStatus.Size = new System.Drawing.Size(100, 23);
            this.lblReportStatus.TabIndex = 0;
            this.lblReportStatus.Text = "Lọc theo:";

            //
            // cboReportStatusFilter
            //
            this.cboReportStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportStatusFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboReportStatusFilter.FormattingEnabled = true;
            this.cboReportStatusFilter.Items.AddRange(new object[] {
            "Tất cả",
            "Chờ phản hồi",
            "Đã phản hồi"});
            this.cboReportStatusFilter.Location = new System.Drawing.Point(120, 8);
            this.cboReportStatusFilter.Name = "cboReportStatusFilter";
            this.cboReportStatusFilter.Size = new System.Drawing.Size(180, 29);
            this.cboReportStatusFilter.TabIndex = 1;

            //
            // dgvReports
            //
            this.dgvReports.AllowUserToAddRows = false;
            this.dgvReports.AllowUserToDeleteRows = false;
            this.dgvReports.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReports.BackgroundColor = System.Drawing.Color.White;
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Location = new System.Drawing.Point(10, 45);
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.ReadOnly = true;
            this.dgvReports.RowHeadersWidth = 51;
            this.dgvReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReports.Size = new System.Drawing.Size(1152, 265);
            this.dgvReports.TabIndex = 2;

            //
            // panelReportDetail
            //
            this.panelReportDetail.Controls.Add(this.lblReportTitle);
            this.panelReportDetail.Controls.Add(this.txtReportContent);
            this.panelReportDetail.Controls.Add(this.txtLecturerComment);
            this.panelReportDetail.Controls.Add(this.btnSubmitReview);
            this.panelReportDetail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReportDetail.Location = new System.Drawing.Point(0, 0);
            this.panelReportDetail.Name = "panelReportDetail";
            this.panelReportDetail.Padding = new System.Windows.Forms.Padding(10);
            this.panelReportDetail.Size = new System.Drawing.Size(1172, 324);
            this.panelReportDetail.TabIndex = 0;

            //
            // lblReportTitle
            //
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblReportTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblReportTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.lblReportTitle.Location = new System.Drawing.Point(10, 10);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Padding = new System.Windows.Forms.Padding(0, 0, 0, 10);
            this.lblReportTitle.Size = new System.Drawing.Size(250, 35);
            this.lblReportTitle.TabIndex = 0;
            this.lblReportTitle.Text = "Chọn báo cáo để xem chi tiết";

            //
            // txtReportContent
            //
            this.txtReportContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReportContent.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtReportContent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtReportContent.Location = new System.Drawing.Point(10, 50);
            this.txtReportContent.Name = "txtReportContent";
            this.txtReportContent.ReadOnly = true;
            this.txtReportContent.Size = new System.Drawing.Size(1152, 120);
            this.txtReportContent.TabIndex = 1;
            this.txtReportContent.Text = "";

            //
            // txtLecturerComment
            //
            this.txtLecturerComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLecturerComment.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLecturerComment.Location = new System.Drawing.Point(10, 180);
            this.txtLecturerComment.Name = "txtLecturerComment";
            this.txtLecturerComment.Size = new System.Drawing.Size(1152, 90);
            this.txtLecturerComment.TabIndex = 2;
            this.txtLecturerComment.Text = "";

            //
            // btnSubmitReview
            //
            this.btnSubmitReview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitReview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.btnSubmitReview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitReview.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSubmitReview.ForeColor = System.Drawing.Color.White;
            this.btnSubmitReview.Location = new System.Drawing.Point(1012, 280);
            this.btnSubmitReview.Name = "btnSubmitReview";
            this.btnSubmitReview.Size = new System.Drawing.Size(150, 35);
            this.btnSubmitReview.TabIndex = 3;
            this.btnSubmitReview.Text = "✅ Gửi phản hồi";
            this.btnSubmitReview.UseVisualStyleBackColor = false;

            //
            // tabGrading
            //
            this.tabGrading.BackColor = System.Drawing.Color.White;
            this.tabGrading.Controls.Add(this.dgvGrading);
            this.tabGrading.Controls.Add(this.panelGradingBottom);
            this.tabGrading.Location = new System.Drawing.Point(4, 28);
            this.tabGrading.Name = "tabGrading";
            this.tabGrading.Padding = new System.Windows.Forms.Padding(10);
            this.tabGrading.Size = new System.Drawing.Size(1192, 668);
            this.tabGrading.TabIndex = 2;
            this.tabGrading.Text = "📊 Nhập điểm";

            //
            // dgvGrading
            //
            this.dgvGrading.AllowUserToAddRows = false;
            this.dgvGrading.AllowUserToDeleteRows = false;
            this.dgvGrading.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvGrading.BackgroundColor = System.Drawing.Color.White;
            this.dgvGrading.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvGrading.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvGrading.Location = new System.Drawing.Point(10, 10);
            this.dgvGrading.Name = "dgvGrading";
            this.dgvGrading.RowHeadersWidth = 51;
            this.dgvGrading.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvGrading.Size = new System.Drawing.Size(1172, 588);
            this.dgvGrading.TabIndex = 0;

            //
            // panelGradingBottom
            //
            this.panelGradingBottom.Controls.Add(this.lblGradingInfo);
            this.panelGradingBottom.Controls.Add(this.btnSaveGrades);
            this.panelGradingBottom.Controls.Add(this.btnExportGrades);
            this.panelGradingBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelGradingBottom.Location = new System.Drawing.Point(10, 598);
            this.panelGradingBottom.Name = "panelGradingBottom";
            this.panelGradingBottom.Size = new System.Drawing.Size(1172, 60);
            this.panelGradingBottom.TabIndex = 1;

            //
            // lblGradingInfo
            //
            this.lblGradingInfo.AutoSize = true;
            this.lblGradingInfo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic);
            this.lblGradingInfo.Location = new System.Drawing.Point(10, 15);
            this.lblGradingInfo.Name = "lblGradingInfo";
            this.lblGradingInfo.Size = new System.Drawing.Size(400, 20);
            this.lblGradingInfo.TabIndex = 0;
            this.lblGradingInfo.Text = "💡 Click đúp vào ô để chỉnh sửa điểm. Điểm tổng = QT*30% + BC*30% + BV*40%";

            //
            // btnSaveGrades
            //
            this.btnSaveGrades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveGrades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.btnSaveGrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveGrades.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnSaveGrades.ForeColor = System.Drawing.Color.White;
            this.btnSaveGrades.Location = new System.Drawing.Point(892, 10);
            this.btnSaveGrades.Name = "btnSaveGrades";
            this.btnSaveGrades.Size = new System.Drawing.Size(130, 40);
            this.btnSaveGrades.TabIndex = 1;
            this.btnSaveGrades.Text = "💾 Lưu điểm";
            this.btnSaveGrades.UseVisualStyleBackColor = false;

            //
            // btnExportGrades
            //
            this.btnExportGrades.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportGrades.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(111)))), ((int)(((byte)(33)))));
            this.btnExportGrades.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportGrades.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportGrades.ForeColor = System.Drawing.Color.White;
            this.btnExportGrades.Location = new System.Drawing.Point(1032, 10);
            this.btnExportGrades.Name = "btnExportGrades";
            this.btnExportGrades.Size = new System.Drawing.Size(130, 40);
            this.btnExportGrades.TabIndex = 2;
            this.btnExportGrades.Text = "📊 Xuất Excel";
            this.btnExportGrades.UseVisualStyleBackColor = false;

            //
            // tabDefense
            //
            this.tabDefense.BackColor = System.Drawing.Color.White;
            this.tabDefense.Controls.Add(this.splitContainerDefense);
            this.tabDefense.Controls.Add(this.panelDefenseControls);
            this.tabDefense.Location = new System.Drawing.Point(4, 28);
            this.tabDefense.Name = "tabDefense";
            this.tabDefense.Padding = new System.Windows.Forms.Padding(10);
            this.tabDefense.Size = new System.Drawing.Size(1192, 668);
            this.tabDefense.TabIndex = 3;
            this.tabDefense.Text = "📅 Lịch bảo vệ";

            //
            // splitContainerDefense
            //
            this.splitContainerDefense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerDefense.Location = new System.Drawing.Point(10, 10);
            this.splitContainerDefense.Name = "splitContainerDefense";
            //
            // splitContainerDefense.Panel1
            //
            this.splitContainerDefense.Panel1.Controls.Add(this.calendarDefense);
            //
            // splitContainerDefense.Panel2
            //
            this.splitContainerDefense.Panel2.Controls.Add(this.dgvDefenseSchedule);
            this.splitContainerDefense.Size = new System.Drawing.Size(1172, 588);
            this.splitContainerDefense.SplitterDistance = 350;
            this.splitContainerDefense.TabIndex = 0;

            //
            // calendarDefense
            //
            this.calendarDefense.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendarDefense.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.calendarDefense.Location = new System.Drawing.Point(0, 0);
            this.calendarDefense.Name = "calendarDefense";
            this.calendarDefense.TabIndex = 0;

            //
            // dgvDefenseSchedule
            //
            this.dgvDefenseSchedule.AllowUserToAddRows = false;
            this.dgvDefenseSchedule.AllowUserToDeleteRows = false;
            this.dgvDefenseSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDefenseSchedule.BackgroundColor = System.Drawing.Color.White;
            this.dgvDefenseSchedule.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDefenseSchedule.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDefenseSchedule.Location = new System.Drawing.Point(0, 0);
            this.dgvDefenseSchedule.Name = "dgvDefenseSchedule";
            this.dgvDefenseSchedule.ReadOnly = true;
            this.dgvDefenseSchedule.RowHeadersWidth = 51;
            this.dgvDefenseSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDefenseSchedule.Size = new System.Drawing.Size(818, 588);
            this.dgvDefenseSchedule.TabIndex = 0;

            //
            // panelDefenseControls
            //
            this.panelDefenseControls.Controls.Add(this.btnCreateDefense);
            this.panelDefenseControls.Controls.Add(this.btnDeleteDefense);
            this.panelDefenseControls.Controls.Add(this.btnExportDefensePDF);
            this.panelDefenseControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelDefenseControls.Location = new System.Drawing.Point(10, 598);
            this.panelDefenseControls.Name = "panelDefenseControls";
            this.panelDefenseControls.Size = new System.Drawing.Size(1172, 60);
            this.panelDefenseControls.TabIndex = 1;

            //
            // btnCreateDefense
            //
            this.btnCreateDefense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreateDefense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.btnCreateDefense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreateDefense.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnCreateDefense.ForeColor = System.Drawing.Color.White;
            this.btnCreateDefense.Location = new System.Drawing.Point(752, 10);
            this.btnCreateDefense.Name = "btnCreateDefense";
            this.btnCreateDefense.Size = new System.Drawing.Size(130, 40);
            this.btnCreateDefense.TabIndex = 0;
            this.btnCreateDefense.Text = "➕ Tạo lịch";
            this.btnCreateDefense.UseVisualStyleBackColor = false;

            //
            // btnDeleteDefense
            //
            this.btnDeleteDefense.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDeleteDefense.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDeleteDefense.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteDefense.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnDeleteDefense.ForeColor = System.Drawing.Color.White;
            this.btnDeleteDefense.Location = new System.Drawing.Point(892, 10);
            this.btnDeleteDefense.Name = "btnDeleteDefense";
            this.btnDeleteDefense.Size = new System.Drawing.Size(130, 40);
            this.btnDeleteDefense.TabIndex = 1;
            this.btnDeleteDefense.Text = "🗑️ Xóa";
            this.btnDeleteDefense.UseVisualStyleBackColor = false;

            //
            // btnExportDefensePDF
            //
            this.btnExportDefensePDF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportDefensePDF.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(111)))), ((int)(((byte)(33)))));
            this.btnExportDefensePDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportDefensePDF.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportDefensePDF.ForeColor = System.Drawing.Color.White;
            this.btnExportDefensePDF.Location = new System.Drawing.Point(1032, 10);
            this.btnExportDefensePDF.Name = "btnExportDefensePDF";
            this.btnExportDefensePDF.Size = new System.Drawing.Size(130, 40);
            this.btnExportDefensePDF.TabIndex = 2;
            this.btnExportDefensePDF.Text = "📄 Xuất PDF";
            this.btnExportDefensePDF.UseVisualStyleBackColor = false;

            //
            // tabStatistics
            //
            this.tabStatistics.BackColor = System.Drawing.Color.White;
            this.tabStatistics.Controls.Add(this.chartStatistics);
            this.tabStatistics.Controls.Add(this.panelStatsInfo);
            this.tabStatistics.Controls.Add(this.panelStatsTop);
            this.tabStatistics.Location = new System.Drawing.Point(4, 28);
            this.tabStatistics.Name = "tabStatistics";
            this.tabStatistics.Padding = new System.Windows.Forms.Padding(10);
            this.tabStatistics.Size = new System.Drawing.Size(1192, 668);
            this.tabStatistics.TabIndex = 4;
            this.tabStatistics.Text = "📈 Thống kê";

            //
            // panelStatsTop
            //
            this.panelStatsTop.Controls.Add(this.cboStatsFilter);
            this.panelStatsTop.Controls.Add(this.btnExportStats);
            this.panelStatsTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStatsTop.Location = new System.Drawing.Point(10, 10);
            this.panelStatsTop.Name = "panelStatsTop";
            this.panelStatsTop.Size = new System.Drawing.Size(1172, 50);
            this.panelStatsTop.TabIndex = 0;

            //
            // cboStatsFilter
            //
            this.cboStatsFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboStatsFilter.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboStatsFilter.FormattingEnabled = true;
            this.cboStatsFilter.Items.AddRange(new object[] {
            "Tổng quan",
            "Theo doanh nghiệp",
            "Theo đề tài"});
            this.cboStatsFilter.Location = new System.Drawing.Point(10, 10);
            this.cboStatsFilter.Name = "cboStatsFilter";
            this.cboStatsFilter.Size = new System.Drawing.Size(200, 29);
            this.cboStatsFilter.TabIndex = 0;

            //
            // btnExportStats
            //
            this.btnExportStats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExportStats.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(111)))), ((int)(((byte)(33)))));
            this.btnExportStats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportStats.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnExportStats.ForeColor = System.Drawing.Color.White;
            this.btnExportStats.Location = new System.Drawing.Point(1032, 8);
            this.btnExportStats.Name = "btnExportStats";
            this.btnExportStats.Size = new System.Drawing.Size(130, 35);
            this.btnExportStats.TabIndex = 1;
            this.btnExportStats.Text = "📊 Xuất Excel";
            this.btnExportStats.UseVisualStyleBackColor = false;

            //
            // panelStatsInfo
            //
            this.panelStatsInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(248)))), ((int)(((byte)(255)))));
            this.panelStatsInfo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatsInfo.Controls.Add(this.lblTotalStudents);
            this.panelStatsInfo.Controls.Add(this.lblCompletedStudents);
            this.panelStatsInfo.Controls.Add(this.lblPendingReports);
            this.panelStatsInfo.Controls.Add(this.lblAverageScore);
            this.panelStatsInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelStatsInfo.Location = new System.Drawing.Point(10, 60);
            this.panelStatsInfo.Name = "panelStatsInfo";
            this.panelStatsInfo.Padding = new System.Windows.Forms.Padding(10);
            this.panelStatsInfo.Size = new System.Drawing.Size(1172, 100);
            this.panelStatsInfo.TabIndex = 1;

            //
            // lblTotalStudents
            //
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblTotalStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.lblTotalStudents.Location = new System.Drawing.Point(20, 20);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(200, 25);
            this.lblTotalStudents.TabIndex = 0;
            this.lblTotalStudents.Text = "👥 Tổng SV: 0";

            //
            // lblCompletedStudents
            //
            this.lblCompletedStudents.AutoSize = true;
            this.lblCompletedStudents.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblCompletedStudents.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(167)))), ((int)(((byte)(69)))));
            this.lblCompletedStudents.Location = new System.Drawing.Point(320, 20);
            this.lblCompletedStudents.Name = "lblCompletedStudents";
            this.lblCompletedStudents.Size = new System.Drawing.Size(200, 25);
            this.lblCompletedStudents.TabIndex = 1;
            this.lblCompletedStudents.Text = "✅ Hoàn thành: 0";

            //
            // lblPendingReports
            //
            this.lblPendingReports.AutoSize = true;
            this.lblPendingReports.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblPendingReports.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(111)))), ((int)(((byte)(33)))));
            this.lblPendingReports.Location = new System.Drawing.Point(620, 20);
            this.lblPendingReports.Name = "lblPendingReports";
            this.lblPendingReports.Size = new System.Drawing.Size(200, 25);
            this.lblPendingReports.TabIndex = 2;
            this.lblPendingReports.Text = "⏳ BC chờ duyệt: 0";

            //
            // lblAverageScore
            //
            this.lblAverageScore.AutoSize = true;
            this.lblAverageScore.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblAverageScore.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(66)))), ((int)(((byte)(193)))));
            this.lblAverageScore.Location = new System.Drawing.Point(20, 55);
            this.lblAverageScore.Name = "lblAverageScore";
            this.lblAverageScore.Size = new System.Drawing.Size(200, 25);
            this.lblAverageScore.TabIndex = 3;
            this.lblAverageScore.Text = "📊 Điểm TB: 0.0";

            //
            // chartStatistics
            //
            this.chartStatistics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chartStatistics.Location = new System.Drawing.Point(10, 160);
            this.chartStatistics.Name = "chartStatistics";
            this.chartStatistics.Size = new System.Drawing.Size(1172, 498);
            this.chartStatistics.TabIndex = 2;
            this.chartStatistics.Text = "chart1";

            //
            // TeacherForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Name = "TeacherForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Giảng viên - Lac Hong University";
            this.Load += new System.EventHandler(this.TeacherForm_Load);
            this.tabControl.ResumeLayout(false);
            this.tabStudents.ResumeLayout(false);
            this.tabStudents.PerformLayout();
            this.tabReports.ResumeLayout(false);
            this.tabGrading.ResumeLayout(false);
            this.tabDefense.ResumeLayout(false);
            this.tabStatistics.ResumeLayout(false);
            this.panelStudentsTop.ResumeLayout(false);
            this.panelStudentsTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudents)).EndInit();
            this.splitContainerReports.Panel1.ResumeLayout(false);
            this.splitContainerReports.Panel1.PerformLayout();
            this.splitContainerReports.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerReports)).EndInit();
            this.splitContainerReports.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            this.panelReportDetail.ResumeLayout(false);
            this.panelReportDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvGrading)).EndInit();
            this.panelGradingBottom.ResumeLayout(false);
            this.panelGradingBottom.PerformLayout();
            this.splitContainerDefense.Panel1.ResumeLayout(false);
            this.splitContainerDefense.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerDefense)).EndInit();
            this.splitContainerDefense.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDefenseSchedule)).EndInit();
            this.panelDefenseControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chartStatistics)).EndInit();
            this.panelStatsTop.ResumeLayout(false);
            this.panelStatsInfo.ResumeLayout(false);
            this.panelStatsInfo.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabStudents;
        private System.Windows.Forms.TabPage tabReports;
        private System.Windows.Forms.TabPage tabGrading;
        private System.Windows.Forms.TabPage tabDefense;
        private System.Windows.Forms.TabPage tabStatistics;

        // Students Tab
        private System.Windows.Forms.Panel panelStudentsTop;
        private System.Windows.Forms.ComboBox cboStatusFilter;
        private System.Windows.Forms.TextBox txtSearchStudent;
        private System.Windows.Forms.Button btnSearchStudent;
        private System.Windows.Forms.Button btnRefreshStudents;
        private System.Windows.Forms.DataGridView dgvStudents;
        private System.Windows.Forms.Label lblStudentCount;

        // Reports Tab
        private System.Windows.Forms.SplitContainer splitContainerReports;
        private System.Windows.Forms.DataGridView dgvReports;
        private System.Windows.Forms.Panel panelReportDetail;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.RichTextBox txtReportContent;
        private System.Windows.Forms.RichTextBox txtLecturerComment;
        private System.Windows.Forms.Button btnSubmitReview;
        private System.Windows.Forms.ComboBox cboReportStatusFilter;
        private System.Windows.Forms.Label lblReportStatus;

        // Grading Tab
        private System.Windows.Forms.DataGridView dgvGrading;
        private System.Windows.Forms.Panel panelGradingBottom;
        private System.Windows.Forms.Button btnSaveGrades;
        private System.Windows.Forms.Button btnExportGrades;
        private System.Windows.Forms.Label lblGradingInfo;

        // Defense Tab
        private System.Windows.Forms.SplitContainer splitContainerDefense;
        private System.Windows.Forms.MonthCalendar calendarDefense;
        private System.Windows.Forms.DataGridView dgvDefenseSchedule;
        private System.Windows.Forms.Panel panelDefenseControls;
        private System.Windows.Forms.Button btnCreateDefense;
        private System.Windows.Forms.Button btnDeleteDefense;
        private System.Windows.Forms.Button btnExportDefensePDF;

        // Statistics Tab
        private System.Windows.Forms.DataVisualization.Charting.Chart chartStatistics;
        private System.Windows.Forms.Panel panelStatsTop;
        private System.Windows.Forms.ComboBox cboStatsFilter;
        private System.Windows.Forms.Button btnExportStats;
        private System.Windows.Forms.Panel panelStatsInfo;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.Label lblCompletedStudents;
        private System.Windows.Forms.Label lblPendingReports;
        private System.Windows.Forms.Label lblAverageScore;
    }
}

