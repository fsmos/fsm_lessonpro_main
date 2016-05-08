using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
using LessonPro.LessonProDataSetTableAdapters;
using WMEncoderLib;
using System.Security.Cryptography;  

namespace LessonPro
{
    public partial class Form1 : Form
    {
        LessonProDataSetTableAdapters.LessonTableAdapter dbl; //уроки
        LessonProDataSetTableAdapters.FileTableAdapter fl; //файлы
        LessonProDataSetTableAdapters.ScanerTableAdapter sce; //Сканеры
        LessonProDataSetTableAdapters.ScanTableAdapter scf; //Сканирования
        LessonProDataSetTableAdapters.SettingTableAdapter setanapter; //Настройка
        LessonProDataSetTableAdapters.DTMediaTableAdapter dtm; //Трансляции
        LessonProDataSetTableAdapters.TbalsTableAdapter tb; //Баллы учителей
        LessonProDataSetTableAdapters.TeacherTableAdapter teacher;//Учителя
        LessonProDataSetTableAdapters.ConTLTableAdapter ct; //Отношение урок-учитель
        LessonProDataSetTableAdapters.GroupTableAdapter group; //Группы
        LessonProDataSetTableAdapters.ConGLTableAdapter cgl;//Отношение урок-группа
        LessonProDataSetTableAdapters.GbalsTableAdapter gb;//Баллы группы
        LessonProDataSetTableAdapters.StudentTableAdapter student;//Студенты
        LessonProDataSetTableAdapters.SbalsTableAdapter sb; //Баллы студентов
        LessonProDataSetTableAdapters.UserTableAdapter user; //Пользователи
        LessonProDataSetTableAdapters.FileCommentTableAdapter comment; //Коментарии
        LessonProDataSetTableAdapters.DopFileTableAdapter df; //Дополнительные файлы
        WMEncoderApp EncoderApp;
        IWMEncoder Encoder;
        string autchsql = "Integrated Security=True";
        int studentidlogin = 0;
        int groupidlogin = 0;
        bool Studentsel = false;
        public Form1()
        {
            InitializeComponent();
       
        }
        int idlesson = 0;
        string filepatches = "";
        string scanersetting = "";
        private void ShowALLButton()
        {
            ribbonTab3.Visible = true;
            ribbonTab4.Visible = true;
            ribbonTab5.Visible = true;
            ribbonTab6.Visible = true;
            ribbonTab7.Visible = true;
            StudentSellect.Visible = true;
            ribbon1.Update();
            ribbon1.Refresh();
            if (Studentsel) StudentApply2();
            else  AdminApply2();
       
        }
        private void UpdateSubFile()
        {
            var q2 = df.DopLessonSelect(idlesson);
            info.Nodes[6].Nodes.Clear();
            for (int j = 0; j < q2.Rows.Count; j++)
            {
               info.Nodes[6].Nodes.Add(dbl.selectnamelesson(q2[j].DopLessonid));
                var q = fl.GetData(q2[j].DopLessonid);

                for (int i = 0; i < q.Rows.Count; i++)
                {


                    info.Nodes[6].Nodes[j].Nodes.Add((string)q.Rows[i].ItemArray[2], (string)q.Rows[i].ItemArray[1]);
                }
            }
            
        }
        private void UpdateGroup()
        {
            try
            {
                var q = cgl.SelectGroup(idlesson);
                info.Nodes[4].Nodes.Clear();
                 info.Nodes[5].Nodes.Clear();
                 for (int i = 0; i < q.Rows.Count; i++)
                 {


                     info.Nodes[4].Nodes.Add(((int)q.Rows[i].ItemArray[1]).ToString(), group.SelectGroupName(((int)q.Rows[i].ItemArray[1])));
                     var q2 = student.SelectStudent((int)q.Rows[i].ItemArray[1]);

                     for (int j = 0; j < q2.Rows.Count; j++)
                     {
                         info.Nodes[5].Nodes.Add(((int)q2.Rows[j].ItemArray[0]).ToString(), (string)q2.Rows[j].ItemArray[1]);
                     }
                 }
            }
            catch (Exception el)
            {
                new InfoMassege(el.Message);
                HideALLButton();
            }
        }
        private void UpdateATeacher()
        {
            try
            {
                TeacherBox.DropDownItems.Clear();
                var q = teacher.GetData();
                for (int i = 0; i < q.Rows.Count; i++)
                {
                    RibbonLabel rb = new RibbonLabel();
                    rb.Text = (string)q.Rows[i].ItemArray[1];
                    TeacherBox.DropDownItems.Add(rb);
                }
                UpdateTeacher();
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }
        private void UpdateAGroup()
        {
            try
            {
                GroupBox.DropDownItems.Clear();
                var q = group.GetData();
                for (int i = 0; i < q.Rows.Count; i++)
                {
                    RibbonLabel rb = new RibbonLabel();
                    rb.Text = (string)q.Rows[i].ItemArray[1];
                    GroupBox.DropDownItems.Add(rb);
                }
                UpdateGroup();
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }
        private void UpdateAStudent()
        {
            try
            {
                StudentBox.DropDownItems.Clear();
                var q = student.SelectStudent((int)group.SelectGroupid(SgroupBox.TextBoxText)) ;
                for (int i = 0; i < q.Rows.Count; i++)
                {
                    RibbonLabel rb = new RibbonLabel();
                    rb.Text = (string)q.Rows[i].ItemArray[1];
                    StudentBox.DropDownItems.Add(rb);
                }
                UpdateGroup();
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }
        private void UpdateAGroupasStudent()
        {
            try
            {
                SgroupBox.DropDownItems.Clear();
                var q = group.GetData();
                for (int i = 0; i < q.Rows.Count; i++)
                {
                    RibbonLabel rb = new RibbonLabel();
                    rb.Text = (string)q.Rows[i].ItemArray[1];
                    SgroupBox.DropDownItems.Add(rb);
                }
                UpdateGroup();
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }
        private void UpdateTeacher()
        {
            try
            {
                var q = ct.SelectTeacherByLesson(idlesson);
                info.Nodes[3].Nodes.Clear();
                for (int i = 0; i < q.Rows.Count; i++)
                {


                    info.Nodes[3].Nodes.Add(((int)q.Rows[i].ItemArray[1]).ToString(), teacher.SelectByTeacherid((int)q.Rows[i].ItemArray[1]));
                }
            }
            catch (Exception el)
            {
                new InfoMassege(el.Message);
                HideALLButton();
            }
        }
        private void ShowLessonButton()
        {
            ribbonTab2.Visible = true;
            ribbon1.Update();
            ribbon1.Refresh();
            HideALLButton();
        }
        private void ShowScanButton()
        {
          /*  ScanAdd.Visible = true;
            ScanStart.Visible = true;
            DeleteScan.Visible = true;
           * */
            ribbonPanel7.Enabled = true ;
            ribbon1.Update();
            ribbon1.Refresh();
        }
        private void HideALLButton()
        {
            ribbonTab3.Visible = false;
            ribbonTab4.Visible = false;
            ribbonTab5.Visible = false;
            ribbonTab6.Visible = false;
            ribbonTab7.Visible = false;
            StudentSellect.Visible = false;
            ribbon1.Update();
            ribbon1.Refresh();
            idlesson = 0;
            info.Nodes[0].Nodes.Clear();
            info.Nodes[1].Nodes.Clear();
            info.Nodes[2].Nodes.Clear();
            info.Nodes[3].Nodes.Clear();
            info.Nodes[4].Nodes.Clear();
            info.Nodes[5].Nodes.Clear();
        }
        private void HideScanButton()
        {
            /*
            ScanAdd.Visible = false;
            ScanStart.Visible = false;
            DeleteScan.Visible = false;
             * */
            ribbonPanel7.Enabled = false;
            ribbon1.Update();
            ribbon1.Refresh();
        }
        private void HideLessonButton()
        {
      
            ribbonTab2.Visible = false;
            HideALLButton();
            ribbon1.Update();
            ribbon1.Refresh();
        }
        private void StudentApply()
        {
            ribbonPanel8.Visible = false;
           
        }
        private void StudentApply2()
        {
            ribbonPanel10.Visible = false;
            ribbonPanel11.Visible = false;
            ribbonPanel13.Visible = false;
            ribbonPanel14.Visible = false;
            ribbonPanel15.Visible = false;
            ribbonPanel16.Visible = false;
            AuthStudent.Visible = false;
        }
        private void AdminApply()
        {
            ribbonPanel8.Visible = true;

        }
        private void AdminApply2()
        {
            ribbonPanel10.Visible = true;
            ribbonPanel11.Visible = true;
            ribbonPanel13.Visible = true;
            ribbonPanel14.Visible = true;
            ribbonPanel15.Visible = true;
            ribbonPanel16.Visible = true;
            AuthStudent.Visible = true;
        }
        string GetHashString(string s)
        {
            //переводим строку в байт-массим  
            byte[] bytes = Encoding.Unicode.GetBytes(s);

            //создаем объект для получения средст шифрования  
            MD5CryptoServiceProvider CSP =
                new MD5CryptoServiceProvider();

            //вычисляем хеш-представление в байтах  
            byte[] byteHash = CSP.ComputeHash(bytes);

            string hash = string.Empty;

            //формируем одну цельную строку из массива  
            foreach (byte b in byteHash)
                hash += string.Format("{0:x2}", b);

            return hash;
        }  
        private void Con_base_Click(object sender, EventArgs e)
        {
            try
            {
            user = new UserTableAdapter();
            System.Data.SqlClient.SqlConnection sc = new System.Data.SqlClient.SqlConnection(string.Format("Data Source={0};Initial Catalog={1}; {2}", server.TextBoxText, base_sv.TextBoxText, autchsql));
            user.Connection = sc;
                Autch sp =new Autch();
                sp.ShowDialog();
                if ((sp.logins != null) && (sp.logins != "") && (sp.passwords != null) && (sp.passwords != ""))
                {
                    if ((int)user.TestUser(sp.logins, GetHashString(sp.passwords)) != 0)
                    {
                        studentidlogin = (int)user.SelectStudentid(sp.logins, GetHashString(sp.passwords));

                        UserSp.Text = "Пользователь:" + sp.logins;
                        dbl = new LessonProDataSetTableAdapters.LessonTableAdapter();
                        fl = new FileTableAdapter();
                        sce = new ScanerTableAdapter();
                        scf = new ScanTableAdapter();
                        dtm = new DTMediaTableAdapter();
                        setanapter = new SettingTableAdapter();
                        tb = new TbalsTableAdapter();
                        teacher = new TeacherTableAdapter();
                        ct = new ConTLTableAdapter();
                        group = new GroupTableAdapter();
                        gb = new GbalsTableAdapter();
                        cgl = new ConGLTableAdapter();
                        student = new StudentTableAdapter();
                        sb = new SbalsTableAdapter();
                        comment = new FileCommentTableAdapter();
                        df = new DopFileTableAdapter();
                        sc.Open();
                        sc.Close();
                        con_status.Text = "Соединение успешно установлено";
                        infoeror.Text = "Соединение успешно установлено";
                        dbl.Connection = sc;
                        fl.Connection = sc;
                        sce.Connection = sc;
                        scf.Connection = sc;
                        dtm.Connection = sc;
                        setanapter.Connection = sc;
                        tb.Connection = sc;
                        teacher.Connection = sc;
                        ct.Connection = sc;
                        group.Connection = sc;
                        gb.Connection = sc;
                        cgl.Connection = sc;
                        student.Connection = sc;
                        sb.Connection = sc;
                        comment.Connection = sc;
                        df.Connection = sc;
                        con_base_st.Text = string.Format("Server:{0} Database: {1}", dbl.Connection.DataSource, dbl.Connection.Database);
                        ShowLessonButton();
                        filepatches = (string)setanapter.GetData("filepatch").Rows[0].ItemArray[1];
                        if (studentidlogin == -1)
                        {
                            Studentsel = false;
                            AdminApply();
                        }
                        else
                        {
                            Studentsel = true;
                            groupidlogin = (int)student.SelectGroupid(studentidlogin);
                            StudentApply();
                        }
                    }
                    else
                    {
                        con_status.Text = "Неверный логин или пароль";
                        HideLessonButton();
                    }
                }
            }
            catch(Exception el)
            {
                con_status.Text ="Ошибка соединения: "+el.HResult;
                infoeror.Text = "Ошибка соединения: " + el.HResult; 
                new InfoMassege(el.Message);
               HideLessonButton();
            }

        }

        void sc_InfoMessage(object sender, System.Data.SqlClient.SqlInfoMessageEventArgs e)
        {
   
        }
        private void UpdateLessonlist()
        {
            try
            {
                con.DropDownItems.Clear();
                if (Studentsel == false)
                {
                    var q = dbl.GETLESPRO((DateTime.Now.Hour * 60) + DateTime.Now.Minute, DateTime.Now.ToShortDateString());
                    for (int i = 0; i < q.Rows.Count; i++)
                    {
                        RibbonLabel rb = new RibbonLabel();
                        rb.Text = (string)q.Rows[i].ItemArray[1];
                        con.DropDownItems.Add(rb);
                    }
                }
                else
                {
                    var q2 = cgl.GetLessonbygid(groupidlogin);
                    for (int i = 0; i < q2.Rows.Count; i++)
                    {
                        string textadd = (string)dbl.GetLessonbyid(((int)q2.Rows[i].ItemArray[2]), (DateTime.Now.Hour * 60) + DateTime.Now.Minute, DateTime.Now.ToShortDateString());
                        if (textadd !=null)
                        {
                            RibbonLabel rb = new RibbonLabel();
                            rb.Text = textadd;
                            con.DropDownItems.Add(rb);
                        }
                    }
                }
                con.TextBoxText = "";
              
            }
            catch (Exception es)
            {
                //   HideLessonButton();
                infoeror.Text = "Ошибка соединения";
                new InfoMassege(es.Message);
            }
        }
        private void ribbonTab2_ActiveChanged(object sender, EventArgs e)
        {
            UpdateLessonlist();
        }

        private void con_lesson_Click(object sender, EventArgs e)
        {
            try
            {
                idlesson = (int)dbl.ScalarQuery(con.TextBoxText);
                var q = fl.GetData(idlesson);
                info.Nodes[0].Nodes.Clear();
                for (int i = 0; i < q.Rows.Count; i++)
                {


                    info.Nodes[0].Nodes.Add((string)q.Rows[i].ItemArray[2], (string)q.Rows[i].ItemArray[1]);
                }
                var q2 = scf.GetData(idlesson);
                info.Nodes[1].Nodes.Clear();
                for (int i = 0; i < q2.Rows.Count; i++)
                {


                    info.Nodes[1].Nodes.Add(((int)q2.Rows[i].ItemArray[0]).ToString(), (string)q2.Rows[i].ItemArray[1]);
                }
                UpdateScreen();
                UpdateTeacher();
                UpdateGroup();
                statusles.Text = "Подключение успешно установлено";
                lesidu.Text = string.Format("ID: {0}", idlesson);
                infoeror.Text = "Соединение успешно установлено";
                UpdateSubFile();
                ShowALLButton();
            }
            catch(Exception eq)
            {
                statusles.Text = "Ошибка:"+eq.HResult;
                infoeror.Text =  "Ошибка:"+eq.HResult;
                new InfoMassege(eq.Message);
                HideALLButton();
            }
             
        }

        private void DownloadFile_Click(object sender, EventArgs e)
        {
            try
            {
                open.ShowDialog();
                File.Copy(open.FileName, filepatches + idlesson + "\\" + open.SafeFileName, true);
                fl.AddFile(open.SafeFileName, filepatches + idlesson + "\\" + open.SafeFileName, idlesson);
                var q = fl.GetData(idlesson);
                info.Nodes[0].Nodes.Clear();
                for (int i = 0; i < q.Rows.Count; i++)
                {


                    info.Nodes[0].Nodes.Add((string)q.Rows[i].ItemArray[2], (string)q.Rows[i].ItemArray[1]);
                }
            }
            catch (Exception ep)
            {

                new InfoMassege(ep.Message);
            }
        }

        private void ReadFile_Click(object sender, EventArgs e)
        {
            try
            {
                save.FileName = info.SelectedNode.Text;
                save.ShowDialog();
                File.Copy(info.SelectedNode.Name, save.FileName, true);
            }
            catch (Exception ep)
            {

                new InfoMassege(ep.Message);
            }
        }

        private void DeleteFile_Click(object sender, EventArgs e)
        {
            try
            {
                File.Delete(info.SelectedNode.Name);
                fl.DeleteFile(info.SelectedNode.Text, idlesson);
                var q = fl.GetData(idlesson);
                info.Nodes[0].Nodes.Clear();
                for (int i = 0; i < q.Rows.Count; i++)
                {


                    info.Nodes[0].Nodes.Add((string)q.Rows[i].ItemArray[2], (string)q.Rows[i].ItemArray[1]);
                }
            }
            catch (Exception ep)
            {

                new InfoMassege(ep.Message);
            }
        }

        private void RenameFile_Click(object sender, EventArgs e)
        {
            try
            {
                Rename rnm = new Rename(info.SelectedNode.Text);
                rnm.sv = false;
                rnm.ShowDialog();
                if (rnm.sv) 
                {
                    fl.FileRename(rnm.namest, info.SelectedNode.Text, idlesson);
                    var q = fl.GetData(idlesson);
                    info.Nodes[0].Nodes.Clear();
                    for (int i = 0; i < q.Rows.Count; i++)
                    {


                        info.Nodes[0].Nodes.Add((string)q.Rows[i].ItemArray[2], (string)q.Rows[i].ItemArray[1]);
                    }
                }
            }
            catch (Exception ep)
            {

                new InfoMassege(ep.Message);
            }
        }

        private void ribbonTab4_ActiveChanged(object sender, EventArgs e)
        {
            try
            {
                scanerlist.DropDownItems.Clear();
                var q = sce.GetData();
                for (int i = 0; i < q.Rows.Count; i++)
                {

                    RibbonLabel rb = new RibbonLabel();
                    rb.Text = (string)q.Rows[i].ItemArray[0];
                    scanerlist.DropDownItems.Add(rb);
                }
            }
            catch (Exception ep)
            {

                new InfoMassege(ep.Message);
            }
        }

        private void ScanStart_Click(object sender, EventArgs e)
        {
            try
            {
                var q = sce.SelectPrinter(scanerlist.TextBoxText);
                LessonProScanConnect.ConnectScanServer.Connect((string)q.Rows[0].ItemArray[5], (int)q.Rows[0].ItemArray[6], int.Parse(info.SelectedNode.Name));
                var q2 = fl.GetData(idlesson);
                info.Nodes[0].Nodes.Clear();
                for (int i = 0; i < q2.Rows.Count; i++)
                {


                    info.Nodes[0].Nodes.Add((string)q2.Rows[i].ItemArray[2], (string)q2.Rows[i].ItemArray[1]);
                }
            }
            catch (Exception ep)
            {

                new InfoMassege(ep.Message);
            }
        }

        private void ScanAdd_Click(object sender, EventArgs e)
        {
            try
            {
                ADDScan scd = new ADDScan(scf.Connection);
                scd.idlesson = idlesson;
                scd.filepatches = filepatches;
                scd.ShowDialog();
                var q2 = scf.GetData(idlesson);
                info.Nodes[1].Nodes.Clear();
                for (int i = 0; i < q2.Rows.Count; i++)
                {


                    info.Nodes[1].Nodes.Add(((int)q2.Rows[i].ItemArray[0]).ToString(), (string)q2.Rows[i].ItemArray[1]);
                }
            }
            catch (Exception ep)
            {

                new InfoMassege(ep.Message);
            }

        }

        private void scanerlist_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (scanerlist.TextBoxText != "") ShowScanButton(); else HideScanButton();
        }

        private void DeleteScan_Click(object sender, EventArgs e)
        {
            try
            {
                scf.DeleteScan(idlesson, info.SelectedNode.Text);
                var q2 = scf.GetData(idlesson);
                info.Nodes[1].Nodes.Clear();
                for (int i = 0; i < q2.Rows.Count; i++)
                {


                    info.Nodes[1].Nodes.Add(((int)q2.Rows[i].ItemArray[0]).ToString(), (string)q2.Rows[i].ItemArray[1]);
                }
            }
            catch (Exception ep)
            {
            
                new InfoMassege(ep.Message);
            }

        }

        private void AddLesson_Click(object sender, EventArgs e)
        {
            try
            {
                ADDLesson ladd = new ADDLesson();
                ladd.sv = false;
                ladd.ShowDialog();
                if ((ladd.name != "") && ladd.sv)
                    if ((int)dbl.SelName(ladd.name) == 0)
                    {
                        dbl.ADDLesson(ladd.name, ladd.Data, ladd.StartTime, ladd.EndTime);
                        Directory.CreateDirectory(filepatches + (int)dbl.ScalarQuery(ladd.name));
                        statusles.Text = "Урок создан";
                        infoeror.Text = "Урок создан";
                    }
                    else
                    {
                        statusles.Text = "Урок уже существует";
                        infoeror.Text = "Урок уже существует";
                    }
                try
                {
                    con.DropDownItems.Clear();
                    var q = dbl.GETLESPRO((DateTime.Now.Hour * 60) + DateTime.Now.Minute, DateTime.Now.ToShortDateString());
                    for (int i = 0; i < q.Rows.Count; i++)
                    {
                        RibbonLabel rb = new RibbonLabel();
                        rb.Text = (string)q.Rows[i].ItemArray[1];
                        con.DropDownItems.Add(rb);
                    }
                }
                catch (Exception ep)
                {
                    HideLessonButton();
                    new InfoMassege(ep.Message);
                }
            }
            catch (Exception ep)
            {
               
                new InfoMassege(ep.Message);
            }

        }

        private void DeleteLesson_Click(object sender, EventArgs e)
        {
            try
            {
                Directory.Delete(filepatches + (int)dbl.ScalarQuery(con.TextBoxText));
                dbl.DeleteQuery(con.TextBoxText);
                statusles.Text = "Урок удалён";
                infoeror.Text = "Урок удалён";
                con.TextBoxText = "";
                try
                {
                    con.DropDownItems.Clear();
                    var q = dbl.GETLESPRO((DateTime.Now.Hour * 60) + DateTime.Now.Minute, DateTime.Now.ToShortDateString());
                    for (int i = 0; i < q.Rows.Count; i++)
                    {
                        RibbonLabel rb = new RibbonLabel();
                        rb.Text = (string)q.Rows[i].ItemArray[1];
                        con.DropDownItems.Add(rb);
                    }
                }
                catch (Exception ep)
                {
                    HideLessonButton();
                    new InfoMassege(ep.Message);
                }
            }
            catch(Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        //
        public void UpdateScreen()
        {
            try
            {
                var q2 = dtm.SelectDesktop(idlesson);
                info.Nodes[2].Nodes.Clear();
                for (int i = 0; i < q2.Rows.Count; i++)
                {


                    info.Nodes[2].Nodes.Add(((string)q2.Rows[i].ItemArray[3]).ToString(), (string)q2.Rows[i].ItemArray[5]);
                }
            }
            catch (Exception ep)
            {

                new InfoMassege(ep.Message);
            }
        }
        //
        private void ViewAll_Click(object sender, EventArgs e)
        {
            try
            {
                con.DropDownItems.Clear();
                var q = dbl.GetData();
                for (int i = 0; i < q.Rows.Count; i++)
                {
                    RibbonLabel rb = new RibbonLabel();
                    rb.Text = (string)q.Rows[i].ItemArray[1];
                    con.DropDownItems.Add(rb);
                }
            }
            catch (Exception ep)
            {
                HideLessonButton();
                new InfoMassege(ep.Message);
            }
        }

        private void EditLesson_Click(object sender, EventArgs e)
        {
            var q=dbl.GetLes(con.TextBoxText);
            ADDLesson edes=new ADDLesson((string)q.Rows[0].ItemArray[1],(DateTime)q.Rows[0].ItemArray[2],(int)q.Rows[0].ItemArray[3],(int)q.Rows[0].ItemArray[4]);
            edes.sv = false;
            
            edes.ShowDialog();
            if (edes.sv)
            {
                dbl.UpdateLesson(edes.name, edes.Data, edes.StartTime, edes.EndTime, con.TextBoxText);
                con.TextBoxText = "";
                try
                {
                    con.DropDownItems.Clear();
                    var q2 = dbl.GETLESPRO((DateTime.Now.Hour * 60) + DateTime.Now.Minute, DateTime.Now.ToShortDateString());
                    for (int i = 0; i < q2.Rows.Count; i++)
                    {
                        RibbonLabel rb = new RibbonLabel();
                        rb.Text = (string)q2.Rows[i].ItemArray[1];
                        con.DropDownItems.Add(rb);
                    }
                }

                catch (Exception ep)
                {
                    HideLessonButton();
                    new InfoMassege(ep.Message);
                }

            }
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void ADDScreen_Click(object sender, EventArgs e)
        {
            try
            {
                ADDScreen sc = new ADDScreen(filepatches);
                sc.sv = false;
                sc.ShowDialog();
                if (sc.sv && (sc.name != ""))
                    if ( ((int)dtm.TestDesktop(sc.name,idlesson) == 0) && (sc.url != "") && (sc.port != "") && (sc.prof != "") && (idlesson != 0))
                    {
                        dtm.InsertDesktop(sc.prof, idlesson, sc.url, sc.guishow, sc.name, sc.port);
                    }
                    else
                    {
                        new InfoMassege("Неправельно введены параметры или вы не подключены к уроку");
                    }
                UpdateScreen();
            }
            catch(Exception est)
            {
                new InfoMassege(est.Message);
            }
        }

        private void DeleteScreen_Click(object sender, EventArgs e)
        {
            try
            {
            if (info.SelectedNode.Parent == info.Nodes[2])
            {
                dtm.DeleteScreen(idlesson, info.SelectedNode.Text);
            }
            UpdateScreen();
            }
            catch (Exception est)
            {
                new InfoMassege(est.Message);
            }
        }

        private void InTrans_Click(object sender, EventArgs e)
        {
           try
            {
                if (info.SelectedNode.Parent == info.Nodes[2])
                {
                    var g = dtm.SSTS(info.SelectedNode.Text, idlesson);
                    if (EncoderApp == null)
                    {

                        EncoderApp = new WMEncoderApp();
                        Encoder = EncoderApp.Encoder;


                    }
                    else
                    {
                        Encoder.SourceGroupCollection.Remove("SG_1");
                    }


                    // Display the predefined Encoder UI.
                    EncoderApp.Visible = System.Convert.ToBoolean((int)g.Rows[0].ItemArray[4]);
                    if (EncoderApp.Visible == true)
                    {
                        HideTranslator.Enabled = true;
                    }
                    
                    // Specify the source for the input stream.
                    IWMEncSourceGroupCollection SrcGrpColl = Encoder.SourceGroupCollection;
                    IWMEncSourceGroup SrcGrp = SrcGrpColl.Add("SG_1");
                    IWMEncSource SrcAud = SrcGrp.AddSource(WMENC_SOURCE_TYPE.WMENC_AUDIO);
                    IWMEncVideoSource2 SrcVid = (IWMEncVideoSource2)SrcGrp.AddSource(WMENC_SOURCE_TYPE.WMENC_VIDEO);
                    SrcAud.SetInput("Default_Audio_Device", "Device", "");
                    SrcVid.SetInput("ScreenCap://ScreenCapture1", "", "");



                    WMEncProfile2 wm = new WMEncProfile2();
                    wm.LoadFromFile((string)g.Rows[0].ItemArray[1]);

                    SrcGrp.set_Profile(wm);


                    // Create a broadcast.
                    IWMEncBroadcast BrdCst = Encoder.Broadcast;
                    BrdCst.set_PortNumber(WMENC_BROADCAST_PROTOCOL.WMENC_PROTOCOL_HTTP, (int)g.Rows[0].ItemArray[6]);

                    // Start the encoding process.
                    Encoder.PrepareToEncode(true);
                    StartTranslator.Enabled = true;
                    StopTranslator.Enabled = true;
              }
            }
            catch (Exception est)
           {
               new InfoMassege(est.Message);
           }
        }

        private void HideTranslator_Click(object sender, EventArgs e)
        {
            EncoderApp.Visible = false;
            HideTranslator.Enabled = false;
        }

        private void StartTranslator_Click(object sender, EventArgs e)
        {
            Encoder.Start();
        }

        private void StopTranslator_Click(object sender, EventArgs e)
        {
            Encoder.Stop();
        }

        private void ViewTranslation_Click(object sender, EventArgs e)
        {
            if (info.SelectedNode.Parent == info.Nodes[2])
            {

                Process.Start("wmplayer",info.SelectedNode.Name);
            }
        }

        private void ribbonButton2_Click(object sender, EventArgs e)
        {
             try
            {
            ct.Insert((int)teacher.SelectbyName(TeacherBox.TextBoxText), idlesson); 
                 UpdateTeacher();
            }
             catch (Exception ep)
             {
                 new InfoMassege(ep.Message);
             }
         
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void ribbonTab6_ActiveChanged(object sender, EventArgs e)
        {
            UpdateATeacher();
         
        }

        private void info_Click(object sender, EventArgs e)
        {
            
        
         
        }

        private void DeleteTeachertoLesson_Click(object sender, EventArgs e)
        {
            try
            {
                if (info.SelectedNode.Parent == info.Nodes[3])
                {
                    ct.DeleteQuery(int.Parse(info.SelectedNode.Name), idlesson);
                    UpdateTeacher();
                }
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void InTeacherList_Click(object sender, EventArgs e)
        {
           NameTeacher.TextBoxText=TeacherBox.TextBoxText;
        }

        private void AddTeacher_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameTeacher.TextBoxText!="")
                {
                    teacher.Insert(NameTeacher.TextBoxText);
                }
                UpdateATeacher();
                UpdateTeacher();
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void RenameTeacherList_CanvasChanged(object sender, EventArgs e)
        {
         
        }

        private void RenameTeacherList_Click(object sender, EventArgs e)
        {
            try
            {
                if (NameTeacher.TextBoxText != "")
                {
                    teacher.Update(NameTeacher.TextBoxText, (int)teacher.SelectbyName(TeacherBox.TextBoxText));
                }
                UpdateATeacher();
                UpdateTeacher();
                TeacherBox.TextBoxText = "";
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void DeleteTeacher_Click(object sender, EventArgs e)
        {
            try
            {

                teacher.DeleteByName(TeacherBox.TextBoxText);
                
                UpdateATeacher();
                UpdateTeacher();
                TeacherBox.TextBoxText = "";
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void ribbonButton2_Click_1(object sender, EventArgs e)
        {
            try
             {
                int Tballsx=int.Parse(TBallSet.TextBoxText);
                if ((Tballsx >= 0) && (Tballsx <= 100))
                {
                    tb.Insert(int.Parse(info.SelectedNode.Name), idlesson, Tballsx, studentidlogin.ToString());
                    ribbonPanel12.Enabled = false;
                }
                
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void info_AfterSelect(object sender, TreeViewEventArgs e)
        {
          if(e.Node.Parent == info.Nodes[3])
            {
                if (tb.TestUsingTbals(int.Parse(info.SelectedNode.Name), idlesson, studentidlogin.ToString()) == 0)
                {
                    ribbonPanel12.Enabled = true;
                }
                else
                {
                    ribbonPanel12.Enabled = false;
                }
              
                DeleteTeachertoLesson.Enabled =true;
            }
            else
            {
                ribbonPanel12.Enabled = false;
       
                DeleteTeachertoLesson.Enabled = false;
            }
          if (e.Node.Parent == info.Nodes[4])
          {
              if ((int)gb.TestofusingGbals(idlesson, int.Parse(info.SelectedNode.Name), studentidlogin.ToString()) == 0)
              {
                  GroupBals.Enabled = true;
              }
              else
              {
                  GroupBals.Enabled = false;
              }

              DeleteGroupinLesson.Enabled = true;
          }
          else
          {
              GroupBals.Enabled = false;
              DeleteGroupinLesson.Enabled = false;
          }
          if (e.Node.Parent == info.Nodes[5])
          {
              if ((int)sb.TestSBalls(int.Parse(info.SelectedNode.Name), idlesson, studentidlogin.ToString()) == 0)
              {
                  StudenBallsSet.Enabled = true;
              }
              else
              {
                  StudenBallsSet.Enabled = false;
              }

            
          }
          else
          {
              StudenBallsSet.Enabled = false;
          }

          if (e.Node.Parent == info.Nodes[0])
          {
              DeleteFile.Enabled = true;
              ReadFile.Enabled = true;
              RenameFile.Enabled = true;
              ribbonButton2.Enabled = true;
          }
          else
          {
              DeleteFile.Enabled = false;
              ReadFile.Enabled = false ;
              RenameFile.Enabled = false;
              ribbonButton2.Enabled = false;
              if (e.Node.Parent != null)
                  if (e.Node.Parent.Parent == info.Nodes[6])
                  {

                      ReadFile.Enabled = true;

                  }
                  else
                  {

                      ReadFile.Enabled = false;

                  }
          }
          if (e.Node.Parent == info.Nodes[1])
          {
              if (ribbonPanel6.Enabled == false)
              {
                  ribbonPanel6.Enabled = true;
                  scanerlist.TextBoxText = scanersetting;
              }
          }
          else
          {  
              scanersetting = scanerlist.TextBoxText;
              scanerlist.TextBoxText = "";
              ribbonPanel6.Enabled = false;
            
          }
          if (e.Node.Parent == info.Nodes[2])
          {
              DeleteScreen.Enabled = true;
              InTrans.Enabled = true;
              ViewTranslation.Enabled = true;
          }
          else
          {
              DeleteScreen.Enabled = false;
              InTrans.Enabled = false;
              ViewTranslation.Enabled = false;

          }
           
            if (e.Node.Parent== info.Nodes[6])
            {

                DeleteDopFile.Enabled = true;

            }
            else
            {

                DeleteDopFile.Enabled = false;

            }
        }

        private void TeacherBox_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (TeacherBox.TextBoxText != "")
            {
                AddTeachertoLesson.Enabled = true;
                RenameTeacherList.Enabled = true;
                InTeacherList.Enabled = true;
                DeleteTeacher.Enabled = true;
            }
            else
            {
                AddTeachertoLesson.Enabled = false;
                RenameTeacherList.Enabled = false;
                InTeacherList.Enabled = false;
                DeleteTeacher.Enabled = false;
            }
        }

        private void ADDGroup_Click(object sender, EventArgs e)
        {
            try
            {
                cgl.Insert((int)group.SelectGroupid(GroupBox.TextBoxText), idlesson);
                UpdateGroup();
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void ribbonTab7_ActiveChanged(object sender, EventArgs e)
        {
            UpdateAGroup();
        }

        private void DeleteGroupinLesson_Click(object sender, EventArgs e)
        {
            try
            {
                if (info.SelectedNode.Parent == info.Nodes[4])
                {
                    cgl.DeleteGrouptoLesson(int.Parse(info.SelectedNode.Name), idlesson);
                    UpdateGroup();
                }
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void inGroupBox_Click(object sender, EventArgs e)
        {
            GroupName.TextBoxText = GroupBox.TextBoxText;
        }

        private void AddGroup_Click_1(object sender, EventArgs e)
        {
            try
            {
                if (GroupName.TextBoxText != "")
                {
                  group.Insert(GroupName.TextBoxText);
                }
                UpdateAGroup();
                UpdateGroup();
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void ReanameGroup_Click(object sender, EventArgs e)
        {
            try
            {
                if (GroupName.TextBoxText != "")
                {
                    group.Update(GroupName.TextBoxText, (int)group.SelectGroupid(GroupBox.TextBoxText));
                }
                UpdateAGroup();
                UpdateGroup();
                GroupBox.TextBoxText = "";
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void DeleteGroup_Click(object sender, EventArgs e)
        {
            try
            {

                group.DeletebyName(GroupBox.TextBoxText);

                UpdateAGroup();
                UpdateGroup();
                GroupBox.TextBoxText = "";
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void Gsetbals_Click(object sender, EventArgs e)
        {
            try
            {
                int Tballsx = int.Parse(Gbalsset.TextBoxText);
                if ((Tballsx >= 0) && (Tballsx <= 100))
                {
                    gb.Insert(idlesson, int.Parse(info.SelectedNode.Name), Tballsx, studentidlogin.ToString());
                    GroupBals.Enabled = false;
                }

            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void GroupBox_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (GroupBox.TextBoxText != "")
            {
                ADDGroupinLesson.Enabled = true;
                ReanameGroup.Enabled = true;
                inGroupBox.Enabled = true;
                DeleteGroup.Enabled = true;
            }
            else
            {
                ADDGroupinLesson.Enabled = false;
                ReanameGroup.Enabled = false;
                inGroupBox.Enabled = false;
                DeleteGroup.Enabled = false;
            }
        }

        private void con_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (con.TextBoxText != "")
            {
                DeleteLesson.Enabled = true;
                EditLesson.Enabled = true;
          
            }
            else
            {
                DeleteLesson.Enabled = false;
                EditLesson.Enabled = false;
            }
        }

        private void StudentSellect_ActiveChanged(object sender, EventArgs e)
        {
            UpdateAGroupasStudent();
            Login.TextBoxText = "";
            Password.TextBoxText = "";
        }

        private void inStudent_Click(object sender, EventArgs e)
        {
            StudentName.TextBoxText=StudentBox.TextBoxText;
        }

        private void SgroupBox_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (SgroupBox.TextBoxText != "")
            {
                AddStudent.Enabled = true;
     
                UpdateAStudent();
                StudentBox.TextBoxText = "";
            }
            else
            {
                AddStudent.Enabled = false;
             
            }
        }

        private void StudentBox_Click(object sender, EventArgs e)
        {
         
        }

        private void StudentBox_TextBoxTextChanged(object sender, EventArgs e)
        {
            if (StudentBox.TextBoxText != "")
            {

                DeleteStudent.Enabled = true;
                RenameStudent.Enabled = true;
                AddPasword.Enabled = true;
                inStudent.Enabled = true;
            }
            else
            {

                DeleteStudent.Enabled = false;
                RenameStudent.Enabled = false;
                AddPasword.Enabled = false;
                inStudent.Enabled = false;
            }
        }

        private void AddStudent_Click(object sender, EventArgs e)
        {
            try
            {
                student.Insert(StudentName.TextBoxText, (int)group.SelectGroupid(SgroupBox.TextBoxText));
                UpdateAStudent();
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void RenameStudent_Click(object sender, EventArgs e)
        {
            try
            {
                student.UpdateStudent(StudentName.TextBoxText, (int)group.SelectGroupid(SgroupBox.TextBoxText),StudentBox.TextBoxText);
                UpdateAStudent();
                StudentBox.TextBoxText = "";
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void DeleteStudent_Click(object sender, EventArgs e)
        {
            try
            {
                student.DeleteStudent((int)group.SelectGroupid(SgroupBox.TextBoxText), StudentBox.TextBoxText);
                UpdateAStudent();
                StudentBox.TextBoxText = "";
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void SbalsActive_Click(object sender, EventArgs e)
        {
            try
            {
                int Tballsx = int.Parse(SbalsSet.TextBoxText);
                if ((Tballsx >= -1) && (Tballsx <= 100))
                {
                    sb.Insert(int.Parse(info.SelectedNode.Name), idlesson, Tballsx, studentidlogin.ToString());
                    StudenBallsSet.Enabled = false;
                }

            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void SQLLogin_Click(object sender, EventArgs e)
        {
            Autch sqlautchform = new Autch();
            
            sqlautchform.ShowDialog();
            if ((sqlautchform.logins != null) && (sqlautchform.logins != "") && (sqlautchform.passwords != null) && (sqlautchform.passwords != ""))
            {
                autchsql = string.Format("User ID={0};Password={1};", sqlautchform.logins, sqlautchform.passwords);
            }
        }

        private void base_sv_Click(object sender, EventArgs e)
        {
         
        }

        private void SysAutch_Click(object sender, EventArgs e)
        {
            autchsql = "Integrated Security=True";
        }

        private void AddPasword_Click(object sender, EventArgs e)
        {
            try
            {
                if (user.TestUserUsed(Login.TextBoxText) == 0)
                {
                    user.Insert((int)student.SelectStudenid(StudentBox.TextBoxText), Login.TextBoxText,GetHashString(Password.TextBoxText));
                }
                else
                {
                    new InfoMassege("Логин уже существуе");

                }
                Login.TextBoxText = "";
                Password.TextBoxText = "";

            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void EditPassword_Click(object sender, EventArgs e)
        {
            try
            {
                if (user.TestUserUsed(Login.TextBoxText) == 0)
                {
                    new InfoMassege("Логин не существуе");
                }
                else
                {
                    user.UpdatePassword( GetHashString(Password.TextBoxText),Login.TextBoxText);

                }
                Login.TextBoxText = "";
                Password.TextBoxText = "";

            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void AuthStudent_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                Autch myautch =new Autch();
                myautch.ShowDialog();
                if ((myautch.logins != null) && (myautch.logins != "") && (myautch.passwords != null) && (myautch.passwords != ""))
                {
                    if (user.TestUserUsed(Login.TextBoxText) == 0)
                    {
                        user.Insert(-1, myautch.logins, GetHashString(myautch.passwords));
                    }
                    else
                    {
                        new InfoMassege("Логин уже существуе");

                    }
                    Login.TextBoxText = "";
                    Password.TextBoxText = "";
                }

            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void ribbonButton2_Click_2(object sender, EventArgs e)
        {
            try
            {
                Comment cm;
                int idfile=(int)fl.SelectFileid(info.SelectedNode.Text, idlesson);
                if ((int)comment.TestComment(idfile) == 0)
                {
                    cm = new Comment();
                    cm.ShowDialog();
                    if (cm.comments != "")
                    {
                        comment.Insert(idfile, cm.comments);
                    }
                }
                else
                {
                    cm = new Comment((string)comment.SelectComment(idfile));
                    cm.ShowDialog();
                    if (cm.comments != "")
                    {
                        comment.Update(cm.comments, idfile);
                    }
                }
              

            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
           
        }

        private void AddDopFile_Click(object sender, EventArgs e)
        {
           try
           {
               int dopidlesson=(int)dbl.ScalarQuery(con.TextBoxText);
               if(idlesson!=dopidlesson)
                   if((int)df.TestDopFile(idlesson,dopidlesson)==0)
                       df.Insert(idlesson, dopidlesson);
               UpdateSubFile();
           }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void DeleteDopFile_Click(object sender, EventArgs e)
        {
            try
            {
                int dopidlesson = (int)dbl.ScalarQuery(info.SelectedNode.Text);
                        df.DeleteDopLesson(idlesson, dopidlesson);
                UpdateSubFile();
            }
            catch (Exception ep)
            {
                new InfoMassege(ep.Message);
            }
        }

        private void info_DoubleClick(object sender, EventArgs e)
        {
            if (info.SelectedNode.Parent == info.Nodes[0])
            {
                ReadFile.PerformClick();
            }
        }
    }
}
