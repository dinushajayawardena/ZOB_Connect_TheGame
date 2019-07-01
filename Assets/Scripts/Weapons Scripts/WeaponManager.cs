using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private WeaponHandler[] weapons;

    public static int current_Weapon_Index;

    // Start is called before the first frame update
    void Start()
    {
        current_Weapon_Index = 0;
        weapons[current_Weapon_Index].gameObject.SetActive(true);
        WeaponHandler.bullets_Left = 6;
        WeaponHandler.bullets_Per_Mag = 6;
        WeaponHandler.bullets_Total = 30;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            TurnOnSelectedWeapon(0);

            WeaponHandler.bullets_Left = 6;

            WeaponHandler.bullets_Per_Mag = 6;

            WeaponHandler.bullets_Total = 30;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            TurnOnSelectedWeapon(1);

            WeaponHandler.bullets_Left = 1;

            WeaponHandler.bullets_Per_Mag = 1;

            WeaponHandler.bullets_Total = 45;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            TurnOnSelectedWeapon(2);

            WeaponHandler.bullets_Left = 30;

            WeaponHandler.bullets_Per_Mag = 30;

            WeaponHandler.bullets_Total = 320;
        }
    }

    void TurnOnSelectedWeapon(int weaponIndex)
    {
        if(current_Weapon_Index==weaponIndex)
        {
            return;
        }

        weapons[current_Weapon_Index].gameObject.SetActive(false); //turn off the current weapon
        weapons[weaponIndex].gameObject.SetActive(true); //turn on the weapon according to the input
        current_Weapon_Index = weaponIndex; //store the index as the current weapon number
    }

    public WeaponHandler GetCurrentSelectedWeapon()
    {
        
        return weapons[current_Weapon_Index];
    }

    /// <summary>
    /// EDITED LATER FOR TESTING SAVE AND LOAD IN BINARY METHOD PURPOSE
    /// </summary>
    //public void SavePlayer()
    //{

    //    SaveSystem.SavePlayer(this);
    //}

    //public void LoadPlayer()
    //{
    //    PlayerData data = SaveSystem.LoadPlayer();
        
    //    current_Weapon_Index = data.active_Weapon;
    //    Debug.Log(current_Weapon_Index);
    //}
}











