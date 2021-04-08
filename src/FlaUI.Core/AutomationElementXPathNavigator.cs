using System;
using System.Xml;
using System.Xml.XPath;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Definitions;

namespace FlaUI.Core
{
    /// <summary>
    /// Custom implementation of a <see cref="XPathNavigator" /> which allows
    /// selecting items by xpath by using the <see cref="ITreeWalker" />.
    /// </summary>
    public class AutomationElementXPathNavigator : XPathNavigator
    {
        private const int NoAttributeValue = -1;
        private readonly AutomationElement _rootElement;
        private readonly ITreeWalker _treeWalker;
        private AutomationElement _currentElement;
        private int _attributeIndex = NoAttributeValue;

        /// <summary>
        /// Creates a new XPath navigator which uses the given element as the root.
        /// </summary>
        /// <param name="rootElement">The element to use as root element.</param>
        public AutomationElementXPathNavigator(AutomationElement rootElement)
        {
            _treeWalker = rootElement.Automation.TreeWalkerFactory.GetControlViewWalker();
            _rootElement = rootElement;
            _currentElement = rootElement;
        }

        private bool IsInAttribute => _attributeIndex != NoAttributeValue;

        /// <inheritdoc />
        public override bool HasAttributes => !IsInAttribute;

        /// <inheritdoc />
        public override string Value => IsInAttribute ? GetAttributeValue(_attributeIndex) : _currentElement.ToString();

        /// <inheritdoc />
        public override object UnderlyingObject => _currentElement;

        /// <inheritdoc />
        public override XPathNodeType NodeType
        {
            get
            {
                if (IsInAttribute)
                {
                    return XPathNodeType.Attribute;
                }
                if (_currentElement.Equals(_rootElement))
                {
                    return XPathNodeType.Root;
                }
                return XPathNodeType.Element;
            }
        }

        /// <inheritdoc />
        public override string LocalName
        {
            get
            {
                if (IsInAttribute)
                {
                    return GetAttributeName(_attributeIndex);
                }
                // Map unknown types to custom so they are at least findable
                var controlType = _currentElement.Properties.ControlType.IsSupported
                    ? _currentElement.Properties.ControlType.Value
                    : ControlType.Custom;
                return controlType.ToString();
            }
        }

        /// <inheritdoc />
        public override string Name => LocalName;

        /// <inheritdoc />
        public override XmlNameTable NameTable => throw new NotImplementedException();

        /// <inheritdoc />
        public override string NamespaceURI => String.Empty;

        /// <inheritdoc />
        public override string Prefix => String.Empty;

        /// <inheritdoc />
        public override string BaseURI => String.Empty;

        /// <inheritdoc />
        public override bool IsEmptyElement => false;

        /// <inheritdoc />
        public override XPathNavigator Clone()
        {
            var clonedObject = new AutomationElementXPathNavigator(_rootElement)
            {
                _currentElement = _currentElement,
                _attributeIndex = _attributeIndex
            };
            return clonedObject;
        }

        /// <inheritdoc />
        public override bool MoveToFirstAttribute()
        {
            if (IsInAttribute)
            {
                return false;
            }
            _attributeIndex = 0;
            return true;
        }

        /// <inheritdoc />
        public override bool MoveToNextAttribute()
        {
            if (_attributeIndex >= Enum.GetNames(typeof(ElementAttributes)).Length - 1)
            {
                // No more attributes
                return false;
            }
            if (!IsInAttribute)
            {
                return false;
            }
            _attributeIndex++;
            return true;
        }

        /// <inheritdoc />
        public override string GetAttribute(string localName, string namespaceUri)
        {
            if (IsInAttribute)
            {
                return String.Empty;
            }
            var attributeIndex = GetAttributeIndexFromName(localName);
            if (attributeIndex != NoAttributeValue)
            {
                return GetAttributeValue(attributeIndex);
            }
            return String.Empty;
        }

        /// <inheritdoc />
        public override bool MoveToAttribute(string localName, string namespaceUri)
        {
            if (IsInAttribute)
            {
                return false;
            }
            var attributeIndex = GetAttributeIndexFromName(localName);
            if (attributeIndex != NoAttributeValue)
            {
                _attributeIndex = attributeIndex;
                return true;
            }
            return false;
        }

        /// <inheritdoc />
        public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope) => throw new NotImplementedException();

