using System;
using System.Collections.Generic;

namespace MyWinFormsApp.Business.Models
{
    /// <summary>
    /// Model cho thông tin doanh nghiệp
    /// </summary>
    public class CompanyProfile
    {
        public string? Id { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string TaxCode { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Website { get; set; }
        public string ContactPerson { get; set; } = string.Empty;
        public string ContactPhone { get; set; } = string.Empty;
        public string ContactEmail { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty; // Lĩnh vực
        public int TotalInterns { get; set; }
        public int ActiveInterns { get; set; }
        public int CompletedInterns { get; set; }
        public DateTime RegisteredAt { get; set; }
    }

    /// <summary>
    /// Model cho xác nhận sinh viên
    /// </summary>
    public class StudentConfirmation
    {
        public string? Id { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string TopicTitle { get; set; } = string.Empty;
        public string Supervisor { get; set; } = string.Empty; // Người hướng dẫn DN
        public string Status { get; set; } = "pending"; // pending, confirmed, rejected
        public DateTime RequestedAt { get; set; }
        public DateTime? ConfirmedAt { get; set; }
        public string? Notes { get; set; }
    }

    /// <summary>
    /// Model cho đánh giá sinh viên
    /// </summary>
    public class StudentEvaluation
    {
        public string? Id { get; set; }
        public string StudentId { get; set; } = string.Empty;
        public string StudentCode { get; set; } = string.Empty;
        public string StudentName { get; set; } = string.Empty;
        public string TopicTitle { get; set; } = string.Empty;
        
        // Điểm đánh giá (0-10)
        public decimal? AttendanceScore { get; set; } // Điểm chuyên cần
        public decimal? AttitudeScore { get; set; } // Điểm thái độ
        public decimal? SkillScore { get; set; } // Điểm kỹ năng
        public decimal? ResultScore { get; set; } // Điểm kết quả
        public decimal? TotalScore { get; set; } // Điểm tổng
        
        public string? Comment { get; set; }
        public string Status { get; set; } = "draft"; // draft, submitted
        public DateTime? EvaluatedAt { get; set; }
    }

    /// <summary>
    /// Model cho báo cáo tổng kết
    /// </summary>
    public class CompanyReport
    {
        public string? Id { get; set; }
        public string CompanyId { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string Period { get; set; } = string.Empty; // Kỳ thực tập
        public int TotalStudents { get; set; }
        public int CompletedStudents { get; set; }
        public List<string> Attachments { get; set; } = new List<string>();
        public string Status { get; set; } = "draft"; // draft, submitted
        public DateTime CreatedAt { get; set; }
        public DateTime? SubmittedAt { get; set; }
    }

    /// <summary>
    /// Model cho thống kê doanh nghiệp
    /// </summary>
    public class CompanyStatistics
    {
        public int TotalTopics { get; set; }
        public int ActiveTopics { get; set; }
        public int TotalStudents { get; set; }
        public int PendingConfirmations { get; set; }
        public int CompletedEvaluations { get; set; }
        public decimal AverageScore { get; set; }
        public Dictionary<string, int> StudentsByTopic { get; set; } = new Dictionary<string, int>();
        public Dictionary<string, decimal> AverageScoresByMonth { get; set; } = new Dictionary<string, decimal>();
    }
}

