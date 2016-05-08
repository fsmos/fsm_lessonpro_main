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
    public partial class ADDLesson : Form
    {
        public ADDLesson()
        {
            InitializeComponent();
        }
        public ADDLesson(string name, DateTime Data, int StartTime, int EndTime)
        {
            InitializeComponent();
            dateTimePicker1.Value = Data;
            LesName.Text = name;
            dateTimePicker2.Value = DateTime.Parse(string.Format("{0}.{1}.{2} {3}:{4}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, System.Convert.ToInt32(StartTime / 60), StartTime%60));
            dateTimePicker3.Value = DateTime.Parse(string.Format("{0}.{1}.{2} {3}:{4}", DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year, System.Convert.ToInt32(EndTime / 60), EndTime % 60));
        }
        public string name;
        public DateTime Data;
        public int StartTime;
        public int EndTime;
        public bool sv;
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = LesName.Text;
            Data = dateTimePicker1.Value;
            StartTime = (dateTimePicker2.Value.Hour * 60) + dateTimePicker2.Value.Minute;
            EndTime = (dateTimePicker3.Value.Hour * 60) + dateTimePicker3.Value.Minute;
            sv = true;
            Close();
        }

        private void ADDLesson_Load(object sender, EventArgs e)
        {

        }
    }
}
