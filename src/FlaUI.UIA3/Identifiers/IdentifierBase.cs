using System;
using System.Collections.Generic;

namespace FlaUI.UIA3.Identifiers
{
    /// <summary>
    /// Base class for wrappers around various identifiers
    /// </summary>
    public abstract class IdentifierBase
    {
        /// <summary>
        /// Dictionary which holds all known properties
        /// </summary>
        private static readonly Dictionary<int, PropertyId> PropertyDict = new Dictionary<int, PropertyId>();
        /// <summary>
        /// Dictionary which holds all known events
        /// </summary>
        private static readonly Dictionary<int, EventId> EventDict = new Dictionary<int, EventId>();
        /// <summary>
        /// Dictionary which holds all known patterns
        /// </summary>
        private static readonly Dictionary<int, PatternId> PatternDict = new Dictionary<int, PatternId>();
        /// <summary>
        /// Dictionary which holds all known text attributes
        /// </summary>
        private static readonly Dictionary<int, TextAttributeId> TextAttributeDict = new Dictionary<int, TextAttributeId>();

        /// <summary>
        /// The native id of the identifier
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// A readable name for the identifier
        /// </summary>
        public string Name { get; private set; }

        protected IdentifierBase(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return String.Format("{0} [#{1}]", Name, Id);
        }

        protected static PropertyId RegisterProperty(int id, string name)
        {
            return Register(id, name, PropertyDict, (i, s) => new PropertyId(i, s));
        }

        protected static EventId RegisterEvent(int id, string name)
        {
            return Register(id, name, EventDict, (i, s) => new EventId(i, s));
        }

        protected static PatternId RegisterPattern(int id, string name)
        {
            return Register(id, name, PatternDict, (i, s) => new PatternId(i, s));
        }

        protected static TextAttributeId RegisterTextAttribute(int id, string name)
        {
            return Register(id, name, TextAttributeDict, (i, s) => new TextAttributeId(i, s));
        }

        protected static PropertyId FindProperty(int id)
        {
            return PropertyDict.ContainsKey(id) ? PropertyDict[id] : new PropertyId(id, String.Format("Property#{0}", id));
        }

        protected static EventId FindEvent(int id)
        {
            return EventDict.ContainsKey(id) ? EventDict[id] : new EventId(id, String.Format("Event#{0}", id));
        }

        protected static PatternId FindPattern(int id)
        {
            return PatternDict.ContainsKey(id) ? PatternDict[id] : new PatternId(id, String.Format("Pattern#{0}", id));
        }

        protected static TextAttributeId FindTextAttribute(int id)
        {
            return TextAttributeDict.ContainsKey(id) ? TextAttributeDict[id] : new TextAttributeId(id, String.Format("TextAttribute#{0}", id));
        }

        private static T Register<T>(int id, string name, IDictionary<int, T> dict, Func<int, string, T> creator) where T : IdentifierBase
        {
            if (dict.ContainsKey(id))
            {
                return dict[id];
            }
            var newIdObject = creator(id, name);
            dict[id] = newIdObject;
            return newIdObject;
        }
    }
}
