﻿using System;
using FlaUI.Core.Definitions;
using FlaUI.Core.Identifiers;

namespace FlaUI.Core.Conditions
{
    public class PropertyCondition : ConditionBase
    {
        public PropertyCondition(PropertyId property, object value)
            : this(property, value, PropertyConditionFlags.None)
        {
        }

        public PropertyCondition(PropertyId property, object value, PropertyConditionFlags propertyConditionFlags)
        {
            Property = property;
            Value = value;
            PropertyConditionFlags = propertyConditionFlags;
        }

        public PropertyId Property { get; private set; }

        public PropertyConditionFlags PropertyConditionFlags { get; private set; }

        public object Value { get; private set; }

        public override string ToString()
        {
            return String.Format("{0}: {1}", Property, Value);
        }
    }
}
