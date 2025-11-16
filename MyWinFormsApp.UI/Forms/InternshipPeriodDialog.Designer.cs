namespace MyWinFormsApp.UI.Forms
{
    partial class InternshipPeriodDialog
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
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblSemester = new System.Windows.Forms.Label();
            this.cboSemester = new System.Windows.Forms.ComboBox();
            this.lblAcademicYear = new System.Windows.Forms.Label();
            this.txtAcademicYear = new System.Windows.Forms.TextBox();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.lblEndDate = new System.Windows.Forms.Label();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.lblRegistrationDeadline = new System.Windows.Forms.Label();
            this.dtpRegistrationDeadline = new System.Windows.Forms.DateTimePicker();
            this.lblReportDeadline = new System.Windows.Forms.Label();
            this.dtpReportDeadline = new System.Windows.Forms.DateTimePicker();
            this.lblDefenseDate = new System.Windows.Forms.Label();
            this.dtpDefenseDate = new System.Windows.Forms.DateTimePicker();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(20, 20);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(120, 15);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Tên kỳ thực tập: *";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(180, 17);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(350, 23);
            this.txtName.TabIndex = 1;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(20, 55);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(50, 15);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Mô tả:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(180, 52);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(350, 60);
            this.txtDescription.TabIndex = 3;
            // 
            // lblSemester
            // 
            this.lblSemester.AutoSize = true;
            this.lblSemester.Location = new System.Drawing.Point(20, 130);
            this.lblSemester.Name = "lblSemester";
            this.lblSemester.Size = new System.Drawing.Size(60, 15);
            this.lblSemester.TabIndex = 4;
            this.lblSemester.Text = "Học kỳ: *";
            // 
            // cboSemester
            // 
            this.cboSemester.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSemester.FormattingEnabled = true;
            this.cboSemester.Location = new System.Drawing.Point(180, 127);
            this.cboSemester.Name = "cboSemester";
            this.cboSemester.Size = new System.Drawing.Size(100, 23);
            this.cboSemester.TabIndex = 5;
            // 
            // lblAcademicYear
            // 
            this.lblAcademicYear.AutoSize = true;
            this.lblAcademicYear.Location = new System.Drawing.Point(300, 130);
            this.lblAcademicYear.Name = "lblAcademicYear";
            this.lblAcademicYear.Size = new System.Drawing.Size(70, 15);
            this.lblAcademicYear.TabIndex = 6;
            this.lblAcademicYear.Text = "Năm học: *";
            // 
            // txtAcademicYear
            // 
            this.txtAcademicYear.Location = new System.Drawing.Point(380, 127);
            this.txtAcademicYear.Name = "txtAcademicYear";
            this.txtAcademicYear.PlaceholderText = "VD: 2024-2025";
            this.txtAcademicYear.Size = new System.Drawing.Size(150, 23);
            this.txtAcademicYear.TabIndex = 7;
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Location = new System.Drawing.Point(20, 170);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(100, 15);
            this.lblStartDate.TabIndex = 8;
            this.lblStartDate.Text = "Ngày bắt đầu: *";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpStartDate.Location = new System.Drawing.Point(180, 167);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(150, 23);
            this.dtpStartDate.TabIndex = 9;
            // 
            // lblEndDate
            // 
            this.lblEndDate.AutoSize = true;
            this.lblEndDate.Location = new System.Drawing.Point(20, 210);
            this.lblEndDate.Name = "lblEndDate";
            this.lblEndDate.Size = new System.Drawing.Size(110, 15);
            this.lblEndDate.TabIndex = 10;
            this.lblEndDate.Text = "Ngày kết thúc: *";
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(180, 207);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(150, 23);
            this.dtpEndDate.TabIndex = 11;
            this.dtpEndDate.Value = new System.DateTime(2025, 1, 1, 0, 0, 0, 0);
            //
            // lblRegistrationDeadline
            //
            this.lblRegistrationDeadline.AutoSize = true;
            this.lblRegistrationDeadline.Location = new System.Drawing.Point(20, 250);
            this.lblRegistrationDeadline.Name = "lblRegistrationDeadline";
            this.lblRegistrationDeadline.Size = new System.Drawing.Size(120, 15);
            this.lblRegistrationDeadline.TabIndex = 12;
            this.lblRegistrationDeadline.Text = "Hạn đăng ký: *";
            //
            // dtpRegistrationDeadline
            //
            this.dtpRegistrationDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpRegistrationDeadline.Location = new System.Drawing.Point(180, 247);
            this.dtpRegistrationDeadline.Name = "dtpRegistrationDeadline";
            this.dtpRegistrationDeadline.Size = new System.Drawing.Size(150, 23);
            this.dtpRegistrationDeadline.TabIndex = 13;
            //
            // lblReportDeadline
            //
            this.lblReportDeadline.AutoSize = true;
            this.lblReportDeadline.Location = new System.Drawing.Point(20, 290);
            this.lblReportDeadline.Name = "lblReportDeadline";
            this.lblReportDeadline.Size = new System.Drawing.Size(130, 15);
            this.lblReportDeadline.TabIndex = 14;
            this.lblReportDeadline.Text = "Hạn nộp báo cáo: *";
            //
            // dtpReportDeadline
            //
            this.dtpReportDeadline.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpReportDeadline.Location = new System.Drawing.Point(180, 287);
            this.dtpReportDeadline.Name = "dtpReportDeadline";
            this.dtpReportDeadline.Size = new System.Drawing.Size(150, 23);
            this.dtpReportDeadline.TabIndex = 15;
            //
            // lblDefenseDate
            //
            this.lblDefenseDate.AutoSize = true;
            this.lblDefenseDate.Location = new System.Drawing.Point(20, 330);
            this.lblDefenseDate.Name = "lblDefenseDate";
            this.lblDefenseDate.Size = new System.Drawing.Size(90, 15);
            this.lblDefenseDate.TabIndex = 16;
            this.lblDefenseDate.Text = "Ngày bảo vệ:";
            //
            // dtpDefenseDate
            //
            this.dtpDefenseDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDefenseDate.Location = new System.Drawing.Point(180, 327);
            this.dtpDefenseDate.Name = "dtpDefenseDate";
            this.dtpDefenseDate.Size = new System.Drawing.Size(150, 23);
            this.dtpDefenseDate.TabIndex = 17;
            //
            // lblNotes
            //
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(20, 370);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(60, 15);
            this.lblNotes.TabIndex = 18;
            this.lblNotes.Text = "Ghi chú:";
            //
            // txtNotes
            //
            this.txtNotes.Location = new System.Drawing.Point(180, 367);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(350, 60);
            this.txtNotes.TabIndex = 19;
            //
            // btnSave
            //
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(84)))), ((int)(((byte)(166)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(320, 450);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            //
            // btnCancel
            //
            this.btnCancel.BackColor = System.Drawing.Color.Gray;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(430, 450);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 21;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            //
            // InternshipPeriodDialog
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 510);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.dtpDefenseDate);
            this.Controls.Add(this.lblDefenseDate);
            this.Controls.Add(this.dtpReportDeadline);
            this.Controls.Add(this.lblReportDeadline);
            this.Controls.Add(this.dtpRegistrationDeadline);
            this.Controls.Add(this.lblRegistrationDeadline);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.lblEndDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.lblStartDate);
            this.Controls.Add(this.txtAcademicYear);
            this.Controls.Add(this.lblAcademicYear);
            this.Controls.Add(this.cboSemester);
            this.Controls.Add(this.lblSemester);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.lblName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InternshipPeriodDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Kỳ Thực Tập";
            this.Load += new System.EventHandler(this.InternshipPeriodDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblSemester;
        private System.Windows.Forms.ComboBox cboSemester;
        private System.Windows.Forms.Label lblAcademicYear;
        private System.Windows.Forms.TextBox txtAcademicYear;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label lblEndDate;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label lblRegistrationDeadline;
        private System.Windows.Forms.DateTimePicker dtpRegistrationDeadline;
        private System.Windows.Forms.Label lblReportDeadline;
        private System.Windows.Forms.DateTimePicker dtpReportDeadline;
        private System.Windows.Forms.Label lblDefenseDate;
        private System.Windows.Forms.DateTimePicker dtpDefenseDate;
        private System.Windows.Forms.Label lblNotes;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}


