﻿using FlaUI.Core.Definitions;
using FlaUI.Core.Elements.Infrastructure;

namespace FlaUI.Core.EventHandlers
{
    public interface IAutomationStructureChangedEventHandler
    {
        void HandleStructureChangedEvent(AutomationElement sender, StructureChangeType changeType, int[] runtimeId);
    }
}
