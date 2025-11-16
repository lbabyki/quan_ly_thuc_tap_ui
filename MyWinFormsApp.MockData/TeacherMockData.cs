using System;
using System.Collections.Generic;
using System.Linq;
using MyWinFormsApp.Business.Models;

namespace MyWinFormsApp.MockData
{
    /// <summary>
    /// Mock data cho Teacher/Lecturer module (dành cho giảng viên đăng nhập)
    /// </summary>
    public static class TeacherMockData
    {
        private static LecturerProfile _currentLecturer;
        private static List<SupervisedStudent> _supervisedStudents = new List<SupervisedStudent>();
        private static List<StudentReport> _studentReports = new List<StudentReport>();
        private static List<StudentGrading> _studentGradings = new List<StudentGrading>();
        private static List<DefenseSchedule> _defenseSchedules = new List<DefenseSchedule>();

        static TeacherMockData()
        {
            InitializeData();
        }

        private static void InitializeData()
        {
            // Current Lecturer
            _currentLecturer = new LecturerProfile
            {
                Id = "lecturer001",
                LecturerCode = "GV001",
                FullName = "TS. Nguyễn Văn Giảng",
                Email = "giang.nv@lhu.edu.vn",
                Phone = "0901234567",
                Department = "Khoa Công nghệ Thông tin",
                Title = "TS.",
                Specialization = "Công nghệ phần mềm, AI/ML",
                MaxStudents = 10,
                CurrentStudents = 5,
                CreatedAt = DateTime.Now.AddYears(-3),
                UpdatedAt = DateTime.Now
            };

            // Supervised Students
            _supervisedStudents = new List<SupervisedStudent>
            {
                new SupervisedStudent
                {
                    Id = "student001",
                    StudentCode = "2021600001",
                    StudentName = "Nguyễn Văn An",
                    Email = "an.nv@student.lhu.edu.vn",
                    Phone = "0912345678",
                    TopicId = "topic001",
                    TopicTitle = "Phát triển ứng dụng Mobile với React Native",
                    CompanyName = "Công ty FPT Software",
                    Status = "in_progress",
                    Progress = 65,
                    StartDate = DateTime.Now.AddMonths(-2),
                    EndDate = null
                },
                new SupervisedStudent
                {
                    Id = "student002",
                    StudentCode = "2021600002",
                    StudentName = "Trần Thị Bình",
                    Email = "binh.tt@student.lhu.edu.vn",
                    Phone = "0923456789",
                    TopicId = "topic002",
                    TopicTitle = "Xây dựng hệ thống quản lý kho",
                    CompanyName = "Công ty TNHH ABC",
                    Status = "in_progress",
                    Progress = 80,
                    StartDate = DateTime.Now.AddMonths(-3),
                    EndDate = null
                },
                new SupervisedStudent
                {
                    Id = "student003",
                    StudentCode = "2021600003",
                    StudentName = "Lê Văn Cường",
                    Email = "cuong.lv@student.lhu.edu.vn",
                    Phone = "0934567890",
                    TopicId = "topic003",
                    TopicTitle = "Phát triển game 2D với Unity",
                    CompanyName = "Công ty VNG Corporation",
                    Status = "in_progress",
                    Progress = 45,
                    StartDate = DateTime.Now.AddMonths(-1),
                    EndDate = null
                },
                new SupervisedStudent
                {
                    Id = "student004",
                    StudentCode = "2020600001",
                    StudentName = "Phạm Thị Dung",
                    Email = "dung.pt@student.lhu.edu.vn",
                    Phone = "0945678901",
                    TopicId = "topic004",
                    TopicTitle = "Hệ thống quản lý bán hàng",
                    CompanyName = "Công ty TNHH ABC",
                    Status = "completed",
                    Progress = 100,
                    StartDate = DateTime.Now.AddMonths(-4),
                    EndDate = DateTime.Now.AddDays(-5)
                },
                new SupervisedStudent
                {
                    Id = "student005",
                    StudentCode = "2021600004",
                    StudentName = "Hoàng Văn Em",
                    Email = "em.hv@student.lhu.edu.vn",
                    Phone = "0956789012",
                    TopicId = "topic005",
                    TopicTitle = "Website thương mại điện tử",
                    CompanyName = "Công ty FPT Software",
                    Status = "in_progress",
                    Progress = 55,
                    StartDate = DateTime.Now.AddMonths(-2),
                    EndDate = null
                }
            };

            // Student Reports
            _studentReports = new List<StudentReport>
            {
                new StudentReport
                {
                    Id = "report001",
                    StudentId = "student001",
                    StudentName = "Nguyễn Văn An",
                    StudentCode = "2021600001",
                    WeekNumber = 1,
                    Title = "Báo cáo tuần 1: Tìm hiểu React Native",
                    Content = "Đã hoàn thành việc tìm hiểu cơ bản về React Native, cài đặt môi trường phát triển...",
                    Progress = 10,
                    Status = "reviewed",
                    LecturerComment = "Tốt, tiếp tục nghiên cứu sâu hơn về Navigation",
                    SubmittedAt = DateTime.Now.AddDays(-50),
                    ReviewedAt = DateTime.Now.AddDays(-49)
                },
                new StudentReport
                {
                    Id = "report002",
                    StudentId = "student001",
                    StudentName = "Nguyễn Văn An",
                    StudentCode = "2021600001",
                    WeekNumber = 2,
                    Title = "Báo cáo tuần 2: Xây dựng giao diện cơ bản",
                    Content = "Đã xây dựng được các màn hình cơ bản: Login, Home, Profile...",
                    Progress = 25,
                    Status = "submitted",
                    SubmittedAt = DateTime.Now.AddDays(-2)
                },
                new StudentReport
                {
                    Id = "report003",
                    StudentId = "student002",
                    StudentName = "Trần Thị Bình",
                    StudentCode = "2021600002",
                    WeekNumber = 1,
                    Title = "Báo cáo tuần 1: Phân tích yêu cầu hệ thống",
                    Content = "Đã hoàn thành phân tích yêu cầu, thiết kế database...",
                    Progress = 15,
                    Status = "reviewed",
                    LecturerComment = "Database design cần bổ sung thêm index",
                    SubmittedAt = DateTime.Now.AddDays(-60),
                    ReviewedAt = DateTime.Now.AddDays(-59)
                },
                new StudentReport
                {
                    Id = "report004",
                    StudentId = "student003",
                    StudentName = "Lê Văn Cường",
                    StudentCode = "2021600003",
                    WeekNumber = 1,
                    Title = "Báo cáo tuần 1: Tìm hiểu Unity Engine",
                    Content = "Đã cài đặt Unity, tìm hiểu cơ bản về GameObject, Component...",
                    Progress = 10,
                    Status = "submitted",
                    SubmittedAt = DateTime.Now.AddDays(-1)
                }
            };

            // Student Gradings
            _studentGradings = new List<StudentGrading>
            {
                new StudentGrading
                {
                    Id = "grade001",
                    StudentId = "student001",
                    StudentCode = "2021600001",
                    StudentName = "Nguyễn Văn An",
                    TopicTitle = "Phát triển ứng dụng Mobile với React Native",
                    ProcessScore = 8.5m,
                    ReportScore = null,
                    DefenseScore = null,
                    FinalScore = null,
                    Comment = "Quá trình làm việc tốt, chăm chỉ",
                    GradedAt = DateTime.Now.AddDays(-10)
                },
                new StudentGrading
                {
                    Id = "grade002",
                    StudentId = "student002",
                    StudentCode = "2021600002",
                    StudentName = "Trần Thị Bình",
                    TopicTitle = "Xây dựng hệ thống quản lý kho",
                    ProcessScore = 9.0m,
                    ReportScore = 8.5m,
                    DefenseScore = null,
                    FinalScore = null,
                    Comment = "Rất tốt, code sạch và có tài liệu đầy đủ",
                    GradedAt = DateTime.Now.AddDays(-5)
                },
                new StudentGrading
                {
                    Id = "grade003",
                    StudentId = "student004",
                    StudentCode = "2020600001",
                    StudentName = "Phạm Thị Dung",
                    TopicTitle = "Hệ thống quản lý bán hàng",
                    ProcessScore = 8.0m,
                    ReportScore = 8.5m,
                    DefenseScore = 9.0m,
                    FinalScore = 8.5m,
                    Comment = "Hoàn thành tốt, bảo vệ xuất sắc",
                    GradedAt = DateTime.Now.AddDays(-3)
                }
            };

            // Defense Schedules
            _defenseSchedules = new List<DefenseSchedule>
            {
                new DefenseSchedule
                {
                    Id = "defense001",
                    StudentId = "student002",
                    StudentCode = "2021600002",
                    StudentName = "Trần Thị Bình",
                    TopicTitle = "Xây dựng hệ thống quản lý kho",
                    DefenseDate = DateTime.Now.AddDays(7),
                    Location = "Phòng A101",
                    CouncilMembers = "TS. Nguyễn Văn A (Chủ tịch), ThS. Trần Thị B, ThS. Lê Văn C",
                    Status = "scheduled",
                    Notes = "Chuẩn bị slide và demo sản phẩm",
                    CreatedAt = DateTime.Now.AddDays(-3)
                },
                new DefenseSchedule
                {
                    Id = "defense002",
                    StudentId = "student004",
                    StudentCode = "2020600001",
                    StudentName = "Phạm Thị Dung",
                    TopicTitle = "Hệ thống quản lý bán hàng",
                    DefenseDate = DateTime.Now.AddDays(-3),
                    Location = "Phòng B202",
                    CouncilMembers = "PGS.TS. Hoàng Văn D (Chủ tịch), TS. Nguyễn Văn E, ThS. Phạm Thị F",
                    Status = "completed",
                    Notes = "Đã hoàn thành xuất sắc",
                    CreatedAt = DateTime.Now.AddDays(-10)
                }
            };
        }

