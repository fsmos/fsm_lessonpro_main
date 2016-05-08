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
    public partial class Comment : Form
    {
        public Comment(string comment)
        {
            InitializeComponent();
            richTextBox1.Text = comment;
        }
        public Comment()
        {
            InitializeComponent();
        }
        public string comments="";
        private void button1_Click(object sender, EventArgs e)
        {
            comments = richTextBox1.Text;
            Close();
        }
    }
}
