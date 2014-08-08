using System;
using System.Windows.Forms;
public class frmMain : Form
{
    private GroupBox gpbFoodsCanMake;
    private GroupBox gpbFoodsCannotMake;
    private GroupBox gpbMaterialsOut;
    private ListView listView1;
    private ComboBox comboBox1;
    private GroupBox gpbMaterialsHave;

    private void InitializeComponent()
    {
            this.gpbFoodsCanMake = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.gpbFoodsCannotMake = new System.Windows.Forms.GroupBox();
            this.gpbMaterialsHave = new System.Windows.Forms.GroupBox();
            this.gpbMaterialsOut = new System.Windows.Forms.GroupBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.gpbFoodsCanMake.SuspendLayout();
            this.SuspendLayout();
            // 
            // gpbFoodsCanMake
            // 
            this.gpbFoodsCanMake.Controls.Add(this.comboBox1);
            this.gpbFoodsCanMake.Controls.Add(this.listView1);
            this.gpbFoodsCanMake.Location = new System.Drawing.Point(12, 12);
            this.gpbFoodsCanMake.Name = "gpbFoodsCanMake";
            this.gpbFoodsCanMake.Size = new System.Drawing.Size(250, 300);
            this.gpbFoodsCanMake.TabIndex = 0;
            this.gpbFoodsCanMake.TabStop = false;
            this.gpbFoodsCanMake.Text = "อาหารที่ทำได้";
            // 
            // listView1
            // 
            this.listView1.Location = new System.Drawing.Point(6, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(238, 244);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // gpbFoodsCannotMake
            // 
            this.gpbFoodsCannotMake.Location = new System.Drawing.Point(280, 12);
            this.gpbFoodsCannotMake.Name = "gpbFoodsCannotMake";
            this.gpbFoodsCannotMake.Size = new System.Drawing.Size(250, 300);
            this.gpbFoodsCannotMake.TabIndex = 1;
            this.gpbFoodsCannotMake.TabStop = false;
            this.gpbFoodsCannotMake.Text = "อาหารที่ทำไม่ได้";
            // 
            // gpbMaterialsHave
            // 
            this.gpbMaterialsHave.Location = new System.Drawing.Point(548, 12);
            this.gpbMaterialsHave.Name = "gpbMaterialsHave";
            this.gpbMaterialsHave.Size = new System.Drawing.Size(250, 300);
            this.gpbMaterialsHave.TabIndex = 2;
            this.gpbMaterialsHave.TabStop = false;
            this.gpbMaterialsHave.Text = "วัตถุดิบที่มี";
            // 
            // gpbMaterialsOut
            // 
            this.gpbMaterialsOut.Location = new System.Drawing.Point(816, 12);
            this.gpbMaterialsOut.Name = "gpbMaterialsOut";
            this.gpbMaterialsOut.Size = new System.Drawing.Size(250, 300);
            this.gpbMaterialsOut.TabIndex = 3;
            this.gpbMaterialsOut.TabStop = false;
            this.gpbMaterialsOut.Text = "วัตถุดิบที่หมด";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(113, 269);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 1;
            // 
            // frmMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1081, 328);
            this.Controls.Add(this.gpbMaterialsOut);
            this.Controls.Add(this.gpbMaterialsHave);
            this.Controls.Add(this.gpbFoodsCannotMake);
            this.Controls.Add(this.gpbFoodsCanMake);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Food Manager";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.gpbFoodsCanMake.ResumeLayout(false);
            this.ResumeLayout(false);

    }
    public frmMain()
    {
        InitializeComponent();
    }
    public static void Main()
    {
        frmMain main = new frmMain();
        Application.Run(main);
    }
}