        /// <inheritdoc />
        public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope) => throw new NotImplementedException();

        /// <inheritdoc />
        public override void MoveToRoot()
        {
            _attributeIndex = NoAttributeValue;
            _currentElement = _rootElement;
        }

        /// <inheritdoc />
        public override bool MoveToNext()
        {
            if (IsInAttribute) { return false; }
            var nextElement = _treeWalker.GetNextSibling(_currentElement);
            if (nextElement == null)
            {
                return false;
            }
            _currentElement = nextElement;
            return true;
        }

        /// <inheritdoc />
        public override bool MoveToPrevious()
        {
            if (IsInAttribute) { return false; }
            var previousElement = _treeWalker.GetPreviousSibling(_currentElement);
            if (previousElement == null)
            {
                return false;
            }
            _currentElement = previousElement;
            return true;
        }

        /// <inheritdoc />
        public override bool MoveToFirstChild()
        {
            if (IsInAttribute) { return false; }
            var childElement = _treeWalker.GetFirstChild(_currentElement);
            if (childElement == null)
            {
                return false;
            }
            _currentElement = childElement;
            return true;
        }

        /// <inheritdoc />
        public override bool MoveToParent()
        {
            if (IsInAttribute)
            {
                _attributeIndex = NoAttributeValue;
                return true;
            }
            if (_currentElement.Equals(_rootElement))
            {
                return false;
            }
            _currentElement = _treeWalker.GetParent(_currentElement);
            return true;
        }

        /// <inheritdoc />
        public override bool MoveTo(XPathNavigator other)
        {
            var specificNavigator = other as AutomationElementXPathNavigator;
            if (specificNavigator == null)
            {
                return false;
            }
            if (!_rootElement.Equals(specificNavigator._rootElement))
            {
                return false;
            }
            _currentElement = specificNavigator._currentElement;
            _attributeIndex = specificNavigator._attributeIndex;
            return true;
        }

        /// <inheritdoc />
        public override bool MoveToId(string id)
        {
            return false;
        }

        /// <inheritdoc />
        public override bool IsSamePosition(XPathNavigator other)
        {
            var specificNavigator = other as AutomationElementXPathNavigator;
            if (specificNavigator == null)
            {
                return false;
            }
            if (!_rootElement.Equals(specificNavigator._rootElement))
            {
                return false;
            }
            return _currentElement.Equals(specificNavigator._currentElement)
                && _attributeIndex == specificNavigator._attributeIndex;
        }

        private string GetAttributeValue(int attributeIndex)
        {
            switch ((ElementAttributes)attributeIndex)
            {
                case ElementAttributes.AutomationId:
                    return _currentElement.Properties.AutomationId.ValueOrDefault;
                case ElementAttributes.Name:
                    return _currentElement.Properties.Name.ValueOrDefault;
                case ElementAttributes.ClassName:
                    return _currentElement.Properties.ClassName.ValueOrDefault;
                case ElementAttributes.HelpText:
                    return _currentElement.Properties.HelpText.ValueOrDefault;
                case ElementAttributes.IsPassword:
                    return _currentElement.Properties.IsPassword.ValueOrDefault.ToString().ToLower();
                case ElementAttributes.FullDescription:
                    return _currentElement.Properties.FullDescription.ValueOrDefault;
                case ElementAttributes.ItemType:
                    return _currentElement.Properties.ItemType.ValueOrDefault;
                case ElementAttributes.AcceleratorKey:
                    return _currentElement.Properties.AcceleratorKey.ValueOrDefault;
                case ElementAttributes.AccessKey:
                    return _currentElement.Properties.AccessKey.ValueOrDefault;
                case ElementAttributes.IsEnabled:
                    return _currentElement.Properties.IsEnabled.ValueOrDefault.ToString().ToLower();
                case ElementAttributes.IsOffscreen:
                    return _currentElement.Properties.IsOffscreen.ValueOrDefault.ToString().ToLower();
                case ElementAttributes.ProcessId:
                    return _currentElement.Properties.ProcessId.ValueOrDefault.ToString();
                default:
                    throw new ArgumentOutOfRangeException(nameof(attributeIndex));
            }
        }

        private string GetAttributeName(int attributeIndex)
        {
            var name = Enum.GetName(typeof(ElementAttributes), attributeIndex);
            if (name == null)
            {
                throw new ArgumentOutOfRangeException(nameof(attributeIndex));
            }
            return name;
        }

        private int GetAttributeIndexFromName(string attributeName)
        {
#if NET35
            if (EnumExtensions.TryParse(attributeName, out ElementAttributes parsedValue))
#else
            if (Enum.TryParse(attributeName, out ElementAttributes parsedValue))
#endif
            {
                return (int)parsedValue;
            }
            return NoAttributeValue;
        }

        private enum ElementAttributes
        {
            AutomationId,
            Name,
            ClassName,
            HelpText,
            IsPassword,
            FullDescription,
            ItemType,
            AcceleratorKey,
            AccessKey,
            IsEnabled,
            IsOffscreen,
            ProcessId
        }
    }
}
