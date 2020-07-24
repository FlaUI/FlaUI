using System;

namespace FlaUI.Custom
{
    public class CustomProperty
    {
        public CustomProperty(Guid guid, string name, PropertyType type)
        {
            Guid = guid;
            Name = name;
            Type = type;
        }

        public Guid Guid { get; }
        public string Name { get; }
        public PropertyType Type { get; }
        public int Id { get; internal set; }
    }
}
