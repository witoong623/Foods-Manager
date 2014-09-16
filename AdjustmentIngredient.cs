using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class AdjustmentIngredient
{
    private List<string> ListName;
    private DBConnector myDB;
    private string recipeName;

    /// <summary>
    /// Initializes a new instance of AdjustmentIngredient
    /// </summary>
    public AdjustmentIngredient()
    {
        myDB = new DBConnector();
    }

    /// <summary>
    /// Initializes a new instance of AdjustmentIngredient with recipe's name
    /// </summary>
    /// <param name="name">a name of recipe</param>
    public AdjustmentIngredient(string name) : this()
    {
        recipeName = name;
    }

    /// <summary>
    /// Initializes a new instance of AdjustmentIngredient with list of recipe's name
    /// </summary>
    /// <param name="ListOfName">List of recipe's name</param>
    public AdjustmentIngredient(List<string> ListOfName) : this()
    {
        ListName = ListOfName;
    }

    /// <summary>
    /// Adjust quantity of recipe. This method can Adjust only one recipe per call
    /// </summary>
    /// <param name="name"></param>
    /// <returns>True if sucesses otherwise false</returns>
    public bool UpdateRecipeQuantity(string name)
    {
        int CurrentQuantity = myDB.GetCurrentQuantity(name);
        List<int>[] IngredientQuantity = myDB.GetIngredientByRecipe(name);

        for (var i = 0; i < IngredientQuantity[0].Count; i++)
        {
            int processQuantity = IngredientQuantity[1][i] / IngredientQuantity[0][i];
            if (processQuantity > CurrentQuantity)
            {
                CurrentQuantity = processQuantity;
            }
        }
        if (myDB.UpdateRecipeQuantity(name, CurrentQuantity))
        {
            return true;
        }
        else
        {
            MessageBox.Show("Cannot update value in database");
            return false;
        }
    }
}
