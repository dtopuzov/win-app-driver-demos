using System;
using System.Diagnostics;

namespace Framework.Utils
{
    public static class Execute
    {
        public static string ExecuteCmd(string command, string workingDirectory, bool waitToFinish = true)
        {
            var output = string.Empty;
            var error = string.Empty;

            using (var compiler = new Process())
            {
                compiler.StartInfo.FileName = "cmd.exe";
                compiler.StartInfo.Arguments = $@"/c {command}";
                compiler.StartInfo.WorkingDirectory = workingDirectory;
                compiler.StartInfo.UseShellExecute = false;
                compiler.StartInfo.RedirectStandardOutput = true;
                compiler.StartInfo.RedirectStandardError = true;
                compiler.Start();

                if (waitToFinish)
                {
                    output = compiler.StandardOutput.ReadToEnd();
                    error = compiler.StandardError.ReadToEnd();
                    compiler.WaitForExit();
                }
            }

            return error == string.Empty ? output : output + Environment.NewLine + error;
        }

        public static void PowerShellComand(string arguments)
        {
            var p = new ProcessStartInfo
            {
                UseShellExecute = true,
                CreateNoWindow = false,
                Arguments = arguments,
                Verb = "runas",
                WindowStyle = ProcessWindowStyle.Hidden,
                FileName = "powershell.exe"
            };
            var proces = Process.Start(p);
            proces.WaitForExit();
        }
    }
}
