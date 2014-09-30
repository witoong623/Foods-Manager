using System;
using System.Windows.Forms;
using System.IO;

namespace FoodsManagerExtension
{
    public enum IngredientType { Flavoring = 1, Meat, Vegetable, Fruit };
    public enum IngredientUnit { Fong = 10, Gram, Ton, Hua, Luk, Mud, Greb };
    public enum Task { None, Add, Edit, Delete, Made };
    /// <summary>
    /// This class use to collect all extension method
    /// </summary>
    static class Convert
    {
        /// <summary>
        /// Convert int unit to string 
        /// </summary>
        /// <param name="unit">The number that indicate unit string</param>
        /// <returns>Unit name in string format</returns>
        public static string ToIngredientUnitString(this int unit)
        {
            switch (unit)
            {
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
                    return "กลีบ";
            }
        }

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