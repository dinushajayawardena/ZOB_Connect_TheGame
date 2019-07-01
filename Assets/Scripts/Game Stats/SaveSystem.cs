

/// <summary>
/// EDITED LATER FOR TESTING SAVE AND LOAD IN BINARY METHOD PURPOSE
/// </summary>
/// 
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer (WeaponManager weapon_Data)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/Player.zob";

        FileStream stream = new FileStream(path, FileMode.Create);


            PlayerData data = new PlayerData(weapon_Data);

        formatter.Serialize(stream, data);
        stream.Close();
    }


    public static PlayerData LoadPlayer()
    {
        

        string path = Application.persistentDataPath + "/Player.zob";
       
        if (File.Exists(path))
        {
            
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open); 

            PlayerData data= formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
