using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FoodsManager
{
    public partial class frmMain : Form
    {
        private const int INSTOCK = 1;
        private const int OUTOFSTOCK = 0;

        private DBConnector myDB;
        private AdjustmentIngredient RecipeUpdateQuantity;

        public frmMain()
        {
            InitializeComponent();
            DBConnectStatus();
        }

        [STAThread]
        public static void Main()
        {
            frmMain main = new frmMain();
            Application.EnableVisualStyles();
            Application.Run(main);
        }

        #region event handler method

        /// <summary>
        /// ปุ่มเปิดฟอร์มเพิ่มสูตรอาหาร
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddRecipe_Click(object sender, EventArgs e)
        {
            // Pass null to indicate that this is form for add a new item
            frmRecipe myRecipe = new frmRecipe(null);
            myRecipe.ShowDialog();
            if (myRecipe.PreviousTask == Task.Add)
            {
                RecipeUpdateQuantity = new AdjustmentIngredient(myRecipe.CurrentName);
                RecipeUpdateQuantity.UpdateRecipeQuantity();
                RecipeUpdate();
            }
        }

        /// <summary>
        /// ปุ่มเปิดฟอร์มเพิ่มวัตถุดิบ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddMaterial_Click(object sender, EventArgs e)
        {
            // Pass null to indicate that this is form for add a new item
            frmIngredient myIngredient = new frmIngredient(null);
            myIngredient.ShowDialog();
            if (myIngredient.PreviousTask == Task.Add)
            {
                IngredientUpdate();
            }
        }

        /// <summary>
        /// อีเว้นท์เกิดขึ้นเมื่อเราดับเบิลคลิกที่ลิสต์แถวใดแถวหนึ่งในส่วนของสูตรเพื่อเปิดหน้าแก้ไขหรือทำอาหารขึ้นมา
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Recipe_Selected_DoubleClick(object sender, EventArgs e)
        {
            frmRecipe myRecipe;
            if (lstvRecipeCanMake.SelectedItems.Count > 0)
            {
                myRecipe = new frmRecipe(lstvRecipeCanMake.SelectedItems[0].Text);
                myRecipe.ShowDialog();
            }
            else
            {
                myRecipe = new frmRecipe(lstvRecipeCannotMake.SelectedItems[0].Text);
                myRecipe.ShowDialog();
            }

            if (myRecipe.PreviousTask == Task.Delete)
            {
                RecipeUpdate();
            }
            else if (myRecipe.PreviousTask == Task.Edit)
            {
                RecipeUpdateQuantity = new AdjustmentIngredient(myRecipe.CurrentName);
                tssDBconnectStatus.Text = "Database is updating";
                RecipeUpdateQuantity.UpdateRecipeQuantity();
                RecipeUpdate();
                IngredientUpdate();
                tssDBconnectStatus.Text = "Database is updated";
            }
            else if (myRecipe.PreviousTask == Task.Made)
            {
                RecipeUpdateQuantity = new AdjustmentIngredient(myRecipe.CurrentName, myRecipe.CurrentMadeQuantity);
                tssDBconnectStatus.Text = "Database is updating";
                RecipeUpdateQuantity.UpdateManyIngredient();
                RecipeUpdate();
                IngredientUpdate();
                tssDBconnectStatus.Text = "Database is updated";
            }
        }

        /// <summary>
        /// อีเว้นท์เกิดขึ้นเมื่อเราดับเบิลคลิกที่ลิสต์แถวใดแถวหนึ่งในส่วนของวัตถุดิบเพื่อเปิดหน้าแก้ไขหรือเพิ่มวัตถุดิบขึ้นมา
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Meterial_Selected_DoubleClick(object sender, EventArgs e)
        {
            if (lstvMaterialsInStock.SelectedItems.Count > 0)
            {
                frmIngredient myEdit = new frmIngredient(lstvMaterialsInStock.SelectedItems[0].Text);
                myEdit.ShowDialog();

                if (myEdit.PreviousTask == Task.Edit || myEdit.PreviousTask == Task.Delete)
                {
                    IngredientUpdate();
                }
                else if (myEdit.PreviousTask == Task.Increase)
                {
                    RecipeUpdateQuantity = new AdjustmentIngredient();
                    RecipeUpdateQuantity.UpdateOneRalateIngredient(myDB.SelectOneIngredientID(myEdit.CurrentName));
                    IngredientUpdate();
                    RecipeUpdate();
                }
                else
                {
                    return;
                }
            }
            else
            {
                frmIngredient myEdit = new frmIngredient(lstvMaterialsOutOfStock.SelectedItems[0].Text);
                myEdit.ShowDialog();

                if (myEdit.PreviousTask == Task.Edit || myEdit.PreviousTask == Task.Delete)
                {
                    IngredientUpdate();
                }
                else if (myEdit.PreviousTask == Task.Increase)
                {
                    RecipeUpdateQuantity = new AdjustmentIngredient();
                    RecipeUpdateQuantity.UpdateOneRalateIngredient(myDB.SelectOneIngredientID(myEdit.CurrentName));
                    IngredientUpdate();
                    RecipeUpdate();
                }
                else
                {
                    return;
                }
            }
        }

        private void cbInstockIndexChange(object sender, EventArgs s)
        {
            IngredientInStockUpdate();
        }

        private void cbOutOfStockIndexChange(object sender, EventArgs s)
        {
            IngredientOutOfStockUpdate();
        }

        private void cbRecipeCanMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecipeInStockUpdate();
        }

        private void cbRecipeCannotMake_SelectedIndexChanged(object sender, EventArgs e)
        {
            RecipeOutOfStockUpdate();
        }

        private void AboutMenuClick(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        private void RestoreDatabaseClick(object sender, EventArgs e)
        {
            frmCreateDB CreateDatabase = new frmCreateDB();
            CreateDatabase.ShowDialog();
            DBConnectStatus();
        }
        #endregion event handler method

        /// <summary>
        /// ตรวจสอบว่าสามารถเชื่อมต่อกับฐานข้อมูลได้หรือไม่
        /// </summary>
        /// <returns>จริงเมื่อสามารถเชื่อมต่อได้ ไม่จริงเมื่อไม่สามารถเชื่อมต่อได้</returns>
        private bool DBConnectStatus()
        {
            myDB = new DBConnector();
            if (myDB.TestConnection)
            {
                EnableForm();
                cbMaterialsInStock.SelectedIndex = 0;
                cbMaterialsOutOfStock.SelectedIndex = 0;
                cbRecipeCanMake.SelectedIndex = 0;
                cbRecipeCannotMake.SelectedIndex = 0;
                tssDBconnectStatus.Text = "Connected to database";
                stsStatusBar.Refresh();
                return true;
            }
            else
            {
                DisableForm();
                tssDBconnectStatus.Text = "Cannot connect to database";
                stsStatusBar.Refresh();
                return false;
            }
        }

        /// <summary>
        /// ปิดฟอร์มบางส่วนเพื่อไม่ให้ใช้งานได้
        /// </summary>
        private void DisableForm()
        {
            gbFoodsCanMake.Enabled = false;
            gbFoodsCannotMake.Enabled = false;
            gbMaterialsHave.Enabled = false;
            gbMaterialsOut.Enabled = false;
        }

        /// <summary>
        /// เปิดฟอร์มเพื่อให้สามารถใช้งานได้
        /// </summary>
        private void EnableForm()
        {
            gbFoodsCanMake.Enabled = true;
            gbFoodsCannotMake.Enabled = true;
            gbMaterialsHave.Enabled = true;
            gbMaterialsOut.Enabled = true;
        }

        private void IngredientUpdate()
        {
            IngredientInStockUpdate();
            IngredientOutOfStockUpdate();
        }

        /// <summary>
        /// อัพเดทข้อมูลสูตรอาหารและวัตถุดิบ
        /// </summary>
        private void RecipeUpdate()
        {
            RecipeInStockUpdate();
            RecipeOutOfStockUpdate();
        }

        /// <summary>
        /// อัพเดทข้อมูลวัตถุดิบที่มีอยู่
        /// </summary>
        private void IngredientInStockUpdate()
        {
            int i;
            List<string>[] data = new List<string>[4];

            data = myDB.SelectIngredient(cbMaterialsInStock.SelectedIndex, Stock.InStock);
            lstvMaterialsInStock.Items.Clear();

            if (data[0].Count == 0)
            {
                return;
            }


            ListViewItem sub;
            for (i = 0; i < data[0].Count; i++)
            {
                sub = new ListViewItem(data[0][i]);
                sub.SubItems.Add(data[1][i]);
                sub.SubItems.Add(int.Parse(data[2][i]).ToIngredientUnitString());
                lstvMaterialsInStock.Items.Add(sub);
            }
        }

        /// <summary>
        /// อัพเดทข้อมูลวัตถุดิบที่หมด
        /// </summary>
        private void IngredientOutOfStockUpdate()
        {
            int i;
            List<string>[] data = new List<string>[4];

            data = myDB.SelectIngredient(cbMaterialsOutOfStock.SelectedIndex, Stock.OutOfStock);
            lstvMaterialsOutOfStock.Items.Clear();

            if (data[0].Count == 0)
            {
                return;
            }

            ListViewItem sub;
            for (i = 0; i < data[0].Count; i++)
            {
                sub = new ListViewItem(data[0][i]);
                lstvMaterialsOutOfStock.Items.Add(sub);
            }
        }

        /// <summary>
        /// อัพเดทสูตรอาหารที่สามารถทำได้
        /// </summary>
        private void RecipeInStockUpdate()
        {
            int i;
            List<string>[] data = new List<string>[3];
            data = myDB.SelectRecipe(cbRecipeCanMake.SelectedIndex, INSTOCK);
            lstvRecipeCanMake.Items.Clear();
            ListViewItem sub;
            for (i = 0; i < data[0].Count; i++)
            {
                sub = new ListViewItem(data[0][i]);
                sub.SubItems.Add(data[1][i]);
                sub.SubItems.Add(int.Parse(data[2][i]).ToRecipeUnitString());
                lstvRecipeCanMake.Items.Add(sub);
            }

        }

        /// <summary>
        /// อัพเดทสูตรอาหารที่ไม่สามารถทำได้
        /// </summary>
        private void RecipeOutOfStockUpdate()
        {
            int i;
            ListViewItem sub;
            List<string>[] data = new List<string>[3];
            AdjustmentIngredient myUpdate = new AdjustmentIngredient();

            data = myDB.SelectRecipe(cbRecipeCannotMake.SelectedIndex, OUTOFSTOCK);
            lstvRecipeCannotMake.Items.Clear();

            for (i = 0; i < data[0].Count; i++)
            {
                sub = new ListViewItem(data[0][i]);
                sub.SubItems.Add(myUpdate.GetNotEnoughIngredient(data[0][i]));
                lstvRecipeCannotMake.Items.Add(sub);
            }
        }
    }
}
