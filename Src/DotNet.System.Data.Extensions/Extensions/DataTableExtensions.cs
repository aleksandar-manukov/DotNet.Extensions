using System;
using System.Data;
using System.Data.Common;
using System.Threading.Tasks;

namespace DotNet.System.Extensions
{
    /// <summary>
    /// Class containing <see cref="DataTable"/> extensions.
    /// </summary>
    public static class DataTableExtensions
    {
        /// <summary>
        /// Asynchronously load data from db to data table.
        /// </summary>
        /// <param name="table"><see cref="DataTable"/> table to which data will be load.</param>
        /// <param name="reader"><see cref="DbDataReader"/> db data reader used to read data from database.</param>
        /// <exception cref="ArgumentNullException">Thrown when table or reader are null.</exception>
        /// <exception cref="InvalidOperationException">Thrown when reader is closed.</exception>
        /// <example>
        /// This is an example, showing how to use <see cref="LoadAsync(DataTable, DbDataReader)"/>.
        /// <code>
        /// string connectionString = "connection string";
        ///
        /// using (DbConnection connection = new SqlConnection(connectionString))
        /// {
        ///     await connection.OpenAsync();
        ///
        ///     using (DbCommand command = connection.CreateCommand())
        ///     {
        ///         command.CommandText = "sql statement";
        ///
        ///         using (DbDataReader reader = command.ExecuteReader())
        ///         {
        ///             using (DataTable table = new DataTable())
        ///             {
        ///                 await table.LoadAsync(reader);
        ///             }
        ///         }
        ///     }
        /// }
        /// </code>
        /// </example>
        public static async Task LoadAsync(this DataTable table, DbDataReader reader)
        {
            if (table == null)
            {
                throw new ArgumentNullException(nameof(table), "Table cannot be null.");
            }

            if (reader == null)
            {
                throw new ArgumentNullException(nameof(reader), "Reader cannot be null.");
            }

            if (reader.IsClosed)
            {
                throw new InvalidOperationException("Cannot read data from closed reader.");
            }

            DataTable schemaTable = reader.GetSchemaTable();

            foreach (DataRow row in schemaTable.Rows)
            {
                DataColumn column = new DataColumn(row["ColumnName"].ToString(), (Type)row["DataType"]);

                table.Columns.Add(column);
            }

            while (await reader.ReadAsync())
            {
                DataRow row = table.NewRow();

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    row[i] = await reader.GetFieldValueAsync<object>(i);
                }

                table.Rows.Add(row);
            }
        }
    }
}