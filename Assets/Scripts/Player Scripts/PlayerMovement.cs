using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // get gameobject
    private CharacterController character_Controller;
    private Vector3 move_Direction;
    public float speed = 5f;
    private float gravity = 20f;

    public float jump_Force = 10f;
    private float vertical_Velocity;

    // get components of game objects
     void Awake()
    {
        character_Controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveThePlayer();
    }

    void MoveThePlayer() // move the player
    {
        move_Direction = new Vector3(Input.GetAxis(Axis.HORIZONTAL), 0f, Input.GetAxis(Axis.VERTICAL));
        //get the direction of the player in the world space
 
        move_Direction = transform.TransformDirection(move_Direction);
        //convert the coordnates to local space to world space

        move_Direction = move_Direction * speed * Time.deltaTime;
        // smoothout the moment

        ApplyGravity(); 

        character_Controller.Move(move_Direction);
        // move the gamobject

    }
    void ApplyGravity() //apply gravity effect to the gameobject
    {
        
            vertical_Velocity -= gravity * Time.deltaTime;

            PlayerJump(); 
 
            move_Direction.y = vertical_Velocity*Time.deltaTime; //set player y axis velocity
    }

    void PlayerJump()
    {
        if (character_Controller.isGrounded && Input.GetKeyDown(KeyCode.Space))  
        {
            vertical_Velocity = jump_Force;
        }
    }
}
