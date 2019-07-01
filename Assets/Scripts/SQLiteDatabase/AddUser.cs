using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System;
using System.Data;
using Mono.Data.Sqlite;
using UnityEngine.UI;

public class AddUser : MonoBehaviour
{
    public GameObject uID_Prefix;
    public GameObject uID;
    public GameObject uName;
    public GameObject initials;
    public GameObject uType;
    public GameObject bGroup;
    public GameObject mNote;
    public GameObject rDate;
    public GameObject sDate;
    public GameObject eDate;
    //public GameObject instructor;
    public GameObject cNo;
    public GameObject address;
    public GameObject image;
    

    private bool check;

    private string uid_prefix;
    private string uid;
    private string uidall;
    private string uname;
    private string _initials;
    private int utype_Index;
    private string utype;
    private int bgroup_Index;
    private string bgroup;
    private string mnote;
    private string rdate;
    private string sdate;
    private string edate;
    //private string _instructor;
    private string cno;
    private string _address;
    private string _image;
 

    // Start is called before the first frame update
    void Start()
    {
        
        check = false;

    }

    private void Update()
    {
                
        uid = uID.GetComponent<InputField>().text;
        uname = uName.GetComponent<InputField>().text;
        _initials = initials.GetComponent<InputField>().text;
        utype_Index = uType.GetComponent<Dropdown>().value;
        GetUserType(); 
        
        bgroup_Index = bGroup.GetComponent<Dropdown>().value;
        GetBGroup();

        if(uType.GetComponent<Dropdown>().value == 0)
        {
            uID_Prefix.GetComponent<Text>().text = "TS/";
        }

        if(uType.GetComponent<Dropdown>().value == 1)
        {
            uID_Prefix.GetComponent<Text>().text = "TI/";
        }
        if (uType.GetComponent<Dropdown>().value == 2)
        {
            uID_Prefix.GetComponent<Text>().text = "TA/";
        }
        uid_prefix = uID_Prefix.GetComponent<Text>().text;

        mnote = mNote.GetComponent<InputField>().text;
        //rdate=
        //sdate=
        //edate=
        //_instructor = instructor.GetComponent<Dropdown>().itemText.ToString();
        cno = cNo.GetComponent<InputField>().text;
        _address = address.GetComponent<InputField>().text;
        //_image = image.GetComponent<Image>().mainTexture;

        uidall = uid_prefix + "" + uid; //make two strings as one
    }

    public void makeData()
    {
        //make connection
        string conn = "URI=file:" + Application.dataPath + "/Plugins/Users.s3db";
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open();
        IDbCommand dbcmd = dbconn.CreateCommand();

        //Debug.Log(utype);
        //make sqlQuery
        String sqlQuery = "INSERT INTO Userinfo(userid,username,initials,usertype,bloodgroup,mnote,contactno,address) " +
                          "VALUES ('" + uidall + "','" + uname + "','" + _initials + "', '" + utype + "' ,'" + bgroup + "'," +
                          "'" + mnote + "', '" + cno + "','" + _address + "')";
        dbcmd.CommandText = sqlQuery;
        dbcmd.ExecuteScalar();

        dbconn.Close();
        check = true;

        //Debug.Log(sqlQuery);
    }

    void GetUserType()
    {
        if (utype_Index == 0)
        {
            utype = "Soldier";
        }
        if (utype_Index == 1)
        {
            utype = "Instructor";
        }
        if (utype_Index == 2)
        {
            utype = "Admin";
        }
    }

    void GetBGroup()
    {
        if(bgroup_Index==0)
        {
            bgroup = "A+";
        }
        if (bgroup_Index == 1)
        {
            bgroup = "A-";
        }
        if (bgroup_Index == 2)
        {
            bgroup = "B+";
        }
        if (bgroup_Index == 3)
        {
            bgroup = "B-";
        }
        if (bgroup_Index == 4)
        {
            bgroup = "AB+";
        }
        if (bgroup_Index == 5)
        {
            bgroup = "AB-";
        }
        if (bgroup_Index == 6)
        {
            bgroup = "O+";
        }
        if (bgroup_Index == 7)
        {
            bgroup = "O-";
        }
    }
}
