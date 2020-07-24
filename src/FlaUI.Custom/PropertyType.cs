using System;
using Interop.UIAutomationCore;

namespace FlaUI.Custom
{
    internal static class PropertyTypeHelper
    {
        public const int Array = 0x00010000;
        public const int Out = 0x00020000;

        internal static UIAutomationType ToNative(PropertyType type)
        {
            switch (type)
            {
                case PropertyType.Int:
                    return UIAutomationType.UIAutomationType_Int;
                case PropertyType.Bool:
                    return UIAutomationType.UIAutomationType_Bool;
                case PropertyType.String:
                    return UIAutomationType.UIAutomationType_String;
                case PropertyType.Double:
                    return UIAutomationType.UIAutomationType_Double;
                case PropertyType.Point:
                    return UIAutomationType.UIAutomationType_Point;
                case PropertyType.Rect:
                    return UIAutomationType.UIAutomationType_Rect;
                case PropertyType.Element:
                    return UIAutomationType.UIAutomationType_Element;
                case PropertyType.IntArray:
                    return UIAutomationType.UIAutomationType_IntArray;
                case PropertyType.BoolArray:
                    return UIAutomationType.UIAutomationType_BoolArray;
                case PropertyType.StringArray:
                    return UIAutomationType.UIAutomationType_StringArray;
                case PropertyType.DoubleArray:
                    return UIAutomationType.UIAutomationType_DoubleArray;
                case PropertyType.PointArray:
                    return UIAutomationType.UIAutomationType_PointArray;
                case PropertyType.RectArray:
                    return UIAutomationType.UIAutomationType_RectArray;
                case PropertyType.ElementArray:
                    return UIAutomationType.UIAutomationType_ElementArray;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }
        }
    }

    public enum PropertyType
    {
        Int = 0x0001,
        Bool = 0x0002,
        String = 0x0003,
        Double = 0x0004,
        Point = 0x0005,
        Rect = 0x0006,
        Element = 0x0007,

        IntArray = Int | PropertyTypeHelper.Array,
        BoolArray = Bool | PropertyTypeHelper.Array,
        StringArray = String | PropertyTypeHelper.Array,
        DoubleArray = Double | PropertyTypeHelper.Array,
        PointArray = Point | PropertyTypeHelper.Array,
        RectArray = Rect | PropertyTypeHelper.Array,
        ElementArray = Element | PropertyTypeHelper.Array,

        //OutInt = (Int | Out),
        //OutBool = (Bool | Out),
        //OutString = (String | Out),
        //OutDouble = (Double | Out),
        //OutPoint = (Point | Out),
        //OutRect = (Rect | Out),
        //OutElement = (Element | Out),

        //OutIntArray = (Int | Array | Out),
        //OutBoolArray = (Bool | Array | Out),
        //OutStringArray = (String | Array | Out),
        //OutDoubleArray = (Double | Array | Out),
        //OutPointArray = (Point | Array | Out),
        //OutRectArray = (Rect | Array | Out),
        //OutElementArray = (Element | Array | Out),
    }
}
