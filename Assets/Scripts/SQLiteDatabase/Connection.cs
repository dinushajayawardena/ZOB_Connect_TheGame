using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System;
using System.Data;

public class Connection
{
    

    public static IDbConnection make_Connection()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/Users.s3db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        return dbconn;        
    }

    public static SqliteDataReader Command(SqliteCommand command)
    {
        var reader = command.ExecuteReader();
        return reader;
    }




    public static void close(SqliteConnection dbconn)
    {
        dbconn.Close();
        dbconn.Dispose();
    }


}
