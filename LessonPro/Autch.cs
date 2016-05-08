using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LessonPro
{
    public partial class Autch : Form
    {
        public string logins;
            public string passwords;
        public Autch()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            logins = login.Text;
            passwords = password.Text;
            Close();
        }
    }
}
