using MyWinFormsApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWinFormsApp.MockData
{
    public static class SystemLogMockData
    {
        private static List<SystemLog> _logs = new List<SystemLog>
        {
            new SystemLog
            {
                Id = "log1",
                UserId = "admin1",
                UserName = "Admin",
                UserEmail = "admin@lhu.edu.vn",
                Action = "Đăng nhập hệ thống",
                ActionType = "login",
                TargetType = "system",
                Details = "Đăng nhập thành công",
                IpAddress = "192.168.1.100",
                CreatedAt = DateTime.Now.AddMinutes(-30)
            },
            new SystemLog
            {
                Id = "log2",
                UserId = "admin1",
                UserName = "Admin",
                UserEmail = "admin@lhu.edu.vn",
                Action = "Tạo người dùng",
                ActionType = "create",
                TargetType = "student",
                TargetId = "sv001",
                Details = "Tạo tài khoản sinh viên mới: Nguyễn Văn A",
                IpAddress = "192.168.1.100",
                CreatedAt = DateTime.Now.AddMinutes(-25)
            },
            new SystemLog
            {
                Id = "log3",
                UserId = "admin1",
                UserName = "Admin",
                UserEmail = "admin@lhu.edu.vn",
                Action = "Duyệt đề tài",
                ActionType = "update",
                TargetType = "topic",
                TargetId = "topic1",
                Details = "Duyệt đề tài thực tập: Xây dựng hệ thống quản lý thư viện",
                IpAddress = "192.168.1.100",
                CreatedAt = DateTime.Now.AddMinutes(-20)
            },
            new SystemLog
            {
                Id = "log4",
                UserId = "admin1",
                UserName = "Admin",
                UserEmail = "admin@lhu.edu.vn",
                Action = "Xóa người dùng",
                ActionType = "delete",
                TargetType = "student",
                TargetId = "sv999",
                Details = "Xóa tài khoản sinh viên: Test User",
                IpAddress = "192.168.1.100",
                CreatedAt = DateTime.Now.AddMinutes(-15)
            },
            new SystemLog
            {
                Id = "log5",
                UserId = "admin1",
                UserName = "Admin",
                UserEmail = "admin@lhu.edu.vn",
                Action = "Mở kỳ thực tập",
                ActionType = "update",
                TargetType = "period",
                TargetId = "period3",
                Details = "Mở kỳ thực tập: Kỳ thực tập Hè 2025",
                IpAddress = "192.168.1.100",
                CreatedAt = DateTime.Now.AddMinutes(-10)
            },
            new SystemLog
            {
                Id = "log6",
                UserId = "unknown",
                UserName = "unknown@lhu.edu.vn",
                UserEmail = "unknown@lhu.edu.vn",
                Action = "Đăng nhập thất bại",
                ActionType = "login",
                TargetType = "system",
                Details = "Đăng nhập thất bại - Sai mật khẩu",
                IpAddress = "192.168.1.200",
                CreatedAt = DateTime.Now.AddMinutes(-5)
            }
        };

        public static List<SystemLog> GetAllLogs()
        {
            return _logs.OrderByDescending(l => l.CreatedAt).ToList();
        }

        public static List<SystemLog> GetLogsByActionType(string actionType)
        {
            return _logs.Where(l => l.ActionType == actionType).OrderByDescending(l => l.CreatedAt).ToList();
        }

        public static List<SystemLog> GetLogsByAction(string action)
        {
            return _logs.Where(l => l.Action.Contains(action)).OrderByDescending(l => l.CreatedAt).ToList();
        }

        public static List<SystemLog> GetLogsByUser(string userId)
        {
            return _logs.Where(l => l.UserId == userId).OrderByDescending(l => l.CreatedAt).ToList();
        }

        public static List<SystemLog> GetLogsByDateRange(DateTime startDate, DateTime endDate)
        {
            return _logs.Where(l => l.CreatedAt >= startDate && l.CreatedAt <= endDate)
                       .OrderByDescending(l => l.CreatedAt)
                       .ToList();
        }

        public static (bool Success, string Message, SystemLog? Log) AddLog(SystemLog log)
        {
            log.Id = Guid.NewGuid().ToString();
            log.CreatedAt = DateTime.Now;
            _logs.Add(log);
            return (true, "Thêm log thành công", log);
        }

        public static (bool Success, string Message) ClearOldLogs(int daysToKeep)
        {
            var cutoffDate = DateTime.Now.AddDays(-daysToKeep);
            var logsToRemove = _logs.Where(l => l.CreatedAt < cutoffDate).ToList();
            
            foreach (var log in logsToRemove)
            {
                _logs.Remove(log);
            }

            return (true, $"Đã xóa {logsToRemove.Count} log cũ");
        }
    }
}

