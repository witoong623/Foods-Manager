using System;
﻿using System.Drawing;
using System.Windows.Forms;
public class clsIngredient : Form
{
    private Label label1;
    private Label label2;
    private TextBox txtQuantity;
    private GroupBox gbUnit;
    private RadioButton rdbGreb;
    private RadioButton rdbMud;
    private RadioButton rdbLuk;
    private RadioButton rdbHua;
    private RadioButton rdbTon;
    private RadioButton rdbGram;
    private RadioButton rdbFong;
    private GroupBox gbType;
    private RadioButton rdbMeat;
    private RadioButton radioButton2;
    private RadioButton rdbFruit;
    private RadioButton rdbVegetable;
    private TextBox txtIngredientName;
    private Button btnAdd;
    private Button btnClose;
    private DBConnector myDB = new DBConnector();
    #region windows code
    private void InitializeComponent()
    {
            this.label1 = new System.Windows.Forms.Label();
            this.txtIngredientName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.gbUnit = new System.Windows.Forms.GroupBox();
            this.rdbGreb = new System.Windows.Forms.RadioButton();
            this.rdbMud = new System.Windows.Forms.RadioButton();
            this.rdbLuk = new System.Windows.Forms.RadioButton();
            this.rdbHua = new System.Windows.Forms.RadioButton();
            this.rdbTon = new System.Windows.Forms.RadioButton();
            this.rdbGram = new System.Windows.Forms.RadioButton();
            this.rdbFong = new System.Windows.Forms.RadioButton();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.rdbFruit = new System.Windows.Forms.RadioButton();
            this.rdbVegetable = new System.Windows.Forms.RadioButton();
            this.rdbMeat = new System.Windows.Forms.RadioButton();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbUnit.SuspendLayout();
            this.gbType.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Location = new System.Drawing.Point(12, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "ชื่อวัตถุดิบ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIngredientName
            // 
            this.txtIngredientName.Location = new System.Drawing.Point(118, 39);
            this.txtIngredientName.Name = "txtIngredientName";
            this.txtIngredientName.Size = new System.Drawing.Size(154, 20);
            this.txtIngredientName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(12, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "จำนวนเริ่มต้น";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(118, 75);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(154, 20);
            this.txtQuantity.TabIndex = 3;
            this.txtQuantity.Text = "0";
            // 
            // gbUnit
            // 
            this.gbUnit.Controls.Add(this.rdbGreb);
            this.gbUnit.Controls.Add(this.rdbMud);
            this.gbUnit.Controls.Add(this.rdbLuk);
            this.gbUnit.Controls.Add(this.rdbHua);
            this.gbUnit.Controls.Add(this.rdbTon);
            this.gbUnit.Controls.Add(this.rdbGram);
            this.gbUnit.Controls.Add(this.rdbFong);
            this.gbUnit.Location = new System.Drawing.Point(12, 109);
            this.gbUnit.Name = "gbUnit";
            this.gbUnit.Size = new System.Drawing.Size(260, 85);
            this.gbUnit.TabIndex = 4;
            this.gbUnit.TabStop = false;
            this.gbUnit.Text = "หน่วย";
            // 
            // rdbGreb
            // 
            this.rdbGreb.AutoSize = true;
            this.rdbGreb.Location = new System.Drawing.Point(131, 42);
            this.rdbGreb.Name = "rdbGreb";
            this.rdbGreb.Size = new System.Drawing.Size(45, 17);
            this.rdbGreb.TabIndex = 9;
            this.rdbGreb.Text = "กลีบ";
            this.rdbGreb.UseVisualStyleBackColor = true;
            // 
            // rdbMud
            // 
            this.rdbMud.AutoSize = true;
            this.rdbMud.Location = new System.Drawing.Point(79, 42);
            this.rdbMud.Name = "rdbMud";
            this.rdbMud.Size = new System.Drawing.Size(39, 17);
            this.rdbMud.TabIndex = 8;
            this.rdbMud.Text = "มัด";
            this.rdbMud.UseVisualStyleBackColor = true;
            // 
            // rdbLuk
            // 
            this.rdbLuk.AutoSize = true;
            this.rdbLuk.Location = new System.Drawing.Point(131, 19);
            this.rdbLuk.Name = "rdbLuk";
            this.rdbLuk.Size = new System.Drawing.Size(38, 17);
            this.rdbLuk.TabIndex = 5;
            this.rdbLuk.Text = "ลูก";
            this.rdbLuk.UseVisualStyleBackColor = true;
            // 
            // rdbHua
            // 
            this.rdbHua.AutoSize = true;
            this.rdbHua.Location = new System.Drawing.Point(175, 19);
            this.rdbHua.Name = "rdbHua";
            this.rdbHua.Size = new System.Drawing.Size(38, 17);
            this.rdbHua.TabIndex = 5;
            this.rdbHua.Text = "หัว";
            this.rdbHua.UseVisualStyleBackColor = true;
            // 
            // rdbTon
            // 
            this.rdbTon.AutoSize = true;
            this.rdbTon.Location = new System.Drawing.Point(79, 19);
            this.rdbTon.Name = "rdbTon";
            this.rdbTon.Size = new System.Drawing.Size(40, 17);
            this.rdbTon.TabIndex = 7;
            this.rdbTon.Text = "ต้น";
            this.rdbTon.UseVisualStyleBackColor = true;
            // 
            // rdbGram
            // 
            this.rdbGram.AutoSize = true;
            this.rdbGram.Checked = true;
            this.rdbGram.Location = new System.Drawing.Point(30, 19);
            this.rdbGram.Name = "rdbGram";
            this.rdbGram.Size = new System.Drawing.Size(45, 17);
            this.rdbGram.TabIndex = 6;
            this.rdbGram.TabStop = true;
            this.rdbGram.Text = "กรัม";
            this.rdbGram.UseVisualStyleBackColor = true;
            // 
            // rdbFong
            // 
            this.rdbFong.AutoSize = true;
            this.rdbFong.Location = new System.Drawing.Point(30, 42);
            this.rdbFong.Name = "rdbFong";
            this.rdbFong.Size = new System.Drawing.Size(44, 17);
            this.rdbFong.TabIndex = 5;
            this.rdbFong.Text = "ฟอง";
            this.rdbFong.UseVisualStyleBackColor = true;
            // 
            // gbType
            // 
            this.gbType.Controls.Add(this.radioButton2);
            this.gbType.Controls.Add(this.rdbFruit);
            this.gbType.Controls.Add(this.rdbVegetable);
            this.gbType.Controls.Add(this.rdbMeat);
            this.gbType.Location = new System.Drawing.Point(12, 200);
            this.gbType.Name = "gbType";
            this.gbType.Size = new System.Drawing.Size(260, 49);
            this.gbType.TabIndex = 0;
            this.gbType.TabStop = false;
            this.gbType.Text = "ประเภท";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(181, 19);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(72, 17);
            this.radioButton2.TabIndex = 10;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "เครื่องปรุง";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // rdbFruit
            // 
            this.rdbFruit.AutoSize = true;
            this.rdbFruit.Location = new System.Drawing.Point(122, 19);
            this.rdbFruit.Name = "rdbFruit";
            this.rdbFruit.Size = new System.Drawing.Size(51, 17);
            this.rdbFruit.TabIndex = 7;
            this.rdbFruit.TabStop = true;
            this.rdbFruit.Text = "ผลไม้";
            this.rdbFruit.UseVisualStyleBackColor = true;
            // 
            // rdbVegetable
            // 
            this.rdbVegetable.AutoSize = true;
            this.rdbVegetable.Location = new System.Drawing.Point(75, 19);
            this.rdbVegetable.Name = "rdbVegetable";
            this.rdbVegetable.Size = new System.Drawing.Size(39, 17);
            this.rdbVegetable.TabIndex = 6;
            this.rdbVegetable.TabStop = true;
            this.rdbVegetable.Text = "ผัก";
            this.rdbVegetable.UseVisualStyleBackColor = true;
            // 
            // rdbMeat
            // 
            this.rdbMeat.AutoSize = true;
            this.rdbMeat.Checked = true;
            this.rdbMeat.Location = new System.Drawing.Point(6, 19);
            this.rdbMeat.Name = "rdbMeat";
            this.rdbMeat.Size = new System.Drawing.Size(63, 17);
            this.rdbMeat.TabIndex = 5;
            this.rdbMeat.TabStop = true;
            this.rdbMeat.Text = "เนื้อสัตว์";
            this.rdbMeat.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(42, 270);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(163, 270);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "ยกเลิก";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // clsIngredient
            // 
            this.ClientSize = new System.Drawing.Size(284, 305);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gbType);
            this.Controls.Add(this.gbUnit);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIngredientName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "clsIngredient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "เพิ่มวัตถุดิบ";
            this.gbUnit.ResumeLayout(false);
            this.gbUnit.PerformLayout();
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

    }
    #endregion windows code
    public clsIngredient()
    {
        InitializeComponent();
        txtIngredientName.Select();
    }

    //============== Helper Method ==================
    #region Helper method
    /// <summary>
    /// To determine what type of ingredient is checked
    /// </summary>
    /// <returns>int    that indicate what type is to insert to database</returns>
    private int TypeSelected()
    {
        if (rdbMeat.Checked == true)
        {
            return 2;
        }
        else if (rdbVegetable.Checked == true)
        {
            return 3;
        }
        else if (rdbFruit.Checked == true)
        {
            return 4;
        }
        else
        {
            return 1;
        }
    }

    /// <summary>
    /// To determine what unit of ingredient is checked
    /// </summary>
    /// <returns>int    that indicate what unit is to insert to database</returns>
    private int UnitSelected()
    {
        if (rdbGram.Checked == true)
        {
            return 11;
        }
        else if (rdbTon.Checked == true)
        {
            return 12;
        }
        else if (rdbLuk.Checked == true)
        {
            return 14;
        }
        else if (rdbHua.Checked == true)
        {
            return 13;
        }
        else if (rdbFong.Checked == true)
        {
            return 10;
        }
        else if (rdbMud.Checked == true)
        {
            return 15;
        }
        else
        {
            return 16;
        }
    }
    #endregion Helper method

    private void btnAdd_Click(object sender, EventArgs e)
    {
        int quantity;
        bool flag;

        if (txtIngredientName.Text.Length == 0)
        {
            MessageBox.Show("กรุณาใส่ชื่อวัตถุดิบ", "ข้อมูลผิดพลาด");
            txtIngredientName.Clear();
            txtIngredientName.Select();
            return;
        }

        flag = int.TryParse(txtQuantity.Text, out quantity);
        if(flag == false)
        {
            MessageBox.Show("กรุณาป้องจำนวนเป็นตัวเลข", "ข้อมูลผิดพลาด");
            txtQuantity.Clear();
            txtQuantity.Select();
            return;
        }

        myDB.Insert(TypeSelected(), txtIngredientName.Text, quantity, UnitSelected());
        Close();
    }

    private void btnClose_Click(object sender, EventArgs e)
    {
        Close();
    }
}