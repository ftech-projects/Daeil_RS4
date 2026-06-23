using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ResisterTest
{
    public partial class _FrmPassWord: Form
    {
        public _FrmPassWord()
        {
            InitializeComponent();
        }

        private string GetMasterPassword()
        {
            long today = long.Parse(DateTime.Now.ToString("yyyyMMdd"));
            return (today * 2).ToString();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtboxPassWord.Text == GlobalValues.strPassWord)
            {
                GlobalValues.openForm.Show();
                this.Close();
            }
            else if(txtboxPassWord.Text == GetMasterPassword())
            {
                GlobalValues.openForm.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("비밀번호가 틀렸습니다.");
            }
            
        }
    }
}
