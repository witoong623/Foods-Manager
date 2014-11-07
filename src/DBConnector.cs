﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using FoodsManager.Extension;

namespace FoodsManager
{
    /// <summary>
    /// ใช้สำหรับเชื่อมต่อและทำงานเกี่ยวกับฐานข้อมูล
    /// </summary>
    public class DBConnector
    {
        private const int INSTOCK = 1;
        private const int OUTOFSTOCK = 0;
        private MySqlConnection connection;


        /// <summary>
        /// สร้าง instance ของคลาส DBConnector
        /// </summary>
        public DBConnector()
        {
            Initialize();
        }

        #region helper methods
        /// <summary>
        /// สร้าง instance ของ MySqlConnection เพื่อใช้เชื่อมต่อฐานข้อมูลภายในคลาส
        /// </summary>
        private void Initialize()
        {
            clsBuildConnectionString build = new clsBuildConnectionString("sqldetail.txt");
            if (build.BuildConnectionString())
            {
                connection = new MySqlConnection(build.ConnectionString);
            }
        }

        /// <summary>
        /// ใช้สำหรับเปิดการเชื่อมต่อของ MySqlConnection ถูกเรียกใช้ทุกครั้งเมื่อทำงานในเมธอดใดเมธอดหนึ่งภายในคลาสนี้
        /// และถูกปิดการทำงานทันทีหลังทำงานภายในเมธอดเสร็จ
        /// </summary>
        /// <returns>จริง เมื่อเชื่อมต่อสำเร็จ นอกเหนือจากนั้นไม่จริง</returns>
        private bool OpenConnection()
        {
            try
            {
                connection.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                // When handling errors, you can your application's response based 
                // on the error number.
                // The two most common error numbers when connecting are as follows:
                // 0: Cannot connect to server.
                // 1045: Invalid user name and/or password.
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show(ex.Message, "Error number : " + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;

                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message, "Error number : " + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Information);
                        break;
                }
                return false;
            }
            catch (NullReferenceException)
            {
                return false;
            }
        }

        /// <summary>
        /// ใช้สำหรับปิดการเชื่อมต่อของ MySqlConnection ถูกเรียกใช้ทุกครั้งหลังทำงานภายในเมธอดใดๆ เสร็จ
        /// </summary>
        /// <returns>จริง เมื่อปิดการเชื่อมต่อสำเร็จ นอกเหนือจากนั้นไม่จริง</returns>
        private bool CloseConnection()
        {
            try
            {
                connection.Close();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error : " + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// ดึงค่า recipe id ออกมาหนึ่งค่าที่ตรงกับชื่อ
        /// </summary>
        /// <param name="name">ชื่อสูตรอาหาร</param>
        /// <returns>ค่า recipe_id จากตาราง recipe</returns>
        private int SelectRecipeID(string name)
        {
            int id = 0;
            string query = "SELECT recipe_id, quantity FROM recipe WHERE recipe_name='" + name + "' LIMIT 1";
            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    id = dataReader.GetInt32("recipe_id");
                }
                dataReader.Close();
                CloseConnection();
            }
            return id;
        }

        #endregion helper methods

        // ============= non query task ===============

