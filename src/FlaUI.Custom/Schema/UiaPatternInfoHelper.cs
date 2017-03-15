using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using Interop.UIAutomationCore;

namespace ManagedUiaCustomizationCore
{
    /// <summary>
    /// Helper class to assemble information about a custom pattern.
    /// Corresponds to UIAutomationPatternInfo
    /// </summary>
    public class UiaPatternInfoHelper
    {
        private readonly Guid _patternGuid;
        private readonly Guid _clientInterfaceId;
        private readonly Guid _providerInterfaceId;
        private readonly string _programmaticName;
        private readonly IUIAutomationPatternHandler _patternHandler;
        private readonly List<UiaMethodInfoHelper> _methods = new List<UiaMethodInfoHelper>();
        private readonly List<UiaPropertyInfoHelper> _properties = new List<UiaPropertyInfoHelper>();
        private readonly List<UiaEventInfoHelper> _events = new List<UiaEventInfoHelper>();

        private bool _built;
        private UIAutomationPatternInfo _data;

        public UiaPatternInfoHelper(Guid patternGuid,
                                    string programmaticName,
                                    Guid clientInterfaceId,
                                    Guid providerInterfaceId,
                                    IUIAutomationPatternHandler patternHandler)
        {
            _programmaticName = programmaticName;
            _patternGuid = patternGuid;
            _clientInterfaceId = clientInterfaceId;
            _providerInterfaceId = providerInterfaceId;
            _patternHandler = patternHandler;
        }

        ~UiaPatternInfoHelper()
        {
            Marshal.FreeCoTaskMem(_data.pMethods);
            Marshal.FreeCoTaskMem(_data.pEvents);
            Marshal.FreeCoTaskMem(_data.pProperties);
        }

        /// <summary>
        /// Get a marshalled UIAutomationPatternInfo struct for this Helper.
        /// </summary>
        public UIAutomationPatternInfo Data
        {
            get
            {
                if (!_built)
                {
                    Build();
                }
                return _data;
            }
        }

        /// <summary>
        /// Add a property to this pattern
        /// </summary>
        /// <param name="property"></param>
        public void AddProperty(UiaPropertyInfoHelper property)
        {
            _properties.Add(property);
        }

        /// <summary>
        /// Add a method to this pattern
        /// </summary>
        /// <param name="method"></param>
        public void AddMethod(UiaMethodInfoHelper method)
        {
            _methods.Add(method);
        }

        /// <summary>
        /// Add an event to this pattern
        /// </summary>
        /// <param name="eventHelper"></param>
        public void AddEvent(UiaEventInfoHelper eventHelper)
        {
            _events.Add(eventHelper);
        }

        private void Build()
        {
            // Basic data
            _data = new UIAutomationPatternInfo
                    {
                        pProgrammaticName = _programmaticName,
                        guid = _patternGuid,
                        clientInterfaceId = _clientInterfaceId,
                        providerInterfaceId = _providerInterfaceId,
                        pPatternHandler = _patternHandler,
                        cMethods = (uint) _methods.Count
                    };

            // Build the list of methods
            if (_data.cMethods > 0)
            {
                _data.pMethods = Marshal.AllocCoTaskMem((int) (_data.cMethods*Marshal.SizeOf(typeof (UIAutomationMethodInfo))));
                var methodPointer = _data.pMethods;
                for (var i = 0; i < _data.cMethods; ++i)
                {
                    Marshal.StructureToPtr(_methods[i].Data, methodPointer, false);
                    methodPointer = (IntPtr) (methodPointer.ToInt64() + Marshal.SizeOf(typeof (UIAutomationMethodInfo)));
                }
            }
            else
            {
                _data.pMethods = IntPtr.Zero;
            }

            // Build the list of properties
            _data.cProperties = (uint) _properties.Count;
            if (_data.cProperties > 0)
            {
                _data.pProperties = Marshal.AllocCoTaskMem((int) (_data.cProperties*Marshal.SizeOf(typeof (UIAutomationPropertyInfo))));
                var propertyPointer = _data.pProperties;
                for (var i = 0; i < _data.cProperties; ++i)
                {
                    Marshal.StructureToPtr(_properties[i].Data, propertyPointer, false);
                    propertyPointer = (IntPtr) (propertyPointer.ToInt64() + Marshal.SizeOf(typeof (UIAutomationPropertyInfo)));
                }
            }
            else
            {
                _data.pProperties = IntPtr.Zero;
            }

            // Build the list of events
            _data.cEvents = (uint) _events.Count;
            if (_data.cEvents > 0)
            {
                _data.pEvents = Marshal.AllocCoTaskMem((int) (_data.cEvents*Marshal.SizeOf(typeof (UIAutomationEventInfo))));
                var eventPointer = _data.pEvents;
                for (var i = 0; i < _data.cEvents; ++i)
                {
                    Marshal.StructureToPtr(_events[i].Data, eventPointer, false);
                    eventPointer = (IntPtr) (eventPointer.ToInt64() + Marshal.SizeOf(typeof (UIAutomationEventInfo)));
                }
            }
            else
            {
                _data.pEvents = IntPtr.Zero;
            }

            _built = true;
        }
    }
}