using OfficeOpenXml;
using OfficeOpenXml.Style;
using MyWinFormsApp.Business.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;

namespace MyWinFormsApp.UI.Services
{
    /// <summary>
    /// Service để xuất dữ liệu ra file Excel
    /// </summary>
    public static class ExcelExportService
    {
        static ExcelExportService()
        {
            // Set EPPlus license context
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        #region Students Export

        public static void ExportStudents(List<Student> students, string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Danh sách Sinh viên");

                // Header
                worksheet.Cells["A1"].Value = "DANH SÁCH SINH VIÊN";
                worksheet.Cells["A1:H1"].Merge = true;
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Column headers
                worksheet.Cells["A3"].Value = "STT";
                worksheet.Cells["B3"].Value = "Mã SV";
                worksheet.Cells["C3"].Value = "Họ tên";
                worksheet.Cells["D3"].Value = "Email";
                worksheet.Cells["E3"].Value = "Số điện thoại";
                worksheet.Cells["F3"].Value = "Khoa";
                worksheet.Cells["G3"].Value = "Năm học";
                worksheet.Cells["H3"].Value = "Trạng thái";

                // Style header
                using (var range = worksheet.Cells["A3:H3"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 84, 166)); // LHU Blue
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // Data
                int row = 4;
                int stt = 1;
                foreach (var student in students)
                {
                    worksheet.Cells[row, 1].Value = stt++;
                    worksheet.Cells[row, 2].Value = student.StudentCode;
                    worksheet.Cells[row, 3].Value = student.FullName;
                    worksheet.Cells[row, 4].Value = student.Email;
                    worksheet.Cells[row, 5].Value = student.Phone;
                    worksheet.Cells[row, 6].Value = student.Department;
                    worksheet.Cells[row, 7].Value = student.Year;
                    worksheet.Cells[row, 8].Value = student.Status;
                    row++;
                }

                // Auto-fit columns
                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                // Borders
                using (var range = worksheet.Cells[3, 1, row - 1, 8])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                // Save
                package.SaveAs(new FileInfo(filePath));
            }
        }

        #endregion

        #region Lecturers Export

        public static void ExportLecturers(List<Lecturer> lecturers, string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Danh sách Giảng viên");

                // Header
                worksheet.Cells["A1"].Value = "DANH SÁCH GIẢNG VIÊN";
                worksheet.Cells["A1:G1"].Merge = true;
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                // Column headers
                worksheet.Cells["A3"].Value = "STT";
                worksheet.Cells["B3"].Value = "Họ tên";
                worksheet.Cells["C3"].Value = "Email";
                worksheet.Cells["D3"].Value = "Số điện thoại";
                worksheet.Cells["E3"].Value = "Khoa";
                worksheet.Cells["F3"].Value = "Chuyên môn";
                worksheet.Cells["G3"].Value = "Ngày tạo";

                // Style header
                using (var range = worksheet.Cells["A3:G3"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 84, 166));
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // Data
                int row = 4;
                int stt = 1;
                foreach (var lecturer in lecturers)
                {
                    worksheet.Cells[row, 1].Value = stt++;
                    worksheet.Cells[row, 2].Value = lecturer.FullName;
                    worksheet.Cells[row, 3].Value = lecturer.Email;
                    worksheet.Cells[row, 4].Value = lecturer.Phone;
                    worksheet.Cells[row, 5].Value = lecturer.Department;
                    worksheet.Cells[row, 6].Value = lecturer.Specialization;
                    worksheet.Cells[row, 7].Value = lecturer.CreatedAt?.ToString("dd/MM/yyyy") ?? "";
                    row++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                using (var range = worksheet.Cells[3, 1, row - 1, 7])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                package.SaveAs(new FileInfo(filePath));
            }
        }

        #endregion

        #region Companies Export

        public static void ExportCompanies(List<Company> companies, string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Danh sách Doanh nghiệp");

                worksheet.Cells["A1"].Value = "DANH SÁCH DOANH NGHIỆP";
                worksheet.Cells["A1:G1"].Merge = true;
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells["A3"].Value = "STT";
                worksheet.Cells["B3"].Value = "Tên công ty";
                worksheet.Cells["C3"].Value = "Email";
                worksheet.Cells["D3"].Value = "Số điện thoại";
                worksheet.Cells["E3"].Value = "Địa chỉ";
                worksheet.Cells["F3"].Value = "Người liên hệ";
                worksheet.Cells["G3"].Value = "Ngày tạo";

                using (var range = worksheet.Cells["A3:G3"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 84, 166));
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                int row = 4;
                int stt = 1;
                foreach (var company in companies)
                {
                    worksheet.Cells[row, 1].Value = stt++;
                    worksheet.Cells[row, 2].Value = company.CompanyName;
                    worksheet.Cells[row, 3].Value = company.ContactEmail;
                    worksheet.Cells[row, 4].Value = company.ContactPhone;
                    worksheet.Cells[row, 5].Value = company.Address;
                    worksheet.Cells[row, 6].Value = company.ContactPerson;
                    worksheet.Cells[row, 7].Value = company.CreatedAt?.ToString("dd/MM/yyyy") ?? "";
                    row++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                using (var range = worksheet.Cells[3, 1, row - 1, 7])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                package.SaveAs(new FileInfo(filePath));
            }
        }

        #endregion

        #region Topics Export

