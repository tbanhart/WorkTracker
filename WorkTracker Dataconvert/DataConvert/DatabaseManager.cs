using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

namespace WorkTracker2.Data
{
    public class DatabaseManager : IDataManager
    {
        public List<Dictionary<string, string>> PullEntry(string database, string table, 
            string filter, string encorr)
        {
            SqlConnection conn = TestConnection(database);
            if (conn == null) { conn.Close(); return new List<Dictionary<string, string>>(); }

            var command = $"SELECT * FROM {table} WHERE CONVERT(VARCHAR, {filter})='{encorr}';";

            return DoPull(conn, command);

        }

        public void RemoveEntry(string database, string table, string column, string value)
        {
            SqlConnection conn = TestConnection(database);
            if (conn == null) { conn.Close(); return; }

            try
            {
                Console.WriteLine("Trying to delete " + value + " from " + table);
                var commandString = $"delete from {table} where convert(varchar, {column}) = '{value}';";
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = conn;
                    command.CommandText = commandString;
                    //command.Parameters.AddWithValue("@Encorr", encorr);
                    //Console.WriteLine(encorr);
                    //Console.WriteLine(command.CommandText);
                    command.ExecuteNonQuery();
                    //Console.WriteLine(encorr + " was deleted from " + table);
                }
            }
            catch(Exception e)
            {
                MessageBox.Show("Could not delete entry.\n" + e);
            }
            conn.Close();
        }

        public SqlConnection TestConnection(string database)
        {
            SqlConnection conn;
            try
            {
                conn = NewConnection(database);
                return conn;
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not complete connection.\n" + e);
                return null;
            }
        }

        public List<Dictionary<string, string>> PullData(
            string database, string table, params string[] args)
        {
            SqlConnection conn = TestConnection(database);
            if (conn == null) { conn.Close(); return new List<Dictionary<string, string>>(); }

            var command = $"SELECT * FROM {table};";

            return DoPull(conn, command);
        }

        public List<Dictionary<string, string>> LimitedPull(
            string database, string table, string column, string value)
        {
            SqlConnection conn = TestConnection(database);
            if (conn == null) { conn.Close(); return new List<Dictionary<string, string>>(); }

            var command = $"SELECT * FROM {table} WHERE CONVERT(VARCHAR, {column}) = '{value}';";

            return DoPull(conn, command);

        }


        private static List<Dictionary<string, string>> DoPull(SqlConnection conn, string commandString)
        {
            List<Dictionary<string, string>> returnList = new List<Dictionary<string, string>>();

            SqlCommand command;
            var columns = new List<string>();

            using (command = new SqlCommand(commandString, conn))
            {
                //Console.WriteLine("Executing reader for " + table);
                using (var reader = command.ExecuteReader(CommandBehavior.KeyInfo))
                {
                    var schemaTable = reader.GetSchemaTable();
                    foreach (DataRow row in schemaTable.Rows)
                    {
                        var column = schemaTable.Columns["ColumnName"].ColumnName;
                        string columnName = row[column].ToString();
                        columns.Add(columnName);
                        //Console.WriteLine("column added: " + columnName);
                    }
                }
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var dictionary = new Dictionary<string, string>();

                        int columnCounter = 0;
                        foreach (var column in columns)
                        {
                            dictionary.Add(columns[columnCounter], (string)reader.GetValue(columnCounter));
                            //Console.WriteLine(columns[columnCounter] + " added to dictionary with value " + (string)reader.GetValue(columnCounter));
                            columnCounter++;
                        }
                        returnList.Add(dictionary);

                    }
                }
            }
            conn.Close();
            return returnList;
        }

        public void UpdateEntry(string database, string table, string IDString, Dictionary<string, string> data)
        {
            SqlConnection conn = TestConnection(database);
            if (conn == null) return;

            var valueString = string.Empty;
            if (FindDuplicates(database, table, IDString, data[IDString]) == false)
            {
                PushData(database, table, data);
                return;
            }
            foreach (var item in data)
            {
                string key; string value;
                if (item.Key == "User") key = "[User]"; else key = item.Key;
                if (item.Value == "") value = "N/A"; else value = item.Value;
                valueString += key + "=" + "'" + value + "'";
                if (item.Key != data.Last().Key)
                {
                    valueString += ", ";
                }
            }

            using (SqlCommand command = new SqlCommand($"UPDATE {table} " +
                $"SET {valueString} WHERE CONVERT(VARCHAR, {IDString}) = '{data[IDString]}'", conn))
            {
                command.ExecuteNonQuery();
            }
            conn.Close();
        }

        public bool PushData(string database, string table, Dictionary<string, string> data)
        {
            TryPushData(database, table, data);
            return true;
        }

        private bool TryPushData( string database,
            string tableName, Dictionary<string, string> data)
        {
            SqlConnection conn = TestConnection(database);
            if (conn == null) return false;

            var columnString = string.Empty; var valueString = string.Empty;
            foreach (var item in data)
            {
                if (item.Value == "") valueString += "'N/A'";
                else valueString += $"'{item.Value}'";

                if (item.Key == "User") columnString += "[user]";
                else columnString += $"{item.Key}";

                if (item.Key != data.Last().Key)
                {
                    columnString += ", ";
                    valueString += ", ";
                }
            }
            try
            {
                string commandString = $"INSERT INTO {tableName} " +
                    $"({columnString}) VALUES ({valueString});";
                using (SqlCommand command = new SqlCommand(commandString, conn))
                {
                    Console.WriteLine(commandString);
                    command.ExecuteNonQuery();
                }
                conn.Close();
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Could not update table \n" + e);
                return false;
            }
        }

        public bool FindDuplicates(string database, string table, string column, string columnValue)
        {
            if (PullEntry(database, table, column, columnValue).Count == 0) return false;
            else return true;
        }

        private static SqlConnection NewConnection(string databaseName)
        {
            string connectionText = @"Data Source=DSKCFSIBMLNP;" +
                $"Initial Catalog={databaseName};User ID=Ibmluser;Password=userpass";
            SqlConnection conn = new SqlConnection(connectionText);
            Console.WriteLine(connectionText);
            conn.Open();
            return conn;
        }

    }
}
