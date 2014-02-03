using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C2CWindowsDesktopClient.Helpers
{
    public static class Utilities
    {
        public static string GetDropBoxPath()
        {
            string appDataPath = Environment.GetFolderPath(
                                   Environment.SpecialFolder.ApplicationData);
            string dbPath = System.IO.Path.Combine(appDataPath, "Dropbox\\host.db");
            string[] lines = System.IO.File.ReadAllLines(dbPath);
            byte[] dbBase64Text = Convert.FromBase64String(lines[1]);
            string folderPath = System.Text.ASCIIEncoding.ASCII.GetString(dbBase64Text);
            
            return folderPath;
        }
    }
}
