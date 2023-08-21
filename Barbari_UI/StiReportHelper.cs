using System;
using System.IO;
using Stimulsoft.Report;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Barbari_UI
{
    public class StiReportHelper
    {
        public static StiReport GetReport(string reportName)
        {
            StiReport rpt = new StiReport();
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Report", reportName);
            string stiDir = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Stimulsoft");
            string stiDir_license = Path.Combine(stiDir, "license.key");
            if (!File.Exists(stiDir_license))
            {
                string license = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Report", "license.key");
                File.Copy(license, stiDir_license);
            }
            string stiDir_account = Path.Combine(stiDir, "account.dat");
            if (!File.Exists(stiDir_account))
            {
                string account = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Report", "account.dat");
                File.Copy(account, stiDir_account);
            }
            rpt.Load(path);
            return rpt;
        }
    }
}
