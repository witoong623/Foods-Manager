using System.Windows.Forms;

namespace FoodsManager
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.gbFoodsCanMake.SuspendLayout();
            this.gbFoodsCannotMake.SuspendLayout();
            this.gbMaterialsHave.SuspendLayout();
            this.gbMaterialsOut.SuspendLayout();
            this.stsStatusBar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbFoodsCanMake
            // 
            this.gbFoodsCanMake.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFoodsCanMake.Controls.Add(this.btnAddRecipe);
            this.gbFoodsCanMake.Controls.Add(this.lstvRecipeCanMake);
            this.gbFoodsCanMake.Controls.Add(this.cbRecipeCanMake);
            this.gbFoodsCanMake.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFoodsCanMake.Location = new System.Drawing.Point(3, 3);
            this.gbFoodsCanMake.Name = "gbFoodsCanMake";
            this.gbFoodsCanMake.Size = new System.Drawing.Size(254, 300);
            this.gbFoodsCanMake.TabIndex = 0;
            this.gbFoodsCanMake.TabStop = false;
            this.gbFoodsCanMake.Text = "อาหารที่ทำได้";
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.lstvRecipeCanMake.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.cbRecipeCanMake.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.gbFoodsCannotMake.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbFoodsCannotMake.Controls.Add(this.lstvRecipeCannotMake);
            this.gbFoodsCannotMake.Controls.Add(this.cbRecipeCannotMake);
            this.gbFoodsCannotMake.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbFoodsCannotMake.Location = new System.Drawing.Point(263, 3);
            this.gbFoodsCannotMake.Name = "gbFoodsCannotMake";
            this.gbFoodsCannotMake.Size = new System.Drawing.Size(360, 300);
            this.gbFoodsCannotMake.TabIndex = 1;
            this.gbFoodsCannotMake.TabStop = false;
            this.gbFoodsCannotMake.Text = "อาหารที่ทำไม่ได้";
            // 
            // lstvRecipeCannotMake
            // 
            this.lstvRecipeCannotMake.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstvRecipeCannotMake.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.lstvRecipeCannotMake.FullRowSelect = true;
            this.lstvRecipeCannotMake.GridLines = true;
            this.lstvRecipeCannotMake.Location = new System.Drawing.Point(6, 20);
            this.lstvRecipeCannotMake.Name = "lstvRecipeCannotMake";
            this.lstvRecipeCannotMake.Size = new System.Drawing.Size(348, 243);
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
            this.cbRecipeCannotMake.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
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
            this.gbMaterialsHave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMaterialsHave.Controls.Add(this.btnAddMaterial);
            this.gbMaterialsHave.Controls.Add(this.lstvMaterialsInStock);
            this.gbMaterialsHave.Controls.Add(this.cbMaterialsInStock);
            this.gbMaterialsHave.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMaterialsHave.Location = new System.Drawing.Point(629, 3);
            this.gbMaterialsHave.Name = "gbMaterialsHave";
            this.gbMaterialsHave.Size = new System.Drawing.Size(254, 300);
            this.gbMaterialsHave.TabIndex = 2;
            this.gbMaterialsHave.TabStop = false;
            this.gbMaterialsHave.Text = "วัตถุดิบที่มี";
            // 
            // btnAddMaterial
            // 
            this.btnAddMaterial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
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
            this.lstvMaterialsInStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstvMaterialsInStock.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lstvMaterialsInStock.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstvMaterialsInStock.FullRowSelect = true;
            this.lstvMaterialsInStock.GridLines = true;
            this.lstvMaterialsInStock.Location = new System.Drawing.Point(7, 20);
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
            this.cbMaterialsInStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMaterialsInStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaterialsInStock.FormattingEnabled = true;
            this.cbMaterialsInStock.Items.AddRange(new object[] {
            "ทั้งหมด",
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
            this.gbMaterialsOut.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbMaterialsOut.Controls.Add(this.lstvMaterialsOutOfStock);
            this.gbMaterialsOut.Controls.Add(this.cbMaterialsOutOfStock);
            this.gbMaterialsOut.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbMaterialsOut.Location = new System.Drawing.Point(889, 3);
            this.gbMaterialsOut.Name = "gbMaterialsOut";
            this.gbMaterialsOut.Size = new System.Drawing.Size(148, 300);
            this.gbMaterialsOut.TabIndex = 3;
            this.gbMaterialsOut.TabStop = false;
            this.gbMaterialsOut.Text = "วัตถุดิบที่หมด";
            // 
            // lstvMaterialsOutOfStock
            // 
            this.lstvMaterialsOutOfStock.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
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
            this.columnHeader9.Width = 114;
            // 
            // cbMaterialsOutOfStock
            // 
            this.cbMaterialsOutOfStock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMaterialsOutOfStock.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMaterialsOutOfStock.FormattingEnabled = true;
            this.cbMaterialsOutOfStock.Items.AddRange(new object[] {
            "ทั้งหมด",
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
            // 
            // mnMenu
            // 
            this.mnMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smnSelectOrCreateDB});
            this.mnMenu.Name = "mnMenu";
            this.mnMenu.Size = new System.Drawing.Size(36, 20);
            this.mnMenu.Text = "เมนู";
            // 
            // smnSelectOrCreateDB
            // 
            this.smnSelectOrCreateDB.Name = "smnSelectOrCreateDB";
            this.smnSelectOrCreateDB.Size = new System.Drawing.Size(157, 22);
            this.smnSelectOrCreateDB.Text = "เลือกไฟล์ฐานข้อมูล";
            this.smnSelectOrCreateDB.Click += new System.EventHandler(this.RestoreDatabaseClick);
            // 
            // mnHelp
            // 
            this.mnHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.smnAbout});
            this.mnHelp.Name = "mnHelp";
            this.mnHelp.Size = new System.Drawing.Size(59, 20);
            this.mnHelp.Text = "ช่วยเหลือ";
            // 
            // smnAbout
            // 
            this.smnAbout.Name = "smnAbout";
            this.smnAbout.Size = new System.Drawing.Size(109, 22);
            this.smnAbout.Text = "เกี่ยวกับ";
            this.smnAbout.Click += new System.EventHandler(this.AboutMenuClick);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.42596F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.70906F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25.66116F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 14.20382F));
            this.tableLayoutPanel1.Controls.Add(this.gbFoodsCanMake, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbFoodsCannotMake, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbMaterialsHave, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.gbMaterialsOut, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 27);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1040, 306);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(1064, 358);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.stsStatusBar);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Food Manager";
            this.gbFoodsCanMake.ResumeLayout(false);
            this.gbFoodsCannotMake.ResumeLayout(false);
            this.gbMaterialsHave.ResumeLayout(false);
            this.gbMaterialsOut.ResumeLayout(false);
            this.stsStatusBar.ResumeLayout(false);
            this.stsStatusBar.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

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
        private TableLayoutPanel tableLayoutPanel1;
    }
}