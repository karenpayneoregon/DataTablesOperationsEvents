using System;
using System.Data;
using System.Linq;

namespace BaseLibrary
{
    public static class DataExtensions
    {
        public static int NextIdentifier(this DataTable sender, string identifierColumnName = "id")
        {
            var id = sender.AsEnumerable().Where(row => !row.IsNull("id") && row.RowState != DataRowState.Deleted).Max(row => row.Field<int>(identifierColumnName)) + 1;
            return id;
        }

        public static string GetStringSafe(this IDataReader pReader, string pField) => 
            ((pReader[pField] is DBNull) ? null : pReader[pField].ToString());
        public static int GetInt32Safe(this IDataReader pReader, string pField) => 
            pReader.GetInt32Safe(pField, 0);
        public static int GetInt32Safe(this IDataReader pReader, string pField, int pDefaultValue)
        {
            var value = pReader[pField];
            return ((value is int i) ? Convert.ToInt32((int)i) : pDefaultValue);
        }
        public static double GetDoubleSafe(this IDataReader pReader, string pField) => 
            pReader.GetDoubleSafe(pField, 0);
        public static double GetDoubleSafe(this IDataReader pReader, string pField, long pDefaultValue)
        {
            var value = pReader[pField];
            return ((value is double) ? Convert.ToDouble(value) : pDefaultValue);
        }
        public static DateTime GetDateTimeSafe(this IDataReader pReader, string pField) => 
            pReader.GetDateTimeSafe(pField, DateTime.MinValue);
        public static DateTime GetDateTimeSafe(this IDataReader pReader, string pField, DateTime pDefaultValue)
        {
            var value = pReader[pField];
            return ((value is DateTime) ? Convert.ToDateTime(value) : pDefaultValue);
        }
    }
}
