using System.Windows.Forms;

namespace FoodsManager
{
    partial class frmIngredient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmIngredient));
            this.label1 = new System.Windows.Forms.Label();
            this.txtIngredientName = new System.Windows.Forms.TextBox();
            this.lblQuantity = new System.Windows.Forms.Label();
            this.txtQuantity = new System.Windows.Forms.TextBox();
            this.gbUnit = new System.Windows.Forms.GroupBox();
            this.rdbGrain = new System.Windows.Forms.RadioButton();
            this.rdbBundle = new System.Windows.Forms.RadioButton();
            this.rdbMud = new System.Windows.Forms.RadioButton();
            this.rdbLuk = new System.Windows.Forms.RadioButton();
            this.rdbHua = new System.Windows.Forms.RadioButton();
            this.rdbTon = new System.Windows.Forms.RadioButton();
            this.rdbGram = new System.Windows.Forms.RadioButton();
            this.rdbFong = new System.Windows.Forms.RadioButton();
            this.gbType = new System.Windows.Forms.GroupBox();
            this.rdbFruit = new System.Windows.Forms.RadioButton();
            this.rdbVegetable = new System.Windows.Forms.RadioButton();
            this.rdbMeat = new System.Windows.Forms.RadioButton();
            this.btnSubmit = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.cbDelete = new System.Windows.Forms.CheckBox();
            this.gbUnit.SuspendLayout();
            this.gbType.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
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
            this.txtIngredientName.Click += new System.EventHandler(this.txtIngredientName_Click);
            // 
            // lblQuantity
            // 
            this.lblQuantity.Location = new System.Drawing.Point(12, 74);
            this.lblQuantity.Name = "lblQuantity";
            this.lblQuantity.Size = new System.Drawing.Size(100, 20);
            this.lblQuantity.TabIndex = 2;
            this.lblQuantity.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtQuantity
            // 
            this.txtQuantity.Location = new System.Drawing.Point(118, 75);
            this.txtQuantity.Name = "txtQuantity";
            this.txtQuantity.Size = new System.Drawing.Size(154, 20);
            this.txtQuantity.TabIndex = 3;
            this.txtQuantity.Click += new System.EventHandler(this.txtQuantity_Click);
            // 
            // gbUnit
            // 
            this.gbUnit.Controls.Add(this.rdbGrain);
            this.gbUnit.Controls.Add(this.rdbBundle);
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
            // rdbGrain
            // 
            this.rdbGrain.AutoSize = true;
            this.rdbGrain.Location = new System.Drawing.Point(175, 42);
            this.rdbGrain.Name = "rdbGrain";
            this.rdbGrain.Size = new System.Drawing.Size(44, 17);
            this.rdbGrain.TabIndex = 10;
            this.rdbGrain.TabStop = true;
            this.rdbGrain.Text = "เม็ด";
            this.rdbGrain.UseVisualStyleBackColor = true;
            // 
            // rdbBundle
            // 
            this.rdbBundle.AutoSize = true;
            this.rdbBundle.Location = new System.Drawing.Point(131, 42);
            this.rdbBundle.Name = "rdbBundle";
            this.rdbBundle.Size = new System.Drawing.Size(38, 17);
            this.rdbBundle.TabIndex = 9;
            this.rdbBundle.Text = "ห่อ";
            this.rdbBundle.UseVisualStyleBackColor = true;
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
            this.rdbGram.Location = new System.Drawing.Point(30, 19);
            this.rdbGram.Name = "rdbGram";
            this.rdbGram.Size = new System.Drawing.Size(45, 17);
            this.rdbGram.TabIndex = 6;
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
            // rdbFruit
            // 
            this.rdbFruit.AutoSize = true;
            this.rdbFruit.Location = new System.Drawing.Point(168, 19);
            this.rdbFruit.Name = "rdbFruit";
            this.rdbFruit.Size = new System.Drawing.Size(51, 17);
            this.rdbFruit.TabIndex = 7;
            this.rdbFruit.Text = "ผลไม้";
            this.rdbFruit.UseVisualStyleBackColor = true;
            // 
            // rdbVegetable
            // 
            this.rdbVegetable.AutoSize = true;
            this.rdbVegetable.Location = new System.Drawing.Point(121, 19);
            this.rdbVegetable.Name = "rdbVegetable";
            this.rdbVegetable.Size = new System.Drawing.Size(39, 17);
            this.rdbVegetable.TabIndex = 6;
            this.rdbVegetable.Text = "ผัก";
            this.rdbVegetable.UseVisualStyleBackColor = true;
            // 
            // rdbMeat
            // 
            this.rdbMeat.AutoSize = true;
            this.rdbMeat.Location = new System.Drawing.Point(52, 19);
            this.rdbMeat.Name = "rdbMeat";
            this.rdbMeat.Size = new System.Drawing.Size(63, 17);
            this.rdbMeat.TabIndex = 5;
            this.rdbMeat.Text = "เนื้อสัตว์";
            this.rdbMeat.UseVisualStyleBackColor = true;
            // 
            // btnSubmit
            // 
            this.btnSubmit.Location = new System.Drawing.Point(42, 279);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(75, 23);
            this.btnSubmit.TabIndex = 5;
            this.btnSubmit.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(163, 279);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "ยกเลิก";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // cbDelete
            // 
            this.cbDelete.AutoSize = true;
            this.cbDelete.Location = new System.Drawing.Point(101, 255);
            this.cbDelete.Name = "cbDelete";
            this.cbDelete.Size = new System.Drawing.Size(81, 17);
            this.cbDelete.TabIndex = 7;
            this.cbDelete.Text = "ลบวัตถุดิบนี้";
            this.cbDelete.UseVisualStyleBackColor = true;
            this.cbDelete.Visible = false;
            // 
            // frmIngredient
            // 
            this.ClientSize = new System.Drawing.Size(284, 317);
            this.Controls.Add(this.cbDelete);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.gbType);
            this.Controls.Add(this.gbUnit);
            this.Controls.Add(this.txtQuantity);
            this.Controls.Add(this.lblQuantity);
            this.Controls.Add(this.txtIngredientName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmIngredient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbUnit.ResumeLayout(false);
            this.gbUnit.PerformLayout();
            this.gbType.ResumeLayout(false);
            this.gbType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblQuantity;
        private TextBox txtQuantity;
        private GroupBox gbUnit;
        private RadioButton rdbBundle;
        private RadioButton rdbMud;
        private RadioButton rdbLuk;
        private RadioButton rdbHua;
        private RadioButton rdbTon;
        private RadioButton rdbGram;
        private RadioButton rdbFong;
        private GroupBox gbType;
        private RadioButton rdbMeat;
        private RadioButton rdbFruit;
        private RadioButton rdbVegetable;
        private TextBox txtIngredientName;
        private Button btnSubmit;
        private Button btnClose;
        private CheckBox cbDelete;
        private DBConnector myDB = new DBConnector();
        private RadioButton rdbGrain;
    }
}