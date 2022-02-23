using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class deebee : MonoBehaviour {
    void Start() {

        string conn = "URI=file:" + Application.dataPath + "/food.db"; //Path to database.

        IDbConnection dbconn;

        dbconn = (IDbConnection) new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.

        IDbCommand dbcmd = dbconn.CreateCommand();

        string sqlQuery = "SELECT value,name, randomSequence " + "FROM PlaceSequence"; //KYSELY!
        dbcmd.CommandText = sqlQuery;

        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read()) {
            int value = reader.GetInt32(0);
            string name = reader.GetString(1);
            int rand = reader.GetInt32(2);

            Debug.Log( "value= "+value+"  name ="+name+"  random ="+  rand);
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;

    }
}
