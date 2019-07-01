using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float amount;
    public float smooth_Amount;

    private Vector3 initial_Position;

    // Start is called before the first frame update
    void Start()
    {
        initial_Position = transform.localPosition; //assign the local position of the particular weapon as the initial position
    }

    // Update is called once per frame
    void Update()
    {
        float movement_X = -Input.GetAxis(MouseAxis.MOUSE_X) * amount; //give the opposite direction of the mouse x axis movement to the weapon to sway
        float movement_Y = -Input.GetAxis(MouseAxis.MOUSE_Y) * amount; //give the opposite direction of the mouse y axis movement to the weapon to sway

        Vector3 final_Position = new Vector3(movement_X,movement_Y,0f); //make the final coordinates of the weapon

        transform.localPosition = Vector3.Lerp(transform.localPosition,final_Position+initial_Position,Time.deltaTime*smooth_Amount);
        //make the amount in between final pos+init pos and the time consider in the frame* smooth amount
       
    }
}
