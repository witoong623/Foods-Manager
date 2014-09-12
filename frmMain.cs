using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using FoodsManager;

public class frmMain : Form
{
    private GroupBox gpbFoodsCanMake;
    private GroupBox gpbFoodsCannotMake;
    private GroupBox gpbMaterialsOut;
    private ComboBox cbRecipeCanMake;
    private ListView lstvRecipeCanMake;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    private ListView lstvRecipeCannotMake;
    private ColumnHeader columnHeader4;
    private ColumnHeader columnHeader5;
    private ComboBox cbRecipeCannotMake;
    private ListView lstvMaterialsInStock;
    private ColumnHeader columnHeader6;
    private ColumnHeader columnHeader7;
    private ColumnHeader columnHeader8;
    private ComboBox cbMaterialsInStock;
    private ComboBox cbMaterialsOutOfStock;
    private ListView lstvMaterialsOutOfStock;
    private Button btnAddRecipe;
    private Button btnAddMaterial;
    private GroupBox gpbMaterialsHave;
    private StatusStrip stsStatusBar;
    private ToolStripStatusLabel tssDBconnectStatus;
    private DBConnector myDB = new DBConnector();
    private ColumnHeader columnHeader9;

    private const string ADD = null;

    #region windows component
    private void InitializeComponent()
    {
            this.gpbFoodsCanMake = new System.Windows.Forms.GroupBox();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.lstvRecipeCanMake = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbRecipeCanMake = new System.Windows.Forms.ComboBox();
            this.gpbFoodsCannotMake = new System.Windows.Forms.GroupBox();
            this.lstvRecipeCannotMake = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbRecipeCannotMake = new System.Windows.Forms.ComboBox();
            this.gpbMaterialsHave = new System.Windows.Forms.GroupBox();
            this.btnAddMaterial = new System.Windows.Forms.Button();
            this.lstvMaterialsInStock = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbMaterialsInStock = new System.Windows.Forms.ComboBox();
            this.gpbMaterialsOut = new System.Windows.Forms.GroupBox();
            this.lstvMaterialsOutOfStock = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbMaterialsOutOfStock = new System.Windows.Forms.ComboBox();
            this.stsStatusBar = new System.Windows.Forms.StatusStrip();
            this.tssDBconnectStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.gpbFoodsCanMake.SuspendLayout();
            this.gpbFoodsCannotMake.SuspendLayout();
            this.gpbMaterialsHave.SuspendLayout();
            this.gpbMaterialsOut.SuspendLayout();
            this.stsStatusBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbFoodsCanMake
            // 
            this.gpbFoodsCanMake.Controls.Add(this.btnAddRecipe);
            this.gpbFoodsCanMake.Controls.Add(this.lstvRecipeCanMake);
            this.gpbFoodsCanMake.Controls.Add(this.cbRecipeCanMake);
            this.gpbFoodsCanMake.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbFoodsCanMake.Location = new System.Drawing.Point(12, 12);
            this.gpbFoodsCanMake.Name = "gpbFoodsCanMake";
            this.gpbFoodsCanMake.Size = new System.Drawing.Size(250, 300);
            this.gpbFoodsCanMake.TabIndex = 0;
            this.gpbFoodsCanMake.TabStop = false;
            this.gpbFoodsCanMake.Text = "อาหารที่ทำได้";
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.Location = new System.Drawing.Point(6, 269);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(90, 23);
            this.btnAddRecipe.TabIndex = 6;
            this.btnAddRecipe.Text = "เพิ่มเมนูอาหาร";
            this.btnAddRecipe.UseVisualStyleBackColor = true;
            this.btnAddRecipe.Click += new System.EventHandler(this.btnAddMenu_Click);
            // 
            // lstvRecipeCanMake
            // 
            this.lstvRecipeCanMake.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstvRecipeCanMake.FullRowSelect = true;
            this.lstvRecipeCanMake.GridLines = true;
            this.lstvRecipeCanMake.Location = new System.Drawing.Point(6, 20);
            this.lstvRecipeCanMake.Name = "lstvRecipeCanMake";
            this.lstvRecipeCanMake.Size = new System.Drawing.Size(238, 243);
            this.lstvRecipeCanMake.TabIndex = 4;
            this.lstvRecipeCanMake.UseCompatibleStateImageBehavior = false;
            this.lstvRecipeCanMake.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ชื่ออาหาร";
            this.columnHeader1.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "จำนวน";
            this.columnHeader2.Width = 55;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "หน่วย";
            // 
            // cbRecipeCanMake
            // 
            this.cbRecipeCanMake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRecipeCanMake.FormattingEnabled = true;
            this.cbRecipeCanMake.Location = new System.Drawing.Point(123, 269);
            this.cbRecipeCanMake.Name = "cbRecipeCanMake";
            this.cbRecipeCanMake.Size = new System.Drawing.Size(121, 21);
            this.cbRecipeCanMake.TabIndex = 1;
            // 
            // gpbFoodsCannotMake
            // 
            this.gpbFoodsCannotMake.Controls.Add(this.lstvRecipeCannotMake);
            this.gpbFoodsCannotMake.Controls.Add(this.cbRecipeCannotMake);
            this.gpbFoodsCannotMake.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbFoodsCannotMake.Location = new System.Drawing.Point(280, 12);
            this.gpbFoodsCannotMake.Name = "gpbFoodsCannotMake";
            this.gpbFoodsCannotMake.Size = new System.Drawing.Size(344, 300);
            this.gpbFoodsCannotMake.TabIndex = 1;
            this.gpbFoodsCannotMake.TabStop = false;
            this.gpbFoodsCannotMake.Text = "อาหารที่ทำไม่ได้";
            // 
            // lstvRecipeCannotMake
            // 
            this.lstvRecipeCannotMake.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.lstvRecipeCannotMake.FullRowSelect = true;
            this.lstvRecipeCannotMake.GridLines = true;
            this.lstvRecipeCannotMake.Location = new System.Drawing.Point(6, 20);
            this.lstvRecipeCannotMake.Name = "lstvRecipeCannotMake";
            this.lstvRecipeCannotMake.Size = new System.Drawing.Size(332, 243);
            this.lstvRecipeCannotMake.TabIndex = 5;
            this.lstvRecipeCannotMake.UseCompatibleStateImageBehavior = false;
            this.lstvRecipeCannotMake.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ชื่ออาหาร";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "วัตถุดิบที่ขาด";
            this.columnHeader5.Width = 210;
            // 
            // cbRecipeCannotMake
            // 
            this.cbRecipeCannotMake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRecipeCannotMake.FormattingEnabled = true;
            this.cbRecipeCannotMake.Location = new System.Drawing.Point(217, 269);
            this.cbRecipeCannotMake.Name = "cbRecipeCannotMake";
            this.cbRecipeCannotMake.Size = new System.Drawing.Size(121, 21);
            this.cbRecipeCannotMake.TabIndex = 3;
            // 
            // gpbMaterialsHave
            // 
            this.gpbMaterialsHave.Controls.Add(this.btnAddMaterial);
            this.gpbMaterialsHave.Controls.Add(this.lstvMaterialsInStock);
            this.gpbMaterialsHave.Controls.Add(this.cbMaterialsInStock);
            this.gpbMaterialsHave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbMaterialsHave.Location = new System.Drawing.Point(630, 12);
            this.gpbMaterialsHave.Name = "gpbMaterialsHave";
            this.gpbMaterialsHave.Size = new System.Drawing.Size(250, 300);
            this.gpbMaterialsHave.TabIndex = 2;
            this.gpbMaterialsHave.TabStop = false;
            this.gpbMaterialsHave.Text = "วัตถุดิบที่มี";
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.Location = new System.Drawing.Point(6, 269);
            this.btnAddMaterial.Name = "btnAddMaterial";
            this.btnAddMaterial.Size = new System.Drawing.Size(75, 23);
            this.btnAddMaterial.TabIndex = 7;
            this.btnAddMaterial.Text = "เพิ่มวัตถุดิบ";
            this.btnAddMaterial.UseVisualStyleBackColor = true;
            this.btnAddMaterial.Click += new System.EventHandler(this.btnAddMaterial_Click);
            // 
            // lstvMaterialsInStock
            // 
            this.lstvMaterialsInStock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lstvMaterialsInStock.FullRowSelect = true;
            this.lstvMaterialsInStock.GridLines = true;
            this.lstvMaterialsInStock.Location = new System.Drawing.Point(6, 20);
            this.lstvMaterialsInStock.Name = "lstvMaterialsInStock";
            this.lstvMaterialsInStock.Size = new System.Drawing.Size(238, 243);
            this.lstvMaterialsInStock.TabIndex = 5;
            this.lstvMaterialsInStock.UseCompatibleStateImageBehavior = false;
            this.lstvMaterialsInStock.View = System.Windows.Forms.View.Details;
            this.lstvMaterialsInStock.DoubleClick += new System.EventHandler(this.Meterial_Selected_DoubleClick);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ชื่อวัตถุดิบ";
            this.columnHeader6.Width = 100;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "จำนวน";
            this.columnHeader7.Width = 55;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "หน่วย";
            // 
            // cbMaterialsInStock
            // 
            this.cbMaterialsInStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaterialsInStock.FormattingEnabled = true;
            this.cbMaterialsInStock.Items.AddRange(new object[] {
            "ทั้งหมด",
            "เครื่องปรุง",
            "เนื้อสัตว์",
            "ผัก",
            "ผลไม้"});
            this.cbMaterialsInStock.Location = new System.Drawing.Point(123, 269);
            this.cbMaterialsInStock.Name = "cbMaterialsInStock";
            this.cbMaterialsInStock.Size = new System.Drawing.Size(121, 21);
            this.cbMaterialsInStock.TabIndex = 3;
            this.cbMaterialsInStock.SelectedIndexChanged += new System.EventHandler(this.cbInstockIndexChange);
            // 
            // gpbMaterialsOut
            // 
            this.gpbMaterialsOut.Controls.Add(this.lstvMaterialsOutOfStock);
            this.gpbMaterialsOut.Controls.Add(this.cbMaterialsOutOfStock);
            this.gpbMaterialsOut.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbMaterialsOut.Location = new System.Drawing.Point(901, 12);
            this.gpbMaterialsOut.Name = "gpbMaterialsOut";
            this.gpbMaterialsOut.Size = new System.Drawing.Size(146, 300);
            this.gpbMaterialsOut.TabIndex = 3;
            this.gpbMaterialsOut.TabStop = false;
            this.gpbMaterialsOut.Text = "วัตถุดิบที่หมด";
            // 
            // lstvMaterialsOutOfStock
            // 
            this.lstvMaterialsOutOfStock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9});
            this.lstvMaterialsOutOfStock.FullRowSelect = true;
            this.lstvMaterialsOutOfStock.GridLines = true;
            this.lstvMaterialsOutOfStock.Location = new System.Drawing.Point(6, 20);
            this.lstvMaterialsOutOfStock.Name = "lstvMaterialsOutOfStock";
            this.lstvMaterialsOutOfStock.Size = new System.Drawing.Size(134, 243);
            this.lstvMaterialsOutOfStock.TabIndex = 4;
            this.lstvMaterialsOutOfStock.UseCompatibleStateImageBehavior = false;
            this.lstvMaterialsOutOfStock.View = System.Windows.Forms.View.Details;
            this.lstvMaterialsOutOfStock.DoubleClick += new System.EventHandler(this.Meterial_Selected_DoubleClick);
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "ชื่อวัตถุดิบ";
            this.columnHeader9.Width = 100;
            // 
            // cbMaterialsOutOfStock
            // 
            this.cbMaterialsOutOfStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaterialsOutOfStock.FormattingEnabled = true;
            this.cbMaterialsOutOfStock.Items.AddRange(new object[] {
            "ทั้งหมด",
            "เครื่องปรุง",
            "เนื้อสัตว์",
            "ผัก",
            "ผลไม้"});
            this.cbMaterialsOutOfStock.Location = new System.Drawing.Point(19, 269);
            this.cbMaterialsOutOfStock.Name = "cbMaterialsOutOfStock";
            this.cbMaterialsOutOfStock.Size = new System.Drawing.Size(121, 21);
            this.cbMaterialsOutOfStock.TabIndex = 3;
            this.cbMaterialsOutOfStock.SelectedIndexChanged += new System.EventHandler(this.cbOutOfStockIndexChange);
            // 
            // stsStatusBar
            // 
            this.stsStatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tssDBconnectStatus});
            this.stsStatusBar.Location = new System.Drawing.Point(0, 336);
            this.stsStatusBar.Name = "stsStatusBar";
            this.stsStatusBar.Size = new System.Drawing.Size(1064, 22);
            this.stsStatusBar.TabIndex = 4;
            this.stsStatusBar.Text = "statusStrip1";
            // 
            // tssDBconnectStatus
            // 
            this.tssDBconnectStatus.Name = "tssDBconnectStatus";
            this.tssDBconnectStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(1064, 358);
            this.Controls.Add(this.stsStatusBar);
            this.Controls.Add(this.gpbMaterialsOut);
            this.Controls.Add(this.gpbMaterialsHave);
            this.Controls.Add(this.gpbFoodsCannotMake);
            this.Controls.Add(this.gpbFoodsCanMake);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Food Manager";
            this.gpbFoodsCanMake.ResumeLayout(false);
            this.gpbFoodsCannotMake.ResumeLayout(false);
            this.gpbMaterialsHave.ResumeLayout(false);
            this.gpbMaterialsOut.ResumeLayout(false);
            this.stsStatusBar.ResumeLayout(false);
            this.stsStatusBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    #endregion windows component

    /// <summary>
    /// Construct windows component and check if program ready to use
    /// </summary>
    
    public frmMain()
    {
        InitializeComponent();
        if (DBConnectStatus() == true)
        {
            cbMaterialsInStock.SelectedIndex = 0;
            cbMaterialsOutOfStock.SelectedIndex = 0;
        }
    }

    [STAThread]
    public static void Main()
    {
        frmMain main = new frmMain();
        Application.EnableVisualStyles();
        Application.Run(main);
    }

    private void btnAddMenu_Click(object sender, EventArgs e)
    {
        frmRecipe myRecipe = new frmRecipe(DisplayMode.Addition);
        myRecipe.ShowDialog();
    }

    /// <summary>
    /// Double event on selected list view to edit or delete ingredient
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void Meterial_Selected_DoubleClick(object sender, EventArgs e)
    {
        if (lstvMaterialsInStock.SelectedItems.Count > 0)
        {
            frmIngredient myEdit = new frmIngredient(lstvMaterialsInStock.SelectedItems[0].Text);
            myEdit.ShowDialog();
            InStockUpdate();
        }
        else
        {
            frmIngredient myEdit = new frmIngredient(lstvMaterialsOutOfStock.SelectedItems[0].Text);
            myEdit.ShowDialog();
            OutOfStockUpdate();
        }
    }

    /// <summary>
    /// Click event to add new ingredient
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnAddMaterial_Click(object sender, EventArgs e)
    {
        frmIngredient myIngredient = new frmIngredient(ADD);
        myIngredient.ShowDialog();
        InStockUpdate();
    }

    /// <summary>
    /// Get connection status by call ConnectDB.ConnectStstus and update status bar
    /// </summary>
    /// <returns>True if connected otherwise false</returns>
    private bool DBConnectStatus()
    {
        try
        {
            if (myDB.ConnectStatus == true)
            {
                tssDBconnectStatus.Text = "Connected to database";
                return true;
            }
            else
            {
                tssDBconnectStatus.Text = "Cannot connect to database, please contact to administrator";
                this.Enabled = false;
                return false;
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.Message);
            return false;
        }
        finally
        {
            stsStatusBar.Refresh();
        }
    }

    private void InStockUpdate()
    {
        int i;
        lstvMaterialsInStock.Items.Clear();
        List<string>[] data = new List<string>[4];
        if (cbMaterialsInStock.SelectedIndex == 0)
        {
            data = myDB.IngredientSelect();
        }
        else
        {
            data = myDB.IngredientSelect(cbMaterialsInStock.SelectedIndex);
        }
        ListViewItem sub;
        for (i = 0; i < data[0].Count; i++)
        {
            int quantity = int.Parse(data[2][i]);
            if (quantity != 0)
            {
                sub = new ListViewItem(data[1][i]);
                sub.SubItems.Add(data[2][i]);
                sub.SubItems.Add(int.Parse(data[3][i]).ToUnitString());
                lstvMaterialsInStock.Items.Add(sub);
            }
        }
    }

    private void OutOfStockUpdate()
    {
        int i;
        lstvMaterialsOutOfStock.Items.Clear();
        List<string>[] data = new List<string>[4];
        if (cbMaterialsOutOfStock.SelectedIndex == 0)
        {
            data = myDB.IngredientSelect();
        }
        else
        {
            data = myDB.IngredientSelect(cbMaterialsOutOfStock.SelectedIndex, 0);
        }
        ListViewItem sub;
        for (i = 0; i < data[0].Count; i++)
        {
            int quantity = int.Parse(data[2][i]);
            if (quantity == 0)
            {
                sub = new ListViewItem(data[1][i]);
                lstvMaterialsOutOfStock.Items.Add(sub);
            }
        }
    }

    private void cbInstockIndexChange(object sender, EventArgs s)
    {
        InStockUpdate();
    }

    private void cbOutOfStockIndexChange(object sender, EventArgs s)
    {
        OutOfStockUpdate();
    }
}
