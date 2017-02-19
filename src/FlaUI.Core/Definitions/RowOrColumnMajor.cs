namespace FlaUI.Core.Definitions
{
    /// <summary>
    /// Contains values that specify whether data in a table should be read primarily by row or by column.
    /// </summary>
    public enum RowOrColumnMajor
    {
        /// <summary>
        /// Specifies that data in the table should be read row by row.
        /// </summary>
        RowMajor = 0,
        /// <summary>
        /// Specifies that data in the table should be read column by column
        /// </summary>
        ColumnMajor = 1,
        /// <summary>
        /// Specifies that the best way to present the data is indeterminate.
        /// </summary>
        Indeterminate = 2
    }
}
