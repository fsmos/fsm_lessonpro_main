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
    public partial class ADDScan : Form
    {
        public ADDScan(System.Data.SqlClient.SqlConnection sqlc)
        {
            InitializeComponent();
            scanerTableAdapter.Connection = sqlc;
            scanTableAdapter1.Connection = sqlc;
            scaner.Refresh();
        }
        public int idlesson;
        public string filepatches;
        public bool sv;
        private void ADDScan_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "lessonProDataSet.Scaner". При необходимости она может быть перемещена или удалена.
            this.scanerTableAdapter.Fill(this.lessonProDataSet.Scaner);

        }

        private void DPI_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void scaner_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var q = scanerTableAdapter.SelectPrinter(scaner.Text);
            mode.Items.Clear();
            foreach (string mod in ((string)q.Rows[0].ItemArray[3]).Split('-'))
            {
                mode.Items.Add(mod);
            }
            maxdpi.Text = "Максимальое DPI:" + (string)q.Rows[0].ItemArray[4];
        }

        private void scaner_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void scaner_TextUpdate(object sender, EventArgs e)
        {
            var q = scanerTableAdapter.SelectPrinter(scaner.Text);
            mode.Items.Clear();
            foreach (string mod in ((string)q.Rows[0].ItemArray[3]).Split('-'))
            {
                mode.Items.Add(mod);
            }
            maxdpi.Text = "Максимальое DPI:" + (string)q.Rows[0].ItemArray[4];
        }

        private void ADDScan_Shown(object sender, EventArgs e)
        {
            var q = scanerTableAdapter.SelectPrinter(scaner.Text);
            mode.Items.Clear();
            foreach (string mod in ((string)q.Rows[0].ItemArray[3]).Split('-'))
            {
                mode.Items.Add(mod);
            }
            maxdpi.Text = "Максимальое DPI:" + (string)q.Rows[0].ItemArray[4];
            dpim.Text = (string)q.Rows[0].ItemArray[4];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            scanTableAdapter1.Insert(scanname.Text, filepatches + idlesson + "\\" + scanname.Text, int.Parse(dpim.Text), mode.Text, int.Parse(countlist.Text), idlesson, ft.Text);
            Close();
        }

    }
}
