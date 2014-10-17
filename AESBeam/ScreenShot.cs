using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace AESBeam
{
    public static class ScreenShot
    {
        public static Bitmap CreateSS(string TargetFolder, string SSFileName)
        {   Bitmap CreateSS = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics GFX = Graphics.FromImage(CreateSS);
            GFX.CopyFromScreen(Screen.PrimaryScreen.Bounds.X, Screen.PrimaryScreen.Bounds.Y, 0, 0, Screen.PrimaryScreen.Bounds.Size);
            CreateSS.Save(TargetFolder + "\\" + SSFileName, ImageFormat.Jpeg);
            return CreateSS;
        }
        public static string SSFileName()
        {
            string SSFileName = DateTime.Now.ToString("HHmmssffffff") + ".jpg";
            return SSFileName;
        }
    }
}
