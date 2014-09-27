using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

public class AdjustmentIngredient
{
    private int madeQuantity = 0;
    private string recipeName;
    private List<string> ListName;
    private DBConnector myDB;

    public AdjustmentIngredient()
    {
        myDB = new DBConnector();
    }
    /// <summary>
    /// Initializes a new instance of AdjustmentIngredient with recipe's name
    /// </summary>
    /// <param name="RecipeName">a name of recipe</param>
    public AdjustmentIngredient(string RecipeName) : this()
    {
        recipeName = RecipeName;
    }

    public AdjustmentIngredient(string name, int quantity) : this()
    {
        recipeName = name;
        madeQuantity = quantity;
    }

    public int MadeQuantity
    {
        get
        {
            return madeQuantity;
        }
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
    /// Adjust quantity of recipe
    /// </summary>
    /// <returns>True if sucesses otherwise false</returns>
    public bool UpdateRecipeQuantity()
    {
        int CurrentQuantity;
        List<int>[] IngredientQuantity = myDB.SelectCurrentRequireIngredient(recipeName);

        // The initial value for current quantity to value of the first ingredient
        CurrentQuantity = IngredientQuantity[2][0] / IngredientQuantity[1][0];

        for (var i = 1; i < IngredientQuantity[0].Count; i++)
        {
            int processQuantity = IngredientQuantity[2][i] / IngredientQuantity[1][i];
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

    /// <summary>
    /// Adjust quantity of recipe
    /// </summary>
    /// <param name="ID">ID of recipe</param>
    /// <returns>True if sucesses otherwise false</returns>
    public bool UpdateRecipeQuantity(int ID)
    {
        int CurrentQuantity;
        List<int>[] IngredientQuantity = myDB.SelectCurrentRequireIngredient(ID);

        // The initial value for current quantity to value of the first ingredient
        CurrentQuantity = IngredientQuantity[2][0] / IngredientQuantity[1][0];

        for (var i = 1; i < IngredientQuantity[0].Count; i++)
        {
            int processQuantity = IngredientQuantity[2][i] / IngredientQuantity[1][i];
            if (processQuantity < CurrentQuantity)
            {
                CurrentQuantity = processQuantity;
            }
        }

        if (myDB.UpdateDatabaseRecipeQuantity(ID, CurrentQuantity))
        {
            return true;
        }
        else
        {
            MessageBox.Show("Cannot update value in database");
            return false;
        }
    }

    /// <summary>
    /// Update ingredient quantity that is made
    /// </summary>
    /// <param name="name">name of recipe</param>
    /// <param name="quantity">quantity that is made</param>
    /// <returns>true if sucesses otherwise false</returns>
    public bool UpdateManyIngredient()
    {
        int i;
        List<int>[] IngredientQuantity = myDB.SelectCurrentRequireIngredient(recipeName);
        List<int> ListOfIngredient = IngredientQuantity[0];

        for (i = 0; i < IngredientQuantity[0].Count; i++)
        {
            IngredientQuantity[2][i] -= (IngredientQuantity[1][i] * madeQuantity);
        }

        if (myDB.UpdateManyIngredientQuantity(IngredientQuantity))
        {
            UpdateRelateRecipe(PrepareUpdateRelateRecipe(ListOfIngredient), 0);
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Prepare List of id by qualify relate recipe with ingredient that use in another recipe
    /// </summary>
    /// <param name="ID">List of ingredient ID</param>
    /// <returns></returns>
    private List<int> PrepareUpdateRelateRecipe(List<int> ListOfIngredientID)
    {
        List<int> ListOfRecipe = myDB.QualifyRelateRecipe(ListOfIngredientID);
        List<int> RelateList = ListOfRecipe.Distinct().ToList();
        return RelateList;
    }

    public void UpdateOneRalateIngredient(int IngredientID)
    {
        List<int> RelateList = myDB.QualifyRelateRecipe(IngredientID);
        UpdateRelateRecipe(RelateList, 0);
    }

    /// <summary>
    /// Update ingredient relate to another recipe
    /// </summary>
    /// <param name="ListOfRelateRecipe"></param>
    /// <param name="FirstIndex"></param>
    private void UpdateRelateRecipe(List<int> ListOfRelateRecipe, int FirstIndex)
    {
        if (FirstIndex < ListOfRelateRecipe.Count)
        {
            UpdateRecipeQuantity(ListOfRelateRecipe[FirstIndex]);
            UpdateRelateRecipe(ListOfRelateRecipe, FirstIndex + 1);
        }
    }
}
