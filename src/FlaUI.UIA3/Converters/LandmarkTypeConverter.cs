using System;
using FlaUI.Core.Definitions;
using UIA = Interop.UIAutomationClient;

namespace FlaUI.UIA3.Converters
{
    /// <summary>
    /// Converter with converts between <see cref="UIA.UIA_LandmarkTypeIds"/> and FlaUIs <see cref="LandmarkType"/>.
    /// </summary>
    public static class LandmarkTypeConverter
    {
        /// <summary>
        /// Converts a <see cref="UIA.UIA_LandmarkTypeIds"/> to a FlaUI <see cref="LandmarkType"/>.
        /// </summary>
        public static object ToLandmarkType(object nativeLandmarkType)
        {
            switch ((int)nativeLandmarkType)
            {
                case UIA.UIA_LandmarkTypeIds.UIA_CustomLandmarkTypeId:
                    return LandmarkType.CustomLandmark;
                case UIA.UIA_LandmarkTypeIds.UIA_FormLandmarkTypeId:
                    return LandmarkType.FormLandmark;
                case UIA.UIA_LandmarkTypeIds.UIA_MainLandmarkTypeId:
                    return LandmarkType.MainLandmark;
                case UIA.UIA_LandmarkTypeIds.UIA_NavigationLandmarkTypeId:
                    return LandmarkType.NavigationLandmark;
                case UIA.UIA_LandmarkTypeIds.UIA_SearchLandmarkTypeId:
                    return LandmarkType.SearchLandmark;
                default:
                    throw new NotSupportedException();
            }
        }

        /// <summary>
        /// Converts a FlaUI <see cref="LandmarkType"/> to a <see cref="UIA.UIA_LandmarkTypeIds"/>.
        /// </summary>
        public static object ToLandmarkTypeNative(LandmarkType landmarkType)
        {
            switch (landmarkType)
            {
                case LandmarkType.CustomLandmark:
                    return UIA.UIA_LandmarkTypeIds.UIA_CustomLandmarkTypeId;
                case LandmarkType.FormLandmark:
                    return UIA.UIA_LandmarkTypeIds.UIA_FormLandmarkTypeId;
                case LandmarkType.MainLandmark:
                    return UIA.UIA_LandmarkTypeIds.UIA_MainLandmarkTypeId;
                case LandmarkType.NavigationLandmark:
                    return UIA.UIA_LandmarkTypeIds.UIA_NavigationLandmarkTypeId;
                case LandmarkType.SearchLandmark:
                    return UIA.UIA_LandmarkTypeIds.UIA_SearchLandmarkTypeId;
                default:
                    throw new NotSupportedException();
            }
        }
    }
}
