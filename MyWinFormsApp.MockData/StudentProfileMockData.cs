using System;
using System.Collections.Generic;
using System.Linq;
using MyWinFormsApp.Business.Models;

namespace MyWinFormsApp.MockData
{
    /// <summary>
    /// Mock data cho module Sinh viên (Student Portal)
    /// </summary>
    public static class StudentProfileMockData
    {
        private static StudentProfile _currentStudent = new StudentProfile
        {
            Id = "SV001",
            StudentCode = "2021600001",
            FullName = "Nguyễn Văn An",
            Email = "an.nv@student.lhu.edu.vn",
            Phone = "0901234567",
            Department = "Công nghệ thông tin",
            Year = 3,
            AvatarUrl = null,
            Description = "Sinh viên năm 3, chuyên ngành Công nghệ phần mềm. Quan tâm đến lập trình Web và Mobile.",
            CvUrl = null,
            Status = "approved",
            CreatedAt = DateTime.Now.AddMonths(-6),
            UpdatedAt = DateTime.Now
        };

        private static List<InternshipRegistration> _registrations = new List<InternshipRegistration>
        {
            new InternshipRegistration
            {
                Id = "REG001",
                StudentId = "SV001",
                StudentName = "Nguyễn Văn An",
                TopicId = "topic002",
                TopicTitle = "Xây dựng hệ thống quản lý kho",
                CompanyId = "company001",
                CompanyName = "Công ty TNHH ABC",
                CoverLetterUrl = null,
                Status = "approved",
                RegisteredAt = DateTime.Now.AddMonths(-2),
                ApprovedAt = DateTime.Now.AddMonths(-2).AddDays(3)
            },
            new InternshipRegistration
            {
                Id = "REG002",
                StudentId = "SV001",
                StudentName = "Nguyễn Văn An",
                TopicId = "topic001",
                TopicTitle = "Phát triển ứng dụng Mobile với React Native",
                CompanyId = "company002",
                CompanyName = "Công ty FPT Software",
                CoverLetterUrl = null,
                Status = "pending",
                RegisteredAt = DateTime.Now.AddDays(-5),
                ApprovedAt = null
            },
            new InternshipRegistration
            {
                Id = "REG003",
                StudentId = "SV001",
                StudentName = "Nguyễn Văn An",
                TopicId = "topic005",
                TopicTitle = "Xây dựng hệ thống E-commerce",
                CompanyId = "company001",
                CompanyName = "Công ty TNHH ABC",
                CoverLetterUrl = null,
                Status = "rejected",
                RegisteredAt = DateTime.Now.AddDays(-15),
                ApprovedAt = null,
                RejectionReason = "Sinh viên chưa đủ kinh nghiệm về ASP.NET Core"
            }
        };

        private static List<WeeklyReport> _weeklyReports = new List<WeeklyReport>
        {
            new WeeklyReport
            {
                Id = "WR001",
                StudentId = "SV001",
                WeekNumber = 1,
                Title = "Báo cáo tuần 1 - Tìm hiểu yêu cầu dự án",
                Content = "Tuần này em đã tìm hiểu yêu cầu dự án, phân tích nghiệp vụ và thiết kế database ban đầu.",
                Progress = 10,
                Status = "reviewed",
                LecturerComment = "Tốt, tiếp tục phát huy",
                CompanyComment = "Sinh viên nhiệt tình, chủ động",
                SubmittedAt = DateTime.Now.AddDays(-50),
                ReviewedAt = DateTime.Now.AddDays(-48),
                CreatedAt = DateTime.Now.AddDays(-51)
            },
            new WeeklyReport
            {
                Id = "WR002",
                StudentId = "SV001",
                WeekNumber = 2,
                Title = "Báo cáo tuần 2 - Thiết kế giao diện",
                Content = "Tuần này em đã thiết kế giao diện các màn hình chính và xây dựng prototype.",
                Progress = 25,
                Status = "reviewed",
                LecturerComment = "Giao diện đẹp, cần chú ý UX",
                CompanyComment = "Đạt yêu cầu",
                SubmittedAt = DateTime.Now.AddDays(-43),
                ReviewedAt = DateTime.Now.AddDays(-41),
                CreatedAt = DateTime.Now.AddDays(-44)
            },
            new WeeklyReport
            {
                Id = "WR003",
                StudentId = "SV001",
                WeekNumber = 3,
                Title = "Báo cáo tuần 3 - Xây dựng API Backend",
                Content = "Tuần này em đã xây dựng các API cho module quản lý sản phẩm và danh mục.",
                Progress = 40,
                Status = "submitted",
                SubmittedAt = DateTime.Now.AddDays(-36),
                CreatedAt = DateTime.Now.AddDays(-37)
            }
        };

