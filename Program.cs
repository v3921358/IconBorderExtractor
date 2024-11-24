using System.Globalization;

namespace ExtractIconBorder;

static class Program
{
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // To customize application configuration such as set high DPI settings or default font,
        // see https://aka.ms/applicationconfiguration.
        ApplicationConfiguration.Initialize();
        ApplyCulture();
        Application.Run(new MainForm());
    }

    static void ApplyCulture()
    {
        CultureInfo culture = CultureInfo.CurrentCulture;
        Thread.CurrentThread.CurrentUICulture = culture;
        Thread.CurrentThread.CurrentCulture = culture;
    }
    
}