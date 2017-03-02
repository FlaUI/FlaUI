using System;
using System.Xml;
using System.Xml.XPath;
using FlaUI.Core.AutomationElements.Infrastructure;
#if NET35
using FlaUI.Core.Tools;
#endif

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

        public AutomationElementXPathNavigator(AutomationElement rootElement)
        {
            _treeWalker = rootElement.Automation.TreeWalkerFactory.GetControlViewWalker();
            _rootElement = rootElement;
            _currentElement = rootElement;
        }

        private bool IsInAttribute => _attributeIndex != NoAttributeValue;

        public override bool HasAttributes => !IsInAttribute;

        public override string Value => IsInAttribute ? GetAttributeValue(_attributeIndex) : _currentElement.ToString();

        public override object UnderlyingObject => _currentElement;

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

        public override string LocalName => IsInAttribute ? GetAttributeName(_attributeIndex) : _currentElement.Properties.ControlType.Value.ToString();

        public override string Name => LocalName;

        public override XmlNameTable NameTable
        {
            get { throw new NotImplementedException(); }
        }

        public override string NamespaceURI => String.Empty;

        public override string Prefix => String.Empty;

        public override string BaseURI => String.Empty;

        public override bool IsEmptyElement => false;

        public override XPathNavigator Clone()
        {
            var clonedObject = new AutomationElementXPathNavigator(_rootElement)
            {
                _currentElement = _currentElement,
                _attributeIndex = _attributeIndex
            };
            return clonedObject;
        }

        public override bool MoveToFirstAttribute()
        {
            if (IsInAttribute)
            {
                return false;
            }
            _attributeIndex = 0;
            return true;
        }

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

        public override string GetAttribute(string localName, string namespaceURI)
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

        public override bool MoveToAttribute(string localName, string namespaceURI)
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

        public override bool MoveToFirstNamespace(XPathNamespaceScope namespaceScope)
        {
            throw new NotImplementedException();
        }

        public override bool MoveToNextNamespace(XPathNamespaceScope namespaceScope)
        {
            throw new NotImplementedException();
        }

        public override void MoveToRoot()
        {
            _attributeIndex = NoAttributeValue;
            _currentElement = _rootElement;
        }

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

        public override bool MoveToId(string id)
        {
            return false;
        }

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
                    return _currentElement.Properties.AutomationId.Value;
                case ElementAttributes.Name:
                    return _currentElement.Properties.Name.Value;
                case ElementAttributes.ClassName:
                    return _currentElement.Properties.ClassName.Value;
                case ElementAttributes.HelpText:
                    return _currentElement.Properties.HelpText.Value;
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
            ElementAttributes parsedValue;
#if NET35
            if (ExtensionMethods.TryParse(attributeName, out parsedValue))
#else
            if (Enum.TryParse(attributeName, out parsedValue))
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
            HelpText
        }
    }
}
