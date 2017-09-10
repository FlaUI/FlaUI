using System.Collections.Generic;
using System.Linq;

namespace FlaUI.Core.AutomationElements
{
    /// <summary>
    /// Represents a list of <see cref="MenuItem"/> elements.
    /// </summary>
    public class MenuItems : List<MenuItem>
    {
        /// <summary>
        /// Creates the list of <see cref="MenuItem"/> elements.
        /// </summary>
        public MenuItems(IEnumerable<MenuItem> collection) : base(collection)
        {
        }

        /// <summary>
        /// Gets the number of elements in the list.
        /// </summary>
        public int Length => Count;

        /// <summary>
        /// Gets the <see cref="MenuItem"/> with the given text.
        /// </summary>
        public MenuItem this[string text]
        {
            get { return this.FirstOrDefault(x => x.Text.Equals(text)); }
        }
    }
}
