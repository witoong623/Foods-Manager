using System;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using FileManage;

public class frmCreateDB : Form
{
    private Label label2;
    private Label label3;
    private Label label4;
    private TextBox txtSqlUsername;
    private TextBox txtSqlPassword;
    private TextBox txtSqlServer;
    private Button btnSubmit;
    private Button btnClose;
    private TextBox txtDatabase;
    private Label label5;

    clsBuildConnectionString build = new clsBuildConnectionString("sqldetail.txt");

    private string FilePath;

    #region windows component
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCreateDB));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSqlUsername = new System.Windows.Forms.TextBox();
            this.txtSqlPassword = new System.Windows.Forms.TextBox();
            this.txtSqlServer = new System.Windows.Forms.TextBox();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtDatabase = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label2.Location = new System.Drawing.Point(66, 29);
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
            this.label3.Location = new System.Drawing.Point(60, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "รหัสผ่าน";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Location = new System.Drawing.Point(39, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "ที่อยู่เซิฟเวอร์";
            // 
            // txtSqlUsername
            // 
            this.txtSqlUsername.Location = new System.Drawing.Point(115, 26);
            this.txtSqlUsername.Name = "txtSqlUsername";
            this.txtSqlUsername.Size = new System.Drawing.Size(212, 20);
            this.txtSqlUsername.TabIndex = 1;
            // 
            // txtSqlPassword
            // 
            this.txtSqlPassword.Location = new System.Drawing.Point(115, 61);
            this.txtSqlPassword.Name = "txtSqlPassword";
            this.txtSqlPassword.PasswordChar = '●';
            this.txtSqlPassword.Size = new System.Drawing.Size(212, 20);
            this.txtSqlPassword.TabIndex = 2;
            // 
            // txtSqlServer
            // 
            this.txtSqlServer.Location = new System.Drawing.Point(115, 96);
            this.txtSqlServer.Name = "txtSqlServer";
            this.txtSqlServer.Size = new System.Drawing.Size(212, 20);
            this.txtSqlServer.TabIndex = 3;
            this.txtSqlServer.Text = "localhost";
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(115, 171);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.Text = "ตกลง";
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(219, 171);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "ยกเลิก";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtDatabase
            // 
            this.txtDatabase.Location = new System.Drawing.Point(115, 131);
            this.txtDatabase.Name = "txtDatabase";
            this.txtDatabase.Size = new System.Drawing.Size(212, 20);
            this.txtDatabase.TabIndex = 4;
            this.txtDatabase.Text = "food_manager";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Location = new System.Drawing.Point(39, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "ชื่อฐานข้อมูล";
            // 
            // frmCreateDB
            // 
            this.ClientSize = new System.Drawing.Size(391, 222);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDatabase);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.txtSqlServer);
            this.Controls.Add(this.txtSqlPassword);
            this.Controls.Add(this.txtSqlUsername);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
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
            psi.FileName = "mysql.exe";
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

    /*private void btnOpenSqlFile(object sender, EventArgs e)
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
    }*/

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {
        if (txtSqlServer.Text.Length == 0)
        {
            MessageBox.Show("กรุณากรอกที่อยู่ database server", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (txtDatabase.Text.Length == 0)
        {
            MessageBox.Show("กรุณากรอกชื่อฐานข้อมูล\nหากไม่แน่ใจให้ใช้ค่าเริ่มต้น", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (txtSqlUsername.Text.Length == 0)
        {
            MessageBox.Show("กรุณากรอกชื่อผู้ใช้ของฐานข้อมูล", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (txtSqlPassword.Text.Length == 0)
        {
            MessageBox.Show("กรุณากรอกรหัสผ่านของฐานข้อมูล", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return;
        }

        if (WriteConnectionString())
        {
            Close();
        }
        else
        {
            MessageBox.Show("ไม่สามารถเขียนไฟล์เผื่อเก็บข้อมูลได้", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
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