        public bool TestConnection
        {
            get
            {
                if (OpenConnection())
                {
                    CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        #region ingredient general methods

        /// <summary>
        /// เพิ่มวัตถุดิบเข้าสู่ฐานข้อมูล(ingredient)
        /// </summary>
        /// <param name="type">ประเภทวัตถุดิบ</param>
        /// <param name="name">ชื่อวัตถุดิบ</param>
        /// <param name="initial">ปริมาณของวัตถุดิบ</param>
        /// <param name="unit">หน่วยของวัตถุดิบ</param>
        /// <returns>จริง เมื่อเพิ่มสำเร็จ ไม่จริงเมื่อเพิ่มไม่สำเร็จ</returns>
        public bool InsertIngredient(int type, string name, int initial, int unit)
        {
            try
            {
                string query = "INSERT INTO ingredient (type_id, ingredient_name," +
                        " ingredient_quantity, unit_id) VALUES('" + type + "', '" +
                        name + "', '" + initial + "', '" + unit + "')";

                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1062)
                {
                    MessageBox.Show(name + "ถูกเพิ่มแล้ว", "ข้อมูลซ้ำกัน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "Error number : " + ex.Number,
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// ดึงข้อมูลของวัตถุดิบขึ้นมา 1 อย่างโดยข้อมูลต้องตรงกับชื่อที่ถูกส่งมา
        /// </summary>
        /// <param name="name">ชื่อของวัตถุดิบ</param>
        /// <returns></returns>
        public string[] SelectSpecifiedIngredient(string name)
        {
            string query = "SELECT type_id, ingredient_name, ingredient_quantity, unit_id " +
                           "FROM ingredient " +
                           "WHERE ingredient_name='" + name + "'";

            string[] list = new string[4];

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();

                list[0] = dataReader.GetString("type_id");
                list[1] = dataReader.GetString("ingredient_name");
                list[2] = dataReader.GetString("ingredient_quantity");
                list[3] = dataReader.GetString("unit_id");
                dataReader.Close();
                CloseConnection();
                return list;
            }
            else
            {
                return list;
            }
        }

        /// <summary>
        /// ดึงค่าหน่วยของวัตถุดิบตามชื่อที่ถูกส่งมาให้
        /// </summary>
        /// <param name="name">ชื่อของวัตถุดิบ</param>
        /// <returns>ไอดีหน่วยของวัตถุดิบ</returns>
        public int SelectIngredientUnitID(string name)
        {
            string query = "SELECT unit_id FROM ingredient WHERE ingredient_name='" + name + "' LIMIT 1";
            int id = 0;

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    id = dataReader.GetInt32("unit_id");
                }

                dataReader.Close();
                CloseConnection();
                return id;
            }
            else
            {
                return id;
            }
        }

        /// <summary>
        /// ดึงชื่อและปริมาณที่มีอยู่ของวัตถุดิบ คัดเลือกโดยประเภทและปริมาณ
        /// </summary>
        /// <param name="typeID">ประเภทของวัตถุดิบ</param>
        /// <param name="quantity">ปริมาณของวัตถุดิบ กำหนดได้เฉพาะที่หมดและที่มีอยู่เท่านั้น</param>
        /// <returns>ชื่อของวัตถุดิบพร้อมกับปริมาณที่มีอยู่ ในรูปแบบ List string[] โดยลำดับที่อยู่จะตรงกันเสมอ</returns>
        public List<string>[] SelectIngredient(int typeID, Stock quantity)
        {
            string query;

            if (quantity == Stock.InStock)
            {
                if (typeID == 0)
                {
                    query = "SELECT ingredient_name, ingredient_quantity, unit_id " +
                            "FROM ingredient WHERE ingredient_quantity > 0 ORDER BY ingredient_name";
                }
                else
                {
                    query = "SELECT ingredient_name, ingredient_quantity, unit_id " +
                            "FROM ingredient WHERE type_id='" + typeID + "' AND ingredient_quantity > 0 ORDER BY ingredient_name";
                }
            }
            else
            {
                if (typeID == 0)
                {
                    query = "SELECT ingredient_name, ingredient_quantity, unit_id " +
                            "FROM ingredient WHERE ingredient_quantity = 0 ORDER BY ingredient_name";
                }
                else
                {
                    query = "SELECT ingredient_name, ingredient_quantity, unit_id " +
                            "FROM ingredient WHERE type_id='" + typeID + "' AND ingredient_quantity = 0 ORDER BY ingredient_name";
                }
            }

            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list[0].Add(dataReader.GetString("ingredient_name"));
                    list[1].Add(dataReader.GetString("ingredient_quantity"));
                    list[2].Add(dataReader.GetString("unit_id"));
                }

                dataReader.Close();
                CloseConnection();

                return list;
            }
            else
            {
                return list;
            }
        }

        /// <summary>
        /// เพื่อชื่อวัตถุดิบทั้งหมดเข้าสํ่ AutoCompleteStringCollection เพื่อใช้ในการเพิ่มสูตรอาหาร
        /// </summary>
        /// <returns>AutoCompleteStringCollection</returns>
        public AutoCompleteStringCollection AddIngredientNameToAutoComplete()
        {
            AutoCompleteStringCollection autoCom = new AutoCompleteStringCollection();
            try
            {
                string query = "SELECT ingredient_name FROM ingredient ORDER BY ingredient_name";

                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        autoCom.Add(dataReader.GetString("ingredient_name"));
                    }

                    dataReader.Close();
                    CloseConnection();
                    return autoCom;
                }
                else
                {
                    return autoCom;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "Error number : " + ex.Number,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return autoCom;
            }
        }

