using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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
        string ConnectionString;
        ConnectionString = "SERVER=" + server + ";" + "DATABASE=" +
        database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";
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
    /// To insert new ingredient to ingredient table
    /// </summary>
    /// <param name="typeID">Ingredient type</param>
    /// <param name="name">Ingredient name</param>
    /// <param name="initial">Ingredient initial quantity</param>
    /// <param name="unitID">Ingredient unit called</param>
    public void Insert(int typeID, string name, int initial, int unitID)
    {
        string query;

        query = "INSERT INTO ingredient (type_id, ingredient_name," + 
                " ingredient_quantity, unit_id) VALUES('" + typeID + "', '" + 
                name + "', '" + initial + "', '" + unitID + "')";

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
    }

    /// <summary>
    /// To load player data sort be descending of score
    /// </summary>
    /// <returns>Array of string list contain name and money</returns>
    public List<string>[] Select()
    {
        string query = "SELECT * FROM player_score ORDER BY score DESC";

        //Create a list to store the result
        List<string>[] list = new List<string>[2];
        list[0] = new List<string>();
        list[1] = new List<string>();

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
                list[0].Add(dataReader["name"] + "");
                list[1].Add(dataReader["score"] + "");
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
}