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
    public partial class Rename : Form
    {
        public string namest;
        public bool sv;
        public Rename(string namst)
        {
            InitializeComponent();
           
            textBox1.Text = namst;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            namest = textBox1.Text;
              sv = true;
            Close();
          

        }
    }
}
