using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;
using FoodsManager;

public class frmRecipe : Form
{
    private const int ADD = 1;
    private const int EDIT = 2;
    private const int DELETE = 3;
    private const int MADE = 4;

    private ListView lstvIngredientTable;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private Label label1;
    private TextBox txtFoodName;
    private Label label3;
    private TextBox txtQuantity;
    private ComboBox cbIngredientType;
    private Label label4;
    private Button btnAddIngredient;
    private Button btnDeleteIngredient;
    private Label label2;
    private GroupBox gbRecipeType;
    private RadioButton rdbMeatDish;
    private RadioButton rdbDessert;
    private Button btnAddNewIngredient;
    private DBConnector myDB = new DBConnector();
    private ComboBox cbIngredientName;
    private GroupBox gbRecipeUnit;
    private RadioButton rdbBag;
    private RadioButton rdbRot;
    private RadioButton rdbCup;
    private RadioButton rdbBowl;
    private RadioButton rdbPlate;
    private StatusStrip MainStatusStrip;
    private GroupBox gbDecrease;
    private RadioButton rdbCustomMakeQuantity;
    private RadioButton rdb2ea;
    private RadioButton rdb1ea;
    private TextBox txtCustomMakeQuantity;
    private Button btnMakeFood;
    private Label lblCurrentQuantityCanMake;
    private Label lblUnitString;
    private CheckBox cbDeleteRecipe;
    private Button btnCancel;
    private Button btnSubmit;

    private int currentMadeQuantity;
    private int previousTask;
    private string currentName;

