﻿using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using FoodsManager;

/// <summary>
/// To Connect and perform task concern to DB
/// </summary>
public class DBConnector
{
    private const int INSTOCK = 1;
    private const int OUTOFSTOCK = 0;

    private static MySqlConnection connection;
    private static string server;
    private static string database;
    private static string uid;
    private static string password;
    private static string charset;

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

    /// <summary>
    /// To Initialize about DB information such as server database id etc.
    /// </summary>
    public DBConnector()
    {
        Initialize();
    }

    public void Initialize()
    {
        server = "localhost";
        database = "food_manager";
        uid = "root";
        password = "root";
        charset = "utf8";
        string ConnectionString;
        ConnectionString = "SERVER=" + server + ";" + "DATABASE=" + database + ";" +
        "UID=" + uid + ";" + "PASSWORD=" + password + ";" + "CHARSET=" + charset + ";";
        connection = new MySqlConnection(ConnectionString);
    }

    /// <summary>
    /// To open connection to DB
    /// It is helper method and use only in this class
    /// </summary>
    /// <returns>true if connection open otherwise false and show exception messange</returns>
    private bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            //When handling errors, you can your application's response based 
            //on the error number.
            //The two most common error numbers when connecting are as follows:
            //0: Cannot connect to server.
            //1045: Invalid user name and/or password.
            switch (ex.Number)
            {
                case 0:
                    MessageBox.Show("Cannot connect to server.  Contact administrator");
                    break;

                case 1045:
                    MessageBox.Show("Invalid username/password, please try again");
                    break;
                default :
                    MessageBox.Show(ex.Message);
                    break;
            }
            return false;
        }
    }

    /// <summary>
    /// To close connection this is helper method use only in this class
    /// </summary>
    /// <returns>True if close otherwise false and show exception message</returns>
    private bool CloseConnection()
    {
        try
        {
            connection.Close();
            return true;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
    }

    /// <summary>
    /// Insert new ingredient to ingredient table
    /// </summary>
    /// <param name="type">Ingredient type</param>
    /// <param name="name">Ingredient name</param>
    /// <param name="initial">Ingredient initial quantity</param>
    /// <param name="unit">Ingredient unit called</param>
    public bool InsertIngredient(int type, string name, int initial, int unit)
    {
        try
        {
            string query;

            query = "INSERT INTO ingredient (type_id, ingredient_name," +
                    " ingredient_quantity, unit_id) VALUES('" + type + "', '" +
                    name + "', '" + initial + "', '" + unit + "')";

            // Open connection
            if (OpenConnection())
            {
                // Create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                // Execute command
                cmd.ExecuteNonQuery();

                // Close connection
                CloseConnection();
            }
            return true;
        }
        catch (MySqlException ex)
        {
            if (ex.Number == 1062)
            {
                MessageBox.Show(name + "ถูกเพิ่มแล้ว", "ข้อมูลซ้ำกัน");
            }
            return false;
        }
    }

    /// <summary>
    /// Insert recipe to database
    /// </summary>
    /// <param name="name">string name of recipe</param>
    /// <param name="type">int type of recipe</param>
    /// <param name="ingredient">List string name of ingredient and quantity to use in string format</param>
    /// <returns>True if sucesses otherwise false</returns>
    public bool InsertRecipe(string name, int type, List<string>[] ingredient, int unitID)
    {
        try
        {
            List<string> ingredient_id = new List<string>();
            int i;
            string recipeID = "1";
            string query = "INSERT INTO recipe (recipe_type_id, recipe_name, recipe_unit_id)" +
                           "VALUES ('" + type + "', '" + name + "', '" + unitID + "')";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                // Insert name of food to recipe table
                cmd.ExecuteNonQuery();

                // Get recipe id after insert
                query = "SELECT recipe_id FROM recipe WHERE recipe_name='" + name + "' LIMIT 1";
                cmd.CommandText = query;
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
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
                    while (dataReader.Read())
                    {
                        ingredient_id.Add(dataReader.GetString("ingredient_id"));
                    }
                    dataReader.Close();
                }

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
            MessageBox.Show(ex.Message + ex.StackTrace);
            return false;
        }
        finally
        {
            CloseConnection();
        }
    }

    public string[] SelectSpecifiedIngredient(string name)
    {
        string query = "SELECT type_id,ingredient_name,ingredient_quantity,unit_id " +
                        "FROM ingredient " +
                        "WHERE ingredient_name='" + name + "'";

        // Create a list to store the result
        string[] list = new string[4];

        // Open connection
        if (OpenConnection())
        {
            // Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            // Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            // Read from database
            dataReader.Read();
            // Assign to list
            // type_id
            // ingreient_name
            // ingredient_quantity
            // unit_id
            list[0] = dataReader.GetString(0);
            list[1] = dataReader.GetString(1);
            list[2] = dataReader.GetString(2);
            list[3] = dataReader.GetString(3);
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
    /// Select Ingredient information from table by specific type id and quantity
    /// </summary>
    /// <param name="typeID">Ingredient type</param>
    /// <param name="quantity">Ingredient quantity</param>
    /// <returns></returns>
    public List<string>[] SelectIngredient(int typeID, int quantity)
    {
        string query;

        if (quantity == INSTOCK)
        {
            if (typeID == 0)
            {
                query = "SELECT ingredient_name, ingredient_quantity, unit_id FROM ingredient WHERE ingredient_quantity > 0";
            }
            else
            {
                query = "SELECT ingredient_name, ingredient_quantity, unit_id FROM ingredient WHERE type_id='" + typeID + "' AND ingredient_quantity > 0";
            }
        }
        else
        {
            if (typeID == 0)
            {
                query = "SELECT ingredient_name, ingredient_quantity, unit_id FROM ingredient WHERE ingredient_quantity = 0";
            }
            else
            {
                query = "SELECT ingredient_name, ingredient_quantity, unit_id FROM ingredient WHERE type_id='" + typeID + "' AND ingredient_quantity = 0";
            }
        }

        // Create a list to store the result
        List<string>[] list = new List<string>[3];
        list[0] = new List<string>();
        list[1] = new List<string>();
        list[2] = new List<string>();

        // Open connection
        if (OpenConnection())
        {
            // Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            // Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            // Read the data and store them in the list
            while (dataReader.Read())
            {
                list[0].Add(dataReader.GetString("ingredient_name"));
                list[1].Add(dataReader.GetString("ingredient_quantity"));
                list[2].Add(dataReader.GetString("unit_id"));
            }

            // Close Data Reader
            dataReader.Close();

            // Close Connection
            CloseConnection();

            // Return list to be displayed
            return list;
        }
        else
        {
            return list;
        }
    }

    /// <summary>
    /// Add ingredient name to AutoCompleteStringCollection that use in recipe form
    /// </summary>
    /// <returns>a AutoCompleteStringCollection that contain name of ingredient</returns>
    public AutoCompleteStringCollection AddIngredientNameToAutoComplete()
    {
        AutoCompleteStringCollection autoCom = new AutoCompleteStringCollection();
        try
        {
            string query = "SELECT ingredient_name FROM ingredient";

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
            MessageBox.Show(ex.Message);
        }
        return autoCom;
    }

    /// <summary>
    /// Add ingredient name to an array of string that is added to ComboBox filter by type id
    /// </summary>
    /// <param name="typeID"></param>
    /// <returns>an array of string that contain name of ingredient</returns>
    public string[] AddIngredientNameToComboBoxCollection(int typeID)
    {
        int i;
        string[] IngredientName;
        string query;
        List<string> list = new List<string>();

        if (typeID == 0)
        {
            query = "SELECT ingredient_name FROM ingredient";
        }
        else
        {
            query = "SELECT ingredient_name FROM ingredient WHERE type_id = '" + typeID + "'";
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

            for (i = 0; i < IngredientName.Length; i++)
            {
                IngredientName[i] = list[i];
            }

            return IngredientName;
        }
        else
        {
            return IngredientName = null;
        }
    }

    /// <summary>
    /// Select ingredient of a recipe filter by name
    /// </summary>
    /// <param name="name">name of recipe</param>
    /// <returns>ingredient of a recipe</returns>
    public List<string>[] SelectIngredientOfRecipe(string name)
    {
        int ID = SelectRecipeID(name);
        string query = "SELECT ingredient_id, (SELECT ingredient_name FROM ingredient WHERE ingredient_id=ri.ingredient_id), quantity " +
                       "FROM recipe_ingredient ri WHERE recipe_id='" + ID + "'";
        List<string>[] list = new List<string>[2];
        list[0] = new List<string>();
        list[1] = new List<string>();

        if (OpenConnection())
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
            {
                list[0].Add(dataReader.GetString(1));
                list[1].Add(dataReader.GetString(2));
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

    public List<string> SelectRecipeDetail(string name)
    {
        int ID = SelectRecipeID(name);
        string query = "SELECT recipe_type_id, quantity, recipe_unit_id FROM recipe WHERE recipe_name='" + name + "'";
        List<string> list = new List<string>();

        if (OpenConnection())
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();

            while (dataReader.Read())
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
    /// Update ingredient but can't edit name
    /// </summary>
    /// <param name="type">Ingredient type</param>
    /// <param name="name">Ingredient name</param>
    /// <param name="initial">Ingredient initial quantity</param>
    /// <param name="unit">Ingredient unit called</param>
    public void Update(int type, string name, int initial, int unit)
    {
        string query = "UPDATE ingredient " +
                        "SET type_id='" + type + "', ingredient_quantity='" + initial + "', unit_id='" + unit + "' " +
                        "WHERE ingredient_name='" + name + "'";
                        

        //Open connection
        if (OpenConnection())
        {
            // Create mysql command
            MySqlCommand cmd = new MySqlCommand();
            // Assign the query using CommandText
            cmd.CommandText = query;
            // Assign the connection using Connection
            cmd.Connection = connection;

            // Execute query
            cmd.ExecuteNonQuery();

            // Close connection
            CloseConnection();
        }
    }

    /// <summary>
    /// Update recipe quantity
    /// </summary>
    /// <param name="quantity">New quantity</param>
    /// <returns>True if sucesses otherwise false</returns>
    public bool UpdateRecipeQuantity(string name, int quantity)
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
            MessageBox.Show(ex.Message + ex.StackTrace);
            return false;
        }
        return false;
    }

    /// <summary>
    /// Select recipe name and quantity without filter anything
    /// </summary>
    /// <returns>List of recipe name and quantity</returns>
    public List<string>[] SelectRecipe(int typeID, int quantity)
    {
        string query;
        if (quantity == INSTOCK)
        {
            if (typeID == 0)
            {
                query = "SELECT recipe_name, quantity, recipe_unit_id FROM recipe WHERE quantity > 0";
            }
            else
            {
                query = "SELECT recipe_name, quantity, recipe_unit_id FROM recipe WHERE quantity > 0 AND recipe_type_id = '" + typeID + "'";
            }
        }
        else
        {
            if (typeID == 0)
            {
                query = "SELECT recipe_name, quantity, recipe_unit_id FROM recipe WHERE quantity = 0";
            }
            else
            {
                query = "SELECT recipe_name, quantity, recipe_unit_id FROM recipe WHERE quantity = 0 AND recipe_type_id = '" + typeID + "'";
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

            while(dataReader.Read())
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
    /// To count number of row in DB
    /// </summary>
    /// <returns>Number of row in DB</returns>
    public int Count()
    {
        string query = "SELECT Count(*) FROM player_score";
        int Count = -1;

        //Open Connection
        if (this.OpenConnection())
        {
            //Create Mysql Command
            MySqlCommand cmd = new MySqlCommand(query, connection);

            //ExecuteScalar will return one value
            Count = int.Parse(cmd.ExecuteScalar() + "");

            //close Connection
            CloseConnection();

            return Count;
        }
        else
        {
            return Count;
        }
    }

    /// <summary>
    /// Delete ingredient from database
    /// </summary>
    /// <param name="name">string name of ingredient</param>
    public void Delete(string name)
    {
        try
        {
            string query = "DELETE FROM ingredient WHERE ingredient_name='" + name + "'";

            if (this.OpenConnection())
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                CloseConnection();
            }
        }
        catch(MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    /// <summary>
    /// Get require and current ingredient quantity
    /// </summary>
    /// <param name="name">name of recipe</param>
    /// <returns>Require and current ingredient quantity</returns>
    public List<int>[] GetIngredientByRecipe(string name)
    {
        List<int>[] RawData = new List<int>[2];
        RawData[0] = new List<int>();
        RawData[1] = new List<int>();
        int recipeID = SelectRecipeID(name);

        string query = "SELECT ingredient_id, quantity, (SELECT ingredient_quantity FROM ingredient WHERE ingredient_id=ri.ingredient_id)" +
        "FROM recipe_ingredient ri WHERE recipe_id='" + recipeID + "'";
        if (OpenConnection())
        {
            MySqlCommand cmd = new MySqlCommand(query, connection);
            MySqlDataReader dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                RawData[0].Add(dataReader.GetInt32(1));
                RawData[1].Add(dataReader.GetInt32(2));
            }
            dataReader.Close();
            CloseConnection();
        }
        return RawData;
    }

    /// <summary>
    /// Select recipe's id only one value
    /// </summary>
    /// <param name="name">recipe id</param>
    /// <returns>recipe_id from recipe table</returns>
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

    /// <summary>
    /// Get current quantity of recipe from recipe table by name
    /// </summary>
    /// <param name="name">name of recipe</param>
    /// <returns></returns>
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

    public bool SelectSpecifiedRecipe(string name)
    {
        return true;
    }
}

