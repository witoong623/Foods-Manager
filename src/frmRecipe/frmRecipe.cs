using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FoodsManager
{
    public partial class frmRecipe : Form
    {
        private int MakeQuantity;
        private int CanMakeQuantity;
        private int UnitID;
        private int TypeID;
        private int CurrentSelectedIndex = -1;
        private string currentName = "";
        private Task previousTask = Task.None;
        private List<string>[] currentIngredient;

        public frmRecipe()
        {
            InitializeComponent();
            AutoCompleteSource();
        }

        /// <summary>
        /// ใช้สำหรับสร้างฟอร์มที่ถูกต้องกับการทำงานและโหลดข้อมูลขึ้นมาแสดง
        /// </summary>
        /// <param name="call"></param>
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

        public Task PreviousTask
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
                return MakeQuantity;
            }
        }

        #region event handler

        /// <summary>
        /// อีเว้นท์สำหรับเพิ่มสูตรอาหาร โดยตรวจสอบเงื่อนไขต่างๆ ก่อน
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddRecipe(object sender, EventArgs e)
        {
            int i;
            List<string>[] ingredient = new List<string>[2];
            ingredient[0] = new List<string>();
            ingredient[1] = new List<string>();

            if (txtFoodName.Text.Length == 0)
            {
                MessageBox.Show("กรุณาใส่ชื่อสูตรอาหาร", "กรอกข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFoodName.Select();
                return;
            }

            if (lstvIngredientTable.Items.Count == 0)
            {
                MessageBox.Show("กรุณาเพิ่มวัตถุดิบ\nลงไปในรายการทางด้านซ้าย", "กรอกข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbIngredientName.Select();
                return;
            }

            for (i = 0; i < lstvIngredientTable.Items.Count; i++)
            {
                ListViewItem subitem = lstvIngredientTable.Items[i];
                ingredient[0].Add(subitem.SubItems[0].Text);
                ingredient[1].Add(subitem.SubItems[1].Text);
            }

            if (myDB.InsertRecipe(txtFoodName.Text, CheckedToTypeID(), ingredient, CheckedToUnitID()))
            {
                currentName = txtFoodName.Text;
                previousTask = Task.Add;
                Close();
            }
        }

        /// <summary>
        /// อีเว้นสำหรับเปลี่ยนค่าภายใน ComboBox ตามประเภทที่ถูกเลือก
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
        /// อีเว้นสำหรับเพิ่มวัตถุดิบที่ต้องการเข้าไปในสูตร พร้อมตรวจสอบเงื่อนไขต่างๆ ก่อนด้วย
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
                MessageBox.Show("กรุณาใส่ชื่อวัตถุดิบ", "กรอกข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cbIngredientName.Select();
                return;
            }

            if (txtQuantity.Text.Length == 0)
            {
                MessageBox.Show("กรุณาใส่ปริมาณที่ต้องใช้", "กรอกข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity.Select();
                return;
            }

            flag = int.TryParse(txtQuantity.Text, out quantity);

            if (!flag)
            {
                MessageBox.Show("กรุณาป้อนจำนวนเป็นตัวเลข", "กรอกข้อมูลผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity.Select();
                return;
            }

            if (CurrentSelectedIndex < 0)
            {
                for (int i = 0; i < lstvIngredientTable.Items.Count; i++)
                {
                    if (lstvIngredientTable.Items[i].SubItems[0].Text.Equals(cbIngredientName.Text))
                    {
                        MessageBox.Show("มีวัตถุดิบนี้อยู่แล้ว", "กรอกข้อมูลซ้ำ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                string temp = myDB.SelectIngredientUnitID(cbIngredientName.Text).ToIngredientUnitString();

                if (temp.Equals("ไม่มีวัตถุดิบนี้"))
                {
                    MessageBox.Show("ไม่มีวัตถุดิบนี้ในฐานข้อมูล", "ไม่มีข้อมูล", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                ListCollection = new ListViewItem(cbIngredientName.Text);
                ListCollection.SubItems.Add(txtQuantity.Text);
                ListCollection.SubItems.Add(temp);
                lstvIngredientTable.Items.Add(ListCollection);
            }
            else
            {
                ListCollection = new ListViewItem(cbIngredientName.Text);
                ListCollection.SubItems.Add(txtQuantity.Text);
                ListCollection.SubItems.Add(myDB.SelectIngredientUnitID(cbIngredientName.Text).ToIngredientUnitString());
                lstvIngredientTable.Items[CurrentSelectedIndex] = ListCollection;
                btnAddIngredient.Text = "เพิ่มวัตถุดิบ";
            }

            CurrentSelectedIndex = -1;
            cbIngredientName.Text = "";
            txtQuantity.Clear();

        }

        /// <summary>
        /// อีเว้นท์สำหรับลบหรือแก้ไขสูตร แต่จะไม่สามารถแก้ไขชื่อสูตรได้
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEditRecipe_Click(object sender, EventArgs e)
        {
            if (cbDeleteRecipe.Checked)
            {
                DialogResult dr = MessageBox.Show("ต้องกดจะลบสูตร" + txtFoodName.Text + "นี้ใช่หรือไม่",
                                                  "ยืนยันการลบ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    myDB.DeleteRecipe(txtFoodName.Text);
                    previousTask = Task.Delete;
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

                // Case edit detail but don't edit ingredient
                if ((CheckedToTypeID() != TypeID) || (CheckedToUnitID() != UnitID) && !IsIngredientChange(ingredient))
                {
                    if (myDB.UpdateRecipeDetail(txtFoodName.Text, CheckedToTypeID(), CheckedToUnitID()))
                    {
                        previousTask = Task.Edit;
                        currentName = txtFoodName.Text;
                        MessageBox.Show("แก้ไขสูตรเรียบร้อย", "แก้ไขสูตรเรียบร้อย", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        return;
                    }
                }
                // Case edit ingredient but don't edit detail
                else if ((CheckedToTypeID() == TypeID) && (CheckedToUnitID() == UnitID) && IsIngredientChange(ingredient))
                {
                    if (myDB.EditIngredientOfRecipe(txtFoodName.Text, ingredient))
                    {
                        previousTask = Task.Edit;
                        currentName = txtFoodName.Text;
                        MessageBox.Show("แก้ไขสูตรเรียบร้อย", "แก้ไขสูตรเรียบร้อย", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                }
                // Case edit both
                else
                {
                    if (myDB.UpdateRecipeDetail(txtFoodName.Text, CheckedToTypeID(), CheckedToUnitID()))
                    {
                        if (myDB.EditIngredientOfRecipe(txtFoodName.Text, ingredient))
                        {
                            previousTask = Task.Edit;
                            currentName = txtFoodName.Text;
                            MessageBox.Show("แก้ไขสูตรเรียบร้อย", "แก้ไขสูตรเรียบร้อย", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Close();
                        }
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }

        /// <summary>
        /// อีเว้นสำหรับทำอาหาร โดยจะทำการตัดวัตถุดิบทั้งหมดที่ต้องการใช้ตามปริมาณที่ต้องการใช้ในภายหลัง
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMakeFood_Click(object sender, EventArgs e)
        {
            if ((MessageBox.Show("ต้องการจะทำอาหารนี้ใช่หรือไม่", "ยืนยันการทำอาหาร", MessageBoxButtons.YesNo,
                                  MessageBoxIcon.Question) == DialogResult.Yes))
            {
                if (rdb1ea.Checked)
                {
                    MakeQuantity = 1;
                }
                else if (rdb2ea.Checked)
                {
                    MakeQuantity = 2;
                }
                else
                {
                    if (!int.TryParse(txtCustomMakeQuantity.Text, out MakeQuantity))
                    {
                        MessageBox.Show("กรุณาป้อนจำนวนเป็นตัวเลข", "ข้อมูลผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (MakeQuantity <= 0)
                    {
                        MessageBox.Show("กรุณาป้อนปริมาณที่มากกว่า 0", "ข้อมูลที่รับมาไม่ถูกต้อง", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                if (MakeQuantity > CanMakeQuantity)
                {
                    MessageBox.Show("ไม่สามารถทำอาหารนี้ได้ตามจำนวนที่ต้องการ\nปริมาณที่สามารถทำได้สูงสุดคือ " + CanMakeQuantity,
                        "ไม่สามารถทำอาหารได้", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                currentName = txtFoodName.Text;
                previousTask = Task.Made;
                Close();
            }
            else
            {
                return;
            }
        }

        /// <summary>
        /// ลบวัตถุดิบออกจาก List view ผ่านการคลิก
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
                    cbIngredientName.Text = "";
                    txtQuantity.Clear();
                }
            }
        }

        private void SelectedListViewToEdit(object sender, EventArgs e)
        {
            ListViewItem SelectedItem = lstvIngredientTable.SelectedItems[0];

            CurrentSelectedIndex = lstvIngredientTable.SelectedIndices[0];
            cbIngredientName.Text = SelectedItem.SubItems[0].Text;
            txtQuantity.Text = SelectedItem.SubItems[1].Text;
            btnAddIngredient.Text = "แก้ไขวัตถุดิบ";
            cbIngredientName.Enabled = false;
        }

        /// <summary>
        /// ล้างกล่องข้อความเพื่อเตรียมรับข้อมูลจากผู้ใช้ใหม่
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddEmptyTextbox(object sender, EventArgs e)
        {
            txtQuantity.Clear();
            CurrentSelectedIndex = -1;
            btnAddIngredient.Text = "เพิ่มวัตถุดิบ";
            cbIngredientName.Text = "";
            cbIngredientName.Enabled = true;
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

        private void txtFoodName_Click(object sender, EventArgs e)
        {
            txtFoodName.SelectAll();
        }

        private void cbIngredientName_Click(object sender, EventArgs e)
        {
            cbIngredientName.Select();
        }

        private void txtQuantity_Click(object sender, EventArgs e)
        {
            txtQuantity.SelectAll();
        }

        private void txtCustomMakeQuantity_Click(object sender, EventArgs e)
        {
            txtCustomMakeQuantity.SelectAll();
        }

        /// <summary>
        /// อีเว้นสำหรับปิดฟอร์ม
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CloseForm(object sender, EventArgs e)
        {
            Close();
        }

        #endregion event handler

        /// <summary>
        /// แก้ไขฟอร์มเพื่อใช้สำหรับเพิ่มสูตร
        /// </summary>
        private void AdditionFormDisplay()
        {
            this.Text = "เพิ่มสูตรอาหาร";
            btnSubmit.Text = "เพิ่มสูตรอาหาร";
            btnCancel.Text = "ยกเลิก";
            txtFoodName.Select();
            rdbMeatDish.Checked = true;
            btnSubmit.Click += new EventHandler(AddRecipe);
            btnCancel.Click += new EventHandler(CloseForm);
        }

        /// <summary>
        /// แก้ไขฟอร์มเพื่อใช้สำหรับแก้ไขสูตร
        /// </summary>
        private void EditorFormDisplay()
        {
            this.Text = "แก้ไขสูตรอาหาร";
            btnSubmit.Text = "แก้ไขสูตร";
            btnCancel.Text = "ยกเลิก";
            btnAddNewIngredient.Visible = true;
            AddNewControlToEditForm();
            rdb1ea.Checked = true;
            btnSubmit.Click += new EventHandler(btnEditRecipe_Click);
            btnCancel.Click += new EventHandler(CloseForm);
        }

        /// <summary>
        /// ดึงข้อมูลจากฐานข้อมูลเพื่อนำมาใส่ใน AutoCompleteStringCollection
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
        /// ดึงรายละเอียดของสูตรและวัตถุดิบที่ต้องการมาแสดง
        /// </summary>
        /// <param name="name">ชื่อของสูตร</param>
        private void LoadRecipeToDisplay(string name)
        {
            int i;
            List<string> RecipeDetail = myDB.SelectRecipeDetail(name);
            List<string>[] IngredientOfRecipe = myDB.SelectIngredientOfRecipe(name);
            currentIngredient = IngredientOfRecipe;

            TypeID = int.Parse(RecipeDetail[0]);
            CanMakeQuantity = int.Parse(RecipeDetail[1]);
            UnitID = int.Parse(RecipeDetail[2]);

            txtFoodName.Text = name;
            lblUnitString.Text = UnitID.ToRecipeUnitString();
            UnitIDToCheck(UnitID);
            TypeIdToCheck(TypeID);
            lblCurrentQuantityCanMake.Text += " " + RecipeDetail[1] + " " + lblUnitString.Text;
            rdb1ea.Text += lblUnitString.Text;
            rdb2ea.Text += lblUnitString.Text;

            if (CanMakeQuantity == 0)
            {
                btnMakeFood.Enabled = false;
            }

            ListViewItem sub;
            for (i = 0; i < IngredientOfRecipe[0].Count; i++)
            {
                sub = new ListViewItem(IngredientOfRecipe[0][i]);
                sub.SubItems.Add(IngredientOfRecipe[1][i]);
                sub.SubItems.Add(int.Parse(IngredientOfRecipe[2][i]).ToIngredientUnitString());
                lstvIngredientTable.Items.Add(sub);
            }

            txtFoodName.ReadOnly = true;
        }

        /// <summary>
        /// ตรวจสอบว่ามีการเปลี่ยนแปลงวัตถุดิบของสูตรหรือไม่
        /// </summary>
        /// <param name="NewIngredient">เซตของวัตถุดิบขณะแก้ไขวัตถุดิบ</param>
        /// <returns>จริงเมื่อมีการเปลี่ยนแปลง ไม่จริงเมื่อไม่มีการเปลี่ยนแปลง</returns>
        private bool IsIngredientChange(List<string>[] NewIngredient)
        {
            if (NewIngredient[0].Count != currentIngredient[0].Count)
            {
                return true;
            }

            for (var i = 0; i < NewIngredient[0].Count; i++)
            {
                if (NewIngredient[0][i].Equals(currentIngredient[0][i]))
                {
                    if (!NewIngredient[1][i].Equals(currentIngredient[1][i]))
                    {
                        return true;
                    }
                }
                else
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// เปลี่ยนฟอร์มที่ถูกติกเป็นไอดีของหน่วยอาหาร
        /// </summary>
        /// <returns>ไอดีของหน่วยอาหาร</returns>
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

        /// <summary>
        /// เปลี่ยนฟอร์มที่ถูกติกเป็นไอดีของประเภทอาหาร
        /// </summary>
        /// <returns>ไอดีของประเภทอาหาร</returns>
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

        /// <summary>
        /// เปลี่ยนไอดีของประเภทอาหารมาติกที่ฟอร์ม
        /// </summary>
        /// <param name="typeID">ไอดีของประเภทอาหาร</param>
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

        /// <summary>
        /// เปลี่ยนไอดีของหน่วยอาหารมาติกที่ฟอร์ม
        /// </summary>
        /// <param name="unitID">ไอดีของหน่วยอาหาร</param>
        private void UnitIDToCheck(int unitID)
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


    }
}
