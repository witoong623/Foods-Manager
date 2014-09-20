using System;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

public class frmCreateDB : Form
{
    private Label label1;
    private Label label2;
    private Label label3;
    private Label label4;

    #region windows component
    private void InitializeComponent()
    {
        this.label1 = new System.Windows.Forms.Label();
        this.label2 = new System.Windows.Forms.Label();
        this.label3 = new System.Windows.Forms.Label();
        this.label4 = new System.Windows.Forms.Label();
        this.SuspendLayout();
        // 
        // label1
        // 
        this.label1.AutoSize = true;
        this.label1.Location = new System.Drawing.Point(36, 34);
        this.label1.Name = "label1";
        this.label1.Size = new System.Drawing.Size(46, 13);
        this.label1.TabIndex = 0;
        this.label1.Text = "ไฟล์ .sql";
        // 
        // label2
        // 
        this.label2.AutoSize = true;
        this.label2.Location = new System.Drawing.Point(42, 68);
        this.label2.Name = "label2";
        this.label2.Size = new System.Drawing.Size(40, 13);
        this.label2.TabIndex = 1;
        this.label2.Text = "ชื่อผู้ใช้";
        // 
        // label3
        // 
        this.label3.AutoSize = true;
        this.label3.Location = new System.Drawing.Point(36, 106);
        this.label3.Name = "label3";
        this.label3.Size = new System.Drawing.Size(46, 13);
        this.label3.TabIndex = 2;
        this.label3.Text = "รหัสผ่าน";
        // 
        // label4
        // 
        this.label4.AutoSize = true;
        this.label4.Location = new System.Drawing.Point(12, 133);
        this.label4.Name = "label4";
        this.label4.Size = new System.Drawing.Size(70, 13);
        this.label4.TabIndex = 3;
        this.label4.Text = "ที่อยู่เซิฟเวอร์";
        // 
        // frmCreateDB
        // 
        this.ClientSize = new System.Drawing.Size(284, 331);
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
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "เลือกไฟล์ฐานข้อมูล";
            openFile.InitialDirectory = "Desktop";
            openFile.FilterIndex = 2;
            openFile.Filter = "MySql dumpfile|*.sql";
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                string path;
                string input;

                path = openFile.FileName;
                StreamReader file = new StreamReader(path);
                input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    
}