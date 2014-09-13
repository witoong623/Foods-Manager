﻿using System;

namespace FoodsManager
{
    public enum IngredientType { Flavoring = 1, Meat, Vegetable, Fruit };
    public enum IngredientUnit { Fong = 10, Gram, Ton, Hua, Luk, Mud, Greb}

    /// <summary>
    /// Specifies weather form use to add or edit
    /// </summary>
    public enum DisplayMode { Addition, Editor };

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
        public static string ToUnitString(this int unit)
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
    }
}