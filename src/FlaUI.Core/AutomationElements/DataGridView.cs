using System.Linq;
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
        public DataGridView(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
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
                var header = FindFirstChild(cf => cf.ByName(LocalizedStrings.DataGridViewHeader).Or(cf.ByControlType(ControlType.Header)));
                return header == null ? null : new DataGridViewHeader(header.FrameworkAutomationElement);
            }
        }

        /// <summary>
        /// Gets all the data rows.
        /// </summary>
        public virtual DataGridViewRow[] Rows
        {
            get
            {
                var rows = FindAllChildren(cf => cf.ByControlType(ControlType.Custom).Or(cf.ByControlType(ControlType.DataItem))
                    .And(cf.ByName(LocalizedStrings.DataGridViewHeader).Not()));
                // Remove the last row if we have the "add" row
                if (HasAddRow)
                {
                    rows = rows.Take(rows.Length - 1).ToArray();
                }
                return rows.Select(x => new DataGridViewRow(x.FrameworkAutomationElement)).ToArray();
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
        public DataGridViewHeader(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// Gets the header items.
        /// </summary>
        public DataGridViewHeaderItem[] Columns
        {
            get
            {
                // WinForms uses Header control type, WPF uses HeaderItem control type
                var headerItems = FindAllChildren(cf => cf.ByControlType(ControlType.Header).Or(cf.ByControlType(ControlType.HeaderItem)));
                var convertedHeaderItems = headerItems.Select(x => new DataGridViewHeaderItem(x.FrameworkAutomationElement))
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
        public DataGridViewHeaderItem(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
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
        public DataGridViewRow(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
        {
        }

        /// <summary>
        /// Gets all cells.
        /// </summary>
        public DataGridViewCell[] Cells
        {
            get
            {
                var cells = FindAllChildren(cf =>
                    cf.ByControlType(ControlType.Header).Not()
                    .And(cf.ByControlType(ControlType.HeaderItem).Not())
                    .And(cf.ByClassName("DataGridDetailsPresenter").Not()));
                return cells.Select(x => new DataGridViewCell(x.FrameworkAutomationElement)).ToArray();
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
        public DataGridViewCell(FrameworkAutomationElementBase frameworkAutomationElement) : base(frameworkAutomationElement)
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