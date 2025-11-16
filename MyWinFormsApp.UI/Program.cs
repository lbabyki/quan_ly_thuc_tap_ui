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

        // Khởi chạy LoginForm thay vì Form1
        Application.Run(new LoginForm());
    }
}