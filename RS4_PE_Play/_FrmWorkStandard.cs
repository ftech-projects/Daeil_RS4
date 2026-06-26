using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class _FrmWorkStandard : Form
    {
        public _FrmWorkStandard()
        {
            InitializeComponent();
        }

        public void LoadPicture(string picName)
        {
            string dir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Image_WorkStandard");
            Directory.CreateDirectory(dir);

            // 원본 이름으로 시도
            if (TryLoad(dir, picName + ".png")) return;
            if (TryLoad(dir, picName + ".jpg")) return;

            // Op05 방식: 5번째 글자를 '0'으로 대체한 이름으로 시도
            if (picName.Length >= 5)
            {
                string alt = picName.Substring(0, 4) + "0" + picName.Substring(5);
                if (TryLoad(dir, alt + ".png")) return;
                TryLoad(dir, alt + ".jpg");
            }
        }

        private bool TryLoad(string dir, string fileName)
        {
            try
            {
                string path = Path.Combine(dir, fileName);
                srcPictureBox.Image = Image.FromFile(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void srcPictureBox_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
