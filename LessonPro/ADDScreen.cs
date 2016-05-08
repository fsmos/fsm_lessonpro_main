using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LessonPro
{
    public partial class ADDScreen : Form
    {
        public ADDScreen(string patch_v)
        {
            InitializeComponent();
            patch = patch_v;
        }
       public  bool sv;
       public string patch;
       public string prof;
       public string name;
       public string port;
        public int guishow;
        public string url;
        private void ADDScreen_Load(object sender, EventArgs e)
        {
            Dprofile.Items.Clear();
            foreach(string pf in Directory.GetFiles(patch + "Profiles\\"))
            {
             
                Dprofile.Items.Add(pf);
            }
            Durl.Text = string.Format("mms:\\\\{0}.{1}.ru:{2}", Environment.MachineName, Environment.UserDomainName, Dport.Text);
        }

        private void Dport_TextChanged(object sender, EventArgs e)
        {
            Durl.Text = string.Format("mms:\\\\{0}.{1}.ru:{2}", Environment.MachineName, Environment.UserDomainName, Dport.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            guishow = System.Convert.ToInt32(Dguishow.Checked);
            name = Dname.Text;
            prof = Dprofile.Text;
            port = Dport.Text;
            url = Durl.Text;
            sv=true;
            Close();
        }
    }
}
