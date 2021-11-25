using System.Data;
using System.Windows.Forms;

namespace BaseLibrary
{
    public static class BindingSourceExtensions
    {
        public static DataTable DataTable(this BindingSource sender) => (DataTable)sender.DataSource;

        public static DataRow DataRow(this BindingSource sender) => ((DataRowView) sender.Current).Row;
    }
}
