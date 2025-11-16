using System;

namespace MyWinFormsApp.Business.Models
{
    /// <summary>
    /// Model mở rộng cho quản lý người dùng (kết hợp User + Student/Lecturer/Company)
    /// </summary>
    public class UserManagement
    {
        // User info
        public string? UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        
        // Student specific
        public string? StudentCode { get; set; }
        public string? Major { get; set; }
        public string? Class { get; set; }
        public double? GPA { get; set; }
        
        // Lecturer specific
        public string? Department { get; set; }
        public string? Title { get; set; } // Giảng viên, Tiến sĩ, Phó giáo sư, etc.
        
        // Company specific
        public string? CompanyName { get; set; }
        public string? TaxCode { get; set; }
        public string? Address { get; set; }
        public string? Website { get; set; }
        
        // Additional info
        public int? InternshipCount { get; set; }
        public int? StudentCount { get; set; }
    }
}

