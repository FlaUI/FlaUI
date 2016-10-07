using System;
using System.Collections;
using System.Collections.Generic;

namespace FlaUI.Core.Identifiers
{
    /// <summary>
    /// Base class for wrappers around various identifiers
    /// </summary>
    public abstract class IdentifierBase
    {
        /// <summary>
        /// Class which capsules all identifiers which can be used for an automation library
        /// </summary>
        private class IdentifiersHolder
        {
            /// <summary>
            /// Dictionary which holds all known properties
            /// </summary>
            public readonly Dictionary<int, PropertyId> PropertyDict = new Dictionary<int, PropertyId>();

            /// <summary>
            /// Dictionary which holds all known events
            /// </summary>
            public readonly Dictionary<int, EventId> EventDict = new Dictionary<int, EventId>();

            /// <summary>
            /// Dictionary which holds all known patterns
            /// </summary>
            public readonly Dictionary<int, PatternId> PatternDict = new Dictionary<int, PatternId>();

            /// <summary>
            /// Dictionary which holds all known text attributes
            /// </summary>
            public readonly Dictionary<int, TextAttributeId> TextAttributeDict = new Dictionary<int, TextAttributeId>();
        }

        /// <summary>
        /// Dictionary which holds all identifiers for each automation library
        /// </summary>
        private static readonly Dictionary<AutomationType, IdentifiersHolder> IdentifiersDict = new Dictionary<AutomationType, IdentifiersHolder>();

        /// <summary>
        /// The native id of the identifier
        /// </summary>
        public int Id { get; }

        /// <summary>
        /// A readable name for the identifier
        /// </summary>
        public string Name { get; }

        protected IdentifierBase(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public override string ToString()
        {
            return String.Format("{0} [#{1}]", Name, Id);
        }

        protected static PropertyId RegisterProperty(AutomationType automationType, int id, string name)
        {
            var idsHolder = GetIdHolder(automationType);
            return Register(id, idsHolder.PropertyDict, () => new PropertyId(id, name));
        }

        protected static EventId RegisterEvent(AutomationType automationType, int id, string name)
        {
            var idsHolder = GetIdHolder(automationType);
            return Register(id, idsHolder.EventDict, () => new EventId(id, name));
        }

        protected static PatternId RegisterPattern(AutomationType automationType, int id, string name)
        {
            var idsHolder = GetIdHolder(automationType);
            return Register(id, idsHolder.PatternDict, () => new PatternId(id, name));
        }

        protected static TextAttributeId RegisterTextAttribute(AutomationType automationType, int id, string name)
        {
            var idsHolder = GetIdHolder(automationType);
            return Register(id, idsHolder.TextAttributeDict, () => new TextAttributeId(id, name));
        }

        protected static PropertyId FindProperty(AutomationType automationType, int id)
        {
            var idsHolder = GetIdHolder(automationType);
            return idsHolder.PropertyDict.ContainsKey(id) ? idsHolder.PropertyDict[id] : new PropertyId(id, String.Format("Property#{0}", id));
        }

        protected static EventId FindEvent(AutomationType automationType, int id)
        {
            var idsHolder = GetIdHolder(automationType);
            return idsHolder.EventDict.ContainsKey(id) ? idsHolder.EventDict[id] : new EventId(id, String.Format("Event#{0}", id));
        }

        protected static PatternId FindPattern(AutomationType automationType, int id)
        {
            var idsHolder = GetIdHolder(automationType);
            return idsHolder.PatternDict.ContainsKey(id) ? idsHolder.PatternDict[id] : new PatternId(id, String.Format("Pattern#{0}", id));
        }

        protected static TextAttributeId FindTextAttribute(AutomationType automationType, int id)
        {
            var idsHolder = GetIdHolder(automationType);
            return idsHolder.TextAttributeDict.ContainsKey(id) ? idsHolder.TextAttributeDict[id] : new TextAttributeId(id, String.Format("TextAttribute#{0}", id));
        }

        /// <summary>
        /// Adds the property to the dictionary if it does not exist yet
        /// </summary>
        private static T Register<T>(int commonId, IDictionary<int, T> dict, Func<T> creator)
        {
            if (dict.ContainsKey(commonId))
            {
                return dict[commonId];
            }
            var newIdObject = creator();
            dict[commonId] = newIdObject;
            return newIdObject;
        }

        /// <summary>
        /// Get the ids-holder or create a new one
        /// </summary>
        private static IdentifiersHolder GetIdHolder(AutomationType automationType)
        {
            // ReSharper disable InconsistentlySynchronizedField This is on purpose to speed this thing up
            if (!IdentifiersDict.ContainsKey(automationType))
            {
                // Lock to have thread safety
                lock (((IDictionary)IdentifiersDict).SyncRoot)
                {
                    // Double check in case someone already added it while aquiring the lock
                    if (!IdentifiersDict.ContainsKey(automationType))
                    {
                        IdentifiersDict.Add(automationType, new IdentifiersHolder());
                    }
                }
            }
            return IdentifiersDict[automationType];
            // ReSharper restore InconsistentlySynchronizedField
        }
    }
}
