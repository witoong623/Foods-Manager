using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FoodsManager
{
    public partial class frmIngredient : Form
    {

        private Task previousTask = Task.None;
        private int currentQuantity;
        private string currentName;

        public frmIngredient()
        {
            InitializeComponent();
        }

        /// <summary>
        /// สร้างตัวฟอร์มและโหลดข้อมูลที่จำเป็นขึ้นมาให้ผู้ใช้
        /// </summary>
        /// <param name="item">ชื่อของส่วนผสม หรือ ส่วนผสมที่ต้องการเพิ่ม</param>
        public frmIngredient(string item)
            : this()
        {
            if (item == null)
            {
                AddForm();
            }
            else
            {
                EditForm();
                LoadIngredient(item);
                txtQuantity.Select(txtQuantity.Text.Length, 0);
            }
        }

        /// <summary>
        /// ใช้ดึงข้อมูลว่าใช้ฟอร์มนี้ทำอะไรในฟอร์มหลัก
        /// </summary>
        public Task PreviousTask
        {
            get
            {
                return previousTask;
            }
        }

        /// <summary>
        /// ใช้ดึงชื่อของวัตถุดิบที่ถูกแสดงจากฟอร์มหลัก
        /// </summary>
        public string CurrentName
        {
            get
            {
                return currentName;
            }
        }

        //============== Helper Method ==================
        #region Helper method
        /// <summary>
        /// เปลี่ยนปุ่มประเภทอาหารที่ถูกติกเป็นไอดี
        /// </summary>
        /// <returns>ไอดีของประเภทอาหาร</returns>
        private int CheckedToTypeID()
        {
            if (rdbMeat.Checked)
            {
                return 1;
            }
            else if (rdbVegetable.Checked)
            {
                return 2;
            }
            else
            {
                return 3;
            }
        }

        /// <summary>
        /// เปลี่ยนข้อมูลที่ถูกเช็คไว้มาเป็นไอดีของหน่วยวัตถุดิย
        /// </summary>
        /// <returns>ไอดีของหน่วยวัตถุดิบ</returns>
        private int UnitSelected()
        {
            if (rdbGram.Checked)
            {
                return 11;
            }
            else if (rdbTon.Checked)
            {
                return 12;
            }
            else if (rdbLuk.Checked)
            {
                return 14;
            }
            else if (rdbHua.Checked)
            {
                return 13;
            }
            else if (rdbFong.Checked)
            {
                return 10;
            }
            else if (rdbMud.Checked)
            {
                return 15;
            }
            else if (rdbBundle.Checked)
            {
                return 16;
            }
            else
            {
                return 17;
            }
        }

        /// <summary>
        /// สร้างฟอร์มและแก้ไขข้อมูลของฟอร์มที่มีอยู่สำหรับเพิ่มวัตถุดิบ
        /// </summary>
        private void AddForm()
        {
            btnSubmit.Click += new System.EventHandler(this.btnAdd_Click);
            this.Text = "เพิ่มวัตถุดิบ";
            lblQuantity.Text = "จำนวนเริ่มต้น";
            btnSubmit.Text = "เพิ่ม";
            txtQuantity.Text = "0";
            txtIngredientName.Select();
            rdbGram.Checked = true;
            rdbMeat.Checked = true;
        }

        /// <summary>
        /// สร้างฟอร์มและแก้ไขข้อมูลของฟอร์มที่มีอยู่สำหรับแก้ไขวัตถุดิบ
        /// </summary>
        private void EditForm()
        {
            btnSubmit.Click += new System.EventHandler(this.btnEdit_Click);
            this.Text = "แก้ไขวัตถุดิบ";
            lblQuantity.Text = "จำนวน";
            btnSubmit.Text = "แก้ไข";
            cbDelete.Visible = true;
        }

        /// <summary>
        /// ใช้โหลดข้อมูลวัตถุดิบจากฐานข้อมูลมาแสดงและจัดการนำข้อมูลเข้าสู่ Textbox ที่ถูกต้อง
        /// </summary>
        /// <param name="item">ชื่อวัตถุดิบ</param>
        private void LoadIngredient(string item)
        {
            string[] data;
            data = myDB.SelectSpecifiedIngredient(item);
            txtIngredientName.Text = data[1];
            txtQuantity.Text = data[2];
            currentQuantity = int.Parse(data[2]);
            UnitIdToCheck(int.Parse(data[3]));
            TypeIdToCheck(int.Parse(data[0]));
            // You cannot edit name
            txtIngredientName.ReadOnly = true;
        }

        /// <summary>
        /// ใช้ตรวจสอบไอดีของหน่วยวัตถุดิบและนำไปติกให้ถูกต้อง
        /// </summary>
        /// <param name="unit">ไอดีของหน่วยวัตถุดิบ</param>
        private void UnitIdToCheck(int unit)
        {
            switch (unit)
            {
                case 10:
                    rdbFong.Checked = true;
                    break;
                case 11:
                    rdbGram.Checked = true;
                    break;
                case 12:
                    rdbTon.Checked = true;
                    break;
                case 13:
                    rdbHua.Checked = true;
                    break;
                case 14:
                    rdbLuk.Checked = true;
                    break;
                case 15:
                    rdbMud.Checked = true;
                    break;
                case 16:
                    rdbBundle.Checked = true;
                    break;
                case 17:
                    rdbGrain.Checked = true;
                    break;
            }
        }

        /// <summary>
        /// ใช้ตรวจสอบไอดีของประเภทวัตถุดิบและนำไปติกให้ถูกต้อง
        /// </summary>
        /// <param name="type">ไอดีของประเภทวัตถุดิบ</param>
        private void TypeIdToCheck(int type)
        {
            switch (type)
            {
                case 1:
                    rdbMeat.Checked = true;
                    break;
                case 2:
                    rdbVegetable.Checked = true;
                    break;
                case 3:
                    rdbFruit.Checked = true;
                    break;
            }
        }


        #endregion Helper method

        /// <summary>
        /// อีเว้นท์ของปุ่มสำหรับเพิ่มวัตถุดิบสู่ฐานข้อมูล
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int quantity;
            bool flag;

            if (txtIngredientName.Text.Length == 0)
            {
                MessageBox.Show("กรุณาใส่ชื่อวัตถุดิบ", "ข้อมูลไม่ครบถ้วน", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtIngredientName.Clear();
                txtIngredientName.Select();
                return;
            }

            flag = int.TryParse(txtQuantity.Text, out quantity);
            if (flag == false)
            {
                MessageBox.Show("กรุณาป้องจำนวนเป็นตัวเลข", "ข้อมูลผิดพลาด", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtQuantity.Clear();
                txtQuantity.Select();
                return;
            }

            if (myDB.InsertIngredient(CheckedToTypeID(), txtIngredientName.Text, quantity, UnitSelected()))
            {
                previousTask = Task.Add;
                Close();
            }
            else
            {
                string message = "พบข้อผิดพลาดกรุณาตรวจสอบว่า\nข้อมูลอาจถูกเพิ่มแล้ว\nมีข้อผิดพลาดอื่นๆ ในข้อมูลที่ถูกเพิ่ม";
                MessageBox.Show(message, "ข้อมูลซ้ำกัน", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtIngredientName.Clear();
                txtIngredientName.Select();
                return;
            }
        }

        /// <summary>
        /// อีเว้นของปุ่มสำหรับแก้ไขวัตถุดิบหรือลบวัตถุดิบออกจากฐานข้อมูล
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int quantity;
            quantity = int.Parse(txtQuantity.Text);

            // Delete case
            if (cbDelete.Checked)
            {
                if (myDB.DeleteIngredient(txtIngredientName.Text))
                {
                    previousTask = Task.Delete;
                    Close();
                }
                else
                {
                    return;
                }

            }
            else if (quantity == currentQuantity)
            {
                if (myDB.UpdateIngredient(CheckedToTypeID(), txtIngredientName.Text, quantity, UnitSelected()))
                {
                    previousTask = Task.Edit;
                    Close();
                }
                else
                {
                    return;
                }
            }
            // Increase(maybe edit other detail) case
            else
            {
                if (myDB.UpdateIngredient(CheckedToTypeID(), txtIngredientName.Text, quantity, UnitSelected()))
                {
                    currentName = txtIngredientName.Text;
                    previousTask = Task.Increase;
                    Close();
                }
                else
                {
                    return;
                }
            }
        }

        private void txtIngredientName_Click(object sender, EventArgs e)
        {
            txtIngredientName.SelectAll();
        }

        private void txtQuantity_Click(object sender, EventArgs e)
        {
            txtQuantity.SelectAll();
        }

        /// <summary>
        /// อีเว้นใช้ปิดฟอร์ม
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClose_Click(object sender, EventArgs e)
        {
            previousTask = Task.None;
            Close();
        }
    }
}
