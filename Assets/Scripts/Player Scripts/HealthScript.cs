using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthScript : MonoBehaviour
{

    public float health = 100f;

    private bool is_Dead;

    private PlayerStats player_Stats;
    
    void Awake()
    {
       // player_Stats = GetComponent<PlayerStats>();
    }

    public void ApplyDamage(float damage)
    {
        if (is_Dead)
            return;

       // health -= damage;

        player_Stats.Display_HealthStats(health);
        
        if(health <= 0f)
        {
            PlayerDied();

            is_Dead = true;
        }
    }

    void PlayerDied()
    {

    }
}
