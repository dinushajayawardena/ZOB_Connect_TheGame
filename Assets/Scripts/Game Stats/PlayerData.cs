
/// <summary>
/// EDITED LATER FOR TESTING SAVE AND LOAD IN BINARY METHOD PURPOSE
/// </summary>

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{

    public int active_Weapon;

    public PlayerData (WeaponManager weapon_Data)
    {
        active_Weapon = WeaponManager.current_Weapon_Index;
    }
        

}

