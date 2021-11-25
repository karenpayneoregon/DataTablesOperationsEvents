using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary
{
    public class DataTableEvents
    {
        /// <summary>
        /// Used to manually assign a surrogate primary key
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void RowChanged(object sender, DataRowChangeEventArgs e)
        {
            if (e.Action != DataRowAction.Add) return;
            var row = e.Row;
            row.SetField("id", row.Table.NextIdentifier());
        }
        /// <summary>
        /// Provide access to changes for the current DataRow after in this
        /// case leaving a cell in a DataGridView.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void ColumnChanged(object sender, DataColumnChangeEventArgs e)
        {
            if (e.Row.RowState == DataRowState.Deleted || e.Row.RowState == DataRowState.Detached || e.Row.RowState == DataRowState.Added) return;

            if (e.Row.Table.Columns.Contains("id"))
            {
                Console.WriteLine($"                Id {e.Row.Field<int>("id")}");
            }

            Console.WriteLine($"       Column name {e.Column.ColumnName}");
            Console.WriteLine($"    Original value [{e.Row[e.Column.ColumnName, DataRowVersion.Original]}]");
            Console.WriteLine($"    Propose value [{e.ProposedValue}]");
            Console.WriteLine(new string('-',20));
        }
    }
}
