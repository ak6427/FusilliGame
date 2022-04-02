using System.Collections;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using System.Data;
using Mono.Data.Sqlite;

namespace db
{
    public class DBAccess : MonoBehaviour
    {
        private string connection;
        private IDbConnection dbcon;
        private IDbCommand dbcmd;
        private IDataReader reader;

        private void Awake()
        {
            DontDestroyOnLoad(this);
        }

        public void OpenDB(string p)
        {
            connection = "URI=file:" + p; // we set the connection to our database
            dbcon = new SqliteConnection(connection);
            dbcon.Open();
        }

        public IDataReader BasicQuery(string q, bool r) // run a basic sqlite query
        {
            dbcmd = dbcon.CreateCommand(); // create empty command
            dbcmd.CommandText = q; // fill the command
            reader = dbcmd.ExecuteReader(); // execute command which returns a reader
            if(r)
            { // if we want to return the reader
                return reader; // return the reader
            }
            return null;
        }

        // This returns a 2 dimensional ArrayList with all the
        // data from the table requested
        public ArrayList ReadFullTable(string tableName) 
        {
            string query;
            query = "SELECT * FROM " + tableName;
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;
            reader = dbcmd.ExecuteReader();
            var readArray = new ArrayList();
            while(reader.Read())
            {
                var lineArray = new ArrayList();
                for (var i = 0; i < reader.FieldCount; i++)
                {
                    lineArray.Add(reader.GetValue(i)); // This reads the entries in a row
                    readArray.Add(lineArray); // This makes an array of all the rows
                }
            }
            return readArray; // return matches
        }

        // This function deletes all the data in the given table. Forever. WATCH OUT! Use sparingly, if at all
        public void DeleteTableContents(string tableName)
        {
            string query;
            query = "DELETE FROM " + tableName;
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;
            reader = dbcmd.ExecuteReader();
        }

        public void CreateTable(string name, ArrayList col, ArrayList colType)
        { // Create a table, name, column array, column type array
            string query;
            query = "CREATE TABLE " + name + "(" + col[0] + " " + colType[0];
            for(int i=1; i<col.Count; i++)
            {
                query += ", " + col + " " + colType;
            }
            query += ")";
            dbcmd = dbcon.CreateCommand(); // create empty command
            dbcmd.CommandText = query; // fill the command
            reader = dbcmd.ExecuteReader(); // execute command which returns a reader
        }

        public void InsertIntoSingle(string tableName, string colName, string val)
        { // single insert
            string query;
            query = "INSERT INTO " + tableName + "(" + colName + ") " + "VALUES (" + val + ")";
            dbcmd = dbcon.CreateCommand(); // create empty command
            dbcmd.CommandText = query; // fill the command
            reader = dbcmd.ExecuteReader(); // execute command which returns a reader
        }

        public void InsertIntoSpecific(string tableName, ArrayList col, ArrayList values)
        { // Specific insert with col and values
            string query;
            query = "INSERT INTO " + tableName + "(" + col[0];
            for(int i=1; i<col.Count; i++)
            {
                query += ", " + col;
            }
            query += ") VALUES (" + values[0];
            for(int i=1; i<values.Count; i++)
            {
                query += ", " + values;
            }
            query += ")";
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;
            reader = dbcmd.ExecuteReader();
        }

        public void InsertInto(string tableName, ArrayList values)
        { // basic Insert with just values
        string query;
        query = "INSERT INTO " + tableName + " VALUES (" + values[0];
        for(int i=1; i<values.Count; i++)
        {
            query += ", " + values;
        }
        query += ")";
        dbcmd = dbcon.CreateCommand();
        dbcmd.CommandText = query;
        reader = dbcmd.ExecuteReader();
        }

        // This function reads a single column
        // wCol is the WHERE column, wPar is the operator you want to use to compare with,
        // and wValue is the value you want to compare against.
        // Ex. - SingleSelectWhere("puppies", "breed", "earType", "=", "floppy")
        // returns an array of matches from the command: SELECT breed FROM puppies WHERE earType = floppy;
        public ArrayList SingleSelectWhereID(string tableName, string itemToSelect, string wCol, string wPar, string wValue)
        { // Selects a single Item
            string query;
            query = "SELECT " + itemToSelect + " FROM " + tableName + " WHERE " + wCol + wPar + wValue;
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;
            reader = dbcmd.ExecuteReader();
            ArrayList readArray = new ArrayList();
            while(reader.Read())
            {
                readArray.Add(reader.GetInt32(0)); // Fill array with all matches
            }
            return readArray; // return matches
        }

        public ArrayList SingleSelectWhereString(string tableName, string itemToSelect, string wCol, string wPar, string wValue)
        { // Selects a single Item
            string query;
            query = "SELECT " + itemToSelect + " FROM " + tableName + " WHERE " + wCol + wPar + wValue;
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;
            reader = dbcmd.ExecuteReader();
            ArrayList readArray = new ArrayList();
            while(reader.Read())
            {
                readArray.Add(reader.GetString(0)); // Fill array with all matches
            }
            return readArray; // return matches
        }

        public ArrayList SelectIDColumn(string tableName, string itemToSelect)
        { // Selects a single Item
            string query;
            query = "SELECT " + itemToSelect + " FROM " + tableName;
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;
            reader = dbcmd.ExecuteReader();
            ArrayList readArray = new ArrayList();
            while(reader.Read())
            {
                readArray.Add(reader.GetInt32(0)); // Fill array with all matches
            }
            return readArray; // return matches
        }

        public ArrayList SelectStringColumn(string tableName, string itemToSelect)
        { // Selects a single Item
            string query;
            query = "SELECT " + itemToSelect + " FROM " + tableName;
            dbcmd = dbcon.CreateCommand();
            dbcmd.CommandText = query;
            reader = dbcmd.ExecuteReader();
            ArrayList readArray = new ArrayList();
            while(reader.Read())
            {
                readArray.Add(reader.GetString(0)); // Fill array with all matches
            }
            return readArray; // return matches
        }

        public void CloseDB()
        {
            try
            {
                reader.Close(); // clean everything up
                reader = null;
            }
            catch
            {
                ;
            }
            try
            {
                dbcmd.Dispose();
                dbcmd = null;
            }
            catch
            {
                ;
            }
            try
            {
                dbcon.Close();
                dbcon = null;
            }
            catch
            {
                ;
            }

        }
    }
}
