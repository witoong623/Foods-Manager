using System;
using System.IO;
using System.Windows.Forms;

namespace FileManage
{
    [Serializable]
    class clsBuildConnectionString
    {
        private string FileIO;
        private string server;
        private string database;
        private string username;
        private string password;
        private string charset;
        private string connectionString;

        private StreamReader sr;
        private StreamWriter sw;

        public clsBuildConnectionString(string fileName)
        {
            FileIO = fileName;
        }

        public string ConnectionString
        {
            get
            {
                return connectionString;
            }
        }

        public string Server
        {
            get
            {
                return server;
            }
            set
            {
                server = value;
            }
        }

        public string Database
        {
            get
            {
                return database;
            }
            set
            {
                database = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public string Charset
        {
            get
            {
                return charset;
            }
            set
            {
                charset = value;
            }
        }

        public bool BuildConnectionString()
        {
            try
            {
                if (File.Exists(FileIO))
                {
                    int i;
                    string temp;
                    string[] tempArray = new string[5];
                    sr = new StreamReader(FileIO);

                    for (i = 0; (i < 5) && ((temp = sr.ReadLine()) != null); i++)
                    {
                        tempArray[i] = temp;
                    }

                    sr.Close();

                    if (i != 5)
                    {
                        MessageBox.Show("ข้อมูลในการเชื่อมต่อไม่ครบถ้วย\nกรุณากรอกใหม่ให้ครบถ้วน", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                        return false;
                    }

                    server = tempArray[0];
                    database = tempArray[1];
                    username = tempArray[2];
                    password = tempArray[3];
                    charset = tempArray[4];
                    connectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" +
                                        "UID=" + username + ";" + "PASSWORD=" + password + ";" + "CHARSET=" + charset + ";";

                    return true;
                }
                else
                {
                    MessageBox.Show("ไม่พบไฟล์ " + FileIO + " ภายใน root directory\nกรุณาตรวจสอบชื่อไฟล์ หรือ สร้างไฟล์นี้ก่อน",
                                    "ไม่พบไฟล์", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "พบข้อผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool WriteConnectionStringData()
        {
            try
            {
                sw = new StreamWriter(FileIO);

                sw.WriteLine(server);
                sw.WriteLine(database);
                sw.WriteLine(username);
                sw.WriteLine(password);
                sw.WriteLine(charset);

                sw.Close();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "พบข้อผิดพลาดในการเขียนไฟล์", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}