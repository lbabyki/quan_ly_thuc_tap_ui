using System;
using System.Collections.Generic;

namespace MyWinFormsApp.Business.Models
{
    /// <summary>
    /// Model cho thống kê hệ thống
    /// </summary>
    public class Statistics
    {
        public int TotalStudents { get; set; }
        public int TotalLecturers { get; set; }
        public int TotalCompanies { get; set; }
        public int TotalInternships { get; set; }
        public int ActiveInternships { get; set; }
        public int CompletedInternships { get; set; }
        public int PendingTopics { get; set; }
        public double AverageScore { get; set; }
        
        // Thống kê sinh viên theo công ty
        public List<CompanyStudentCount> StudentsByCompany { get; set; } = new List<CompanyStudentCount>();
        
        // Điểm trung bình theo ngành
        public List<MajorAverageScore> ScoresByMajor { get; set; } = new List<MajorAverageScore>();
        
        // Thống kê theo thời gian
        public List<MonthlyStatistic> MonthlyStats { get; set; } = new List<MonthlyStatistic>();
    }

    public class CompanyStudentCount
    {
        public string CompanyId { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public int StudentCount { get; set; }
    }

    public class MajorAverageScore
    {
        public string Major { get; set; } = string.Empty;
        public double AverageScore { get; set; }
        public int StudentCount { get; set; }
    }

    public class MonthlyStatistic
    {
        public int Month { get; set; }
        public int Year { get; set; }
        public int NewStudents { get; set; }
        public int CompletedInternships { get; set; }
    }
}

