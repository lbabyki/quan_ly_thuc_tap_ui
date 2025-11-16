namespace MyWinFormsApp.UI.Forms
{
    partial class CompanyForm
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
            this.tabConfirmations = new System.Windows.Forms.TabPage();
            this.tabEvaluations = new System.Windows.Forms.TabPage();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.tabTopics = new System.Windows.Forms.TabPage();

            // Tab Confirmations controls
            this.dgvConfirmations = new System.Windows.Forms.DataGridView();
            this.cboConfirmStatusFilter = new System.Windows.Forms.ComboBox();
            this.lblConfirmFilter = new System.Windows.Forms.Label();
            this.btnRefreshConfirmations = new System.Windows.Forms.Button();

            // Tab Evaluations controls
            this.dgvEvaluations = new System.Windows.Forms.DataGridView();
            this.grpEvaluationForm = new System.Windows.Forms.GroupBox();
            this.lblStudent = new System.Windows.Forms.Label();
            this.txtStudentName = new System.Windows.Forms.TextBox();
            this.lblAttendance = new System.Windows.Forms.Label();
            this.numAttendance = new System.Windows.Forms.NumericUpDown();
            this.lblAttitude = new System.Windows.Forms.Label();
            this.numAttitude = new System.Windows.Forms.NumericUpDown();
            this.lblSkill = new System.Windows.Forms.Label();
            this.numSkill = new System.Windows.Forms.NumericUpDown();
            this.lblResult = new System.Windows.Forms.Label();
            this.numResult = new System.Windows.Forms.NumericUpDown();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.lblComment = new System.Windows.Forms.Label();
            this.rtbComment = new System.Windows.Forms.RichTextBox();
            this.btnSubmitEvaluation = new System.Windows.Forms.Button();
            this.btnCancelEvaluation = new System.Windows.Forms.Button();

            // Tab Reports controls
            this.grpReportForm = new System.Windows.Forms.GroupBox();
            this.lblReportTitle = new System.Windows.Forms.Label();
            this.txtReportTitle = new System.Windows.Forms.TextBox();
            this.lblReportContent = new System.Windows.Forms.Label();
            this.rtbReportContent = new System.Windows.Forms.RichTextBox();
            this.lblPeriod = new System.Windows.Forms.Label();
            this.txtPeriod = new System.Windows.Forms.TextBox();
            this.lblTotalStudents = new System.Windows.Forms.Label();
            this.numTotalStudents = new System.Windows.Forms.NumericUpDown();
            this.lblCompletedStudents = new System.Windows.Forms.Label();
            this.numCompletedStudents = new System.Windows.Forms.NumericUpDown();
            this.lblAttachments = new System.Windows.Forms.Label();
            this.lvAttachments = new System.Windows.Forms.ListView();
            this.btnAddAttachment = new System.Windows.Forms.Button();
            this.btnRemoveAttachment = new System.Windows.Forms.Button();
            this.btnSubmitReport = new System.Windows.Forms.Button();
            this.dgvReports = new System.Windows.Forms.DataGridView();

            // Tab Topics controls
            this.dgvTopics = new System.Windows.Forms.DataGridView();
            this.btnAddTopic = new System.Windows.Forms.Button();
            this.btnEditTopic = new System.Windows.Forms.Button();
            this.btnDeleteTopic = new System.Windows.Forms.Button();
            this.btnRefreshTopics = new System.Windows.Forms.Button();

            this.tabControl.SuspendLayout();
            this.tabConfirmations.SuspendLayout();
            this.tabEvaluations.SuspendLayout();
            this.tabReports.SuspendLayout();
            this.tabTopics.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConfirmations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvaluations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAttendance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAttitude)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkill)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numResult)).BeginInit();
            this.grpEvaluationForm.SuspendLayout();
            this.grpReportForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCompletedStudents)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopics)).BeginInit();
            this.SuspendLayout();

            //
            // tabControl
            //
            this.tabControl.Controls.Add(this.tabConfirmations);
            this.tabControl.Controls.Add(this.tabEvaluations);
            this.tabControl.Controls.Add(this.tabReports);
            this.tabControl.Controls.Add(this.tabTopics);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1200, 700);
            this.tabControl.TabIndex = 0;
            this.tabControl.Visible = true;

            //
            // tabConfirmations
            //
            this.tabConfirmations.BackColor = System.Drawing.Color.White;
            this.tabConfirmations.Controls.Add(this.lblConfirmFilter);
            this.tabConfirmations.Controls.Add(this.cboConfirmStatusFilter);
            this.tabConfirmations.Controls.Add(this.btnRefreshConfirmations);
            this.tabConfirmations.Controls.Add(this.dgvConfirmations);
            this.tabConfirmations.Location = new System.Drawing.Point(4, 28);
            this.tabConfirmations.Name = "tabConfirmations";
            this.tabConfirmations.Padding = new System.Windows.Forms.Padding(10);
            this.tabConfirmations.Size = new System.Drawing.Size(1192, 668);
            this.tabConfirmations.TabIndex = 0;
            this.tabConfirmations.Text = "✅ Xác nhận sinh viên";

            // 
            // lblConfirmFilter
            // 
            this.lblConfirmFilter.AutoSize = true;
            this.lblConfirmFilter.Location = new System.Drawing.Point(10, 15);
            this.lblConfirmFilter.Name = "lblConfirmFilter";
            this.lblConfirmFilter.Size = new System.Drawing.Size(75, 19);
            this.lblConfirmFilter.TabIndex = 0;
            this.lblConfirmFilter.Text = "Trạng thái:";

            // 
            // cboConfirmStatusFilter
            // 
            this.cboConfirmStatusFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboConfirmStatusFilter.FormattingEnabled = true;
            this.cboConfirmStatusFilter.Items.AddRange(new object[] {
            "Tất cả",
            "Chờ xác nhận",
            "Đã xác nhận",
            "Đã từ chối"});
            this.cboConfirmStatusFilter.Location = new System.Drawing.Point(90, 12);
            this.cboConfirmStatusFilter.Name = "cboConfirmStatusFilter";
            this.cboConfirmStatusFilter.Size = new System.Drawing.Size(200, 27);
            this.cboConfirmStatusFilter.TabIndex = 1;
            this.cboConfirmStatusFilter.SelectedIndex = 0;

            //
            // btnRefreshConfirmations
            //
            this.btnRefreshConfirmations.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.btnRefreshConfirmations.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshConfirmations.ForeColor = System.Drawing.Color.White;
            this.btnRefreshConfirmations.Location = new System.Drawing.Point(300, 10);
            this.btnRefreshConfirmations.Name = "btnRefreshConfirmations";
            this.btnRefreshConfirmations.Size = new System.Drawing.Size(100, 32);
            this.btnRefreshConfirmations.TabIndex = 2;
            this.btnRefreshConfirmations.Text = "Làm mới";
            this.btnRefreshConfirmations.UseVisualStyleBackColor = false;

            //
            // dgvConfirmations
            //
            this.dgvConfirmations.AllowUserToAddRows = false;
            this.dgvConfirmations.AllowUserToDeleteRows = false;
            this.dgvConfirmations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConfirmations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConfirmations.BackgroundColor = System.Drawing.Color.White;
            this.dgvConfirmations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConfirmations.Location = new System.Drawing.Point(10, 50);
            this.dgvConfirmations.MultiSelect = false;
            this.dgvConfirmations.Name = "dgvConfirmations";
            this.dgvConfirmations.ReadOnly = false;
            this.dgvConfirmations.RowHeadersWidth = 51;
            this.dgvConfirmations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConfirmations.Size = new System.Drawing.Size(1172, 608);
            this.dgvConfirmations.TabIndex = 3;

            //
            // tabEvaluations
            //
            this.tabEvaluations.BackColor = System.Drawing.Color.White;
            this.tabEvaluations.Controls.Add(this.grpEvaluationForm);
            this.tabEvaluations.Controls.Add(this.dgvEvaluations);
            this.tabEvaluations.Location = new System.Drawing.Point(4, 28);
            this.tabEvaluations.Name = "tabEvaluations";
            this.tabEvaluations.Padding = new System.Windows.Forms.Padding(10);
            this.tabEvaluations.Size = new System.Drawing.Size(1192, 668);
            this.tabEvaluations.TabIndex = 1;
            this.tabEvaluations.Text = "Đánh giá sinh viên";

            //
            // dgvEvaluations
            //
            this.dgvEvaluations.AllowUserToAddRows = false;
            this.dgvEvaluations.AllowUserToDeleteRows = false;
            this.dgvEvaluations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEvaluations.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEvaluations.BackgroundColor = System.Drawing.Color.White;
            this.dgvEvaluations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEvaluations.Location = new System.Drawing.Point(10, 10);
            this.dgvEvaluations.MultiSelect = false;
            this.dgvEvaluations.Name = "dgvEvaluations";
            this.dgvEvaluations.ReadOnly = true;
            this.dgvEvaluations.RowHeadersWidth = 51;
            this.dgvEvaluations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEvaluations.Size = new System.Drawing.Size(1172, 250);
            this.dgvEvaluations.TabIndex = 0;

            //
            // grpEvaluationForm
            //
            this.grpEvaluationForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEvaluationForm.Controls.Add(this.lblStudent);
            this.grpEvaluationForm.Controls.Add(this.txtStudentName);
            this.grpEvaluationForm.Controls.Add(this.lblAttendance);
            this.grpEvaluationForm.Controls.Add(this.numAttendance);
            this.grpEvaluationForm.Controls.Add(this.lblAttitude);
            this.grpEvaluationForm.Controls.Add(this.numAttitude);
            this.grpEvaluationForm.Controls.Add(this.lblSkill);
            this.grpEvaluationForm.Controls.Add(this.numSkill);
            this.grpEvaluationForm.Controls.Add(this.lblResult);
            this.grpEvaluationForm.Controls.Add(this.numResult);
            this.grpEvaluationForm.Controls.Add(this.lblTotal);
            this.grpEvaluationForm.Controls.Add(this.txtTotal);
            this.grpEvaluationForm.Controls.Add(this.lblComment);
            this.grpEvaluationForm.Controls.Add(this.rtbComment);
            this.grpEvaluationForm.Controls.Add(this.btnSubmitEvaluation);
            this.grpEvaluationForm.Controls.Add(this.btnCancelEvaluation);
            this.grpEvaluationForm.Location = new System.Drawing.Point(10, 270);
            this.grpEvaluationForm.Name = "grpEvaluationForm";
            this.grpEvaluationForm.Size = new System.Drawing.Size(1172, 388);
            this.grpEvaluationForm.TabIndex = 1;
            this.grpEvaluationForm.TabStop = false;
            this.grpEvaluationForm.Text = "Form đánh giá";

            //
            // lblStudent
            //
            this.lblStudent.AutoSize = true;
            this.lblStudent.Location = new System.Drawing.Point(20, 35);
            this.lblStudent.Name = "lblStudent";
            this.lblStudent.Size = new System.Drawing.Size(70, 19);
            this.lblStudent.TabIndex = 0;
            this.lblStudent.Text = "Sinh viên:";

            //
            // txtStudentName
            //
            this.txtStudentName.Location = new System.Drawing.Point(150, 32);
            this.txtStudentName.Name = "txtStudentName";
            this.txtStudentName.ReadOnly = true;
            this.txtStudentName.Size = new System.Drawing.Size(400, 25);
            this.txtStudentName.TabIndex = 1;

            //
            // lblAttendance
            //
            this.lblAttendance.AutoSize = true;
            this.lblAttendance.Location = new System.Drawing.Point(20, 75);
            this.lblAttendance.Name = "lblAttendance";
            this.lblAttendance.Size = new System.Drawing.Size(120, 19);
            this.lblAttendance.TabIndex = 2;
            this.lblAttendance.Text = "Điểm chuyên cần:";

            //
            // numAttendance
            //
            this.numAttendance.DecimalPlaces = 1;
            this.numAttendance.Location = new System.Drawing.Point(150, 73);
            this.numAttendance.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numAttendance.Name = "numAttendance";
            this.numAttendance.Size = new System.Drawing.Size(120, 25);
            this.numAttendance.TabIndex = 3;

            //
            // lblAttitude
            //
            this.lblAttitude.AutoSize = true;
            this.lblAttitude.Location = new System.Drawing.Point(20, 115);
            this.lblAttitude.Name = "lblAttitude";
            this.lblAttitude.Size = new System.Drawing.Size(100, 19);
            this.lblAttitude.TabIndex = 4;
            this.lblAttitude.Text = "Điểm thái độ:";

            //
            // numAttitude
            //
            this.numAttitude.DecimalPlaces = 1;
            this.numAttitude.Location = new System.Drawing.Point(150, 113);
            this.numAttitude.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numAttitude.Name = "numAttitude";
            this.numAttitude.Size = new System.Drawing.Size(120, 25);
            this.numAttitude.TabIndex = 5;

            //
            // lblSkill
            //
            this.lblSkill.AutoSize = true;
            this.lblSkill.Location = new System.Drawing.Point(20, 155);
            this.lblSkill.Name = "lblSkill";
            this.lblSkill.Size = new System.Drawing.Size(110, 19);
            this.lblSkill.TabIndex = 6;
            this.lblSkill.Text = "Điểm kỹ năng:";

            //
            // numSkill
            //
            this.numSkill.DecimalPlaces = 1;
            this.numSkill.Location = new System.Drawing.Point(150, 153);
            this.numSkill.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numSkill.Name = "numSkill";
            this.numSkill.Size = new System.Drawing.Size(120, 25);
            this.numSkill.TabIndex = 7;

            //
            // lblResult
            //
            this.lblResult.AutoSize = true;
            this.lblResult.Location = new System.Drawing.Point(20, 195);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(110, 19);
            this.lblResult.TabIndex = 8;
            this.lblResult.Text = "Điểm kết quả:";

            //
            // numResult
            //
            this.numResult.DecimalPlaces = 1;
            this.numResult.Location = new System.Drawing.Point(150, 193);
            this.numResult.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            this.numResult.Name = "numResult";
            this.numResult.Size = new System.Drawing.Size(120, 25);
            this.numResult.TabIndex = 9;

            //
            // lblTotal
            //
            this.lblTotal.AutoSize = true;
            this.lblTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblTotal.Location = new System.Drawing.Point(20, 235);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(90, 19);
            this.lblTotal.TabIndex = 10;
            this.lblTotal.Text = "Tổng điểm:";

            //
            // txtTotal
            //
            this.txtTotal.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.txtTotal.Location = new System.Drawing.Point(150, 233);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(120, 25);
            this.txtTotal.TabIndex = 11;

            //
            // lblComment
            //
            this.lblComment.AutoSize = true;
            this.lblComment.Location = new System.Drawing.Point(20, 275);
            this.lblComment.Name = "lblComment";
            this.lblComment.Size = new System.Drawing.Size(70, 19);
            this.lblComment.TabIndex = 12;
            this.lblComment.Text = "Nhận xét:";

            //
            // rtbComment
            //
            this.rtbComment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbComment.Location = new System.Drawing.Point(150, 275);
            this.rtbComment.Name = "rtbComment";
            this.rtbComment.Size = new System.Drawing.Size(1002, 60);
            this.rtbComment.TabIndex = 13;
            this.rtbComment.Text = "";

            //
            // btnSubmitEvaluation
            //
            this.btnSubmitEvaluation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitEvaluation.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.btnSubmitEvaluation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitEvaluation.ForeColor = System.Drawing.Color.White;
            this.btnSubmitEvaluation.Location = new System.Drawing.Point(952, 345);
            this.btnSubmitEvaluation.Name = "btnSubmitEvaluation";
            this.btnSubmitEvaluation.Size = new System.Drawing.Size(100, 35);
            this.btnSubmitEvaluation.TabIndex = 14;
            this.btnSubmitEvaluation.Text = "Lưu";
            this.btnSubmitEvaluation.UseVisualStyleBackColor = false;

            //
            // btnCancelEvaluation
            //
            this.btnCancelEvaluation.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelEvaluation.BackColor = System.Drawing.Color.Gray;
            this.btnCancelEvaluation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelEvaluation.ForeColor = System.Drawing.Color.White;
            this.btnCancelEvaluation.Location = new System.Drawing.Point(1058, 345);
            this.btnCancelEvaluation.Name = "btnCancelEvaluation";
            this.btnCancelEvaluation.Size = new System.Drawing.Size(100, 35);
            this.btnCancelEvaluation.TabIndex = 15;
            this.btnCancelEvaluation.Text = "Hủy";
            this.btnCancelEvaluation.UseVisualStyleBackColor = false;

            //
            // tabReports
            //
            this.tabReports.BackColor = System.Drawing.Color.White;
            this.tabReports.Controls.Add(this.dgvReports);
            this.tabReports.Controls.Add(this.grpReportForm);
            this.tabReports.Location = new System.Drawing.Point(4, 28);
            this.tabReports.Name = "tabReports";
            this.tabReports.Padding = new System.Windows.Forms.Padding(10);
            this.tabReports.Size = new System.Drawing.Size(1192, 668);
            this.tabReports.TabIndex = 2;
            this.tabReports.Text = "📊 Báo cáo tổng kết";

            //
            // dgvReports
            //
            this.dgvReports.AllowUserToAddRows = false;
            this.dgvReports.AllowUserToDeleteRows = false;
            this.dgvReports.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReports.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReports.BackgroundColor = System.Drawing.Color.White;
            this.dgvReports.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReports.Location = new System.Drawing.Point(10, 10);
            this.dgvReports.MultiSelect = false;
            this.dgvReports.Name = "dgvReports";
            this.dgvReports.ReadOnly = true;
            this.dgvReports.RowHeadersWidth = 51;
            this.dgvReports.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReports.Size = new System.Drawing.Size(1172, 200);
            this.dgvReports.TabIndex = 0;

            //
            // grpReportForm
            //
            this.grpReportForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpReportForm.Controls.Add(this.lblReportTitle);
            this.grpReportForm.Controls.Add(this.txtReportTitle);
            this.grpReportForm.Controls.Add(this.lblReportContent);
            this.grpReportForm.Controls.Add(this.rtbReportContent);
            this.grpReportForm.Controls.Add(this.lblPeriod);
            this.grpReportForm.Controls.Add(this.txtPeriod);
            this.grpReportForm.Controls.Add(this.lblTotalStudents);
            this.grpReportForm.Controls.Add(this.numTotalStudents);
            this.grpReportForm.Controls.Add(this.lblCompletedStudents);
            this.grpReportForm.Controls.Add(this.numCompletedStudents);
            this.grpReportForm.Controls.Add(this.lblAttachments);
            this.grpReportForm.Controls.Add(this.lvAttachments);
            this.grpReportForm.Controls.Add(this.btnAddAttachment);
            this.grpReportForm.Controls.Add(this.btnRemoveAttachment);
            this.grpReportForm.Controls.Add(this.btnSubmitReport);
            this.grpReportForm.Location = new System.Drawing.Point(10, 220);
            this.grpReportForm.Name = "grpReportForm";
            this.grpReportForm.Size = new System.Drawing.Size(1172, 438);
            this.grpReportForm.TabIndex = 1;
            this.grpReportForm.TabStop = false;
            this.grpReportForm.Text = "Form báo cáo";

            //
            // lblReportTitle
            //
            this.lblReportTitle.AutoSize = true;
            this.lblReportTitle.Location = new System.Drawing.Point(20, 35);
            this.lblReportTitle.Name = "lblReportTitle";
            this.lblReportTitle.Size = new System.Drawing.Size(90, 19);
            this.lblReportTitle.TabIndex = 0;
            this.lblReportTitle.Text = "Tiêu đề:";

            //
            // txtReportTitle
            //
            this.txtReportTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtReportTitle.Location = new System.Drawing.Point(150, 32);
            this.txtReportTitle.Name = "txtReportTitle";
            this.txtReportTitle.Size = new System.Drawing.Size(1002, 25);
            this.txtReportTitle.TabIndex = 1;

            //
            // lblReportContent
            //
            this.lblReportContent.AutoSize = true;
            this.lblReportContent.Location = new System.Drawing.Point(20, 75);
            this.lblReportContent.Name = "lblReportContent";
            this.lblReportContent.Size = new System.Drawing.Size(70, 19);
            this.lblReportContent.TabIndex = 2;
            this.lblReportContent.Text = "Nội dung:";

            //
            // rtbReportContent
            //
            this.rtbReportContent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rtbReportContent.Location = new System.Drawing.Point(150, 75);
            this.rtbReportContent.Name = "rtbReportContent";
            this.rtbReportContent.Size = new System.Drawing.Size(1002, 100);
            this.rtbReportContent.TabIndex = 3;
            this.rtbReportContent.Text = "";

            //
            // lblPeriod
            //
            this.lblPeriod.AutoSize = true;
            this.lblPeriod.Location = new System.Drawing.Point(20, 195);
            this.lblPeriod.Name = "lblPeriod";
            this.lblPeriod.Size = new System.Drawing.Size(60, 19);
            this.lblPeriod.TabIndex = 4;
            this.lblPeriod.Text = "Kỳ học:";

            //
            // txtPeriod
            //
            this.txtPeriod.Location = new System.Drawing.Point(150, 192);
            this.txtPeriod.Name = "txtPeriod";
            this.txtPeriod.Size = new System.Drawing.Size(200, 25);
            this.txtPeriod.TabIndex = 5;

            //
            // lblTotalStudents
            //
            this.lblTotalStudents.AutoSize = true;
            this.lblTotalStudents.Location = new System.Drawing.Point(400, 195);
            this.lblTotalStudents.Name = "lblTotalStudents";
            this.lblTotalStudents.Size = new System.Drawing.Size(100, 19);
            this.lblTotalStudents.TabIndex = 6;
            this.lblTotalStudents.Text = "Tổng SV:";

            //
            // numTotalStudents
            //
            this.numTotalStudents.Location = new System.Drawing.Point(510, 193);
            this.numTotalStudents.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numTotalStudents.Name = "numTotalStudents";
            this.numTotalStudents.Size = new System.Drawing.Size(120, 25);
            this.numTotalStudents.TabIndex = 7;

            //
            // lblCompletedStudents
            //
            this.lblCompletedStudents.AutoSize = true;
            this.lblCompletedStudents.Location = new System.Drawing.Point(650, 195);
            this.lblCompletedStudents.Name = "lblCompletedStudents";
            this.lblCompletedStudents.Size = new System.Drawing.Size(120, 19);
            this.lblCompletedStudents.TabIndex = 8;
            this.lblCompletedStudents.Text = "SV hoàn thành:";

            //
            // numCompletedStudents
            //
            this.numCompletedStudents.Location = new System.Drawing.Point(780, 193);
            this.numCompletedStudents.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            this.numCompletedStudents.Name = "numCompletedStudents";
            this.numCompletedStudents.Size = new System.Drawing.Size(120, 25);
            this.numCompletedStudents.TabIndex = 9;

            //
            // lblAttachments
            //
            this.lblAttachments.AutoSize = true;
            this.lblAttachments.Location = new System.Drawing.Point(20, 235);
            this.lblAttachments.Name = "lblAttachments";
            this.lblAttachments.Size = new System.Drawing.Size(80, 19);
            this.lblAttachments.TabIndex = 10;
            this.lblAttachments.Text = "File đính kèm:";

            //
            // lvAttachments
            //
            this.lvAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAttachments.Location = new System.Drawing.Point(150, 235);
            this.lvAttachments.Name = "lvAttachments";
            this.lvAttachments.Size = new System.Drawing.Size(1002, 120);
            this.lvAttachments.TabIndex = 11;
            this.lvAttachments.UseCompatibleStateImageBehavior = false;
            this.lvAttachments.View = System.Windows.Forms.View.List;

            //
            // btnAddAttachment
            //
            this.btnAddAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddAttachment.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.btnAddAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAttachment.ForeColor = System.Drawing.Color.White;
            this.btnAddAttachment.Location = new System.Drawing.Point(150, 365);
            this.btnAddAttachment.Name = "btnAddAttachment";
            this.btnAddAttachment.Size = new System.Drawing.Size(120, 35);
            this.btnAddAttachment.TabIndex = 12;
            this.btnAddAttachment.Text = "Thêm file";
            this.btnAddAttachment.UseVisualStyleBackColor = false;

            //
            // btnRemoveAttachment
            //
            this.btnRemoveAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRemoveAttachment.BackColor = System.Drawing.Color.Gray;
            this.btnRemoveAttachment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRemoveAttachment.ForeColor = System.Drawing.Color.White;
            this.btnRemoveAttachment.Location = new System.Drawing.Point(280, 365);
            this.btnRemoveAttachment.Name = "btnRemoveAttachment";
            this.btnRemoveAttachment.Size = new System.Drawing.Size(120, 35);
            this.btnRemoveAttachment.TabIndex = 13;
            this.btnRemoveAttachment.Text = "Xóa file";
            this.btnRemoveAttachment.UseVisualStyleBackColor = false;

            //
            // btnSubmitReport
            //
            this.btnSubmitReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSubmitReport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.btnSubmitReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSubmitReport.ForeColor = System.Drawing.Color.White;
            this.btnSubmitReport.Location = new System.Drawing.Point(1052, 365);
            this.btnSubmitReport.Name = "btnSubmitReport";
            this.btnSubmitReport.Size = new System.Drawing.Size(100, 35);
            this.btnSubmitReport.TabIndex = 14;
            this.btnSubmitReport.Text = "Lưu";
            this.btnSubmitReport.UseVisualStyleBackColor = false;

            //
            // tabTopics
            //
            this.tabTopics.BackColor = System.Drawing.Color.White;
            this.tabTopics.Controls.Add(this.dgvTopics);
            this.tabTopics.Controls.Add(this.btnAddTopic);
            this.tabTopics.Controls.Add(this.btnEditTopic);
            this.tabTopics.Controls.Add(this.btnDeleteTopic);
            this.tabTopics.Controls.Add(this.btnRefreshTopics);
            this.tabTopics.Location = new System.Drawing.Point(4, 28);
            this.tabTopics.Name = "tabTopics";
            this.tabTopics.Padding = new System.Windows.Forms.Padding(10);
            this.tabTopics.Size = new System.Drawing.Size(1192, 668);
            this.tabTopics.TabIndex = 3;
            this.tabTopics.Text = "📝 Quản lý đề tài";

            //
            // dgvTopics
            //
            this.dgvTopics.AllowUserToAddRows = false;
            this.dgvTopics.AllowUserToDeleteRows = false;
            this.dgvTopics.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTopics.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTopics.BackgroundColor = System.Drawing.Color.White;
            this.dgvTopics.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTopics.Location = new System.Drawing.Point(10, 50);
            this.dgvTopics.MultiSelect = false;
            this.dgvTopics.Name = "dgvTopics";
            this.dgvTopics.ReadOnly = true;
            this.dgvTopics.RowHeadersWidth = 51;
            this.dgvTopics.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTopics.Size = new System.Drawing.Size(1172, 608);
            this.dgvTopics.TabIndex = 4;

            //
            // btnAddTopic
            //
            this.btnAddTopic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.btnAddTopic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTopic.ForeColor = System.Drawing.Color.White;
            this.btnAddTopic.Location = new System.Drawing.Point(10, 10);
            this.btnAddTopic.Name = "btnAddTopic";
            this.btnAddTopic.Size = new System.Drawing.Size(120, 35);
            this.btnAddTopic.TabIndex = 0;
            this.btnAddTopic.Text = "Thêm đề tài";
            this.btnAddTopic.UseVisualStyleBackColor = false;

            //
            // btnEditTopic
            //
            this.btnEditTopic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(111)))), ((int)(((byte)(33)))));
            this.btnEditTopic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTopic.ForeColor = System.Drawing.Color.White;
            this.btnEditTopic.Location = new System.Drawing.Point(140, 10);
            this.btnEditTopic.Name = "btnEditTopic";
            this.btnEditTopic.Size = new System.Drawing.Size(120, 35);
            this.btnEditTopic.TabIndex = 1;
            this.btnEditTopic.Text = "Sửa";
            this.btnEditTopic.UseVisualStyleBackColor = false;

            //
            // btnDeleteTopic
            //
            this.btnDeleteTopic.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(53)))), ((int)(((byte)(69)))));
            this.btnDeleteTopic.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTopic.ForeColor = System.Drawing.Color.White;
            this.btnDeleteTopic.Location = new System.Drawing.Point(270, 10);
            this.btnDeleteTopic.Name = "btnDeleteTopic";
            this.btnDeleteTopic.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteTopic.TabIndex = 2;
            this.btnDeleteTopic.Text = "Xóa";
            this.btnDeleteTopic.UseVisualStyleBackColor = false;

            //
            // btnRefreshTopics
            //
            this.btnRefreshTopics.BackColor = System.Drawing.Color.Gray;
            this.btnRefreshTopics.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefreshTopics.ForeColor = System.Drawing.Color.White;
            this.btnRefreshTopics.Location = new System.Drawing.Point(400, 10);
            this.btnRefreshTopics.Name = "btnRefreshTopics";
            this.btnRefreshTopics.Size = new System.Drawing.Size(120, 35);
            this.btnRefreshTopics.TabIndex = 3;
            this.btnRefreshTopics.Text = "Làm mới";
            this.btnRefreshTopics.UseVisualStyleBackColor = false;

            //
            // CompanyForm
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 700);
            this.Controls.Add(this.tabControl);
            this.Name = "CompanyForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản lý Thực tập - Doanh nghiệp";

            ((System.ComponentModel.ISupportInitialize)(this.dgvConfirmations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEvaluations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAttendance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAttitude)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSkill)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReports)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numTotalStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCompletedStudents)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTopics)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabConfirmations.ResumeLayout(false);
            this.tabEvaluations.ResumeLayout(false);
            this.tabReports.ResumeLayout(false);
            this.tabTopics.ResumeLayout(false);
            this.grpEvaluationForm.ResumeLayout(false);
            this.grpReportForm.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabConfirmations;
        private System.Windows.Forms.TabPage tabEvaluations;
        private System.Windows.Forms.TabPage tabReports;
        private System.Windows.Forms.TabPage tabTopics;

        // Tab Confirmations
        private System.Windows.Forms.DataGridView dgvConfirmations;
        private System.Windows.Forms.ComboBox cboConfirmStatusFilter;
        private System.Windows.Forms.Label lblConfirmFilter;
        private System.Windows.Forms.Button btnRefreshConfirmations;

        // Tab Evaluations
        private System.Windows.Forms.DataGridView dgvEvaluations;
        private System.Windows.Forms.GroupBox grpEvaluationForm;
        private System.Windows.Forms.Label lblStudent;
        private System.Windows.Forms.TextBox txtStudentName;
        private System.Windows.Forms.Label lblAttendance;
        private System.Windows.Forms.NumericUpDown numAttendance;
        private System.Windows.Forms.Label lblAttitude;
        private System.Windows.Forms.NumericUpDown numAttitude;
        private System.Windows.Forms.Label lblSkill;
        private System.Windows.Forms.NumericUpDown numSkill;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.NumericUpDown numResult;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label lblComment;
        private System.Windows.Forms.RichTextBox rtbComment;
        private System.Windows.Forms.Button btnSubmitEvaluation;
        private System.Windows.Forms.Button btnCancelEvaluation;

        // Tab Reports
        private System.Windows.Forms.GroupBox grpReportForm;
        private System.Windows.Forms.Label lblReportTitle;
        private System.Windows.Forms.TextBox txtReportTitle;
        private System.Windows.Forms.Label lblReportContent;
        private System.Windows.Forms.RichTextBox rtbReportContent;
        private System.Windows.Forms.Label lblPeriod;
        private System.Windows.Forms.TextBox txtPeriod;
        private System.Windows.Forms.Label lblTotalStudents;
        private System.Windows.Forms.NumericUpDown numTotalStudents;
        private System.Windows.Forms.Label lblCompletedStudents;
        private System.Windows.Forms.NumericUpDown numCompletedStudents;
        private System.Windows.Forms.Label lblAttachments;
        private System.Windows.Forms.ListView lvAttachments;
        private System.Windows.Forms.Button btnAddAttachment;
        private System.Windows.Forms.Button btnRemoveAttachment;
        private System.Windows.Forms.Button btnSubmitReport;
        private System.Windows.Forms.DataGridView dgvReports;

        // Tab Topics
        private System.Windows.Forms.DataGridView dgvTopics;
        private System.Windows.Forms.Button btnAddTopic;
        private System.Windows.Forms.Button btnEditTopic;
        private System.Windows.Forms.Button btnDeleteTopic;
        private System.Windows.Forms.Button btnRefreshTopics;
    }
}

