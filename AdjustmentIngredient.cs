using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

/// <summary>
/// คลาสสำหรับใช้ปรับจำนวนอาหารที่สามารถทำได้
/// </summary>
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
    /// สร้างคลาสขึ้นมาสำหรับปรับปริมาณของสูตร
    /// </summary>
    /// <param name="RecipeName">ชื่อของสูตร</param>
    public AdjustmentIngredient(string RecipeName) : this()
    {
        recipeName = RecipeName;
    }

    /// <summary>
    /// สร้างคลาสขึ้นมาสำหรับปรับปริมาณของสูตร ร่วมถึงสูตรอื่นๆ ที่ใช้วัตถุดิบร่วมกัน
    /// </summary>
    /// <param name="name"></param>
    /// <param name="quantity"></param>
    public AdjustmentIngredient(string name, int quantity) : this()
    {
        recipeName = name;
        madeQuantity = quantity;
    }

    /// <summary>
    /// สร้างคลาสขึ้นมาสำหรับปรับปริมาณของสูตรที่ถูกส่งมาให้มากกว่า 1 สูตร
    /// </summary>
    /// <param name="ListOfName">List of recipe's name</param>
    public AdjustmentIngredient(List<string> ListOfName)
    {
        ListName = ListOfName;
    }

    public int MadeQuantity
    {
        get
        {
            return madeQuantity;
        }
    }

    /// <summary>
    /// ปรับปริมาณที่ทำได้ของสูตร โดยใช้ชื่อซึ่งเป็น property ของคลาส
    /// </summary>
    /// <returns>จริงเมื่อปรับสำเร็จ ไม่จริงเมื่อปรับไม่สำเร็จ</returns>
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
    /// ปรับปริมาณที่ทำได้ของสูตรตามไอดีของสูตรที่ถูกส่งมา
    /// </summary>
    /// <param name="ID">ไอดีของสูตรที่ต้องการจะปรับ</param>
    /// <returns>จริงเมื่อปรับสำเร็จ ไม่จริงเมื่อปรับไม่สำเร็จ</returns>
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
    /// ปรับปริมาณของวัตถุดิบที่ถูกใช้ในการทำ ใช้ชื่อของสูตรซึ่งเป็น property ของคลาส
    /// </summary>
    /// <returns>จริงเมื่อปรับสำเร็จ ไม่จริงเมื่อปรับไม่สำเร็จ</returns>
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
    /// ถึงไอดีของสูตรที่ใช้วัตถุดิบตามลิสต์ที่ถูกส่งมา
    /// </summary>
    /// <param name="ID">ลิสต์ของไอดีวัตถุดิบ</param>
    /// <returns>ไอดีของสูตรที่จะต้องถูกปรับ</returns>
    private List<int> PrepareUpdateRelateRecipe(List<int> ListOfIngredientID)
    {
        List<int> ListOfRecipe = myDB.QualifyRelateRecipe(ListOfIngredientID);
        List<int> RelateList = ListOfRecipe.Distinct().ToList();
        return RelateList;
    }

    /// <summary>
    /// ใช้สำหรับดึงไอดีของสูตรที่ต้องปรับ ตามไอดีของวัตถุดิบที่ถูกเพิ่ม
    /// </summary>
    /// <param name="IngredientID">ไอดีของวัตถุดิบที่ถูกเพิ่ม</param>
    public void UpdateOneRalateIngredient(int IngredientID)
    {
        List<int> RelateList = myDB.QualifyRelateRecipe(IngredientID);
        UpdateRelateRecipe(RelateList, 0);
    }

    /// <summary>
    /// Recursion method สำหรับปรับปริมาณที่ทำได้ของสูตรตามลิสต์ที่ถูกส่งมาให้
    /// </summary>
    /// <param name="ListOfRelateRecipe">ไอดีของสูตรที่ต้องการจะปรับ</param>
    /// <param name="FirstIndex">Index ตัวแรกของลิสต์ ต้องเริ่มที่ 0 เสมอ</param>
    private void UpdateRelateRecipe(List<int> ListOfRelateRecipe, int FirstIndex)
    {
        if (FirstIndex < ListOfRelateRecipe.Count)
        {
            UpdateRecipeQuantity(ListOfRelateRecipe[FirstIndex]);
            UpdateRelateRecipe(ListOfRelateRecipe, FirstIndex + 1);
        }
    }

    /// <summary>
    /// ดึงวัตถุดิบที่ขาดสำเร็จทำอาหารตามสูตรให้ได้อย่างน้อย 1 หน่วย
    /// </summary>
    /// <param name="RecipeName">ชื่อของสูตร</param>
    /// <returns>ชื่อของวัตถุดิบที่ขาด</returns>
    public string GetNotEnoughIngredient(string RecipeName)
    {
        int processQuantity;
        string NotEnoughIngredient = null;
        List<int>[] IngredientQuantity = myDB.SelectCurrentRequireIngredient(RecipeName);

        for (var i = 0; i < IngredientQuantity[0].Count; i++)
        {
            processQuantity = IngredientQuantity[2][i] - IngredientQuantity[1][i];
            if (processQuantity < 0)
            {
                NotEnoughIngredient += myDB.SelectIngredientName(IngredientQuantity[0][i]);
            }
        }

        return NotEnoughIngredient;
    }
}
