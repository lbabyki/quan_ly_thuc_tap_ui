using MyWinFormsApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWinFormsApp.MockData
{
    /// <summary>
    /// Mock data cho Admin module
    /// </summary>
    public static class AdminMockData
    {
        private static List<User> _users = new List<User>();
        private static List<InternshipTopic> _topics = new List<InternshipTopic>();
        private static List<SystemLog> _logs = new List<SystemLog>();
        private static Statistics _statistics = new Statistics();

        static AdminMockData()
        {
            InitializeUsers();
            InitializeTopics();
            InitializeLogs();
            InitializeStatistics();
        }

        #region Users Management

        public static List<User> GetAllUsers()
        {
            return _users.ToList();
        }

        public static List<User> GetUsersByRole(string role)
        {
            return _users.Where(u => u.Role.Equals(role, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static (bool Success, string Message, User? User) CreateUser(User user)
        {
            // Check if email already exists
            if (_users.Any(u => u.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase)))
            {
                return (false, "Email đã tồn tại", null);
            }

            user.UserId = Guid.NewGuid().ToString();
            user.CreatedAt = DateTime.Now;
            _users.Add(user);

            return (true, "Tạo người dùng thành công", user);
        }

        public static (bool Success, string Message, User? User) UpdateUser(string userId, User user)
        {
            var existingUser = _users.FirstOrDefault(u => u.UserId == userId);
            if (existingUser == null)
            {
                return (false, "Không tìm thấy người dùng", null);
            }

            existingUser.Email = user.Email;
            existingUser.FullName = user.FullName;
            existingUser.Phone = user.Phone;
            existingUser.Role = user.Role;
            existingUser.UpdatedAt = DateTime.Now;

            return (true, "Cập nhật người dùng thành công", existingUser);
        }

        public static (bool Success, string Message) DeleteUser(string userId)
        {
            var user = _users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return (false, "Không tìm thấy người dùng");
            }

            _users.Remove(user);
            return (true, "Xóa người dùng thành công");
        }

        public static (bool Success, string Message) ResetPassword(string userId)
        {
            var user = _users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return (false, "Không tìm thấy người dùng");
            }

            // In real app, would reset password to default
            return (true, "Reset mật khẩu thành công. Mật khẩu mới: 123456");
        }

        #endregion

        #region Topics Management

        public static List<InternshipTopic> GetTopics(string? status = null)
        {
            if (string.IsNullOrEmpty(status))
            {
                return _topics.ToList();
            }
            return _topics.Where(t => t.Status.Equals(status, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public static (bool Success, string Message, InternshipTopic? Topic) ApproveTopic(string topicId)
        {
            var topic = _topics.FirstOrDefault(t => t.Id == topicId);
            if (topic == null)
            {
                return (false, "Không tìm thấy đề tài", null);
            }

            topic.Status = "approved";
            topic.UpdatedAt = DateTime.Now;

            return (true, "Duyệt đề tài thành công", topic);
        }

        public static (bool Success, string Message, InternshipTopic? Topic) RejectTopic(string topicId, string reason)
        {
            var topic = _topics.FirstOrDefault(t => t.Id == topicId);
            if (topic == null)
            {
                return (false, "Không tìm thấy đề tài", null);
            }

            topic.Status = "rejected";
            topic.RejectionReason = reason;
            topic.UpdatedAt = DateTime.Now;

            return (true, "Từ chối đề tài thành công", topic);
        }

        #endregion

        #region System Logs

        public static List<SystemLog> GetSystemLogs(int limit = 100)
        {
            return _logs.OrderByDescending(l => l.CreatedAt).Take(limit).ToList();
        }

        #endregion

        #region Statistics

        public static Statistics GetStatistics()
        {
            return _statistics;
        }

        #endregion

        #region Initialization

        private static void InitializeUsers()
        {
            _users = new List<User>
            {
                // Admin users
                new User
                {
                    UserId = "admin001",
                    Email = "admin@lhu.edu.vn",
                    Password = "admin123",
                    Role = "admin",
                    FullName = "Nguyễn Văn Admin",
                    UserName = "admin",
                    Phone = "0901234567",
                    CreatedAt = DateTime.Now.AddMonths(-6)
                },
                // Student users
                new User
                {
                    UserId = "student001",
                    Email = "student@lhu.edu.vn",
                    Password = "student123",
                    Role = "student",
                    FullName = "Trần Thị Sinh Viên",
                    UserName = "student",
                    Phone = "0912345678",
                    CreatedAt = DateTime.Now.AddMonths(-3)
                },
                new User
                {
                    UserId = "student002",
                    Email = "nguyenvana@lhu.edu.vn",
                    Password = "123456",
                    Role = "student",
                    FullName = "Nguyễn Văn A",
                    UserName = "nguyenvana",
                    Phone = "0923456789",
                    CreatedAt = DateTime.Now.AddMonths(-3)
                },
                new User
                {
                    UserId = "student003",
                    Email = "lethib@lhu.edu.vn",
                    Password = "123456",
                    Role = "student",
                    FullName = "Lê Thị B",
                    UserName = "lethib",
                    Phone = "0934567890",
                    CreatedAt = DateTime.Now.AddMonths(-2)
                },
                // Lecturer users
                new User
                {
                    UserId = "lecturer001",
                    Email = "lecturer@lhu.edu.vn",
                    Password = "lecturer123",
                    Role = "lecturer",
                    FullName = "TS. Phạm Văn Giảng Viên",
                    UserName = "lecturer",
                    Phone = "0945678901",
                    CreatedAt = DateTime.Now.AddYears(-2)
                },
                new User
                {
                    UserId = "lecturer002",
                    Email = "tranvanc@lhu.edu.vn",
                    Password = "123456",
                    Role = "lecturer",
                    FullName = "ThS. Trần Văn C",
                    UserName = "tranvanc",
                    Phone = "0956789012",
                    CreatedAt = DateTime.Now.AddYears(-1)
                },
                // Company users
                new User
                {
                    UserId = "company001",
                    Email = "company@example.com",
                    Password = "company123",
                    Role = "company",
                    FullName = "Công ty TNHH ABC",
                    UserName = "company",
                    Phone = "0967890123",
                    CreatedAt = DateTime.Now.AddMonths(-4)
                },
                new User
                {
                    UserId = "company002",
                    Email = "fpt@company.com",
                    Password = "123456",
                    Role = "company",
                    FullName = "Công ty FPT Software",
                    UserName = "fpt",
                    Phone = "0978901234",
                    CreatedAt = DateTime.Now.AddMonths(-5)
                },
                new User
                {
                    UserId = "company003",
                    Email = "vng@company.com",
                    Password = "123456",
                    Role = "company",
                    FullName = "Công ty VNG Corporation",
                    UserName = "vng",
                    Phone = "0989012345",
                    CreatedAt = DateTime.Now.AddMonths(-3)
                }
            };
        }

        private static void InitializeTopics()
        {
            _topics = new List<InternshipTopic>
            {
                new InternshipTopic
                {
                    Id = "topic001",
                    Title = "Phát triển ứng dụng Mobile với React Native",
                    Description = "Xây dựng ứng dụng mobile đa nền tảng sử dụng React Native",
                    CompanyId = "company002",
                    CompanyName = "Công ty FPT Software",
                    LecturerId = "lecturer001",
                    LecturerName = "TS. Phạm Văn Giảng Viên",
                    Status = "pending",
                    MaxStudents = 2,
                    CurrentStudents = 0,
                    Requirements = "Có kiến thức về JavaScript, React",
                    Skills = "React Native, JavaScript, Mobile Development",
                    StartDate = DateTime.Now.AddDays(30),
                    EndDate = DateTime.Now.AddDays(120),
                    Deadline = DateTime.Now.AddDays(15),
                    CreatedAt = DateTime.Now.AddDays(-5)
                },
                new InternshipTopic
                {
                    Id = "topic002",
                    Title = "Xây dựng hệ thống quản lý kho",
                    Description = "Phát triển web application quản lý kho hàng",
                    CompanyId = "company001",
                    CompanyName = "Công ty TNHH ABC",
                    LecturerId = "lecturer002",
                    LecturerName = "ThS. Trần Văn C",
                    Status = "approved",
                    MaxStudents = 3,
                    CurrentStudents = 2,
                    Requirements = "Có kiến thức về C#, ASP.NET",
                    Skills = "C#, ASP.NET Core, SQL Server",
                    StartDate = DateTime.Now.AddDays(20),
                    EndDate = DateTime.Now.AddDays(110),
                    Deadline = DateTime.Now.AddDays(10),
                    CreatedAt = DateTime.Now.AddDays(-10)
                },
                new InternshipTopic
                {
                    Id = "topic003",
                    Title = "Phát triển game 2D với Unity",
                    Description = "Tạo game 2D casual cho mobile",
                    CompanyId = "company003",
                    CompanyName = "Công ty VNG Corporation",
                    LecturerId = "lecturer001",
                    LecturerName = "TS. Phạm Văn Giảng Viên",
                    Status = "pending",
                    MaxStudents = 2,
                    CurrentStudents = 0,
                    Requirements = "Có kiến thức về Unity, C#",
                    Skills = "Unity, C#, Game Development",
                    StartDate = DateTime.Now.AddDays(25),
                    EndDate = DateTime.Now.AddDays(115),
                    Deadline = DateTime.Now.AddDays(12),
                    CreatedAt = DateTime.Now.AddDays(-3)
                },
                new InternshipTopic
                {
                    Id = "topic004",
                    Title = "AI Chatbot cho customer service",
                    Description = "Xây dựng chatbot sử dụng AI/ML",
                    CompanyId = "company002",
                    CompanyName = "Công ty FPT Software",
                    Status = "rejected",
                    MaxStudents = 1,
                    CurrentStudents = 0,
                    Requirements = "Có kiến thức về Python, Machine Learning",
                    Skills = "Python, NLP, Machine Learning",
                    RejectionReason = "Yêu cầu kỹ năng quá cao cho sinh viên thực tập",
                    CreatedAt = DateTime.Now.AddDays(-15)
                }
            };
        }

        private static void InitializeLogs()
        {
            _logs = new List<SystemLog>
            {
                new SystemLog
                {
                    Id = "log001",
                    UserId = "admin001",
                    UserName = "admin",
                    UserEmail = "admin@lhu.edu.vn",
                    Action = "Đăng nhập hệ thống",
                    ActionType = "login",
                    TargetType = "system",
                    IpAddress = "192.168.1.100",
                    CreatedAt = DateTime.Now.AddMinutes(-30)
                },
                new SystemLog
                {
                    Id = "log002",
                    UserId = "admin001",
                    UserName = "admin",
                    UserEmail = "admin@lhu.edu.vn",
                    Action = "Duyệt đề tài thực tập",
                    ActionType = "update",
                    TargetType = "topic",
                    TargetId = "topic002",
                    Details = "Duyệt đề tài: Xây dựng hệ thống quản lý kho",
                    IpAddress = "192.168.1.100",
                    CreatedAt = DateTime.Now.AddMinutes(-25)
                },
                new SystemLog
                {
                    Id = "log003",
                    UserId = "company002",
                    UserName = "fpt",
                    UserEmail = "fpt@company.com",
                    Action = "Tạo đề tài thực tập mới",
                    ActionType = "create",
                    TargetType = "topic",
                    TargetId = "topic001",
                    Details = "Tạo đề tài: Phát triển ứng dụng Mobile với React Native",
                    IpAddress = "192.168.1.50",
                    CreatedAt = DateTime.Now.AddHours(-2)
                },
                new SystemLog
                {
                    Id = "log004",
                    UserId = "student001",
                    UserName = "student",
                    UserEmail = "student@lhu.edu.vn",
                    Action = "Đăng ký thực tập",
                    ActionType = "create",
                    TargetType = "internship",
                    TargetId = "topic002",
                    Details = "Đăng ký đề tài: Xây dựng hệ thống quản lý kho",
                    IpAddress = "192.168.1.75",
                    CreatedAt = DateTime.Now.AddHours(-5)
                },
                new SystemLog
                {
                    Id = "log005",
                    UserId = "admin001",
                    UserName = "admin",
                    UserEmail = "admin@lhu.edu.vn",
                    Action = "Từ chối đề tài thực tập",
                    ActionType = "update",
                    TargetType = "topic",
                    TargetId = "topic004",
                    Details = "Từ chối đề tài: AI Chatbot cho customer service",
                    IpAddress = "192.168.1.100",
                    CreatedAt = DateTime.Now.AddDays(-1)
                }
            };
        }

        private static void InitializeStatistics()
        {
            _statistics = new Statistics
            {
                TotalStudents = 3,
                TotalLecturers = 2,
                TotalCompanies = 3,
                TotalInternships = 4,
                ActiveInternships = 2,
                CompletedInternships = 0,
                PendingTopics = 2,
                AverageScore = 8.5,
                StudentsByCompany = new List<CompanyStudentCount>
                {
                    new CompanyStudentCount { CompanyId = "company001", CompanyName = "Công ty TNHH ABC", StudentCount = 2 },
                    new CompanyStudentCount { CompanyId = "company002", CompanyName = "Công ty FPT Software", StudentCount = 1 },
                    new CompanyStudentCount { CompanyId = "company003", CompanyName = "Công ty VNG Corporation", StudentCount = 0 }
                },
                ScoresByMajor = new List<MajorAverageScore>
                {
                    new MajorAverageScore { Major = "Công nghệ thông tin", AverageScore = 8.7, StudentCount = 2 },
                    new MajorAverageScore { Major = "Kỹ thuật phần mềm", AverageScore = 8.3, StudentCount = 1 }
                },
                MonthlyStats = new List<MonthlyStatistic>
                {
                    new MonthlyStatistic { Month = DateTime.Now.Month - 2, Year = DateTime.Now.Year, NewStudents = 5, CompletedInternships = 3 },
                    new MonthlyStatistic { Month = DateTime.Now.Month - 1, Year = DateTime.Now.Year, NewStudents = 3, CompletedInternships = 2 },
                    new MonthlyStatistic { Month = DateTime.Now.Month, Year = DateTime.Now.Year, NewStudents = 2, CompletedInternships = 0 }
                }
            };
        }

        #endregion
    }
}

