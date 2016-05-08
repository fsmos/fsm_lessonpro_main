namespace LessonPro
{
    partial class ADDScan
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.scaner = new System.Windows.Forms.ComboBox();
            this.scanerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lessonProDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lessonProDataSet = new LessonPro.LessonProDataSet();
            this.scanerTableAdapter = new LessonPro.LessonProDataSetTableAdapters.ScanerTableAdapter();
            this.scanname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.scanTableAdapter1 = new LessonPro.LessonProDataSetTableAdapters.ScanTableAdapter();
            this.DPI = new System.Windows.Forms.Label();
            this.dpim = new System.Windows.Forms.TextBox();
            this.maxdpi = new System.Windows.Forms.Label();
            this.mode = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.countlist = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ft = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.scanerBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lessonProDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lessonProDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // scaner
            // 
            this.scaner.DataSource = this.scanerBindingSource;
            this.scaner.DisplayMember = "ScanerName";
            this.scaner.FormattingEnabled = true;
            this.scaner.Location = new System.Drawing.Point(53, 12);
            this.scaner.Name = "scaner";
            this.scaner.Size = new System.Drawing.Size(282, 21);
            this.scaner.TabIndex = 0;
            this.scaner.ValueMember = "ScanerName";
            this.scaner.SelectionChangeCommitted += new System.EventHandler(this.scaner_SelectionChangeCommitted);
            this.scaner.TextUpdate += new System.EventHandler(this.scaner_TextUpdate);
            this.scaner.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.scaner_ControlAdded);
            // 
            // scanerBindingSource
            // 
            this.scanerBindingSource.DataMember = "Scaner";
            this.scanerBindingSource.DataSource = this.lessonProDataSetBindingSource;
            // 
            // lessonProDataSetBindingSource
            // 
            this.lessonProDataSetBindingSource.DataSource = this.lessonProDataSet;
            this.lessonProDataSetBindingSource.Position = 0;
            // 
            // lessonProDataSet
            // 
            this.lessonProDataSet.DataSetName = "LessonProDataSet";
            this.lessonProDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // scanerTableAdapter
            // 
            this.scanerTableAdapter.ClearBeforeFill = true;
            // 
            // scanname
            // 
            this.scanname.Location = new System.Drawing.Point(115, 60);
            this.scanname.Name = "scanname";
            this.scanname.Size = new System.Drawing.Size(211, 20);
            this.scanname.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 63);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(105, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Имя Сканирования";
            // 
            // scanTableAdapter1
            // 
            this.scanTableAdapter1.ClearBeforeFill = true;
            // 
            // DPI
            // 
            this.DPI.AutoSize = true;
            this.DPI.Location = new System.Drawing.Point(12, 107);
            this.DPI.Name = "DPI";
            this.DPI.Size = new System.Drawing.Size(25, 13);
            this.DPI.TabIndex = 3;
            this.DPI.Text = "DPI";
            this.DPI.Click += new System.EventHandler(this.DPI_Click);
            // 
            // dpim
            // 
            this.dpim.Location = new System.Drawing.Point(61, 104);
            this.dpim.Name = "dpim";
            this.dpim.Size = new System.Drawing.Size(265, 20);
            this.dpim.TabIndex = 4;
            // 
            // maxdpi
            // 
            this.maxdpi.AutoSize = true;
            this.maxdpi.Location = new System.Drawing.Point(115, 131);
            this.maxdpi.Name = "maxdpi";
            this.maxdpi.Size = new System.Drawing.Size(102, 13);
            this.maxdpi.TabIndex = 5;
            this.maxdpi.Text = "Максимальое DPI:";
            // 
            // mode
            // 
            this.mode.FormattingEnabled = true;
            this.mode.Location = new System.Drawing.Point(61, 166);
            this.mode.Name = "mode";
            this.mode.Size = new System.Drawing.Size(265, 21);
            this.mode.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Режим";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 210);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(110, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Количество страниц";
            // 
            // countlist
            // 
            this.countlist.Location = new System.Drawing.Point(128, 207);
            this.countlist.Name = "countlist";
            this.countlist.Size = new System.Drawing.Size(198, 20);
            this.countlist.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Сканер";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 246);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(61, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Тип файла";
            // 
            // ft
            // 
            this.ft.FormattingEnabled = true;
            this.ft.Items.AddRange(new object[] {
            "jpg",
            "bmp"});
            this.ft.Location = new System.Drawing.Point(79, 243);
            this.ft.Name = "ft";
            this.ft.Size = new System.Drawing.Size(247, 21);
            this.ft.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(142, 280);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 13;
            this.button1.Text = "Ок";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ADDScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 308);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ft);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.countlist);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mode);
            this.Controls.Add(this.maxdpi);
            this.Controls.Add(this.dpim);
            this.Controls.Add(this.DPI);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scanname);
            this.Controls.Add(this.scaner);
            this.Name = "ADDScan";
            this.Text = "Добавить сканирование";
            this.Load += new System.EventHandler(this.ADDScan_Load);
            this.Shown += new System.EventHandler(this.ADDScan_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.scanerBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lessonProDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lessonProDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox scaner;
        private System.Windows.Forms.BindingSource lessonProDataSetBindingSource;
        private LessonProDataSet lessonProDataSet;
        private System.Windows.Forms.BindingSource scanerBindingSource;
        private LessonProDataSetTableAdapters.ScanerTableAdapter scanerTableAdapter;
        private System.Windows.Forms.TextBox scanname;
        private System.Windows.Forms.Label label1;
        private LessonProDataSetTableAdapters.ScanTableAdapter scanTableAdapter1;
        private System.Windows.Forms.Label DPI;
        private System.Windows.Forms.TextBox dpim;
        private System.Windows.Forms.Label maxdpi;
        private System.Windows.Forms.ComboBox mode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox countlist;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox ft;
        private System.Windows.Forms.Button button1;
    }
}