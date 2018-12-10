using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary
{
    public static class ExtensionMethods
    {
        public static TableChanges AllChanges(this DataTable sender, int primaryKeyIndex)
        {
            var results = new TableChanges {Deleted = sender.GetChanges(DataRowState.Deleted)};

            results.HasDeleted = results.Deleted != null;

            for (var index = 0; index < sender.Rows.Count; index++)
            {
                if (sender.Rows[index].RowState == DataRowState.Deleted)
                {
                    results.DeletedPrimaryKeys.Add(Convert.ToInt32(sender.Rows[index][primaryKeyIndex, DataRowVersion.Original]));
                }
            }

            results.Modified = sender.GetChanges(DataRowState.Modified);
            results.HasModified = results.Modified != null;

            results.Added = sender.GetChanges(DataRowState.Added);
            results.HasNew = results.Added != null;

            results.UnChanged = sender.GetChanges(DataRowState.Unchanged);
            results.HasUnchanged = results.UnChanged != null;

            results.Any = results.HasDeleted || results.HasModified || results.HasNew;

            return results;

        }
        /// <summary> 
        /// Get changes by primary name 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <param name="primaryKeyColumnName"></param> 
        /// <returns></returns> 
        public static TableChanges AllChanges(this DataTable sender, string primaryKeyColumnName = "id")
        {

            int primaryKeyIndex = sender.Columns[primaryKeyColumnName].Ordinal;
            var results = sender.AllChanges(primaryKeyIndex);

            return results;

        }
        /// <summary> 
        /// Returns a comma delimited string representing all  
        /// data rows in the table. 
        /// </summary> 
        /// <param name="sender"></param> 
        /// <returns></returns> 
        public static string Flatten(this DataTable sender)
        {
            var sb = new StringBuilder();
            foreach (DataRow row in sender.Rows)
            {
                sb.AppendLine(string.Join(",", row.ItemArray));
            }

            return sb.ToString();

        }
    }
}
