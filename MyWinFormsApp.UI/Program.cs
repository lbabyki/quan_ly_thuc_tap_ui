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

        // TEST: Chạy AdminForm trực tiếp để test
        Application.Run(new AdminForm());

        // Hoặc chạy LoginForm như bình thường
        // Application.Run(new LoginForm());
    }
}