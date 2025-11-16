using MyWinFormsApp.Business.Services;
using MyWinFormsApp.MockData;
using MyWinFormsApp.UI.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace MyWinFormsApp.Forms
{
    /// <summary>
    /// LoginForm - Form đăng nhập với màu sắc Đại học Lạc Hồng
    /// Màu xanh dương: #0054A6
    /// Màu cam: #F36F21
    /// </summary>
    public partial class LoginForm : Form
    {
        private readonly UserService _userService;
        private bool _useMockData = true; // Set true để dùng mock data, false để gọi API thật

        public LoginForm()
        {
            InitializeComponent();
            _userService = new UserService();
            SetupColors();
        }

        /// <summary>
        /// Thiết lập màu sắc Đại học Lạc Hồng
        /// </summary>
        private void SetupColors()
        {
            // Màu nền form
            this.BackColor = ColorTranslator.FromHtml("#0054A6"); // Xanh dương LHU

            // Màu cho panel chứa form login
            if (panelLogin != null)
            {
                panelLogin.BackColor = Color.White;
            }

            // Màu cho button login
            if (btnLogin != null)
            {
                btnLogin.BackColor = ColorTranslator.FromHtml("#F36F21"); // Cam LHU
                btnLogin.ForeColor = Color.White;
                btnLogin.FlatStyle = FlatStyle.Flat;
                btnLogin.FlatAppearance.BorderSize = 0;
            }

            // Màu cho label title
            if (lblTitle != null)
            {
                lblTitle.ForeColor = ColorTranslator.FromHtml("#0054A6");
            }
        }

        /// <summary>
        /// Xử lý sự kiện click button Login
        /// </summary>
        private async void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                // Disable button để tránh click nhiều lần
                btnLogin.Enabled = false;
                btnLogin.Text = "Đang đăng nhập...";

                string email = txtEmail.Text.Trim();
                string password = txtPassword.Text;

                if (_useMockData)
                {
                    // Sử dụng Mock Data để test
                    var (success, message, user) = UserMockData.MockLogin(email, password);

                    if (success && user != null)
                    {
                        MessageBox.Show(
                            $"Đăng nhập thành công!\n\nChào mừng: {user.FullName}\nRole: {user.Role}\n\n(Sử dụng Mock Data)",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        // Mở form tương ứng với role
                        OpenFormByRole(user.Role, user.Token);

                        this.Hide(); // Ẩn form login
                    }
                    else
                    {
                        MessageBox.Show(
                            message,
                            "Lỗi đăng nhập",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
                else
                {
                    // Gọi API thật
                    var (success, message, user) = await _userService.LoginAsync(email, password);

                    if (success && user != null)
                    {
                        MessageBox.Show(
                            $"Đăng nhập thành công!\n\nChào mừng: {user.FullName}\nRole: {user.Role}",
                            "Thành công",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information
                        );

                        // Mở form tương ứng với role
                        OpenFormByRole(user.Role, user.Token);

                        this.Hide(); // Ẩn form login
                    }
                    else
                    {
                        MessageBox.Show(
                            message,
                            "Lỗi đăng nhập",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Có lỗi xảy ra: {ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
            }
            finally
            {
                // Enable lại button
                btnLogin.Enabled = true;
                btnLogin.Text = "Đăng nhập";
            }
        }

        /// <summary>
        /// Xử lý Enter key trong textbox password
        /// </summary>
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }

        /// <summary>
        /// Mở form tương ứng với role của user
        /// </summary>
        /// <param name="role">Role của user (admin, student, lecturer, company)</param>
        /// <param name="token">JWT token (nếu có)</param>
        private void OpenFormByRole(string role, string? token)
        {
            Form? formToOpen = null;

            switch (role.ToLower())
            {
                case "admin":
                    formToOpen = new AdminForm();
                    break;

                case "student":
                    formToOpen = new StudentForm();
                    break;

                case "lecturer":
                case "teacher":
                    formToOpen = new TeacherForm();
                    break;

                case "company":
                    formToOpen = new CompanyForm();
                    break;

                default:
                    MessageBox.Show(
                        $"Role '{role}' không được hỗ trợ",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
            }

            if (formToOpen != null)
            {
                // Đăng ký sự kiện khi form đóng thì hiện lại LoginForm
                formToOpen.FormClosed += (s, e) =>
                {
                    this.Show();
                    txtPassword.Clear();
                    txtEmail.Focus();
                };

                formToOpen.Show();
            }
        }
    }
}