        private static List<WorkLog> _workLogs = new List<WorkLog>
        {
            new WorkLog
            {
                Id = "WL001",
                StudentId = "SV001",
                Date = DateTime.Now.AddDays(-5),
                Title = "Họp với mentor",
                Content = "Họp với mentor để review code và nhận feedback về kiến trúc hệ thống.",
                HoursWorked = 2,
                Tags = "meeting,review",
                CreatedAt = DateTime.Now.AddDays(-5)
            },
            new WorkLog
            {
                Id = "WL002",
                StudentId = "SV001",
                Date = DateTime.Now.AddDays(-4),
                Title = "Coding API Products",
                Content = "Xây dựng CRUD API cho module Products, viết unit test.",
                HoursWorked = 6,
                Tags = "coding,api,testing",
                CreatedAt = DateTime.Now.AddDays(-4)
            },
            new WorkLog
            {
                Id = "WL003",
                StudentId = "SV001",
                Date = DateTime.Now.AddDays(-3),
                Title = "Tích hợp Frontend",
                Content = "Tích hợp API vào giao diện, xử lý validation và error handling.",
                HoursWorked = 5,
                Tags = "frontend,integration",
                CreatedAt = DateTime.Now.AddDays(-3)
            }
        };

        private static List<StudentGrade> _grades = new List<StudentGrade>
        {
            new StudentGrade
            {
                Id = "GR001",
                StudentId = "SV001",
                Category = "Quá trình",
                Score = 8.5,
                MaxScore = 10,
                Comment = "Sinh viên chăm chỉ, tích cực học hỏi",
                GradedBy = "lecturer",
                GraderName = "TS. Nguyễn Văn B",
                GradedAt = DateTime.Now.AddDays(-10)
            },
            new StudentGrade
            {
                Id = "GR002",
                StudentId = "SV001",
                Category = "Báo cáo",
                Score = 8.0,
                MaxScore = 10,
                Comment = "Báo cáo đầy đủ, trình bày tốt",
                GradedBy = "lecturer",
                GraderName = "TS. Nguyễn Văn B",
                GradedAt = DateTime.Now.AddDays(-5)
            },
            new StudentGrade
            {
                Id = "GR003",
                StudentId = "SV001",
                Category = "Đánh giá DN",
                Score = 9.0,
                MaxScore = 10,
                Comment = "Làm việc nghiêm túc, kỹ năng tốt",
                GradedBy = "company",
                GraderName = "Công ty ABC",
                GradedAt = DateTime.Now.AddDays(-3)
            }
        };

        private static InternshipProgress _progress = new InternshipProgress
        {
            Id = "PROG001",
            StudentId = "SV001",
            TotalWeeks = 12,
            CompletedWeeks = 3,
            ProgressPercentage = 40,
            StartDate = DateTime.Now.AddDays(-51),
            EndDate = DateTime.Now.AddDays(33),
            ReportDeadline = DateTime.Now.AddDays(40),
            DefenseDate = DateTime.Now.AddDays(50),
            DaysRemaining = 33,
            Status = "in_progress"
        };

        private static List<Milestone> _milestones = new List<Milestone>
        {
            new Milestone
            {
                Id = "MS001",
                Title = "Hoàn thành phân tích yêu cầu",
                Description = "Phân tích nghiệp vụ, thiết kế database",
                DueDate = DateTime.Now.AddDays(-45),
                IsCompleted = true,
                CompletedAt = DateTime.Now.AddDays(-46)
            },
            new Milestone
            {
                Id = "MS002",
                Title = "Hoàn thành thiết kế giao diện",
                Description = "Thiết kế UI/UX, prototype",
                DueDate = DateTime.Now.AddDays(-38),
                IsCompleted = true,
                CompletedAt = DateTime.Now.AddDays(-39)
            },
            new Milestone
            {
                Id = "MS003",
                Title = "Hoàn thành Backend API",
                Description = "Xây dựng các API cần thiết",
                DueDate = DateTime.Now.AddDays(7),
                IsCompleted = false
            },
            new Milestone
            {
                Id = "MS004",
                Title = "Hoàn thành tích hợp Frontend",
                Description = "Tích hợp API vào giao diện",
                DueDate = DateTime.Now.AddDays(21),
                IsCompleted = false
            },
            new Milestone
            {
                Id = "MS005",
                Title = "Hoàn thành testing",
                Description = "Unit test, integration test",
                DueDate = DateTime.Now.AddDays(28),
                IsCompleted = false
            }
        };

        // Profile Methods
        public static (bool Success, string Message, StudentProfile? Data) GetProfile()
        {
            return (true, "Lấy hồ sơ thành công", _currentStudent);
        }

        public static (bool Success, string Message) UpdateProfile(string? phone, string? description, string? avatarUrl, string? cvUrl)
        {
            _currentStudent.Phone = phone;
            _currentStudent.Description = description;
            _currentStudent.AvatarUrl = avatarUrl;
            _currentStudent.CvUrl = cvUrl;
            _currentStudent.UpdatedAt = DateTime.Now;
            return (true, "Cập nhật hồ sơ thành công");
        }

