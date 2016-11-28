using System;
using System.Collections.ObjectModel;
using System.Management;
using System.Runtime.InteropServices;
using WinLab.Windows.Helpers.System.Models;

namespace WinLab.Windows.Helpers.System
{
    [Guid("12DD2C8D-F4B4-46B6-8899-230B418A00F0")]
    public class SystemHelper
    {
        private const string SecurityCenterLocation = @"\root\SecurityCenter";
        private const string SecurityCenter2Location = @"\root\SecurityCenter2";
        private const string AntivirusProductSearchQuery = "SELECT * FROM AntivirusProduct";

        public static bool IsAntivirusInstalled()
        {
            return GetAntivirusDetails().Count > 0;
        }

        public static ObservableCollection<Antivirus> GetAntivirusDetails()
        {
            var antivirusCollection = new ObservableCollection<Antivirus>();
            using (var searcher = new ManagementObjectSearcher(@"\\" + Environment.MachineName + SecurityCenterLocation, AntivirusProductSearchQuery))
            {
                GetInstalledAntivirusProducts(searcher, ref antivirusCollection);
            }

            using (var searcher = new ManagementObjectSearcher(@"\\" + Environment.MachineName + SecurityCenter2Location, AntivirusProductSearchQuery))
            {
                GetInstalledAntivirusProducts(searcher, ref antivirusCollection);
            }

            return antivirusCollection;
        }

        private static void GetInstalledAntivirusProducts(ManagementObjectSearcher searcher, ref ObservableCollection<Antivirus> antivirusCollection)
        {
            using (var searcherInstance = searcher.Get())
            {
                foreach (var instance in searcherInstance)
                {
                    antivirusCollection.Add(new Antivirus { ID = instance["instanceGuid"].ToString(), DisplayName = instance["displayName"].ToString() });
                }
            }
        }
    }
}
