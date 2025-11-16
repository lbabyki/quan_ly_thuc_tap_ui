using MyWinFormsApp.Business.Models;
using System.Collections.Generic;

namespace MyWinFormsApp.MockData
{
    /// <summary>
    /// Mock Data cho User - dùng để test mà không cần gọi API thật
    /// </summary>
    public static class UserMockData
    {
        /// <summary>
        /// Danh sách User giả lập
        /// </summary>
        public static List<User> GetMockUsers()
        {
            return new List<User>
            {
                // Admin
                new User
                {
                    UserId = "admin001",
                    Email = "admin@lhu.edu.vn",
                    Password = "admin123", // Trong thực tế không nên lưu password như này
                    Role = "admin",
                    FullName = "Quản Trị Viên",
                    UserName = "admin",
                    Phone = "0901234567",
                    Token = "mock_token_admin_001"
                },

                // Student
                new User
                {
                    UserId = "student001",
                    Email = "student@lhu.edu.vn",
                    Password = "student123",
                    Role = "student",
                    FullName = "Nguyễn Văn A",
                    UserName = "nguyenvana",
                    Phone = "0912345678",
                    Token = "mock_token_student_001"
                },

                // Lecturer
                new User
                {
                    UserId = "lecturer001",
                    Email = "lecturer@lhu.edu.vn",
                    Password = "lecturer123",
                    Role = "lecturer",
                    FullName = "TS. Trần Thị B",
                    UserName = "tranthib",
                    Phone = "0923456789",
                    Token = "mock_token_lecturer_001"
                },

                // Company
                new User
                {
                    UserId = "company001",
                    Email = "company@example.com",
                    Password = "company123",
                    Role = "company",
                    FullName = "Công ty ABC",
                    UserName = "companyabc",
                    Phone = "0934567890",
                    Token = "mock_token_company_001"
                }
            };
        }

        /// <summary>
        /// Tìm user theo email và password (dùng cho mock login)
        /// </summary>
        public static User? FindUser(string email, string password)
        {
            var users = GetMockUsers();
            return users.Find(u => u.Email == email && u.Password == password);
        }

        /// <summary>
        /// Kiểm tra login với mock data
        /// </summary>
        public static (bool Success, string Message, User? User) MockLogin(string email, string password)
        {
            if (string.IsNullOrWhiteSpace(email))
            {
                return (false, "Email không được để trống", null);
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return (false, "Mật khẩu không được để trống", null);
            }

            var user = FindUser(email, password);

            if (user != null)
            {
                return (true, "Đăng nhập thành công (Mock Data)", user);
            }
            else
            {
                return (false, "Email hoặc mật khẩu không đúng", null);
            }
        }
    }
}

