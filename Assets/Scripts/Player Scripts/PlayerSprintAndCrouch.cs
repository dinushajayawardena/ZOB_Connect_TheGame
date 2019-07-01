using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSprintAndCrouch : MonoBehaviour
{
    private PlayerMovement playerMovement;

    public float sprint_Speed = 10f;
    public float move_Speed = 5f;
    public float crouch_Speed = 2f;

    private Transform look_Root;
    
    private float stand_Height = 1.6f;
    private float crouch_Height = 1f;

    private bool is_Crouching;

    private PlayerFootsteps player_Footsteps;

    private float sprint_Volume = 1f;
    private float crouch_Volume = 0.1f;
    private float walk_Volume_Min=0.2f, walk_Volume_Max=0.6f;

    private float walk_Step_Distance = 0.4f;
    private float sprint_Step_Distance = 0.25f;
    private float crouch_Step_Distance = 0.5f;

    private PlayerStats player_Stats;

    private float sprint_Value = 100f;
    public float sprint_Treshold = 10f;

    private void Awake() 
    {
        playerMovement = GetComponent<PlayerMovement>();

        look_Root = transform.GetChild(0);

        player_Footsteps = GetComponentInChildren<PlayerFootsteps>();

        player_Stats = GetComponent<PlayerStats>();
    }

    private void Start()
    {
        player_Footsteps.volume_Min = walk_Volume_Min;
        player_Footsteps.volume_Max = walk_Volume_Max;
        player_Footsteps.step_Distance = walk_Step_Distance;
    }

    // Update is called once per frame
    void Update()
    {
        Sprint();
        Crouch();
    }

    void Sprint()
    {

        if (sprint_Value > 0f)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift) & !is_Crouching) //check whether the sprint key is pressed for once
            {
                playerMovement.speed = sprint_Speed; //set the speed as sprint speed

                player_Footsteps.volume_Min = sprint_Volume;
                player_Footsteps.volume_Max = sprint_Volume;
                player_Footsteps.step_Distance = sprint_Step_Distance;

            }
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && !is_Crouching) //check whether the pressed sprint key is released
        {
            playerMovement.speed = move_Speed; //set the speed as back to normal

            player_Footsteps.volume_Min = walk_Volume_Min;
            player_Footsteps.volume_Max = walk_Volume_Max;
            player_Footsteps.step_Distance = walk_Step_Distance;
        }

        if(Input.GetKey(KeyCode.LeftShift) && !is_Crouching)
        {
            sprint_Value -= sprint_Treshold * Time.deltaTime; //reduce the sprint value 

            if(sprint_Value<=0f)
            {
                sprint_Value = 0f;

                playerMovement.speed = move_Speed; //set the speed back to normal
                player_Footsteps.volume_Min = walk_Volume_Min;
                player_Footsteps.volume_Max = walk_Volume_Max;
                player_Footsteps.step_Distance = walk_Step_Distance;

             }
           player_Stats.Display_StaminaStats(sprint_Value); //passe value to the Display_StaminaStats method in the player_stats class

        }
        else
        {
            // Debug.Log("Error happened");
            if (sprint_Value != 100f)
            {
                sprint_Value += (sprint_Treshold / 2f) * Time.deltaTime; //increase the sprint value

                player_Stats.Display_StaminaStats(sprint_Value); //passe value to the Display_StaminaStats method in the player_stats class

                if (sprint_Value > 100f)
                {
                    sprint_Value = 100f;
                }
            }
        }
        
    }

    void Crouch()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            if(is_Crouching) //if player is crouching
            {
                look_Root.localPosition = new Vector3(0f,stand_Height,0f);
                playerMovement.speed = move_Speed;

                player_Footsteps.volume_Min = walk_Volume_Min;
                player_Footsteps.volume_Max = walk_Volume_Max;
                player_Footsteps.step_Distance = walk_Step_Distance;

                is_Crouching = false;
            }
            else //if player is standing
            {
                look_Root.localPosition = new Vector3(0f,crouch_Height,0f);
                playerMovement.speed = crouch_Speed;

                player_Footsteps.volume_Min = crouch_Volume;
                player_Footsteps.volume_Max = crouch_Volume;
                player_Footsteps.step_Distance = crouch_Step_Distance;

                is_Crouching = true;
            }
        }
    }
}

















