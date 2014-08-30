using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
public class frmMain : Form
{
    private GroupBox gpbFoodsCanMake;
    private GroupBox gpbFoodsCannotMake;
    private GroupBox gpbMaterialsOut;
    private ComboBox cbFoodsCanMake;
    private ListView lstvFoodsCanMake;
    private ColumnHeader columnHeader1;
    private ColumnHeader columnHeader2;
    private ColumnHeader columnHeader3;
    private ListView lstvFoodsCannotMake;
    private ColumnHeader columnHeader4;
    private ColumnHeader columnHeader5;
    private ComboBox cbFoodsCannotMake;
    private ListView lstvMaterialsHave;
    private ColumnHeader columnHeader6;
    private ColumnHeader columnHeader7;
    private ColumnHeader columnHeader8;
    private ComboBox cbMaterialsHave;
    private ComboBox cbMaterialsOut;
    private ListView listView1;
    private ColumnHeader columnHeader9;
    private Button btnAddMenu;
    private Button btnAddMaterial;
    private GroupBox gpbMaterialsHave;
    private DBConnector myDB = new DBConnector();

    #region windows component
    private void InitializeComponent()
    {
            this.gpbFoodsCanMake = new System.Windows.Forms.GroupBox();
            this.btnAddMenu = new System.Windows.Forms.Button();
            this.lstvFoodsCanMake = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbFoodsCanMake = new System.Windows.Forms.ComboBox();
            this.gpbFoodsCannotMake = new System.Windows.Forms.GroupBox();
            this.lstvFoodsCannotMake = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbFoodsCannotMake = new System.Windows.Forms.ComboBox();
            this.gpbMaterialsHave = new System.Windows.Forms.GroupBox();
            this.btnAddMaterial = new System.Windows.Forms.Button();
            this.lstvMaterialsHave = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbMaterialsHave = new System.Windows.Forms.ComboBox();
            this.gpbMaterialsOut = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbMaterialsOut = new System.Windows.Forms.ComboBox();
            this.gpbFoodsCanMake.SuspendLayout();
            this.gpbFoodsCannotMake.SuspendLayout();
            this.gpbMaterialsHave.SuspendLayout();
            this.gpbMaterialsOut.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbFoodsCanMake
            // 
            this.gpbFoodsCanMake.Controls.Add(this.btnAddMenu);
            this.gpbFoodsCanMake.Controls.Add(this.lstvFoodsCanMake);
            this.gpbFoodsCanMake.Controls.Add(this.cbFoodsCanMake);
            this.gpbFoodsCanMake.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbFoodsCanMake.Location = new System.Drawing.Point(12, 12);
            this.gpbFoodsCanMake.Name = "gpbFoodsCanMake";
            this.gpbFoodsCanMake.Size = new System.Drawing.Size(250, 300);
            this.gpbFoodsCanMake.TabIndex = 0;
            this.gpbFoodsCanMake.TabStop = false;
            this.gpbFoodsCanMake.Text = "อาหารที่ทำได้";
            // 
            // btnAddMenu
            // 
            this.btnAddMenu.Location = new System.Drawing.Point(6, 269);
            this.btnAddMenu.Name = "btnAddMenu";
            this.btnAddMenu.Size = new System.Drawing.Size(90, 23);
            this.btnAddMenu.TabIndex = 6;
            this.btnAddMenu.Text = "เพิ่มเมนูอาหาร";
            this.btnAddMenu.UseVisualStyleBackColor = true;
            this.btnAddMenu.Click += new System.EventHandler(this.btnAddMenu_Click);
            // 
            // lstvFoodsCanMake
            // 
            this.lstvFoodsCanMake.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lstvFoodsCanMake.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lstvFoodsCanMake.Location = new System.Drawing.Point(6, 20);
            this.lstvFoodsCanMake.Name = "lstvFoodsCanMake";
            this.lstvFoodsCanMake.Size = new System.Drawing.Size(238, 243);
            this.lstvFoodsCanMake.TabIndex = 4;
            this.lstvFoodsCanMake.UseCompatibleStateImageBehavior = false;
            this.lstvFoodsCanMake.View = System.Windows.Forms.View.Details;
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
            // cbFoodsCanMake
            // 
            this.cbFoodsCanMake.FormattingEnabled = true;
            this.cbFoodsCanMake.Location = new System.Drawing.Point(123, 269);
            this.cbFoodsCanMake.Name = "cbFoodsCanMake";
            this.cbFoodsCanMake.Size = new System.Drawing.Size(121, 21);
            this.cbFoodsCanMake.TabIndex = 1;
            // 
            // gpbFoodsCannotMake
            // 
            this.gpbFoodsCannotMake.Controls.Add(this.lstvFoodsCannotMake);
            this.gpbFoodsCannotMake.Controls.Add(this.cbFoodsCannotMake);
            this.gpbFoodsCannotMake.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbFoodsCannotMake.Location = new System.Drawing.Point(280, 12);
            this.gpbFoodsCannotMake.Name = "gpbFoodsCannotMake";
            this.gpbFoodsCannotMake.Size = new System.Drawing.Size(344, 300);
            this.gpbFoodsCannotMake.TabIndex = 1;
            this.gpbFoodsCannotMake.TabStop = false;
            this.gpbFoodsCannotMake.Text = "อาหารที่ทำไม่ได้";
            // 
            // lstvFoodsCannotMake
            // 
            this.lstvFoodsCannotMake.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5});
            this.lstvFoodsCannotMake.Location = new System.Drawing.Point(6, 20);
            this.lstvFoodsCannotMake.Name = "lstvFoodsCannotMake";
            this.lstvFoodsCannotMake.Size = new System.Drawing.Size(332, 243);
            this.lstvFoodsCannotMake.TabIndex = 5;
            this.lstvFoodsCannotMake.UseCompatibleStateImageBehavior = false;
            this.lstvFoodsCannotMake.View = System.Windows.Forms.View.Details;
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
            // cbFoodsCannotMake
            // 
            this.cbFoodsCannotMake.FormattingEnabled = true;
            this.cbFoodsCannotMake.Location = new System.Drawing.Point(217, 269);
            this.cbFoodsCannotMake.Name = "cbFoodsCannotMake";
            this.cbFoodsCannotMake.Size = new System.Drawing.Size(121, 21);
            this.cbFoodsCannotMake.TabIndex = 3;
            // 
            // gpbMaterialsHave
            // 
            this.gpbMaterialsHave.Controls.Add(this.btnAddMaterial);
            this.gpbMaterialsHave.Controls.Add(this.lstvMaterialsHave);
            this.gpbMaterialsHave.Controls.Add(this.cbMaterialsHave);
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
            // lstvMaterialsHave
            // 
            this.lstvMaterialsHave.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lstvMaterialsHave.Location = new System.Drawing.Point(6, 20);
            this.lstvMaterialsHave.Name = "lstvMaterialsHave";
            this.lstvMaterialsHave.Size = new System.Drawing.Size(238, 243);
            this.lstvMaterialsHave.TabIndex = 5;
            this.lstvMaterialsHave.UseCompatibleStateImageBehavior = false;
            this.lstvMaterialsHave.View = System.Windows.Forms.View.Details;
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
            // cbMaterialsHave
            // 
            this.cbMaterialsHave.FormattingEnabled = true;
            this.cbMaterialsHave.Location = new System.Drawing.Point(123, 269);
            this.cbMaterialsHave.Name = "cbMaterialsHave";
            this.cbMaterialsHave.Size = new System.Drawing.Size(121, 21);
            this.cbMaterialsHave.TabIndex = 3;
            // 
            // gpbMaterialsOut
            // 
            this.gpbMaterialsOut.Controls.Add(this.listView1);
            this.gpbMaterialsOut.Controls.Add(this.cbMaterialsOut);
            this.gpbMaterialsOut.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gpbMaterialsOut.Location = new System.Drawing.Point(901, 12);
            this.gpbMaterialsOut.Name = "gpbMaterialsOut";
            this.gpbMaterialsOut.Size = new System.Drawing.Size(146, 300);
            this.gpbMaterialsOut.TabIndex = 3;
            this.gpbMaterialsOut.TabStop = false;
            this.gpbMaterialsOut.Text = "วัตถุดิบที่หมด";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader9});
            this.listView1.Location = new System.Drawing.Point(6, 20);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(134, 243);
            this.listView1.TabIndex = 4;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "ชื่อวัตถุดิบ";
            this.columnHeader9.Width = 110;
            // 
            // cbMaterialsOut
            // 
            this.cbMaterialsOut.FormattingEnabled = true;
            this.cbMaterialsOut.Location = new System.Drawing.Point(19, 269);
            this.cbMaterialsOut.Name = "cbMaterialsOut";
            this.cbMaterialsOut.Size = new System.Drawing.Size(121, 21);
            this.cbMaterialsOut.TabIndex = 3;
            // 
            // frmMain
            // 
            this.ClientSize = new System.Drawing.Size(1064, 328);
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
            this.ResumeLayout(false);

    }
    #endregion windows component

    private void lstvFoodsCanMake_ItemActivate(object sender, EventArgs e)
    {
        int id;
        ListView.SelectedListViewItemCollection itemSelected = lstvFoodsCanMake.SelectedItems;
    }
    public frmMain()
    {
        InitializeComponent();
        IngredientUpdate();
    }
    public static void Main()
    {
        frmMain main = new frmMain();
        Application.EnableVisualStyles();
        Application.Run(main);
    }

    private void btnAddMenu_Click(object sender, EventArgs e)
    {

    }

    private void btnAddMaterial_Click(object sender, EventArgs e)
    {
        clsIngredient myIngredient = new clsIngredient();
        myIngredient.ShowDialog();
    }
    private void IngredientUpdate()
    {
        int i;
        List<string>[] data = new List<string>[4];
        data = myDB.IngredientSelect();
        ListViewItem sub;
        for (i = 0; i < data[0].Count; i++)
        {
            sub = new ListViewItem(data[1][i]);
            sub.SubItems.Add(data[2][i]);
            sub.SubItems.Add(data[3][i]);
            lstvMaterialsHave.Items.Add(sub);
        }
    }
}
