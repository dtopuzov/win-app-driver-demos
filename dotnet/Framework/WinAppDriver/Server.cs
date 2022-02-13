using System;
using Framework.Utils;

namespace Framework.Server
{
    public static class Server
    {
        private static readonly string DriverExecutable = "WinAppDriver";

        public static Uri ServiceUri => new Uri("http://127.0.0.1:4723/");

        public static void Start()
        {
            Processes.KillByName(DriverExecutable);

            var driverHomePath = Environment.GetEnvironmentVariable("DRIVER_HOME");
            if (driverHomePath == null)
            {
                driverHomePath = @"c:\Program Files (x86)\Windows Application Driver\";
            }

            Execute.ExecuteCmd($"{DriverExecutable}.exe", driverHomePath, waitToFinish: false);
        }

        public static void Stop()
        {
            Processes.KillByName(DriverExecutable);
        }
    }
}
