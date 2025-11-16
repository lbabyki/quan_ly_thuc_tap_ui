using System;
using System.Drawing;
using System.Windows.Forms;
using MyWinFormsApp.Business.Models;

namespace MyWinFormsApp.Forms
{
    /// <summary>
    /// Dialog for creating/editing users (Student, Lecturer, Company)
    /// </summary>
    public partial class UserDialog : Form
    {
        private readonly Color PRIMARY_COLOR = ColorTranslator.FromHtml("#0054A6");
        private readonly Color SECONDARY_COLOR = ColorTranslator.FromHtml("#F36F21");

        public string UserRole { get; private set; } = "student"; // student, lecturer, company
        public bool IsEditMode { get; private set; }
        public object? UserData { get; private set; }

        // Common fields
        private TextBox txtUserName = null!;
        private TextBox txtFullName = null!;
        private TextBox txtEmail = null!;
        private TextBox txtPhone = null!;
        private TextBox txtPassword = null!;
        private ComboBox cboRole = null!;

        // Student fields
        private TextBox? txtStudentCode;
        private TextBox? txtDepartment;
        private ComboBox? cboYear;
        private ComboBox? cboStatus;

        // Lecturer fields
        private TextBox? txtSpecialization;

        // Company fields
        private TextBox? txtCompanyName;
        private TextBox? txtAddress;
        private TextBox? txtContactPerson;

        private Button btnSave = null!;
        private Button btnCancel = null!;

        public UserDialog(string role, object? existingUser = null)
        {
            UserRole = role;
            IsEditMode = existingUser != null;
            UserData = existingUser;

            InitializeComponent();
            SetupForm();
            LoadData();
        }

        private void SetupForm()
        {
            this.Text = IsEditMode ? $"Chỉnh sửa {GetRoleName()}" : $"Tạo mới {GetRoleName()}";
            this.Size = new Size(500, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                AutoScroll = true
            };

            int yPos = 10;

            // Title
            var lblTitle = new Label
            {
                Text = this.Text,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = PRIMARY_COLOR,
                Location = new Point(0, yPos),
                Size = new Size(440, 40),
                TextAlign = ContentAlignment.MiddleCenter
            };
            panel.Controls.Add(lblTitle);
            yPos += 50;

            // Common fields
            AddField(panel, ref yPos, "Tên đăng nhập:", ref txtUserName, true);
            AddField(panel, ref yPos, "Họ và tên:", ref txtFullName, true);
            AddField(panel, ref yPos, "Email:", ref txtEmail, true);
            AddField(panel, ref yPos, "Số điện thoại:", ref txtPhone, false);
            
            if (!IsEditMode)
            {
                AddField(panel, ref yPos, "Mật khẩu:", ref txtPassword, true, true);
            }

            // Role-specific fields
            switch (UserRole.ToLower())
            {
                case "student":
                    AddStudentFields(panel, ref yPos);
                    break;
                case "lecturer":
                    AddLecturerFields(panel, ref yPos);
                    break;
                case "company":
                    AddCompanyFields(panel, ref yPos);
                    break;
            }

            // Buttons
            yPos += 20;
            var btnPanel = new Panel
            {
                Location = new Point(0, yPos),
                Size = new Size(440, 50),
                Dock = DockStyle.None
            };

            btnSave = new Button
            {
                Text = IsEditMode ? "Cập nhật" : "Tạo mới",
                Size = new Size(120, 40),
                Location = new Point(100, 5),
                BackColor = SECONDARY_COLOR,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnSave.FlatAppearance.BorderSize = 0;
            btnSave.Click += BtnSave_Click;

            btnCancel = new Button
            {
                Text = "Hủy",
                Size = new Size(120, 40),
                Location = new Point(230, 5),
                BackColor = Color.Gray,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F),
                Cursor = Cursors.Hand
            };
            btnCancel.FlatAppearance.BorderSize = 0;
            btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

            btnPanel.Controls.Add(btnSave);
            btnPanel.Controls.Add(btnCancel);
            panel.Controls.Add(btnPanel);

            this.Controls.Add(panel);
        }

