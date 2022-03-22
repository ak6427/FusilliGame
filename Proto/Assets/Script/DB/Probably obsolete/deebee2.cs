using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class deebee2 : MonoBehaviour
{
    string conn;
    string sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;
    
    string foodDB = "/foodDB.s3db";
    void Start()
    {
        string filepath = Application.dataPath + foodDB;
        conn = "URI=file:" + filepath;
        dbconn = new SqliteConnection(conn);
        CreateTable();
    }
    private void CreateTable()
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open();
            dbcmd = dbconn.CreateCommand();
            sqlQuery = "CREATE TABLE IF NOT EXISTS [foods] (" +
                "[id] INTEGER  NOT NULL PRIMARY KEY AUTOINCREMENT," +
                "[name] VARCHAR(255)  NOT NULL," +
                "[age] INTEGER DEFAULT '18' NOT NULL)";
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }
}
