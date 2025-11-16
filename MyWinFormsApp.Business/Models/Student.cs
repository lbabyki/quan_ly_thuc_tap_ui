using System;
using System.Collections.Generic;

namespace MyWinFormsApp.Business.Models
{
    /// <summary>
    /// Model đại diện cho Student (Sinh viên)
    /// </summary>
    public class Student
    {
        public string? Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string? StudentCode { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Department { get; set; }
        public string? InternshipCompany { get; set; } // ObjectId reference
        public string? CvUrl { get; set; }
        public string Status { get; set; } = "pending"; // pending, approved, rejected
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "student";
        public List<string> Skills { get; set; } = new List<string>();
        public int? Year { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

