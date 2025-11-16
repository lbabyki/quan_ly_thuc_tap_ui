using System;
using System.Collections.Generic;
using System.Linq;
using MyWinFormsApp.Business.Models;

namespace MyWinFormsApp.MockData
{
    /// <summary>
    /// Mock data cho Company module (dành cho Doanh nghiệp sử dụng)
    /// </summary>
    public static class CompanyMockData
    {
        private static CompanyProfile _currentCompany = new CompanyProfile
        {
            Id = "comp001",
            CompanyName = "FPT Software",
            TaxCode = "0123456789",
            Address = "Lô 29B-31B-33B Đường Tân Thuận, KCX Tân Thuận, Q.7, TP.HCM",
            Phone = "028-54-161-666",
            Email = "contact@fpt-software.com",
            Website = "https://fptsoftware.com",
            ContactPerson = "Nguyễn Văn A",
            ContactPhone = "0901234567",
            ContactEmail = "nguyenvana@fpt-software.com",
            Industry = "Công nghệ thông tin",
            TotalInterns = 15,
            ActiveInterns = 8,
            CompletedInterns = 7,
            RegisteredAt = DateTime.Now.AddMonths(-6)
        };

        private static List<StudentConfirmation> _studentConfirmations = new List<StudentConfirmation>
        {
            new StudentConfirmation
            {
                Id = "conf001",
                StudentId = "std001",
                StudentCode = "2051120001",
                StudentName = "Trần Văn B",
                Email = "tranvanb@student.lhu.edu.vn",
                Phone = "0912345678",
                TopicTitle = "Phát triển ứng dụng quản lý nhân sự",
                Supervisor = "",
                Status = "pending",
                RequestedAt = DateTime.Now.AddDays(-3),
                Notes = null
            },
            new StudentConfirmation
            {
                Id = "conf002",
                StudentId = "std002",
                StudentCode = "2051120002",
                StudentName = "Lê Thị C",
                Email = "lethic@student.lhu.edu.vn",
                Phone = "0923456789",
                TopicTitle = "Xây dựng hệ thống CRM",
                Supervisor = "",
                Status = "pending",
                RequestedAt = DateTime.Now.AddDays(-2),
                Notes = null
            },
            new StudentConfirmation
            {
                Id = "conf003",
                StudentId = "std003",
                StudentCode = "2051120003",
                StudentName = "Phạm Văn D",
                Email = "phamvand@student.lhu.edu.vn",
                Phone = "0934567890",
                TopicTitle = "Phát triển ứng dụng Mobile",
                Supervisor = "Trần Minh E",
                Status = "confirmed",
                RequestedAt = DateTime.Now.AddDays(-10),
                ConfirmedAt = DateTime.Now.AddDays(-8),
                Notes = "Đã xác nhận, bắt đầu từ 01/12/2024"
            },
            new StudentConfirmation
            {
                Id = "conf004",
                StudentId = "std004",
                StudentCode = "2051120004",
                StudentName = "Hoàng Thị F",
                Email = "hoangthif@student.lhu.edu.vn",
                Phone = "0945678901",
                TopicTitle = "Xây dựng website thương mại điện tử",
                Supervisor = "Nguyễn Văn G",
                Status = "confirmed",
                RequestedAt = DateTime.Now.AddDays(-15),
                ConfirmedAt = DateTime.Now.AddDays(-12),
                Notes = "Đã xác nhận"
            }
        };

