using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_3
{
    public class Database
    {
        private static Database instance;
        private SqlConnection sql;
        private string sqlString;
        private string dbName;
        private string SrvName;

        public Database(string SrvName, string dbName)
        {
            instance = this;

            this.SrvName = SrvName;
            this.dbName = dbName;
            this.sqlString = $"Data Source={SrvName};Initial Catalog={dbName};Integrated Security=True";
            this.sql = new SqlConnection(sqlString);

        }
        public Database(string sqlString)
        {
            this.sqlString = sqlString;
            this.sql = new SqlConnection(sqlString);
        }

        public SqlDataReader CreateCommand(string query)
        {
            SqlCommand command = sql.CreateCommand();
            command.CommandText = query;

            return command.ExecuteReader();
        }
        public SqlConnection GetConn()
        {
            return sql;
        }

        public bool IsOpen()
        {
            return sql.State.Equals(ConnectionState.Open);
        }

        public void Open()
        {
            sql.Open();
        }

        public void OpenAsync()
        {
            sql.OpenAsync();
        }

        public void Close()
        {
            sql.Close();
        }

        public void Dispose()
        {
            sql.Dispose();
        }

        public String getSqlString()
        {
            return sqlString;
        }

        public void setSqlString(string sqlString)
        {
            this.sqlString = sqlString;
        }

        public static Database GetDatabase()
        {
            return instance;
        }
    }
}
