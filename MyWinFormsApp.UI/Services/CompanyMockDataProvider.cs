using System.Collections.Generic;
using MyWinFormsApp.Business.Interfaces;
using MyWinFormsApp.Business.Models;
using MyWinFormsApp.MockData;

namespace MyWinFormsApp.UI.Services
{
    /// <summary>
    /// Mock data provider wrapper cho Company module
    /// </summary>
    public class CompanyMockDataProvider : ICompanyDataProvider
    {
        public (bool Success, string Message, CompanyProfile? Data) GetProfile()
        {
            return CompanyMockData.GetProfile();
        }

        public (bool Success, string Message, List<StudentConfirmation> Data) GetStudentConfirmations(string? status = null)
        {
            return CompanyMockData.GetStudentConfirmations(status);
        }

        public (bool Success, string Message) ConfirmStudent(string studentId, string status, string? supervisor, string? notes)
        {
            return CompanyMockData.ConfirmStudent(studentId, status, supervisor, notes);
        }

        public (bool Success, string Message, List<StudentEvaluation> Data) GetStudentEvaluations(string? status = null)
        {
            return CompanyMockData.GetStudentEvaluations(status);
        }

        public (bool Success, string Message) SubmitEvaluation(string studentId, decimal attendanceScore, decimal attitudeScore, decimal skillScore, decimal resultScore, string? comment)
        {
            return CompanyMockData.SubmitEvaluation(studentId, attendanceScore, attitudeScore, skillScore, resultScore, comment);
        }

        public (bool Success, string Message, List<CompanyReport> Data) GetReports()
        {
            return CompanyMockData.GetReports();
        }

        public (bool Success, string Message) SubmitReport(string title, string content, string period, int totalStudents, int completedStudents, List<string> attachments)
        {
            return CompanyMockData.SubmitReport(title, content, period, totalStudents, completedStudents, attachments);
        }

        public (bool Success, string Message, List<InternshipTopic> Data) GetTopics()
        {
            return CompanyMockData.GetTopics();
        }

        public (bool Success, string Message) CreateTopic(string title, string description, string requirements, int maxStudents, string duration, string location, string supervisor)
        {
            return CompanyMockData.CreateTopic(title, description, requirements, maxStudents, duration, location, supervisor);
        }

        public (bool Success, string Message) UpdateTopic(string topicId, string title, string description, string requirements, int maxStudents, string duration, string location, string supervisor)
        {
            return CompanyMockData.UpdateTopic(topicId, title, description, requirements, maxStudents, duration, location, supervisor);
        }

        public (bool Success, string Message) DeleteTopic(string topicId)
        {
            return CompanyMockData.DeleteTopic(topicId);
        }

        public (bool Success, string Message, CompanyStatistics? Data) GetStatistics()
        {
            return CompanyMockData.GetStatistics();
        }
    }
}

