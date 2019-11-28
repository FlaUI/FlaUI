using System;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;
using FlaUI.Core.WindowsAPI;
using System.Text;

namespace FlaUI.Core.AutomationElements.PatternElements
{
    /// <summary>
    /// Class for an element that supports the <see cref="ITogglePattern"/>.
    /// </summary>
    public class ToggleAutomationElement : AutomationElement
    {
        /// <summary>
        /// Creates an element with a <see cref="ITogglePattern"/>.
        /// </summary>
        public ToggleAutomationElement(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// The toggle pattern.
        /// </summary>
        public ITogglePattern TogglePattern => Patterns.Toggle.Pattern;

        /// <summary>
        /// Gets or sets the current toggle state.
        /// </summary>
        public ToggleState ToggleState
        {
            get
            {
                if (GetToggleStateWin32(out ToggleState state) == true)
                {
                    return state;
                }
                else
                {
                    return TogglePattern.ToggleState.Value;
                }
            }
            set
            {
                // Loop for all states
                /*for (var i = 0; i < Enum.GetNames(typeof(ToggleState)).Length; i++)
                {
                    // Break if we're in the correct state
                    if (ToggleState == value) return;
                    // Toggle to the next state
                    Toggle();
                }*/ // What is this loop used for? What is "i" used for?
                
                // Break if we're in the correct state
                if (ToggleState == value) return;
                // Toggle to the next state
                Toggle();
                
                // Break if UIA succeeded
                if (ToggleState == value) return;
                // try with Win32 methods
                SetToggleStateWin32(value);
            }
        }
        
        internal void SetToggleStateWin32(ToggleState state)
        {
            if (Properties.NativeWindowHandle.IsSupported)
            {
                var windowHandle = Properties.NativeWindowHandle.ValueOrDefault;
                if (windowHandle != IntPtr.Zero)
                {
                    StringBuilder className = new StringBuilder(256);
                    User32.GetClassName(windowHandle, className, 256);
                    
                    if (className.ToString() == "Button") // Common Win32 Checkbox window
                    {
                        IntPtr result = User32.SendMessage(windowHandle, ButtonMessages.BM_GETCHECK, IntPtr.Zero, IntPtr.Zero);
                    
                        if (state == ToggleState.On)
                        {
                            if (result.ToInt32() != (int)ButtonMessages.BST_CHECKED)
                            {
                                User32.SendMessage(windowHandle, ButtonMessages.BM_SETCHECK, new IntPtr(ButtonMessages.BST_CHECKED), IntPtr.Zero);
                            }
                        }
                        else if (state == ToggleState.Off)
                        {
                            if (result.ToInt32() != (int)ButtonMessages.BST_UNCHECKED)
                            {
                                User32.SendMessage(windowHandle, ButtonMessages.BM_SETCHECK, new IntPtr(ButtonMessages.BST_UNCHECKED), IntPtr.Zero);
                            }
                        }
                        else // indeterminate state
                        {
                            if (result.ToInt32() != (int)ButtonMessages.BST_INDETERMINATE)
                            {
                                User32.SendMessage(windowHandle, ButtonMessages.BM_SETCHECK, new IntPtr(ButtonMessages.BST_INDETERMINATE), IntPtr.Zero);
                            }
                        }
                    }
                }
            }
        }
        
        internal bool GetToggleStateWin32(out ToggleState stateOut)
        {
            stateOut = ToggleState.Off;
            if (Properties.NativeWindowHandle.IsSupported)
            {
                var windowHandle = Properties.NativeWindowHandle.ValueOrDefault;
                if (windowHandle != IntPtr.Zero)
                {
                    StringBuilder className = new StringBuilder(256);
                    User32.GetClassName(windowHandle, className, 256);
                            
                    if (className.ToString() == "Button")  // common Win32 checkbox window
                    {
                        IntPtr result = User32.SendMessage(windowHandle,
                            ButtonMessages.BM_GETCHECK, IntPtr.Zero, IntPtr.Zero);

                        if (result.ToInt32() == (int)ButtonMessages.BST_UNCHECKED)
                        {
                            stateOut = ToggleState.Off;
                        }
                        else if (result.ToInt32() == (int)ButtonMessages.BST_CHECKED)
                        {
                            stateOut = ToggleState.On;
                        }
                        else // indeterminate
                        {
                            stateOut = ToggleState.Indeterminate;
                        }
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /// Gets or sets if the element is toggled.
        /// </summary>
        public bool? IsToggled
        {
            get => ToggleStateToBool(ToggleState);
            set
            {
                if (IsToggled == value)
                {
                    return;
                }
                ToggleState = BoolToToggleState(value);
            }
        }

        /// <summary>
        /// Toggles the element.
        /// </summary>
        public virtual void Toggle()
        {
            TogglePattern.Toggle();
        }

        private bool? ToggleStateToBool(ToggleState toggleState)
        {
            switch (toggleState)
            {
                case ToggleState.Off:
                    return false;
                case ToggleState.On:
                    return true;
                case ToggleState.Indeterminate:
                    return null;
                default:
                    throw new ArgumentOutOfRangeException(nameof(toggleState));
            }
        }

        private ToggleState BoolToToggleState(bool? toggled)
        {
            switch (toggled)
            {
                case false:
                    return ToggleState.Off;
                case true:
                    return ToggleState.On;
                case null:
                    return ToggleState.Indeterminate;
                default:
                    throw new ArgumentOutOfRangeException(nameof(toggled));
            }
        }
    }
}
