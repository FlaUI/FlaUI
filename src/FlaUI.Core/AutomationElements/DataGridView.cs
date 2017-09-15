using System.Linq;
using FlaUI.Core.AutomationElements.Infrastructure;
using FlaUI.Core.Definitions;
using FlaUI.Core.Patterns;
using FlaUI.Core.Tools;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Class to interact with a WinForms DataGridView
    /// </summary>
    public class DataGridView : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="DataGridView"/> element.
        /// </summary>
        public DataGridView(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        /// <summary>
        /// Flag to indicate if the grid has the "Add New Item" row or not.
        /// This needs to be set as FlaUI cannot find out if this is the case or not.
        /// </summary>
        public bool HasAddRow { get; set; }

        /// <summary>
        /// Gets the header element or null if the header is disabled.
        /// </summary>
        public virtual DataGridViewHeader Header
        {
            get
            {
                var header = FindFirstChild(cf => cf.ByName(LocalizedStrings.DataGridViewHeader));
                return header == null ? null : new DataGridViewHeader(header.BasicAutomationElement);
            }
        }

        /// <summary>
        /// Gets all the data rows.
        /// </summary>
        public virtual DataGridViewRow[] Rows
        {
            get
            {
                var rows = FindAllChildren(cf => cf.ByControlType(ControlType.Custom).And(cf.ByName(LocalizedStrings.DataGridViewHeader).Not()));
                // Remove the last row if we have the "add" row
                if (HasAddRow)
                {
                    rows = rows.Take(rows.Length - 1).ToArray();
                }
                return rows.Select(x => new DataGridViewRow(x.BasicAutomationElement)).ToArray();
            }
        }
    }

    /// <summary>
    /// Class to interact with a WinForms DataGridView header.
    /// </summary>
    public class DataGridViewHeader : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="DataGridViewHeader"/> element.
        /// </summary>
        public DataGridViewHeader(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        /// <summary>
        /// Gets the header items.
        /// </summary>
        public DataGridViewHeaderItem[] Columns
        {
            get
            {
                var headerItems = FindAllChildren(cf => cf.ByControlType(ControlType.Header));
                var convertedHeaderItems = headerItems.Select(x => new DataGridViewHeaderItem(x.BasicAutomationElement))
                    .ToList();
                // Remove the top-left header item if it exists (can be the first or last item)
                if (convertedHeaderItems.Last().Text == LocalizedStrings.DataGridViewHeaderItemTopLeft)
                {
                    convertedHeaderItems = convertedHeaderItems.Take(convertedHeaderItems.Count - 1).ToList();
                }
                else if (convertedHeaderItems.First().Text == LocalizedStrings.DataGridViewHeaderItemTopLeft)
                {
                    convertedHeaderItems = convertedHeaderItems.Skip(1).ToList();
                }
                return convertedHeaderItems.ToArray();
            }
        }
    }

    /// <summary>
    /// Class to interact with a WinForms DataGridView header item.
    /// </summary>
    public class DataGridViewHeaderItem : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="DataGridViewHeaderItem"/> element.
        /// </summary>
        public DataGridViewHeaderItem(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        /// <summary>
        /// Gets the text of the header item.
        /// </summary>
        public string Text => Properties.Name.Value;
    }

    /// <summary>
    /// Class to interact with a WinForms DataGridView row.
    /// </summary>
    public class DataGridViewRow : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="DataGridViewRow"/> element.
        /// </summary>
        public DataGridViewRow(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        /// <summary>
        /// Gets all cells.
        /// </summary>
        public DataGridViewCell[] Cells
        {
            get
            {
                var cells = FindAllChildren(cf => cf.ByControlType(ControlType.Header).Not());
                return cells.Select(x => new DataGridViewCell(x.BasicAutomationElement)).ToArray();
            }
        }
    }

    /// <summary>
    /// Class to interact with a WinForms DataGridView cell.
    /// </summary>
    public class DataGridViewCell : AutomationElement
    {
        /// <summary>
        /// Creates a <see cref="DataGridViewCell"/> element.
        /// </summary>
        public DataGridViewCell(BasicAutomationElementBase basicAutomationElement) : base(basicAutomationElement)
        {
        }

        /// <summary>
        /// Pattern object for the <see cref="IValuePattern"/>.
        /// </summary>
        protected IValuePattern ValuePattern => Patterns.Value.Pattern;

        /// <summary>
        /// Gets or sets the value in the cell.
        /// </summary>
        public string Value
        {
            get => ValuePattern.Value.Value;
            set => ValuePattern.SetValue(value);
        }
    }
}