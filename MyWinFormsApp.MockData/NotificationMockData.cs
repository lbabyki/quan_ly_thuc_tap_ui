using MyWinFormsApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyWinFormsApp.MockData
{
    public static class NotificationMockData
    {
        private static List<Notification> _notifications = new List<Notification>
        {
            new Notification
            {
                Id = "notif1",
                Title = "Thông báo mở đăng ký kỳ thực tập HK2 2024-2025",
                Content = "Kỳ thực tập HK2 2024-2025 đã mở đăng ký. Sinh viên vui lòng đăng ký đề tài trước ngày 05/01/2025.",
                Type = "info",
                TargetType = "student",
                SenderId = "admin1",
                SenderName = "Admin",
                CreatedAt = DateTime.Now.AddDays(-5),
                IsSent = true,
                SentAt = DateTime.Now.AddDays(-5),
                TotalRecipients = 150,
                SuccessCount = 148,
                FailureCount = 2
            },
            new Notification
            {
                Id = "notif2",
                Title = "Nhắc nhở nộp báo cáo thực tập",
                Content = "Hạn nộp báo cáo thực tập là 20/05/2025. Sinh viên chưa nộp vui lòng hoàn thành báo cáo.",
                Type = "warning",
                TargetType = "student",
                SenderId = "admin1",
                SenderName = "Admin",
                CreatedAt = DateTime.Now.AddDays(-2),
                IsSent = true,
                SentAt = DateTime.Now.AddDays(-2),
                TotalRecipients = 52,
                SuccessCount = 52,
                FailureCount = 0
            },
            new Notification
            {
                Id = "notif3",
                Title = "Thông báo lịch bảo vệ thực tập",
                Content = "Lịch bảo vệ thực tập sẽ diễn ra vào ngày 28/05/2025. Vui lòng chuẩn bị slide và báo cáo.",
                Type = "info",
                TargetType = "all",
                SenderId = "admin1",
                SenderName = "Admin",
                CreatedAt = DateTime.Now.AddDays(-1),
                IsSent = false,
                ScheduledAt = DateTime.Now.AddDays(1),
                TotalRecipients = 200,
                SuccessCount = 0,
                FailureCount = 0
            }
        };

        public static List<Notification> GetAllNotifications()
        {
            return _notifications.OrderByDescending(n => n.CreatedAt).ToList();
        }

        public static Notification? GetNotificationById(string id)
        {
            return _notifications.FirstOrDefault(n => n.Id == id);
        }

        public static List<Notification> GetNotificationsByType(string type)
        {
            return _notifications.Where(n => n.Type == type).OrderByDescending(n => n.CreatedAt).ToList();
        }

        public static List<Notification> GetSentNotifications()
        {
            return _notifications.Where(n => n.IsSent).OrderByDescending(n => n.SentAt).ToList();
        }

        public static List<Notification> GetPendingNotifications()
        {
            return _notifications.Where(n => !n.IsSent).OrderBy(n => n.ScheduledAt).ToList();
        }

        public static (bool Success, string Message, Notification? Notification) CreateNotification(Notification notification)
        {
            // Validate
            if (string.IsNullOrWhiteSpace(notification.Title))
                return (false, "Tiêu đề thông báo không được để trống", null);

            if (string.IsNullOrWhiteSpace(notification.Content))
                return (false, "Nội dung thông báo không được để trống", null);

            // Create
            notification.Id = Guid.NewGuid().ToString();
            notification.CreatedAt = DateTime.Now;
            notification.IsSent = false;

            _notifications.Add(notification);

            return (true, "Tạo thông báo thành công", notification);
        }

        public static (bool Success, string Message, Notification? Notification) SendNotification(string id)
        {
            var notification = _notifications.FirstOrDefault(n => n.Id == id);
            if (notification == null)
                return (false, "Không tìm thấy thông báo", null);

            if (notification.IsSent)
                return (false, "Thông báo đã được gửi", null);

            // Simulate sending
            notification.IsSent = true;
            notification.SentAt = DateTime.Now;
            notification.SuccessCount = notification.TotalRecipients;
            notification.FailureCount = 0;

            return (true, $"Gửi thông báo thành công đến {notification.TotalRecipients} người", notification);
        }

        public static (bool Success, string Message) DeleteNotification(string id)
        {
            var notification = _notifications.FirstOrDefault(n => n.Id == id);
            if (notification == null)
                return (false, "Không tìm thấy thông báo");

            if (notification.IsSent)
                return (false, "Không thể xóa thông báo đã gửi");

            _notifications.Remove(notification);
            return (true, "Xóa thông báo thành công");
        }
    }
}