        // Public methods
        public static (bool Success, string Message, LecturerProfile? Data) GetProfile()
        {
            return (true, "Lấy thông tin giảng viên thành công", _currentLecturer);
        }

        public static (bool Success, string Message, List<SupervisedStudent> Data) GetSupervisedStudents(string? status = null)
        {
            var students = _supervisedStudents.AsEnumerable();

            if (!string.IsNullOrEmpty(status))
            {
                students = students.Where(s => s.Status == status);
            }

            return (true, "Lấy danh sách sinh viên thành công", students.ToList());
        }

        public static (bool Success, string Message, List<StudentReport> Data) GetStudentReports(string? studentId = null, string? status = null)
        {
            var reports = _studentReports.AsEnumerable();

            if (!string.IsNullOrEmpty(studentId))
            {
                reports = reports.Where(r => r.StudentId == studentId);
            }

            if (!string.IsNullOrEmpty(status))
            {
                reports = reports.Where(r => r.Status == status);
            }

            return (true, "Lấy danh sách báo cáo thành công", reports.ToList());
        }

        public static (bool Success, string Message) ReviewReport(string reportId, string comment)
        {
            var report = _studentReports.FirstOrDefault(r => r.Id == reportId);
            if (report == null)
            {
                return (false, "Không tìm thấy báo cáo");
            }

            report.LecturerComment = comment;
            report.Status = "reviewed";
            report.ReviewedAt = DateTime.Now;

            return (true, "Phản hồi báo cáo thành công");
        }

