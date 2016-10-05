﻿using FlaUI.Core.Conditions;
using FlaUI.Core.Elements.Infrastructure;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Overlay;
using FlaUI.Core.Shapes;
using System;

namespace FlaUI.Core
{
    /// <summary>
    /// Base class for the native automation object
    /// </summary>
    public abstract class AutomationBase : IDisposable
    {
        protected AutomationBase(IPropertyLibray propertyLibrary)
        {
            OverlayManager = new OverlayManager();
            PropertyLibrary = propertyLibrary;
            ConditionFactory = new ConditionFactory(propertyLibrary);
        }

        public OverlayManager OverlayManager { get; }

        public ConditionFactory ConditionFactory { get; }

        public IPropertyLibray PropertyLibrary { get; }

        /// <summary>
        /// The automation type of the automation implementation
        /// </summary>
        public abstract AutomationType AutomationType { get; }

        /// <summary>
        /// Object which represents the "Not Supported" value
        /// </summary>
        public abstract object NotSupportedValue { get; }

        public abstract AutomationElement GetDesktop();

        /// <summary>
        /// Creates an <see cref="AutomationElement"/> from a given point
        /// </summary>
        public abstract AutomationElement FromPoint(Point point);

        /// <summary>
        /// Creates an <see cref="AutomationElement"/> from a given windows handle (HWND)
        /// </summary>
        public abstract AutomationElement FromHandle(IntPtr hwnd);

        public abstract AutomationElement FocusedElement();

        public abstract IAutomationFocusChangedEventHandler RegisterFocusChangedEvent(Action<AutomationElement> action);

        public abstract void UnRegisterFocusChangedEvent(IAutomationFocusChangedEventHandler eventHandler);

        /// <summary>
        /// Removes all registered event handlers
        /// </summary>
        public abstract void UnregisterAllEvents();

        /// <summary>
        /// Cleans up the resources
        /// </summary>
        public void Dispose()
        {
            UnregisterAllEvents();
            OverlayManager.Dispose();
        }
    }
}
