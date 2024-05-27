namespace CatalogoApp.Service
{
    using CatalogoApp.Models;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.SqlClient;

    public class SchemaService
    {
        private readonly string _connectionString;

        public SchemaService(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<TableInfo> GetDatabaseSchema()
        {
            var tables = new List<TableInfo>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var tablesCommand = new SqlCommand("SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'", connection);
                using (var reader = tablesCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var tableName = reader["TABLE_NAME"].ToString();
                        var tableInfo = new TableInfo
                        {
                            TableName = tableName,
                            TableDescription = GetTableDescription(connection, tableName),
                            Fields = GetTableFields(connection, tableName)
                        };
                        tables.Add(tableInfo);
                    }
                }
            }

            return tables;
        }

        private string GetTableDescription(SqlConnection connection, string tableName)
        {
            var descriptionCommand = new SqlCommand($@"
            SELECT 
                ep.value AS TableDescription
            FROM 
                sys.tables t
            INNER JOIN 
                sys.extended_properties ep ON ep.major_id = t.object_id
            WHERE 
                ep.name = 'MS_Description' AND t.name = @TableName", connection);
            descriptionCommand.Parameters.AddWithValue("@TableName", tableName);

            var description = descriptionCommand.ExecuteScalar()?.ToString();
            return description ?? string.Empty;
        }

        private List<FieldInfo> GetTableFields(SqlConnection connection, string tableName)
        {
            var fields = new List<FieldInfo>();

            var fieldsCommand = new SqlCommand($@"
            SELECT 
                c.name AS ColumnName, 
                ep.value AS ColumnDescription
            FROM 
                sys.columns c
            LEFT JOIN 
                sys.extended_properties ep ON ep.major_id = c.object_id AND ep.minor_id = c.column_id AND ep.name = 'MS_Description'
            WHERE 
                c.object_id = OBJECT_ID(@TableName)", connection);
            fieldsCommand.Parameters.AddWithValue("@TableName", tableName);

            using (var reader = fieldsCommand.ExecuteReader())
            {
                while (reader.Read())
                {
                    var fieldInfo = new FieldInfo
                    {
                        FieldName = reader["ColumnName"].ToString(),
                        FieldDescription = reader["ColumnDescription"]?.ToString() ?? string.Empty
                    };
                    fields.Add(fieldInfo);
                }
            }

            return fields;
        }
    }

}