        private static List<StudentEvaluation> _studentEvaluations = new List<StudentEvaluation>
        {
            new StudentEvaluation
            {
                Id = "eval001",
                StudentId = "std003",
                StudentCode = "2051120003",
                StudentName = "Phạm Văn D",
                TopicTitle = "Phát triển ứng dụng Mobile",
                AttendanceScore = null,
                AttitudeScore = null,
                SkillScore = null,
                ResultScore = null,
                TotalScore = null,
                Comment = null,
                Status = "draft",
                EvaluatedAt = null
            },
            new StudentEvaluation
            {
                Id = "eval002",
                StudentId = "std004",
                StudentCode = "2051120004",
                StudentName = "Hoàng Thị F",
                TopicTitle = "Xây dựng website thương mại điện tử",
                AttendanceScore = 9.0m,
                AttitudeScore = 8.5m,
                SkillScore = 8.0m,
                ResultScore = 9.0m,
                TotalScore = 8.625m,
                Comment = "Sinh viên chăm chỉ, có tinh thần học hỏi tốt",
                Status = "submitted",
                EvaluatedAt = DateTime.Now.AddDays(-5)
            },
            new StudentEvaluation
            {
                Id = "eval003",
                StudentId = "std005",
                StudentCode = "2051120005",
                StudentName = "Võ Văn H",
                TopicTitle = "Phát triển hệ thống ERP",
                AttendanceScore = 8.0m,
                AttitudeScore = 9.0m,
                SkillScore = 7.5m,
                ResultScore = 8.5m,
                TotalScore = 8.25m,
                Comment = "Sinh viên có thái độ tốt, cần cải thiện kỹ năng",
                Status = "submitted",
                EvaluatedAt = DateTime.Now.AddDays(-3)
            }
        };

        private static List<CompanyReport> _companyReports = new List<CompanyReport>
        {
            new CompanyReport
            {
                Id = "rep001",
                CompanyId = "comp001",
                Title = "Báo cáo tổng kết kỳ thực tập HK1 2024-2025",
                Content = "Trong kỳ thực tập này, công ty đã tiếp nhận 8 sinh viên từ trường Đại học Lạc Hồng...\n\nKết quả:\n- Hoàn thành tốt: 5 sinh viên\n- Đang thực tập: 3 sinh viên\n\nNhận xét chung: Sinh viên có tinh thần học hỏi tốt, cần cải thiện kỹ năng làm việc nhóm.",
                Period = "HK1 2024-2025",
                TotalStudents = 8,
                CompletedStudents = 5,
                Attachments = new List<string> { "report_hk1_2024.pdf", "images.zip" },
                Status = "draft",
                CreatedAt = DateTime.Now.AddDays(-2),
                SubmittedAt = null
            },
            new CompanyReport
            {
                Id = "rep002",
                CompanyId = "comp001",
                Title = "Báo cáo tổng kết kỳ thực tập HK2 2023-2024",
                Content = "Báo cáo tổng kết kỳ thực tập HK2 2023-2024...",
                Period = "HK2 2023-2024",
                TotalStudents = 10,
                CompletedStudents = 10,
                Attachments = new List<string> { "report_hk2_2023.pdf" },
                Status = "submitted",
                CreatedAt = DateTime.Now.AddMonths(-6),
                SubmittedAt = DateTime.Now.AddMonths(-5)
            }
        };

        private static List<InternshipTopic> _internshipTopics = new List<InternshipTopic>
        {
            new InternshipTopic
            {
                Id = "topic001",
                CompanyId = "comp001",
                Title = "Phát triển ứng dụng quản lý nhân sự",
                Description = "Xây dựng hệ thống quản lý nhân sự sử dụng .NET Core và React",
                Requirements = "Có kiến thức về C#, .NET Core, React, SQL Server",
                MaxStudents = 2,
                CurrentStudents = 1,
                Duration = "3 tháng",
                Location = "FPT Software - Q.7, TP.HCM",
                Supervisor = "Nguyễn Văn A",
                Status = "active",
                CreatedAt = DateTime.Now.AddMonths(-2),
                UpdatedAt = DateTime.Now.AddDays(-5)
            },
            new InternshipTopic
            {
                Id = "topic002",
                CompanyId = "comp001",
                Title = "Xây dựng hệ thống CRM",
                Description = "Phát triển hệ thống quản lý quan hệ khách hàng",
                Requirements = "Có kiến thức về Java, Spring Boot, MySQL",
                MaxStudents = 2,
                CurrentStudents = 1,
                Duration = "3 tháng",
                Location = "FPT Software - Q.7, TP.HCM",
                Supervisor = "Trần Thị B",
                Status = "active",
                CreatedAt = DateTime.Now.AddMonths(-2),
                UpdatedAt = null
            },
            new InternshipTopic
            {
                Id = "topic003",
                CompanyId = "comp001",
                Title = "Phát triển ứng dụng Mobile",
                Description = "Xây dựng ứng dụng Mobile sử dụng React Native",
                Requirements = "Có kiến thức về JavaScript, React Native, Firebase",
                MaxStudents = 2,
                CurrentStudents = 2,
                Duration = "3 tháng",
                Location = "FPT Software - Q.7, TP.HCM",
                Supervisor = "Trần Minh E",
                Status = "full",
                CreatedAt = DateTime.Now.AddMonths(-3),
                UpdatedAt = DateTime.Now.AddDays(-10)
            },
            new InternshipTopic
            {
                Id = "topic004",
                CompanyId = "comp001",
                Title = "Xây dựng website thương mại điện tử",
                Description = "Phát triển website bán hàng online",
                Requirements = "Có kiến thức về PHP, Laravel, MySQL, Vue.js",
                MaxStudents = 1,
                CurrentStudents = 1,
                Duration = "3 tháng",
                Location = "FPT Software - Q.7, TP.HCM",
                Supervisor = "Nguyễn Văn G",
                Status = "full",
                CreatedAt = DateTime.Now.AddMonths(-3),
                UpdatedAt = DateTime.Now.AddDays(-15)
            }
        };

