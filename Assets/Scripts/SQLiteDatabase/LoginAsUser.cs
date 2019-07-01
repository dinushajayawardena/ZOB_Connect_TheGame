using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Mono.Data.Sqlite;
using System.Data;
using System;

using System.Text.RegularExpressions;
using UnityEngine.UI;

public class LoginAsUser : MonoBehaviour
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

    // Start is called before the first frame update
    void Start()
    {
        top_Label_Value = "enter your user id";
        top_Label2.active = false;
        con_Password.active = false;
        password.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