    #region windows code
    private void InitializeComponent()
    {
            this.lstvIngredientTable = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txtFoodName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cbIngredientType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.btnDeleteIngredient = new System.Windows.Forms.Button();
            this.gbRecipeType = new System.Windows.Forms.GroupBox();
            this.rdbDessert = new System.Windows.Forms.RadioButton();
            this.rdbMeatDish = new System.Windows.Forms.RadioButton();
            this.btnAddNewIngredient = new System.Windows.Forms.Button();
            this.cbIngredientName = new System.Windows.Forms.ComboBox();
            this.gbRecipeUnit = new System.Windows.Forms.GroupBox();
            this.rdbBag = new System.Windows.Forms.RadioButton();
            this.rdbRot = new System.Windows.Forms.RadioButton();
            this.rdbCup = new System.Windows.Forms.RadioButton();
            this.rdbBowl = new System.Windows.Forms.RadioButton();
            this.rdbPlate = new System.Windows.Forms.RadioButton();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.gbRecipeType.SuspendLayout();
            this.gbRecipeUnit.SuspendLayout();
            this.SuspendLayout();
            // 
            // lstvIngredientTable
            // 
            this.lstvIngredientTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.lstvIngredientTable.FullRowSelect = true;
            this.lstvIngredientTable.GridLines = true;
            this.lstvIngredientTable.Location = new System.Drawing.Point(12, 50);
            this.lstvIngredientTable.Name = "lstvIngredientTable";
            this.lstvIngredientTable.Size = new System.Drawing.Size(263, 334);
            this.lstvIngredientTable.TabIndex = 0;
            this.lstvIngredientTable.UseCompatibleStateImageBehavior = false;
            this.lstvIngredientTable.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ชื่อวัตถุดิบ";
            this.columnHeader1.Width = 146;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "ปริมาณที่ใช้";
            this.columnHeader2.Width = 88;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(295, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "ชื่อวัตถุดิบ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtFoodName
            // 
            this.txtFoodName.Location = new System.Drawing.Point(118, 14);
            this.txtFoodName.Name = "txtFoodName";
            this.txtFoodName.Size = new System.Drawing.Size(411, 20);
            this.txtFoodName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "ชื่ออาหาร";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(295, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 23);
            this.label3.TabIndex = 5;
            this.label3.Text = "ปริมาณ";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(371, 94);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(152, 20);
            this.txtQuantity.TabIndex = 3;
            // 
            // cbIngredientType
            // 
            this.cbIngredientType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIngredientType.FormattingEnabled = true;
            this.cbIngredientType.Items.AddRange(new object[] {
            "ทั้งหมด",
            "เครื่องปรุง",
            "เนื้อสัตว์",
            "ผัก",
            "ผลไม้"});
            this.cbIngredientType.Location = new System.Drawing.Point(371, 132);
            this.cbIngredientType.Name = "cbIngredientType";
            this.cbIngredientType.Size = new System.Drawing.Size(121, 21);
            this.cbIngredientType.TabIndex = 6;
            this.cbIngredientType.SelectedIndexChanged += new System.EventHandler(this.AddIngredientNameToComboBox);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(281, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "ประเภทวัตถุดิบ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnAddIngredient
            // 
            this.btnAddIngredient.Location = new System.Drawing.Point(317, 174);
            this.btnAddIngredient.Name = "btnAddIngredient";
            this.btnAddIngredient.Size = new System.Drawing.Size(75, 23);
            this.btnAddIngredient.TabIndex = 4;
            this.btnAddIngredient.UseVisualStyleBackColor = true;
            this.btnAddIngredient.Click += new System.EventHandler(this.btnAddIngredient_Click);
            // 
            // btnDeleteIngredient
            // 
            this.btnDeleteIngredient.Location = new System.Drawing.Point(417, 174);
            this.btnDeleteIngredient.Name = "btnDeleteIngredient";
            this.btnDeleteIngredient.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteIngredient.TabIndex = 5;
            this.btnDeleteIngredient.Text = "ลบวัตถุดิบ";
            this.btnDeleteIngredient.UseVisualStyleBackColor = true;
            this.btnDeleteIngredient.Click += new System.EventHandler(this.btnDeleteIngredient_Click);
            // 
            // gbRecipeType
            // 
            this.gbRecipeType.Controls.Add(this.rdbDessert);
            this.gbRecipeType.Controls.Add(this.rdbMeatDish);
            this.gbRecipeType.Location = new System.Drawing.Point(298, 295);
            this.gbRecipeType.Name = "gbRecipeType";
            this.gbRecipeType.Size = new System.Drawing.Size(212, 61);
            this.gbRecipeType.TabIndex = 9;
            this.gbRecipeType.TabStop = false;
            this.gbRecipeType.Text = "เพิ่มสูครอาหาร";
            // 
            // rdbDessert
            // 
            this.rdbDessert.AutoSize = true;
            this.rdbDessert.Location = new System.Drawing.Point(111, 26);
            this.rdbDessert.Name = "rdbDessert";
            this.rdbDessert.Size = new System.Drawing.Size(80, 17);
            this.rdbDessert.TabIndex = 2;
            this.rdbDessert.Text = "อาหารหวาน";
            this.rdbDessert.UseVisualStyleBackColor = true;
            // 
            // rdbMeatDish
            // 
            this.rdbMeatDish.AutoSize = true;
            this.rdbMeatDish.Checked = true;
            this.rdbMeatDish.Location = new System.Drawing.Point(33, 26);
            this.rdbMeatDish.Name = "rdbMeatDish";
            this.rdbMeatDish.Size = new System.Drawing.Size(72, 17);
            this.rdbMeatDish.TabIndex = 1;
            this.rdbMeatDish.TabStop = true;
            this.rdbMeatDish.Text = "อาหารคาว";
            this.rdbMeatDish.UseVisualStyleBackColor = true;
            // 
            // btnAddNewIngredient
            // 
            this.btnAddNewIngredient.Location = new System.Drawing.Point(15, 395);
            this.btnAddNewIngredient.Name = "btnAddNewIngredient";
            this.btnAddNewIngredient.Size = new System.Drawing.Size(97, 23);
            this.btnAddNewIngredient.TabIndex = 10;
            this.btnAddNewIngredient.Text = "เพิ่มวัตถุดิบใหม่";
            this.btnAddNewIngredient.UseVisualStyleBackColor = true;
            this.btnAddNewIngredient.Visible = false;
            this.btnAddNewIngredient.Click += new System.EventHandler(this.btnAddEmptyTextbox);
            // 
            // cbIngredientName
            // 
            this.cbIngredientName.FormattingEnabled = true;
            this.cbIngredientName.Location = new System.Drawing.Point(371, 62);
            this.cbIngredientName.Name = "cbIngredientName";
            this.cbIngredientName.Size = new System.Drawing.Size(152, 21);
            this.cbIngredientName.TabIndex = 11;
            // 
            // gbRecipeUnit
            // 
            this.gbRecipeUnit.Controls.Add(this.rdbBag);
            this.gbRecipeUnit.Controls.Add(this.rdbRot);
            this.gbRecipeUnit.Controls.Add(this.rdbCup);
            this.gbRecipeUnit.Controls.Add(this.rdbBowl);
            this.gbRecipeUnit.Controls.Add(this.rdbPlate);
            this.gbRecipeUnit.Location = new System.Drawing.Point(298, 207);
            this.gbRecipeUnit.Name = "gbRecipeUnit";
            this.gbRecipeUnit.Size = new System.Drawing.Size(212, 80);
            this.gbRecipeUnit.TabIndex = 11;
            this.gbRecipeUnit.TabStop = false;
            this.gbRecipeUnit.Text = "หน่วยอาหาร";
            // 
            // rdbBag
            // 
            this.rdbBag.AutoSize = true;
            this.rdbBag.Location = new System.Drawing.Point(88, 44);
            this.rdbBag.Name = "rdbBag";
            this.rdbBag.Size = new System.Drawing.Size(37, 17);
            this.rdbBag.TabIndex = 17;
            this.rdbBag.Text = "ถุง";
            this.rdbBag.UseVisualStyleBackColor = true;
            // 
            // rdbRot
            // 
            this.rdbRot.AutoSize = true;
            this.rdbRot.Location = new System.Drawing.Point(23, 47);
            this.rdbRot.Name = "rdbRot";
            this.rdbRot.Size = new System.Drawing.Size(38, 17);
            this.rdbRot.TabIndex = 16;
            this.rdbRot.Text = "ไม้";
            this.rdbRot.UseVisualStyleBackColor = true;
            // 
            // rdbCup
            // 
            this.rdbCup.AutoSize = true;
            this.rdbCup.Location = new System.Drawing.Point(153, 21);
            this.rdbCup.Name = "rdbCup";
            this.rdbCup.Size = new System.Drawing.Size(45, 17);
            this.rdbCup.TabIndex = 14;
            this.rdbCup.Text = "ถ้วย";
            this.rdbCup.UseVisualStyleBackColor = true;
            // 
            // rdbBowl
            // 
            this.rdbBowl.AutoSize = true;
            this.rdbBowl.Location = new System.Drawing.Point(87, 21);
            this.rdbBowl.Name = "rdbBowl";
            this.rdbBowl.Size = new System.Drawing.Size(44, 17);
            this.rdbBowl.TabIndex = 13;
            this.rdbBowl.Text = "ชาม";
            this.rdbBowl.UseVisualStyleBackColor = true;
            // 
            // rdbPlate
            // 
            this.rdbPlate.AutoSize = true;
            this.rdbPlate.Checked = true;
            this.rdbPlate.Location = new System.Drawing.Point(23, 21);
            this.rdbPlate.Name = "rdbPlate";
            this.rdbPlate.Size = new System.Drawing.Size(44, 17);
            this.rdbPlate.TabIndex = 12;
            this.rdbPlate.TabStop = true;
            this.rdbPlate.Text = "จาน";
            this.rdbPlate.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(418, 385);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(318, 385);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 11;
            this.btnSubmit.UseVisualStyleBackColor = true;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // frmRecipe
            // 
            this.ClientSize = new System.Drawing.Size(537, 434);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.gbRecipeUnit);
            this.Controls.Add(this.cbIngredientName);
            this.Controls.Add(this.btnAddNewIngredient);
            this.Controls.Add(this.gbRecipeType);
            this.Controls.Add(this.btnDeleteIngredient);
            this.Controls.Add(this.btnAddIngredient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbIngredientType);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFoodName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstvIngredientTable);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbRecipeType.ResumeLayout(false);
            this.gbRecipeType.PerformLayout();
            this.gbRecipeUnit.ResumeLayout(false);
            this.gbRecipeUnit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    #endregion windows code

    public frmRecipe()
    {
        InitializeComponent();
        AutoCompleteSource();
    }

    public frmRecipe(string call) : this()
    {
        cbIngredientType.SelectedIndex = 0;
        if (call == null)
        {
            AdditionFormDisplay();
        }
        else
        {
            EditorFormDisplay();
            LoadRecipeToDisplay(call);
        }
    }

    public string CurrentName
    {
        get
        {
            return currentName;
        }
    }

    public int PreviousTask
    {
        get
        {
            return previousTask;
        }
    }

    public int CurrentMadeQuantity
    {
        get
        {
            return currentMadeQuantity;
        }
    }

    /// <summary>
    /// Display Addition form mode
    /// </summary>
    private void AdditionFormDisplay()
    {
        this.Text = "เพิ่มสูตรอาหาร";
        btnAddIngredient.Text = "เพิ่มวัตถุดิบ";
        btnSubmit.Text = "เพิ่มสูตรอาหาร";
        btnCancel.Text = "ยกเลิก";
        txtFoodName.Select();
        rdbMeatDish.Checked = true;
        btnSubmit.Click += new EventHandler(AddRecipe);
        btnCancel.Click += new EventHandler(CloseForm);
    }

    /// <summary>
    /// Display Editor form mode
    /// </summary>
    private void EditorFormDisplay()
    {
        this.Text = "แก้ไขสูตรอาหาร";
        btnAddIngredient.Text = "แก้ไขวัตถุดิบ";
        btnSubmit.Text = "แก้ไขสูตร";
        btnCancel.Text = "ลบสูตรอาหาร";
        btnAddNewIngredient.Visible = true;
        AddNewControlToEditForm();
        rdb1ea.Checked = true;
        btnSubmit.Click += new EventHandler(btnEditRecipe_Click);
        btnCancel.Click += new EventHandler(CloseForm);
    }

    #region new control in editor form
    /// <summary>
    /// Contruct new control items to form
    /// </summary>
    private void AddNewControlToEditForm()
    {
        this.Height = 535;
        this.gbRecipeType.Height = 80;

        this.gbDecrease = new System.Windows.Forms.GroupBox();
        this.lblUnitString = new System.Windows.Forms.Label();
        this.txtCustomMakeQuantity = new System.Windows.Forms.TextBox();
        this.btnMakeFood = new System.Windows.Forms.Button();
        this.rdbCustomMakeQuantity = new System.Windows.Forms.RadioButton();
        this.rdb2ea = new System.Windows.Forms.RadioButton();
        this.rdb1ea = new System.Windows.Forms.RadioButton();
        this.lblCurrentQuantityCanMake = new System.Windows.Forms.Label();
        this.cbDeleteRecipe = new System.Windows.Forms.CheckBox();

        this.gbDecrease.SuspendLayout();

        // 
        // lblUnitString
        // 
        this.lblUnitString.AutoSize = true;
        this.lblUnitString.Location = new System.Drawing.Point(338, 28);
        this.lblUnitString.Name = "lblUnitString";
        this.lblUnitString.Size = new System.Drawing.Size(0, 13);
        this.lblUnitString.TabIndex = 20;
        // 
        // txtCustomMakeQuantity
        // 
        this.txtCustomMakeQuantity.Location = new System.Drawing.Point(269, 25);
        this.txtCustomMakeQuantity.Name = "txtCustomMakeQuantity";
        this.txtCustomMakeQuantity.Size = new System.Drawing.Size(63, 20);
        this.txtCustomMakeQuantity.TabIndex = 21;
        // 
        // btnMakeFood
        // 
        this.btnMakeFood.Location = new System.Drawing.Point(406, 23);
        this.btnMakeFood.Name = "button1";
        this.btnMakeFood.Size = new System.Drawing.Size(75, 23);
        this.btnMakeFood.TabIndex = 20;
        this.btnMakeFood.Text = "ทำอาหารนี้";
        this.btnMakeFood.UseVisualStyleBackColor = true;
        this.btnMakeFood.Click += new EventHandler(btnMakeFood_Click);
        // 
        // rdbCustomMakeQuantity
        // 
        this.rdbCustomMakeQuantity.AutoSize = true;
        this.rdbCustomMakeQuantity.Location = new System.Drawing.Point(188, 26);
        this.rdbCustomMakeQuantity.Name = "rdbCustomMakeQuantity";
        this.rdbCustomMakeQuantity.Size = new System.Drawing.Size(75, 17);
        this.rdbCustomMakeQuantity.TabIndex = 2;
        this.rdbCustomMakeQuantity.TabStop = true;
        this.rdbCustomMakeQuantity.Text = "กำหนดเอง";
        this.rdbCustomMakeQuantity.UseVisualStyleBackColor = true;
        this.rdbCustomMakeQuantity.CheckedChanged += new System.EventHandler(this.rdbQuantity_CheckedChange);
        // 
        // rdb2ea
        // 
        this.rdb2ea.AutoSize = true;
        this.rdb2ea.Location = new System.Drawing.Point(99, 26);
        this.rdb2ea.Name = "rdb2ea";
        this.rdb2ea.Size = new System.Drawing.Size(34, 17);
        this.rdb2ea.TabIndex = 1;
        this.rdb2ea.TabStop = true;
        this.rdb2ea.Text = "2 ";
        this.rdb2ea.UseVisualStyleBackColor = true;
        this.rdb2ea.CheckedChanged += new System.EventHandler(this.rdbQuantity_CheckedChange);
        // 
        // rdb1ea
        // 
        this.rdb1ea.AutoSize = true;
        this.rdb1ea.Location = new System.Drawing.Point(18, 26);
        this.rdb1ea.Name = "rdb1ea";
        this.rdb1ea.Size = new System.Drawing.Size(34, 17);
        this.rdb1ea.TabIndex = 0;
        this.rdb1ea.TabStop = true;
        this.rdb1ea.Text = "1 ";
        this.rdb1ea.UseVisualStyleBackColor = true;
        this.rdb1ea.CheckedChanged += new System.EventHandler(this.rdbQuantity_CheckedChange);
        // 
        // lblCurrentQuantityCanMake
        // 
        this.lblCurrentQuantityCanMake.AutoSize = true;
        this.lblCurrentQuantityCanMake.Location = new System.Drawing.Point(118, 400);
        this.lblCurrentQuantityCanMake.Name = "lblCurrentQuantityCanMake";
        this.lblCurrentQuantityCanMake.Size = new System.Drawing.Size(101, 13);
        this.lblCurrentQuantityCanMake.TabIndex = 19;
        this.lblCurrentQuantityCanMake.Text = "ปริมาณที่ทำได้ขณะนี้";
        // 
        // cbDeleteRecipe
        // 
        this.cbDeleteRecipe.AutoSize = true;
        this.cbDeleteRecipe.Location = new System.Drawing.Point(73, 52);
        this.cbDeleteRecipe.Name = "cbDeleteRecipe";
        this.cbDeleteRecipe.Size = new System.Drawing.Size(66, 17);
        this.cbDeleteRecipe.TabIndex = 12;
        this.cbDeleteRecipe.Text = "ลบสูตรนี้";
        this.cbDeleteRecipe.UseVisualStyleBackColor = true;

        // Add control items to group box
        this.gbDecrease.Controls.Add(this.lblUnitString);
        this.gbDecrease.Controls.Add(this.txtCustomMakeQuantity);
        this.gbDecrease.Controls.Add(this.btnMakeFood);
        this.gbDecrease.Controls.Add(this.rdbCustomMakeQuantity);
        this.gbDecrease.Controls.Add(this.rdb2ea);
        this.gbDecrease.Controls.Add(this.rdb1ea);
        this.gbDecrease.Location = new System.Drawing.Point(15, 424);
        this.gbDecrease.Name = "gbDecrease";
        this.gbDecrease.Size = new System.Drawing.Size(495, 60);
        this.gbDecrease.TabIndex = 18;
        this.gbDecrease.TabStop = false;
        this.gbDecrease.Text = "ทำอาหาร";
        this.gbRecipeType.Controls.Add(this.cbDeleteRecipe);

        this.Controls.Add(gbDecrease);
        this.Controls.Add(this.lblCurrentQuantityCanMake);
        this.gbDecrease.ResumeLayout(false);
        this.gbDecrease.PerformLayout();
    }
    #endregion new control in editor form
    /// <summary>
    /// Get information from database and add to autostring collection
    /// </summary>
    private void AutoCompleteSource()
    {
        AutoCompleteStringCollection AutoCompleteCollection = new AutoCompleteStringCollection();

        AutoCompleteCollection = myDB.AddIngredientNameToAutoComplete();
        cbIngredientName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
        cbIngredientName.AutoCompleteMode = AutoCompleteMode.Suggest;
        cbIngredientName.AutoCompleteCustomSource = AutoCompleteCollection;
    }

    /// <summary>
    /// Add item Collection to ingredient name Combobox
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AddIngredientNameToComboBox(object sender, EventArgs e)
    {
        string[] collection;

        cbIngredientName.Items.Clear();
        collection = myDB.AddIngredientNameToComboBoxCollection(cbIngredientType.SelectedIndex);
        cbIngredientName.Items.AddRange(collection);
    }

    /// <summary>
    /// Load recipe detail with ingredient of recipe and assign to form
    /// </summary>
    /// <param name="name">name of recipe</param>
    private void LoadRecipeToDisplay(string name)
    {
        int i;
        List<string> RecipeDetail = myDB.SelectRecipeDetail(name);
        List<string>[] IngredientOfRecipe = myDB.SelectIngredientOfRecipe(name);

        txtFoodName.Text = name;
        lblUnitString.Text = UnitIDToString(int.Parse(RecipeDetail[2]));
        UnitIdToCheck(int.Parse(RecipeDetail[2]));
        lblCurrentQuantityCanMake.Text += " " + RecipeDetail[1] + " " + lblUnitString.Text;
        rdb1ea.Text += lblUnitString.Text;
        rdb2ea.Text += lblUnitString.Text;
        ListViewItem sub;
        for (i = 0; i < IngredientOfRecipe[0].Count; i++)
        {
            sub = new ListViewItem(IngredientOfRecipe[0][i]);
            sub.SubItems.Add(IngredientOfRecipe[1][i]);
            lstvIngredientTable.Items.Add(sub);
        }

        txtFoodName.ReadOnly = true;
        gbRecipeUnit.Enabled = false;
        if (rdbMeatDish.Checked)
        {
            rdbDessert.Enabled = false;
        }
        else
        {
            rdbMeatDish.Enabled = false;
        }
    }

    /// <summary>
    /// Add ingredient to List View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnAddIngredient_Click(object sender, EventArgs e)
    {
        ListViewItem ListCollection;
        int quantity;
        bool flag;

        if (cbIngredientName.Text.Length == 0)
        {
            MessageBox.Show("กรุณาใส่ชื่อวัตถุดิบ");
            cbIngredientName.Select();
            return;
        }

        if (txtQuantity.Text.Length == 0)
        {
            MessageBox.Show("กรุณาใส่ปริมาณที่ต้องใช้");
            txtQuantity.Select();
            return;
        }

        flag = int.TryParse(txtQuantity.Text, out quantity);
        
        if (!flag)
        {
            MessageBox.Show("กรุณาป้อนจำนวนเป็นตัวเลข");
            txtQuantity.Select();
            return;
        }

        for (int i = 0; i < lstvIngredientTable.Items.Count; i++)
        {
            if (lstvIngredientTable.Items[i].SubItems[0].Text.Equals(cbIngredientName.Text))
            {
                MessageBox.Show("มีวัตถุดิบนี้อยู่แล้ว");
                return;
            }
        }


        ListCollection = new ListViewItem(cbIngredientName.Text);
        ListCollection.SubItems.Add(txtQuantity.Text);
        lstvIngredientTable.Items.Add(ListCollection);
    }

    /// <summary>
    /// Add a new recipe to recipe and ingredient of recipe to recipe_ingredient table
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void AddRecipe(object sender, EventArgs e)
    {
        List<string>[] ingredient = new List<string>[2];
        ingredient[0] = new List<string>();
        ingredient[1] = new List<string>();
        int i;
        bool flag;

        if (txtFoodName.Text.Length == 0)
        {
            MessageBox.Show("กรุณาใส่ชื่อสูตรอาหาร");
            txtFoodName.Select();
            return;
        }

        if (lstvIngredientTable.Items.Count == 0)
        {
            MessageBox.Show("กรุณาเพิ่มวัตถุดิบ\nลงไปในรายการทางด้านซ้าย");
            cbIngredientName.Select();
            return;
        }

        for (i = 0; i < lstvIngredientTable.Items.Count; i++)
        {
            ListViewItem subitem = lstvIngredientTable.Items[i];
            ingredient[0].Add(subitem.SubItems[0].Text);
            ingredient[1].Add(subitem.SubItems[1].Text);
        }

        flag = myDB.InsertRecipe(txtFoodName.Text, CheckedToTypeID(), ingredient, CheckedToUnitID());
        if (flag)
        {
            currentName = txtFoodName.Text;
            Close();
        }
    }

    /// <summary>
    /// Delete ingredient from List View
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnDeleteIngredient_Click(object sender, EventArgs e)
    {
        int i;

        if (lstvIngredientTable.SelectedItems.Count > 0)
        {
            for (i = lstvIngredientTable.SelectedItems.Count - 1; i >= 0; i--)
            {
                ListViewItem SelectedDelete = lstvIngredientTable.SelectedItems[i];
                lstvIngredientTable.Items[SelectedDelete.Index].Remove();
            }
        }
    }

    private void btnEditRecipe_Click(object sender, EventArgs e)
    {
        if (cbDeleteRecipe.Checked)
        {
            DialogResult dr = MessageBox.Show("ต้องกดจะลบสูตร" + txtFoodName.Text + "นี้ใช่หรือไม่", 
                                              "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                myDB.DeleteRecipe(txtFoodName.Text);
                previousTask = DELETE;
                Close();
            }
        }
        else
        {
            int i;
            List<string>[] ingredient = new List<string>[2];
            ingredient[0] = new List<string>();
            ingredient[1] = new List<string>();

            for (i = 0; i < lstvIngredientTable.Items.Count; i++)
            {
                ListViewItem subitem = lstvIngredientTable.Items[i];
                ingredient[0].Add(subitem.SubItems[0].Text);
                ingredient[1].Add(subitem.SubItems[1].Text);
            }


            if (myDB.EditIngredientOfRecipe(txtFoodName.Text, ingredient))
            {
                previousTask = EDIT;
                currentName = txtFoodName.Text;
                Close();
            }
        }
    }

    private void btnMakeFood_Click(object sender, EventArgs e)
    {
        if ((MessageBox.Show("ต้องการจะทำอาหารนี้ใช่หรือไม่", "ยืนยันการทำอาหาร", MessageBoxButtons.YesNo, 
                              MessageBoxIcon.Question) == DialogResult.Yes))
        {
            if (rdb1ea.Checked)
            {
                currentMadeQuantity = 1;
            }
            else if (rdb2ea.Checked)
            {
                currentMadeQuantity = 2;
            }
            else
            {
                currentMadeQuantity = int.Parse(txtCustomMakeQuantity.Text);
            }
            currentName = txtFoodName.Text;
            previousTask = MADE;
            Close();
        }
        else
        {
            return;
        }
    }

    /// <summary>
    /// Clear Textbox for ready to get data from user
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    private void btnAddEmptyTextbox(object sender, EventArgs e)
    {
        cbIngredientName.SelectedText = "";
        txtQuantity.Clear();
        btnAddIngredient.Text = "เพิ่มวัตถุดิบ";
    }

    private void rdbQuantity_CheckedChange(object sender, EventArgs e)
    {
        if (rdbCustomMakeQuantity.Checked)
        {
            txtCustomMakeQuantity.Enabled = true;
        }
        else
        {
            txtCustomMakeQuantity.Enabled = false;
        }
    }

    private int CheckedToUnitID()
    {
        if (rdbPlate.Checked)
        {
            return 1;
        }
        else if (rdbBowl.Checked)
        {
            return 2;
        }
        else if (rdbCup.Checked)
        {
            return 3;
        }
        else if (rdbRot.Checked)
        {
            return 4;
        }
        else
        {
            return 5;
        }
    }

    private int CheckedToTypeID()
    {
        if (rdbMeatDish.Checked)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

    private void TypeIdToCheck(int typeID)
    {
        if (typeID == 1)
        {
            rdbMeatDish.Checked = true;
        }
        else
        {
            rdbDessert.Checked = true;
        }
    }

    private void UnitIdToCheck(int unitID)
    {
        switch (unitID)
        {
            case 1:
                rdbPlate.Checked = true;
                break;
            case 2:
                rdbBowl.Checked = true;
                break;
            case 3:
                rdbCup.Checked = true;
                break;
            case 4:
                rdbRot.Checked = true;
                break;
            case 5:
                rdbBag.Checked = true;
                break;
        }
    }

    private string UnitIDToString(int typeID)
    {
        switch (typeID)
        {
            case 1:
                return "จาน";
            case 2:
                return "ชาม";
            case 3:
                return "ถ้วย";
            case 4:
                return "ไม้";
            case 5:
                return "ถุง";
            default :
                return "หน่วยผิด";
        }
    }

    private void CloseForm(object sender, EventArgs e)
    {
        Close();
    }

    private void btnSubmit_Click(object sender, EventArgs e)
    {

    }
}