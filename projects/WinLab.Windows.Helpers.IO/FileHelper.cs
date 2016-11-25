using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.InteropServices;

namespace WinLab.Windows.Helpers.IO
{
    [Guid("0642B95A-B707-4A4C-B5A5-073CB725BA53")]
    public class FileHelper
    {
        public static FileVersionInfo GetFileVersionInfo(string filePath)
        {
            return File.Exists(filePath) ? FileVersionInfo.GetVersionInfo(filePath) : null;
        }
    }
}