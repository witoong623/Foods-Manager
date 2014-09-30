using System;
using System.Windows.Forms;
using System.Threading;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using FoodsManagerExtension;

public class frmMain : Form
{
    private const int INSTOCK = 1;
    private const int OUTOFSTOCK = 0;
    private const int ADD = 1;
    private const int EDIT = 2;
    private const int DELETE = 3;
    private const int MADE = 4;

    private GroupBox gbFoodsCanMake;
    private GroupBox gbFoodsCannotMake;
    private GroupBox gbMaterialsOut;
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
    private GroupBox gbMaterialsHave;
    private StatusStrip stsStatusBar;
    private ToolStripStatusLabel tssDBconnectStatus;
    private ColumnHeader columnHeader9;
    private MenuStrip menuStrip1;
    private ToolStripMenuItem mnMenu;
    private ToolStripMenuItem smnSelectOrCreateDB;
    private ToolStripMenuItem mnHelp;
    private ToolStripMenuItem smnAbout;

    private DBConnector myDB;
    private AdjustmentIngredient RecipeUpdateQuantity;

    #region windows component
    private void InitializeComponent()
    {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.gbFoodsCanMake = new System.Windows.Forms.GroupBox();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.lstvRecipeCanMake = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbRecipeCanMake = new System.Windows.Forms.ComboBox();
            this.gbFoodsCannotMake = new System.Windows.Forms.GroupBox();
            this.lstvRecipeCannotMake = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbRecipeCannotMake = new System.Windows.Forms.ComboBox();
            this.gbMaterialsHave = new System.Windows.Forms.GroupBox();
            this.btnAddMaterial = new System.Windows.Forms.Button();
            this.lstvMaterialsInStock = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbMaterialsInStock = new System.Windows.Forms.ComboBox();
            this.gbMaterialsOut = new System.Windows.Forms.GroupBox();
            this.lstvMaterialsOutOfStock = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbMaterialsOutOfStock = new System.Windows.Forms.ComboBox();
            this.stsStatusBar = new System.Windows.Forms.StatusStrip();
            this.tssDBconnectStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mnMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.smnSelectOrCreateDB = new System.Windows.Forms.ToolStripMenuItem();
            this.mnHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.smnAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.gbFoodsCanMake.SuspendLayout();
            this.gbFoodsCannotMake.SuspendLayout();
            this.gbMaterialsHave.SuspendLayout();
            this.gbMaterialsOut.SuspendLayout();
            this.stsStatusBar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFoodsCanMake
            // 
            this.gbFoodsCanMake.Controls.Add(this.btnAddRecipe);
            this.gbFoodsCanMake.Controls.Add(this.lstvRecipeCanMake);
            this.gbFoodsCanMake.Controls.Add(this.cbRecipeCanMake);
            this.gbFoodsCanMake.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFoodsCanMake.Location = new System.Drawing.Point(12, 28);
            this.gbFoodsCanMake.Name = "gbFoodsCanMake";
            this.gbFoodsCanMake.Size = new System.Drawing.Size(250, 300);
            this.gbFoodsCanMake.TabIndex = 0;
            this.gbFoodsCanMake.TabStop = false;
            this.gbFoodsCanMake.Text = "อาหารที่ทำได้";
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.Location = new System.Drawing.Point(6, 269);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(90, 23);
            this.btnAddRecipe.TabIndex = 6;
            this.btnAddRecipe.Text = "เพิ่มเมนูอาหาร";
            this.btnAddRecipe.UseVisualStyleBackColor = true;
            this.btnAddRecipe.Click += new System.EventHandler(this.btnAddRecipe_Click);
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
            this.lstvRecipeCanMake.DoubleClick += new System.EventHandler(this.Recipe_Selected_DoubleClick);
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
            this.cbRecipeCanMake.Items.AddRange(new object[] {
            "ทั้งหมด",
            "อาหารคาว",
            "อาหารหวาน"});
            this.cbRecipeCanMake.Location = new System.Drawing.Point(123, 269);
            this.cbRecipeCanMake.Name = "cbRecipeCanMake";
            this.cbRecipeCanMake.Size = new System.Drawing.Size(121, 21);
            this.cbRecipeCanMake.TabIndex = 1;
            this.cbRecipeCanMake.SelectedIndexChanged += new System.EventHandler(this.cbRecipeCanMake_SelectedIndexChanged);
            // 
            // gbFoodsCannotMake
            // 
            this.gbFoodsCannotMake.Controls.Add(this.lstvRecipeCannotMake);
            this.gbFoodsCannotMake.Controls.Add(this.cbRecipeCannotMake);
            this.gbFoodsCannotMake.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFoodsCannotMake.Location = new System.Drawing.Point(280, 28);
            this.gbFoodsCannotMake.Name = "gbFoodsCannotMake";
            this.gbFoodsCannotMake.Size = new System.Drawing.Size(344, 300);
            this.gbFoodsCannotMake.TabIndex = 1;
            this.gbFoodsCannotMake.TabStop = false;
            this.gbFoodsCannotMake.Text = "อาหารที่ทำไม่ได้";
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
            this.lstvRecipeCannotMake.DoubleClick += new System.EventHandler(this.Recipe_Selected_DoubleClick);
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
            this.cbRecipeCannotMake.Items.AddRange(new object[] {
            "ทั้งหมด",
            "อาหารคาว",
            "อาหารหวาน"});
            this.cbRecipeCannotMake.Location = new System.Drawing.Point(217, 269);
            this.cbRecipeCannotMake.Name = "cbRecipeCannotMake";
            this.cbRecipeCannotMake.Size = new System.Drawing.Size(121, 21);
            this.cbRecipeCannotMake.TabIndex = 3;
            this.cbRecipeCannotMake.SelectedIndexChanged += new System.EventHandler(this.cbRecipeCannotMake_SelectedIndexChanged);
            // 
            // gbMaterialsHave
            // 
            this.gbMaterialsHave.Controls.Add(this.btnAddMaterial);
            this.gbMaterialsHave.Controls.Add(this.lstvMaterialsInStock);
            this.gbMaterialsHave.Controls.Add(this.cbMaterialsInStock);
            this.gbMaterialsHave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMaterialsHave.Location = new System.Drawing.Point(630, 28);
            this.gbMaterialsHave.Name = "gbMaterialsHave";
            this.gbMaterialsHave.Size = new System.Drawing.Size(250, 300);
            this.gbMaterialsHave.TabIndex = 2;
            this.gbMaterialsHave.TabStop = false;
            this.gbMaterialsHave.Text = "วัตถุดิบที่มี";
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
            this.lstvMaterialsInStock.Cursor = System.Windows.Forms.Cursors.Default;
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
            // gbMaterialsOut
            // 
            this.gbMaterialsOut.Controls.Add(this.lstvMaterialsOutOfStock);
            this.gbMaterialsOut.Controls.Add(this.cbMaterialsOutOfStock);
            this.gbMaterialsOut.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMaterialsOut.Location = new System.Drawing.Point(901, 28);
            this.gbMaterialsOut.Name = "gbMaterialsOut";
            this.gbMaterialsOut.Size = new System.Drawing.Size(146, 300);
            this.gbMaterialsOut.TabIndex = 3;
            this.gbMaterialsOut.TabStop = false;
            this.gbMaterialsOut.Text = "วัตถุดิบที่หมด";
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
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnMenu,
            this.mnHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1064, 24);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // mnMenu
            // 
            this.mnMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smnSelectOrCreateDB});
            this.mnMenu.Name = "mnMenu";
            this.mnMenu.Size = new System.Drawing.Size(39, 20);
            this.mnMenu.Text = "เมนู";
            // 
            // smnSelectOrCreateDB
            // 
            this.smnSelectOrCreateDB.Name = "smnSelectOrCreateDB";
            this.smnSelectOrCreateDB.Size = new System.Drawing.Size(163, 22);
            this.smnSelectOrCreateDB.Text = "เลือกไฟล์ฐานข้อมูล";
            this.smnSelectOrCreateDB.Click += new System.EventHandler(this.RestoreDatabaseClick);
            // 
            // mnHelp
            // 
            this.mnHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smnAbout});
            this.mnHelp.Name = "mnHelp";
            this.mnHelp.Size = new System.Drawing.Size(63, 20);
            this.mnHelp.Text = "ช่วยเหลือ";
            // 
            // smnAbout
            // 
            this.smnAbout.Name = "smnAbout";
            this.smnAbout.Size = new System.Drawing.Size(113, 22);
            this.smnAbout.Text = "เกี่ยวกับ";
            this.smnAbout.Click += new System.EventHandler(this.AboutMenuClick);
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(1064, 358);
            this.Controls.Add(this.stsStatusBar);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.gbMaterialsOut);
            this.Controls.Add(this.gbMaterialsHave);
            this.Controls.Add(this.gbFoodsCannotMake);
            this.Controls.Add(this.gbFoodsCanMake);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Food Manager";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.gbFoodsCanMake.ResumeLayout(false);
            this.gbFoodsCannotMake.ResumeLayout(false);
            this.gbMaterialsHave.ResumeLayout(false);
            this.gbMaterialsOut.ResumeLayout(false);
            this.stsStatusBar.ResumeLayout(false);
            this.stsStatusBar.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
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
        if (myRecipe.CurrentName.Length != 0)
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
        IngredientUpdate();
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

        if (myRecipe.PreviousTask == DELETE)
        {
            RecipeUpdate();
        }
        else if (myRecipe.PreviousTask == EDIT)
        {
            RecipeUpdateQuantity = new AdjustmentIngredient(myRecipe.CurrentName);
            tssDBconnectStatus.Text = "Database is updating";
            RecipeUpdateQuantity.UpdateRecipeQuantity();
            RecipeUpdate();
            IngredientUpdate();
            tssDBconnectStatus.Text = "Database is updated";
        }
        else if (myRecipe.PreviousTask == MADE)
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

            if (myEdit.PreviousTask == EDIT)
            {
                RecipeUpdateQuantity = new AdjustmentIngredient();
                RecipeUpdateQuantity.UpdateOneRalateIngredient(myDB.SelectOneIngredientID(myEdit.CurrentName));
            }

            IngredientUpdate();
            RecipeUpdate();
        }
        else
        {
            frmIngredient myEdit = new frmIngredient(lstvMaterialsOutOfStock.SelectedItems[0].Text);
            myEdit.ShowDialog();

            if (myEdit.PreviousTask == EDIT)
            {
                RecipeUpdateQuantity = new AdjustmentIngredient();
                RecipeUpdateQuantity.UpdateOneRalateIngredient(myDB.SelectOneIngredientID(myEdit.CurrentName));
            }

            IngredientUpdate();
            RecipeUpdate();
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
    /// Get connection status by call ConnectDB.ConnectStstus and update status bar
    /// </summary>
    /// <returns>True if connected otherwise false</returns>
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

    private void DisableForm()
    {
        gbFoodsCanMake.Enabled = false;
        gbFoodsCannotMake.Enabled = false;
        gbMaterialsHave.Enabled = false;
        gbMaterialsOut.Enabled = false;
    }

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
    /// (โหลดทั้งสองกรณีของสูตรที่แสดงผลใน ListView)Reload both case of recipe to display in recipe ListView
    /// </summary>
    private void RecipeUpdate()
    {
        RecipeInStockUpdate();
        RecipeOutOfStockUpdate();
    }

    private void IngredientInStockUpdate()
    {
        int i;
        List<string>[] data = new List<string>[4];

        lstvMaterialsInStock.Items.Clear();
        data = myDB.SelectIngredient(cbMaterialsInStock.SelectedIndex, INSTOCK);
        ListViewItem sub;
        for (i = 0; i < data[0].Count; i++)
        {
            sub = new ListViewItem(data[0][i]);
            sub.SubItems.Add(data[1][i]);
            sub.SubItems.Add(int.Parse(data[2][i]).ToIngredientUnitString());
            lstvMaterialsInStock.Items.Add(sub);
        }
    }

    private void IngredientOutOfStockUpdate()
    {
        int i;
        lstvMaterialsOutOfStock.Items.Clear();
        List<string>[] data = new List<string>[4];
        if (cbMaterialsOutOfStock.SelectedIndex == 0)
        data = myDB.SelectIngredient(cbMaterialsOutOfStock.SelectedIndex, OUTOFSTOCK);
        ListViewItem sub;
        for (i = 0; i < data[0].Count; i++)
        {
            sub = new ListViewItem(data[0][i]);
            lstvMaterialsOutOfStock.Items.Add(sub);
        }
    }

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

    private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
    {

    }

    private void frmMain_Load(object sender, EventArgs e)
    {

    }
}
