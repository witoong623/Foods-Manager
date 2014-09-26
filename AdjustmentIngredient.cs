using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class AdjustmentIngredient
{
    private List<string> ListName;
    private DBConnector myDB = new DBConnector();
    private string recipeName;

    /// <summary>
    /// Initializes a new instance of AdjustmentIngredient with recipe's name
    /// </summary>
    /// <param name="name">a name of recipe</param>
    public AdjustmentIngredient(string name)
    {
        recipeName = name;
    }

    /// <summary>
    /// Initializes a new instance of AdjustmentIngredient with list of recipe's name
    /// </summary>
    /// <param name="ListOfName">List of recipe's name</param>
    public AdjustmentIngredient(List<string> ListOfName)
    {
        ListName = ListOfName;
    }

    /// <summary>
    /// Adjust quantity of recipe. This method can Adjust only one recipe per call
    /// </summary>
    /// <param name="recipeName"></param>
    /// <returns>True if sucesses otherwise false</returns>
    public bool UpdateRecipeQuantity()
    {
        int CurrentQuantity;
        List<int>[] IngredientQuantity = myDB.SelectCurrentRequireIngredient(recipeName);

        // The initial value for current quantity to value of the first ingredient
        CurrentQuantity = IngredientQuantity[1][0] / IngredientQuantity[0][0];

        for (var i = 1; i < IngredientQuantity[0].Count; i++)
        {
            int processQuantity = IngredientQuantity[1][i] / IngredientQuantity[0][i];
            if (processQuantity < CurrentQuantity)
            {
                CurrentQuantity = processQuantity;
            }
        }
        if (myDB.UpdateDatabaseRecipeQuantity(recipeName, CurrentQuantity))
        {
            return true;
        }
        else
        {
            MessageBox.Show("Cannot update value in database");
            return false;
        }
    }

    public bool UpdateManyIngredient(string name, int quantity)
    {

    }
}
