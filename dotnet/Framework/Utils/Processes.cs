using System.Diagnostics;

namespace Framework.Utils
{
    public static class Processes
    {
        public static void KillByName(string processName)
        {
            foreach (var process in Process.GetProcessesByName(processName))
            {
                process.Kill();
            }
        }
    }
}
