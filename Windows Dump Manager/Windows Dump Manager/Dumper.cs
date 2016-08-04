using DumpManager.Enums;
using Microsoft.Win32.SafeHandles;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace DumpManager
{
    [Guid("C60514E1-A23F-4677-961D-4CD09EC85AB3")]
    public static class Dumper
    {
        [DllImportAttribute("dbghelp.dll")]
        [return: MarshalAsAttribute(UnmanagedType.Bool)]
        private static extern bool MiniDumpWriteDump([In] IntPtr hProcess, uint ProcessId, SafeFileHandle hFile, DumpType DumpType, [In] IntPtr ExceptionParam, [In] IntPtr UserStreamParam, [In] IntPtr CallbackParam);

        /// <summary>
        /// Writes the dump for process.
        /// </summary>
        /// <param name="processID">The process identifier. If it is the current process, pass <code>(uint)Process.GetCurrentProcess().Id</code>.</param>
        /// <param name="folderPath">The folder path where you want to store the dump file.</param>
        /// <param name="dumpFileName">Name of the dump file.</param>
        /// <param name="dumpType">Type of the dump (optional). Default is: <code>DumpType.MiniDumpNormal</code>.</param>
        /// <exception cref="Win32Exception">Error writing the dump file.</exception>
        public static void WriteDumpForProcess(uint processID, string folderPath, string dumpFileName, DumpType dumpType = DumpType.MiniDumpNormal)
        {
            if (!Directory.Exists(folderPath)) { Directory.CreateDirectory(folderPath); }

            var dumpFilePath = Path.GetFullPath(Path.Combine(folderPath, dumpFileName));
            using (var fileStream = File.Create(dumpFilePath))
            {
                if (!MiniDumpWriteDump(Process.GetCurrentProcess().Handle, processID, fileStream.SafeFileHandle, dumpType,
                    IntPtr.Zero, IntPtr.Zero, IntPtr.Zero))
                {
                    throw new Win32Exception(Marshal.GetLastWin32Error(), "Error writing the dump file: " + dumpFilePath);
                }
            }
        }
    }
}
