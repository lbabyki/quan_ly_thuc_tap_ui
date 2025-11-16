using System;

namespace MyWinFormsApp.Business.Models
{
    /// <summary>
    /// Model đại diện cho Kỳ thực tập (Internship Period)
    /// </summary>
    public class InternshipPeriod
    {
        public string? Id { get; set; }
        
        /// <summary>
        /// Tên kỳ thực tập (VD: "Kỳ thực tập HK1 2024-2025")
        /// </summary>
        public string Name { get; set; } = string.Empty;
        
        /// <summary>
        /// Mô tả kỳ thực tập
        /// </summary>
        public string? Description { get; set; }
        
        /// <summary>
        /// Học kỳ (1, 2, 3)
        /// </summary>
        public int Semester { get; set; }
        
        /// <summary>
        /// Năm học (VD: "2024-2025")
        /// </summary>
        public string AcademicYear { get; set; } = string.Empty;
        
        /// <summary>
        /// Ngày bắt đầu kỳ thực tập
        /// </summary>
        public DateTime StartDate { get; set; }
        
        /// <summary>
        /// Ngày kết thúc kỳ thực tập
        /// </summary>
        public DateTime EndDate { get; set; }
        
        /// <summary>
        /// Hạn đăng ký đề tài
        /// </summary>
        public DateTime RegistrationDeadline { get; set; }
        
        /// <summary>
        /// Hạn nộp báo cáo
        /// </summary>
        public DateTime ReportDeadline { get; set; }
        
        /// <summary>
        /// Ngày bảo vệ
        /// </summary>
        public DateTime? DefenseDate { get; set; }
        
        /// <summary>
        /// Trạng thái: draft, open, in_progress, closed, completed
        /// </summary>
        public string Status { get; set; } = "draft";
        
        /// <summary>
        /// Số lượng sinh viên đăng ký
        /// </summary>
        public int RegisteredStudents { get; set; } = 0;
        
        /// <summary>
        /// Số lượng đề tài
        /// </summary>
        public int TotalTopics { get; set; } = 0;
        
        /// <summary>
        /// Ghi chú
        /// </summary>
        public string? Notes { get; set; }
        
        /// <summary>
        /// Người tạo
        /// </summary>
        public string? CreatedBy { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

