using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyWinFormsApp.Business.Interfaces;
using MyWinFormsApp.Business.Models;
using MyWinFormsApp.DataAccess.Models;
using MyWinFormsApp.DataAccess.Repositories;

namespace MyWinFormsApp.Business.Services
{
    /// <summary>
    /// Service layer cho Lecturer module
    /// </summary>
    public class LecturerService
    {
        private readonly LecturerRepository _repository;
        private readonly ILecturerDataProvider? _mockDataProvider;
        private readonly bool _useMockData;

        public LecturerService(string? token = null, bool useMockData = false, ILecturerDataProvider? mockDataProvider = null)
        {
            _repository = new LecturerRepository(token);
            _useMockData = useMockData;
            _mockDataProvider = mockDataProvider;
        }

        /// <summary>
        /// Lấy thông tin giảng viên
        /// </summary>
        public async Task<(bool Success, string Message, LecturerProfile? Data)> GetProfileAsync()
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetProfile());
            }

            // API call - placeholder
            return await Task.FromResult((false, "API chưa được implement", (LecturerProfile?)null));
        }

        /// <summary>
        /// Lấy danh sách sinh viên hướng dẫn
        /// </summary>
        public async Task<(bool Success, string Message, List<SupervisedStudent> Data)> GetSupervisedStudentsAsync(string? status = null)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetSupervisedStudents(status));
            }

            try
            {
                var response = await _repository.GetSupervisedStudentsAsync(status);
                if (response.Success)
                {
                    var students = response.Students.Select(MapToSupervisedStudent).ToList();
                    return (true, response.Message ?? "Success", students);
                }
                return (false, response.Message ?? "Failed", new List<SupervisedStudent>());
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", new List<SupervisedStudent>());
            }
        }

        /// <summary>
        /// Lấy danh sách báo cáo sinh viên
        /// </summary>
        public async Task<(bool Success, string Message, List<StudentReport> Data)> GetStudentReportsAsync(string? studentId = null, string? status = null)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetStudentReports(studentId, status));
            }

            try
            {
                var response = await _repository.GetStudentReportsAsync(studentId, status);
                if (response.Success)
                {
                    var reports = response.Reports.Select(MapToStudentReport).ToList();
                    return (true, response.Message ?? "Success", reports);
                }
                return (false, response.Message ?? "Failed", new List<StudentReport>());
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", new List<StudentReport>());
            }
        }

        /// <summary>
        /// Phản hồi báo cáo
        /// </summary>
        public async Task<(bool Success, string Message)> ReviewReportAsync(string reportId, string comment)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.ReviewReport(reportId, comment));
            }

            try
            {
                var dto = new ReviewReportDto
                {
                    ReportId = reportId,
                    Comment = comment,
                    Status = "reviewed"
                };

                var response = await _repository.ReviewReportAsync(dto);
                return (response.Success, response.Message ?? (response.Success ? "Success" : "Failed"));
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách điểm
        /// </summary>
        public async Task<(bool Success, string Message, List<StudentGrading> Data)> GetStudentGradingsAsync()
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetStudentGradings());
            }

            try
            {
                var response = await _repository.GetStudentGradingsAsync();
                if (response.Success)
                {
                    var gradings = response.Gradings.Select(MapToStudentGrading).ToList();
                    return (true, response.Message ?? "Success", gradings);
                }
                return (false, response.Message ?? "Failed", new List<StudentGrading>());
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", new List<StudentGrading>());
            }
        }

        /// <summary>
        /// Nhập điểm
        /// </summary>
        public async Task<(bool Success, string Message)> SubmitGradeAsync(string studentId, decimal processScore, decimal reportScore, decimal defenseScore, string? comment)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.SubmitGrade(studentId, processScore, reportScore, defenseScore, comment));
            }

            try
            {
                var dto = new SubmitGradeDto
                {
                    StudentId = studentId,
                    ProcessScore = processScore,
                    ReportScore = reportScore,
                    DefenseScore = defenseScore,
                    Comment = comment
                };

                var response = await _repository.SubmitGradeAsync(dto);
                return (response.Success, response.Message ?? (response.Success ? "Success" : "Failed"));
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}");
            }
        }

        /// <summary>
        /// Lấy danh sách lịch bảo vệ
        /// </summary>
        public async Task<(bool Success, string Message, List<DefenseSchedule> Data)> GetDefenseSchedulesAsync()
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.GetDefenseSchedules());
            }

            try
            {
                var response = await _repository.GetDefenseSchedulesAsync();
                if (response.Success)
                {
                    var schedules = response.Schedules.Select(MapToDefenseSchedule).ToList();
                    return (true, response.Message ?? "Success", schedules);
                }
                return (false, response.Message ?? "Failed", new List<DefenseSchedule>());
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", new List<DefenseSchedule>());
            }
        }

        /// <summary>
        /// Tạo lịch bảo vệ
        /// </summary>
        public async Task<(bool Success, string Message, DefenseSchedule? Data)> CreateDefenseScheduleAsync(string studentId, DateTime defenseDate, string location, string? councilMembers, string? notes)
        {
            if (_useMockData && _mockDataProvider != null)
            {
                return await Task.FromResult(_mockDataProvider.CreateDefenseSchedule(studentId, defenseDate, location, councilMembers, notes));
            }

            try
            {
                var dto = new CreateDefenseScheduleDto
                {
                    StudentId = studentId,
                    DefenseDate = defenseDate,
                    Location = location,
                    CouncilMembers = councilMembers,
                    Notes = notes
                };

                var response = await _repository.CreateDefenseScheduleAsync(dto);
                return (response.Success, response.Message ?? (response.Success ? "Success" : "Failed"), null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        /// <summary>
        /// Lấy thống kê
        /// </summary>
        public async Task<(bool Success, string Message, LecturerStatistics? Data)> GetStatisticsAsync()
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
                    var stats = MapToLecturerStatistics(response.Data);
                    return (true, response.Message ?? "Success", stats);
                }
                return (false, response.Message ?? "Failed", null);
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi: {ex.Message}", null);
            }
        }

        // Mapping methods
        private SupervisedStudent MapToSupervisedStudent(SupervisedStudentDto dto)
        {
            return new SupervisedStudent
            {
                Id = dto.Id,
                StudentCode = dto.StudentCode,
                StudentName = dto.StudentName,
                Email = dto.Email,
                Phone = dto.Phone,
                TopicId = dto.TopicId,
                TopicTitle = dto.TopicTitle,
                CompanyName = dto.CompanyName,
                Status = dto.Status,
                Progress = dto.Progress,
                StartDate = dto.StartDate,
                EndDate = dto.EndDate
            };
        }

        private StudentReport MapToStudentReport(StudentReportDto dto)
        {
            return new StudentReport
            {
                Id = dto.Id,
                StudentId = dto.StudentId,
                StudentName = dto.StudentName,
                StudentCode = dto.StudentCode,
                WeekNumber = dto.WeekNumber,
                Title = dto.Title,
                Content = dto.Content,
                AttachmentUrl = dto.AttachmentUrl,
                Progress = dto.Progress,
                Status = dto.Status,
                LecturerComment = dto.LecturerComment,
                SubmittedAt = dto.SubmittedAt,
                ReviewedAt = dto.ReviewedAt
            };
        }

        private StudentGrading MapToStudentGrading(StudentGradingDto dto)
        {
            return new StudentGrading
            {
                Id = dto.Id,
                StudentId = dto.StudentId,
                StudentCode = dto.StudentCode,
                StudentName = dto.StudentName,
                TopicTitle = dto.TopicTitle,
                ProcessScore = dto.ProcessScore,
                ReportScore = dto.ReportScore,
                DefenseScore = dto.DefenseScore,
                FinalScore = dto.FinalScore,
                Comment = dto.Comment,
                GradedAt = dto.GradedAt
            };
        }

        private DefenseSchedule MapToDefenseSchedule(DefenseScheduleDto dto)
        {
            return new DefenseSchedule
            {
                Id = dto.Id,
                StudentId = dto.StudentId,
                StudentCode = dto.StudentCode,
                StudentName = dto.StudentName,
                TopicTitle = dto.TopicTitle,
                DefenseDate = dto.DefenseDate,
                Location = dto.Location,
                CouncilMembers = dto.CouncilMembers,
                Status = dto.Status,
                Notes = dto.Notes,
                CreatedAt = dto.CreatedAt
            };
        }

        private LecturerStatistics MapToLecturerStatistics(LecturerStatisticsDto dto)
        {
            return new LecturerStatistics
            {
                TotalStudents = dto.TotalStudents,
                CompletedStudents = dto.CompletedStudents,
                InProgressStudents = dto.InProgressStudents,
                PendingReports = dto.PendingReports,
                ReviewedReports = dto.ReviewedReports,
                AverageScore = dto.AverageScore,
                ScheduledDefenses = dto.ScheduledDefenses
            };
        }
    }
}

