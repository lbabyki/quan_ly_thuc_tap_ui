using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MyWinFormsApp.DataAccess.Models
{
    // DTO cho Internship Period
    public class InternshipPeriodDto
    {
        [JsonProperty("_id")]
        public string? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("semester")]
        public int Semester { get; set; }

        [JsonProperty("academicYear")]
        public string? AcademicYear { get; set; }

        [JsonProperty("startDate")]
        public DateTime? StartDate { get; set; }

        [JsonProperty("endDate")]
        public DateTime? EndDate { get; set; }

        [JsonProperty("registrationDeadline")]
        public DateTime? RegistrationDeadline { get; set; }

        [JsonProperty("reportDeadline")]
        public DateTime? ReportDeadline { get; set; }

        [JsonProperty("defenseDate")]
        public DateTime? DefenseDate { get; set; }

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("registeredStudents")]
        public int RegisteredStudents { get; set; }

        [JsonProperty("totalTopics")]
        public int TotalTopics { get; set; }

        [JsonProperty("notes")]
        public string? Notes { get; set; }

        [JsonProperty("createdBy")]
        public string? CreatedBy { get; set; }

        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }

        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }

    // DTO cho System Log
    public class SystemLogDto
    {
        [JsonProperty("_id")]
        public string? Id { get; set; }
        
        [JsonProperty("userId")]
        public string? UserId { get; set; }
        
        [JsonProperty("userName")]
        public string? UserName { get; set; }
        
        [JsonProperty("userEmail")]
        public string? UserEmail { get; set; }
        
        [JsonProperty("action")]
        public string? Action { get; set; }
        
        [JsonProperty("actionType")]
        public string? ActionType { get; set; }
        
        [JsonProperty("targetType")]
        public string? TargetType { get; set; }
        
        [JsonProperty("targetId")]
        public string? TargetId { get; set; }
        
        [JsonProperty("details")]
        public string? Details { get; set; }
        
        [JsonProperty("ipAddress")]
        public string? IpAddress { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }
    }

    // DTO cho Internship Topic
    public class InternshipTopicDto
    {
        [JsonProperty("_id")]
        public string? Id { get; set; }
        
        [JsonProperty("title")]
        public string? Title { get; set; }
        
        [JsonProperty("description")]
        public string? Description { get; set; }
        
        [JsonProperty("company")]
        public string? CompanyId { get; set; }
        
        [JsonProperty("companyName")]
        public string? CompanyName { get; set; }
        
        [JsonProperty("lecturer")]
        public string? LecturerId { get; set; }
        
        [JsonProperty("lecturerName")]
        public string? LecturerName { get; set; }
        
        [JsonProperty("status")]
        public string? Status { get; set; }
        
        [JsonProperty("maxStudents")]
        public int MaxStudents { get; set; }
        
        [JsonProperty("currentStudents")]
        public int CurrentStudents { get; set; }
        
        [JsonProperty("requirements")]
        public string? Requirements { get; set; }
        
        [JsonProperty("skills")]
        public string? Skills { get; set; }
        
        [JsonProperty("startDate")]
        public DateTime? StartDate { get; set; }
        
        [JsonProperty("endDate")]
        public DateTime? EndDate { get; set; }
        
        [JsonProperty("deadline")]
        public DateTime? Deadline { get; set; }
        
        [JsonProperty("rejectionReason")]
        public string? RejectionReason { get; set; }
        
        [JsonProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }
        
        [JsonProperty("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }

    // DTO cho Statistics
    public class StatisticsDto
    {
        [JsonProperty("totalStudents")]
        public int TotalStudents { get; set; }
        
        [JsonProperty("totalLecturers")]
        public int TotalLecturers { get; set; }
        
        [JsonProperty("totalCompanies")]
        public int TotalCompanies { get; set; }
        
        [JsonProperty("totalInternships")]
        public int TotalInternships { get; set; }
        
        [JsonProperty("activeInternships")]
        public int ActiveInternships { get; set; }
        
        [JsonProperty("completedInternships")]
        public int CompletedInternships { get; set; }
        
        [JsonProperty("pendingTopics")]
        public int PendingTopics { get; set; }
        
        [JsonProperty("averageScore")]
        public double AverageScore { get; set; }
        
        [JsonProperty("studentsByCompany")]
        public List<CompanyStudentCountDto>? StudentsByCompany { get; set; }
        
        [JsonProperty("scoresByMajor")]
        public List<MajorAverageScoreDto>? ScoresByMajor { get; set; }
        
        [JsonProperty("monthlyStats")]
        public List<MonthlyStatisticDto>? MonthlyStats { get; set; }
    }

    public class CompanyStudentCountDto
    {
        [JsonProperty("companyId")]
        public string? CompanyId { get; set; }
        
        [JsonProperty("companyName")]
        public string? CompanyName { get; set; }
        
        [JsonProperty("studentCount")]
        public int StudentCount { get; set; }
    }

    public class MajorAverageScoreDto
    {
        [JsonProperty("major")]
        public string? Major { get; set; }
        
        [JsonProperty("averageScore")]
        public double AverageScore { get; set; }
        
        [JsonProperty("studentCount")]
        public int StudentCount { get; set; }
    }

    public class MonthlyStatisticDto
    {
        [JsonProperty("month")]
        public int Month { get; set; }
        
        [JsonProperty("year")]
        public int Year { get; set; }
        
        [JsonProperty("newStudents")]
        public int NewStudents { get; set; }
        
        [JsonProperty("completedInternships")]
        public int CompletedInternships { get; set; }
    }
}

