using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace WinLab.Windows.Helpers.IO
{
    [Guid("0641B95A-B707-4A4C-B5A5-073CB705BA53")]
    public class AssemblyFileHelper
    {
        public static Assembly GetAssemblyFromFile(string filePath)
        {
            return File.Exists(filePath) ? Assembly.LoadFrom(filePath) : null;
        }

        public static AssemblyName GetAssemblyName(Assembly assembly)
        {
            return assembly.GetName();
        }

        public static string GetAssemblyDisplayName(Assembly assembly)
        {
            return GetAssemblyName(assembly).FullName;
        }

        public static Version GetAssemblyVersion(Assembly assembly)
        {
            return GetAssemblyName(assembly).Version;
        }
    }
}