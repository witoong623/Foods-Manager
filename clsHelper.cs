using System;
using System.Windows.Forms;
using System.IO;

namespace FoodsManager
{
    public enum IngredientType { Flavoring = 1, Meat, Vegetable, Fruit };
    public enum IngredientUnit { Fong = 10, Gram, Ton, Hua, Luk, Mud, Greb };
    public enum PreviousTask { Add, Edit };
    /// <summary>
    /// This class use to collect all extension method
    /// </summary>
    static class Convert
    {
        /// <summary>
        /// Convert int unit to string 
        /// </summary>
        /// <param name="unit">The number that indicate unit string</param>
        /// <returns>Unit name in string format</returns>
        public static string ToIngredientUnitString(this int unit)
        {
            switch (unit)
            {
                case 10:
                    return "ฟอง";
                case 11:
                    return "กรัม";
                case 12:
                    return "ต้น";
                case 13:
                    return "หัว";
                case 14:
                    return "ลูก";
                case 15:
                    return "มัด";
                default:
                    return "กลีบ";
            }
        }

        public static string ToRecipeUnitString(this int unit)
        {
            switch (unit)
            {
                case 1:
                    return "จาน";
                case 2:
                    return "ชาม";
                case 3:
                    return "ถ้วย";
                case 4:
                    return "ไม้";
                case 5:
                    return "ถุง";
                default:
                    return "รหัสหน่วยผิดพลาด";
            }
        }
    }
}

namespace FileManage
{
    [Serializable]
    class ConnectionString
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

        public ConnectionString(string fileName)
        {
            FileIO = fileName;
            BuildConnectionString();
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
                    MessageBox.Show("ไม่พบไฟล์ " + FileIO + "ภายใน root directory\nกรุณาตรวจสอบชื่อไฟล์ หรือ สร้างไฟล์นี้ก่อน",
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
    }
}