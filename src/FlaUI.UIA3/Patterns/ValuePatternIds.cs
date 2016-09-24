using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FlaUI.Core;
using FlaUI.Core.Identifiers;

namespace FlaUI.UIA3.Patterns
{
    public static class ValuePatternIds
    {
        public static readonly PatternId Pattern = PatternId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PatternIds.UIA_ValuePatternId, "Value");
        public static readonly PropertyId IsReadOnlyProperty = PropertyId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PropertyIds.UIA_ValueIsReadOnlyPropertyId, "IsReadOnly");
        public static readonly PropertyId ValueProperty = PropertyId.Register(AutomationType.UIA3, interop.UIAutomationCore.UIA_PropertyIds.UIA_ValueValuePropertyId, "Value");

    }
}
