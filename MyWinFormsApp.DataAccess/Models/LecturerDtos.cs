using System;
using System.Collections.Generic;

namespace MyWinFormsApp.DataAccess.Models
{
    /// <summary>
    /// DTO cho phản hồi báo cáo
    /// </summary>
    public class ReviewReportDto
    {
        public string ReportId { get; set; } = string.Empty;
        public string Comment { get; set; } = string.Empty;
        public string Status { get; set; } = "reviewed";
    }

    /// <summary>
    /// DTO cho nhập điểm
    /// </summary>
    public class SubmitGradeDto
    {
        public string StudentId { get; set; } = string.Empty;
        public decimal ProcessScore { get; set; }
        public decimal ReportScore { get; set; }
        public decimal DefenseScore { get; set; }
        public string? Comment { get; set; }
    }

    /// <summary>
    /// DTO cho tạo lịch bảo vệ
    /// </summary>
    public class CreateDefenseScheduleDto
    {
        public string StudentId { get; set; } = string.Empty;
        public DateTime DefenseDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public string? CouncilMembers { get; set; }
        public string? Notes { get; set; }
    }

    /// <summary>
    /// Response cho danh sách sinh viên
    /// </summary>
    public class SupervisedStudentsResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<SupervisedStudentDto> Students { get; set; } = new List<SupervisedStudentDto>();
    }

    public class SupervisedStudentDto
    {
        public string? Id { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string TopicId { get; set; } = string.Empty;
        public string TopicTitle { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public int Progress { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    /// <summary>
    /// Response cho danh sách báo cáo
    /// </summary>
    public class StudentReportsResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<StudentReportDto> Reports { get; set; } = new List<StudentReportDto>();
    }

    public class StudentReportDto
    {
        public string? Id { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public int WeekNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? AttachmentUrl { get; set; }
        public int Progress { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? LecturerComment { get; set; }
        public DateTime SubmittedAt { get; set; }
        public DateTime? ReviewedAt { get; set; }
    }

    /// <summary>
    /// Response cho danh sách điểm
    /// </summary>
    public class StudentGradingsResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<StudentGradingDto> Gradings { get; set; } = new List<StudentGradingDto>();
    }

    public class StudentGradingDto
    {
        public string? Id { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string TopicTitle { get; set; } = string.Empty;
        public decimal? ProcessScore { get; set; }
        public decimal? ReportScore { get; set; }
        public decimal? DefenseScore { get; set; }
        public decimal? FinalScore { get; set; }
        public string? Comment { get; set; }
        public DateTime? GradedAt { get; set; }
    }

    /// <summary>
    /// Response cho lịch bảo vệ
    /// </summary>
    public class DefenseSchedulesResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public List<DefenseScheduleDto> Schedules { get; set; } = new List<DefenseScheduleDto>();
    }

    public class DefenseScheduleDto
    {
        public string? Id { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string TopicTitle { get; set; } = string.Empty;
        public DateTime DefenseDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public string? CouncilMembers { get; set; }
        public string Status { get; set; } = string.Empty;
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Response cho thống kê
    /// </summary>
    public class LecturerStatisticsResponse
    {
        public bool Success { get; set; }
        public string? Message { get; set; }
        public LecturerStatisticsDto? Data { get; set; }
    }

    public class LecturerStatisticsDto
    {
        public int TotalStudents { get; set; }
        public int CompletedStudents { get; set; }
        public int InProgressStudents { get; set; }
        public int PendingReports { get; set; }
        public int ReviewedReports { get; set; }
        public decimal AverageScore { get; set; }
        public int ScheduledDefenses { get; set; }
    }
}

