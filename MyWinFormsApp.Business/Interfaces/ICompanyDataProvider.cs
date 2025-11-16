using System.Collections.Generic;
using MyWinFormsApp.Business.Models;

namespace MyWinFormsApp.Business.Interfaces
{
    /// <summary>
    /// Interface cho Company Data Provider (Mock hoặc API)
    /// </summary>
    public interface ICompanyDataProvider
    {
        // Company Profile
        (bool Success, string Message, CompanyProfile? Data) GetProfile();

        // Student Confirmations
        (bool Success, string Message, List<StudentConfirmation> Data) GetStudentConfirmations(string? status = null);
        (bool Success, string Message) ConfirmStudent(string studentId, string status, string? supervisor, string? notes);

        // Student Evaluations
        (bool Success, string Message, List<StudentEvaluation> Data) GetStudentEvaluations(string? status = null);
        (bool Success, string Message) SubmitEvaluation(string studentId, decimal attendanceScore, decimal attitudeScore, decimal skillScore, decimal resultScore, string? comment);

        // Company Reports
        (bool Success, string Message, List<CompanyReport> Data) GetReports();
        (bool Success, string Message) SubmitReport(string title, string content, string period, int totalStudents, int completedStudents, List<string> attachments);

        // Internship Topics
        (bool Success, string Message, List<InternshipTopic> Data) GetTopics();
        (bool Success, string Message) CreateTopic(string title, string description, string requirements, int maxStudents, string duration, string location, string supervisor);
        (bool Success, string Message) UpdateTopic(string topicId, string title, string description, string requirements, int maxStudents, string duration, string location, string supervisor);
        (bool Success, string Message) DeleteTopic(string topicId);

        // Statistics
        (bool Success, string Message, CompanyStatistics? Data) GetStatistics();
    }
}