        public static void ExportTopics(List<InternshipTopic> topics, string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Danh sách Đề tài");

                worksheet.Cells["A1"].Value = "DANH SÁCH ĐỀ TÀI THỰC TẬP";
                worksheet.Cells["A1:H1"].Merge = true;
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells["A3"].Value = "STT";
                worksheet.Cells["B3"].Value = "Tiêu đề";
                worksheet.Cells["C3"].Value = "Mô tả";
                worksheet.Cells["D3"].Value = "Công ty";
                worksheet.Cells["E3"].Value = "Số lượng SV";
                worksheet.Cells["F3"].Value = "Yêu cầu";
                worksheet.Cells["G3"].Value = "Trạng thái";
                worksheet.Cells["H3"].Value = "Ngày tạo";

                using (var range = worksheet.Cells["A3:H3"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 84, 166));
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                int row = 4;
                int stt = 1;
                foreach (var topic in topics)
                {
                    worksheet.Cells[row, 1].Value = stt++;
                    worksheet.Cells[row, 2].Value = topic.Title;
                    worksheet.Cells[row, 3].Value = topic.Description;
                    worksheet.Cells[row, 4].Value = topic.CompanyName;
                    worksheet.Cells[row, 5].Value = topic.MaxStudents;
                    worksheet.Cells[row, 6].Value = topic.Requirements;
                    worksheet.Cells[row, 7].Value = topic.Status;
                    worksheet.Cells[row, 8].Value = topic.CreatedAt.ToString("dd/MM/yyyy");
                    row++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                using (var range = worksheet.Cells[3, 1, row - 1, 8])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                package.SaveAs(new FileInfo(filePath));
            }
        }

        #endregion

        #region Periods Export

        public static void ExportPeriods(List<InternshipPeriod> periods, string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Danh sách Kỳ thực tập");

                worksheet.Cells["A1"].Value = "DANH SÁCH KỲ THỰC TẬP";
                worksheet.Cells["A1:J1"].Merge = true;
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells["A3"].Value = "STT";
                worksheet.Cells["B3"].Value = "Tên kỳ";
                worksheet.Cells["C3"].Value = "Học kỳ";
                worksheet.Cells["D3"].Value = "Năm học";
                worksheet.Cells["E3"].Value = "Ngày bắt đầu";
                worksheet.Cells["F3"].Value = "Ngày kết thúc";
                worksheet.Cells["G3"].Value = "Hạn đăng ký";
                worksheet.Cells["H3"].Value = "Số SV";
                worksheet.Cells["I3"].Value = "Số đề tài";
                worksheet.Cells["J3"].Value = "Trạng thái";

                using (var range = worksheet.Cells["A3:J3"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 84, 166));
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                int row = 4;
                int stt = 1;
                foreach (var period in periods)
                {
                    worksheet.Cells[row, 1].Value = stt++;
                    worksheet.Cells[row, 2].Value = period.Name;
                    worksheet.Cells[row, 3].Value = period.Semester;
                    worksheet.Cells[row, 4].Value = period.AcademicYear;
                    worksheet.Cells[row, 5].Value = period.StartDate.ToString("dd/MM/yyyy");
                    worksheet.Cells[row, 6].Value = period.EndDate.ToString("dd/MM/yyyy");
                    worksheet.Cells[row, 7].Value = period.RegistrationDeadline.ToString("dd/MM/yyyy");
                    worksheet.Cells[row, 8].Value = period.RegisteredStudents;
                    worksheet.Cells[row, 9].Value = period.TotalTopics;
                    worksheet.Cells[row, 10].Value = period.Status;
                    row++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                using (var range = worksheet.Cells[3, 1, row - 1, 10])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                package.SaveAs(new FileInfo(filePath));
            }
        }

        #endregion

        #region System Logs Export

        public static void ExportSystemLogs(List<SystemLog> logs, string filePath)
        {
            using (var package = new ExcelPackage())
            {
                var worksheet = package.Workbook.Worksheets.Add("Nhật ký hệ thống");

                worksheet.Cells["A1"].Value = "NHẬT KÝ HỆ THỐNG";
                worksheet.Cells["A1:F1"].Merge = true;
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                worksheet.Cells["A3"].Value = "STT";
                worksheet.Cells["B3"].Value = "Thời gian";
                worksheet.Cells["C3"].Value = "Người dùng";
                worksheet.Cells["D3"].Value = "Hành động";
                worksheet.Cells["E3"].Value = "Chi tiết";
                worksheet.Cells["F3"].Value = "IP Address";

                using (var range = worksheet.Cells["A3:F3"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.FromArgb(0, 84, 166));
                    range.Style.Font.Color.SetColor(Color.White);
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                int row = 4;
                int stt = 1;
                foreach (var log in logs)
                {
                    worksheet.Cells[row, 1].Value = stt++;
                    worksheet.Cells[row, 2].Value = log.CreatedAt.ToString("dd/MM/yyyy HH:mm:ss");
                    worksheet.Cells[row, 3].Value = log.UserName;
                    worksheet.Cells[row, 4].Value = log.Action;
                    worksheet.Cells[row, 5].Value = log.Details;
                    worksheet.Cells[row, 6].Value = log.IpAddress;
                    row++;
                }

                worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                using (var range = worksheet.Cells[3, 1, row - 1, 6])
                {
                    range.Style.Border.Top.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Left.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Right.Style = ExcelBorderStyle.Thin;
                    range.Style.Border.Bottom.Style = ExcelBorderStyle.Thin;
                }

                package.SaveAs(new FileInfo(filePath));
            }
        }

        #endregion
    }
}

