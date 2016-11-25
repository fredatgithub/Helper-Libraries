using System;
using System.IO;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Reflection;
using System.Runtime.InteropServices;

namespace WinLab.Windows.Helpers.IO
{
    [Guid("0641B95A-B707-4A4C-B5A5-073CB705BA53")]
    public class AssemblyHelper
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

        public static bool IsSigned(string filepath)
        {
            var runspaceConfiguration = RunspaceConfiguration.Create();
            using (var runspace = RunspaceFactory.CreateRunspace(runspaceConfiguration))
            {
                runspace.Open();
                using (var pipeline = runspace.CreatePipeline())
                {
                    pipeline.Commands.AddScript("Get-AuthenticodeSignature \"" + filepath + "\"");
                    var results = pipeline.Invoke();
                    runspace.Close();

                    var signature = results[0].BaseObject as Signature;
                    return signature == null || signature.SignerCertificate == null ? false : (signature.Status != SignatureStatus.NotSigned);
                }
            }
        }
    }
}