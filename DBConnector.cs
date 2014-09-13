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
    private static MySqlConnection connection;
    private static string server;
    private static string database;
    private static string uid;
    private static string password;
    private static string charset;

    public bool ConnectStatus
    {
        get
        {
            if (OpenConnection() == true)
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

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            }
            return true;
        }
        catch(MySqlException ex)
        {
            if (ex.Number == 1062)
            {
                MessageBox.Show(name + "ถูกเพิ่มแล้ว","ข้อมูลซ้ำกัน");
            }
            return false;
        }
        finally
        {
            this.CloseConnection();
        }
        
    }

    /// <summary>
    /// To update ingredient but can't edit name
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
        if (this.OpenConnection() == true)
        {
            //create mysql command
            MySqlCommand cmd = new MySqlCommand();
            //Assign the query using CommandText
            cmd.CommandText = query;
            //Assign the connection using Connection
            cmd.Connection = connection;

            //Execute query
            cmd.ExecuteNonQuery();

            //close connection
            this.CloseConnection();
        }
    }

    /// <summary>
    /// Select all ingredient information from table
    /// </summary>
    /// <returns>Array of List string contain data</returns>
    public List<string>[] SelecteIngredient()
    {
        string query = "SELECT * FROM ingredient";

        //Create a list to store the result
        List<string>[] list = new List<string>[4];
        list[0] = new List<string>();
        list[1] = new List<string>();
        list[2] = new List<string>();
        list[3] = new List<string>();

        //Open connection
        if (this.OpenConnection() == true)
        {
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                list[0].Add(dataReader["type_id"] + "");
                list[1].Add(dataReader["ingredient_name"] + "");
                list[2].Add(dataReader["ingredient_quantity"] + "");
                list[3].Add(dataReader["unit_id"] + "");
            }

            //close Data Reader
            dataReader.Close();

            //close Connection
            this.CloseConnection();

            //return list to be displayed
            return list;
        }
        else
        {
            return list;
        }
    }

    /// <summary>
    /// Load Ingredient information from table by specific type id
    /// </summary>
    /// <param name="typeID">Ingredient type</param>
    /// <returns>Array of List string contain data</returns>
    public List<string>[] SelectIngredient(int typeID)
    {
        string query = "SELECT * FROM ingredient WHERE type_id='" + typeID + "'";

        //Create a list to store the result
        List<string>[] list = new List<string>[4];
        list[0] = new List<string>();
        list[1] = new List<string>();
        list[2] = new List<string>();
        list[3] = new List<string>();

        //Open connection
        if (this.OpenConnection() == true)
        {
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                list[0].Add(dataReader["type_id"] + "");
                list[1].Add(dataReader["ingredient_name"] + "");
                list[2].Add(dataReader["ingredient_quantity"] + "");
                list[3].Add(dataReader["unit_id"] + "");
            }

            //close Data Reader
            dataReader.Close();

            //close Connection
            this.CloseConnection();

            //return list to be displayed
            return list;
        }
        else
        {
            return list;
        }
    }

    /// <summary>
    /// Load Ingredient information from table by specific type id and quantity
    /// </summary>
    /// <param name="typeID">Ingredient type</param>
    /// <param name="quantity">Ingredient quantity</param>
    /// <returns></returns>
    public List<string>[] SelectIngredient(int typeID, int quantity)
    {
        string query = "SELECT * FROM ingredient " +
                        "WHERE type_id='" + typeID + "' AND ingredient_quantity='" + quantity + "'";

        //Create a list to store the result
        List<string>[] list = new List<string>[4];
        list[0] = new List<string>();
        list[1] = new List<string>();
        list[2] = new List<string>();
        list[3] = new List<string>();

        //Open connection
        if (this.OpenConnection() == true)
        {
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();

            //Read the data and store them in the list
            while (dataReader.Read())
            {
                list[0].Add(dataReader["type_id"] + "");
                list[1].Add(dataReader["ingredient_name"] + "");
                list[2].Add(dataReader["ingredient_quantity"] + "");
                list[3].Add(dataReader["unit_id"] + "");
            }

            //close Data Reader
            dataReader.Close();

            //close Connection
            this.CloseConnection();

            //return list to be displayed
            return list;
        }
        else
        {
            return list;
        }
    }

    public string[] SelectSpecifiedIngredient(string name)
    {
        string query = "SELECT type_id,ingredient_name,ingredient_quantity,unit_id " +
                        "FROM ingredient " +
                        "WHERE ingredient_name='" + name + "'";

        //Create a list to store the result
        string[] list = new string[4];

        //Open connection
        if (OpenConnection() == true)
        {
            //Create Command
            MySqlCommand cmd = new MySqlCommand(query, connection);
            //Create a data reader and Execute the command
            MySqlDataReader dataReader = cmd.ExecuteReader();
            //Read from database
            dataReader.Read();
            //assign to list
            list[0] = dataReader.GetString(0);  //type_id
            list[1] = dataReader.GetString(1);  //ingreient_name
            list[2] = dataReader.GetString(2);  //ingredient_quantity
            list[3] = dataReader.GetString(3);  //unit_id
            dataReader.Close();
            this.CloseConnection();
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
        if (this.OpenConnection() == true)
        {
            //Create Mysql Command
            MySqlCommand cmd = new MySqlCommand(query, connection);

            //ExecuteScalar will return one value
            Count = int.Parse(cmd.ExecuteScalar() + "");

            //close Connection
            this.CloseConnection();

            return Count;
        }
        else
        {
            return Count;
        }
    }

    public void Delete(string name)
    {
        try
        {
            string query = "DELETE FROM ingredient WHERE ingredient_name='" + name + "'";

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
                this.CloseConnection();
            }
        }
        catch(MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    /// <summary>
    /// Assign name of ingredient from database to AutoCompleteStringCollection
    /// </summary>
    /// <param name="autoCom">A collection of Autocomplete string</param>
    public void AssignAutoComplete(AutoCompleteStringCollection autoCom)
    {
        try
        {
            string query = "SELECT ingredient_name FROM ingredient";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    autoCom.Add(dataReader.GetString("ingredient_name"));
                }
                dataReader.Close();
                CloseConnection();
            }
            else
            {
                return;
            }
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    public bool SelectSpecifiedRecipe(string name)
    {
        return true;
    }

    public bool InsertRecipe(string name, int type, List<string>[] ingredient)
    {
        try
        {
            string query = "INSERT INTO recipe (recipe_type_id, recipe_name)" +
                            "VALUES (" + type + ", " + name + ")";

            if (OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                cmd.ExecuteNonQuery();
            }
            return true;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
        finally
        {
            CloseConnection();
        }
        
    }
}

