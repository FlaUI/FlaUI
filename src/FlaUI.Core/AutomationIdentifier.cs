using System;
using System.Collections.Generic;

namespace FlaUI.Core
{
    /// <summary>
    /// Base class for wrappers around various identifiers
    /// </summary>
    public abstract class AutomationIdentifier
    {
        /// <summary>
        /// Dictionary which holds all known properties
        /// </summary>
        private static readonly Dictionary<int, AutomationProperty> PropertyDict = new Dictionary<int, AutomationProperty>();
        /// <summary>
        /// Dictionary which holds all known events
        /// </summary>
        private static readonly Dictionary<int, AutomationEvent> EventDict = new Dictionary<int, AutomationEvent>();
        /// <summary>
        /// Dictionary which holds all known patterns
        /// </summary>
        private static readonly Dictionary<int, AutomationPattern> PatternDict = new Dictionary<int, AutomationPattern>();
        /// <summary>
        /// Dictionary which holds all known text attributes
        /// </summary>
        private static readonly Dictionary<int, AutomationTextAttribute> TextAttributeDict = new Dictionary<int, AutomationTextAttribute>();

        /// <summary>
        /// The native id of the identifier
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// A readable name for the identifier
        /// </summary>
        public string Name { get; private set; }

        protected AutomationIdentifier(int id, string name)
        {
            Id = id;
            Name = name;
        }

        protected static AutomationProperty RegisterProperty(int id, string name)
        {
            if (PropertyDict.ContainsKey(id))
            {
                return PropertyDict[id];
            }
            var newIdObject = new AutomationProperty(id, name);
            PropertyDict[id] = newIdObject;
            return newIdObject;
        }

        protected static AutomationEvent RegisterEvent(int id, string name)
        {
            if (EventDict.ContainsKey(id))
            {
                return EventDict[id];
            }
            var newIdObject = new AutomationEvent(id, name);
            EventDict[id] = newIdObject;
            return newIdObject;
        }

        protected static AutomationPattern RegisterPattern(int id, string name)
        {
            if (PatternDict.ContainsKey(id))
            {
                return PatternDict[id];
            }
            var newIdObject = new AutomationPattern(id, name);
            PatternDict[id] = newIdObject;
            return newIdObject;
        }

        protected static AutomationTextAttribute RegisterTextAttribute(int id, string name)
        {
            if (TextAttributeDict.ContainsKey(id))
            {
                return TextAttributeDict[id];
            }
            var newIdObject = new AutomationTextAttribute(id, name);
            TextAttributeDict[id] = newIdObject;
            return newIdObject;
        }

        protected static AutomationProperty FindProperty(int id)
        {
            if (PropertyDict.ContainsKey(id))
            {
                return PropertyDict[id];
            }
            return new AutomationProperty(id, String.Format("Property#{0}", id));
        }

        protected static AutomationEvent FindEvent(int id)
        {
            if (EventDict.ContainsKey(id))
            {
                return EventDict[id];
            }
            return new AutomationEvent(id, String.Format("Event#{0}", id));
        }

        protected static AutomationPattern FindPattern(int id)
        {
            if (PatternDict.ContainsKey(id))
            {
                return PatternDict[id];
            }
            return new AutomationPattern(id, String.Format("Pattern#{0}", id));
        }

        protected static AutomationTextAttribute FindTextAttribute(int id)
        {
            if (TextAttributeDict.ContainsKey(id))
            {
                return TextAttributeDict[id];
            }
            return new AutomationTextAttribute(id, String.Format("TextAttribute#{0}", id));
        }

        public override string ToString()
        {
            return String.Format("{0}: {1}", Id, Name);
        }
    }
}
