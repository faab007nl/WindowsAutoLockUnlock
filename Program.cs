namespace WindowsAutoLockUnlock
{
    internal static class Program
    {

        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            // Start programm
            Application.Run(new WindowsAutoLockUnlock());
        }
    }
}