        public static (bool Success, string Message, List<StudentGrading> Data) GetStudentGradings()
        {
            return (true, "Lấy danh sách điểm thành công", _studentGradings);
        }

        public static (bool Success, string Message) SubmitGrade(string studentId, decimal processScore, decimal reportScore, decimal defenseScore, string? comment)
        {
            var grading = _studentGradings.FirstOrDefault(g => g.StudentId == studentId);

            if (grading == null)
            {
                // Create new grading
                var student = _supervisedStudents.FirstOrDefault(s => s.Id == studentId);
                if (student == null)
                {
                    return (false, "Không tìm thấy sinh viên");
                }

                grading = new StudentGrading
                {
                    Id = $"grade{_studentGradings.Count + 1:D3}",
                    StudentId = studentId,
                    StudentCode = student.StudentCode,
                    StudentName = student.StudentName,
                    TopicTitle = student.TopicTitle
                };
                _studentGradings.Add(grading);
            }

            // Update scores
            grading.ProcessScore = processScore;
            grading.ReportScore = reportScore;
            grading.DefenseScore = defenseScore;
            grading.FinalScore = (processScore * 0.3m + reportScore * 0.3m + defenseScore * 0.4m);
            grading.Comment = comment;
            grading.GradedAt = DateTime.Now;

            return (true, "Lưu điểm thành công");
        }

