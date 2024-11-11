﻿using System;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Exceptions;
using FlaUI.UIA2.Converters;
using FlaUI.UIA2.EventHandlers;
using FlaUI.UIA2.Extensions;
using UIA = System.Windows.Automation;

namespace FlaUI.UIA2
{
    /// <summary>
    /// Automation implementation for UIA2.
    /// </summary>
    public class UIA2Automation : AutomationBase
    {
        public UIA2Automation() : base(new UIA2PropertyLibrary(), new UIA2EventLibrary(), new UIA2PatternLibrary(), new UIA2TextAttributeLibrary())
        {
            TreeWalkerFactory = new UIA2TreeWalkerFactory(this);
        }

        /// <inheritdoc />
        public override ITreeWalkerFactory TreeWalkerFactory { get; }

        /// <inheritdoc />
        public override AutomationType AutomationType => AutomationType.UIA2;

        /// <inheritdoc />
        public override object NotSupportedValue => UIA.AutomationElement.NotSupported;

        /// <inheritdoc />
        public override object MixedAttributeValue => UIA.TextPattern.MixedAttributeValue;

        /// <inheritdoc />
        public override TimeSpan TransactionTimeout
        {
            get => throw new NotSupportedByFrameworkException();
            set => throw new NotSupportedByFrameworkException();
        }

        /// <inheritdoc />
        public override TimeSpan ConnectionTimeout
        {
            get => throw new NotSupportedByFrameworkException();
            set => throw new NotSupportedByFrameworkException();
        }

        /// <inheritdoc />
        public override ConnectionRecoveryBehaviorOptions ConnectionRecoveryBehavior
        {
            get => throw new NotSupportedByFrameworkException();
            set => throw new NotSupportedByFrameworkException();
        }

        /// <inheritdoc />
        public override CoalesceEventsOptions CoalesceEvents
        {
            get => throw new NotSupportedByFrameworkException();
            set => throw new NotSupportedByFrameworkException();
        }

        /// <inheritdoc />
        public override AutomationElement GetDesktop()
        {
            var nativeElement = InternalGetNativeElement(() => UIA.AutomationElement.RootElement);
            return AutomationElementConverter.NativeToManaged(this, nativeElement);
        }

        /// <inheritdoc />
        public override AutomationElement FromPoint(Point point)
        {
            var nativeElement = InternalGetNativeElement(() => UIA.AutomationElement.FromPoint(new System.Windows.Point(point.X, point.Y)));
            return AutomationElementConverter.NativeToManaged(this, nativeElement);
        }

        /// <inheritdoc />
        public override AutomationElement FromHandle(IntPtr hwnd)
        {
            var nativeElement = InternalGetNativeElement(() => UIA.AutomationElement.FromHandle(hwnd));
            return AutomationElementConverter.NativeToManaged(this, nativeElement);
        }

        /// <inheritdoc />
        public override AutomationElement FocusedElement()
        {
            var nativeElement = InternalGetNativeElement(() => UIA.AutomationElement.FocusedElement);
            return AutomationElementConverter.NativeToManaged(this, nativeElement);
        }

        /// <inheritdoc />
        public override FocusChangedEventHandlerBase RegisterFocusChangedEvent(Action<AutomationElement> action)
        {
            var eventHandler = new UIA2FocusChangedEventHandler(this, action);
            UIA.Automation.AddAutomationFocusChangedEventHandler(eventHandler.EventHandler);
            return eventHandler;
        }

        /// <inheritdoc />
        public override void UnregisterFocusChangedEvent(FocusChangedEventHandlerBase eventHandler)
        {
            UIA.Automation.RemoveAutomationFocusChangedEventHandler(((UIA2FocusChangedEventHandler)eventHandler).EventHandler);
        }

        /// <inheritdoc />
        public override void UnregisterAllEvents()
        {
            UIA.Automation.RemoveAllEventHandlers();
        }

        /// <inheritdoc />
        public override bool Compare(AutomationElement element1, AutomationElement element2)
        {
            return UIA.Automation.Compare(element1.ToNative(), element2.ToNative());
        }
        
        [return: NotNullIfNotNull(nameof(nativeElement))]
        public AutomationElement? WrapNativeElement(UIA.AutomationElement? nativeElement)
        {
            return nativeElement == null ? null : new AutomationElement(new UIA2FrameworkAutomationElement(this, nativeElement));
        }

        /// <summary>
        /// Gets the native element according to the passed action. Uses caching if it is active.
        /// </summary>
        private UIA.AutomationElement InternalGetNativeElement(Func<UIA.AutomationElement> getAction)
        {
            if (!CacheRequest.IsCachingActive)
            {
                return getAction();
            }
            var cacheRequest = CacheRequest.Current.ToNative();
            using (cacheRequest.Activate())
            {
                return getAction();
            }
        }
    }
}
