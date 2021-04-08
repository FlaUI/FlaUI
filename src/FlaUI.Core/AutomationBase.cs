using System;
using System.Drawing;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Conditions;
using FlaUI.Core.Definitions;
using FlaUI.Core.EventHandlers;
using FlaUI.Core.Identifiers;
using FlaUI.Core.Overlay;

namespace FlaUI.Core
{
    /// <summary>
    /// Base class for the native automation object.
    /// </summary>
    public abstract class AutomationBase : IDisposable
    {
        /// <summary>
        /// Creates a new <see cref="AutomationBase"/> instance.
        /// </summary>
        /// <param name="propertyLibrary">The property library to use.</param>
        /// <param name="eventLibrary">The event library to use.</param>
        /// <param name="patternLibrary">The pattern library to use.</param>
        /// <param name="textAttributeLibrary">The text attribute library to use.</param>
        protected AutomationBase(IPropertyLibrary propertyLibrary, IEventLibrary eventLibrary, IPatternLibrary patternLibrary, ITextAttributeLibrary textAttributeLibrary)
        {
            PropertyLibrary = propertyLibrary;
            EventLibrary = eventLibrary;
            PatternLibrary = patternLibrary;
            TextAttributeLibrary = textAttributeLibrary;
            ConditionFactory = new ConditionFactory(propertyLibrary);
#if NETSTANDARD
            OverlayManager = new NullOverlayManager();
#else
            OverlayManager = new WinFormsOverlayManager();
#endif
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
        /// Provides a library with the existing <see cref="TextAttributeId"/>s.
        /// </summary>
        public ITextAttributeLibrary TextAttributeLibrary { get; }

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
        /// Object which represents a mixed attribute value in a textpattern.
        /// For example if the text contains multiple fonts, the FontName attribute will return this value.
        /// </summary>
        public abstract object MixedAttributeValue { get; }

        /// <summary>
        /// Specifies the length of time that UI Automation will wait for a provider to respond to a client request for information about an automation element.
        /// The default is 20 seconds.
        /// </summary>
        public abstract TimeSpan TransactionTimeout { get; set; }

        /// <summary>
        /// Specifies the length of time that UI Automation will wait for a provider to respond to a client request for an automation element.
        /// The default is two seconds.
        /// </summary>
        public abstract TimeSpan ConnectionTimeout { get; set; }

        /// <summary>
        /// Indicates whether an accessible technology client adjusts provider request timeouts when the provider is non-responsive.
        /// </summary>
        public abstract ConnectionRecoveryBehaviorOptions ConnectionRecoveryBehavior { get; set; }

        /// <summary>
        /// Gets or sets whether an accessible technology client receives all events, or a subset where duplicate events are detected and filtered.
        /// </summary>
        public abstract CoalesceEventsOptions CoalesceEvents { get; set; }

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
