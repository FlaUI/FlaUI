using System;
using Interop.UIAutomationCore;

namespace ManagedUiaCustomizationCore
{
    /// <summary>
    /// Helper class to gather data about a custom event
    /// Corresponds to UIAutomationEventInfo.
    /// </summary>
    public class UiaEventInfoHelper
    {
        private readonly Guid _eventGuid;
        private readonly string _programmaticName;
        private bool _built;
        private UIAutomationEventInfo _data;

        public UiaEventInfoHelper(Guid eventGuid, string programmaticName)
        {
            _programmaticName = programmaticName;
            _eventGuid = eventGuid;
        }

        /// <summary>
        /// Get a marshalled UIAutomationEventInfo struct for this Helper.
        /// </summary>
        public UIAutomationEventInfo Data
        {
            get
            {
                if (!_built)
                    Build();
                return _data;
            }
        }

        /// <summary>
        /// The unique identifier of this event
        /// </summary>
        public Guid Guid
        {
            get { return _eventGuid; }
        }

        /// <summary>
        /// The event ID of this event, assigned after registration
        /// </summary>
        public int EventId { get; set; }

        private void Build()
        {
            _data = new UIAutomationEventInfo {pProgrammaticName = _programmaticName, guid = _eventGuid};
            _built = true;
        }
    }
}