        // Public methods
        public static (bool Success, string Message, CompanyProfile? Data) GetProfile()
        {
            return (true, "Success", _currentCompany);
        }

        public static (bool Success, string Message, List<StudentConfirmation> Data) GetStudentConfirmations(string? status = null)
        {
            var result = _studentConfirmations.AsEnumerable();

            if (!string.IsNullOrEmpty(status) && status != "all")
            {
                result = result.Where(c => c.Status == status);
            }

            return (true, "Success", result.ToList());
        }

        public static (bool Success, string Message) ConfirmStudent(string studentId, string status, string? supervisor, string? notes)
        {
            var confirmation = _studentConfirmations.FirstOrDefault(c => c.StudentId == studentId);

            if (confirmation == null)
            {
                return (false, "Không tìm thấy sinh viên");
            }

            if (confirmation.Status != "pending")
            {
                return (false, "Sinh viên đã được xác nhận trước đó");
            }

            confirmation.Status = status;
            confirmation.Supervisor = supervisor ?? "";
            confirmation.Notes = notes;
            confirmation.ConfirmedAt = DateTime.Now;

            return (true, $"Đã {(status == "confirmed" ? "xác nhận" : "từ chối")} sinh viên thành công");
        }

        public static (bool Success, string Message, List<StudentEvaluation> Data) GetStudentEvaluations(string? status = null)
        {
            var result = _studentEvaluations.AsEnumerable();

            if (!string.IsNullOrEmpty(status) && status != "all")
            {
                result = result.Where(e => e.Status == status);
            }

            return (true, "Success", result.ToList());
        }

        public static (bool Success, string Message) SubmitEvaluation(string studentId, decimal attendanceScore, decimal attitudeScore, decimal skillScore, decimal resultScore, string? comment)
        {
            var evaluation = _studentEvaluations.FirstOrDefault(e => e.StudentId == studentId);

            if (evaluation == null)
            {
                // Tìm sinh viên đã confirmed
                var student = _studentConfirmations.FirstOrDefault(c => c.StudentId == studentId && c.Status == "confirmed");
                if (student == null)
                {
                    return (false, "Không tìm thấy sinh viên hoặc sinh viên chưa được xác nhận");
                }

                // Tạo evaluation mới
                evaluation = new StudentEvaluation
                {
                    Id = $"eval{_studentEvaluations.Count + 1:D3}",
                    StudentId = studentId,
                    StudentCode = student.StudentCode,
                    StudentName = student.StudentName,
                    TopicTitle = student.TopicTitle
                };
                _studentEvaluations.Add(evaluation);
            }

            // Validate scores
            if (attendanceScore < 0 || attendanceScore > 10 ||
                attitudeScore < 0 || attitudeScore > 10 ||
                skillScore < 0 || skillScore > 10 ||
                resultScore < 0 || resultScore > 10)
            {
                return (false, "Điểm phải nằm trong khoảng 0-10");
            }

            evaluation.AttendanceScore = attendanceScore;
            evaluation.AttitudeScore = attitudeScore;
            evaluation.SkillScore = skillScore;
            evaluation.ResultScore = resultScore;
            evaluation.TotalScore = (attendanceScore + attitudeScore + skillScore + resultScore) / 4;
            evaluation.Comment = comment;
            evaluation.Status = "submitted";
            evaluation.EvaluatedAt = DateTime.Now;

            return (true, "Gửi đánh giá thành công");
        }

