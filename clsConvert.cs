using System;
namespace FoodsManager
{
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