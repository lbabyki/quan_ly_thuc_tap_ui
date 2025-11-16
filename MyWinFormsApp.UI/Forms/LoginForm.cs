using MyWinFormsApp.Business.Services;
using MyWinFormsApp.MockData;
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

                        // TODO: Mở form chính tương ứng với role
                        // Ví dụ: if (user.Role == "student") { new StudentForm().Show(); }
                        
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

                        // TODO: Mở form chính tương ứng với role
                        
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
    }
}

