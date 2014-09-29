using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using FileManage;

public class frmCreateDB : Form
{
    private Label label1;
    private Label label2;
    private Label label3;
    private TextBox txtSqlFilePath;
    private Button button1;
    private Label label4;
    private TextBox txtSqlUsername;
    private TextBox txtSqlPassword;
    private TextBox txtSqlServer;
    private Button btnSubmit;
    private Button btnClose;
    private TextBox txtDatabase;
    private Label label5;

    clsBuildConnectionString build = new clsBuildConnectionString("sqldetail.txt");
    private RadioButton rdbConnectionString;
    private RadioButton rdbBoth;
    private RadioButton rdbDatabase;

    private string FilePath;

    #region windows component
    private void InitializeComponent()
    {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSqlFilePath = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.txtSqlUsername = new System.Windows.Forms.TextBox();
            this.txtSqlPassword = new System.Windows.Forms.TextBox();
            this.txtSqlServer = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rdbConnectionString = new System.Windows.Forms.RadioButton();
            this.rdbBoth = new System.Windows.Forms.RadioButton();
            this.rdbDatabase = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "ไฟล์ .sql";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(39, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "ชื่อผู้ใช้";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Location = new System.Drawing.Point(33, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "รหัสผ่าน";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(12, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "ที่อยู่เซิฟเวอร์";
            // 
            // txtSqlFilePath
            // 
            this.txtSqlFilePath.Location = new System.Drawing.Point(88, 22);
            this.txtSqlFilePath.Name = "txtSqlFilePath";
            this.txtSqlFilePath.ReadOnly = true;
            this.txtSqlFilePath.Size = new System.Drawing.Size(212, 20);
            this.txtSqlFilePath.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Enabled = false;
            this.button1.Location = new System.Drawing.Point(306, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "เลือกไฟล์";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnOpenSqlFile);
            // 
            // txtSqlUsername
            // 
            this.txtSqlUsername.Location = new System.Drawing.Point(88, 57);
            this.txtSqlUsername.Name = "txtSqlUsername";
            this.txtSqlUsername.Size = new System.Drawing.Size(212, 20);
            this.txtSqlUsername.TabIndex = 6;
            // 
            // txtSqlPassword
            // 
            this.txtSqlPassword.Location = new System.Drawing.Point(88, 92);
            this.txtSqlPassword.Name = "txtSqlPassword";
            this.txtSqlPassword.Size = new System.Drawing.Size(212, 20);
            this.txtSqlPassword.TabIndex = 7;
            // 
            // txtSqlServer
            // 
            this.txtSqlServer.Location = new System.Drawing.Point(88, 127);
            this.txtSqlServer.Name = "txtSqlServer";
            this.txtSqlServer.Size = new System.Drawing.Size(212, 20);
            this.txtSqlServer.TabIndex = 8;
            this.txtSqlServer.Text = "localhost";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(88, 216);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 9;
            this.btnSubmit.Text = "ตกลง";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(192, 216);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "ยกเลิก";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(88, 162);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(212, 20);
            this.txtDatabase.TabIndex = 11;
            this.txtDatabase.Text = "food_manager";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(12, 165);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "ชื่อฐานข้อมูล";
            // 
            // rdbConnectionString
            // 
            this.rdbConnectionString.AutoSize = true;
            this.rdbConnectionString.Checked = true;
            this.rdbConnectionString.Location = new System.Drawing.Point(71, 193);
            this.rdbConnectionString.Name = "rdbConnectionString";
            this.rdbConnectionString.Size = new System.Drawing.Size(78, 17);
            this.rdbConnectionString.TabIndex = 13;
            this.rdbConnectionString.TabStop = true;
            this.rdbConnectionString.Text = "เพิ่มชื่อผู้ใช้";
            this.rdbConnectionString.UseVisualStyleBackColor = true;
            // 
            // rdbBoth
            // 
            this.rdbBoth.AutoSize = true;
            this.rdbBoth.Location = new System.Drawing.Point(155, 193);
            this.rdbBoth.Name = "rdbBoth";
            this.rdbBoth.Size = new System.Drawing.Size(92, 17);
            this.rdbBoth.TabIndex = 14;
            this.rdbBoth.Text = "เพิ่มทั้ง 2 อย่าง";
            this.rdbBoth.UseVisualStyleBackColor = true;
            // 
            // rdbDatabase
            // 
            this.rdbDatabase.AutoSize = true;
            this.rdbDatabase.Location = new System.Drawing.Point(253, 193);
            this.rdbDatabase.Name = "rdbDatabase";
            this.rdbDatabase.Size = new System.Drawing.Size(89, 17);
            this.rdbDatabase.TabIndex = 15;
            this.rdbDatabase.Text = "เพิ่มฐานข้อมูล";
            this.rdbDatabase.UseVisualStyleBackColor = true;
            // 
            // frmCreateDB
            // 
            this.ClientSize = new System.Drawing.Size(391, 251);
            this.Controls.Add(this.rdbDatabase);
            this.Controls.Add(this.rdbBoth);
            this.Controls.Add(this.rdbConnectionString);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtSqlServer);
            this.Controls.Add(this.txtSqlPassword);
            this.Controls.Add(this.txtSqlUsername);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSqlFilePath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCreateDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "เชื่อมต่อฐานข้อมูล";
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    #endregion windows component

    public frmCreateDB()
    {
        InitializeComponent();
        txtSqlUsername.Select();
    }

    private bool CreateDB()
    {
        try
        {
            string path;
            string input;

            path = FilePath;
            StreamReader file = new StreamReader(path);
            input = file.ReadToEnd();
            file.Close();

            ProcessStartInfo psi = new ProcessStartInfo();
            psi.FileName = "mysql";
            psi.RedirectStandardInput = true;
            psi.RedirectStandardOutput = false;
            psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}", 
                build.Username, build.Password, build.Server, build.Database);
            psi.UseShellExecute = false;

            Process process = Process.Start(psi);
            process.StandardInput.WriteLine(input);
            process.StandardInput.Close();
            process.WaitForExit();
            process.Close();

            MessageBox.Show("เพิ่มฐานข้อมูลสำเร็จ", "เพิ่มฐานข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message + "\n" + ex.StackTrace , "พบข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return false;
        }
    }

    private void btnOpenSqlFile(object sender, EventArgs e)
    {
        OpenFileDialog openFile = new OpenFileDialog();
        openFile.Title = "เลือกไฟล์ฐานข้อมูล";
        openFile.InitialDirectory = "Desktop";
        openFile.FilterIndex = 2;
        openFile.Filter = "MySql dumpfile|*.sql";

        if (openFile.ShowDialog() == DialogResult.OK)
        {
            txtSqlFilePath.Text = openFile.FileName;
            FilePath = openFile.FileName;
        }
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if ((txtSqlFilePath.Text.Length != 0) && rdbBoth.Checked)
        {
            if (WriteConnectionString() && CreateDB())
            {
                Close();
            }
            else
            {
                return;
            }
        }
        else if (rdbConnectionString.Checked)
        {
            if (WriteConnectionString())
            {
                Close();
            }
            else
            {
                return;
            }
        }
        else
        {
            if (CreateDB())
            {
                Close();
            }
            else
            {
                return;
            }
        }
    }

    private bool WriteConnectionString()
    {
        build.Server = txtSqlServer.Text;
        build.Database = txtDatabase.Text;
        build.Username = txtSqlUsername.Text;
        build.Password = txtSqlPassword.Text;
        build.Charset = "utf8";
        if (build.WriteConnectionStringData())
        {
            MessageBox.Show("เขียนข้อมูลการเชื่อมต่อสำเร็จ", "การทำงานสำเร็จ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
        else
        {
            return false;
        }
    }
}