using System;
using System.Collections.Generic;

namespace MyWinFormsApp.Business.Models
{
    /// <summary>
    /// Model đại diện cho Lecturer (Giảng viên)
    /// </summary>
    public class Lecturer
    {
        public string? Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public string? FullName { get; set; }
        public string Email { get; set; } = string.Empty;
        public string? Phone { get; set; }
        public string? Department { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = "lecturer";
        public List<string> AssignedStudents { get; set; } = new List<string>(); // ObjectId references
        public string? Specialization { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}

