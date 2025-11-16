using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWinFormsApp.Business.Models;
using MyWinFormsApp.Business.Interfaces;
using MyWinFormsApp.DataAccess.Repositories;
using MyWinFormsApp.DataAccess.Models;

namespace MyWinFormsApp.Business.Services
{
    /// <summary>
    /// Service for Student module
    /// Supports both Mock Data (via IStudentDataProvider) and API calls
    /// </summary>
    public class StudentService
    {
        private readonly StudentRepository _repository;
        private readonly IStudentDataProvider? _mockDataProvider;
        private readonly bool _useMockData;

        public StudentService(string? token = null, bool useMockData = false, IStudentDataProvider? mockDataProvider = null)
        {
            _repository = new StudentRepository(token);
            _useMockData = useMockData;
            _mockDataProvider = mockDataProvider;
        }

        #region Profile

        public async Task<(bool Success, string Message, StudentProfile? Data)> GetProfileAsync()
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetProfile());
            }

            try
            {
                var response = await _repository.GetProfileAsync();
                if (response.Success && response.Data != null)
                {
                    var profile = MapToStudentProfile(response.Data);
                    return (true, response.Message ?? "Success", profile);
                }
                return (false, response.Message ?? "Failed", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> UpdateProfileAsync(
            string phone, string description, string? avatarUrl, string? cvUrl)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.UpdateProfile(phone, description, avatarUrl, cvUrl));
            }

            try
            {
                var dto = new UpdateStudentProfileDto
                {
                    Phone = phone,
                    Description = description,
                    AvatarUrl = avatarUrl,
                    CvUrl = cvUrl
                };

                var response = await _repository.UpdateProfileAsync(dto);
                return (response.Success, response.Message ?? "Success");
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        #endregion

        #region Registration

        public async Task<(bool Success, string Message, List<InternshipTopic> Data)> GetAvailableTopicsAsync()
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetAvailableTopics());
            }

            try
            {
                var response = await _repository.GetAvailableTopicsAsync();
                if (response.Success && response.Data != null)
                {
                    var topics = response.Data.Topics.Select(MapToInternshipTopic).ToList();
                    return (true, response.Message ?? "Success", topics);
                }
                return (false, response.Message ?? "Failed", new List<InternshipTopic>());
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", new List<InternshipTopic>());
            }
        }

        public async Task<(bool Success, string Message, InternshipRegistration? Data)> RegisterInternshipAsync(
            int topicId, string coverLetter, string? coverLetterUrl)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.RegisterInternship(topicId, coverLetter, coverLetterUrl));
            }

            try
            {
                var dto = new CreateInternshipRegistrationDto
                {
                    TopicId = topicId.ToString(),
                    CompanyId = "", // Will be filled by backend
                    CoverLetterUrl = coverLetterUrl
                };

                var response = await _repository.RegisterInternshipAsync(dto);
                if (response.Success && response.Data != null)
                {
                    var registration = MapToInternshipRegistration(response.Data);
                    return (true, response.Message ?? "Success", registration);
                }
                return (false, response.Message ?? "Failed", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, List<InternshipRegistration> Data)> GetMyRegistrationsAsync()
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetMyRegistrations());
            }

            // API not implemented yet, return empty list
            return await Task.FromResult((true, "API chưa được implement", new List<InternshipRegistration>()));
        }

        #endregion

        #region Weekly Reports

        public async Task<(bool Success, string Message, List<WeeklyReport> Data)> GetWeeklyReportsAsync()
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetWeeklyReports());
            }

            try
            {
                var response = await _repository.GetWeeklyReportsAsync();
                if (response.Success && response.Data != null)
                {
                    var reports = response.Data.Select(MapToWeeklyReport).ToList();
                    return (true, response.Message ?? "Success", reports);
                }
                return (false, response.Message ?? "Failed", new List<WeeklyReport>());
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", new List<WeeklyReport>());
            }
        }

        public async Task<(bool Success, string Message, WeeklyReport? Data)> CreateWeeklyReportAsync(
            int weekNumber, string title, string content, int progress)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.CreateWeeklyReport(weekNumber, title, content, progress));
            }

            try
            {
                var dto = new CreateWeeklyReportDto
                {
                    WeekNumber = weekNumber,
                    Title = title,
                    Content = content,
                    Progress = progress
                };

                var response = await _repository.CreateWeeklyReportAsync(dto);
                if (response.Success && response.Data != null)
                {
                    var report = MapToWeeklyReport(response.Data);
                    return (true, response.Message ?? "Success", report);
                }
                return (false, response.Message ?? "Failed", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message)> SubmitWeeklyReportAsync(int reportId)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.SubmitWeeklyReport(reportId));
            }

            // API not implemented yet
            return await Task.FromResult((true, "API chưa được implement"));
        }

        #endregion

        #region Work Logs

        public async Task<(bool Success, string Message, List<WorkLog> Data)> GetWorkLogsAsync()
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetWorkLogs());
            }

            // API not implemented yet
            return await Task.FromResult((true, "API chưa được implement", new List<WorkLog>()));
        }

        public async Task<(bool Success, string Message, WorkLog? Data)> CreateWorkLogAsync(
            DateTime date, string title, string content, decimal hoursWorked, string? tags)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.CreateWorkLog(date, title, content, hoursWorked, tags));
            }

            // API not implemented yet
            return await Task.FromResult((true, "API chưa được implement", (WorkLog?)null));
        }

        #endregion

        #region Grades & Progress

        public async Task<(bool Success, string Message, List<StudentGrade> Data)> GetGradesAsync()
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetGrades());
            }

            try
            {
                var response = await _repository.GetGradesAsync();
                if (response.Success && response.Data != null)
                {
                    var grades = response.Data.Grades.Select(MapToStudentGrade).ToList();
                    return (true, response.Message ?? "Success", grades);
                }
                return (false, response.Message ?? "Failed", new List<StudentGrade>());
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", new List<StudentGrade>());
            }
        }

        public async Task<(bool Success, string Message, InternshipProgress? Data)> GetProgressAsync()
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetProgress());
            }

            try
            {
                var response = await _repository.GetProgressAsync();
                if (response.Success && response.Data != null)
                {
                    var progress = MapToInternshipProgress(response.Data);
                    return (true, response.Message ?? "Success", progress);
                }
                return (false, response.Message ?? "Failed", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        #endregion

        #region Statistics

        public async Task<(bool Success, string Message, StudentStatistics? Data)> GetStatisticsAsync()
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetStatistics());
            }

            try
            {
                var response = await _repository.GetStatisticsAsync();
                if (response.Success && response.Data != null)
                {
                    var stats = MapToStudentStatistics(response.Data);
                    return (true, response.Message ?? "Success", stats);
                }
                return (false, response.Message ?? "Failed", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        public async Task<(bool Success, string Message, List<Milestone> Data)> GetMilestonesAsync()
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetMilestones());
            }

            try
            {
                var response = await _repository.GetStatisticsAsync();
                if (response.Success && response.Data != null)
                {
                    var milestones = response.Data.Milestones.Select(MapToMilestone).ToList();
                    return (true, response.Message ?? "Success", milestones);
                }
                return (false, response.Message ?? "Failed", new List<Milestone>());
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", new List<Milestone>());
            }
        }

        #endregion

        #region Mapping Methods

        private StudentProfile MapToStudentProfile(dynamic data)
        {
            return new StudentProfile
            {
                Id = data.Id,
                StudentCode = data.StudentCode,
                FullName = data.FullName,
                Email = data.Email,
                Phone = data.Phone,
                Department = data.Department,
                Year = data.Year,
                AvatarUrl = data.AvatarUrl,
                CvUrl = data.CvUrl,
                Description = data.Description,
                Status = data.Status
            };
        }

        private InternshipTopic MapToInternshipTopic(TopicDto dto)
        {
            return new InternshipTopic
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                CompanyId = dto.CompanyId,
                CompanyName = dto.CompanyName,
                MaxStudents = dto.MaxStudents,
                CurrentStudents = 0, // Not available in DTO
                Requirements = dto.Requirements,
                Status = dto.Status,
                CreatedAt = DateTime.Now
            };
        }

        private InternshipRegistration MapToInternshipRegistration(dynamic data)
        {
            return new InternshipRegistration
            {
                Id = data.Id,
                StudentId = data.StudentId,
                StudentName = data.StudentName ?? "",
                TopicId = data.TopicId,
                TopicTitle = data.TopicTitle,
                CompanyId = data.CompanyId ?? "",
                CompanyName = data.CompanyName,
                CoverLetterUrl = data.CoverLetterUrl,
                Status = data.Status,
                RejectionReason = data.RejectionReason,
                RegisteredAt = data.RegisteredAt,
                ApprovedAt = data.ApprovedAt
            };
        }

        private WeeklyReport MapToWeeklyReport(dynamic data)
        {
            return new WeeklyReport
            {
                Id = data.Id,
                StudentId = data.StudentId ?? "",
                WeekNumber = data.WeekNumber,
                Title = data.Title,
                Content = data.Content,
                AttachmentUrl = data.AttachmentUrl,
                Progress = data.Progress,
                Status = data.Status,
                LecturerComment = data.LecturerComment,
                CompanyComment = data.CompanyComment,
                SubmittedAt = data.SubmittedAt,
                ReviewedAt = data.ReviewedAt,
                CreatedAt = data.CreatedAt
            };
        }

        private WorkLog MapToWorkLog(dynamic data)
        {
            return new WorkLog
            {
                Id = data.Id,
                StudentId = data.StudentId ?? "",
                Date = data.Date,
                Title = data.Title,
                Content = data.Content,
                HoursWorked = (int)data.HoursWorked,
                Tags = data.Tags,
                CreatedAt = data.CreatedAt
            };
        }

        private StudentGrade MapToStudentGrade(GradeDto dto)
        {
            return new StudentGrade
            {
                Id = dto.Id,
                Category = dto.Category,
                Score = dto.Score,
                MaxScore = dto.MaxScore,
                GraderName = dto.GraderName,
                Comment = dto.Comment,
                GradedAt = dto.GradedAt
            };
        }

        private InternshipProgress MapToInternshipProgress(ProgressResponse response)
        {
            return new InternshipProgress
            {
                TotalWeeks = response.TotalWeeks,
                CompletedWeeks = response.CompletedWeeks,
                ProgressPercentage = response.ProgressPercentage,
                DaysRemaining = response.DaysRemaining,
                ReportDeadline = response.ReportDeadline,
                DefenseDate = response.DefenseDate
            };
        }

        private StudentStatistics MapToStudentStatistics(StatisticsResponse response)
        {
            return new StudentStatistics
            {
                TotalReports = response.TotalReports,
                SubmittedReports = response.SubmittedReports,
                TotalWorkLogs = response.TotalWorkLogs,
                TotalHoursWorked = response.TotalHoursWorked,
                DaysRemaining = response.DaysRemaining,
                CompletedMilestones = response.CompletedMilestones,
                TotalMilestones = response.TotalMilestones
            };
        }

        private Milestone MapToMilestone(MilestoneDto dto)
        {
            return new Milestone
            {
                Id = dto.Id,
                Title = dto.Title,
                Description = dto.Description,
                DueDate = dto.DueDate,
                IsCompleted = dto.IsCompleted,
                CompletedAt = dto.CompletedAt
            };
        }

        #endregion
    }
}



