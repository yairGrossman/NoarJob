using System;
using System.Data;
using System.Data.OleDb;

namespace DAL
{
    /// <summary>
    /// Summary description for DBHelper
    /// this class manege the connection to the Data Bage
    /// it can return a query resault ro exequte a query;
    /// </summary>
    public static class DBHelper
    {
        private const string connectionstring = @"Provider = Microsoft.ACE.OLEDB.12.0;
                                                Data Source = C:\Users\Yair\Documents\Project_12th_Grade\NoarJob\NoarJobDAL\Data\NoarJobDB.accdb;
                                                Persist Security Info=False;";


        private static OleDbConnection GetConnection()
        {
            OleDbConnection conn = new OleDbConnection();

            // add a connection string to the connection
            conn.ConnectionString = connectionstring;
            try
            {
                //open the connection to the data base
                conn.Open();
                return conn;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        /// <summary>
        /// The GetDataSet method returns a .NET DataSet object that contains a DataTable.  
        /// The DataTable contains the results for each of the rules in the RET rule set that was checked.
        /// </summary>
        /// <param name="query">sql select query</param>
        /// <returns>Dataset of all the the datatables in the query</returns>
        public static DataSet GetDataSet(string query)
        {
            try
            {
                OleDbConnection connection = GetConnection();
                if (connection == null)
                    return null;

                OleDbCommand c = new OleDbCommand(query, connection);
                OleDbDataAdapter d = new OleDbDataAdapter(c);
                DataSet ds = new DataSet();
                d.Fill(ds);
                connection.Close();
                return ds;
            }
            catch (Exception ex)
            {
                //catch the error (if there is an error while connecting.
                return null;

            }
        }
        /// <summary>
        /// return a data table frm the data base basen on an SQL query from the user
        /// </summary>
        /// <param name="query">an SQL QUERY</param>
        /// <returns>Data Table: one Data Table</returns>
        public static DataTable GetDataTable(string query)
        {
            try
            {
                OleDbConnection connection = GetConnection();
                if (connection == null)
                    return null;

                OleDbCommand command = new OleDbCommand(query, connection);
                OleDbDataAdapter d = new OleDbDataAdapter(command);
                DataSet ds = new DataSet();
                d.Fill(ds);
                connection.Close();
                return ds.Tables[0];
            }
            catch (Exception ex)
            {
                //catch the error (if there is an error while connecting.
                return null;

            }
        }

        /// <summary>
        /// Executes a Transact-SQL statement against the connection and returns the number of rows affected. 
        /// </summary>
        /// <param name="sql">sql statment </param>
        /// <returns>number of rows affected</returns>
        public static int ExecuteNonQuery(string sql)
        {
            try
            {
                OleDbConnection connection = GetConnection();
                if (connection == null)
                    return -1;
                OleDbCommand command = new OleDbCommand(sql, connection);
                int rowsAffected = command.ExecuteNonQuery();
                connection.Close();
                return rowsAffected;
            }
            catch (Exception ex)
            {
                //catch the error (if there is an error while connecting.
                return -1;

            }
        }

        /// <summary>
        /// פונקציה שכניסה רשומה חדשה לטבלה ומחזירה את המפתח של אותה רשומה
        /// </summary>
        /// <param name="sql">sql statment </param>
        /// <returns>number of rows affected</returns>
        public static int ExecuteInsertGetIdentity(string sql)
        {
            try
            {
                OleDbConnection connection = GetConnection();
                if (connection == null)
                    return -1;
                OleDbCommand command = new OleDbCommand(sql, connection);
                command.ExecuteNonQuery();

                command.CommandText = "SELECT @@IDENTITY AS News_ID";
                int newID = Int32.Parse(command.ExecuteScalar().ToString());

                connection.Close();
                return newID;
            }
            catch (Exception ex)
            {
                //catch the error (if there is an error while connecting.
                return -1;

            }
        }

        /// <summary>
        /// פונקציה שמחזירה נתון בודד
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static int GetScalar(string sql)
        {
            try
            {
                OleDbConnection connection = GetConnection();
                if (connection == null)
                    return -1;
                OleDbCommand command = new OleDbCommand(sql, connection);
                int ScalarResult = (int)command.ExecuteScalar();

                connection.Close();
                return ScalarResult;
            }
            catch (Exception ex)
            {
                //catch the error (if there is an error while connecting.
                return -1;

            }
        }
    }
}