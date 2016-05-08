namespace LessonPro
{
    partial class ADDScreen
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
            this.Dname = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.Dprofile = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Durl = new System.Windows.Forms.TextBox();
            this.Dport = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Dguishow = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // Dname
            // 
            this.Dname.Location = new System.Drawing.Point(135, 23);
            this.Dname.Name = "Dname";
            this.Dname.Size = new System.Drawing.Size(242, 20);
            this.Dname.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя";
            // 
            // Dprofile
            // 
            this.Dprofile.FormattingEnabled = true;
            this.Dprofile.Location = new System.Drawing.Point(135, 59);
            this.Dprofile.Name = "Dprofile";
            this.Dprofile.Size = new System.Drawing.Size(242, 21);
            this.Dprofile.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Профиль";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(159, 189);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Ок";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "URL";
            // 
            // Durl
            // 
            this.Durl.Location = new System.Drawing.Point(135, 136);
            this.Durl.Name = "Durl";
            this.Durl.Size = new System.Drawing.Size(242, 20);
            this.Durl.TabIndex = 6;
            // 
            // Dport
            // 
            this.Dport.Location = new System.Drawing.Point(135, 98);
            this.Dport.Name = "Dport";
            this.Dport.Size = new System.Drawing.Size(242, 20);
            this.Dport.TabIndex = 7;
            this.Dport.Text = "8049";
            this.Dport.TextChanged += new System.EventHandler(this.Dport_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Порт";
            // 
            // Dguishow
            // 
            this.Dguishow.AutoSize = true;
            this.Dguishow.Location = new System.Drawing.Point(16, 168);
            this.Dguishow.Name = "Dguishow";
            this.Dguishow.Size = new System.Drawing.Size(159, 17);
            this.Dguishow.TabIndex = 9;
            this.Dguishow.Text = "Показывать окно захвата";
            this.Dguishow.UseVisualStyleBackColor = true;
            // 
            // ADDScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(389, 224);
            this.Controls.Add(this.Dguishow);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Dport);
            this.Controls.Add(this.Durl);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Dprofile);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Dname);
            this.Name = "ADDScreen";
            this.Text = "ADDScreen";
            this.Load += new System.EventHandler(this.ADDScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Dname;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Dprofile;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox Durl;
        private System.Windows.Forms.TextBox Dport;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox Dguishow;
    }
}