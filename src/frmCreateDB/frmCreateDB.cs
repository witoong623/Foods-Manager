using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace FoodsManager
{
    public partial class frmCreateDB : Form
    {

        // private string FilePath;

        public frmCreateDB()
        {
            InitializeComponent();
        }

        /* private bool CreateDB()
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
                MessageBox.Show(ex.Message + "\n" + ex.StackTrace, "พบข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            /*if (WriteConnectionString())
            {
                Close();
            }
            else
            {
                MessageBox.Show("ไม่สามารถเขียนไฟล์เผื่อเก็บข้อมูลได้", "เกิดข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }*/
        }

        /*private bool WriteConnectionString()
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
        }*/
    }
}
