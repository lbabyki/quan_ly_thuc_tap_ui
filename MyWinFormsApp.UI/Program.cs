using MyWinFormsApp.Forms;

namespace MyWinFormsApp;

/// <summary>
/// Program - Entry point của ứng dụng
/// </summary>
static class Program
{
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();

        // Khởi động ứng dụng từ LoginForm
        Application.Run(new LoginForm());

        // TEST: Chạy form trực tiếp để test (bỏ comment dòng cần test)
        // Application.Run(new AdminForm());
        // Application.Run(new StudentForm());
        // Application.Run(new TeacherForm());
        // Application.Run(new CompanyForm());
    }
}