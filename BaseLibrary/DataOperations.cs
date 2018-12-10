using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary
{
    public class DataOperations : BaseSqlServerConnections
    {
        public DataOperations()
        {
            DefaultCatalog = "TechNetData";
        }
        /// <summary>
        /// Load state abbreviations were the table has only
        /// a string field where it would be best to have a
        /// primary key to link back to tables using this yet
        /// doubtful state names will change 
        /// </summary>
        /// <returns></returns>
        public DataTable LoadStates()
        {
            var dt = new DataTable();
            const string selectStatement = "SELECT State FROM dbo.UsStates ORDER BY State";
            try
            {
                using (var cn = new SqlConnection() { ConnectionString = ConnectionString })
                {
                    using (var cmd = new SqlCommand() { Connection = cn, CommandText = selectStatement })
                    {
                        cn.Open();

                        dt.Load(cmd.ExecuteReader());
                    }
                }
            }
            catch (Exception e)
            {
                mHasException = true;
                mLastException = e;
            }
            return dt;
        }

        public DataTable LoadMembers()
        {
            var dt = new DataTable();
            const string selectStatement = "SELECT Id ,Status, FirstName,LastName,Street,City,State,PostalCode,PIN FROM dbo.Member";
            try
            {
                using (var cn = new SqlConnection() {ConnectionString = ConnectionString})
                {
                    using (var cmd = new SqlCommand() {Connection = cn, CommandText = selectStatement})
                    {
                        cn.Open();

                        dt.Load(cmd.ExecuteReader());

                        /*
                         * Turn off AutoIncrement and setting AllowDBNull to true
                         * allows us to control adding new records, otherwise when
                         * a user selects a new row in the DataGridView and moves out
                         * the id would be incremented which we want to assign the value
                         * after a adding the row to the database table.
                         */
                        dt.Columns["id"].AutoIncrement = false;
                        dt.Columns["id"].AllowDBNull = true;
                        dt.Columns["id"].ReadOnly = false;
                        dt.Columns["Status"].DefaultValue = true;

                    }
                }               
            }
            catch (Exception e)
            {
                mHasException = true;
                mLastException = e;
            }
            return dt;
        }

        public void RemoveRows(List<int> primaryKeys)
        {
            mHasException = false;

            try
            {
                using (var cn = new SqlConnection() {ConnectionString = ConnectionString})
                {
                    using (var cmd = new SqlCommand() {Connection = cn, CommandText = "DELETE FROM dbo.Member WHERE ID = @Id" })
                    {
                        cmd.Parameters.Add(new SqlParameter() {ParameterName = "@ID", SqlDbType = SqlDbType.Int});
                        cn.Open();
                        foreach (var id in primaryKeys)
                        {
                            cmd.Parameters[0].Value = id;
                            cmd.ExecuteNonQuery();
                        }
                    }
                }

            }
            catch (Exception e)
            {
                mHasException = true;
                mLastException = e;
            }
        }
        public void AddRows(DataTable resultsAdded)
        {
            const string insertStatement = "INSERT INTO dbo.Member " + 
                                           "(FirstName,LastName,Street,City,State,PostalCode,PIN,Status) " + 
                                           "VALUES " + 
                                           "(@FirstName,@LastName,@Street,@City,@STATE,@PostalCode,@PIN,@STATUS)";

            for (int rowIndex = 0; rowIndex < resultsAdded.Rows.Count; rowIndex++)
            {
                Console.WriteLine(string.Join(",", resultsAdded.Rows[rowIndex].ItemArray));
            }
        }
        public void UpdateRows(DataTable resultsModified)
        {
            const string updateStatement = "UPDATE dbo.Member " + 
                                           "SET FirstName = @FirstName," +
                                           "LastName = @LastName, " +
                                           "Street = @Street,City = " +
                                           "@City,State = @STATE, " +
                                           "PostalCode = @PostalCode, " + 
                                           "PIN = @PIN, " + 
                                           "Status = @STATUS " +
                                           "WHERE Id = @Id";

        }

        public List<DataColumn> ColumnDetails(string pTableName)
        {
            mHasException = false;

            var columnData = new List<DataColumn>();
            const string selectStatement = 
                "SELECT  COLUMN_NAME AS ColumnName, ORDINAL_POSITION AS Postion,prop.value AS [Description] " + 
                "FROM INFORMATION_SCHEMA.TABLES AS tbl " + 
                "INNER JOIN INFORMATION_SCHEMA.COLUMNS AS col ON col.TABLE_NAME = tbl.TABLE_NAME " + 
                "INNER JOIN sys.columns AS sc ON sc.object_id = OBJECT_ID(tbl.TABLE_SCHEMA + '.' + tbl.TABLE_NAME) AND sc.name = col.COLUMN_NAME " + 
                "LEFT JOIN sys.extended_properties prop ON prop.major_id = sc.object_id AND prop.minor_id = sc.column_id AND prop.name = 'MS_Description' " + 
                "WHERE tbl.TABLE_NAME = @TableName " + 
                "ORDER BY col.ORDINAL_POSITION";

            try
            {
                using (SqlConnection cn = new SqlConnection { ConnectionString = ConnectionString })
                {
                    using (SqlCommand cmd = new SqlCommand { Connection = cn })
                    {

                        cmd.CommandText = selectStatement;
                        cmd.Parameters.AddWithValue("@TableName", pTableName);

                        cn.Open();

                        var reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            columnData.Add(new DataColumn()
                            {
                                Name = reader.GetString(0),
                                Ordinal = reader.GetInt32(1),
                                Description = reader.GetStringSafe("Description")
                            });
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                mHasException = true;
                mLastException = ex;
            }

            return columnData;

        }



    }
}
