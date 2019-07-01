
/// <summary>
/// EDITED LATER FOR TESTING SAVE AND LOAD IN BINARY METHOD
/// </summary>


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [SerializeField]
    private Image health_Stats, stamina_Stats; 

    public void Display_HealthStats(float healthValue) 
    {
        healthValue /= 100f;

        health_Stats.fillAmount = healthValue; //access to the fill amount property of health foreground image and set it to a variable

    }

    public void Display_StaminaStats(float staminaValue)
    {
        staminaValue /= 100f;

        stamina_Stats.fillAmount = staminaValue; //access to the fill amount property of health foreground image and set it to a variable

    }

}
