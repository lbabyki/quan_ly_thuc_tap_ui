using MyWinFormsApp.Business.Models;
using MyWinFormsApp.DataAccess.Repositories;
using System;
using System.Threading.Tasks;

namespace MyWinFormsApp.Business.Services
{
    /// <summary>
    /// UserService - Business Logic cho User
    /// </summary>
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService()
        {
            _userRepository = new UserRepository();
        }

        /// <summary>
        /// Đăng nhập
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">Mật khẩu</param>
        /// <returns>Tuple (success, message, user)</returns>
        public async Task<(bool Success, string Message, User? User)> LoginAsync(string email, string password)
        {
            try
            {
                // Validate input
                if (string.IsNullOrWhiteSpace(email))
                {
                    return (false, "Email không được để trống", null);
                }

                if (string.IsNullOrWhiteSpace(password))
                {
                    return (false, "Mật khẩu không được để trống", null);
                }

                // Validate email format (đơn giản)
                if (!email.Contains("@"))
                {
                    return (false, "Email không hợp lệ", null);
                }

                // Gọi Repository để login
                var response = await _userRepository.LoginAsync(email, password);

                if (response.Success && response.Data != null)
                {
                    // Map từ DTO sang Business Model
                    var user = new User
                    {
                        UserId = response.Data.User?.Id,
                        Email = response.Data.User?.Email ?? email,
                        Role = response.Data.User?.Role ?? "student",
                        Token = response.Data.Token,
                        FullName = response.Data.User?.FullName,
                        UserName = response.Data.User?.UserName,
                        Phone = response.Data.User?.Phone
                    };

                    return (true, "Đăng nhập thành công", user);
                }
                else
                {
                    return (false, response.Message ?? "Đăng nhập thất bại", null);
                }
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        /// <summary>
        /// Đăng xuất
        /// </summary>
        public void Logout()
        {
            _userRepository.Logout();
        }
    }
}