        /// <summary>
        /// เพิ่มชื่อวัตถุดิบเข้าสู่ string[] เพื่อใช้ในการคัดเลือกชื่อวัตถุดิบที่จะถูกแสดงใน ComboBox
        /// </summary>
        /// <param name="typeID">ประเภทของวัตถุดิบ</param>
        /// <returns>string[] ที่บรรจุชื่อของวัตถุดิบตามประเภทที่กำหนด</returns>
        public string[] AddIngredientNameToComboBoxCollection(int typeID)
        {
            string query;
            string[] IngredientName;
            List<string> list = new List<string>();

            if (typeID == 0)
            {
                query = "SELECT ingredient_name FROM ingredient ORDER BY ingredient_name";
            }
            else
            {
                query = "SELECT ingredient_name FROM ingredient WHERE type_id = '" + typeID + "' ORDER BY ingredient_name";
            }

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list.Add(dataReader.GetString("ingredient_name"));
                }

                dataReader.Close();
                CloseConnection();
                IngredientName = new string[list.Count];
                list.CopyTo(IngredientName);

                return IngredientName;
            }
            else
            {
                return IngredientName = null;
            }
        }

        /// <summary>
        /// ดึง ingredient_id จาก ingredient เพื่อส่งต่อไปปรับปริมาณที่กระทบกับกับเพิ่มของวัตถุดิบ
        /// </summary>
        /// <param name="name">ชื่อของวัตถุดิบ</param>
        /// <returns>ไอดีของวัตถุดิบ</returns>
        public int SelectOneIngredientID(string name)
        {
            int ID = 0;
            string query = "SELECT ingredient_id FROM ingredient WHERE ingredient_name='" + name + "' LIMIT 1";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    ID = dataReader.GetInt32("ingredient_id");
                }

                dataReader.Close();
                CloseConnection();
                return ID;
            }
            return ID;
        }

        /// <summary>
        /// ดึงชื่อของวัตถุดิบ คัดเลือดโดยไอดีของวัตถุดิบ เพื่อใช้แสดงในส่่วนของวัตถุดิบที่ขาด
        /// </summary>
        /// <param name="ID">ไอดีของวัตถุดิบ</param>
        /// <returns>ชื่อของวัตถุดิบ</returns>
        public string SelectIngredientName(int ID)
        {
            string IngredientName = "";
            string query = "SELECT ingredient_name FROM ingredient WHERE ingredient_id='" + ID + "' LIMIT 1";

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    IngredientName = dataReader.GetString("ingredient_name");
                }

                dataReader.Close();
                CloseConnection();
            }
            return IngredientName;
        }

        /// <summary>
        /// วัตถุดิบ แต่ไม่สามารถแก้ไขชื่อได้
        /// </summary>
        /// <param name="type">ประเภทวัตถุดิบ</param>
        /// <param name="name">ชื่อวัตถุดิบ</param>
        /// <param name="initial">ปริมาณของวัตถุดิบ</param>
        /// <param name="unit">หน่วยของวัตถุดิบ</param>
        public bool UpdateIngredient(int type, string name, int initial, int unit)
        {
            try
            {
                string query = "UPDATE ingredient " +
                            "SET type_id='" + type + "', ingredient_quantity='" + initial + "', unit_id='" + unit + "' " +
                            "WHERE ingredient_name='" + name + "'";

                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    CloseConnection();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "Error number : " + ex.Number,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
        }

        /// <summary>
        /// ลบวัตถุดิบออกจากฐานข้อมูล แต่จะไม่สามารถลบได้จนกว่าจะไม่มีสูตรที่ใช้วัตถุดิบนี้
        /// </summary>
        /// <param name="name">ชื่อวัตถุดิบ</param>
        public bool DeleteIngredient(string name)
        {
            try
            {
                string query = "DELETE FROM ingredient WHERE ingredient_name='" + name + "'";

                if (this.OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                if (ex.Number == 1451)
                {
                    MessageBox.Show("กรุณาลบสูตรที่ใช้วัตถุดิบนี้ออกให้หมดก่อน", "ไม่สามารถลบวัตถุดิบนี้ได้",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "Error number : ",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            finally
            {
                CloseConnection();
            }
        }

        #endregion ingredient general methods

        /// <summary>
        /// เพิ่มสูตรลงสู่ฐานข้อมูล
        /// </summary>
        /// <param name="name">ชื่อสูตร</param>
        /// <param name="type">ประเภทสูตร</param>
        /// <param name="ingredient">รายชื่อวัตถุดิบและปริมาณที่ใช้สำหรับสูตรนี้</param>
        /// <returns>จริงถ้าเพิ่มสำเร็จ ไม่จริงถ้าเพิ่มไม่สำเร็จ</returns>
        public bool InsertRecipe(string name, int type, List<string>[] ingredient, int unitID)
        {
            try
            {
                int i;
                string recipeID = "0";
                string query = "SELECT recipe_id FROM recipe WHERE recipe_name='" + name + "' LIMIT 1";
                List<string> ingredient_id = new List<string>();

                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        recipeID = dataReader.GetString("recipe_id");
                    }

                    dataReader.Close();

                    if (!recipeID.Equals("0"))
                    {
                        MessageBox.Show("มีสูตร" + name + "อยู่ในฐานข้อมูลแล้ว", "ไม่สามารถเพิ่มสูตรใหม่ได้", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }

                    // Get ingredient id specify by name
                    for (i = 0; i < ingredient[0].Count; i++)
                    {
                        query = "SELECT ingredient_id FROM ingredient WHERE ingredient_name='" + ingredient[0][i] + "' LIMIT 1";
                        cmd.CommandText = query;
                        dataReader = cmd.ExecuteReader();

                        if (dataReader.Read())
                        {
                            ingredient_id.Add(dataReader.GetString("ingredient_id"));
                        }

                        dataReader.Close();
                    }

                    // Insert name of food to recipe table
                    query = "INSERT INTO recipe (recipe_type_id, recipe_name, recipe_unit_id)" +
                               "VALUES ('" + type + "', '" + name + "', '" + unitID + "')";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    // Get recipe id after insert
                    query = "SELECT recipe_id FROM recipe WHERE recipe_name='" + name + "' LIMIT 1";
                    cmd.CommandText = query;
                    dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        recipeID = dataReader.GetString("recipe_id");
                    }

                    dataReader.Close();

                    // Insert ingredient of recipe to 3rd relation table(recipe_ingredient)
                    for (i = 0; i < ingredient[0].Count; i++)
                    {
                        query = "INSERT INTO recipe_ingredient (recipe_id, ingredient_id, quantity)" +
                                "VALUES('" + recipeID + "', '" + ingredient_id[i] + "', '" + ingredient[1][i] + "')";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                    }
                }

                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "Error number : " + ex.Number,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// ดึงชื่อและปริมาณของวัตถุดิบที่สูตรใช้
        /// </summary>
        /// <param name="name">ชื่อของสูตร</param>
        /// <returns>ชื่อและปริมาณของวัตถุดิบที่ใช้</returns>
        public List<string>[] SelectIngredientOfRecipe(string name)
        {
            int ID = SelectRecipeID(name);
            string query = "SELECT ingredient_id, (SELECT ingredient_name FROM ingredient WHERE ingredient_id=ri.ingredient_id), " +
                           "quantity, (SELECT unit_id FROM ingredient WHERE ingredient_id=ri.ingredient_id) " +
                           "FROM recipe_ingredient ri WHERE recipe_id='" + ID + "'";
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list[0].Add(dataReader.GetString(1));
                    list[1].Add(dataReader.GetString(2));
                    list[2].Add(dataReader.GetString(3));
                }

                dataReader.Close();
                CloseConnection();
                return list;
            }
            else
            {
                return list;
            }
        }

        /// <summary>
        /// ดึงรายละเอียดของสูตรร่วมถึงปริมาณที่ทำได้ขณะนั้นด้วย
        /// </summary>
        /// <param name="name">ชื่อสูตร</param>
        /// <returns>ประเภทของสูตร, ปริมาณที่ทำได้และหน่วยของสูตร</returns>
        public List<string> SelectRecipeDetail(string name)
        {
            int ID = SelectRecipeID(name);
            string query = "SELECT recipe_type_id, quantity, recipe_unit_id FROM recipe WHERE recipe_name='" + name + "'";
            List<string> list = new List<string>();

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                if (dataReader.Read())
                {
                    list.Add(dataReader.GetString("recipe_type_id"));
                    list.Add(dataReader.GetString("quantity"));
                    list.Add(dataReader.GetString("recipe_unit_id"));
                }

                dataReader.Close();
                CloseConnection();
                return list;
            }
            else
            {
                return list;
            }
        }

        /// <summary>
        /// ดึงไอดีของสูตรทั้งหมดที่ใช้วัตถุดิบตามที่ถูกส่งมาให้
        /// </summary>
        /// <param name="IngredientID">ลิสต์ของไอดีวัตถุดิบ</param>
        /// <returns>ลิสต์ไอดีของสูตร</returns>
        public List<int> QualifyRelateRecipe(List<int> IngredientID)
        {
            List<int> List = new List<int>();
            try
            {
                int i;
                string query;

                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;

                    for (i = 0; i < IngredientID.Count; i++)
                    {
                        query = "SELECT recipe_id FROM recipe_ingredient WHERE ingredient_id='" + IngredientID[i] + "'";
                        cmd.CommandText = query;
                        MySqlDataReader dataReader = cmd.ExecuteReader();

                        while (dataReader.Read())
                        {
                            List.Add(dataReader.GetInt32("recipe_id"));
                        }

                        dataReader.Close();
                    }

                    CloseConnection();
                    return List;
                }
                else
                {
                    return List;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Error number : " + ex.Number, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return List;
            }
        }

        /// <summary>
        /// ดึงไอดีของสูตรทั้งหมดที่ใช้วัตถุดิบตามที่ถูกส่งมาให้
        /// </summary>
        /// <param name="ID">ไอดีของวัตถุดิบเป็นไอดีเดียวเท่านั้น</param>
        /// <returns>ลิสต์ไอดีของสูตร</returns>
        public List<int> QualifyRelateRecipe(int ID)
        {
            List<int> List = new List<int>();
            try
            {
                string query = "SELECT recipe_id FROM recipe_ingredient WHERE ingredient_id='" + ID + "'";

                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    while (dataReader.Read())
                    {
                        List.Add(dataReader.GetInt32("recipe_id"));
                    }

                    dataReader.Close();

                    CloseConnection();
                    return List;
                }
                else
                {
                    return List;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message);
                return List;
            }
        }

        /// <summary>
        /// แก้ไขวัตถุดิบของสูตรที่ถูกใช้ทั้งหมด โดยการลบวัตถุดิบทั้งหมดที่ใช้ออกก่อน หลังจากนั้นทำการเพิ่มวัตถุดิบและปริมาณที่ใช้ลงไปใหม่ทั้งหมด
        /// </summary>
        /// <param name="name">ชื่อของสูตร</param>
        /// <param name="ingredient">ลิสของชื่อวัตถุดิบและปริมาณที่ใช้</param>
        /// <returns>จริงเมื่อแก้ไขสำเร็จ ไม่จริงเมื่อแก้ไขไม่สำเร็จ</returns>
        public bool EditIngredientOfRecipe(string name, List<string>[] ingredient)
        {
            try
            {
                int i;
                string recipeID = "1";
                string query = "SELECT recipe_id FROM recipe WHERE recipe_name='" + name + "' LIMIT 1";
                List<string> ingredient_id = new List<string>();

                if (OpenConnection())
                {
                    // Get recipe id after insert
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    if (dataReader.Read())
                    {
                        recipeID = dataReader.GetString("recipe_id");
                    }

                    dataReader.Close();

                    // Get ingredient id specify by name
                    for (i = 0; i < ingredient[0].Count; i++)
                    {
                        query = "SELECT ingredient_id FROM ingredient WHERE ingredient_name='" + ingredient[0][i] + "' LIMIT 1";
                        cmd.CommandText = query;
                        dataReader = cmd.ExecuteReader();

                        if (dataReader.Read())
                        {
                            ingredient_id.Add(dataReader.GetString("ingredient_id"));
                        }

                        dataReader.Close();
                    }

                    // Delete all ingredient from recipe_ingredient(3rd relationship)
                    query = "DELETE FROM recipe_ingredient WHERE recipe_id='" + recipeID + "'";
                    cmd.CommandText = query;
                    cmd.ExecuteNonQuery();

                    // Insert ingredient of recipe to 3rd relation table(recipe_ingredient)
                    for (i = 0; i < ingredient[0].Count; i++)
                    {
                        query = "INSERT INTO recipe_ingredient (recipe_id, ingredient_id, quantity)" +
                                "VALUES('" + recipeID + "', '" + ingredient_id[i] + "', '" + ingredient[1][i] + "')";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + ex.StackTrace, "Error number : " + ex.Number.ToString());
                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// ดึงชื่อของสูตรและปริมาณที่สามารถทำได้ คัดเลือดโดยประเภทและปริมาณที่สามารถทำได้
        /// </summary>
        /// <param name="typeID">ประเภทของสูตร</param>
        /// <param name="quantity">ปริมาณที่ทำได้ของสูตร สามารถกำหนดได้แค่ ทำได้หรือไม่ได้เท่านั้น</param>
        /// <returns>ลิสต์ของชื่อและปริมาณของสูตร</returns>
        public List<string>[] SelectRecipe(int typeID, int quantity)
        {
            string query;
            if (quantity == INSTOCK)
            {
                if (typeID == 0)
                {
                    query = "SELECT recipe_name, quantity, recipe_unit_id FROM recipe WHERE quantity > 0 ORDER BY recipe_name";
                }
                else
                {
                    query = "SELECT recipe_name, quantity, recipe_unit_id FROM recipe WHERE quantity > 0 AND recipe_type_id = '" + typeID + "' ORDER BY recipe_name";
                }
            }
            else
            {
                if (typeID == 0)
                {
                    query = "SELECT recipe_name, quantity, recipe_unit_id FROM recipe WHERE quantity = 0 ORDER BY recipe_name";
                }
                else
                {
                    query = "SELECT recipe_name, quantity, recipe_unit_id FROM recipe WHERE quantity = 0 AND recipe_type_id = '" + typeID + "' ORDER BY recipe_name";
                }
            }

            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    list[0].Add(dataReader.GetString("recipe_name"));
                    list[1].Add(dataReader.GetString("quantity"));
                    list[2].Add(dataReader.GetString("recipe_unit_id"));
                }
                dataReader.Close();
                CloseConnection();
                return list;
            }
            else
            {
                return list;
            }
        }

        /// <summary>
        /// ดึงปริมาณที่ใช้และปริมาณที่มีอยู่ของวัตถุดิบที่สูตรใช้
        /// </summary>
        /// <param name="name">ชื่อของสูตร</param>
        /// <returns>index 0 = ingredient_id, 1 = require, 2 = current</returns>
        public List<int>[] SelectCurrentRequireIngredient(string name)
        {
            List<int>[] RawData = new List<int>[3];
            RawData[0] = new List<int>();
            RawData[1] = new List<int>();
            RawData[2] = new List<int>();
            int recipeID = SelectRecipeID(name);

            string query = "SELECT ingredient_id, quantity, (SELECT ingredient_quantity FROM ingredient WHERE ingredient_id=ri.ingredient_id)" +
            "FROM recipe_ingredient ri WHERE recipe_id='" + recipeID + "'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    RawData[0].Add(dataReader.GetInt32(0));
                    RawData[1].Add(dataReader.GetInt32(1));
                    RawData[2].Add(dataReader.GetInt32(2));
                }
                dataReader.Close();
                CloseConnection();
            }
            return RawData;
        }

        /// <summary>
        /// ดึงปริมาณที่ใช้และปริมาณที่มีอยู่ของวัตถุดิบที่สูตรใช้
        /// </summary>
        /// <param name="ID">ไอดีของสูตร</param>
        /// <returns>index 0 = ingredient_id, 1 = require, 2 = current</returns>
        public List<int>[] SelectCurrentRequireIngredient(int ID)
        {
            List<int>[] RawData = new List<int>[3];
            RawData[0] = new List<int>();
            RawData[1] = new List<int>();
            RawData[2] = new List<int>();

            string query = "SELECT ingredient_id, quantity, (SELECT ingredient_quantity FROM ingredient WHERE ingredient_id=ri.ingredient_id)" +
            "FROM recipe_ingredient ri WHERE recipe_id='" + ID + "'";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    RawData[0].Add(dataReader.GetInt32(0));
                    RawData[1].Add(dataReader.GetInt32(1));
                    RawData[2].Add(dataReader.GetInt32(2));
                }
                dataReader.Close();
                CloseConnection();
            }
            return RawData;
        }

        /// <summary>
        /// ดึงค่าปริมาณที่ทำได้ของสูตร คัดเลือดโดยชื่อ
        /// </summary>
        /// <param name="name">ชื่อของสูตร</param>
        /// <returns>ปริมาณที่ทำได้ของสูตร</returns>
        public int GetCurrentQuantity(string name)
        {
            int quantity = 0;
            string query = "SELECT quantity FROM recipe WHERE recipe_name='" + name + "' LIMIT 1";
            if (OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    quantity = dataReader.GetInt32("quantity");
                }
                CloseConnection();
            }
            return quantity;
        }

        public bool UpdateRecipeDetail(string name, int TypeId, int UnitID)
        {
            try
            {
                string query = "UPDATE recipe SET recipe_type_id='" + TypeId + "', recipe_unit_id='" + UnitID + "'" +
                           " WHERE recipe_name='" + name + "'";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "Error number : " + ex.Number,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }
            finally
            {
                CloseConnection();
            }
        }

        /// <summary>
        /// อัพเดทค่าปริมาณที่ทำได้ของสูตร
        /// </summary>
        /// <param name="name">ชื่อของสูตร</param>
        /// <param name="quantity">ปริมาณที่ทำได้</param>
        /// <returns>จริงเมื่ออัพเดทสำเร็จ ไม่จริงเมื่อแก้ไขไม่สำเร็จ</returns>
        public bool UpdateDatabaseRecipeQuantity(string name, int quantity)
        {
            try
            {
                string query = "UPDATE recipe SET quantity='" + quantity + "' WHERE recipe_name='" + name + "'";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();
                    return true;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "Error number : " + ex.Number,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }
            return false;
        }

        /// <summary>
        /// อัพเดทค่าปริมาณที่ทำได้ของสูตร
        /// </summary>
        /// <param name="ID">ไอดีของสูตร</param>
        /// <param name="quantity">ปริมาณของสูตร</param>
        /// <returns>จริงเมื่ออัพเดทสำเร็จ ไม่จริงเมื่ออัพเดทไม่สำเร็จ</returns>
        public bool UpdateDatabaseRecipeQuantity(int ID, int quantity)
        {
            try
            {
                string query = "UPDATE recipe SET quantity='" + quantity + "' WHERE recipe_id='" + ID + "'";
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();

                    return true;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "Error number : " + ex.Number,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }
            return false;
        }

        /// <summary>
        /// อัพเดทปริมาณของวัตถุดิบที่มีอยู่ตามลิสต์ของไอดีที่ถูกส่งมา
        /// </summary>
        /// <param name="IngredientList">ปริมาณและไอดีของวัตถุดิบที่จะอัพเดท</param>
        /// <returns>จริงเมื่ออัพเดทสำเร็จ ไม่จริงเมื่ออัพเดทไม่สำเร็จ</returns>
        public bool UpdateManyIngredientQuantity(List<int>[] IngredientList)
        {
            int i;
            string query;
            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = connection;
                    for (i = 0; i < IngredientList[0].Count; i++)
                    {
                        query = "UPDATE ingredient SET ingredient_quantity='" + IngredientList[2][i] +
                                "' WHERE ingredient_id='" + IngredientList[0][i] + "'";
                        cmd.CommandText = query;
                        cmd.ExecuteNonQuery();
                    }
                    CloseConnection();

                    return true;
                }
                return false;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "Error number : " + ex.Number,
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                return false;
            }
        }

        /// <summary>
        /// ลบสูตรอาหารตามชื่อที่ถูกส่งมา
        /// </summary>
        /// <param name="name">ชื่อของสูตร</param>
        /// <returns>จริงเมื่อลบสำเร็จ ไม่จริงเมื่อลบไม่สำเร็จ</returns>
        public bool DeleteRecipe(string name)
        {
            try
            {
                string query = "DELETE FROM recipe WHERE recipe_name='" + name + "'";

                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    cmd.ExecuteNonQuery();
                    CloseConnection();

                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message + Environment.NewLine + ex.StackTrace, "พบข้อผิดพลาดในการลบ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

                return false;
            }
        }
    }
}


