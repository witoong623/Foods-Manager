using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

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
    private TextBox txtSqlHost;
    private Button button2;
    private Button button3;

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
            this.txtSqlHost = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
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
            this.txtSqlFilePath.Size = new System.Drawing.Size(179, 20);
            this.txtSqlFilePath.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(273, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "เลือกไฟล์";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtSqlUsername
            // 
            this.txtSqlUsername.Location = new System.Drawing.Point(88, 57);
            this.txtSqlUsername.Name = "txtSqlUsername";
            this.txtSqlUsername.Size = new System.Drawing.Size(179, 20);
            this.txtSqlUsername.TabIndex = 6;
            // 
            // txtSqlPassword
            // 
            this.txtSqlPassword.Location = new System.Drawing.Point(88, 92);
            this.txtSqlPassword.Name = "txtSqlPassword";
            this.txtSqlPassword.Size = new System.Drawing.Size(179, 20);
            this.txtSqlPassword.TabIndex = 7;
            // 
            // txtSqlHost
            // 
            this.txtSqlHost.Location = new System.Drawing.Point(88, 127);
            this.txtSqlHost.Name = "txtSqlHost";
            this.txtSqlHost.Size = new System.Drawing.Size(179, 20);
            this.txtSqlHost.TabIndex = 8;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(88, 164);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "ตกลง";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(192, 164);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 10;
            this.button3.Text = "ยกเลิก";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // frmCreateDB
            // 
            this.ClientSize = new System.Drawing.Size(360, 209);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtSqlHost);
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
    }

    private void CreateDB()
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
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void button1_Click(object sender, EventArgs e)
    {
        OpenFileDialog openFile = new OpenFileDialog();
        openFile.Title = "เลือกไฟล์ฐานข้อมูล";
        openFile.InitialDirectory = "Desktop";
        openFile.FilterIndex = 2;
        openFile.Filter = "MySql dumpfile|*.sql";

        if (openFile.ShowDialog() == DialogResult.OK)
        {
            txtSqlFilePath.Text = openFile.FileName;
        }
    }
}