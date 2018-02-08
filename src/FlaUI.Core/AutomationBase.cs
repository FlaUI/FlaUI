using System;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Overlay;
using FlaUI.Core.Shapes;

namespace FlaUI.Core
{
    /// <summary>
    /// Base class for the native automation object.
    /// </summary>
    public abstract class AutomationBase : IDisposable
    {
        protected AutomationBase(IPropertyLibrary propertyLibrary, IEventLibrary eventLibrary, IPatternLibrary patternLibrary)
        {
            PropertyLibrary = propertyLibrary;
            EventLibrary = eventLibrary;
            PatternLibrary = patternLibrary;
            ConditionFactory = new ConditionFactory(propertyLibrary);
            OverlayManager = new WinFormsOverlayManager();
            // Make sure all pattern ids are initialized
            var unused = PatternLibrary.AllForCurrentFramework;
        }

        /// <summary>
        /// Provides a library with the existing <see cref="PropertyId"/>s.
        /// </summary>
        public IPropertyLibrary PropertyLibrary { get; }

        /// <summary>
        /// Provides a library with the existing <see cref="EventId"/>s.
        /// </summary>
        public IEventLibrary EventLibrary { get; }

        /// <summary>
        /// Provides a library with the existing <see cref="PatternId"/>s.
        /// </summary>
        public IPatternLibrary PatternLibrary { get; }

        /// <summary>
        /// Provides a factory to create conditions for searching.
        /// </summary>
        public ConditionFactory ConditionFactory { get; }

        /// <summary>
        /// Provides a manager for displaying overlays.
        /// </summary>
        public IOverlayManager OverlayManager { get; }

        /// <summary>
        /// Provides a factory to create <see cref="ITreeWalker"/>s.
        /// </summary>
        public abstract ITreeWalkerFactory TreeWalkerFactory { get; }

        /// <summary>
        /// The <see cref="AutomationType"/> of the automation implementation.
        /// </summary>
        public abstract AutomationType AutomationType { get; }

        /// <summary>
        /// Object which represents the "Not Supported" value.
        /// </summary>
        public abstract object NotSupportedValue { get; }

        /// <summary>
        /// Specifies the length of time that UI Automation will wait for a provider to respond to a client request for information about an automation element.
        /// </summary>
        public abstract TimeSpan TransactionTimeout { get; set; }

        /// <summary>
        /// Specifies the length of time that UI Automation will wait for a provider to respond to a client request for an automation element.
        /// </summary>
        public abstract TimeSpan ConnectionTimeout { get; set; }

        /// <summary>
        /// Gets the desktop (root) element.
        /// </summary>
        public abstract AutomationElement GetDesktop();

        /// <summary>
        /// Creates an <see cref="AutomationElement" /> from a given point.
        /// </summary>
        public abstract AutomationElement FromPoint(Point point);

        /// <summary>
        /// Creates an <see cref="AutomationElement" /> from a given windows handle (HWND).
        /// </summary>
        public abstract AutomationElement FromHandle(IntPtr hwnd);

        /// <summary>
        /// Gets the currently focused element as an <see cref="AutomationElement"/>.
        /// </summary>
        /// <returns></returns>
        public abstract AutomationElement FocusedElement();

        /// <summary>
        /// Registers for a focus changed event.
        /// </summary>
        public abstract FocusChangedEventHandlerBase RegisterFocusChangedEvent(Action<AutomationElement> action);

        /// <summary>
        /// Unregisters the given focus changed event handler.
        /// </summary>
        public abstract void UnregisterFocusChangedEvent(FocusChangedEventHandlerBase eventHandler);

        /// <summary>
        /// Removes all registered event handlers.
        /// </summary>
        public abstract void UnregisterAllEvents();

        /// <summary>
        /// Compares two automation elements for equality.
        /// </summary>
        public abstract bool Compare(AutomationElement element1, AutomationElement element2);

        /// <summary>
        /// Cleans up the resources.
        /// </summary>
        public void Dispose()
        {
            UnregisterAllEvents();
            OverlayManager.Dispose();
        }
    }
}
