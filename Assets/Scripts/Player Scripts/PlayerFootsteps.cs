using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFootsteps : MonoBehaviour
{
    private AudioSource footstep_Sound;

    [SerializeField]
    private AudioClip[] footstep_Clip;

    private CharacterController character_Controller;

    [HideInInspector]
    public float volume_Min, volume_Max;

    private float accumulated_Distance;

    [HideInInspector]
    public float step_Distance;

    
    void Awake()
    {
        footstep_Sound = GetComponent<AudioSource>();
        character_Controller = GetComponentInParent<CharacterController>();

    }

    // Update is called once per frame
    void Update()
    {
        CheckToPlayFootstepSound();
        
    }

    void CheckToPlayFootstepSound()
    {
        if(!character_Controller.isGrounded) //if player is not on the ground
        {
            
            return;
        }
        if (character_Controller.velocity.sqrMagnitude > 0) //check whether the player is moving or not
        {
            accumulated_Distance += Time.deltaTime;

            if (accumulated_Distance > step_Distance)//check the audio clip need to play or not
            {
                footstep_Sound.volume = Random.Range(volume_Min, volume_Max); //vary the volume of the selected footstep clip
                footstep_Sound.clip = footstep_Clip[Random.Range(0, footstep_Clip.Length)];//vary the footstep clip within 4 audio
                footstep_Sound.Play();

               

                accumulated_Distance = 0f; //reset the accumulated distance
            }
        }
        else
        {
            accumulated_Distance = 0f; //reset the accumulated distance
        }
                

        

    }
}












