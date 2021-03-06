﻿using System;
using System.Windows.Forms;
using System.IO;

namespace FoodsManager
{
    public enum Task { None, Add, Edit, Delete, Made, Increase };
    public enum Stock { InStock, OutOfStock };

    static class FoodsManagerConvert
    {
        /// <summary>
        /// เปลี่ยนไอดีของหน่วยวัตถุดิบเป็นตัวหนังสือ
        /// </summary>
        /// <param name="unit">ไอดีของหน่วยวัตถุดิบ</param>
        /// <returns>หน่วยของวัตถุดิบเป็นตัวอักษร</returns>
        public static string ToIngredientUnitString(this int unit)
        {
            switch (unit)
            {
                case 0:
                    return "ไม่มีวัตถุดิบนี้";
                case 10:
                    return "ฟอง";
                case 11:
                    return "กรัม";
                case 12:
                    return "ต้น";
                case 13:
                    return "หัว";
                case 14:
                    return "ลูก";
                case 15:
                    return "มัด";
                default:
                    return "ห่อ";
            }
        }

        /// <summary>
        /// เปลี่ยนไอดีของหน่วยอาหารเป็นตัวหนักสือ
        /// </summary>
        /// <param name="unit">ไอดีของหน่วยอาหาร</param>
        /// <returns>หน่วยอาหารเป็นตัวหนังสือ</returns>
        public static string ToRecipeUnitString(this int unit)
        {
            switch (unit)
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
                default:
                    return "รหัสหน่วยผิดพลาด";
            }
        }
    }
}