        // Registration Methods
        public static (bool Success, string Message, List<InternshipTopic> Data) GetAvailableTopics()
        {
            var topics = AdminMockData.GetTopics("approved");
            return (true, "Lấy danh sách đề tài thành công", topics);
        }

        public static (bool Success, string Message, InternshipRegistration? Data) RegisterInternship(int topicId, string coverLetter, string? coverLetterUrl)
        {
            var topic = AdminMockData.GetTopics().FirstOrDefault(t => t.Id == topicId.ToString());
            if (topic == null)
            {
                return (false, "Không tìm thấy đề tài", null);
            }

            var registration = new InternshipRegistration
            {
                Id = $"REG{_registrations.Count + 1:D3}",
                StudentId = _currentStudent.Id!,
                StudentName = _currentStudent.FullName,
                TopicId = topicId.ToString(),
                TopicTitle = topic.Title,
                CompanyId = topic.CompanyId,
                CompanyName = topic.CompanyName,
                CoverLetterUrl = coverLetterUrl,
                Status = "pending",
                RegisteredAt = DateTime.Now
            };

            _registrations.Add(registration);
            return (true, "Đăng ký thực tập thành công", registration);
        }

        public static (bool Success, string Message, List<InternshipRegistration> Data) GetMyRegistrations()
        {
            return (true, "Lấy danh sách đăng ký thành công", _registrations);
        }

        // Weekly Report Methods
        public static (bool Success, string Message, List<WeeklyReport> Data) GetWeeklyReports()
        {
            return (true, "Lấy danh sách báo cáo thành công", _weeklyReports);
        }

        public static (bool Success, string Message, WeeklyReport? Data) CreateWeeklyReport(int weekNumber, string title, string content, int progress)
        {
            var report = new WeeklyReport
            {
                Id = $"WR{_weeklyReports.Count + 1:D3}",
                StudentId = _currentStudent.Id!,
                WeekNumber = weekNumber,
                Title = title,
                Content = content,
                Progress = progress,
                Status = "draft",
                CreatedAt = DateTime.Now
            };

            _weeklyReports.Add(report);
            return (true, "Tạo báo cáo thành công", report);
        }

        public static (bool Success, string Message) SubmitWeeklyReport(string reportId)
        {
            var report = _weeklyReports.FirstOrDefault(r => r.Id == reportId);
            if (report == null)
            {
                return (false, "Không tìm thấy báo cáo");
            }

            report.Status = "submitted";
            report.SubmittedAt = DateTime.Now;
            return (true, "Nộp báo cáo thành công");
        }

        // Work Log Methods
        public static (bool Success, string Message, List<WorkLog> Data) GetWorkLogs()
        {
            return (true, "Lấy danh sách nhật ký thành công", _workLogs);
        }

        public static (bool Success, string Message, WorkLog? Data) CreateWorkLog(DateTime date, string title, string content, int hoursWorked, string? tags)
        {
            var workLog = new WorkLog
            {
                Id = $"WL{_workLogs.Count + 1:D3}",
                StudentId = _currentStudent.Id!,
                Date = date,
                Title = title,
                Content = content,
                HoursWorked = hoursWorked,
                Tags = tags,
                CreatedAt = DateTime.Now
            };

            _workLogs.Add(workLog);
            return (true, "Tạo nhật ký thành công", workLog);
        }

        // Grade Methods
        public static (bool Success, string Message, List<StudentGrade> Data) GetGrades()
        {
            return (true, "Lấy danh sách điểm thành công", _grades);
        }

        // Progress Methods
        public static (bool Success, string Message, InternshipProgress? Data) GetProgress()
        {
            return (true, "Lấy tiến độ thành công", _progress);
        }

        // Statistics Methods
        public static (bool Success, string Message, StudentStatistics? Data) GetStatistics()
        {
            var stats = new StudentStatistics
            {
                TotalReports = _progress.TotalWeeks,
                SubmittedReports = _weeklyReports.Count(r => r.Status == "submitted" || r.Status == "reviewed"),
                TotalWorkLogs = _workLogs.Count,
                TotalHoursWorked = _workLogs.Sum(w => w.HoursWorked),
                AverageScore = _grades.Any() ? _grades.Average(g => g.Score) : 0,
                DaysRemaining = _progress.DaysRemaining,
                CompletedMilestones = _milestones.Count(m => m.IsCompleted),
                TotalMilestones = _milestones.Count
            };

            return (true, "Lấy thống kê thành công", stats);
        }

        public static (bool Success, string Message, List<Milestone> Data) GetMilestones()
        {
            return (true, "Lấy danh sách milestone thành công", _milestones);
        }
    }
}


