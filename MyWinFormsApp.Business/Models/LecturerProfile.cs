using System;
using System.Collections.Generic;

namespace MyWinFormsApp.Business.Models
{
    /// <summary>
    /// Model cho hồ sơ giảng viên
    /// </summary>
    public class LecturerProfile
    {
        public string? Id { get; set; }
        public string LecturerCode { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Department { get; set; }
        public string? Title { get; set; } // TS., ThS., GV.
        public string? Specialization { get; set; }
        public int MaxStudents { get; set; } = 10;
        public int CurrentStudents { get; set; } = 0;
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }

    /// <summary>
    /// Model cho sinh viên được hướng dẫn
    /// </summary>
    public class SupervisedStudent
    {
        public string? Id { get; set; }
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string TopicId { get; set; } = string.Empty;
        public string TopicTitle { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Status { get; set; } = "in_progress"; // in_progress, completed, failed
        public int Progress { get; set; } = 0; // 0-100
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }

    /// <summary>
    /// Model cho báo cáo sinh viên
    /// </summary>
    public class StudentReport
    {
        public string? Id { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public int WeekNumber { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? AttachmentUrl { get; set; }
        public int Progress { get; set; } // 0-100
        public string Status { get; set; } = "submitted"; // submitted, reviewed
        public string? LecturerComment { get; set; }
        public DateTime SubmittedAt { get; set; }
        public DateTime? ReviewedAt { get; set; }
    }

    /// <summary>
    /// Model cho điểm đánh giá
    /// </summary>
    public class StudentGrading
    {
        public string? Id { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string TopicTitle { get; set; } = string.Empty;
        public decimal? ProcessScore { get; set; } // Điểm quá trình (0-10)
        public decimal? ReportScore { get; set; } // Điểm báo cáo (0-10)
        public decimal? DefenseScore { get; set; } // Điểm bảo vệ (0-10)
        public decimal? FinalScore { get; set; } // Điểm tổng kết
        public string? Comment { get; set; }
        public DateTime? GradedAt { get; set; }
    }

    /// <summary>
    /// Model cho lịch bảo vệ
    /// </summary>
    public class DefenseSchedule
    {
        public string? Id { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string TopicTitle { get; set; } = string.Empty;
        public DateTime DefenseDate { get; set; }
        public string Location { get; set; } = string.Empty;
        public string? CouncilMembers { get; set; } // Danh sách hội đồng
        public string Status { get; set; } = "scheduled"; // scheduled, completed, cancelled
        public string? Notes { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    /// <summary>
    /// Model cho thống kê giảng viên
    /// </summary>
    public class LecturerStatistics
    {
        public int TotalStudents { get; set; }
        public int CompletedStudents { get; set; }
        public int InProgressStudents { get; set; }
        public int PendingReports { get; set; }
        public int ReviewedReports { get; set; }
        public decimal AverageScore { get; set; }
        public int ScheduledDefenses { get; set; }
        public Dictionary<string, int> StudentsByCompany { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, int> StudentsByTopic { get; set; } = new Dictionary<string, int>();
        public List<MonthlyProgress> MonthlyProgressData { get; set; } = new List<MonthlyProgress>();
    }

    /// <summary>
    /// Model cho tiến độ theo tháng
    /// </summary>
    public class MonthlyProgress
    {
        public string Month { get; set; } = string.Empty;
        public int CompletedReports { get; set; }
        public int PendingReports { get; set; }
        public decimal AverageProgress { get; set; }
    }
}

