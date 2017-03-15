using System;
using System.Collections.Generic;
using Interop.UIAutomationCore;

namespace ManagedUiaCustomizationCore
{
    /// <summary>
    /// Base class for defining a custom schema.
    /// Responsible for defining the minimum info for a custom schema and
    /// registering it with UI Automation.
    /// This class is not required by UIA and doesn't correspond to anything in UIA;
    /// it's a personal preference about the right way to represent what is similar
    /// between various schemas and what varies.
    /// </summary>
    public abstract class CustomPatternSchemaBase
    {
        private readonly Dictionary<uint, ISchemaMember> _members = new Dictionary<uint, ISchemaMember>();
        private int _patternId;
        private int _patternAvailablePropertyId;
        private bool _registered;

        // The abstract properties define the minimal data needed to express
        // a custom pattern.

        /// <summary>
        /// The list of properties for this pattern.
        /// </summary>
        public abstract UiaPropertyInfoHelper[] Properties { get; }

        /// <summary>
        /// It is just a convenient shortcut. Because UIA on Win7 has a bug which doesn't allow
        /// to register more than two custom properties for given custom pattern, some properties
        /// that ideally should belong to pattern would be registered standalone. This is the list
        /// of such properties.
        /// </summary>
        public virtual UiaPropertyInfoHelper[] StandaloneProperties
        {
            get { return null; }
        }

        /// <summary>
        /// The list of methods for this pattern.
        /// </summary>
        public abstract UiaMethodInfoHelper[] Methods { get; }

        /// <summary>
        /// The list of events for this pattern.
        /// </summary>
        public abstract UiaEventInfoHelper[] Events { get; }

        /// <summary>
        /// The unique ID for this pattern.
        /// </summary>
        public abstract Guid PatternGuid { get; }

        /// <summary>
        /// The interface ID for the COM interface for this pattern on the client side.
        /// </summary>
        public virtual Guid PatternClientGuid
        {
            get { return PatternClientInterface.GUID; }
        }

        /// <summary>
        /// The interface ID for the COM interface for this pattern on the provider side.
        /// </summary>
        public virtual Guid PatternProviderGuid
        {
            get { return PatternProviderInterface.GUID; }
        }

        /// <summary>
        /// The programmatic name for this pattern.
        /// </summary>
        public abstract string PatternName { get; }

        /// <summary>
        /// Type of the provider interface
        /// </summary>
        public abstract Type PatternProviderInterface { get; }

        /// <summary>
        /// Type of the client-side interface
        /// </summary>
        public abstract Type PatternClientInterface { get; }

        /// <summary>
        /// An object that implements IUIAutomationPatternHandler to handle
        /// dispatching and client-pattern creation for this pattern
        /// </summary>
        public abstract IUIAutomationPatternHandler Handler { get; }

        /// <summary>
        /// The assigned ID for this pattern.
        /// </summary>
        public int PatternId
        {
            get { return _patternId; }
        }

        /// <summary>
        /// The assigned ID for the IsXxxxPatternAvailable property.
        /// </summary>
        public int PatternAvailablePropertyId
        {
            get { return _patternAvailablePropertyId; }
        }

        /// <summary>
        /// Helper method to register this pattern.
        /// </summary>
        public void Register()
        {
            if (_registered) return;

            // Get our pointer to the registrar
            IUIAutomationRegistrar registrar = new CUIAutomationRegistrarClass();

            // Set up the pattern struct
            var patternInfo = new UiaPatternInfoHelper(PatternGuid,
                                                       PatternName,
                                                       PatternClientGuid,
                                                       PatternProviderGuid,
                                                       Handler);

            // Populate it with properties and methods
            uint index = 0;
            foreach (var propertyInfo in Properties)
            {
                patternInfo.AddProperty(propertyInfo);
                propertyInfo.Index = index++;
                if (propertyInfo.SupportsDispatch)
                    _members[propertyInfo.Index] = propertyInfo;
            }
            foreach (var methodInfo in Methods)
            {
                patternInfo.AddMethod(methodInfo);
                methodInfo.Index = index++;
                if (methodInfo.SupportsDispatch)
                    _members[methodInfo.Index] = methodInfo;
            }

            // Add the events, too, although they are not indexed
            foreach (var eventInfo in Events)
            {
                patternInfo.AddEvent(eventInfo);
            }

            // Register the pattern
            var patternData = patternInfo.Data;

            // Call register pattern
            int[] propertyIds = new int[patternData.cProperties];
            int[] eventIds = new int[patternData.cEvents];
            registrar.RegisterPattern(ref patternData,
                                      out _patternId,
                                      out _patternAvailablePropertyId,
                                      patternData.cProperties,
                                      propertyIds,
                                      patternData.cEvents,
                                      eventIds);

            // Write the property IDs back
            for (uint i = 0; i < propertyIds.Length; ++i)
            {
                Properties[i].PropertyId = propertyIds[i];
            }
            for (var i = 0; i < eventIds.Length; ++i)
            {
                Events[i].EventId = eventIds[i];
            }

            if (StandaloneProperties != null)
                RegisterStandaloneProperties(registrar);

            _registered = true;
        }

        private void RegisterStandaloneProperties(IUIAutomationRegistrar registrar)
        {
            foreach (var propertyInfoHelper in StandaloneProperties)
            {
                int id;
                var propInfo = propertyInfoHelper.Data;
                registrar.RegisterProperty(ref propInfo, out id);
                propertyInfoHelper.PropertyId = id;
            }
        }

        public ISchemaMember GetMemberByIndex(uint index)
        {
            if (!_registered)
                throw new InvalidOperationException("Pattern schema should be registered first");

            ISchemaMember result;
            if (_members.TryGetValue(index, out result))
                return result;
            return null;
        }
    }
}
