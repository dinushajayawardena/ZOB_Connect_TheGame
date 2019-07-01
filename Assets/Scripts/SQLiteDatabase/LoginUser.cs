using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


using Mono.Data.Sqlite;
using System.Data;
using System;

using System.Text.RegularExpressions;

public class LoginUser : MonoBehaviour
{
    public GameObject top_Label;
    public GameObject top_Label2;
    
    public GameObject id;
    public GameObject password;
    public GameObject con_Password;

    public Button login;
    public Button next;
    
    
    public GameObject back;

    private string top_Label_Value;
    
    private string input_ID;
    private string input_Password;
    private string input_Con_Password;
    private string name;
    private string pass;
    

    private bool input_Matched = false;
    private bool change_Password = false;

    IDbCommand dbcmd;
    
    void Start()

    {

        top_Label_Value = "enter your user id";
        top_Label2.active = false;
        con_Password.active = false;
        password.active = false;
        
    }

    private void Update()
    {
        top_Label.GetComponent<Text>().text = top_Label_Value;
        input_ID = id.GetComponent<InputField>().text; // get the user entered value to a variable
        input_Password = password.GetComponent<InputField>().text; //get the entered password to a string
        input_Con_Password = con_Password.GetComponent<InputField>().text;
        open_Connection();
                
        if(name!="")
        {
            next.onClick.AddListener(Next);
        }

        if (input_Password == pass)
        {
            //login.onClick.AddListener(LoadScene);
        }
        
    }

    void open_Connection()
    {
        //var connection =Connection.make_Connection();

        string conn = "URI=file:" + Application.dataPath + "/Plugins/Users.s3db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        String sqlQuery = "SELECT * " + "FROM Userinfo";
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {

            name = reader.GetString(1);
           // Debug.Log(name);

            if(input_ID == name)
            {
                //Debug.Log("matched");
                input_Matched = true;
            }
        }

        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    void Next()
    {
        if(input_Matched)
        {
            //Debug.Log(input_ID);

            check_Password();
            back.active = true;

            next.gameObject.SetActive(false);
        }
        
    }

    void check_Password()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/Users.s3db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        dbcmd = dbconn.CreateCommand();
        String sqlQuery = "SELECT * FROM Userinfo WHERE userid ='"+input_ID+"'";
        
        dbcmd.CommandText = sqlQuery;
        
        IDataReader reader = dbcmd.ExecuteReader();

        while (reader.Read())
        {

            //Debug.Log("checked");
            pass = reader["password"].ToString();
        }

        reader.Close();
        reader = null;

        if (pass == "")
            {
                //Debug.Log("Enter new password");
                top_Label_Value = "enter new password";
                id.active = false;
                password.active = true;
                top_Label2.active = true;
                con_Password.active = true;
            
            SetPassword();
                            
            }
        else
            {
                top_Label_Value = "enter current password";
                id.active = false;
                password.active = true;
            
            }
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }

    private void SetPassword()
    {
        input_Password = password.GetComponent<InputField>().text; //get the entered password to a string
        String sqlQuery_Child = "UPDATE Userinfo SET password= '" + input_Password + "' WHERE userid = '" + input_ID + "'";
        dbcmd.CommandText = sqlQuery_Child;
        
    }


    //Debug.Log("loop closed");
    //input_Password = password.GetComponent<InputField>().text; //get the entered password to a string
    //Debug.Log("error");

    //String sqlQuery_Child = "UPDATE Userinfo SET password= '" + pass + "' WHERE userid = '" + input_ID + "'";

    //    dbcmd.CommandText = sqlQuery_Child;
    //    dbcmd.ExecuteScalar();
    




}
