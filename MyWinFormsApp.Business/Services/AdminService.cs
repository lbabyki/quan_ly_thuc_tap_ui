using MyWinFormsApp.Business.Models;
using MyWinFormsApp.DataAccess.Models;
using MyWinFormsApp.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyWinFormsApp.Business.Services
{
    /// <summary>
    /// Service xử lý business logic cho Admin
    /// </summary>
    public class AdminService
    {
        private readonly AdminRepository _repository;

        public AdminService()
        {
            _repository = new AdminRepository();
        }

        /// <summary>
        /// Lấy danh sách tất cả người dùng
        /// </summary>
        public async Task<(bool Success, string Message, List<User>? Users)> GetAllUsersAsync()
        {
            try
            {
                var response = await _repository.GetAllUsersAsync();
                
                if (response.Success && response.Data != null)
                {
                    var users = response.Data.Select(MapDtoToUser).ToList();
                    return (true, "Success", users);
                }
                else
                {
                    return (false, response.Message ?? "Failed to get users", null);
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}", null);
            }
        }

        /// <summary>
        /// Lấy danh sách người dùng theo role
        /// </summary>
        public async Task<(bool Success, string Message, List<User>? Users)> GetUsersByRoleAsync(string role)
        {
            // Validate role
            if (string.IsNullOrWhiteSpace(role))
            {
                return (false, "Role không được để trống", null);
            }

            var validRoles = new[] { "student", "lecturer", "company", "admin" };
            if (!validRoles.Contains(role.ToLower()))
            {
                return (false, "Role không hợp lệ", null);
            }

            try
            {
                var response = await _repository.GetUsersByRoleAsync(role);
                
                if (response.Success && response.Data != null)
                {
                    var users = response.Data.Select(MapDtoToUser).ToList();
                    return (true, "Success", users);
                }
                else
                {
                    return (false, response.Message ?? "Failed to get users", null);
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}", null);
            }
        }

        /// <summary>
        /// Tạo người dùng mới
        /// </summary>
        public async Task<(bool Success, string Message, User? User)> CreateUserAsync(User user)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(user.Email))
            {
                return (false, "Email không được để trống", null);
            }

            if (!user.Email.Contains("@"))
            {
                return (false, "Email không hợp lệ", null);
            }

            if (string.IsNullOrWhiteSpace(user.Role))
            {
                return (false, "Role không được để trống", null);
            }

            if (string.IsNullOrWhiteSpace(user.FullName))
            {
                return (false, "Họ tên không được để trống", null);
            }

            try
            {
                var userDto = MapUserToDto(user);
                var response = await _repository.CreateUserAsync(userDto);
                
                if (response.Success && response.Data != null)
                {
                    var createdUser = MapDtoToUser(response.Data);
                    return (true, "Tạo người dùng thành công", createdUser);
                }
                else
                {
                    return (false, response.Message ?? "Failed to create user", null);
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}", null);
            }
        }

        /// <summary>
        /// Cập nhật thông tin người dùng
        /// </summary>
        public async Task<(bool Success, string Message, User? User)> UpdateUserAsync(string userId, User user)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(userId))
            {
                return (false, "User ID không được để trống", null);
            }

            if (string.IsNullOrWhiteSpace(user.Email))
            {
                return (false, "Email không được để trống", null);
            }

            if (!user.Email.Contains("@"))
            {
                return (false, "Email không hợp lệ", null);
            }

            if (string.IsNullOrWhiteSpace(user.FullName))
            {
                return (false, "Họ tên không được để trống", null);
            }

            try
            {
                var userDto = MapUserToDto(user);
                var response = await _repository.UpdateUserAsync(userId, userDto);

                if (response.Success && response.Data != null)
                {
                    var updatedUser = MapDtoToUser(response.Data);
                    return (true, "Cập nhật người dùng thành công", updatedUser);
                }
                else
                {
                    return (false, response.Message ?? "Failed to update user", null);
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}", null);
            }
        }

        /// <summary>
        /// Xóa người dùng
        /// </summary>
        public async Task<(bool Success, string Message)> DeleteUserAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return (false, "User ID không được để trống");
            }

            try
            {
                var response = await _repository.DeleteUserAsync(userId);

                if (response.Success)
                {
                    return (true, "Xóa người dùng thành công");
                }
                else
                {
                    return (false, response.Message ?? "Failed to delete user");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Reset mật khẩu người dùng
        /// </summary>
        public async Task<(bool Success, string Message)> ResetPasswordAsync(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return (false, "User ID không được để trống");
            }

            try
            {
                var response = await _repository.ResetPasswordAsync(userId);

                if (response.Success)
                {
                    return (true, "Reset mật khẩu thành công");
                }
                else
                {
                    return (false, response.Message ?? "Failed to reset password");
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách đề tài thực tập
        /// </summary>
        public async Task<(bool Success, string Message, List<InternshipTopic>? Topics)> GetTopicsAsync(string? status = null)
        {
            try
            {
                var response = await _repository.GetTopicsAsync(status);

                if (response.Success && response.Data != null)
                {
                    var topics = response.Data.Select(MapDtoToTopic).ToList();
                    return (true, "Success", topics);
                }
                else
                {
                    return (false, response.Message ?? "Failed to get topics", null);
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}", null);
            }
        }

        /// <summary>
        /// Tạo đề tài mới
        /// </summary>
        public async Task<(bool Success, string Message, InternshipTopic? Topic)> CreateTopicAsync(InternshipTopic topic)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(topic.Title))
            {
                return (false, "Tiêu đề không được để trống", null);
            }

            if (string.IsNullOrWhiteSpace(topic.Description))
            {
                return (false, "Mô tả không được để trống", null);
            }

            try
            {
                var topicDto = MapTopicToDto(topic);
                var response = await _repository.CreateTopicAsync(topicDto);

                if (response.Success && response.Data != null)
                {
                    var createdTopic = MapDtoToTopic(response.Data);
                    return (true, "Tạo đề tài thành công", createdTopic);
                }
                else
                {
                    return (false, response.Message ?? "Failed to create topic", null);
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}", null);
            }
        }

        /// <summary>
        /// Cập nhật đề tài
        /// </summary>
        public async Task<(bool Success, string Message, InternshipTopic? Topic)> UpdateTopicAsync(string topicId, InternshipTopic topic)
        {
            // Validate input
            if (string.IsNullOrWhiteSpace(topicId))
            {
                return (false, "Topic ID không được để trống", null);
            }

            if (string.IsNullOrWhiteSpace(topic.Title))
            {
                return (false, "Tiêu đề không được để trống", null);
            }

            try
            {
                var topicDto = MapTopicToDto(topic);
                var response = await _repository.UpdateTopicAsync(topicId, topicDto);

                if (response.Success && response.Data != null)
                {
                    var updatedTopic = MapDtoToTopic(response.Data);
                    return (true, "Cập nhật đề tài thành công", updatedTopic);
                }
                else
                {
                    return (false, response.Message ?? "Failed to update topic", null);
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}", null);
            }
        }

        /// <summary>
        /// Duyệt đề tài thực tập
        /// </summary>
        public async Task<(bool Success, string Message, InternshipTopic? Topic)> ApproveTopicAsync(string topicId)
        {
            if (string.IsNullOrWhiteSpace(topicId))
            {
                return (false, "Topic ID không được để trống", null);
            }

            try
            {
                var response = await _repository.ApproveTopicAsync(topicId);

                if (response.Success && response.Data != null)
                {
                    var topic = MapDtoToTopic(response.Data);
                    return (true, "Duyệt đề tài thành công", topic);
                }
                else
                {
                    return (false, response.Message ?? "Failed to approve topic", null);
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}", null);
            }
        }

        /// <summary>
        /// Từ chối đề tài thực tập
        /// </summary>
        public async Task<(bool Success, string Message, InternshipTopic? Topic)> RejectTopicAsync(string topicId, string reason)
        {
            if (string.IsNullOrWhiteSpace(topicId))
            {
                return (false, "Topic ID không được để trống", null);
            }

            if (string.IsNullOrWhiteSpace(reason))
            {
                return (false, "Lý do từ chối không được để trống", null);
            }

            try
            {
                var response = await _repository.RejectTopicAsync(topicId, reason);

                if (response.Success && response.Data != null)
                {
                    var topic = MapDtoToTopic(response.Data);
                    return (true, "Từ chối đề tài thành công", topic);
                }
                else
                {
                    return (false, response.Message ?? "Failed to reject topic", null);
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}", null);
            }
        }

        /// <summary>
        /// Lấy nhật ký hệ thống
        /// </summary>
        public async Task<(bool Success, string Message, List<SystemLog>? Logs)> GetSystemLogsAsync(int limit = 100)
        {
            try
            {
                var response = await _repository.GetSystemLogsAsync(limit);

                if (response.Success && response.Data != null)
                {
                    var logs = response.Data.Select(MapDtoToLog).ToList();
                    return (true, "Success", logs);
                }
                else
                {
                    return (false, response.Message ?? "Failed to get logs", null);
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}", null);
            }
        }

        /// <summary>
        /// Lấy thống kê hệ thống
        /// </summary>
        public async Task<(bool Success, string Message, Statistics? Stats)> GetStatisticsAsync()
        {
            try
            {
                var response = await _repository.GetStatisticsAsync();

                if (response.Success && response.Data != null)
                {
                    var stats = MapDtoToStatistics(response.Data);
                    return (true, "Success", stats);
                }
                else
                {
                    return (false, response.Message ?? "Failed to get statistics", null);
                }
            }
            catch (Exception ex)
            {
                return (false, $"Error: {ex.Message}", null);
            }
        }

        #region Mapping Methods

        private User MapDtoToUser(UserDto dto)
        {
            return new User
            {
                UserId = dto.Id,
                Email = dto.Email ?? string.Empty,
                Role = dto.Role ?? string.Empty,
                FullName = dto.FullName ?? string.Empty,
                UserName = dto.UserName,
                Phone = dto.Phone,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt
            };
        }

        private UserDto MapUserToDto(User user)
        {
            return new UserDto
            {
                Id = user.UserId,
                Email = user.Email,
                Role = user.Role,
                FullName = user.FullName,
                UserName = user.UserName,
                Phone = user.Phone
            };
        }

        private InternshipTopic MapDtoToTopic(InternshipTopicDto dto)
        {
            return new InternshipTopic
            {
                Id = dto.Id,
                Title = dto.Title ?? string.Empty,
                Description = dto.Description ?? string.Empty,
                CompanyId = dto.CompanyId ?? string.Empty,
                CompanyName = dto.CompanyName ?? string.Empty,
                LecturerId = dto.LecturerId,
                LecturerName = dto.LecturerName,
                Status = dto.Status ?? "pending",
                MaxStudents = dto.MaxStudents,
                CurrentStudents = dto.CurrentStudents,
                Requirements = dto.Requirements ?? string.Empty,
                Skills = dto.Skills ?? string.Empty,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate,
                Deadline = dto.Deadline,
                RejectionReason = dto.RejectionReason,
                CreatedAt = dto.CreatedAt ?? DateTime.Now,
                UpdatedAt = dto.UpdatedAt
            };
        }

        private InternshipTopicDto MapTopicToDto(InternshipTopic topic)
        {
            return new InternshipTopicDto
            {
                Id = topic.Id,
                Title = topic.Title,
                Description = topic.Description,
                CompanyId = topic.CompanyId,
                CompanyName = topic.CompanyName,
                LecturerId = topic.LecturerId,
                LecturerName = topic.LecturerName,
                Status = topic.Status,
                MaxStudents = topic.MaxStudents,
                CurrentStudents = topic.CurrentStudents,
                Requirements = topic.Requirements,
                Skills = topic.Skills,
                StartDate = topic.StartDate,
                EndDate = topic.EndDate,
                Deadline = topic.Deadline,
                RejectionReason = topic.RejectionReason,
                CreatedAt = topic.CreatedAt,
                UpdatedAt = topic.UpdatedAt
            };
        }

        private SystemLog MapDtoToLog(SystemLogDto dto)
        {
            return new SystemLog
            {
                Id = dto.Id,
                UserId = dto.UserId ?? string.Empty,
                UserName = dto.UserName ?? string.Empty,
                UserEmail = dto.UserEmail ?? string.Empty,
                Action = dto.Action ?? string.Empty,
                ActionType = dto.ActionType ?? string.Empty,
                TargetType = dto.TargetType ?? string.Empty,
                TargetId = dto.TargetId,
                Details = dto.Details,
                IpAddress = dto.IpAddress ?? string.Empty,
                CreatedAt = dto.CreatedAt ?? DateTime.Now
            };
        }

        private Statistics MapDtoToStatistics(StatisticsDto dto)
        {
            return new Statistics
            {
                TotalStudents = dto.TotalStudents,
                TotalLecturers = dto.TotalLecturers,
                TotalCompanies = dto.TotalCompanies,
                TotalInternships = dto.TotalInternships,
                ActiveInternships = dto.ActiveInternships,
                CompletedInternships = dto.CompletedInternships,
                PendingTopics = dto.PendingTopics,
                AverageScore = dto.AverageScore,
                StudentsByCompany = dto.StudentsByCompany?.Select(x => new CompanyStudentCount
                {
                    CompanyId = x.CompanyId ?? string.Empty,
                    CompanyName = x.CompanyName ?? string.Empty,
                    StudentCount = x.StudentCount
                }).ToList() ?? new List<CompanyStudentCount>(),
                ScoresByMajor = dto.ScoresByMajor?.Select(x => new MajorAverageScore
                {
                    Major = x.Major ?? string.Empty,
                    AverageScore = x.AverageScore,
                    StudentCount = x.StudentCount
                }).ToList() ?? new List<MajorAverageScore>(),
                MonthlyStats = dto.MonthlyStats?.Select(x => new MonthlyStatistic
                {
                    Month = x.Month,
                    Year = x.Year,
                    NewStudents = x.NewStudents,
                    CompletedInternships = x.CompletedInternships
                }).ToList() ?? new List<MonthlyStatistic>()
            };
        }

        #endregion
    }
}

