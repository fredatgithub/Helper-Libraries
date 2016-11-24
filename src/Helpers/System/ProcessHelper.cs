
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace WinLab.Windows.Helpers.System
{
    [Guid("EC75486A-1ED2-4510-BF9D-4487916310A2")]
    public sealed class ProcessHelper
    {
        /// <summary>
        /// Determines whether the specified process is running.
        /// </summary>
        /// <param name="processName">Name of the process.</param>
        /// <returns>
        ///   <c>true</c> if the process is running; otherwise, <c>false</c>.
        /// </returns>
        public static bool IsProcessRunning(string processName)
        {
            var allProcesses = GetProcesses();
            processName = processName.ToLower();

            foreach (var process in allProcesses)
            {
                if (process.ProcessName.ToLower().StartsWith(processName))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Executes the process specified.
        /// </summary>
        /// <param name="filePath">The executable file path.</param>
        /// <param name="arguments">The arguments passed to the process.</param>
        /// <param name="runAsAdmin">Run as admin, if set to <c>true</c>.</param>
        /// <returns>Success of the execution.</returns>
        public static bool ExecuteProcess(string filePath, string arguments = null, bool runAsAdmin = false)
        {
            using (var process = new Process())
            {
                var processInfo = new ProcessStartInfo(filePath, arguments);
                processInfo.Verb = runAsAdmin ? "runas" : null;

                process.StartInfo = processInfo;
                return process.Start();
            }
        }

        /// <summary>
        /// Closes the specified process or kills it.
        /// </summary>
        /// <param name="processName">Name of the process to close/kill.</param>
        /// <param name="killProcess">Kill the process forcefully, if set to <c>true</c>.</param>
        public static void CloseOrKillProcess(string processName, bool killProcess = false)
        {
            var allProcesses = GetProcesses();
            processName = processName.ToLower();

            foreach (var process in allProcesses)
            {
                if (process.ProcessName.ToLower().StartsWith(processName))
                {
                    process.CloseMainWindow();

                    // if process is still running and kill option has been provided, kill it forcefully
                    if (killProcess && IsProcessRunning(processName))
                    {
                        process.Kill();
                    }
                }
            }
        }

        /// <summary>
        /// Gets the current process.
        /// </summary>
        /// <returns>The current process</returns>
        public static Process GetCurrentProcess()
        {
            return Process.GetCurrentProcess();
        }

        /// <summary>
        /// Gets the process by identifier.
        /// </summary>
        /// <param name="processId">The process identifier.</param>
        /// <returns>The process identified by process Id</returns>
        public static Process GetProcessById(int processId)
        {
            return Process.GetProcessById(processId);
        }

        /// <summary>
        /// Gets the process by identifier.
        /// </summary>
        /// <param name="processId">The process identifier.</param>
        /// <param name="machineName">Name of the machine.</param>
        /// <returns>The process identified by process Id</returns>
        public static Process GetProcessById(int processId, string machineName)
        {
            return Process.GetProcessById(processId, machineName);
        }

        /// <summary>
        /// Gets all the processes.
        /// </summary>
        /// <returns>The processes running</returns>
        public static Process[] GetProcesses()
        {
            return Process.GetProcesses();
        }

        /// <summary>
        /// Gets all the processes running in a particular machine.
        /// </summary>
        /// <param name="machineName">Name of the machine.</param>
        /// <returns>The processes running in that machine</returns>
        public static Process[] GetProcesses(string machineName)
        {
            return Process.GetProcesses(machineName);
        }

        /// <summary>
        /// Gets all the processes specified by process name.
        /// </summary>
        /// <param name="processName">Name of the process.</param>
        /// <returns>The processes having the specified name</returns>
        public static Process[] GetProcessesByName(string processName)
        {
            return Process.GetProcessesByName(processName);
        }

        /// <summary>
        /// Gets all the processes running in a particular machine, specified by process name.
        /// </summary>
        /// <param name="processName">Name of the process.</param>
        /// <param name="machineName">Name of the machine.</param>
        /// <returns>The processes running in that machine, having the specified name</returns>
        public static Process[] GetProcessesByName(string processName, string machineName)
        {
            return Process.GetProcessesByName(processName, machineName);
        }
    }
}