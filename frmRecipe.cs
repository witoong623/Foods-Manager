using System;
using System.Data;
using System.Collections.Generic;
using System.Windows.Forms;

public class frmRecipe : Form
{
    private ListView lstvIngredientTable;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private Label label1;
    private TextBox txtIngredientName;
    private TextBox txtFoodName;
    private Label label3;
    private TextBox txtQuantity;
    private ComboBox cbIngredientType;
    private Label label4;
    private Button btnAddIngredient;
    private Button btnDeleteIngredient;
    private Label label2;
    private GroupBox groupBox1;
    private Button btnAddRecipe;
    private RadioButton rdbMeatDish;
    private RadioButton rdbDessert;
    private DBConnector myDB = new DBConnector();

    #region windows code
    private void InitializeComponent()
    {
            this.lstvIngredientTable = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.txtIngredientName = new System.Windows.Forms.TextBox();
            this.txtFoodName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.cbIngredientType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAddIngredient = new System.Windows.Forms.Button();
            this.btnDeleteIngredient = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddRecipe = new System.Windows.Forms.Button();
            this.rdbMeatDish = new System.Windows.Forms.RadioButton();
            this.rdbDessert = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
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
            this.lstvIngredientTable.Size = new System.Drawing.Size(263, 211);
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
            // txtIngredientName
            // 
            this.txtIngredientName.Location = new System.Drawing.Point(371, 62);
            this.txtIngredientName.Name = "txtIngredientName";
            this.txtIngredientName.Size = new System.Drawing.Size(152, 20);
            this.txtIngredientName.TabIndex = 2;
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
            this.btnAddIngredient.Text = "เพิ่มวัตถุดิบ";
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
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbDessert);
            this.groupBox1.Controls.Add(this.rdbMeatDish);
            this.groupBox1.Controls.Add(this.btnAddRecipe);
            this.groupBox1.Location = new System.Drawing.Point(298, 232);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 128);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "เพิ่มสูครอาหาร";
            // 
            // btnAddRecipe
            // 
            this.btnAddRecipe.Location = new System.Drawing.Point(19, 80);
            this.btnAddRecipe.Name = "btnAddRecipe";
            this.btnAddRecipe.Size = new System.Drawing.Size(75, 23);
            this.btnAddRecipe.TabIndex = 0;
            this.btnAddRecipe.Text = "button1";
            this.btnAddRecipe.UseVisualStyleBackColor = true;
            // 
            // rdbMeatDish
            // 
            this.rdbMeatDish.AutoSize = true;
            this.rdbMeatDish.Location = new System.Drawing.Point(19, 34);
            this.rdbMeatDish.Name = "rdbMeatDish";
            this.rdbMeatDish.Size = new System.Drawing.Size(72, 17);
            this.rdbMeatDish.TabIndex = 1;
            this.rdbMeatDish.TabStop = true;
            this.rdbMeatDish.Text = "อาหารคาว";
            this.rdbMeatDish.UseVisualStyleBackColor = true;
            // 
            // rdbDessert
            // 
            this.rdbDessert.AutoSize = true;
            this.rdbDessert.Location = new System.Drawing.Point(97, 34);
            this.rdbDessert.Name = "rdbDessert";
            this.rdbDessert.Size = new System.Drawing.Size(72, 17);
            this.rdbDessert.TabIndex = 2;
            this.rdbDessert.TabStop = true;
            this.rdbDessert.Text = "อาหารคาว";
            this.rdbDessert.UseVisualStyleBackColor = true;
            // 
            // frmRecipe
            // 
            this.ClientSize = new System.Drawing.Size(537, 372);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnDeleteIngredient);
            this.Controls.Add(this.btnAddIngredient);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbIngredientType);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFoodName);
            this.Controls.Add(this.txtIngredientName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lstvIngredientTable);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "เพิ่มสูตรอาหาร";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    #endregion windows code

    public frmRecipe()
    {
        InitializeComponent();
        cbIngredientType.SelectedIndex = 0;
        AutoCompleteSource();
        txtFoodName.Select();
    }

    private void AutoCompleteSource()
    {
        AutoCompleteStringCollection AutoCompleteCollection = new AutoCompleteStringCollection();
        myDB.AssignAutoComplete(AutoCompleteCollection);
        txtIngredientName.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
        txtIngredientName.AutoCompleteMode = AutoCompleteMode.Suggest;
        txtIngredientName.AutoCompleteCustomSource = AutoCompleteCollection;
    }

    private void btnAddIngredient_Click(object sender, EventArgs e)
    {
        ListViewItem ListCollection;
        int dummy;
        bool flag;

        if (txtIngredientName.Text.Length == 0)
        {
            MessageBox.Show("กรุณาใส่ชื่อวัตถุดิบ");
            txtIngredientName.Select();
            return;
        }

        if (txtQuantity.Text.Length == 0)
        {
            MessageBox.Show("กรุณาใส่ปริมาณที่ต้องใช้");
            txtQuantity.Select();
            return;
        }

        flag = int.TryParse(txtQuantity.Text, out dummy);
        
        if (flag == false)
        {
            MessageBox.Show("กรุณาป้อนจำนวนเป็นตัวเลข");
            txtQuantity.Select();
            return;
        }

        ListCollection = new ListViewItem(txtIngredientName.Text);
        ListCollection.SubItems.Add(txtQuantity.Text);
        lstvIngredientTable.Items.Add(ListCollection);
    }

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
}