        private void AddField(Panel panel, ref int yPos, string label, ref TextBox textBox, bool required, bool isPassword = false)
        {
            var lbl = new Label
            {
                Text = label + (required ? " *" : ""),
                Location = new Point(0, yPos),
                Size = new Size(440, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = required ? PRIMARY_COLOR : Color.Black
            };
            panel.Controls.Add(lbl);
            yPos += 25;

            textBox = new TextBox
            {
                Location = new Point(0, yPos),
                Size = new Size(440, 30),
                Font = new Font("Segoe UI", 10F),
                UseSystemPasswordChar = isPassword
            };
            panel.Controls.Add(textBox);
            yPos += 40;
        }

        private void AddStudentFields(Panel panel, ref int yPos)
        {
            txtStudentCode = new TextBox();
            AddField(panel, ref yPos, "Mã sinh viên:", ref txtStudentCode, true);

            txtDepartment = new TextBox();
            AddField(panel, ref yPos, "Khoa:", ref txtDepartment, false);

            var lblYear = new Label
            {
                Text = "Năm học:",
                Location = new Point(0, yPos),
                Size = new Size(440, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            panel.Controls.Add(lblYear);
            yPos += 25;

            cboYear = new ComboBox
            {
                Location = new Point(0, yPos),
                Size = new Size(440, 30),
                Font = new Font("Segoe UI", 10F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboYear.Items.AddRange(new object[] { "1", "2", "3", "4" });
            cboYear.SelectedIndex = 0;
            panel.Controls.Add(cboYear);
            yPos += 40;

            var lblStatus = new Label
            {
                Text = "Trạng thái:",
                Location = new Point(0, yPos),
                Size = new Size(440, 20),
                Font = new Font("Segoe UI", 9F, FontStyle.Bold)
            };
            panel.Controls.Add(lblStatus);
            yPos += 25;

            cboStatus = new ComboBox
            {
                Location = new Point(0, yPos),
                Size = new Size(440, 30),
                Font = new Font("Segoe UI", 10F),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cboStatus.Items.AddRange(new object[] { "pending", "approved", "rejected" });
            cboStatus.SelectedIndex = 0;
            panel.Controls.Add(cboStatus);
            yPos += 40;
        }

        private void AddLecturerFields(Panel panel, ref int yPos)
        {
            txtDepartment = new TextBox();
            AddField(panel, ref yPos, "Khoa:", ref txtDepartment, false);

            txtSpecialization = new TextBox();
            AddField(panel, ref yPos, "Chuyên môn:", ref txtSpecialization, false);
        }

        private void AddCompanyFields(Panel panel, ref int yPos)
        {
            txtCompanyName = new TextBox();
            AddField(panel, ref yPos, "Tên công ty:", ref txtCompanyName, true);

            txtAddress = new TextBox();
            AddField(panel, ref yPos, "Địa chỉ:", ref txtAddress, false);

            txtContactPerson = new TextBox();
            AddField(panel, ref yPos, "Người liên hệ:", ref txtContactPerson, true);
        }

        private void LoadData()
        {
            if (!IsEditMode || UserData == null) return;

            switch (UserRole.ToLower())
            {
                case "student":
                    LoadStudentData(UserData as Student);
                    break;
                case "lecturer":
                    LoadLecturerData(UserData as Lecturer);
                    break;
                case "company":
                    LoadCompanyData(UserData as Company);
                    break;
            }
        }

        private void LoadStudentData(Student? student)
        {
            if (student == null) return;

            txtUserName.Text = student.UserName;
            txtFullName.Text = student.FullName ?? "";
            txtEmail.Text = student.Email;
            txtPhone.Text = student.Phone ?? "";
            txtStudentCode!.Text = student.StudentCode ?? "";
            txtDepartment!.Text = student.Department ?? "";

            if (student.Year.HasValue && student.Year.Value >= 1 && student.Year.Value <= 4)
                cboYear!.SelectedIndex = student.Year.Value - 1;

            if (!string.IsNullOrEmpty(student.Status))
            {
                int statusIndex = cboStatus!.Items.IndexOf(student.Status);
                if (statusIndex >= 0) cboStatus.SelectedIndex = statusIndex;
            }
        }

        private void LoadLecturerData(Lecturer? lecturer)
        {
            if (lecturer == null) return;

            txtUserName.Text = lecturer.UserName;
            txtFullName.Text = lecturer.FullName ?? "";
            txtEmail.Text = lecturer.Email;
            txtPhone.Text = lecturer.Phone ?? "";
            txtDepartment!.Text = lecturer.Department ?? "";
            txtSpecialization!.Text = lecturer.Specialization ?? "";
        }

        private void LoadCompanyData(Company? company)
        {
            if (company == null) return;

            txtUserName.Text = company.ContactEmail; // Use email as username
            txtFullName.Text = company.ContactPerson;
            txtEmail.Text = company.ContactEmail;
            txtPhone.Text = company.ContactPhone ?? "";
            txtCompanyName!.Text = company.CompanyName;
            txtAddress!.Text = company.Address ?? "";
            txtContactPerson!.Text = company.ContactPerson;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            if (!ValidateInput())
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin bắt buộc!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                UserData = CreateUserObject();
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtUserName.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtFullName.Text)) return false;
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) return false;
            if (!IsEditMode && string.IsNullOrWhiteSpace(txtPassword.Text)) return false;

            switch (UserRole.ToLower())
            {
                case "student":
                    if (string.IsNullOrWhiteSpace(txtStudentCode?.Text)) return false;
                    break;
                case "company":
                    if (string.IsNullOrWhiteSpace(txtCompanyName?.Text)) return false;
                    if (string.IsNullOrWhiteSpace(txtContactPerson?.Text)) return false;
                    break;
            }

            return true;
        }

        private object CreateUserObject()
        {
            switch (UserRole.ToLower())
            {
                case "student":
                    var student = UserData as Student ?? new Student();
                    student.UserName = txtUserName.Text.Trim();
                    student.FullName = txtFullName.Text.Trim();
                    student.Email = txtEmail.Text.Trim();
                    student.Phone = txtPhone.Text.Trim();
                    student.StudentCode = txtStudentCode!.Text.Trim();
                    student.Department = txtDepartment!.Text.Trim();
                    student.Year = cboYear!.SelectedIndex + 1;
                    student.Status = cboStatus!.SelectedItem?.ToString() ?? "pending";
                    if (!IsEditMode) student.Password = txtPassword.Text;
                    student.Role = "student";
                    return student;

                case "lecturer":
                    var lecturer = UserData as Lecturer ?? new Lecturer();
                    lecturer.UserName = txtUserName.Text.Trim();
                    lecturer.FullName = txtFullName.Text.Trim();
                    lecturer.Email = txtEmail.Text.Trim();
                    lecturer.Phone = txtPhone.Text.Trim();
                    lecturer.Department = txtDepartment!.Text.Trim();
                    lecturer.Specialization = txtSpecialization!.Text.Trim();
                    if (!IsEditMode) lecturer.Password = txtPassword.Text;
                    lecturer.Role = "lecturer";
                    return lecturer;

                case "company":
                    var company = UserData as Company ?? new Company();
                    company.CompanyName = txtCompanyName!.Text.Trim();
                    company.ContactPerson = txtContactPerson!.Text.Trim();
                    company.ContactEmail = txtEmail.Text.Trim();
                    company.ContactPhone = txtPhone.Text.Trim();
                    company.Address = txtAddress!.Text.Trim();
                    if (!IsEditMode) company.Password = txtPassword.Text;
                    company.Role = "company";
                    return company;

                default:
                    throw new InvalidOperationException("Invalid user role");
            }
        }

        private string GetRoleName()
        {
            return UserRole.ToLower() switch
            {
                "student" => "Sinh viên",
                "lecturer" => "Giảng viên",
                "company" => "Doanh nghiệp",
                _ => "Người dùng"
            };
        }
    }
}