        public static (bool Success, string Message, List<CompanyReport> Data) GetReports()
        {
            return (true, "Success", _companyReports.ToList());
        }

        public static (bool Success, string Message) SubmitReport(string title, string content, string period, int totalStudents, int completedStudents, List<string> attachments)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return (false, "Tiêu đề không được để trống");
            }

            if (string.IsNullOrWhiteSpace(content))
            {
                return (false, "Nội dung không được để trống");
            }

            var report = new CompanyReport
            {
                Id = $"rep{_companyReports.Count + 1:D3}",
                CompanyId = _currentCompany.Id!,
                Title = title,
                Content = content,
                Period = period,
                TotalStudents = totalStudents,
                CompletedStudents = completedStudents,
                Attachments = attachments,
                Status = "submitted",
                CreatedAt = DateTime.Now,
                SubmittedAt = DateTime.Now
            };

            _companyReports.Add(report);
            return (true, "Gửi báo cáo thành công");
        }

        public static (bool Success, string Message, List<InternshipTopic> Data) GetTopics()
        {
            return (true, "Success", _internshipTopics.ToList());
        }

        public static (bool Success, string Message) CreateTopic(string title, string description, string requirements, int maxStudents, string duration, string location, string supervisor)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                return (false, "Tiêu đề không được để trống");
            }

            var topic = new InternshipTopic
            {
                Id = $"topic{_internshipTopics.Count + 1:D3}",
                CompanyId = _currentCompany.Id!,
                Title = title,
                Description = description,
                Requirements = requirements,
                MaxStudents = maxStudents,
                CurrentStudents = 0,
                Duration = duration,
                Location = location,
                Supervisor = supervisor,
                Status = "active",
                CreatedAt = DateTime.Now,
                UpdatedAt = null
            };

            _internshipTopics.Add(topic);
            return (true, "Tạo đề tài thành công");
        }

        public static (bool Success, string Message) UpdateTopic(string topicId, string title, string description, string requirements, int maxStudents, string duration, string location, string supervisor)
        {
            var topic = _internshipTopics.FirstOrDefault(t => t.Id == topicId);

            if (topic == null)
            {
                return (false, "Không tìm thấy đề tài");
            }

            if (string.IsNullOrWhiteSpace(title))
            {
                return (false, "Tiêu đề không được để trống");
            }

            topic.Title = title;
            topic.Description = description;
            topic.Requirements = requirements;
            topic.MaxStudents = maxStudents;
            topic.Duration = duration;
            topic.Location = location;
            topic.Supervisor = supervisor;
            topic.UpdatedAt = DateTime.Now;

            // Update status based on current students
            if (topic.CurrentStudents >= topic.MaxStudents)
            {
                topic.Status = "full";
            }
            else
            {
                topic.Status = "active";
            }

            return (true, "Cập nhật đề tài thành công");
        }

        public static (bool Success, string Message) DeleteTopic(string topicId)
        {
            var topic = _internshipTopics.FirstOrDefault(t => t.Id == topicId);

            if (topic == null)
            {
                return (false, "Không tìm thấy đề tài");
            }

            if (topic.CurrentStudents > 0)
            {
                return (false, "Không thể xóa đề tài đang có sinh viên thực tập");
            }

            _internshipTopics.Remove(topic);
            return (true, "Xóa đề tài thành công");
        }

        public static (bool Success, string Message, CompanyStatistics? Data) GetStatistics()
        {
            var stats = new CompanyStatistics
            {
                TotalTopics = _internshipTopics.Count,
                ActiveTopics = _internshipTopics.Count(t => t.Status == "active"),
                TotalStudents = _currentCompany.TotalInterns,
                PendingConfirmations = _studentConfirmations.Count(c => c.Status == "pending"),
                CompletedEvaluations = _studentEvaluations.Count(e => e.Status == "submitted"),
                AverageScore = _studentEvaluations.Where(e => e.TotalScore.HasValue).Any()
                    ? _studentEvaluations.Where(e => e.TotalScore.HasValue).Average(e => e.TotalScore!.Value)
                    : 0,
                StudentsByTopic = _internshipTopics.ToDictionary(t => t.Title, t => t.CurrentStudents),
                AverageScoresByMonth = new Dictionary<string, decimal>
                {
                    { "T10/2024", 8.5m },
                    { "T11/2024", 8.3m },
                    { "T12/2024", 8.7m }
                }
            };

            return (true, "Success", stats);
        }

        #region Admin Module Support

        // Danh sách companies cho Admin module (quản lý user)
        private static List<Company> _adminCompanies = new List<Company>
        {
            new Company
            {
                Id = "comp001",
                CompanyName = "FPT Software",
                ContactEmail = "contact@fpt.com.vn",
                ContactPhone = "0283-9309000",
                Address = "Lô L29B-31B-33B, Đường Tân Thuận, KCX Tân Thuận, P.Tân Thuận Đông, Q.7, TP.HCM",
                ContactPerson = "Nguyễn Văn A",
                Status = "active",
                CreatedAt = DateTime.Now.AddMonths(-6)
            },
            new Company
            {
                Id = "comp002",
                CompanyName = "Viettel Software",
                ContactEmail = "contact@viettel.com.vn",
                ContactPhone = "0243-9749999",
                Address = "Tầng 10, Tòa nhà Viettel, 285 Cách Mạng Tháng 8, P.12, Q.10, TP.HCM",
                ContactPerson = "Trần Thị B",
                Status = "active",
                CreatedAt = DateTime.Now.AddMonths(-4)
            },
            new Company
            {
                Id = "comp003",
                CompanyName = "TMA Solutions",
                ContactEmail = "contact@tma.com.vn",
                ContactPhone = "0283-9971990",
                Address = "Tầng 6, Tòa nhà E-Town 2, 364 Cộng Hòa, P.13, Q.Tân Bình, TP.HCM",
                ContactPerson = "Lê Văn C",
                Status = "inactive",
                CreatedAt = DateTime.Now.AddMonths(-2)
            }
        };

        public static List<Company> GetAllCompanies()
        {
            return _adminCompanies.ToList();
        }

        public static (bool Success, string Message, Company? Company) CreateCompany(Company company)
        {
            _adminCompanies.Add(company);
            return (true, "Tạo doanh nghiệp thành công", company);
        }

        public static (bool Success, string Message, Company? Company) UpdateCompany(string id, Company updatedCompany)
        {
            var company = _adminCompanies.FirstOrDefault(c => c.Id == id);
            if (company == null)
            {
                return (false, "Không tìm thấy doanh nghiệp", null);
            }

            // Remove old and add updated
            _adminCompanies.Remove(company);
            _adminCompanies.Add(updatedCompany);

            return (true, "Cập nhật doanh nghiệp thành công", updatedCompany);
        }

        public static (bool Success, string Message) DeleteCompany(string id)
        {
            var company = _adminCompanies.FirstOrDefault(c => c.Id == id);
            if (company == null)
            {
                return (false, "Không tìm thấy doanh nghiệp");
            }

            _adminCompanies.Remove(company);
            return (true, "Xóa doanh nghiệp thành công");
        }

        public static (bool Success, string Message) ResetPassword(string companyId)
        {
            var company = _adminCompanies.FirstOrDefault(c => c.Id == companyId);
            if (company == null)
            {
                return (false, "Không tìm thấy doanh nghiệp");
            }

            return (true, "Đặt lại mật khẩu thành công. Mật khẩu mới: 123456");
        }

        #endregion
    }
}