        public static (bool Success, string Message, List<DefenseSchedule> Data) GetDefenseSchedules()
        {
            return (true, "Lấy danh sách lịch bảo vệ thành công", _defenseSchedules);
        }

        public static (bool Success, string Message, DefenseSchedule? Data) CreateDefenseSchedule(string studentId, DateTime defenseDate, string location, string? councilMembers, string? notes)
        {
            var student = _supervisedStudents.FirstOrDefault(s => s.Id == studentId);
            if (student == null)
            {
                return (false, "Không tìm thấy sinh viên", null);
            }

            // Check if already scheduled
            if (_defenseSchedules.Any(d => d.StudentId == studentId && d.Status == "scheduled"))
            {
                return (false, "Sinh viên đã có lịch bảo vệ", null);
            }

            var schedule = new DefenseSchedule
            {
                Id = $"defense{_defenseSchedules.Count + 1:D3}",
                StudentId = studentId,
                StudentCode = student.StudentCode,
                StudentName = student.StudentName,
                TopicTitle = student.TopicTitle,
                DefenseDate = defenseDate,
                Location = location,
                CouncilMembers = councilMembers,
                Status = "scheduled",
                Notes = notes,
                CreatedAt = DateTime.Now
            };

            _defenseSchedules.Add(schedule);
            return (true, "Tạo lịch bảo vệ thành công", schedule);
        }

        public static (bool Success, string Message, LecturerStatistics? Data) GetStatistics()
        {
            var stats = new LecturerStatistics
            {
                TotalStudents = _supervisedStudents.Count,
                CompletedStudents = _supervisedStudents.Count(s => s.Status == "completed"),
                InProgressStudents = _supervisedStudents.Count(s => s.Status == "in_progress"),
                PendingReports = _studentReports.Count(r => r.Status == "submitted"),
                ReviewedReports = _studentReports.Count(r => r.Status == "reviewed"),
                AverageScore = _studentGradings.Where(g => g.FinalScore.HasValue).Average(g => g.FinalScore ?? 0),
                ScheduledDefenses = _defenseSchedules.Count(d => d.Status == "scheduled"),
                StudentsByCompany = _supervisedStudents.GroupBy(s => s.CompanyName).ToDictionary(g => g.Key, g => g.Count()),
                StudentsByTopic = _supervisedStudents.GroupBy(s => s.TopicTitle).ToDictionary(g => g.Key, g => g.Count()),
                MonthlyProgressData = new List<MonthlyProgress>
                {
                    new MonthlyProgress { Month = "Tháng 1", CompletedReports = 5, PendingReports = 2, AverageProgress = 45 },
                    new MonthlyProgress { Month = "Tháng 2", CompletedReports = 8, PendingReports = 1, AverageProgress = 60 },
                    new MonthlyProgress { Month = "Tháng 3", CompletedReports = 6, PendingReports = 3, AverageProgress = 55 }
                }
            };

            return (true, "Lấy thống kê thành công", stats);
        }
    }
}

