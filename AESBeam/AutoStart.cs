using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

namespace AESBeam
{
    public static class AutoStart
    {
        //Usage: AutoStart.AddDirectory("C:\\Program Files\\AES\\AESBeam.exe", "C:\\Program Files\\AES\\Data");
        public static void AddDirectory(string AppDirectory, string DataDirectory)
        {
            string AppFolder = AppDirectory.Substring(0, AppDirectory.LastIndexOf("\\"));
            string ActiveProgramLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string AppStatus = null;
            try
            {
                System.IO.Directory.CreateDirectory(AppFolder);
            }
            catch (Exception)
            {
                AESApi.Report("101");//Reporting System
            }
            try
            {
                System.IO.Directory.CreateDirectory(DataDirectory);
            }
            catch (Exception)
            {
                AESApi.Report("102");//Reporting System
            }
            try
            {
                System.IO.File.Copy(ActiveProgramLocation, AppDirectory);
                AppStatus = "firstinstall";
            }
            catch (Exception)
            {
                AESApi.Report("103");//Reporting System
            }
            if (AppStatus == "firstinstall")
            {
                Process.Start(AppDirectory);
                Application.Exit();
            }
            return;
        }
        //Usage: AutoStart.AddtoReg("AESBeam", "C:\\Program Files\\AES\\AESBeam.exe");
        public static void AddtoReg(string NickName, string AppDirectory)
        {
            try
            {
                Registry.CurrentUser.CreateSubKey(@"Software\\Microsoft\\Windows\\CurrentVersion\\Run").SetValue(NickName, AppDirectory, RegistryValueKind.String);
                Registry.CurrentUser.CreateSubKey(@"Software\\Microsoft\\Windows\\CurrentVersion\\RunOnce").SetValue(NickName, AppDirectory, RegistryValueKind.String);
            }
            catch (Exception)
            {
                AESApi.Report("104");//Reporting System
            }
            return;
        }
        //Usage: AutoStart.GetPFDirectory("AES\\AESBeam.exe");
        public static string GetPFDirectory(string PFAppName)
        {
            string SystemProgramFileLocation = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
            SystemProgramFileLocation = SystemProgramFileLocation + "\\" + PFAppName;
            return SystemProgramFileLocation;
        }
    }
}
